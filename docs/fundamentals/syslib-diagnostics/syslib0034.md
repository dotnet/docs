---
title: SYSLIB0034 warning - CmsSigner(CspParameters) constructor is obsolete
description: Learn about the obsoletion of the CmsSigner(CspParameters) constructor that generates compile-time warning SYSLIB0034.
ms.date: 09/07/2021
---
# SYSLIB0034: CmsSigner(CspParameters) constructor is obsolete

The <xref:System.Security.Cryptography.Pkcs.CmsSigner.%23ctor(System.Security.Cryptography.CspParameters)> constructor is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0034` at compile time.

## Workaround

Use an alternative constructor.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
