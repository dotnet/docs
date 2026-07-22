---
title: "How to use data protection"
description: Learn how to use data protection by accessing the data protection API (DPAPI) in .NET.
ms.date: 07/22/2026
ai-usage: ai-assisted
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
# How to use data protection

> [!NOTE]
> This article applies to Windows.
>
> For information about ASP.NET Core, see [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction).

.NET provides access to the data protection API (DPAPI), which lets you encrypt data using information from the current user account or computer. When you use the DPAPI, you avoid the difficult problem of explicitly generating and storing a cryptographic key.

Use the <xref:System.Security.Cryptography.ProtectedData> class to encrypt a copy of an array of bytes. You can specify that only the same user account can decrypt the data, or that any account on the computer can decrypt it. For a detailed description of <xref:System.Security.Cryptography.ProtectedData> options, see the <xref:System.Security.Cryptography.DataProtectionScope> enumeration.

## Encrypt data to a file or stream using data protection

1. Create random entropy.

2. Call the static <xref:System.Security.Cryptography.ProtectedData.Protect*> method while passing an array of bytes to encrypt, the entropy, and the data protection scope.

3. Write the encrypted data to a file or stream.

### To decrypt data from a file or stream using data protection

1. Read the encrypted data from a file or stream.

2. Call the static <xref:System.Security.Cryptography.ProtectedData.Unprotect*> method while passing an array of bytes to decrypt and the data protection scope.

## Example

The following code example shows two forms of encryption and decryption. First, the code encrypts and then decrypts an in-memory array of bytes. Next, the code encrypts a copy of a byte array, saves it to a file, loads the data back from the file, and then decrypts the data. The example displays the original data, the encrypted data, and the decrypted data.

> [!IMPORTANT]
> <xref:System.Security.Cryptography.ProtectedMemory> is only available for .NET Framework. <xref:System.Security.Cryptography.ProtectedData> is available on .NET and .NET Framework.

### [.NET](#tab/net)

This sample compiles and runs when you target .NET on Windows. To compile the sample, add the [`System.Security.Cryptography.ProtectedData`](https://www.nuget.org/packages/System.Security.Cryptography.ProtectedData/) NuGet package.

:::code language="csharp" source="./snippets/how-to-use-data-protection/net/csharp/sample.cs":::
:::code language="vb" source="./snippets/how-to-use-data-protection/net/vb/sample.vb":::

### [.NET Framework](#tab/net-framework)

This sample compiles and runs when you target .NET Framework on Windows. To compile the sample, add a library reference to `System.Security.dll`.

:::code language="csharp" source="./snippets/how-to-use-data-protection/framework/csharp/sample.cs":::
:::code language="vb" source="./snippets/how-to-use-data-protection/framework/vb/sample.vb":::

---

## See also

- [Cryptography model](cryptography-model.md)
- [Cryptographic services](cryptographic-services.md)
- [Cross-platform cryptography](cross-platform-cryptography.md)
- <xref:System.Security.Cryptography.ProtectedMemory>
- <xref:System.Security.Cryptography.ProtectedData>
- [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
