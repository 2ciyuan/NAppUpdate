using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Aliyun.OpenServices;
using Aliyun.OpenServices.OpenStorageService;

namespace NAppUpdate.Framework.Sources
{
    class AliyunStream : Stream
    {
        Stream _innerStream;
        public delegate void ReadPositionChangeEventHandler(long nowPosition, long totalBytes);
        public event ReadPositionChangeEventHandler ReadPositionChangeEvent;
        public delegate void WritePositionChangeEventHandler(long nowPosition, long totalBytes);
        public event WritePositionChangeEventHandler WritePositionChangeEvent;

        public AliyunStream(Stream stream)
        {
            _innerStream = stream;
        }

        public override bool CanRead
        {
            get { return _innerStream.CanRead; }
        }

        public override bool CanWrite
        {
            get { return _innerStream.CanWrite; }
        }

        public override bool CanSeek
        {
            get { return _innerStream.CanSeek; }
        }

        public override long Length
        {
            get { return _innerStream.Length; }
        }

        public override long Position
        {
            get
            {
                return _innerStream.Position;
            }

            set
            {
                _innerStream.Position = value;
            }
        }

        public override void Flush()
        {
            _innerStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _innerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _innerStream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int ret = _innerStream.Read(buffer, offset, count);
            if (ReadPositionChangeEvent != null)
            {
                ReadPositionChangeEvent(_innerStream.Position, _innerStream.Length);
            }
            return ret;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _innerStream.Write(buffer, offset, count);
            if (WritePositionChangeEvent != null)
            {
                WritePositionChangeEvent(_innerStream.Position, _innerStream.Length);
            }
        }
    }

    public class AliyunUploadRequest
    {
        public string bucketName { get; set; }
        public string key { get; set; }
        public string file { get; set; }

        public delegate void TranseferFileEventHandler(long transferedBytes, long totalBytes);
        public event TranseferFileEventHandler TranseferFileEvent;

        public AliyunUploadRequest(string _bucketName, string _key, string _file)
        {
            bucketName = _bucketName;
            key = _key;
            file = _file;
        }

        public void TransferFile(long transferedBytes, long totalBytes)
        {
            if (TranseferFileEvent != null)
            {
                TranseferFileEvent(transferedBytes, totalBytes);
            }
        }
    }

    public class AliyunDownloadRequst
    {
        public string bucketName { get; set; }
        public string key { get; set; }
        public string file { get; set; }

        public delegate void TranseferFileEventHandler(long transferedBytes, long totalBytes);
        public event TranseferFileEventHandler TranseferFileEvent;

        public AliyunDownloadRequst(string _bucketName, string _key, string _file)
        {
            bucketName = _bucketName;
            key = _key;
            file = _file;
        }

        public void TransferFile(long transferedBytes, long totalBytes)
        {
            if (TranseferFileEvent != null)
            {
                TranseferFileEvent(transferedBytes, totalBytes);
            }
        }
    }

    public class AliyunUploadDirectoryRequest
    {
        public string bucketName { get; set; }
        public string key { get; set; }
        public string directory { get; set; }

        public delegate void TranseferDirectoryEventHandler(long transferedBytes, long totalBytes, int transferedFiles, int totalFiles);
        public event TranseferDirectoryEventHandler TranseferDirectoryEvent;

        public AliyunUploadDirectoryRequest(string _bucketName, string _key, string _directory)
        {
            bucketName = _bucketName;
            key = _key;
            directory = _directory;
        }

        public void TransferDirectory(long transferedBytes, long totalBytes, int transferedFiles, int totalFiles)
        {
            if (TranseferDirectoryEvent != null)
            {
                TranseferDirectoryEvent(transferedBytes, totalBytes, transferedFiles, totalFiles);
            }
        }
    }

    public class AliyunDownloadDirectoryRequest
    {
        public string bucketName { get; set; }
        public string key { get; set; }
        public string directory { get; set; }

        public delegate void TranseferDirectoryEventHandler(long transferedBytes, long totalBytes, int transferedFiles, int totalFiles);
        public event TranseferDirectoryEventHandler TranseferDirectoryEvent;

        public AliyunDownloadDirectoryRequest(string _bucketName, string _key, string _directory)
        {
            bucketName = _bucketName;
            key = _key;
            directory = _directory;
        }

        public void TransferDirectory(long transferedBytes, long totalBytes, int transferedFiles, int totalFiles)
        {
            if (TranseferDirectoryEvent != null)
            {
                TranseferDirectoryEvent(transferedBytes, totalBytes, transferedFiles, totalFiles);
            }
        }
    }

    public class AliyunOSSTransfer
    {
        private OssClient _ossClient = null;

        public AliyunOSSTransfer(string endPoint, string AccessKeyID, string AccessKeySecret)
        {
            ClientConfiguration config = new ClientConfiguration();
            config.ConnectionTimeout = 5 * 60 * 1000;
            config.MaxErrorRetry = 5;

            _ossClient = new OssClient(new Uri(endPoint), AccessKeyID, AccessKeySecret, config);
        }

        public PutObjectResult PutObejct(AliyunUploadRequest uploadRequest)
        {
            //网上的文件是正确的了，不上传了，相当于文件级别的断点续传
//             if (GetObjectEtag(uploadRequest.bucketName, uploadRequest.key).ToUpper()
//                  == NewBotUtil.UtilHelpers.CalcFileChecksum(uploadRequest.file).ToUpper())
//             {
//                 return null;
//             }

            PutObjectResult ret = null;
            using (FileStream fs = new FileStream(uploadRequest.file, FileMode.Open))
            {
                AliyunStream stream = new AliyunStream(fs);
                stream.ReadPositionChangeEvent += delegate(long nowPosition, long totalBytes)
                {
                    uploadRequest.TransferFile(nowPosition, totalBytes);
                };
                ret = _ossClient.PutObject
                    (
                    uploadRequest.bucketName, uploadRequest.key, stream,
                    new ObjectMetadata()
                    {
                        ContentLength = fs.Length,
//                         ETag = NewBotUtil.UtilHelpers.CalcFileChecksum(uploadRequest.file), //ETag记录MD5值，用于短点续传的判断
                    }
                    );
            }

            return ret;
        }

        public ObjectMetadata GetObject(AliyunDownloadRequst downloadRequst)
        {
            ObjectMetadata ret = null;
            using (FileStream fs = new FileStream(downloadRequst.file, FileMode.Create))
            {
                long totalBytes = GetObjectSize(downloadRequst.bucketName, downloadRequst.key);
                AliyunStream stream = new AliyunStream(fs);
                stream.WritePositionChangeEvent += delegate(long nowPosition, long _totalBytes)
                {
                    downloadRequst.TransferFile(nowPosition, totalBytes);
                };
                GetObjectRequest getObjectRequest = new GetObjectRequest(downloadRequst.bucketName, downloadRequst.key);
                ret = _ossClient.GetObject(getObjectRequest, stream);
            }

            return ret;
        }

        public OssObject GetObject(string bucketName, string key)
        {
            return _ossClient.GetObject(bucketName, key);
        }

        public long GetObjectSize(string bucketName, string key)
        {
            ObjectListing listObject = _ossClient.ListObjects(bucketName, key);
            foreach (var objSummary in listObject.ObjectSummaries)
            {
                return objSummary.Size;
            } 
            return 0;
        }

        public string GetObjectEtag(string bucketName, string key)
        {
            ObjectListing listObject = _ossClient.ListObjects(bucketName, key);
            foreach (var objSummary in listObject.ObjectSummaries)
            {
                return objSummary.ETag;
            }
            return "";
        }

        /// <summary>
        /// 目录上传，只支持一层目录
        /// </summary>
        /// <param name="uploadDirectoryRequest"></param>
        public void PutDirectory(AliyunUploadDirectoryRequest uploadDirectoryRequest)
        {
            if (Directory.Exists(uploadDirectoryRequest.directory) == false)
            {
                throw new DirectoryNotFoundException();
            }

            DirectoryInfo dirInfo = new DirectoryInfo(uploadDirectoryRequest.directory);
            FileInfo[] files = dirInfo.GetFiles();
            int totalFiles = files.Length;
            int transferFiles = 0;
            foreach (var file in files)
            {
                AliyunUploadRequest uploadRequest = new AliyunUploadRequest(uploadDirectoryRequest.bucketName, 
                    uploadDirectoryRequest.key + @file.Name, file.FullName);
                uploadRequest.TranseferFileEvent += delegate(long transferedBytes, long totalBytes)
                {
                    uploadDirectoryRequest.TransferDirectory(transferedBytes, totalBytes, transferFiles, totalFiles);
                };

                PutObejct(uploadRequest);
                transferFiles++;
            }
        }

        public void GetDirectory(AliyunDownloadDirectoryRequest downloadDirectoryRequst)
        {

        }

        /// <summary>
        /// 目录删除，暂时只支持一层文件夹
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        public void DeleteDirectory(string bucketName, string key)
        {
            ObjectListing listObject = _ossClient.ListObjects(bucketName, key);
            foreach (var objSummary in listObject.ObjectSummaries)
            {
                _ossClient.DeleteObject(objSummary.BucketName, objSummary.Key);
            }
            _ossClient.DeleteObject(bucketName, key);
        }

        public CopyObjectResult CopyObject(string sourceBucketName, string sourceDir, string destBucketName, string destDir)
        {
            CopyObjectRequest copyObjectRequest = new CopyObjectRequest(sourceBucketName, sourceDir, destBucketName, destDir);
            return _ossClient.CopyObject(copyObjectRequest);
        }

        /// <summary>
        /// 目录拷贝，暂时只支持一层文件夹
        /// </summary>
        /// <param name="sourceBucketName"></param>
        /// <param name="sourceDir"></param>
        /// <param name="destBucketName"></param>
        /// <param name="destDir"></param>
        public void CopyDirectory(string sourceBucketName, string sourceDir, string destBucketName, string destDir)
        {
            ListObjectsRequest listObjectRequest = new ListObjectsRequest(sourceBucketName);
            listObjectRequest.Prefix = sourceDir;
            listObjectRequest.Delimiter = @"/";
            ObjectListing listObject = _ossClient.ListObjects(listObjectRequest);
            foreach (var objSummary in listObject.ObjectSummaries)
            {
                CopyObjectRequest copyObjectRequest
                    = new CopyObjectRequest(objSummary.BucketName, objSummary.Key
                        , destBucketName, destDir + objSummary.Key.Substring(sourceDir.Length));
                _ossClient.CopyObject(copyObjectRequest); 
            }
        }
    }
}
