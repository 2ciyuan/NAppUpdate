using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace FeedBuilder.ServerProfile
{
    class SecretFile
    {
        string m_FileName;
        static string abcStr = "buvcfgahopqidejwxrstyklmnz";
        public SecretFile(string filename)
        {
            m_FileName = filename;
        }
        public string ReadAll()
        {
            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(abcStr[6].ToString() + abcStr[0].ToString() + abcStr[17].ToString() + abcStr[10].ToString() + abcStr[20].ToString() + abcStr[8].ToString() + abcStr[4].ToString() + abcStr[12].ToString());
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(abcStr[16].ToString() + abcStr[10].ToString() + abcStr[7].ToString() + abcStr[1].ToString() + abcStr[2].ToString() + abcStr[18].ToString() + abcStr[14].ToString() + abcStr[21].ToString());

            // Create the streams used for encryption. 
            using (FileStream msEncrypt = new FileStream(m_FileName, FileMode.Open))
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, cryptic.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader swEncrypt = new StreamReader(csEncrypt))
                    {
                        //Write all data to the stream.
                        return swEncrypt.ReadToEnd();
                    }
                    //encrypted = msEncrypt.ToArray();
                }
            }
        }
        public void Write(string data)
        {
            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(abcStr[6].ToString() + abcStr[0].ToString() + abcStr[17].ToString() + abcStr[10].ToString() + abcStr[20].ToString() + abcStr[8].ToString() + abcStr[4].ToString() + abcStr[12].ToString());
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(abcStr[16].ToString() + abcStr[10].ToString() + abcStr[7].ToString() + abcStr[1].ToString() + abcStr[2].ToString() + abcStr[18].ToString() + abcStr[14].ToString() + abcStr[21].ToString());

            // Create the streams used for encryption. 
            using (FileStream msEncrypt = new FileStream(m_FileName, FileMode.Create))
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, cryptic.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {

                        //Write all data to the stream.
                        swEncrypt.Write(data);
                    }
                }
            }
        }
    }
}
