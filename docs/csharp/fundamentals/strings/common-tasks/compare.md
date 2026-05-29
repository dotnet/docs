---
title: "Compare strings in C#"
description: Learn how to compare strings in C# for equality and order, when ordinal beats culture-aware comparison, and how to sort collections of strings.
ms.date: 05/28/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Compare strings in C\#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** C# `==` on strings is *value* equality, like Java's `String.equals` or JavaScript's `===`, not Java-style reference comparison. The catch is the comparison rules: `==` and <xref:System.String.Equals*?displayProperty=nameWithType> default to **ordinal** (byte-for-byte), while <xref:System.String.Compare*?displayProperty=nameWithType> defaults to **current culture**. Python developers used to `==` returning a single answer should pass a <xref:System.StringComparison> value whenever case or locale matters.

A string comparison answers one of two questions:

- *Are these two strings equivalent?* — use <xref:System.String.Equals*?displayProperty=nameWithType> or the `==` operator.
- *Which one comes first when sorted?* — use <xref:System.String.CompareTo*?displayProperty=nameWithType>, <xref:System.String.Compare*?displayProperty=nameWithType>, or a <xref:System.StringComparer?displayProperty=nameWithType>.

Both questions accept a <xref:System.StringComparison> argument that controls case sensitivity and whether the comparison uses ordinal or culture-aware rules. Pick the right value and most surprises go away. For an in-depth treatment of culture-aware comparison and globalization concerns, see [String operations](../../../language-reference/builtin-types/string-operations.md) and [Best practices for comparing strings](../../../../standard/base-types/best-practices-strings.md).

## Default equality is ordinal, case-sensitive

`==` and the parameterless <xref:System.String.Equals(System.String)?displayProperty=nameWithType> compare strings byte-for-byte. Two strings that differ only in case aren't equal:

:::code language="csharp" source="snippets/compare/Program.cs" id="EqualsDefault":::

This default is right for identifiers, file paths, protocol tokens, and anything else that the program (not a human) defines.

## Ignore case with an `OrdinalIgnoreCase` comparison

To compare without regard to case, pass <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> to the <xref:System.String.Equals(System.String,System.StringComparison)?displayProperty=nameWithType> overload or to <xref:System.String.Compare(System.String,System.String,System.StringComparison)?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/compare/Program.cs" id="IgnoreCase":::

`Compare` returns 0 for equal, a negative integer when the first argument sorts first, and a positive integer when it sorts after.

## Pick a `StringComparison` value

Different categories of text deserve different comparison rules. Use this guide:

| What you're comparing                                | Use                                                                                |
| ---------------------------------------------------- | ---------------------------------------------------------------------------------- |
| Paths, identifiers, URLs, protocol tokens            | <xref:System.StringComparison.Ordinal?displayProperty=nameWithType>                |
| The same data, but case-insensitive                  | <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>      |
| Text shown to the user                               | <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>         |
| Text shown to the user, case-insensitive             | <xref:System.StringComparison.CurrentCultureIgnoreCase?displayProperty=nameWithType> |
| Persisted data that must compare the same everywhere | <xref:System.StringComparison.InvariantCulture?displayProperty=nameWithType>       |

Ordinal comparison is the fastest and most predictable choice; culture-aware comparison applies locale-specific rules that vary by machine and platform. The following example shows the two flavors side by side:

:::code language="csharp" source="snippets/compare/Program.cs" id="ComparePicker":::

## Sort a collection of strings

Collections such as <xref:System.Array> and <xref:System.Collections.Generic.List%601> accept a <xref:System.StringComparer> when you sort or search them. For machine-defined data, use <xref:System.StringComparer.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparer.OrdinalIgnoreCase?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/compare/Program.cs" id="SortCollection":::

Always use the same comparer for sorting and searching the same collection. Mixing them produces unpredictable results. For culture-sensitive sorting and the differences between linguistic and ordinal order, see [String operations](../../../language-reference/builtin-types/string-operations.md).

## See also

- <xref:System.String?displayProperty=nameWithType>
- <xref:System.StringComparison?displayProperty=nameWithType>
- <xref:System.StringComparer?displayProperty=nameWithType>
- [Best practices for comparing strings in .NET](../../../../standard/base-types/best-practices-strings.md)
- [String operations: pattern matching, performance, and span-based search](../../../language-reference/builtin-types/string-operations.md)
