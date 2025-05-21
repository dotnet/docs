---
title: "Breaking change: Asterisk no longer accepted for assembly name attributes"
description: Learn about the breaking change in core .NET libraries in .NET 7 where assembly names no longer accept '*' as a wildcard attribute value.
ms.date: 11/25/2024
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/42598
ms.topic: how-to
---

# Asterisk no longer accepted for assembly name attributes

Prior to .NET 7, assembly names allowed specifying `*` as a wildcard value for an attribute value, which was equivalent to not specifying the value at all. This undocumented feature was removed in .NET 7.

## Version introduced

.NET 7

## Previous behavior

Previously, you could specify `*` as a value for assembly name attributes. For example, the following code succeeded:

```csharp
Assembly.Load("System.Runtime, Version=*, PublicKeyToken=*");
```

The asterisk had identical behavior to not specifying the attribute value at all:

```csharp
Assembly.Load("System.Runtime");
```

## New behavior

Starting in .NET 7, the following code fails with a <xref:System.IO.FileLoadException> with the error message "The given assembly name was invalid".

```csharp
Assembly.Load("System.Runtime, Version=*, PublicKeyToken=*")
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was an undocumented feature and it wasn't consistent implemented by all .NET assembly name parsers. The undocumented feature was removed to unify the behavior of assembly name parsing throughout .NET.

## Recommended action

Omit assembly name attributes that have a wildcard value. For example, change `System.Runtime, Version=*` to just `System.Runtime`.

## Affected APIs

- <xref:System.Reflection.Assembly.Load(System.String)?displayProperty=fullName>
- <xref:System.Type.GetType(System.String)?displayProperty=fullName>
- <xref:System.Reflection.AssemblyName.%23ctor(System.String)?displayProperty=fullName>
