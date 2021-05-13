---
title: SYSLIB0018 warning
description: Learn about the obsoletion of reflection-only load methods that generates compile-time warning SYSLIB0018.
ms.date: 05/07/2021
---
# SYSLIB0018: Reflection-only loading is not supported and throws PlatformNotSupportedException

The following methods are marked as obsolete, starting in .NET 6. Calling them in code generates warning `SYSLIB0018` at compile time. These methods throw a <xref:System.PlatformNotSupportedException> at run time.

- <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A?displayProperty=nameWithType>
- <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom(System.String)?displayProperty=nameWithType>
- <xref:System.Type.ReflectionOnlyGetType(System.String,System.Boolean,System.Boolean)?displayProperty=nameWithType>

For more information, see <https://github.com/dotnet/runtime/issues/50529>.

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
