using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashHelp
{
    public static class Sha1Help
    {
        public static string Message2KeyWord(this string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);// new byte[DATA_SIZE];

            var sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            data = sha.ComputeHash(data);
            var keyTmp = System.Convert.ToBase64String(data);
            return keyTmp;
        }
    }
}
