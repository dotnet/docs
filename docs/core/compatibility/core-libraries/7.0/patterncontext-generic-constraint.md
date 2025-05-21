---
title: ".NET 7 breaking change: Generic type constraint on PatternContext<T>"
description: Learn about the .NET 7 breaking change in core .NET libraries where the generic type parameter on PatternContext<T> is constrained to be a struct type.
ms.date: 03/16/2022
ms.topic: article
---
# Generic type constraint on PatternContext\<T>

As part of annotating the .NET library for nullable reference types, a new generic constraint was added to <xref:Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext%601>. If you're consuming this class directly, your code may break if the `TFrame` type is not a struct.

## Previous behavior

Previously, <xref:Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext%601> allowed any type to fill the `TFrame` type parameter.

## New behavior

Starting in .NET 7, the generic type parameter on <xref:Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext%601>, `TFrame`, is constrained to be a [struct](../../../../csharp/language-reference/builtin-types/struct.md).

## Version introduced

.NET 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was necessary to annotate the type correctly for nullable contexts.

## Recommended action

If you're currently using this type in your code, we recommend that you remove it. This type supports infrastructure and is not intended to be used directly from your code.

## Affected APIs

- <xref:Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext%601?displayProperty=fullName>
