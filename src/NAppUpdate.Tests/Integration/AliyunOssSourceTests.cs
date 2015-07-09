using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAppUpdate.Framework.Sources;
using System.IO;

namespace NAppUpdate.Tests.Integration
{
	[TestClass]
	public class AliyunOssSourceTests
    {
        private string OssEndPoint = "http://oss.aliyuncs.com/";
        private string AccessKeyId = "QuBc7LxHY0Ov7xL6";
        private string AccessKeySecret = "i57W4W7v6di74ObX4LZSa8NbejTF2d";
        private string BucketName = "2ciyuan-test";
        private string SourceRoot = "NetterClient";

        [TestMethod]
		public void can_download_utf_feed()
		{
            var aot = new AliyunOSSTransfer(OssEndPoint, AccessKeyId, AccessKeySecret);
            var aos = new AliyunOssSource(aot, BucketName, SourceRoot);
			var str = aos.GetUpdatesFeed();

            string expected = "<?xml version=";
            Assert.AreEqual(expected, str.Substring(0, expected.Length));
		}

        [TestMethod]
        public void can_download_file()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\UpdateFeed.xml";
            File.Delete(filePath);

            var aot = new AliyunOSSTransfer(OssEndPoint, AccessKeyId, AccessKeySecret);
            var aos = new AliyunOssSource(aot, BucketName, SourceRoot);

            Assert.IsTrue(aos.GetData("UpdateFeed.xml", "", null, ref filePath));
            Assert.IsTrue(File.Exists(filePath));

            string fileContent = File.ReadAllText(filePath);
            string expected = "<?xml version=";
            Assert.AreEqual(expected, fileContent.Substring(0, expected.Length));
        }

        [TestMethod]
        public void can_upload_file()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\test.xml";
            File.WriteAllText(filePath, "test");

            var aot = new AliyunOSSTransfer(OssEndPoint, AccessKeyId, AccessKeySecret);
            var aos = new AliyunOssSource(aot, BucketName, SourceRoot);

            string OssTestXml = SourceRoot + "/test.xml";
            aot.DeleteObject(BucketName, OssTestXml);
            Assert.AreEqual(aot.GetObjectSize(BucketName, OssTestXml), 0);

            Assert.IsTrue(aos.DeployData("test.xml", "", null, filePath));
            Assert.AreEqual(aot.GetObjectSize(BucketName, OssTestXml), new FileInfo(filePath).Length);

            aot.DeleteObject(BucketName, OssTestXml);
            File.Delete(filePath);
        }

    }
}
