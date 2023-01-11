---
title: "How to: Use Data Protection"
description: Learn how to use data protection by accessing the data protection API (DPAPI) in .NET.
ms.date: 07/14/2020
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DPAPI"
  - "encryption [.NET], data protection API"
  - "data [.NET], decryption"
  - "ProtectedMemory class, about ProtectedMemory class"
  - "ProtectedData class, about ProtectedData class"
  - "cryptography [.NET], data protection API"
  - "data protection API [.NET]"
  - "decryption"
  - "data [.NET], encryption"
ms.assetid: 606698b0-cb1a-42ca-beeb-0bea34205d20
---
# How to: Use Data Protection

> [!NOTE]
> This article applies to Windows.
>
> For information about ASP.NET Core, see [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction).

.NET provides access to the data protection API (DPAPI), which allows you to encrypt data using information from the current user account or computer.  When you use the DPAPI, you alleviate the difficult problem of explicitly generating and storing a cryptographic key.  
  
Use the <xref:System.Security.Cryptography.ProtectedData> class to encrypt a copy of an array of bytes. This functionality is available in .NET Framework, .NET Core, and .NET 5+.  You can specify that data encrypted by the current user account can be decrypted only by the same user account, or you can specify that data encrypted by the current user account can be decrypted by any account on the computer.  See the <xref:System.Security.Cryptography.DataProtectionScope> enumeration for a detailed description of <xref:System.Security.Cryptography.ProtectedData> options.  
  
## Encrypt data to a file or stream using data protection  
  
1. Create random entropy.  
  
2. Call the static <xref:System.Security.Cryptography.ProtectedData.Protect%2A> method while passing an array of bytes to encrypt, the entropy, and the data protection scope.  
  
3. Write the encrypted data to a file or stream.  
  
### To decrypt data from a file or stream using data protection  
  
1. Read the encrypted data from a file or stream.  
  
2. Call the static <xref:System.Security.Cryptography.ProtectedData.Unprotect%2A> method while passing an array of bytes to decrypt and the data protection scope.  
  
## Example

The following code example demonstrates two forms of encryption and decryption.  First, the code example encrypts and then decrypts an in-memory array of bytes.  Next, the code example encrypts a copy of a byte array, saves it to a file, loads the data back from the file, and then decrypts the data.  The example displays the original data, the encrypted data, and the decrypted data.

[!code-csharp[DPAPI-HowTO#1](../../../samples/snippets/csharp/VS_Snippets_CLR/DPAPI-HowTO/cs/sample.cs#1)]
[!code-vb[DPAPI-HowTO#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DPAPI-HowTO/vb/sample.vb#1)]  
  
## Compiling the Code  

This example compiles and runs only when targeting .NET Framework and running on Windows.

- Include a reference to `System.Security.dll`.  
  
- Include the <xref:System>, <xref:System.IO>, <xref:System.Security.Cryptography>, and <xref:System.Text> namespace.  
  
## See also

- [Cryptography Model](cryptography-model.md)
- [Cryptographic Services](cryptographic-services.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
- <xref:System.Security.Cryptography.ProtectedMemory>
- <xref:System.Security.Cryptography.ProtectedData>
- [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
