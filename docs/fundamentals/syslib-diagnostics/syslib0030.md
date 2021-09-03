---
title: SYSLIB0030 warning
description: Learn about the obsoletion of one of the HMACSHA1 constructors that generates compile-time warning SYSLIB0030.
ms.date: 07/16/2021
---
# SYSLIB0030: HMACSHA1 always uses the algorithm implementation provided by the platform

The <xref:System.Security.Cryptography.HMACSHA1.%23ctor(System.Byte[],System.Boolean)> constructor is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0030` at compile time.

## Workarounds

Use a constructor without the `useManagedSha1` parameter.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
