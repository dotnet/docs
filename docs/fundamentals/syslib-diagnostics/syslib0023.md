---
title: SYSLIB0023 warning
description: Learn about the RNGCryptoServiceProvider obsoletion that generates compile-time warning SYSLIB0023.
ms.date: 05/18/2021
---
# SYSLIB0023: RNGCryptoServiceProvider is obsolete

<xref:System.Security.Cryptography.RNGCryptoServiceProvider> is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0023` at compile time.

## Workarounds

To generate a random number, use one of the <xref:System.Security.Cryptography.RandomNumberGenerator> methods instead, for example, <xref:System.Security.Cryptography.RandomNumberGenerator.GetInt32(System.Int32)?displayProperty=nameWithType>.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
