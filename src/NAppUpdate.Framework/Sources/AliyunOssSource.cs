﻿using System;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Utils;
using System.Net;
using System.IO;

namespace NAppUpdate.Framework.Sources
{
	public class AliyunOssSource : IUpdateSource
	{
        private AliyunOSSTransfer AliyunTransfer { get; set; }
        private string BucketName { get; set; }
        private string SourceRoot { get; set; }
        private string FeedPath
        {
            get { return SourceRoot + @"/UpdateFeed.xml"; }
        }

        public AliyunOssSource(AliyunOSSTransfer aliyunTransfer, string bucketName
            , string sourceRoot)
		{
            AliyunTransfer = aliyunTransfer;
            BucketName = bucketName;
            SourceRoot = sourceRoot;
		}

		#region IUpdateSource Members

	    public string GetUpdatesFeed()
	    {
            try
            {
                using (var result = AliyunTransfer.GetObject(BucketName, FeedPath))
                {
                    using (StreamReader reader = new StreamReader(result.Content))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch(Exception)
            {

            }

            return "";
		}

		public bool GetData(string fileKey, string baseKey, Action<UpdateProgressInfo> onProgress, ref string tempLocation)
		{
            try
            {
                //aliyun对于"a//b"这样的路径不认，只认"a/b"
               string fullFileKey = (SourceRoot + "/" + baseKey + "/" + fileKey).Replace("//", "/");
                AliyunDownloadRequst downloadRequest = new AliyunDownloadRequst(BucketName, fullFileKey
                    , tempLocation);
                AliyunTransfer.GetObject(downloadRequest);
                return true;
            }
            catch (Exception)
            {

            }

            return false;
		}

        public bool DeployData(string fileKey, string baseKey, Action<UpdateProgressInfo> onProgress, string fileLocation)
        {
            try
            {
                //aliyun对于"a//b"这样的路径不认，只认"a/b"
                string fullFileKey = (SourceRoot + "/" + baseKey + "/" + fileKey).Replace("//", "/");
                AliyunUploadRequest uploadRequest = new AliyunUploadRequest(BucketName, fullFileKey
                    , fileLocation);
                uploadRequest.TranseferFileEvent += delegate (long transferedBytes, long totalBytes)
                {
                    onProgress(new UpdateProgressInfo
                    {
                        Percentage = (totalBytes == 0) ? 0 : (int)(transferedBytes * 100 / totalBytes),
                        StillWorking = (transferedBytes != totalBytes),
                    });
                };
                AliyunTransfer.PutObejct(uploadRequest);
                return true;
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
            return false;
        }

        #endregion
    }
}
