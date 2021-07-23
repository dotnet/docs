---
title: SYSLIB0029 warning
description: Learn about the obsoletion of ProduceLegacyHmacValues that generates compile-time warning SYSLIB0029.
ms.date: 07/16/2021
---
# SYSLIB0029: ProduceLegacyHmacValues is obsolete

The following properties are marked as obsolete, starting in .NET 6:

- <xref:System.Security.Cryptography.HMACSHA384.ProduceLegacyHmacValues?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.HMACSHA512.ProduceLegacyHmacValues?displayProperty=nameWithType>

Using these APIs in code generates warning `SYSLIB0029` at compile time. Producing legacy HMAC values is no longer supported.

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
