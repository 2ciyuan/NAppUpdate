using System;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Utils;
using System.Net;
using System.IO;

namespace NAppUpdate.Framework.Sources
{
	public class AliyunOssSource : IUpdateSource
	{
		public AliyunOssSource(string accessKeyId, string accessKeySecret, string bucketName
            , string sourceRoot)
		{
		}

		#region IUpdateSource Members

	    public string GetUpdatesFeed()
	    {
			return "";
		}

		public bool GetData(string url, string baseUrl, Action<UpdateProgressInfo> onProgress, ref string tempLocation)
		{
			return true;
		}

		#endregion
	}
}
