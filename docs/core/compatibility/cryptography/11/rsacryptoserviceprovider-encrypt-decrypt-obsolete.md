---
title: "Breaking change: RSACryptoServiceProvider.Encrypt and Decrypt with fOAEP parameter are obsolete"
description: "Learn about the breaking change in .NET 11 where the RSACryptoServiceProvider.Encrypt and RSACryptoServiceProvider.Decrypt methods that accept a bool fOAEP parameter are marked as obsolete."
ms.date: 04/03/2026
ai-usage: ai-assisted
---

# RSACryptoServiceProvider.Encrypt and Decrypt with fOAEP parameter are obsolete

The <xref:System.Security.Cryptography.RSACryptoServiceProvider.Encrypt(System.Byte[],System.Boolean)?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSACryptoServiceProvider.Decrypt(System.Byte[],System.Boolean)?displayProperty=nameWithType> methods are now obsolete. Calling these methods produces a `SYSLIB0064` compiler warning.

## Version introduced

.NET 11 Preview 3

## Previous behavior

Previously, code could call the `Encrypt(byte[] rgb, bool fOAEP)` and `Decrypt(byte[] rgb, bool fOAEP)` methods on <xref:System.Security.Cryptography.RSACryptoServiceProvider> without any compilation warnings.

## New behavior

Starting in .NET 11, calling these methods generates a `SYSLIB0064` compiler warning.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

When `fOAEP` was `true`, the affected methods always used SHA-1 as the digest algorithm for the Optimal Asymmetric Encryption Padding (OAEP) scheme. The hash algorithm used was implicit and couldn't be changed. Developers are encouraged to use the overloads that accept an explicit <xref:System.Security.Cryptography.RSAEncryptionPadding> argument. These overloads make the hash algorithm apparent rather than implicit, allow greater flexibility in the hash algorithm used, and help prevent accidental use of OAEP-SHA-1 when a stronger digest algorithm would be more appropriate.

## Recommended action

Replace calls to the obsolete overloads with the corresponding overloads that accept an <xref:System.Security.Cryptography.RSAEncryptionPadding> argument:

| Obsolete call | Replacement |
|---|---|
| `Encrypt(data, fOAEP: true)` | `Encrypt(data, RSAEncryptionPadding.OaepSHA1)` |
| `Encrypt(data, fOAEP: false)` | `Encrypt(data, RSAEncryptionPadding.Pkcs1)` |
| `Decrypt(data, fOAEP: true)` | `Decrypt(data, RSAEncryptionPadding.OaepSHA1)` |
| `Decrypt(data, fOAEP: false)` | `Decrypt(data, RSAEncryptionPadding.Pkcs1)` |

If you're using OAEP padding, consider using a stronger digest algorithm such as SHA-256 by specifying <xref:System.Security.Cryptography.RSAEncryptionPadding.OaepSHA256?displayProperty=nameWithType> instead of <xref:System.Security.Cryptography.RSAEncryptionPadding.OaepSHA1?displayProperty=nameWithType>.

If you must continue using the obsolete API, you can suppress the warning in code:

```csharp
#pragma warning disable SYSLIB0064
// Code that uses obsolete API.
#pragma warning restore SYSLIB0064
```

Or in your project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <NoWarn>$(NoWarn);SYSLIB0064</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [SYSLIB0064](../../../../fundamentals/syslib-diagnostics/syslib0064.md).

## Affected APIs

- <xref:System.Security.Cryptography.RSACryptoServiceProvider.Encrypt(System.Byte[],System.Boolean)?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSACryptoServiceProvider.Decrypt(System.Byte[],System.Boolean)?displayProperty=fullName>
