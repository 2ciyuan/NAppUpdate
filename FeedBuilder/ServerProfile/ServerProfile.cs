using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.IO;

namespace FeedBuilder.ServerProfile
{
    public class ServerProfile : SecretProfile<ServerProfile>
    {
        public string OssEndPoint { get; set; }
        public string OssBucketName { get; set; }
        public string OssAccessKeyID { get; set; }
        public string OssAccessKeySecret { get; set; }
        /// <summary>
        /// 远程服务器的更新目录
        /// </summary>
        public string OssSourceRoot { get; set; }
    }
}
