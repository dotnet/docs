---
title: "Generating Keys for Encryption and Decryption"
description: Understand how to create and manage symmetric and asymmetric keys for encryption and decryption in .NET.
ms.date: 07/14/2020
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keys, encryption and decryption"
  - "keys, asymmetric"
  - "keys, symmetric"
  - "encryption [.NET], keys"
  - "symmetric keys"
  - "asymmetric keys [.NET]"
  - "cryptography [.NET], keys"
ms.topic: how-to
---
# Generating Keys for Encryption and Decryption

Creating and managing keys is an important part of the cryptographic process. Symmetric algorithms require the creation of a key and an initialization vector (IV). The key must be kept secret from anyone who should not decrypt your data. The IV does not have to be secret, but should be changed for each session. Asymmetric algorithms require the creation of a public key and a private key. The public key can be made known to anyone, but the coresponding private key must only be known by the decrypting party. This section describes how to generate and manage keys for both symmetric and asymmetric algorithms.  
  
## Symmetric Keys  

 The symmetric encryption classes supplied by .NET require a key and a new initialization vector (IV) to encrypt and decrypt data. Whenever you create a new instance of one of the managed symmetric cryptographic classes using the parameterless `Create()` method, a new key and IV are automatically created. Anyone that you allow to decrypt your data must possess the same key and IV and use the same algorithm. Generally, a new key and IV should be created for every session, and neither the key nor IV should be stored for use in a later session.  
  
 To communicate a symmetric key and IV to a remote party, you would usually encrypt the symmetric key by using asymmetric encryption. Sending the key across an insecure network without encrypting it is unsafe, because anyone who intercepts the key and IV can then decrypt your data.  
  
 The following example shows the creation of a new instance of the default implementation class for the <xref:System.Security.Cryptography.Aes> algorithm.  
  
```vb  
Dim aes As Aes = Aes.Create()  
```  
  
```csharp  
Aes aes = Aes.Create();  
```  
  
 When the previous code is executed, a new key and IV are generated and placed in the **Key** and **IV** properties, respectively.  
  
 Sometimes you might need to generate multiple keys. In this situation, you can create a new instance of a class that implements a symmetric algorithm and then create a new key and IV by calling the **GenerateKey** and **GenerateIV** methods. The following code example illustrates how to create new keys and IVs after a new instance of the symmetric cryptographic class has been made.  
  
```vb  
Dim aes As Aes = Aes.Create()  
aes.GenerateIV()  
aes.GenerateKey()  
```  
  
```csharp  
Aes aes = Aes.Create();  
aes.GenerateIV();  
aes.GenerateKey();  
```  
  
 When the preceding code is executed, a key and IV are generated when the new instance of **Aes** is made. Another key and IV are created when the **GenerateKey** and **GenerateIV** methods are called.
  
## Asymmetric Keys

 .NET provides the <xref:System.Security.Cryptography.RSA> class for asymmetric encryption. This class creates a public/private key pair when you use the parameterless `Create()` method to create a new instance. Asymmetric keys can be either stored for use in multiple sessions or generated for one session only. While the public key can be made generally available, the private key should be closely guarded.  
  
 A public/private key pair is generated whenever a new instance of an asymmetric algorithm class is created. After a new instance of the class is created, the key information can be extracted using the <xref:System.Security.Cryptography.RSA.ExportParameters%2A> method, which returns an <xref:System.Security.Cryptography.RSAParameters> structure that holds the key information. The method accepts a Boolean value that indicates whether to return only the public key information or to return both the public-key and the private-key information.

There are also other methods that let you extract key information, such as:

* <xref:System.Security.Cryptography.RSA.ExportRSAPublicKey%2A?displayProperty=nameWithType>
* <xref:System.Security.Cryptography.RSA.ExportRSAPrivateKey%2A?displayProperty=nameWithType>
* <xref:System.Security.Cryptography.AsymmetricAlgorithm.ExportSubjectPublicKeyInfo%2A?displayProperty=nameWithType>
* <xref:System.Security.Cryptography.AsymmetricAlgorithm.ExportPkcs8PrivateKey%2A?displayProperty=nameWithType>
* <xref:System.Security.Cryptography.AsymmetricAlgorithm.ExportEncryptedPkcs8PrivateKey%2A?displayProperty=nameWithType>

An **RSA** instance can be initialized to the value of an **RSAParameters** structure by using the <xref:System.Security.Cryptography.RSA.ImportParameters%2A> method. Or create a new instance by using the <xref:System.Security.Cryptography.RSA.Create(System.Security.Cryptography.RSAParameters)?displayProperty=nameWithType> method.  
  
 Asymmetric private keys should never be stored verbatim or in plain text on the local computer. If you need to store a private key, you should use a key container. For more information about how to store a private key in a key container, see [How to: Store Asymmetric Keys in a Key Container](how-to-store-asymmetric-keys-in-a-key-container.md).  
  
 The following code example creates a new instance of the **RSA** class, creating a public/private key pair, and saves the public key information to an **RSAParameters** structure.  
  
```vb  
'Generate a public/private key pair.  
Dim rsa as RSA = RSA.Create()  
'Save the public key information to an RSAParameters structure.  
Dim rsaKeyInfo As RSAParameters = rsa.ExportParameters(false)  
```  
  
```csharp  
//Generate a public/private key pair.  
RSA rsa = RSA.Create();  
//Save the public key information to an RSAParameters structure.  
RSAParameters rsaKeyInfo = rsa.ExportParameters(false);  
```  
  
## See also

- [Encrypting Data](encrypting-data.md)
- [Decrypting Data](decrypting-data.md)
- [Cryptographic Services](cryptographic-services.md)
- [How to: Store Asymmetric Keys in a Key Container](how-to-store-asymmetric-keys-in-a-key-container.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
- [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
