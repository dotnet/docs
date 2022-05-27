---
title: SYSLIB0035 warning - ComputeCounterSignature without specifying a CmsSigner is obsolete
description: Learn about the obsoletion of the parameterless ComputeCounterSignature method that generates compile-time warning SYSLIB0035.
ms.date: 09/07/2021
---
# SYSLIB0035: ComputeCounterSignature without specifying a CmsSigner is obsolete

The <xref:System.Security.Cryptography.Pkcs.SignerInfo.ComputeCounterSignature?displayProperty=nameWithType> method is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0035` at compile time.

## Workaround

Use the overload that accepts a <xref:System.Security.Cryptography.Pkcs.CmsSigner>, that is, <xref:System.Security.Cryptography.Pkcs.SignerInfo.ComputeCounterSignature(System.Security.Cryptography.Pkcs.CmsSigner)?displayProperty=nameWithType>.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
