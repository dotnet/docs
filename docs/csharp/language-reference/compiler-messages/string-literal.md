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

To fix these issues, try the following techniques:

- Use one of the standard escape sequences defined in the C# language specification, such as `\n` (newline), `\t` (tab), `\\` (backslash), or `\"` (double quote) (**CS1009**).
- Switch to verbatim strings (with `@`) or raw string literals to support multi-line content.
- Split string literals that span multiple source lines by ending each line with a closing quote and starting the next line with an opening quote, using the `+` operator to concatenate them (**CS1010**). Alternatively, use verbatim string literals or raw string literals, which allow newlines as part of the string content.
For more information, see [strings](../builtin-types/reference-types.md#string-literals), [verbatim strings](../tokens/verbatim.md), and [raw string literals](../tokens/raw-string.md).

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

To correct these errors, try the following techniques:

- Use regular string literals or verbatim string literals instead of raw string literals in preprocessor directives like `#if`, `#define`, or `#pragma` (**CS8996**). Preprocessor directives are evaluated before the lexical analysis that recognizes raw string literals, so raw string syntax isn't supported in these contexts.
- Complete your raw string literal by adding a closing delimiter that matches the opening delimiter (**CS8997**, **CS9004**). Raw string literals must start and end with the same number of consecutive double-quote characters (at least three: `"""`), which ensures the compiler can correctly identify where the string content ends.
- Place the opening and closing delimiters of multi-line raw string literals on their own lines, with no other content on those lines (**CS9000**). This requirement ensures consistent formatting and makes the boundaries of the raw string content clear, particularly when the string spans many lines.
- Add at least one line of content between the opening and closing delimiters of your multi-line raw string literal (**CS9002**). Multi-line raw strings are designed to contain text that spans multiple lines, so the delimiters must enclose actual content rather than appearing on consecutive lines.
- Adjust the indentation of your raw string content lines to match the indentation of the closing delimiter line (**CS8999**, **CS9003**). The compiler uses the closing delimiter's leading whitespace to determine how much whitespace to trim from each content line, so inconsistent indentation prevents proper whitespace removal and causes these errors.
- Increase the number of double-quote characters in your raw string delimiter to be greater than any consecutive run of quotes in the content (**CS8998**). This ensures the compiler can distinguish between quote characters that are part of the content and the closing delimiter sequence.
- For interpolated raw string literals, ensure the number of dollar signs (`$`) at the start matches the number of consecutive opening or closing braces you need in the content (**CS9005**, **CS9006**, **CS9007**). For example, use `$$"""` to allow single braces as content while still supporting interpolations with `{{` and `}}`.
- Use verbatim interpolated string format (`$@"..."`) when combining interpolation with multi-line strings (**CS9001**). Raw string literals support interpolation through the `$` prefix, but multi-line raw strings with interpolation require the verbatim format to correctly handle both features together.
- Start your raw string literal with quote characters only, without any `@` prefix (**CS9008**, **CS9009**). Raw string literals are a distinct syntax that doesn't use the `@` verbatim prefix, and attempting to combine `@` with raw string delimiters isn't valid syntax.

For more information, see [raw string literals](../tokens/raw-string.md).

## UTF-8 string literals

- **CS9026** - *The input string cannot be converted into the equivalent UTF-8 byte representation.*
- **CS9047** - *Operator cannot be applied to operands that are not UTF-8 byte representations.*

To fix these errors, try the following techniques:

- Remove characters or escape sequences that can't be encoded in UTF-8 from your `u8` string literal (**CS9026**). UTF-8 encoding supports the full Unicode character set but requires valid Unicode scalar values, so surrogate code points (values in the range U+D800 through U+DFFF) can't appear directly in UTF-8 strings because they're reserved for UTF-16 encoding pairs rather than standalone characters.
- Ensure both operands of the addition operator are UTF-8 string literals when concatenating UTF-8 strings (**CS9047**). The compiler provides special support for concatenating UTF-8 string literals (which produce `ReadOnlySpan<byte>` values), but mixing UTF-8 strings with regular strings or other types isn't supported because the resulting type would be ambiguous and the byte representations are incompatible.
For more information, see [UTF-8 string literals](../builtin-types/reference-types.md#utf-8-string-literals).

## Literal strings in data sections

- **CS9274**: *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- **CS9315**: *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*

To fix these issues, try the following techniques:

- Disable the experimental data section string literals feature for your application when you encounter a hash collision (**CS9274**). This error indicates that two different string literals produced the same XXHash128 value, which prevents the optimization from working correctly, so you should remove the feature flag that enables this experimental behavior.
- Restart your application after modifying string literals during a debugging session when the data section feature is enabled (**CS9315**). The hot reload infrastructure can't update string literals stored in the data section because they're embedded in a special format that can't be modified at runtime, so continuing execution with the old string values would produce incorrect behavior.
