---
title: "Concatenate strings in C#"
description: Learn how to join strings in C# with the + and += operators, string interpolation, StringBuilder, and string.Join, and when to choose each.
ms.date: 05/28/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Concatenate strings in C\#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** C# joins strings with the same `+` operator you might know from Java or JavaScript, and with template-style syntax (`$"Hello, {name}"`) that resembles JavaScript template literals or Python f-strings. Unlike Python, strings in C# are immutable: every `+` produces a new <xref:System.String>. For loops or large amounts of text, use <xref:System.Text.StringBuilder> the way Java developers reach for `StringBuilder` and Python developers reach for `"".join(...)`.

C# gives you four everyday tools for joining strings. The right choice depends on how many pieces you're combining and where the values come from:

- `+` and `+=` for one-off concatenation of a fixed set of values.
- *String interpolation* (`$"..."`) for readable templates that mix literal text and expressions.
- <xref:System.Text.StringBuilder> for loops and incremental building.
- <xref:System.String.Join*?displayProperty=nameWithType> for joining the elements of a collection with a separator.

For deeper coverage of `String.Format`, <xref:System.Linq.Enumerable.Aggregate*?displayProperty=nameWithType>, and allocation-free building with <xref:System.String.Create*?displayProperty=nameWithType>, see [String operations](../../../language-reference/builtin-types/string-operations.md).

## Combine values with `+` and `+=`

The `+` operator concatenates two strings into a new one; `+=` appends to an existing variable. Both are easy to read and the C# compiler folds adjacent literal concatenations at compile time:

:::code language="csharp" source="snippets/concatenate/Program.cs" id="PlusOperator":::

Reach for these operators when you're joining a handful of values. They produce a new string every time, so they aren't a good fit for loops.

## Build templates with string interpolation

When you mix literal text and values from variables or expressions, *string interpolation* keeps the intent obvious. Prefix the string with `$` and embed expressions in braces:

:::code language="csharp" source="snippets/concatenate/Program.cs" id="Interpolation":::

Interpolation supports format strings, alignment, and culture control. For a deeper walk-through, see [Tutorial: Learn string interpolation](../../tutorials/string-interpolation.md) and the [interpolated string](../../../language-reference/tokens/interpolated.md) reference.

## Accumulate text with `StringBuilder`

When you build a string piece-by-piece, especially inside a loop, use <xref:System.Text.StringBuilder>. It keeps a growable buffer so each append doesn't allocate a new string:

:::code language="csharp" source="snippets/concatenate/Program.cs" id="StringBuilder":::

Call <xref:System.Text.StringBuilder.ToString*?displayProperty=nameWithType> once at the end to produce the final string.

## Join the elements of a collection

When you already have an array or list of values, <xref:System.String.Join*?displayProperty=nameWithType> is the simplest option. Pass a separator and the collection:

:::code language="csharp" source="snippets/concatenate/Program.cs" id="Join":::

`string.Join` walks the collection once and allocates the final string directly, which is faster than building it up with `+=`.

## See also

- <xref:System.String?displayProperty=nameWithType>
- <xref:System.Text.StringBuilder?displayProperty=nameWithType>
- <xref:System.String.Join*?displayProperty=nameWithType>
- [Interpolated string token](../../../language-reference/tokens/interpolated.md)
- [Tutorial: Learn string interpolation](../../tutorials/string-interpolation.md)
- [String operations: pattern matching, performance, and span-based search](../../../language-reference/builtin-types/string-operations.md)
