using System.Security.Cryptography;
using System.Text;

using SHA256 alg = SHA256.Create();

byte[] data = Encoding.UTF8.GetBytes("Hello, from the .NET Docs!");
byte[] hash = alg.ComputeHash(data);

RSAParameters sharedParameters;
byte[] signedHash;

// Generate signature with Pkcs1 padding.
// When creating RSA signatures, choose a padding mode that is appropriate to your needs.
using (RSA rsa = RSA.Create())
{
    sharedParameters = rsa.ExportParameters(false);

    RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
    rsaFormatter.SetHashAlgorithm(nameof(SHA256));

    signedHash = rsaFormatter.CreateSignature(hash);
}

// Verify signature.
// Since the signature was generated with Pkcs1 padding,
// it can only be verified with Pkcs1 padding.
using (RSA rsa = RSA.Create())
{
    rsa.ImportParameters(sharedParameters);

    RSAPKCS1SignatureDeformatter rsaDeformatter = new(rsa);
    rsaDeformatter.SetHashAlgorithm(nameof(SHA256));

    if (rsaDeformatter.VerifySignature(hash, signedHash))
    {
        Console.WriteLine("The signature is valid.");
    }
    else
    {
        Console.WriteLine("The signature is not valid.");
    }
}
