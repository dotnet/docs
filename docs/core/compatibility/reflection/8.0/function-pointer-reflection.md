---
title: "Breaking change: IntPtr no longer used for function pointer types"
description: Learn about a breaking change in .NET 8 SDK where System.Reflection uses a System.Type instance to represent a function pointer.
ms.date: 03/17/2023
ms.topic: concept-article
---
# IntPtr no longer used for function pointer types

As a new reflection feature, a function pointer type is now a <xref:System.Type?displayProperty=nameWithType> instance with new capabilities such as <xref:System.Type.IsFunctionPointer?displayProperty=nameWithType>. Previously, the <xref:System.Type?displayProperty=nameWithType> instance returned was the <xref:System.IntPtr> type.

Using <xref:System.Type?displayProperty=nameWithType> in this manner is similar to how other types are exposed, such as pointers (<xref:System.Type.IsPointer?displayProperty=nameWithType>) and arrays (<xref:System.Type.IsArray?displayProperty=nameWithType>).

This new functionality is currently implemented in the CoreCLR runtime and in <xref:System.Reflection.MetadataLoadContext>. Support for the Mono and NativeAOT runtimes is expected later.

A function pointer instance, which is a physical address to a function, continues to be represented as an <xref:System.IntPtr>; only the reflection type has changed.

## Previous behavior

Previously, `typeof(delegate*<void>())` returned the <xref:System.IntPtr?displayProperty=fullName> type for a function pointer type. Similarly, reflection also returned this type for a function pointer type, such as with <xref:System.Reflection.FieldInfo.FieldType?displayProperty=nameWithType>. The <xref:System.IntPtr> type didn't allow any access to the parameter types, return type, or calling conventions.

## New behavior

`typeof` and reflection now use <xref:System.Type?displayProperty=fullName> for a function pointer type, which provides access to the parameter types, return type, and calling conventions.

## Version introduced

.NET 8 Preview 2

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change adds the capability to obtain function pointer metadata including parameter types, the return type, and the calling conventions. Function pointer support was added with C# 9 and .NET 5, but reflection support wasn't added at that time.

## Recommended action

If you want your code to support function pointers and to treat them specially, use the new <xref:System.Type.IsFunctionPointer?displayProperty=nameWithType> API.

## Affected APIs

- `typeof` keyword
- <xref:System.Reflection.FieldInfo.FieldType?displayProperty=fullName>
- <xref:System.Reflection.PropertyInfo.PropertyType?displayProperty=fullName>
- <xref:System.Reflection.ParameterInfo.ParameterType?displayProperty=fullName>
