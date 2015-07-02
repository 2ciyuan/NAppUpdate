using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAppUpdate.Framework.Sources;

namespace NAppUpdate.Tests.Integration
{
	[TestClass]
	public class AliyunOssSourceTests
    {
		[TestMethod]
		public void can_download_ansi_feed()
		{
            string expected = "<?xml version=";

            var aot = new AliyunOSSTransfer("http://oss.aliyuncs.com/", "QuBc7LxHY0Ov7xL6", "i57W4W7v6di74ObX4LZSa8NbejTF2d");
            var aos = new AliyunOssSource(aot, "2ciyuan-test", "NetterClient");
			var str = aos.GetUpdatesFeed();

			Assert.AreEqual(expected, str.Substring(0, expected.Length));
		}
	}
}
