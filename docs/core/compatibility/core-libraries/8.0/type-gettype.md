---
title: ".NET 8 breaking change: 'Type.GetType' throws exception for all invalid element types"
description: Learn about the .NET 8 breaking change in core .NET libraries where 'Type.GetType' throws a TypeLoadException for all invalid element types.
ms.date: 03/12/2024
---
# `Type.GetType` throws exception for all invalid element types

<xref:System.Type.GetType(System.String)?displayProperty=nameWithType> now throws a <xref:System.TypeLoadException> for *all* types with an invalid element type, including byref-of-byref. Previously, this method returned `null` for some corner cases.

## Previous behavior

<xref:System.Type.GetType(System.String)?displayProperty=nameWithType> threw a <xref:System.TypeLoadException> for most types with an invalid element type, except a few corner cases such as byref-of-byref. For example, the following code returned `null` in .NET 7:

```csharp
Type.GetType("System.Object&&")
```

## New behavior

<xref:System.Type.GetType(System.String)?displayProperty=nameWithType> throws a <xref:System.TypeLoadException> for all types with an invalid element type, including byref-of-byref. For example, the following code (which returned `null` in .NET 7) throws an exception in .NET 8:

```csharp
Type.GetType("System.Object&&")
```

## Version introduced

.NET 8

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

.NET had multiple type-name parsers, and it was not unusual for them to have different behavior in corner cases like this one. The behavior was unified on:

- If the type with the given name is not found, return `null`.
- If the type is invalid, throw <xref:System.TypeLoadException>. "Invalid" types include types with generic constraint violations or invalid composition of parameter types.

## Recommended action

If your code relied on a `null` return value for these corner cases, change it to catch a <xref:System.TypeLoadException> instead.

## Affected APIs

- <xref:System.Type.GetType(System.String)>
- <xref:System.Type.GetType(System.String,System.Boolean)>
- <xref:System.Type.GetType(System.String,System.Boolean,System.Boolean)>
- <xref:System.Type.GetType(System.String,System.Func{System.Reflection.AssemblyName,System.Reflection.Assembly},System.Func{System.Reflection.Assembly,System.String,System.Boolean,System.Type})>
- <xref:System.Type.GetType(System.String,System.Func{System.Reflection.AssemblyName,System.Reflection.Assembly},System.Func{System.Reflection.Assembly,System.String,System.Boolean,System.Type},System.Boolean)>
- <xref:System.Type.GetType(System.String,System.Func{System.Reflection.AssemblyName,System.Reflection.Assembly},System.Func{System.Reflection.Assembly,System.String,System.Boolean,System.Type},System.Boolean,System.Boolean)>
