using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5Encrypt
{
    public static class MD5Encrypt
    {
        public static string GetMd5(string msg)
        {
            string cryptStr = "";
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            byte[] cryptBytes = md5.ComputeHash(bytes);
            for (int i = 0; i < cryptBytes.Length; i++)
            {
                cryptStr += cryptBytes[i].ToString("X2");
            }
            return cryptStr;
        }
    }
}
