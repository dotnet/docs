---
title: SYSLIB0036 warning - Regex.CompileToAssembly is obsolete
description: Learn about the obsoletion of the Regex.CompileToAssembly method that generates compile-time warning SYSLIB0036.
ms.date: 01/13/2022
---
# SYSLIB0036: Regex.CompileToAssembly is obsolete

The <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> method is marked as obsolete, starting in .NET 7. Using this API in code generates warning `SYSLIB0036` at compile time.

In .NET 5, .NET 6, and all versions of .NET Core, <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> throws a <xref:System.PlatformNotSupportedException>. In .NET Framework, <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> allows a regular expression instance to be compiled into an assembly.

## Workaround

Use the `RegexGeneratorAttribute` feature, which invokes a regular expression source generator. At compile time, the source generator produces an API specific to a regular expression pattern and its options.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
