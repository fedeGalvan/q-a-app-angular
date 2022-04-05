using System;
using System.Security.Cryptography;
using System.Text;

namespace Api.Utils
{
    public static class Crypt
    {

        public static string CryptPassword(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        internal static string CryptPassword(object prevPassword)
        {
            throw new NotImplementedException();
        }
    }
}
