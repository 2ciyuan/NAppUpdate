using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.IO;

namespace FeedBuilder.ServerProfile
{
    public class SecretProfile<T>
    {
        public static T FromJson(string json)
        {
            var jsn = new JavaScriptSerializer();
            return jsn.Deserialize<T>(json);
        }
        public string ToJson()
        {
            var jsn = new JavaScriptSerializer();
            return jsn.Serialize(this);
        }

        public static T LoadFromFile(string filename)
        {
            SecretFile sf = new SecretFile(filename);
            return FromJson(sf.ReadAll());

        }
        public void SaveToFile(string filename)
        {
            SecretFile sf = new SecretFile(filename);
            sf.Write(ToJson());
        }
    }
}
