---
title: "Strings in C#"
description: Learn how strings work in C# — declaration, immutability, literals (regular, verbatim, raw, interpolated), UTF-8 literals, and indexing.
ms.date: 05/08/2026
ms.topic: overview
ai-usage: ai-assisted
---

# C# strings

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from Java or C++?** A C# `string` is an immutable reference type backed by <xref:System.String?>. UTF-16 is the in-memory encoding, similar to Java's `String`. Unlike C/C++, strings aren't null-terminated and don't decay into pointers.

A *string* is a sequence of characters. In C#, `string` is the language keyword for the <xref:System.String?displayProperty=fullName> type. Every string literal you write produces a `System.String` instance.

## `string` vs. `String`

The `string` keyword and the `String` type name refer to the same type. They compile to identical intermediate language (IL).

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="StringKeyword":::

Prefer the `string` keyword in your own code. It's consistent with the other built-in type keywords (`int`, `bool`, `double`), and it works without a `using System;` directive. Reserve `String` for places where you need to call static members and want the type name visible (for example, `String.IsNullOrEmpty(value)` reads slightly more clearly than `string.IsNullOrEmpty(value)` to some teams — both compile identically).

## Strings are immutable

*Immutable* means the value can't be changed after it's created. Once you create a `string`, you can't change its characters. Methods such as `ToUpperInvariant`, `Replace`, `Substring`, and `Trim` return a *new* string that contains the modified value. The original instance stays the same.

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Immutability":::

Because strings are immutable, you can safely share them across methods and threads. This immutability explains why the `string` type behaves like a value type in everyday use even though it's a reference type.

When you build a string from many small pieces in a loop, each `+` or `Concat` call creates a new instance. A better choice is to use <xref:System.Text.StringBuilder>, which appends in place and produces a single string at the end:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="StringBuilder":::

For a small, fixed number of pieces, plain interpolation or `string.Concat` is clearer and just as fast.

## String literals

C# offers four literal forms. Each form suits different content. As a quick guide:

- Use **regular literals** for short, simple text with at most a few escape sequences.
- Use **verbatim literals** when backslashes dominate the content, such as Windows paths or regex patterns.
- Use **raw string literals** for multiline or structurally formatted text, such as inline JSON, SQL, XML, or formatted message blocks.
- Add a `$` prefix to any of the aforementioned literals to get an **interpolated string** when you need to embed values.

### Regular literals and escape sequences

A regular string literal is enclosed in double quotes. Backslash starts an escape sequence:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Escapes":::

Common escape sequences include `\n` (newline), `\t` (tab), `\"` (literal quote), `\\` (literal backslash), `\0` (null char), and Unicode escapes (`\uXXXX`, `\UXXXXXXXX`).

Beginning in C# 13, `\e` represents the **ESC** control character (U+001B). It's the start byte for ANSI terminal escape sequences:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="EscEscape":::

Use a regular literal when the text is short and contains only a handful of escape sequences. Once the escapes start to outnumber the visible characters, switch to a verbatim or raw literal.

### Verbatim literals

A verbatim literal is prefixed with `@`. Backslashes are treated literally, which is useful for Windows paths and regular-expression patterns:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Verbatim":::

To embed a literal quote inside a verbatim string, double it: `@"She said ""hi""."`. Verbatim strings can also span multiple physical lines.

Verbatim literals are the right choice when backslashes are part of the content but you don't have many embedded quotes. For multiline text or content with quotes, raw string literals are usually clearer.

### Raw string literals

For any literal that contains quotes, backslashes, or multiple lines, prefer **raw string literals**. They eliminate escape noise entirely, which makes them the best fit for inline JSON, SQL, XML, regex patterns, and formatted text blocks where the source should look like the output:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Raw":::

Raw string literals all but eliminate escape sequences and accommodate any formatting and quoting you need. See [Raw string literals](raw-string-literals.md) for the full rules.

### Interpolated strings

A `$` prefix turns a literal into an *interpolated string*. Expressions in `{}` holes are evaluated and their results inserted, and you can apply standard format specifiers and alignment inside the holes. Interpolation also combines with the other literal forms — use `$@"..."` to interpolate a verbatim literal, or `$"""..."""` to interpolate a raw string literal for richly formatted output:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Interpolated":::

Interpolation is the recommended way to compose strings from values in everyday code.

## UTF-8 string literals

A `u8` suffix produces a <xref:System.ReadOnlySpan`1> of UTF-8 bytes instead of a `string`. UTF-8 literals are useful for HTTP, network protocols, file formats, and other byte-oriented APIs that don't need a UTF-16 `string` at all:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Utf8Literal":::

The bytes are emitted at compile time, so there's no runtime encoding cost.

## Indexing and `char`

A `string` is a sequence of UTF-16 *code units*. The indexer returns one <xref:System.Char?displayProperty=fullName>, which represents a single UTF-16 code unit, not necessarily a complete Unicode code point. `Length` returns the count of code units.

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Indexing":::

For text that might contain emoji or characters outside the Basic Multilingual Plane, iterate by *rune* using <xref:System.Text.Rune> or by grapheme cluster using <xref:System.Globalization.StringInfo>. Plain `char` iteration works for most Western text and ASCII-dominant content.

## String equality

Equality on `string` compares the character sequences, not references:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="EqualityIntro":::

For comparisons that need to be locale-aware or case-aware, pass an explicit <xref:System.StringComparison> value. Use `StringComparison.Ordinal` for protocol values, identifiers, and other non-linguistic text.

## Common string operations

Use the following table as a quick guide to everyday string operations in C#:

| Category    | What it covers                                              |
|-------------|-------------------------------------------------------------|
| Search      | Find characters or substrings, test prefixes and suffixes   |
| Split       | Break a string into substrings on separators                |
| Concatenate | Combine strings — `+`, interpolation, `Concat`, `Join`      |
| Modify      | Produce a transformed copy — `Replace`, `Trim`, `Substring` |
| Compare     | Test equality and ordering with the right `StringComparison`|

The full API surface — every overload, every method — is documented in the <xref:System.String> reference.

## See also

- [Raw string literals](raw-string-literals.md)
- [`nameof` operator](nameof.md)
- <xref:System.String>
- <xref:System.Text.StringBuilder>
- <xref:System.Char>
- <xref:System.ReadOnlySpan%601>
