---
title: SYSLIB0028 warning
description: Learn about the obsoletion of X509Certificate2.PrivateKey that generates compile-time warning SYSLIB0028.
ms.date: 07/16/2021
---
# SYSLIB0028: X509Certificate2.PrivateKey is obsolete

The <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.PrivateKey?displayProperty=nameWithType> property is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0028` at compile time.

## Workarounds

Use the appropriate method to get the private key, such as <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPrivateKey(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType>, or use the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.CopyWithPrivateKey(System.Security.Cryptography.ECDiffieHellman)?displayProperty=nameWithType> method to create a new instance with a private key.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
