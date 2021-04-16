using System;
using System.IO;
using System.Security.Cryptography;

try
{
    using FileStream fileStream = new("TestData.txt", FileMode.Open);

    // Create a new instance of the default Aes implementation class
    using Aes aes = Aes.Create();

    // Reads IV value from beginning of the file.
    byte[] iv = new byte[aes.IV.Length];
    fileStream.Read(iv, 0, iv.Length);

    // Decryption key must be the same value that was used
    // to encrypt the stream.
    byte[] key =
    {
        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
        0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
    };

    // Create a CryptoStream, pass it the file stream, and decrypt
    // it with the Aes class using the key and IV.
    using CryptoStream cryptoStream = new(
       fileStream,
       aes.CreateDecryptor(key, iv),
       CryptoStreamMode.Read);

    // Read the stream.
    using StreamReader decryptReader = new(cryptoStream);

    var decryptedMessage = await decryptReader.ReadToEndAsync();

    Console.WriteLine($"The decrypted original message: {decryptedMessage}");
}
catch (Execption ex)
{
    Console.WriteLine($"The decryption failed. {ex}");
    throw;
}
