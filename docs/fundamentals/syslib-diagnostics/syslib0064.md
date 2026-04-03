---
title: SYSLIB0064 warning - RSACryptoServiceProvider.Encrypt and Decrypt with fOAEP are obsolete
description: Learn about the obsoletion of RSACryptoServiceProvider.Encrypt and RSACryptoServiceProvider.Decrypt methods that accept a bool fOAEP parameter. Use of these methods generates compile-time warning SYSLIB0064.
ms.date: 04/03/2026
ai-usage: ai-assisted
f1_keywords:
  - SYSLIB0064
---

# SYSLIB0064: RSACryptoServiceProvider.Encrypt and Decrypt with fOAEP are obsolete

Starting in .NET 11, the <xref:System.Security.Cryptography.RSACryptoServiceProvider.Encrypt(System.Byte[],System.Boolean)?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSACryptoServiceProvider.Decrypt(System.Byte[],System.Boolean)?displayProperty=nameWithType> methods are obsolete. Calling these methods in code generates warning `SYSLIB0064` at compile time.

## Reason for obsoletion

When the `fOAEP` parameter is `true`, these methods always use SHA-1 as the digest algorithm for Optimal Asymmetric Encryption Padding (OAEP). The hash algorithm is implicit and can't be changed. Developers are encouraged to use overloads that accept an explicit <xref:System.Security.Cryptography.RSAEncryptionPadding> argument. These overloads make the hash algorithm explicit rather than implicit, allow greater flexibility in the choice of hash algorithm, and help prevent accidental use of OAEP-SHA-1 when a stronger digest would be more appropriate.

## Workaround

Replace calls to the obsolete overloads with the corresponding overloads that accept an <xref:System.Security.Cryptography.RSAEncryptionPadding> argument:

| Obsolete call | Replacement |
|---|---|
| `Encrypt(data, fOAEP: true)` | `Encrypt(data, RSAEncryptionPadding.OaepSHA1)` |
| `Encrypt(data, fOAEP: false)` | `Encrypt(data, RSAEncryptionPadding.Pkcs1)` |
| `Decrypt(data, fOAEP: true)` | `Decrypt(data, RSAEncryptionPadding.OaepSHA1)` |
| `Decrypt(data, fOAEP: false)` | `Decrypt(data, RSAEncryptionPadding.Pkcs1)` |

If you're using OAEP padding, consider using a stronger digest algorithm such as SHA-256 by specifying <xref:System.Security.Cryptography.RSAEncryptionPadding.OaepSHA256?displayProperty=nameWithType> instead of <xref:System.Security.Cryptography.RSAEncryptionPadding.OaepSHA1?displayProperty=nameWithType>.

## Suppress a warning

If you must use the obsolete API, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0064

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0064
```

To suppress all the `SYSLIB0064` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0064</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
