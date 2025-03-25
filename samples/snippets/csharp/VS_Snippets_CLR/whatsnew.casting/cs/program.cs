using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Casting
{
   class Program
   {
      static void Main(string[] args)
      {
         EncryptWithCasting();
         EncryptWithoutCasting();

         Console.ReadLine();
      }

      private static void EncryptWithCasting()
      {
         byte[] data = { 1, 2, 4, 8, 16, 32, 64, 128 };
         X509Certificate2 cert = new X509Certificate2();
         try {
            // <Snippet1>
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] oaepEncrypted = rsa.Encrypt(data, true);
            byte[] pkcs1Encrypted = rsa.Encrypt(data, false);
            // </Snippet1>
         }
         catch (Exception e)
         {
            Console.WriteLine($"{e.GetType().Name}: {e.Message}");
         }
      }

      private static void EncryptWithoutCasting()
      {
         byte[] data = { 1, 2, 4, 8, 16, 32, 64, 128 };
         X509Certificate2 cert = new X509Certificate2();

         // <Snippet2>
         RSA rsa = cert.GetRSAPrivateKey();
         if (rsa == null)
            throw new InvalidOperationException("An RSA certificate was expected");

         byte[] oaepEncrypted = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA1);
         byte[] pkcs1Encrypted = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
         // </Snippet2>
      }
   }
}
