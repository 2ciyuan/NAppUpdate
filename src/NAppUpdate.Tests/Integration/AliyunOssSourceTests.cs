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
            var aos = new AliyunOssSource("QuBc7LxHY0Ov7xL6", "i57W4W7v6di74ObX4LZSa8NbejTF2d", "2ciyuan-test", "NetterClient");
// 			const string expected = "NHibernate.Profiler-Build-";
// 
// 			var ws = new SimpleWebSource("http://builds.hibernatingrhinos.com/latest/nhprof");
// 			var str = ws.GetUpdatesFeed();
// 
// 			Assert.AreEqual(expected, str.Substring(0, expected.Length));
		}
	}
}
