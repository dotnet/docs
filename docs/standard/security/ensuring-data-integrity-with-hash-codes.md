---
title: "Ensuring Data Integrity with Hash Codes"
description: Learn how to ensure data integrity using hash codes in .NET. A hash value is a numeric value of a fixed length that uniquely identifies data.
ms.date: 07/14/2020
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "generating hash"
  - "verifying hash codes"
  - "cryptography [.NET], hash"
  - "data integrity"
  - "checking hash codes"
  - "encryption [.NET], hash"
  - "hash"
ms.topic: how-to
---
# Ensuring Data Integrity with Hash Codes

A hash value is a numeric value of a fixed length that uniquely identifies data. Hash values represent large amounts of data as much smaller numeric values, so they are used with digital signatures. You can sign a hash value more efficiently than signing the larger value. Hash values are also useful for verifying the integrity of data sent through insecure channels. The hash value of received data can be compared to the hash value of data as it was sent to determine whether the data was altered.  
  
This topic describes how to generate and verify hash codes by using the classes in the <xref:System.Security.Cryptography> namespace.  
  
## Generating a Hash

 The managed hash classes can hash either an array of bytes or a managed stream object. The following example uses the SHA1 hash algorithm to create a hash value for a string. The example uses the <xref:System.Text.UnicodeEncoding> class to convert the string into an array of bytes that are hashed by using the <xref:System.Security.Cryptography.SHA256> class. The hash value is then displayed to the console.  

 [!code-csharp[GeneratingAHash#1](../../../samples/snippets/csharp/VS_Snippets_CLR/generatingahash/cs/program.cs#1)]
 [!code-vb[GeneratingAHash#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/generatingahash/vb/program.vb#1)]  
  
 This code will display the following string to the console:  
  
 `185 203 236 22 3 228 27 130 87 23 244 15 87 88 14 43 37 61 106 224 81 172 224 211 104 85 194 197 194 25 120 217`  
  
## Verifying a Hash

 Data can be compared to a hash value to determine its integrity. Usually, data is hashed at a certain time and the hash value is protected in some way. At a later time, the data can be hashed again and compared to the protected value. If the hash values match, the data has not been altered. If the values do not match, the data has been corrupted. For this system to work, the protected hash must be encrypted or kept secret from all untrusted parties.  
  
 The following example compares the previous hash value of a string to a new hash value. This example loops through each byte of the hash values and makes a comparison.  
  
 [!code-csharp[VerifyingAHash#1](../../../samples/snippets/csharp/VS_Snippets_CLR/verifyingahash/cs/program.cs#1)]
 [!code-vb[VerifyingAHash#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/verifyingahash/vb/program.vb#1)]  
  
 If the two hash values match, this code displays the following to the console:  
  
```console  
The hash codes match.  
```  
  
 If they do not match, the code displays the following:  
  
```console  
The hash codes do not match.  
```  
  
## See also

- [Cryptography Model](cryptography-model.md)
- [Cryptographic Services](cryptographic-services.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
- [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
