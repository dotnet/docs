---
title: "Modify string contents in C#"
description: Learn how to produce a new C# string from an existing one with Replace, Trim, Remove, and Regex.Replace, and why every modification returns a new string.
ms.date: 05/28/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Modify string contents in C\#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** C# strings are immutable, like Java's `String` and Python's `str`, and unlike JavaScript strings only when you treat them as mutable buffers. Every method that "modifies" a string returns a new <xref:System.String> and leaves the original unchanged. If you store the result, assign it back to the variable.

Because <xref:System.String> instances are immutable, the methods in this article produce a new string and leave the original untouched. Choose a technique based on what you're trying to change:

- *Substitute known text*: <xref:System.String.Replace*?displayProperty=nameWithType>.
- *Clean up whitespace*: <xref:System.String.Trim*?displayProperty=nameWithType>, <xref:System.String.TrimStart*?displayProperty=nameWithType>, <xref:System.String.TrimEnd*?displayProperty=nameWithType>.
- *Cut out a span of characters*: <xref:System.String.IndexOf*?displayProperty=nameWithType> plus <xref:System.String.Remove*?displayProperty=nameWithType>.
- *Substitute a pattern*: <xref:System.Text.RegularExpressions.Regex.Replace*?displayProperty=nameWithType>.

For allocation-free construction with <xref:System.String.Create*?displayProperty=nameWithType>, see [String operations](../../../language-reference/builtin-types/string-operations.md).

## Replace known text

<xref:System.String.Replace*?displayProperty=nameWithType> substitutes every occurrence of a substring (or character) with another value. The original string isn't changed; capture the return value:

:::code language="csharp" source="snippets/modify/Program.cs" id="Replace":::

Use the `char` overload when you replace a single character. It avoids allocating a one-character string and is the most direct option.

## Trim leading and trailing whitespace

`Trim`, `TrimStart`, and `TrimEnd` return a copy of the string with whitespace removed from one or both ends:

:::code language="csharp" source="snippets/modify/Program.cs" id="Trim":::

Overloads accept an array of `char` values when you want to strip specific punctuation rather than whitespace.

## Remove a span of characters

To delete a range from the middle of a string, find the start position with <xref:System.String.IndexOf*?displayProperty=nameWithType> and pass it to <xref:System.String.Remove*?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/modify/Program.cs" id="Remove":::

Always check that `IndexOf` returned a non-negative value before you call `Remove`. A negative result means the substring isn't present.

## Substitute matches of a pattern

When the text you want to replace follows a pattern rather than a fixed value, use <xref:System.Text.RegularExpressions.Regex.Replace*?displayProperty=nameWithType>. The overload that takes a <xref:System.Text.RegularExpressions.MatchEvaluator> delegate lets you compute the replacement for each match. The following example replaces `the` (or `The`, ignoring case) followed by whitespace, preserving the original capitalization:

:::code language="csharp" source="snippets/modify/Program.cs" id="Regex":::

For a tour of regular-expression patterns and validation, see [String operations](../../../language-reference/builtin-types/string-operations.md) and [Regular expression language - quick reference](../../../../standard/base-types/regular-expression-language-quick-reference.md).

## See also

- <xref:System.String?displayProperty=nameWithType>
- <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>
- [.NET regular expressions](../../../../standard/base-types/regular-expressions.md)
- [String operations: pattern matching, performance, and span-based search](../../../language-reference/builtin-types/string-operations.md)
