using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAppUpdate.Framework.Sources;
using System.IO;

namespace NAppUpdate.Tests.Integration
{
	[TestClass]
	public class AliyunOssSourceTests
    {
		[TestMethod]
		public void can_download_utf_feed()
		{
            var aot = new AliyunOSSTransfer("http://oss.aliyuncs.com/", "QuBc7LxHY0Ov7xL6", "i57W4W7v6di74ObX4LZSa8NbejTF2d");
            var aos = new AliyunOssSource(aot, "2ciyuan-test", "NetterClient");
			var str = aos.GetUpdatesFeed();

            string expected = "<?xml version=";
            Assert.AreEqual(expected, str.Substring(0, expected.Length));
		}

        [TestMethod]
        public void can_download_file()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\UpdateFeed.xml";
            File.Delete(filePath);

            var aot = new AliyunOSSTransfer("http://oss.aliyuncs.com/", "QuBc7LxHY0Ov7xL6", "i57W4W7v6di74ObX4LZSa8NbejTF2d");
            var aos = new AliyunOssSource(aot, "2ciyuan-test", "NetterClient");

            Assert.IsTrue(aos.GetData("UpdateFeed.xml", "", null, ref filePath));
            Assert.IsTrue(File.Exists(filePath));

            string fileContent = File.ReadAllText(filePath);
            string expected = "<?xml version=";
            Assert.AreEqual(expected, fileContent.Substring(0, expected.Length));
        }

    }
}
