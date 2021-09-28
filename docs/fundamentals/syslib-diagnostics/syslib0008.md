---
title: SYSLIB0008 warning
description: Learn about the obsoletion that generates compile-time warning SYSLIB0008.
ms.date: 10/20/2020
---
# SYSLIB0008: CreatePdbGenerator is not supported

The <xref:System.Runtime.CompilerServices.DebugInfoGenerator.CreatePdbGenerator?displayProperty=nameWithType> API is marked obsolete, starting in .NET 5. Using this API generates warning `SYSLIB0008` at compile time and throws a <xref:System.PlatformNotSupportedException> at run time.

<!-- Include adds ## Suppress warnings (H2 heading) -->
[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
