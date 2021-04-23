---
title: SYSLIB0015 warning
description: Learn about the obsoletion of DisablePrivateReflectionAttribute that generates compile-time warning SYSLIB0015.
ms.topic: reference
ms.date: 04/24/2021
---
# SYSLIB0015: DisablePrivateReflectionAttribute is obsolete

The <xref:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute?displayProperty=nameWithType> type is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0015` at compile time.

<xref:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute> has no effect in .NET 6+ applications.

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](../../../../includes/suppress-syslib-warning.md)]
