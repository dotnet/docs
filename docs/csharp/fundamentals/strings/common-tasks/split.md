---
title: "Split strings into substrings in C#"
description: Learn how to split a C# string into substrings with String.Split, including how to use multiple separators, limit the substring count, and trim or remove entries.
ms.date: 05/21/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Split strings into substrings in C\#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** `string.Split` is C#'s counterpart to Java's `String.split` and JavaScript's `String.prototype.split`. Unlike those languages, C# returns an array (`string[]`), not a list, and the separator argument is a character or string, not a regular expression. For pattern-based splitting, see <xref:System.Text.RegularExpressions.Regex.Split*?displayProperty=nameWithType>.

The <xref:System.String.Split*?displayProperty=nameWithType> method breaks a string into an array of substrings using one or more separators. It's the simplest way to parse delimited text such as words, CSV-style values, or protocol tokens.

The method has many overloads, but they cover four independent decisions:

- **Separators**: one `char`, an array of `char`, one `string`, or an array of `string`.
- **Maximum result count**: cap the number of substrings returned.
- **Empty-entry handling**: keep empty substrings (the default) or drop them with <xref:System.StringSplitOptions.RemoveEmptyEntries?displayProperty=nameWithType>.
- **Whitespace handling**: trim leading and trailing whitespace from each entry with <xref:System.StringSplitOptions.TrimEntries?displayProperty=nameWithType>.

The rest of this article walks through the common combinations.

## Split a string into words

To split a phrase on whitespace, pass `' '` as the separator:

:::code language="csharp" source="snippets/split/Program.cs" id="SplitWords":::

Iterate the returned array with `for` to recover the position of each word:

:::code language="csharp" source="snippets/split/Program.cs" id="IndexWords":::

If the input contains runs of the separator character, `Split` produces empty entries, one for each "gap" between consecutive separators:

:::code language="csharp" source="snippets/split/Program.cs" id="RepeatedSeparators":::

Pass `StringSplitOptions.RemoveEmptyEntries` to drop those empty entries (shown later).

## Split on multiple separator characters

When more than one character can act as a separator, pass them as an array. The following example treats spaces, commas, periods, colons, and tabs all as word boundaries:

:::code language="csharp" source="snippets/split/Program.cs" id="MultiChar":::

Adjacent separators still produce empty entries:

:::code language="csharp" source="snippets/split/Program.cs" id="MultiCharGaps":::

## Split on multicharacter separators

To split on whole-word or multicharacter separators, pass an array of strings together with a <xref:System.StringSplitOptions> value:

:::code language="csharp" source="snippets/split/Program.cs" id="StringSeparators":::

## Limit how many substrings you get back

Pass a `count` argument to cap the number of results. The final entry holds everything that's left, including any remaining separators:

:::code language="csharp" source="snippets/split/Program.cs" id="LimitCount":::

This pattern is handy for `key=value` pairs and other formats where only the first separator is meaningful.

## Trim whitespace from each entry

`StringSplitOptions.TrimEntries` strips leading and trailing whitespace from every returned substring. You can combine it with `RemoveEmptyEntries` for typical CSV-style cleanup:

:::code language="csharp" source="snippets/split/Program.cs" id="TrimEntries":::

## Use regular expressions

`Split` works well for fixed character or string delimiters. For pattern-based splitting, use <xref:System.Text.RegularExpressions.Regex.Split*?displayProperty=nameWithType>. See [String operations](../../../language-reference/builtin-types/string-operations.md) for an introduction to regular expressions on strings.

## See also

- <xref:System.String.Split*?displayProperty=nameWithType>
- <xref:System.StringSplitOptions?displayProperty=nameWithType>
- [String operations: pattern matching, performance, and span-based search](../../../language-reference/builtin-types/string-operations.md)
- [Extract elements from a string](../../../../standard/base-types/divide-up-strings.md)
