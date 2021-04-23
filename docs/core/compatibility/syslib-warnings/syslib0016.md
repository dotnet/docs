---
title: SYSLIB0016 warning
description: Learn about the GetContextInfo obsoletion that generates compile-time warning SYSLIB0016.
ms.topic: reference
ms.date: 04/24/2021
---
# SYSLIB0016: GetContextInfo() is obsolete

The <xref:System.Drawing.Graphics.GetContextInfo?displayProperty=nameWithType> method that takes no arguments is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0016` at compile time.

## Workarounds

Use the <xref:System.Drawing.Graphics.GetContextInfo%2A?displayProperty=nameWithType> overloads that accept arguments for better performance and fewer allocations.

[!INCLUDE [suppress-syslib-warning](../../../../includes/suppress-syslib-warning.md)]
