---
title: "Breaking change: Creating type of array of System.Void not allowed"
description: Learn about the .NET 9 breaking change in core .NET libraries where it's no longer allowed to create a type of array of System.Void.
ms.date: 01/18/2024
ms.topic: concept-article
---
# Creating type of array of System.Void not allowed

It's no longer permitted to create a <xref:System.Type?displayProperty=fullName> instance for an array of <xref:System.Void?displayProperty=fullName>.

## Previous behavior

Previously, `typeof(void).MakeArrayType()` returned a <xref:System.Type?displayProperty=fullName> instance.

## New behavior

Starting in .NET 9, `typeof(void).MakeArrayType()` throws an exception.

## Version introduced

.NET 9 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Array of <xref:System.Void?displayProperty=fullName> is an invalid type. This type is rejected in some cases (for example, `void[]` in C# does not compile) and it's not possible to create arrays of this type.

.NET runtimes allowed this invalid type to be created in some situations. However, attempts to use this invalid type in other .NET runtime APIs often lead to unexpected behaviors. To make the behavior robust and consistent, it's better to disallow creating these invalid array types in all situations.

## Recommended action

Remove code that tries to create a type for an array of <xref:System.Void?displayProperty=fullName>.

## Affected APIs

- <xref:System.Type.MakeArrayType?displayProperty=fullName>
