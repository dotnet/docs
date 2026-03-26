---
title: "C# Enumerations"
description: Learn how to define and use enumeration types in C#, including declaring enums, using them in switch expressions, working with bit flags, and converting between enums and integers.
ms.date: 03/24/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# C# enumerations

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll encounter enums once you need to represent a fixed set of choices in your code.
>
> **Experienced in another language?** C# enums work similarly to enums in Java or C++, with additional support for bit flags and pattern matching. Skim the [flags](#bit-flags) and [switch expression](#use-enums-in-switch-expressions) sections for C#-specific patterns.

An *enumeration type* (or *enum*) defines a set of named constants backed by an integer value. Use enums when a value must be one of a fixed set of options—days of the week, HTTP status codes, log levels, or directions. Enums make your code more readable and less error-prone than raw integer constants because the compiler enforces the named values.

## Declare an enum

Define an enum with the `enum` keyword followed by the type name and its members:

:::code language="csharp" source="snippets/enums/Program.cs" ID="BasicEnum":::

By default, the underlying type is `int`, and values start at `0` and increment by one. `Season.Spring` is `0`, `Season.Summer` is `1`, and so on.

## Specify an underlying type and explicit values

You can choose a different integral type and assign explicit values to control the numeric representation:

:::code language="csharp" source="snippets/enums/Program.cs" ID="UnderlyingType":::

Use explicit values when the numbers have external meaning, such as HTTP status codes or protocol identifiers. The underlying type can be any [integral type](../../language-reference/builtin-types/integral-numeric-types.md) except `char`. Use `byte`, `short`, `ushort`, `int`, `uint`, `long`, or `ulong`.

## Use enums in switch expressions

Enums work naturally with `switch` expressions and pattern matching. The compiler warns you if you don't handle all members, which helps prevent bugs when you add a new value later:

:::code language="csharp" source="snippets/enums/Program.cs" ID="SwitchEnum":::

:::code language="csharp" source="snippets/enums/Program.cs" ID="UsingSeason":::

The discard pattern (`_`) handles any value not explicitly listed. *Pattern matching* is a C# feature that tests a value against a shape or condition. In this example, each `case` checks whether the enum matches a specific member. Switch expressions are one of several pattern matching forms. For more information about pattern matching, see [Pattern matching](../functional/pattern-matching.md).

## Bit flags

When an enum represents a combination of choices rather than a single choice, define each member as a power of two and apply the <xref:System.FlagsAttribute>:

:::code language="csharp" source="snippets/enums/Program.cs" ID="FlagsEnum":::

Combine values by using the `|` operator and test for individual flags by using <xref:System.Enum.HasFlag%2A>:

:::code language="csharp" source="snippets/enums/Program.cs" ID="UsingFlags":::

The `[Flags]` attribute also affects `ToString()`. It displays combined values as comma-separated names (like `Read, Write`) instead of a raw number. For more information, see <xref:System.FlagsAttribute?displayProperty=nameWithType>.

## Convert between enums and integers

Explicit casts convert between an enum and its underlying integer type:

:::code language="csharp" source="snippets/enums/Program.cs" ID="Conversions":::

Be aware that casting an integer to an enum doesn't validate whether the value matches a defined member. Use <xref:System.Enum.IsDefined%2A?displayProperty=nameWithType> to check validity when you accept numeric input from external sources.

## Parse strings and iterate values

The <xref:System.Enum> base class provides methods for parsing strings and iterating over all defined values:

:::code language="csharp" source="snippets/enums/Program.cs" ID="ParseAndIterate":::

Use <xref:System.Enum.TryParse%60%601(System.String,System.Boolean,%60%600@)?displayProperty=nameWithType> instead of <xref:System.Enum.Parse%60%601(System.String)?displayProperty=nameWithType> when the input might be invalid. It returns `false` instead of throwing an exception.

## See also

- [Type system overview](index.md)
- [Enumeration types (C# reference)](../../language-reference/builtin-types/enum.md)
- [Pattern matching](../functional/pattern-matching.md)
- [Enum design guidelines](../../../standard/design-guidelines/enum.md)
