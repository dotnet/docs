using System.Security.Cryptography;

if (args.Length < 1)
{
    Console.WriteLine("Usage: aes-decrypt <hex-key>");
    return;
}

try
{
    using (FileStream fileStream = new("TestData.txt", FileMode.Open))
    {
        using (Aes aes = Aes.Create())
        {
            byte[] iv = new byte[aes.IV.Length];
            int numBytesToRead = aes.IV.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
                if (n == 0) break;

                numBytesRead += n;
                numBytesToRead -= n;
            }

            // The key must match the key used during encryption.
            // In production, retrieve the key from a secure key management
            // system rather than hardcoding it in source code.
            byte[] key = Convert.FromHexString(args[0]);

            using (CryptoStream cryptoStream = new(
               fileStream,
               aes.CreateDecryptor(key, iv),
               CryptoStreamMode.Read))
            {
                // By default, the StreamReader uses UTF-8 encoding.
                // To change the text encoding, pass the desired encoding as the second parameter.
                // For example, new StreamReader(cryptoStream, Encoding.Unicode).
                using (StreamReader decryptReader = new(cryptoStream))
                {
                    string decryptedMessage = await decryptReader.ReadToEndAsync();
                    Console.WriteLine($"The decrypted original message: {decryptedMessage}");
                }
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"The decryption failed. {ex}");
}
