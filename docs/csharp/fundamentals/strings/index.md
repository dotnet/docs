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
> **Coming from Java or C++?** A C# `string` is an immutable reference type backed by <xref:System.String>. UTF-16 is the in-memory encoding, similar to Java's `String`. Unlike C/C++, strings aren't null-terminated and don't decay into pointers.

A *string* is a sequence of characters. In C#, `string` is the language keyword for the <xref:System.String> type. Every string literal you write produces a `System.String` instance.

## `string` vs. `String`

The `string` keyword and the `String` type name refer to the same type. They compile to identical IL.

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="StringKeyword":::

Prefer the `string` keyword in your own code. It's consistent with the other built-in type keywords (`int`, `bool`, `double`), and it works without a `using System;` directive. Reserve `String` for places where you need to call static members and want the type name visible (for example, `String.IsNullOrEmpty(value)` reads slightly more clearly than `string.IsNullOrEmpty(value)` to some teams — both compile identically).

## Strings are immutable

Once a `string` is created, its characters never change. Methods such as `ToUpperInvariant`, `Replace`, `Substring`, and `Trim` return a *new* string. The original instance is unchanged.

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Immutability":::

Immutability makes strings safe to share across methods and threads, and it's why the `string` type behaves like a value in everyday use even though it's a reference type.

When you build a string from many small pieces in a loop, each `+` or `Concat` call allocates a new instance. For that scenario, use <xref:System.Text.StringBuilder>, which appends in place and produces a single string at the end:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="StringBuilder":::

For a small fixed number of pieces, plain interpolation or `string.Concat` is clearer and just as fast.

## String literals

C# offers four literal forms. Each is suited to different content.

### Regular literals and escape sequences

A regular string literal is enclosed in double quotes. Backslash starts an escape sequence:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Escapes":::

Common escape sequences include `\n` (newline), `\t` (tab), `\"` (literal quote), `\\` (literal backslash), `\0` (null char), and Unicode escapes (`\uXXXX`, `\UXXXXXXXX`).

Beginning in C# 13, `\e` represents the **ESC** control character (U+001B). It's the start byte for ANSI terminal escape sequences:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="EscEscape":::

### Verbatim literals

A verbatim literal is prefixed with `@`. Backslashes are treated literally, which is useful for Windows paths and regular-expression patterns:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Verbatim":::

To embed a literal quote inside a verbatim string, double it: `@"She said ""hi""."`. Verbatim strings can also span multiple physical lines.

### Raw string literals

For any literal that contains quotes, backslashes, or multiple lines, prefer **raw string literals**. They eliminate escape noise entirely. See [Raw string literals](raw-string-literals.md) for the full rules.

### Interpolated strings

A `$` prefix turns a literal into an *interpolated string*. Expressions in `{}` holes are evaluated and their results inserted: `$"hello, {name}"`. Interpolation is the recommended way to compose strings from values in everyday code, and it works with raw string literals too — `$"""..."""`.

## UTF-8 string literals

A `u8` suffix produces a <xref:System.ReadOnlySpan%601> of UTF-8 bytes instead of a `string`. UTF-8 literals are useful for HTTP, network protocols, file formats, and other byte-oriented APIs that don't need a UTF-16 `string` at all:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Utf8Literal":::

The bytes are emitted at compile time, so there's no runtime encoding cost.

## Indexing and `char`

A `string` is a sequence of UTF-16 *code units*. The indexer returns one <xref:System.Char>, which represents a single UTF-16 code unit, not necessarily a complete Unicode code point. `Length` returns the count of code units.

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="Indexing":::

For text that may contain emoji or characters outside the Basic Multilingual Plane, iterate by *rune* using <xref:System.Text.Rune> or by grapheme cluster using <xref:System.Globalization.StringInfo>. Plain `char` iteration works for most Western text and ASCII-dominant content.

## String equality

Equality on `string` compares the character sequences, not references:

:::code language="csharp" source="snippets/strings-overview/Program.cs" ID="EqualityIntro":::

For comparisons that need to be locale- or case-aware, pass an explicit <xref:System.StringComparison> value. Use `StringComparison.Ordinal` for protocol values, identifiers, and other non-linguistic text.

## Common string operations

The articles in this section cover the everyday operations on strings:

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
