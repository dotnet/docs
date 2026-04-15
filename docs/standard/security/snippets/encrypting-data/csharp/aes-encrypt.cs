using System.Security.Cryptography;

try
{
    string keyHex;

    using (FileStream fileStream = new("TestData.txt", FileMode.OpenOrCreate))
    {
        using (Aes aes = Aes.Create())
        {
            // Generate a cryptographically secure random key.
            // In production, use a key management system or derive from a
            // password using Rfc2898DeriveBytes.Pbkdf2 with a high iteration count.
            aes.GenerateKey();
            keyHex = Convert.ToHexString(aes.Key);

            byte[] iv = aes.IV;
            fileStream.Write(iv, 0, iv.Length);

            using (CryptoStream cryptoStream = new(
                fileStream,
                aes.CreateEncryptor(),
                CryptoStreamMode.Write))
            {
                // By default, the StreamWriter uses UTF-8 encoding.
                // To change the text encoding, pass the desired encoding as the second parameter.
                // For example, new StreamWriter(cryptoStream, Encoding.Unicode).
                using (StreamWriter encryptWriter = new(cryptoStream))
                {
                    encryptWriter.WriteLine("Hello World!");
                }
            }
        }
    }

    Console.WriteLine("The file was encrypted.");
    Console.WriteLine($"Key (hex): {keyHex}");
}
catch (Exception ex)
{
    Console.WriteLine($"The encryption failed. {ex}");
}
