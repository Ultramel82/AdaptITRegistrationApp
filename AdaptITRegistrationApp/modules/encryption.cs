using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace AdaptITRegistrationApp.modules
{
    public class encryption
    {
        byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        byte[] iv = { 65, 110, 68, 26, 69, 178, 200, 219 };

        public byte[] Encrypt(string plainText)
        {

            try
            {
                // Declare a UTF8Encoding object so we may use the GetByte
                // method to transform the plainText into a Byte array.
                UTF8Encoding utf8encoder = new UTF8Encoding();
                Byte[] inputInBytes = utf8encoder.GetBytes(plainText);

                //Create a new TripleDES service provider
                TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();

                // The ICryptTransform interface uses the TripleDES
                // crypt provider along with encryption key and init vector information
                ICryptoTransform cryptoTransform = tdesProvider.CreateEncryptor(this.key, this.iv);

                // All cryptographic functions need a stream to output the
                // encrypted information. Here we declare a memory stream for this purpose.
                MemoryStream encryptedStream = new MemoryStream();
                CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);

                // Write the encrypted information to the stream. Flush the information
                // when done to ensure everything is out of the buffer.
                cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
                cryptStream.FlushFinalBlock();
                encryptedStream.Position = 0;

                // Read the stream back into a Byte array and return it to the calling method.
                byte[] result = new byte[encryptedStream.Length];
                encryptedStream.Read(result, 0, Convert.ToInt16(encryptedStream.Length));
                cryptStream.Close();

                return result;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}