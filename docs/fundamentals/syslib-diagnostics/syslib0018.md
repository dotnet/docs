---
title: SYSLIB0018 warning
description: Learn about the obsoletion of reflection-only load methods that generates compile-time warning SYSLIB0018.
ms.date: 03/02/2022
---
# SYSLIB0018: Reflection-only loading is not supported and throws PlatformNotSupportedException

The following methods are marked as obsolete, starting in .NET 6. Calling them in code generates warning `SYSLIB0018` at compile time. These methods throw a <xref:System.PlatformNotSupportedException> at run time.

- <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A?displayProperty=nameWithType>
- <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom(System.String)?displayProperty=nameWithType>
- <xref:System.Type.ReflectionOnlyGetType(System.String,System.Boolean,System.Boolean)?displayProperty=nameWithType>

## Workarounds

Reflection-only loading is replaced by the metadata load-context in .NET Core and .NET 5+. For more information, see [How to: Inspect assembly contents using MetadataLoadContext](../../standard/assembly/inspect-contents-using-metadataloadcontext.md).

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
