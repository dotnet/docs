---
title: SYSLIB0031 warning
description: Learn about the obsoletion of EncodeOID that generates compile-time warning SYSLIB0031.
ms.date: 07/16/2021
---
# SYSLIB0031: EncodeOID is obsolete

The <xref:System.Security.Cryptography.CryptoConfig.EncodeOID(System.String)?displayProperty=nameWithType> method is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0031` at compile time and throws a <xref:System.PlatformNotSupportedException> exception at run time.

## Workarounds

Use the ASN.1 functionality provided in <xref:System.Formats.Asn1?displayProperty=fullName>.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
