// <snippet1>
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public class MemoryProtectionSample
{
    public static void Main() => Run();

    public static void Run()
    {
        try
        {
            ///////////////////////////////
            //
            // Memory Encryption - ProtectedMemory
            //
            ///////////////////////////////

            // Create the original data to be encrypted (The data length should be a multiple of 16).
            byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes("ThisIsSomeData16");

            Console.WriteLine($"Original data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");
            Console.WriteLine("Encrypting...");

            // Encrypt the data in memory.
            EncryptInMemoryData(toEncrypt, MemoryProtectionScope.SameLogon);

            Console.WriteLine($"Encrypted data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");
            Console.WriteLine("Decrypting...");

            // Decrypt the data in memory.
            DecryptInMemoryData(toEncrypt, MemoryProtectionScope.SameLogon);

            Console.WriteLine($"Decrypted data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");

            ///////////////////////////////
            //
            // Data Encryption - ProtectedData
            //
            ///////////////////////////////

            // Create the original data to be encrypted
            toEncrypt = UnicodeEncoding.ASCII.GetBytes("This is some data of any length.");

            // Create a file.
            FileStream fStream = new FileStream("Data.dat", FileMode.OpenOrCreate);

            // Create some random entropy.
            byte[] entropy = CreateRandomEntropy();

            Console.WriteLine();
            Console.WriteLine($"Original data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");
            Console.WriteLine("Encrypting and writing to disk...");

            // Encrypt a copy of the data to the stream.
            int bytesWritten = EncryptDataToStream(toEncrypt, entropy, DataProtectionScope.CurrentUser, fStream);

            fStream.Close();

            Console.WriteLine("Reading data from disk and decrypting...");

            // Open the file.
            fStream = new FileStream("Data.dat", FileMode.Open);

            // Read from the stream and decrypt the data.
            byte[] decryptData = DecryptDataFromStream(entropy, DataProtectionScope.CurrentUser, fStream, bytesWritten);

            fStream.Close();

            Console.WriteLine($"Decrypted data: {UnicodeEncoding.ASCII.GetString(decryptData)}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }
    }

    public static void EncryptInMemoryData(byte[] Buffer, MemoryProtectionScope Scope )
    {
        if (Buffer == null)
            throw new ArgumentNullException(nameof(Buffer));
        if (Buffer.Length <= 0)
            throw new ArgumentException("The buffer length was 0.", nameof(Buffer));

        // Encrypt the data in memory. The result is stored in the same array as the original data.
        ProtectedMemory.Protect(Buffer, Scope);
    }

    public static void DecryptInMemoryData(byte[] Buffer, MemoryProtectionScope Scope)
    {
        if (Buffer == null)
            throw new ArgumentNullException(nameof(Buffer));
        if (Buffer.Length <= 0)
            throw new ArgumentException("The buffer length was 0.", nameof(Buffer));

        // Decrypt the data in memory. The result is stored in the same array as the original data.
        ProtectedMemory.Unprotect(Buffer, Scope);
    }

    public static byte[] CreateRandomEntropy()
    {
        // Create a byte array to hold the random value.
        byte[] entropy = new byte[16];

        // Create a new instance of the RNGCryptoServiceProvider.
        // Fill the array with a random value.
        new RNGCryptoServiceProvider().GetBytes(entropy);

        // Return the array.
        return entropy;
    }

    public static int EncryptDataToStream(byte[] Buffer, byte[] Entropy, DataProtectionScope Scope, Stream S)
    {
        if (Buffer == null)
            throw new ArgumentNullException(nameof(Buffer));
        if (Buffer.Length <= 0)
            throw new ArgumentException("The buffer length was 0.", nameof(Buffer));
        if (Entropy == null)
            throw new ArgumentNullException(nameof(Entropy));
        if (Entropy.Length <= 0)
            throw new ArgumentException("The entropy length was 0.", nameof(Entropy));
        if (S == null)
            throw new ArgumentNullException(nameof(S));

        int length = 0;

        // Encrypt the data and store the result in a new byte array. The original data remains unchanged.
        byte[] encryptedData = ProtectedData.Protect(Buffer, Entropy, Scope);

        // Write the encrypted data to a stream.
        if (S.CanWrite && encryptedData != null)
        {
            S.Write(encryptedData, 0, encryptedData.Length);

            length = encryptedData.Length;
        }

        // Return the length that was written to the stream.
        return length;
    }

    public static byte[] DecryptDataFromStream(byte[] Entropy, DataProtectionScope Scope, Stream S, int Length)
    {
        if (S == null)
            throw new ArgumentNullException(nameof(S));
        if (Length <= 0 )
            throw new ArgumentException("The given length was 0.", nameof(Length));
        if (Entropy == null)
            throw new ArgumentNullException(nameof(Entropy));
        if (Entropy.Length <= 0)
            throw new ArgumentException("The entropy length was 0.", nameof(Entropy));

        byte[] inBuffer = new byte[Length];
        byte[] outBuffer;

        // Read the encrypted data from a stream.
        if (S.CanRead)
        {
            S.Read(inBuffer, 0, Length);

            outBuffer = ProtectedData.Unprotect(inBuffer, Entropy, Scope);
        }
        else
        {
            throw new IOException("Could not read the stream.");
        }

        // Return the decrypted data
        return outBuffer;
    }
}
// </snippet1>
