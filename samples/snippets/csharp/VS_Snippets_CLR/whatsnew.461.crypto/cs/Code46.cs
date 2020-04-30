namespace Net461 {
// <Snippet1>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Net461Code
{
    public static byte[] SignECDsaSha512(byte[] data, X509Certificate2 cert)
    {
        using (ECDsa privateKey = cert.GetECDsaPrivateKey())
        {
            return privateKey.SignData(data, HashAlgorithmName.SHA512);
        }
    }

    public static byte[] SignECDsaSha512(byte[] data, ECDsa privateKey)
    {
        return privateKey.SignData(data, HashAlgorithmName.SHA512);
    }
}
// </Snippet1>
}

namespace Net46 {
// <Snippet2>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Net46Code
{
    public static byte[] SignECDsaSha512(byte[] data, X509Certificate2 cert)
    {
        // This would require using cert.Handle and a series of p/invokes to get at the
        // underlying key, then passing that to a CngKey object, and passing that to
        // new ECDsa(CngKey).  It's a lot of work.
        throw new Exception("That's a lot of work...");
    }

    public static byte[] SignECDsaSha512(byte[] data, ECDsa privateKey)
    {
        // This way works, but SignData probably better matches what you want.
        using (SHA512 hasher = SHA512.Create())
        {
            byte[] signature1 = privateKey.SignHash(hasher.ComputeHash(data));
        }

        // This might not be the ECDsa you got!
        ECDsaCng ecDsaCng = (ECDsaCng)privateKey;
        ecDsaCng.HashAlgorithm = CngAlgorithm.Sha512;
        return ecDsaCng.SignData(data);
    }
}
// </Snippet2>
}