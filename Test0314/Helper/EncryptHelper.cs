using System.Text;
using System.Security.Cryptography;

namespace Test0314.Helper
{
    public class EncryptHelper
    {
        public static string GetSHA1(string text)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }

            return sh1;
        
        }

    }
}