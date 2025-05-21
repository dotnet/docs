---
description: "Learn more about: Cryptographic Signatures"
title: "Cryptographic Signatures"
ms.date: 08/08/2022
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "digital signatures"
  - "cryptography [.NET], signatures"
  - "digital signatures, XML signing"
  - "signatures, cryptographic"
  - "digital signatures, generating"
  - "verifying signatures"
  - "generating signatures"
  - "digital signatures, about"
  - "encryption [.NET], signatures"
  - "security [.NET], signatures"
  - "XML signing"
  - "digital signatures, verifying"
  - "signing XML"
ms.assetid: aa87cb7f-e608-4a81-948b-c9b8a1225783
ms.topic: article
---

# Cryptographic Signatures

Cryptographic digital signatures use public key algorithms to provide data integrity. When you sign data with a digital signature, someone else can verify the signature, and can prove that the data originated from you and was not altered after you signed it. For more information about digital signatures, see [Cryptographic Services](cryptographic-services.md).

This topic explains how to generate and verify digital signatures using classes in the <xref:System.Security.Cryptography> namespace.

## Generate a signature

Digital signatures are usually applied to hash values that represent larger data. The following example applies a digital signature to a hash value. First, a new instance of the <xref:System.Security.Cryptography.RSA> class is created to generate a public/private key pair. Next, the <xref:System.Security.Cryptography.RSA> is passed to a new instance of the <xref:System.Security.Cryptography.RSAPKCS1SignatureFormatter> class. This transfers the private key to the <xref:System.Security.Cryptography.RSAPKCS1SignatureFormatter>, which actually performs the digital signing. Before you can sign the hash code, you must specify a hash algorithm to use. This example uses the `SHA256` algorithm. Finally, the <xref:System.Security.Cryptography.AsymmetricSignatureFormatter.CreateSignature%2A> method is called to perform the signing.

```vb
Imports System.Security.Cryptography
Imports System.Text

Module Program
    Sub Main()

        Dim alg As SHA256 = SHA256.Create()

        Dim data As Byte() = Encoding.UTF8.GetBytes("Hello, from the .NET Docs!")
        Dim hash As Byte() = alg.ComputeHash(data)

        Dim sharedParameters As RSAParameters
        Dim signedHash As Byte()

        ' Generate signature
        Using rsa As RSA = RSA.Create()
            sharedParameters = rsa.ExportParameters(True)
            Dim rsaFormatter As New RSAPKCS1SignatureFormatter(rsa)
            rsaFormatter.SetHashAlgorithm(NameOf(SHA256))

            signedHash = rsaFormatter.CreateSignature(hash)
        End Using

        ' The sharedParameters, hash, and signedHash are used to later verify the signature.
    End Sub
End Module
```

```csharp
using System.Security.Cryptography;
using System.Text;

using SHA256 alg = SHA256.Create();

byte[] data = Encoding.ASCII.GetBytes("Hello, from the .NET Docs!");
byte[] hash = alg.ComputeHash(data);

RSAParameters sharedParameters;
byte[] signedHash;

// Generate signature
using (RSA rsa = RSA.Create())
{
    sharedParameters = rsa.ExportParameters(false);

    RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
    rsaFormatter.SetHashAlgorithm(nameof(SHA256));

    signedHash = rsaFormatter.CreateSignature(hash);
}

// The sharedParameters, hash, and signedHash are used to later verify the signature.
```

## Verify a signature

To verify that data was signed by a particular party, you must have the following information:

- The public key of the party that signed the data.
- The digital signature.
- The data that was signed.
- The hash algorithm used by the signer.

To verify a signature signed by the <xref:System.Security.Cryptography.RSAPKCS1SignatureFormatter> class, use the <xref:System.Security.Cryptography.RSAPKCS1SignatureDeformatter> class. The <xref:System.Security.Cryptography.RSAPKCS1SignatureDeformatter> class must be supplied the public key of the signer. For RSA, you will need at a minimal the values of the <xref:System.Security.Cryptography.RSAParameters.Modulus?displayProperty=nameWithType> and the <xref:System.Security.Cryptography.RSAParameters.Exponent?displayProperty=nameWithType> to specify the public key. One way to achieve this is to call <xref:System.Security.Cryptography.RSA.ExportParameters%2A?displayProperty=nameWithType> during signature creation and then call <xref:System.Security.Cryptography.RSA.ImportParameters%2A?displayProperty=nameWithType> during the verification process. The party that generated the public/private key pair should provide these values. First create an <xref:System.Security.Cryptography.RSA> object to hold the public key that will verify the signature, and then initialize an <xref:System.Security.Cryptography.RSAParameters> structure to the modulus and exponent values that specify the public key.

The following code shows the sharing of an <xref:System.Security.Cryptography.RSAParameters> structure. The `RSA` responsible for creating the signature exports its parameters. The parameters are then imported into the new `RSA` instance that is responsible for verifying the signature.

The <xref:System.Security.Cryptography.RSA> instance is, in turn, passed to the constructor of an <xref:System.Security.Cryptography.RSAPKCS1SignatureDeformatter> to transfer the key.

The following example illustrates this process. In this example, imagine that `sharedParameters`, `hash`, and `signedHash` are provided by a remote party. The remote party has signed `hash` using the `SHA256` algorithm to produce the digital signature `signedHash`. The <xref:System.Security.Cryptography.RSAPKCS1SignatureDeformatter.VerifySignature%2A?displayProperty=nameWithType> method verifies that the digital signature is valid and was used to sign `hash`.

:::code language="vb" source="./snippets/cryptographic-signatures/vb/Program.vb":::
:::code language="csharp" source="./snippets/cryptographic-signatures/csharp/Program.cs":::

This code fragment displays "`The signature is valid`" if the signature is valid and "`The signature is not valid`" if it's not.

## See also

- [Cryptographic Services](cryptographic-services.md)
- [Cryptography Model](cryptography-model.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
- [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
