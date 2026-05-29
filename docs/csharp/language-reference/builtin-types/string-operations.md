---
title: "String operations: pattern matching, performance, and span-based search"
description: "Learn how to apply regular-expression patterns to strings, search strings with ReadOnlySpan<char>, and pick the right StringComparison for performance."
ms.topic: reference
ms.date: 05/21/2026
ai-usage: ai-assisted
---

# String operations: pattern matching, performance, and span-based search

This article covers three string operations: regular-expression pattern matching with <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>, allocation-free search over <xref:System.ReadOnlySpan%601>, and choosing a <xref:System.StringComparison> value for correct, fast comparisons.

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

For machine-defined text, such as file names, URLs, HTTP headers, identifiers, configuration keys, pass <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> explicitly. Reserve culture-aware values for natural-language text shown to users. For comprehensive guidance, see [Best practices for comparing strings in .NET](../../../standard/base-types/best-practices-strings.md).

## Concatenate with `String.Format` and `Enumerable.Aggregate`

For most concatenation, `+`, string interpolation, <xref:System.Text.StringBuilder>, or <xref:System.String.Join*?displayProperty=nameWithType> is the right tool. <xref:System.String.Format*?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.Aggregate*?displayProperty=nameWithType> fill more specialized roles:

- Use `String.Format` when the **template lives somewhere else than the call site** — most often a resource file for localization, a logging template, or any case where the same composite-format string is reused with different arguments. Composite formatting with numbered placeholders (`"{0} {1}"`) lets you swap the format string without recompiling.
- Use `Enumerable.Aggregate` when the **separator or transformation depends on element position**, or when you're already inside a LINQ query and want a single string out. For a straight "join these values with a separator", `string.Join` is faster and clearer because it walks the sequence once and allocates the final string directly. `Aggregate` allocates an intermediate string on each step.

:::code language="csharp" source="snippets/string-operations/Program.cs" id="format":::

## Culture-sensitive comparison in depth

The basics of choosing a <xref:System.StringComparison> value are covered in [Compare strings](../../fundamentals/strings/common-tasks/compare.md). This section addresses three deeper concerns: the difference between linguistic and ordinal comparison, the .NET 5 switch from NLS to ICU, and the comparer abstractions you pass to collections.

### Linguistic comparison folds characters

Linguistic comparison applies the sort weights of a culture's collation table. Two strings that look different can compare equal — for example, the German Esszet `ß` (U+00DF) is treated as equivalent to `ss` under many cultures. Ordinal comparison treats them as the distinct Unicode code points they are:

:::code language="csharp" source="snippets/string-operations/Program.cs" id="culture-deep":::

The exact comparison results in that snippet depend on which globalization library .NET uses on the host. Before .NET 5, .NET on Windows used [National Language Support (NLS)](/windows/win32/intl/national-language-support); other operating systems used ICU. Starting in .NET 5, all platforms default to [International Components for Unicode (ICU)](https://icu.unicode.org/). ICU and NLS don't always agree on the small details — for example, ICU under the invariant culture treats `ß` and `ss` as distinct, while NLS treated them as equal. If your code relied on the old NLS behavior, opt back in with the [`System.Globalization.UseNls` AppContext switch](../../../core/runtime-config/globalization.md).

### `CompareInfo` and `StringComparer` for collections

<xref:System.Globalization.CompareInfo?displayProperty=nameWithType> is the underlying engine for culture-aware comparison. Pass <xref:System.Globalization.CompareOptions> flags such as <xref:System.Globalization.CompareOptions.IgnoreSymbols?displayProperty=nameWithType> or <xref:System.Globalization.CompareOptions.IgnoreKanaType?displayProperty=nameWithType> when a simple <xref:System.StringComparison> value doesn't capture the rule you need.

<xref:System.StringComparer?displayProperty=nameWithType> wraps a comparison choice into the <xref:System.Collections.Generic.IComparer%601> and <xref:System.Collections.Generic.IEqualityComparer%601> interfaces that collections accept. Pass <xref:System.StringComparer.Ordinal?displayProperty=nameWithType> to <xref:System.Array.Sort%2A?displayProperty=nameWithType> and <xref:System.Array.BinarySearch%2A?displayProperty=nameWithType> when you need a fast, deterministic order; pass <xref:System.StringComparer.CurrentCulture?displayProperty=nameWithType> when the values are user-visible text. Always use the **same** comparer for sorting and searching — a mismatched pair silently returns wrong results.

## Allocation-free construction with `String.Create`

Most ways of building a string allocate intermediate buffers: `+` allocates each result, <xref:System.Text.StringBuilder> grows a backing array, and <xref:System.String.Concat*?displayProperty=nameWithType> copies its inputs. <xref:System.String.Create%2A?displayProperty=nameWithType> avoids those copies. You ask for a string of a known length, supply a state value that the callback needs, and the runtime hands the callback a <xref:System.Span%601> over the final string's character buffer:

:::code language="csharp" source="snippets/string-operations/Program.cs" id="string-create":::

Use this method on a hot path where you know the exact length and want to write each character once. The `static` lambda keeps the callback allocation-free; the `state` parameter (`source` in the example) is the safe way to pass values in, because lambdas given to `string.Create` can't capture variables that would force a closure allocation.

## See also

- [Regular expression language — quick reference](../../../standard/base-types/regular-expression-language-quick-reference.md)
- [Best practices for comparing strings in .NET](../../../standard/base-types/best-practices-strings.md)
- [Search strings](../../fundamentals/strings/common-tasks/search.md)
- [Split strings into substrings](../../fundamentals/strings/common-tasks/split.md)
- [Concatenate strings](../../fundamentals/strings/common-tasks/concatenate.md)
- [Modify string contents](../../fundamentals/strings/common-tasks/modify.md)
- [Compare strings](../../fundamentals/strings/common-tasks/compare.md)
- <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>
- <xref:System.MemoryExtensions?displayProperty=nameWithType>
- <xref:System.StringComparison?displayProperty=nameWithType>
