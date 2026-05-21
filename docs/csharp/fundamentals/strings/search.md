---
title: "Search strings in C#"
description: Learn how to find text within strings in C# with the Contains, StartsWith, EndsWith, IndexOf, and LastIndexOf methods, and how to choose the right StringComparison.
ms.date: 05/21/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Search strings in C\#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** C# `string` methods such as `Contains`, `StartsWith`, and `IndexOf` parallel methods in Java's `String` and JavaScript's `String.prototype`. The key difference is that C# searches default to **ordinal, case-sensitive** comparison; for user-facing searches you might want to pass a <xref:System.StringComparison> value.

The <xref:System.String> class includes methods that answer two everyday questions:

- *Does this string contain that text?* — use <xref:System.String.Contains*>, <xref:System.String.StartsWith*>, or <xref:System.String.EndsWith*>.
- *Where does that text occur?* — use <xref:System.String.IndexOf*> or <xref:System.String.LastIndexOf*>.

For pattern matching (regular expressions), span-based search over `ReadOnlySpan<char>`, and performance considerations, see [String operations](../../language-reference/builtin-types/string-operations.md). For an in-depth treatment of culture-aware comparison, see [Best practices for comparing strings](../../../standard/base-types/best-practices-strings.md).

## Check whether a string contains text

Use `Contains`, `StartsWith`, or `EndsWith` to test for the presence of a substring:

:::code language="csharp" source="snippets/search/Program.cs" id="contains":::

These methods default to **case-sensitive, ordinal** comparison. To accept user input or to ignore case for display text, pass a <xref:System.StringComparison> value such as <xref:System.StringComparison.CurrentCultureIgnoreCase?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>.

When you search for a single character, use the `char` overload of `Contains`. It avoids allocating a one-character string and is more direct:

:::code language="csharp" source="snippets/search/Program.cs" id="ContainsChar":::

## Locate the position of text

`IndexOf` returns the zero-based index of the first occurrence of a substring (or character), and `LastIndexOf` returns the index of the last occurrence. Both return `-1` when the search text isn't present. Combine them to extract the text between two markers:

:::code language="csharp" source="snippets/search/Program.cs" id="IndexOf":::

When you need every occurrence rather than the first or last, iterate by passing the previous result plus one as the `startIndex` argument, or switch to a regular expression.

## Choose the right comparison

Most search overloads accept an optional <xref:System.StringComparison> value. Pick it based on the kind of data you're searching:

| Scenario                                                                | Recommended value                                               |
|-------------------------------------------------------------------------|-----------------------------------------------------------------|
| Identifiers, file paths, protocol tokens, anything machine-defined      | <xref:System.StringComparison.Ordinal>                          |
| Same as above, but you want case insensitivity                          | <xref:System.StringComparison.OrdinalIgnoreCase>                |
| User-visible text where the current locale's rules should apply         | <xref:System.StringComparison.CurrentCulture>                   |
| Same as above, ignoring case                                            | <xref:System.StringComparison.CurrentCultureIgnoreCase>         |
| Persisted data that must compare the same on every machine and culture  | <xref:System.StringComparison.InvariantCulture> (rarely needed) |

Ordinal comparison is the fastest option and the right default for anything that isn't natural-language text. Culture-aware comparison is significantly slower and can produce surprising results — for example, in some cultures the lowercase `i` doesn't match an uppercase `I` — so reserve it for searches that real users perform against real prose.

## See also

- [String operations: pattern matching, performance, and span-based search](../../language-reference/builtin-types/string-operations.md)
- [Best practices for comparing strings in .NET](../../../standard/base-types/best-practices-strings.md)
- [Comparing strings](../../../standard/base-types/comparing.md)
- <xref:System.String?displayProperty=nameWithType>
- <xref:System.StringComparison?displayProperty=nameWithType>
