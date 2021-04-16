using System;
using System;
using System.IO;
using System.Security.Cryptography;

try
{
    using (FileStream fileStream = new("TestData.txt", FileMode.OpenOrCreate))
    {

        // Create an instance of the default Aes implementation class
        // and configure the encryption key.
        using Aes aes = Aes.Create();

        // Encryption key used to encrypt the stream.
        // The same value must be used to encrypt and decrypt the stream.
        byte[] key =
        {
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };
        aes.Key = key;

        // Stores IV at the beginning of the file.
        // This information will be used for decryption.
        byte[] iv = aes.IV;
        fileStream.Write(iv, 0, iv.Length);

        // Create a CryptoStream, pass it the FileStream, and encrypt
        // it with the Aes class.
        using (CryptoStream cryptoStream = new(
            fileStream,
            aes.CreateEncryptor(),
            CryptoStreamMode.Write))
        {
            using (StreamWriter encryptWriter = new(cryptoStream))
            {
                encryptWriter.WriteLine("Hello World!");
            }
        }
    }

    Console.WriteLine("The file was encrypted.");
}
catch (Exception ex)
{
    Console.WriteLine($"The encryption failed. {ex}");
}
