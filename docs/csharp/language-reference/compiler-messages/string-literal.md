---
title: Resolve errors and warnings for string literal declarations
description: Learn how to diagnose and correct C# compiler errors and warnings when you declare string literals, including basic strings, raw strings, and UTF-8 strings.
f1_keywords:
  - "CS1009"
  - "CS1011"
  - "CS1012"
  - "CS1039"
  - "CS8996"
  - "CS8997"
  - "CS8998"
  - "CS8999"
  - "CS9000"
  - "CS9001"
  - "CS9002"
  - "CS9003"
  - "CS9004"
  - "CS9005"
  - "CS9006"
  - "CS9007"
  - "CS9008"
  - "CS9009"
  - "CS1010"
  - "CS9026"
  - "CS9047"
  - "CS9274"
  - "CS9315"
helpviewer_keywords:
  - "CS1009"
  - "CS1011"
  - "CS1012"
  - "CS1039"
  - "CS8996"
  - "CS8997"
  - "CS8998"
  - "CS8999"
  - "CS9000"
  - "CS9001"
  - "CS9002"
  - "CS9003"
  - "CS9004"
  - "CS9005"
  - "CS9006"
  - "CS9007"
  - "CS9008"
  - "CS9009"
  - "CS1010"
  - "CS9026"
  - "CS9047"
  - "CS9274"
  - "CS9315"
ms.date: 12/08/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings for string literal declarations

The C# compiler generates errors and warnings when you declare string literals with incorrect syntax or use them in unsupported contexts. These diagnostics help you identify issues with basic string literals, character literals, raw string literals, and UTF-8 string literals.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS1009**](#incorrectly-formed-string-literals): *Unrecognized escape sequence.*
- [**CS1010**](#incorrectly-formed-string-literals): *Newline in constant.*
- [**CS1011**](#incorrectly-formed-string-literals): *Empty character literal.*
- [**CS1012**](#incorrectly-formed-string-literals): *Too many characters in character literal.*
- [**CS1039**](#incorrectly-formed-string-literals): *Unterminated string literal.*
- [**CS8996**](#incorrectly-formed-raw-string-literals): *Raw string literals are not allowed in preprocessor directives.*
- [**CS8997**](#incorrectly-formed-raw-string-literals): *Unterminated raw string literal.*
- [**CS8998**](#incorrectly-formed-raw-string-literals): *Not enough starting quotes for this raw string content.*
- [**CS8999**](#incorrectly-formed-raw-string-literals): *Line does not start with the same whitespace as the closing line of the raw string literal.*
- [**CS9000**](#incorrectly-formed-raw-string-literals): *Raw string literal delimiter must be on its own line.*
- [**CS9001**](#incorrectly-formed-raw-string-literals): *Multi-line raw string literals are only allowed in verbatim interpolated strings.*
- [**CS9002**](#incorrectly-formed-raw-string-literals): *Multi-line raw string literals must contain at least one line of content.*
- [**CS9003**](#incorrectly-formed-raw-string-literals): *Line contains different whitespace than expected.*
- [**CS9004**](#incorrectly-formed-raw-string-literals): *Not enough quotes for raw string literal.*
- [**CS9005**](#incorrectly-formed-raw-string-literals): *Not enough closing braces for interpolated raw string literal.*
- [**CS9006**](#incorrectly-formed-raw-string-literals): *Too many opening braces for interpolated raw string literal.*
- [**CS9007**](#incorrectly-formed-raw-string-literals): *Too many closing braces for interpolated raw string literal.*
- [**CS9008**](#incorrectly-formed-raw-string-literals): *Sequence of '@' characters is not allowed.*
- [**CS9009**](#incorrectly-formed-raw-string-literals): *String must start with quote character.*
- [**CS9026**](#utf-8-string-literals): *The input string cannot be converted into the equivalent UTF-8 byte representation.*
- [**CS9047**](#utf-8-string-literals): *Operator cannot be applied to operands that are not UTF-8 byte representations.*
- [**CS9274**](#literal-strings-in-data-sections): *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- [**CS9315**](#literal-strings-in-data-sections): *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*

## Incorrectly formed string literals

- **CS1009** - *Unrecognized escape sequence.*
- **CS1010** - *Newline in constant.*
- **CS1011** - *Empty character literal.*
- **CS1012** - *Too many characters in character literal.*
- **CS1039** - *Unterminated string literal.*

To correct these errors, apply the following techniques:

- Use one of the standard escape sequences defined in the [C# language specification](~/_csharpstandard/standard/lexical-structure.md#6457-character-escape-sequences), such as `\n` (newline), `\t` (tab), `\\` (backslash), or `\"` (double quote) (**CS1009**). The compiler doesn't recognize escape sequences that aren't part of the language specification, so using undefined escape sequences causes this error because the compiler can't determine what character you intended to represent.
- Add the closing quote character to complete your string literal (**CS1039**). String literals must have both an opening and closing delimiter, so an unterminated string causes the compiler to treat subsequent source code as part of the string content, which leads to parsing errors.
- Add exactly one character between the single quotes in your character literal (**CS1011**, **CS1012**). Character literals represent a single character value and must contain exactly one character or a valid escape sequence, so empty character literals or those containing multiple characters violate the language rules for the `char` type.
- Split string literals that span multiple source lines by ending each line with a closing quote and starting the next line with an opening quote, using the `+` operator to concatenate them (**CS1010**). Regular string literals can't contain actual newline characters because the closing quote must appear on the same line as the opening quote, but you can achieve multi-line strings through concatenation or by using [verbatim strings](../tokens/verbatim.md) or [raw string literals](../tokens/raw-string.md), which allow embedded newlines as part of the string content.

For more information, see [strings](../builtin-types/reference-types.md#string-literals).

## Incorrectly formed raw string literals

- **CS8996** - *Raw string literals are not allowed in preprocessor directives.*
- **CS8997** - *Unterminated raw string literal.*
- **CS8998** - *Not enough starting quotes for this raw string content.*
- **CS8999** - *Line does not start with the same whitespace as the closing line of the raw string literal.*
- **CS9000** - *Raw string literal delimiter must be on its own line.*
- **CS9001** - *Multi-line raw string literals are only allowed in verbatim interpolated strings.*
- **CS9002** - *Multi-line raw string literals must contain at least one line of content.*
- **CS9003** - *Line contains different whitespace than expected.*
- **CS9004** - *Not enough quotes for raw string literal.*
- **CS9005** - *Not enough closing braces for interpolated raw string literal.*
- **CS9006** - *Too many opening braces for interpolated raw string literal.*
- **CS9007** - *Too many closing braces for interpolated raw string literal.*
- **CS9008** - *Sequence of '@' characters is not allowed.*
- **CS9009** - *String must start with quote character.*

To correct these errors, apply the following techniques:

- Use regular string literals or [verbatim string literals](../tokens/verbatim.md) instead of raw string literals in preprocessor directives like `#if`, `#define`, or `#pragma` (**CS8996**). Preprocessor directives are evaluated during the preprocessing phase before lexical analysis occurs, so the compiler can't recognize raw string literal syntax in these contexts because raw strings are identified during the later lexical analysis phase.
- Add a closing delimiter that matches the opening delimiter to complete your raw string literal (**CS8997**, **CS9004**). The [raw string literal syntax](../tokens/raw-string.md) requires that the opening and closing delimiters contain the same number of consecutive double-quote characters (at least three), so a missing or mismatched closing delimiter prevents the compiler from determining where the string content ends.
- Place the opening and closing delimiters of multi-line raw string literals on their own lines, with no other content on those lines (**CS9000**). The [multi-line raw string format rules](../tokens/raw-string.md) require delimiters to occupy dedicated lines to establish clear boundaries for the string content and to enable the whitespace trimming behavior that removes common leading indentation from all content lines.
- Add at least one line of content between the opening and closing delimiters of your multi-line raw string literal (**CS9002**). The language specification requires multi-line raw strings to contain actual content because empty multi-line raw strings serve no purpose and likely indicate incomplete code, whereas single-line raw strings (with delimiters on the same line) can be empty and are the appropriate syntax for empty string values.
- Adjust the indentation of your raw string content lines to match or exceed the indentation of the closing delimiter line (**CS8999**, **CS9003**). The [whitespace handling rules](../tokens/raw-string.md) for raw string literals use the closing delimiter's leading whitespace as the baseline for trimming common indentation from all content lines, so content lines with less indentation than the closing delimiter violate this trimming algorithm and indicate incorrect formatting.
- Increase the number of double-quote characters in your raw string delimiter to exceed any consecutive run of quote characters in the content (**CS8998**). The delimiter must contain more consecutive quotes than any sequence within the string content so the compiler can unambiguously distinguish between quote characters that are part of the content and the delimiter sequence that marks the end of the string.
- For interpolated raw string literals, ensure the number of dollar signs (`$`) at the start matches the number of consecutive opening or closing braces you need as literal content (**CS9005**, **CS9006**, **CS9007**). The [interpolated raw string syntax](../tokens/raw-string.md#raw-string-literal-text----in-string-literals) uses the dollar sign count to determine the brace escape sequence length, so `$$"""` requires `{{` for interpolation holes and allows single `{` characters as content, while mismatched brace sequences indicate either incorrect interpolation syntax or content that needs a different dollar sign count.
- Remove the `@` prefix from your raw string literal and use only the quote character delimiter (**CS9008**, **CS9009**). Raw string literals are a distinct syntax introduced in C# 11 that doesn't use the `@` verbatim string prefix, and the language specification doesn't allow combining the `@` verbatim syntax with raw string delimiters because raw strings already support multi-line content and don't require escape sequences.

> [!NOTE]
> **CS9001** is no longer produced in current versions of C#. Multi-line raw string literals now support interpolation without requiring verbatim format.

For more information, see [raw string literals](../tokens/raw-string.md).

## UTF-8 string literals

- **CS9026** - *The input string cannot be converted into the equivalent UTF-8 byte representation.*
- **CS9047** - *Operator cannot be applied to operands that are not UTF-8 byte representations.*

To correct these errors, apply the following techniques:

- Remove characters or escape sequences that can't be encoded in UTF-8 from your `u8` string literal (**CS9026**). The [UTF-8 encoding specification](https://www.unicode.org/versions/Unicode15.0.0/ch03.pdf#G7404) supports the full Unicode character set but requires valid Unicode scalar values, so surrogate code points (values in the range U+D800 through U+DFFF) can't appear directly in UTF-8 strings because they're reserved for UTF-16 surrogate pair encoding rather than representing standalone characters, and attempting to encode them as UTF-8 would produce an invalid byte sequence.
- Ensure both operands of the addition operator are UTF-8 string literals (marked with the `u8` suffix) when concatenating UTF-8 strings (**CS9047**). The compiler provides special support for concatenating [UTF-8 string literals](../builtin-types/reference-types.md#utf-8-string-literals) at compile time, which produces `ReadOnlySpan<byte>` values representing the concatenated UTF-8 byte sequences, but mixing UTF-8 strings with regular `string` values or other types isn't supported because the type system can't determine whether to produce a byte span or a text string, and the underlying representations (UTF-8 bytes versus UTF-16 characters) are fundamentally incompatible.

For more information, see [UTF-8 string literals](../builtin-types/reference-types.md#utf-8-string-literals).

## Literal strings in data sections

- **CS9274**: *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- **CS9315**: *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*

To fix these issues, try the following techniques:

- Disable the experimental data section string literals feature for your application when you encounter a hash collision (**CS9274**). This error indicates that two different string literals produced the same XXHash128 value, which prevents the optimization from working correctly, so you should remove the feature flag that enables this experimental behavior.
- Restart your application after modifying string literals during a debugging session when the data section feature is enabled (**CS9315**). The hot reload infrastructure can't update string literals stored in the data section because they're embedded in a special format that can't be modified at runtime, so continuing execution with the old string values would produce incorrect behavior.
