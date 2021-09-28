---
description: "Learn more about: Cryptographic Signatures"
title: "Cryptographic Signatures"
ms.date: 07/14/2020
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
---

# Cryptographic Signatures

Cryptographic digital signatures use public key algorithms to provide data integrity. When you sign data with a digital signature, someone else can verify the signature, and can prove that the data originated from you and was not altered after you signed it. For more information about digital signatures, see [Cryptographic Services](cryptographic-services.md).

This topic explains how to generate and verify digital signatures using classes in the <xref:System.Security.Cryptography> namespace.

## Generating Signatures

Digital signatures are usually applied to hash values that represent larger data. The following example applies a digital signature to a hash value. First, a new instance of the <xref:System.Security.Cryptography.RSA> class is created to generate a public/private key pair. Next, the <xref:System.Security.Cryptography.RSA> is passed to a new instance of the <xref:System.Security.Cryptography.RSAPKCS1SignatureFormatter> class. This transfers the private key to the <xref:System.Security.Cryptography.RSAPKCS1SignatureFormatter>, which actually performs the digital signing. Before you can sign the hash code, you must specify a hash algorithm to use. This example uses the SHA1 algorithm. Finally, the <xref:System.Security.Cryptography.AsymmetricSignatureFormatter.CreateSignature%2A> method is called to perform the signing.

Due to collision problems with SHA1, we recommend SHA256 or better.

```vb
Imports System.Security.Cryptography

Module Module1
    Sub Main()
        'The hash value to sign.
        Dim hashValue As Byte() = {59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135}

        'The value to hold the signed value.
        Dim signedHashValue() As Byte

        'Generate a public/private key pair.
        Dim rsa As RSA = RSA.Create()

        'Create an RSAPKCS1SignatureFormatter object and pass it
        'the RSA instance to transfer the private key.
        Dim rsaFormatter As New RSAPKCS1SignatureFormatter(rsa)

        'Set the hash algorithm to SHA1.
        rsaFormatter.SetHashAlgorithm("SHA1")

        'Create a signature for hashValue and assign it to
        'signedHashValue.
        signedHashValue = rsaFormatter.CreateSignature(hashValue)
    End Sub
End Module
```

```csharp
using System;
using System.Security.Cryptography;

class Class1
{
   static void Main()
   {
      //The hash value to sign.
      byte[] hashValue = {59,4,248,102,77,97,142,201,210,12,224,93,25,41,100,197,213,134,130,135};

      //The value to hold the signed value.
      byte[] signedHashValue;

      //Generate a public/private key pair.
      RSA rsa = RSA.Create();

      //Create an RSAPKCS1SignatureFormatter object and pass it the
      //RSA instance to transfer the private key.
      RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);

      //Set the hash algorithm to SHA1.
      rsaFormatter.SetHashAlgorithm("SHA1");

      //Create a signature for hashValue and assign it to
      //signedHashValue.
      signedHashValue = rsaFormatter.CreateSignature(hashValue);
   }
}
```

## Verifying Signatures

To verify that data was signed by a particular party, you must have the following information:

- The public key of the party that signed the data.

- The digital signature.

- The data that was signed.

- The hash algorithm used by the signer.

To verify a signature signed by the <xref:System.Security.Cryptography.RSAPKCS1SignatureFormatter> class, use the <xref:System.Security.Cryptography.RSAPKCS1SignatureDeformatter> class. The <xref:System.Security.Cryptography.RSAPKCS1SignatureDeformatter> class must be supplied the public key of the signer. For RSA, you will need the values of the modulus and the exponent to specify the public key. (The party that generated the public/private key pair should provide these values.) First create an <xref:System.Security.Cryptography.RSA> object to hold the public key that will verify the signature, and then initialize an <xref:System.Security.Cryptography.RSAParameters> structure to the modulus and exponent values that specify the public key.

The following code shows the creation of an <xref:System.Security.Cryptography.RSAParameters> structure. The `Modulus` property is set to the value of a byte array called `modulusData` and the `Exponent` property is set to the value of a byte array called `exponentData`.

```vb
Dim rsaKeyInfo As RSAParameters
rsaKeyInfo.Modulus = modulusData
rsaKeyInfo.Exponent = exponentData
```

```csharp
RSAParameters rsaKeyInfo;
rsaKeyInfo.Modulus = modulusData;
rsaKeyInfo.Exponent = exponentData;
```

After you have created the <xref:System.Security.Cryptography.RSAParameters> object, you can initialize a new instance of the <xref:System.Security.Cryptography.RSA> implementation class to the values specified in <xref:System.Security.Cryptography.RSAParameters>. The <xref:System.Security.Cryptography.RSA> instance is, in turn, passed to the constructor of an <xref:System.Security.Cryptography.RSAPKCS1SignatureDeformatter> to transfer the key.

The following example illustrates this process. In this example, `hashValue` and `signedHashValue` are arrays of bytes provided by a remote party. The remote party has signed the `hashValue` using the SHA1 algorithm, producing the digital signature `signedHashValue`. The <xref:System.Security.Cryptography.RSAPKCS1SignatureDeformatter.VerifySignature%2A?displayProperty=nameWithType> method verifies that the digital signature is valid and was used to sign the `hashValue`.

Due to collision problems with SHA1, we recommend SHA256 or better.  However, if SHA1 was used to create the signature, you have to use SHA1 to verify the signature.

```vb
Dim rsa As RSA = RSA.Create()
rsa.ImportParameters(rsaKeyInfo)
Dim rsaDeformatter As New RSAPKCS1SignatureDeformatter(rsa)
rsaDeformatter.SetHashAlgorithm("SHA1")
If rsaDeformatter.VerifySignature(hashValue, signedHashValue) Then
   Console.WriteLine("The signature is valid.")
Else
   Console.WriteLine("The signature is not valid.")
End If
```

```csharp
RSA rsa = RSA.Create();
rsa.ImportParameters(rsaKeyInfo);
RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
rsaDeformatter.SetHashAlgorithm("SHA1");
if(rsaDeformatter.VerifySignature(hashValue, signedHashValue))
{
   Console.WriteLine("The signature is valid.");
}
else
{
   Console.WriteLine("The signature is not valid.");
}
```

This code fragment will display "`The signature is valid`" if the signature is valid and "`The signature is not valid`" if it is not.

## See also

- [Cryptographic Services](cryptographic-services.md)
- [Cryptography Model](cryptography-model.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
- [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
