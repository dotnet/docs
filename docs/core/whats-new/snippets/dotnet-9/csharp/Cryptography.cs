using System;
using System.Security.Cryptography;

internal class Cryptography
{
    public static void RunIt()
    {
        // <Kmac>
        if (Kmac128.IsSupported)
        {
            byte[] key = GetKmacKey();
            byte[] input = GetInputToMac();
            byte[] mac = Kmac128.HashData(key, input, outputLength: 32);
        }
        else
        {
            // Handle scenario where KMAC isn't available.
        }
        // </Kmac>

        byte[] GetKmacKey()
        {
            throw new NotImplementedException();
        }

        byte[] GetInputToMac()
        {
            throw new NotImplementedException();
        }
    }

    // <HashData>
    static void HashAndProcessData(HashAlgorithmName hashAlgorithmName, byte[] data)
    {
        byte[] hash = CryptographicOperations.HashData(hashAlgorithmName, data);
        ProcessHash(hash);
    }
    // </HashData>

    private static void ProcessHash(byte[] hash) { throw new NotImplementedException(); }
}
