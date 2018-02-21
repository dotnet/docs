---
title: "How to: Use Data Protection"
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
  - "DPAPI"
  - "encryption [.NET Framework], data protection API"
  - "data [.NET Framework], decryption"
  - "ProtectedMemory class, about ProtectedMemory class"
  - "ProtectedData class, about ProtectedData class"
  - "cryptography [.NET Framework], data protection API"
  - "data protection API [.NET Framework]"
  - "decryption"
  - "data [.NET Framework], encryption"
ms.assetid: 606698b0-cb1a-42ca-beeb-0bea34205d20
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Use Data Protection
The .NET Framework provides access to the data protection API (DPAPI), which allows you to encrypt data using information from the current user account or computer.  When you use the DPAPI, you alleviate the difficult problem of explicitly generating and storing a cryptographic key.  
  
 Use the <xref:System.Security.Cryptography.ProtectedMemory> class to encrypt an array of in-memory bytes.  This functionality is available in Microsoft Windows XP and later operating systems.  You can specify that memory encrypted by the current process can be decrypted by the current process only, by all processes, or from the same user context.  See the <xref:System.Security.Cryptography.MemoryProtectionScope> enumeration for a detailed description of <xref:System.Security.Cryptography.ProtectedMemory> options.  
  
 Use the <xref:System.Security.Cryptography.ProtectedData> class to encrypt a copy of an array of bytes. This functionality is available in Microsoft Windows 2000 and later operating systems.  You can specify that data encrypted by the current user account can be decrypted only by the same user account, or you can specify that data encrypted by the current user account can be decrypted by any account on the computer.  See the <xref:System.Security.Cryptography.DataProtectionScope> enumeration for a detailed description of <xref:System.Security.Cryptography.ProtectedData> options.  
  
### To encrypt in-memory data using data protection  
  
1.  Call the static <xref:System.Security.Cryptography.ProtectedMemory.Protect%2A> method while passing an array of bytes to encrypt, the entropy, and the memory protection scope.  
  
### To decrypt in-memory data using data protection  
  
1.  Call the static <xref:System.Security.Cryptography.ProtectedMemory.Unprotect%2A> method while passing an array of bytes to decrypt and the memory protection scope.  
  
### To encrypt data to a file or stream using data protection  
  
1.  Create random entropy.  
  
2.  Call the static <xref:System.Security.Cryptography.ProtectedData.Protect%2A> method while passing an array of bytes to encrypt, the entropy, and the data protection scope.  
  
3.  Write the encrypted data to a file or stream.  
  
### To decrypt data from a file or stream using data protection  
  
1.  Read the encrypted data from a file or stream.  
  
2.  Call the static <xref:System.Security.Cryptography.ProtectedData.Unprotect%2A> method while passing an array of bytes to decrypt and the data protection scope.  
  
## Example  
 The following code example demonstrates two forms of encryption and decryption.  First, the code example encrypts and then decrypts an in-memory array of bytes.  Next, the code example encrypts a copy of a byte array, saves it to a file, loads the data back from the file, and then decrypts the data.  The example displays the original data, the encrypted data, and the decrypted data.  
  
 [!code-csharp[DPAPI-HowTO#1](../../../samples/snippets/csharp/VS_Snippets_CLR/DPAPI-HowTO/cs/sample.cs#1)]
 [!code-vb[DPAPI-HowTO#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DPAPI-HowTO/vb/sample.vb#1)]  
  
## Compiling the Code  
  
-   Include a reference to `System.Security.dll`.  
  
-   Include the <xref:System>, <xref:System.IO>, <xref:System.Security.Cryptography>, and <xref:System.Text> namespace.  
  
## See Also  
 <xref:System.Security.Cryptography.ProtectedMemory>  
 <xref:System.Security.Cryptography.ProtectedData>
