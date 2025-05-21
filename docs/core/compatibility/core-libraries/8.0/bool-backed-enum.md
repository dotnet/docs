---
title: ".NET 8 breaking change: Boolean-backed enum type support removed"
description: Learn about the .NET 8 breaking change in core .NET libraries where support for parsing, formatting, and conversions of Boolean-backed enumeration types has been removed.
ms.date: 08/02/2023
ms.topic: article
---
# Boolean-backed enum type support removed

Support for formatting, parsing, and conversions of Boolean-backed [enumeration types](../../../../csharp/language-reference/builtin-types/enum.md) has been removed.

## Previous behavior

Previously, formatting, parsing, or converting a Boolean-backed enumeration type was somewhat functional.

## New behavior

Starting in .NET 8, an <xref:System.InvalidOperationException> is thrown if you try to format, parse, or convert a Boolean-backed enumeration type.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to make the .NET runtime simpler, faster, and smaller. Formatting and parsing Boolean-backed enumeration types is never used in practice and complicates the implementation. Also, Boolean-backed enum types aren't expressible in C#.

## Recommended action

If you're using a Boolean-backed enumeration type, use a regular Boolean type or a byte-backed enumeration type instead.

## Affected APIs

- <xref:System.Enum.Parse%2A?displayProperty=fullName>
- <xref:System.Enum.TryParse%2A?displayProperty=fullName>
- <xref:System.Enum.Format(System.Type,System.Object,System.String)?displayProperty=fullName>
- <xref:System.Enum.GetName%2A?displayProperty=fullName>
- <xref:System.Enum.GetNames%2A?displayProperty=fullName>
- <xref:System.Enum.GetValues%2A?displayProperty=fullName>
- <xref:System.Enum.ToObject%2A?displayProperty=fullName>
