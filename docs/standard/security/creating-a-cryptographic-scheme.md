---
title: "Creating a Cryptographic Scheme"
ms.date: 07/14/2020
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "encryption [.NET], creating cryptographic schemes"
  - "cryptography [.NET], creating cryptographic schemes"
ms.assetid: d40c509f-5a5e-46cc-94cb-a951e9ab6843
---
# Creating a Cryptographic Scheme

The cryptographic components of .NET can be combined to create different schemes to encrypt and decrypt data.  
  
 A simple cryptographic scheme for encrypting and decrypting data might specify the following steps:  
  
1. Each party generates a public/private key pair.  
  
2. The parties exchange their public keys.  
  
3. Each party generates a secret key for AES encryption, for example, and encrypts the newly created key using the other's public key.  
  
4. Each party sends the data to the other and combines the other's secret key with its own, in a particular order, to create a new secret key.  
  
5. The parties then initiate a conversation using symmetric encryption.  
  
 Creating a cryptographic scheme is not a trivial task.
  
## See also

- [Cryptography Model](cryptography-model.md) - Describes how cryptography is implemented in the base class library.
- [Cryptographic Services](cryptographic-services.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
