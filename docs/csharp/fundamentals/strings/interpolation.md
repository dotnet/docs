---
title: "String interpolation in C#"
description: Learn how to build result strings in C# with string interpolation by embedding formatted expression results directly in a string literal.
ms.date: 05/21/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# String interpolation in C\#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** String interpolation in C# works much like template literals in JavaScript (`` `${x}` ``) or f-strings in Python (`f"{x}"`). The expression inside `{}` can be any valid C# expression, and you can add format and alignment specifiers without leaving the string.

*String interpolation* lets you embed expressions directly in a string literal by prefixing the literal with `$`:

:::code language="csharp" source="snippets/interpolation/Program.cs" id="general":::

Each `{ }` is an *interpolation expression*. C# evaluates the expression, converts the result to a string by calling its `ToString()` method, and substitutes the text into the result. The string interpolation for a `null` expression is the empty string. In most cases, the default conversion produces the output you want, and you don't need to do anything more.

Interpolated strings are a more readable alternative to <xref:System.String.Format*?displayProperty=nameWithType>, and they support the full [composite formatting](../../../standard/base-types/composite-formatting.md) feature set. Anything you can do with a classic positional format string—format specifiers, alignment, culture-aware formatting, and constant strings—you can also do with an interpolated string. The rest of this article covers those options. Reach for them only when you need finer control over the result; otherwise, the plain `$"{expression}"` form is enough.

For the language-reference treatment of the syntax and the underlying handler types, see [interpolated string](../../language-reference/tokens/interpolated.md) reference. For performance-focused topics such as `Span<char>` interpolation and custom interpolated string handlers, see [String operations](../../language-reference/builtin-types/string-operations.md).

## Apply a format string

To control how an expression result is formatted, follow the expression with a colon and a [standard or custom format string](../../../standard/base-types/formatting-types.md):

```csharp
{<expression>:<formatString>}
```

The following example formats a <xref:System.DateTime> and a <xref:System.Double> value:

:::code language="csharp" source="snippets/interpolation/Program.cs" id="FormatString":::

## Set the field width and alignment

To produce aligned output, follow the expression with a comma and a minimum field width. Positive widths right-align the value, and negative widths left-align it:

```csharp
{<expression>,<width>}
```

:::code language="csharp" source="snippets/interpolation/Program.cs" id="alignment":::

When you need both alignment and a format string, put alignment first:

```csharp
{<expression>,<width>:<formatString>}
```

:::code language="csharp" source="snippets/interpolation/Program.cs" id="AlignmentAndFormat":::

If the formatted value is longer than the requested width, C# ignores the width and emits the full value.

## Escape braces and use escape sequences

Interpolated strings support the same escape sequences as ordinary string literals. To include a literal `{` or `}` character in the result, double it (`{{` or `}}`).

For paths and other strings that contain backslashes, prefer an [interpolated raw string literal](../../language-reference/tokens/raw-string.md) (`$"""..."""`) over the older verbatim form (`$@"..."`). Raw string literals don't process escape sequences, so backslashes appear as-is:

:::code language="csharp" source="snippets/interpolation/Program.cs" id="escapes":::

## Use a conditional expression

The colon has special meaning inside an interpolation expression, so wrap a [conditional exoressuin](../../language-reference/operators/conditional-operator.md) in parentheses:

:::code language="csharp" source="snippets/interpolation/Program.cs" id="conditional":::

## Span an expression across multiple lines

For better readability, break long interpolation expressions across multiple lines. Multi-line interpolation expressions are available since C# 11. The following example adds newlines between the `{` and `}` characters to separate the interpolated expressions from the literal text:

:::code language="csharp" source="snippets/interpolation/Program.cs" id="newlines":::

## Build constant strings

You can build constant interpolated strings when every interpolated expression is a constant value.That makes it usable for attribute arguments, `switch` patterns, and other contexts that require compile-time constants:

:::code language="csharp" source="snippets/interpolation/Program.cs" id="ConstantInterpolated":::

## Format with a specific culture

By default, an interpolated string formats values using <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType>, which affects date, number, and currency representations. For deterministic output, pass an explicit culture to <xref:System.String.Create(System.IFormatProvider,System.Runtime.CompilerServices.DefaultInterpolatedStringHandler%40)?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/interpolation/Program.cs" id="culture":::

For invariant output (logs, file formats, machine-readable data), pass <xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/interpolation/Program.cs" id="invariant":::

## See also

- [Interpolated string token](../../language-reference/tokens/interpolated.md)
- [String operations: pattern matching, performance, and span-based search](../../language-reference/builtin-types/string-operations.md)
- [Composite formatting](../../../standard/base-types/composite-formatting.md)
- [Formatting types in .NET](../../../standard/base-types/formatting-types.md)
- <xref:System.String.Format*?displayProperty=nameWithType>
- <xref:System.FormattableString?displayProperty=nameWithType>
