using System.Security.Cryptography;
using System.Text;

try
{
    // Data Encryption - ProtectedData

    // Create the original data to be encrypted.
    byte[] toEncrypt = Encoding.ASCII.GetBytes("This is some data of any length.");

    // Create some random entropy.
    byte[] entropy = CreateRandomEntropy();

    Console.WriteLine();
    Console.WriteLine($"Original data: {Encoding.ASCII.GetString(toEncrypt)}");
    Console.WriteLine("Encrypting and writing to disk...");

    int bytesWritten;

    // Encrypt a copy of the data to the stream.
    using (FileStream writeStream = new("Data.dat", FileMode.OpenOrCreate))
    {
        bytesWritten = EncryptDataToStream(toEncrypt, entropy, DataProtectionScope.CurrentUser, writeStream);
    }

    Console.WriteLine("Reading data from disk and decrypting...");

    // Read from the stream and decrypt the data.
    byte[] decryptData;
    using (FileStream readStream = new("Data.dat", FileMode.Open))
    {
        decryptData = DecryptDataFromStream(entropy, DataProtectionScope.CurrentUser, readStream, bytesWritten);
    }

    Console.WriteLine($"Decrypted data: {Encoding.ASCII.GetString(decryptData)}");
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}

static byte[] CreateRandomEntropy()
{
    // Create a byte array to hold the random value and fill it with a random value.
    byte[] entropy = new byte[16];
    RandomNumberGenerator.Fill(entropy);

    return entropy;
}

static int EncryptDataToStream(byte[] buffer, byte[] entropy, DataProtectionScope scope, Stream stream)
{
    ArgumentNullException.ThrowIfNull(buffer);
    ArgumentOutOfRangeException.ThrowIfZero(buffer.Length, nameof(buffer));
    ArgumentNullException.ThrowIfNull(entropy);
    ArgumentOutOfRangeException.ThrowIfZero(entropy.Length, nameof(entropy));
    ArgumentNullException.ThrowIfNull(stream);

    int length = 0;

    // Encrypt the data and store the result in a new byte array. The original data remains unchanged.
    byte[] encryptedData = ProtectedData.Protect(buffer, entropy, scope);

    // Write the encrypted data to a stream.
    if (stream.CanWrite)
    {
        stream.Write(encryptedData, 0, encryptedData.Length);
        length = encryptedData.Length;
    }

    // Return the length that was written to the stream.
    return length;
}

static byte[] DecryptDataFromStream(byte[] entropy, DataProtectionScope scope, Stream stream, int length)
{
    ArgumentNullException.ThrowIfNull(stream);
    ArgumentOutOfRangeException.ThrowIfZero(length, nameof(length));
    ArgumentNullException.ThrowIfNull(entropy);
    ArgumentOutOfRangeException.ThrowIfZero(entropy.Length, nameof(entropy));

    if (!stream.CanRead)
        throw new IOException("Could not read the stream.");

    byte[] inBuffer = new byte[length];
    stream.ReadExactly(inBuffer, 0, length);

    // Return the decrypted data.
    return ProtectedData.Unprotect(inBuffer, entropy, scope);
}
