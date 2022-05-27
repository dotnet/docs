---
title: SYSLIB0016 warning
description: Learn about the GetContextInfo obsoletion that generates compile-time warning SYSLIB0016.
ms.date: 04/24/2021
---
# SYSLIB0016: GetContextInfo() is obsolete

The <xref:System.Drawing.Graphics.GetContextInfo?displayProperty=nameWithType> method that takes no arguments is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0016` at compile time.

For more information, see <https://github.com/dotnet/runtime/issues/47880>.

## Workarounds

For better performance and fewer allocations, use the <xref:System.Drawing.Graphics.GetContextInfo%2A?displayProperty=nameWithType> overloads that accept arguments:

- <xref:System.Drawing.Graphics.GetContextInfo(System.Drawing.PointF@)?displayProperty=fullName>
- <xref:System.Drawing.Graphics.GetContextInfo(System.Drawing.PointF@,System.Drawing.Region@)?displayProperty=fullName>

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
