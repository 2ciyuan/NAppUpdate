using System;
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

		public bool GetData(string url, string baseUrl, Action<UpdateProgressInfo> onProgress, ref string tempLocation)
		{
			return true;
		}

		#endregion
	}
}
