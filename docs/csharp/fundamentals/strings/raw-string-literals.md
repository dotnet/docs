---
title: "Raw string literals in C#"
description: Use raw string literals to write strings that contain quotes, backslashes, or multiple lines without escape sequences.
ms.date: 05/08/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Raw string literals

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For the complete grammar, see the [language reference](../../language-reference/tokens/raw-string.md).
>
> **Coming from another language?** C# raw string literals fill the same role as Python's and Rust's `r"..."` strings, Java's text blocks (`"""..."""`), and the back-tick template strings in JavaScript, TypeScript, and Go. The C# syntax is closest to Java's text blocks, with extra rules for variable-length delimiters and interpolation.

A *raw string literal* is delimited by three or more double quotes. Inside the delimiters, every character is taken literally. Quotes and backslashes don't need escaping, and newlines are preserved as written. Use raw strings for any string that contains quotes, backslashes, or multiple lines: JSON, XML, SQL, regular expressions, file paths, and code samples.

> [!WARNING]
> A raw string literal makes SQL easier to read, but it doesn't make SQL safer. Never concatenate or interpolate user-supplied values into a SQL command. That practice opens your application to SQL injection. Use parameterized commands instead: <xref:System.Data.Common.DbCommand.CreateParameter*?displayProperty=nameWithType> with <xref:System.Data.Common.DbParameterCollection.Add*?displayProperty=nameWithType>, or the higher-level helpers in [Entity Framework Core](/ef/core/querying/raw-sql) and [Dapper](https://github.com/DapperLib/Dapper). The same caution applies to other injection-prone formats such as shell commands, LDAP filters, and HTML.

## A literal that contains quotes and backslashes

A regular literal needs escapes for `"` and `\`. A verbatim literal still needs `""` to embed a quote. A raw literal needs neither:

:::code language="csharp" source="snippets/raw-string-literals/Program.cs" ID="EscapeContrast":::

Each form produces the same string, but the raw version reads exactly like the JSON it represents.

## Single-line raw strings

The opening and closing delimiters are each at least three double quotes, and the closing delimiter must use the same number of quotes as the opening delimiter. The content sits between them on the same line. Quotes and backslashes inside the content are literal:

:::code language="csharp" source="snippets/raw-string-literals/Program.cs" ID="SingleLine":::

A single-line raw string can't be empty between its delimiters. It can end with a double quote, but it can't start with one. The compiler treats a leading double quote as an additional opening delimiter character. If your content must start with a quote, use a multiline raw string literal instead, which places the content on its own line where a leading quote is unambiguous.

## Multiline raw strings

For multiline content, the opening delimiter ends the line and the closing delimiter starts its own. As with single-line raw strings, the delimiter is three or more double quotes, and the closing delimiter must use the same number of quotes as the opening one. Three quotes is the common case, but you can use four, five, or more when the content itself contains a run of `"""` (see [Content that contains `"""`](#content-that-contains-)). Everything between the two delimiters is the value of the string, exactly as written:

:::code language="csharp" source="snippets/raw-string-literals/Program.cs" ID="Multiline":::

The newline immediately after the opening `"""` and the newline immediately before the closing `"""` aren't part of the value. They're delimiter whitespace. Likewise, the compiler strips any whitespace to the left of the closing `"""` from every content line, so you can indent the literal to match its enclosing code block without that indentation appearing in the string. The next section covers this rule in detail.

## Indentation: the closing delimiter sets the margin

The column of the closing `"""` defines a left margin. The compiler strips whitespace up to that column from every content line. This rule lets you indent the literal to match the surrounding code without polluting the value:

:::code language="csharp" source="snippets/raw-string-literals/Program.cs" ID="Indentation":::

If a content line has fewer leading whitespace characters than the closing delimiter's column, the compiler reports an error. Keep all content lines indented at least as much as the closing `"""`.

## Content that contains `"""`

When the content itself contains a run of three or more quotes, increase the delimiter count. Use four or more quotes at the opening and closing. The delimiter count just has to exceed the longest run of quotes anywhere in the content:

:::code language="csharp" source="snippets/raw-string-literals/Program.cs" ID="MoreQuotes":::

You can scale this up to any number of quotes. Five-quote and six-quote delimiters work the same way.

## Raw interpolated strings

Add a `$` prefix to a raw string to enable interpolation. The expressions in `{}` holes are evaluated, and their results are inserted into the value:

:::code language="csharp" source="snippets/raw-string-literals/Program.cs" ID="RawInterpolated":::

If the content also needs literal `{` or `}` characters, which are common when generating JSON, CSS, or code, add more `$` signs. Each `$` raises the number of braces required to mark an interpolation hole. With `$$`, single `{` and `}` are literal and only `{{...}}` is treated as a hole:

:::code language="csharp" source="snippets/raw-string-literals/Program.cs" ID="DoubleDollarInterpolation":::

Use any number of `$` signs to disambiguate brace runs. Triple-`$` literals are rare but available.

## When to choose which literal

Use a **raw string literal** whenever the content contains quotes, backslashes, or multiple lines. The result is shorter to read, easier to paste in or out of, and free of escape-sequence bugs.

Use a **regular string literal** for short, single-line values without quotes or backslashes such as names, messages, format placeholders.

Use a **verbatim string literal** (`@"..."`) only when working with existing code that uses them. For new code, raw strings cover every case that verbatim strings cover, with cleaner syntax for embedded quotes.

## See also

- [Strings overview](index.md)
- [`nameof` operator](nameof.md)
- [Raw string literals (language reference)](../../language-reference/tokens/raw-string.md)
- <xref:System.String>
