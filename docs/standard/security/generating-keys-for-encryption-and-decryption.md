---
title: "Generating Keys for Encryption and Decryption"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keys, encryption and decryption"
  - "keys, asymmetric"
  - "keys, symmetric"
  - "encryption [.NET Framework], keys"
  - "symmetric keys"
  - "asymmetric keys [.NET Framework]"
  - "cryptography [.NET Framework], keys"
ms.assetid: c197dfc9-a453-4226-898d-37a16638056e
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Generating Keys for Encryption and Decryption
Creating and managing keys is an important part of the cryptographic process. Symmetric algorithms require the creation of a key and an initialization vector (IV). The key must be kept secret from anyone who should not decrypt your data. The IV does not have to be secret, but should be changed for each session. Asymmetric algorithms require the creation of a public key and a private key. The public key can be made public to anyone, while the private key must known only by the party who will decrypt the data encrypted with the public key. This section describes how to generate and manage keys for both symmetric and asymmetric algorithms.  
  
## Symmetric Keys  
 The symmetric encryption classes supplied by the .NET Framework require a key and a new initialization vector (IV) to encrypt and decrypt data. Whenever you create a new instance of one of the managed symmetric cryptographic classes using the default constructor, a new key and IV are automatically created. Anyone that you allow to decrypt your data must possess the same key and IV and use the same algorithm. Generally, a new key and IV should be created for every session, and neither the key nor IV should be stored for use in a later session.  
  
 To communicate a symmetric key and IV to a remote party, you would usually encrypt the symmetric key by using asymmetric encryption. Sending the key across an insecure network without encrypting it is unsafe, because anyone who intercepts the key and IV can then decrypt your data. For more information about exchanging data by using encryption, see [Creating a Cryptographic Scheme](../../../docs/standard/security/creating-a-cryptographic-scheme.md).  
  
 The following example shows the creation of a new instance of the <xref:System.Security.Cryptography.TripleDESCryptoServiceProvider> class that implements the TripleDES algorithm.  
  
```vb  
Dim TDES As TripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider()  
```  
  
```csharp  
TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();  
```  
  
 When the previous code is executed, a new key and IV are generated and placed in the **Key** and **IV** properties, respectively.  
  
 Sometimes you might need to generate multiple keys. In this situation, you can create a new instance of a class that implements a symmetric algorithm and then create a new key and IV by calling the **GenerateKey** and **GenerateIV** methods. The following code example illustrates how to create new keys and IVs after a new instance of the asymmetric cryptographic class has been made.  
  
```vb  
Dim TDES As TripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider()  
TDES.GenerateIV()  
TDES.GenerateKey()  
```  
  
```csharp  
TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();  
TDES.GenerateIV();  
TDES.GenerateKey();  
```  
  
 When the previous code is executed, a key and IV are generated when the new instance of **TripleDESCryptoServiceProvider** is made. Another key and IV are created when the **GenerateKey** and **GenerateIV** methods are called.  
  
## Asymmetric Keys  
 The .NET Framework provides the <xref:System.Security.Cryptography.RSACryptoServiceProvider> and <xref:System.Security.Cryptography.DSACryptoServiceProvider> classes for asymmetric encryption. These classes create a public/private key pair when you use the default constructor to create a new instance. Asymmetric keys can be either stored for use in multiple sessions or generated for one session only. While the public key can be made generally available, the private key should be closely guarded.  
  
 A public/private key pair is generated whenever a new instance of an asymmetric algorithm class is created. After a new instance of the class is created, the key information can be extracted using one of two methods:  
  
-   The <xref:System.Security.Cryptography.RSA.ToXmlString%2A> method, which returns an XML representation of the key information.  
  
-   The <xref:System.Security.Cryptography.RSACryptoServiceProvider.ExportParameters%2A> method, which returns an <xref:System.Security.Cryptography.RSAParameters> structure that holds the key information.  
  
 Both methods accept a Boolean value that indicates whether to return only the public key information or to return both the public-key and the private-key information. An **RSACryptoServiceProvider** class can be initialized to the value of an **RSAParameters** structure by using the <xref:System.Security.Cryptography.RSACryptoServiceProvider.ImportParameters%2A> method.  
  
 Asymmetric private keys should never be stored verbatim or in plain text on the local computer. If you need to store a private key, you should use a key container. For more on how to store a private key in a key container, see [How to: Store Asymmetric Keys in a Key Container](../../../docs/standard/security/how-to-store-asymmetric-keys-in-a-key-container.md).  
  
 The following code example creates a new instance of the **RSACryptoServiceProvider** class, creating a public/private key pair, and saves the public key information to an **RSAParameters** structure.  
  
```vb  
'Generate a public/private key pair.  
Dim RSA as RSACryptoServiceProvider = new RSACryptoServiceProvider()  
'Save the public key information to an RSAParameters structure.  
Dim RSAKeyInfo As RSAParameters = RSA.ExportParameters(false)  
```  
  
```csharp  
//Generate a public/private key pair.  
RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();  
//Save the public key information to an RSAParameters structure.  
RSAParameters RSAKeyInfo = RSA.ExportParameters(false);  
```  
  
## See Also  
 [Encrypting Data](../../../docs/standard/security/encrypting-data.md)  
 [Decrypting Data](../../../docs/standard/security/decrypting-data.md)  
 [Cryptographic Services](../../../docs/standard/security/cryptographic-services.md)  
 [How to: Store Asymmetric Keys in a Key Container](../../../docs/standard/security/how-to-store-asymmetric-keys-in-a-key-container.md)
