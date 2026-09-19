using System;
using System.Security.Cryptography;
using System.Text;

namespace StarUML_Keyfilemaker
{
    public static class AesGcmEncryption
    {

        // Import AES key from Base64 string
        public static byte[] ImportAesKey(string base64Key)
        {
            return Convert.FromBase64String(base64Key);
        }

        // Base64 encoding (byte[] -> Base64 string)
        private static string ArrayBufferToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        // Base64 decoding (Base64 string -> byte[])
        private static byte[] Base64ToArrayBuffer(string base64)
        {
            return Convert.FromBase64String(base64);
        }

        // Encryption AES-GCM function
        public static string EncryptString(string plainText, byte[] key)
        {
            int tagLength = 16;

            using (var aesGcm = new AesGcm(key, tagLength)) {
                var iv = new byte[12];

                RandomNumberGenerator.Create().GetBytes(iv);

                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

                byte[] encryptedBytes = new byte[plainBytes.Length];

                byte[] tag = new byte[tagLength];

                aesGcm.Encrypt(iv, plainBytes, encryptedBytes, tag);

                byte[] encryptedWithTag = new byte[encryptedBytes.Length + tag.Length];

                Buffer.BlockCopy(encryptedBytes, 0, encryptedWithTag, 0, encryptedBytes.Length);

                Buffer.BlockCopy(tag, 0, encryptedWithTag, encryptedBytes.Length, tag.Length);

                string ivBase64 = ArrayBufferToBase64(iv);

                string encryptedBase64 = ArrayBufferToBase64(encryptedWithTag);

                return $"{ivBase64}:{encryptedBase64}";
            }
        }

        // Decryption AES-GCM function
        public static string DecryptString(string encryptedText, byte[] key)
        {
            string[] parts = encryptedText.Split(':');

            if (parts.Length != 2)
                throw new ArgumentException("The encryptedText must contains IV and ciphertext separated by ':'");

            byte[] iv = Base64ToArrayBuffer(parts[0]);

            byte[] encryptedWithTag = Base64ToArrayBuffer(parts[1]);

            int tagLength = 16;

            byte[] ciphertext = new byte[encryptedWithTag.Length - tagLength];

            byte[] tag = new byte[tagLength];

            Buffer.BlockCopy(encryptedWithTag, 0, ciphertext, 0, ciphertext.Length);

            Buffer.BlockCopy(encryptedWithTag, ciphertext.Length, tag, 0, tagLength);

            using (var aesGcm = new AesGcm(key, tagLength)) {
                byte[] decryptedBytes = new byte[ciphertext.Length];

                aesGcm.Decrypt(iv, ciphertext, tag, decryptedBytes);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

    }
}
