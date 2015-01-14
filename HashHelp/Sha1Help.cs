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
            byte[] data = Encoding.UTF8.GetBytes(message);

            var sha = new SHA1CryptoServiceProvider();
            data = sha.ComputeHash(data);
            var keyTmp = System.Convert.ToBase64String(data);
            return keyTmp;
        }
    }
}
