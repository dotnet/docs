---
title: SYSLIB0012 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0012.
ms.date: 10/20/2020
---
# SYSLIB0012: Assembly.CodeBase and Assembly.EscapedCodeBase are obsolete

The following APIs are marked as obsolete, starting in .NET 5. Using them in code generates warning `SYSLIB0012` at compile time.

- <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType>
- <xref:System.Reflection.Assembly.EscapedCodeBase?displayProperty=nameWithType>

## Workarounds

Use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
