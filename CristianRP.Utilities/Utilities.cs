using System;

namespace CristianRP.Utilities
{
    public static class Utilities
    {
        /// <summary>
        /// Basic encrypt
        /// </summary>
        /// <param name="encrypt"></param>
        /// <returns>string</returns>
        public static string Encrypt(this string encrypt)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(encrypt);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// <summary>
        /// Basic decrypt
        /// </summary>
        /// <param name="decrypt"></param>
        /// <returns>string</returns>
        public static string Decrypt(this string decrypt)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(decrypt);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
