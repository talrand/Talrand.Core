using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Talrand.Core
{
    public class Encryption
    {
        public static readonly string Key = ConfigurationManager.AppSettings["Encryption_Key"];
        public static readonly Encoding Encoder = Encoding.UTF8;

        /// <summary>
        /// Encrypts passed text using Triple DES encryption
        /// </summary>
        /// <param name="plainText">A string containing the text to encrypt</param>
        /// <returns>A string containing the encrypted text</returns>
        public string Encrypt(string plainText)
        {
            var des = CreateDes(Key);
            var ct = des.CreateEncryptor();
            var input = Encoding.UTF8.GetBytes(plainText);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(output);
        }

        /// <summary>
        /// Decrypts the passed encrypted text
        /// </summary>
        /// <param name="cypherText">A string containing the encrypted text</param>
        /// <returns>A string containing the decrypted text</returns>
        public string Decrypt(string cypherText)
        {
            var des = CreateDes(Key);
            var ct = des.CreateDecryptor();
            var input = Convert.FromBase64String(cypherText);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Encoding.UTF8.GetString(output);
        }

        /// <summary>
        /// Creates TripleDES encryptor
        /// </summary>
        /// <param name="key">A string containing the encryption key</param>
        /// <returns>TripleDES encryptor object</returns>
        private TripleDES CreateDes(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            var desKey = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            des.Key = desKey;
            des.IV = new byte[des.BlockSize / 8];
            des.Padding = PaddingMode.PKCS7;
            des.Mode = CipherMode.ECB;
            return des;
        }
    }
}