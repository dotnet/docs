// <generate>
using System.Security.Cryptography;
using System.Text;

byte[] hash;

SHA256 alg = SHA256.Create();
byte[] data = Encoding.ASCII.GetBytes("Hello, from the .NET Docs!");
hash = alg.ComputeHash(data);

RSAParameters sharedParameters;
byte[] signedHash;

using (RSA rsa = RSA.Create())
{
    sharedParameters = rsa.ExportParameters(false);

    RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
    rsaFormatter.SetHashAlgorithm(nameof(SHA256));

    signedHash = rsaFormatter.CreateSignature(hash);
}
// </generate>

// <verify>
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
// </verify>
