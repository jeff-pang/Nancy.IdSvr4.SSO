using Nancy.Cryptography;
using System;
using System.Security.Cryptography;

namespace SSOServer.Core.NancyCustom
{
    public class RSACryptoProvider : IEncryptionProvider
    {
        public string Decrypt(string data)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.KeySize = 2048;
                byte[] bData = Convert.FromBase64String(data);
                byte[] bDecrypyedData = rsa.Decrypt(bData, RSAEncryptionPadding.OaepSHA256);

                return Convert.ToBase64String(bDecrypyedData);
            }
        }

        public string Encrypt(string data)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.KeySize = 2048;
                byte[] bData = Convert.FromBase64String(data);
                byte[] bEncryptedData = rsa.Encrypt(bData, RSAEncryptionPadding.OaepSHA256);

                return Convert.ToBase64String(bEncryptedData);
            }
        }
    }
}
