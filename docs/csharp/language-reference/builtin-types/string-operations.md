---
title: "String operations: pattern matching, performance, and span-based search"
description: "Learn how to apply regular-expression patterns to strings, search strings with ReadOnlySpan<char>, and pick the right StringComparison for performance."
ms.topic: reference
ms.date: 05/21/2026
ai-usage: ai-assisted
---

# String operations: Pattern matching, performance, and span-based search

This article covers three string operations: regular-expression pattern matching with <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>, allocation-free search over <xref:System.ReadOnlySpan`1>, and choosing a <xref:System.StringComparison> value for correct, fast comparisons.

## Find specific text by using regular expressions

The <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class searches strings for patterns rather than fixed substrings. The static <xref:System.Text.RegularExpressions.Regex.IsMatch*?displayProperty=nameWithType> method takes the input string, a pattern, and optional <xref:System.Text.RegularExpressions.RegexOptions> flags.

The following example searches each sentence for the word *the* or *their*, case insensitive. The pattern `the(ir)?\s` matches `the` optionally followed by `ir`, then a whitespace character:

| Pattern  | Meaning                          |
|----------|----------------------------------|
| `the`    | match the literal text `the`     |
| `(ir)?`  | match 0 or 1 occurrence of `ir`  |
| `\s`     | match a whitespace character     |

:::code language="csharp" source="snippets/string-operations/Program.cs" id="RegexPattern":::

## Validate strings against a pattern

To check whether an entire input matches a shape, anchor the pattern with `^` and `$`. The following example validates that each string is a US-style telephone number: three digits, three digits, four digits, separated by dashes:

| Pattern | Meaning                                |
|---------|----------------------------------------|
| `^`     | match the beginning of the string      |
| `\d{3}` | match exactly three digit characters   |
| `-`     | match a literal `-` character          |
| `\d{4}` | match exactly four digit characters    |
| `$`     | match the end of the string            |

:::code language="csharp" source="snippets/string-operations/Program.cs" id="RegexValidate":::

For the full pattern syntax, see [Regular expression language - quick reference](../../../standard/base-types/regular-expression-language-quick-reference.md).

## Choose between `string` methods and regular expressions

`string` methods and `Regex` solve overlapping problems. Prefer `string` methods when the text you're searching for is a literal value, a known prefix or suffix, or a fixed delimiter. They're simpler to read and faster, because they don't pay the cost of compiling and executing a pattern. Reach for `Regex` when the search target is a *shape*, such as alternations, optional groups, repeated character classes, or anchored validation. As a rule of thumb, if you can write the search as one or two `string.Contains` / `StartsWith` / `IndexOf` calls, do so.

## Search using `ReadOnlySpan<char>`

When you parse large inputs or run a search on a hot path, the per-call allocations of `string.Substring` and `string.Split` can dominate. `ReadOnlySpan<char>` gives you a view over an existing string (or array, or stack buffer) without copying, and <xref:System.MemoryExtensions> provides span-based equivalents of the common `string` methods, including <xref:System.MemoryExtensions.IndexOf*>:

:::code language="csharp" source="snippets/string-operations/Program.cs" id="SpanSearch":::

Span-based search avoids allocations because the slices (`input[start..]`, `rest[..end]`) are simply windows over the original characters. The same approach scales to parsing key-value lists, headers, and other delimited text without ever calling `Substring`.

## Performance considerations for `StringComparison`

Most `string` instance methods have overloads that accept a <xref:System.StringComparison> value. Methods such as <xref:System.String.Equals(System.String)?displayProperty=nameWithType> default to **ordinal**, but <xref:System.String.Compare(System.String,System.String)?displayProperty=nameWithType> and <xref:System.String.IndexOf(System.String)?displayProperty=nameWithType> default to **current culture**. This difference matters in two ways:

- **Speed.** Ordinal comparison is a byte-for-byte test that runs in tight, vectorized loops. Culture-aware comparison consults a sort table, walks combining characters, and applies locale-specific rules. For the same input, it can be an order of magnitude slower.
- **Correctness.** Culture-aware comparison can fold characters that you don't expect (Turkish `i`/`I`, German `ß` to `ss`, ligatures). This behavior is right for sorting names a user sees but wrong for parsing identifiers, paths, or protocol tokens.

For machine-defined text, such as file names, URLs, HTTP headers, identifiers, and configuration keys, pass <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> explicitly. Reserve culture-aware values for natural-language text shown to users. For comprehensive guidance, see [Best practices for comparing strings in .NET](../../../standard/base-types/best-practices-strings.md).

## See also

- [Regular expression language — quick reference](../../../standard/base-types/regular-expression-language-quick-reference.md)
- [Best practices for comparing strings in .NET](../../../standard/base-types/best-practices-strings.md)
- [Search strings](../../fundamentals/strings/common-tasks/search.md)
- [Split strings into substrings](../../fundamentals/strings/common-tasks/split.md)
- <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>
- <xref:System.MemoryExtensions?displayProperty=nameWithType>
- <xref:System.StringComparison?displayProperty=nameWithType>
