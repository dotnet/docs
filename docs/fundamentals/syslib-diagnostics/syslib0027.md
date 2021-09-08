---
title: SYSLIB0027 warning
description: Learn about the obsoletion of PublicKey.Key that generates compile-time warning SYSLIB0027.
ms.date: 07/16/2021
---
# SYSLIB0027: PublicKey.Key is obsolete

The <xref:System.Security.Cryptography.X509Certificates.PublicKey.Key?displayProperty=nameWithType> property is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0027` at compile time.

## Workarounds

Use the appropriate method to get the public key, such as <xref:System.Security.Cryptography.X509Certificates.PublicKey.GetRSAPublicKey>.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
