---
title: Errors and warnings for string literal declarations
description: This article helps you diagnose and correct compiler errors and warnings when you declare string literals as constants or variables.
f1_keywords:
  - "CS1009"
  - "CS1011"
  - "CS1012"
  - "CS1039"
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
  - "CS9274"
  - "CS9315"
helpviewer_keywords:
  - "CS1009"
  - "CS1011"
  - "CS1012"
  - "CS1039"
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
  - "CS9274"
  - "CS9315"
ms.date: 10/09/2025
ai-usage: ai-assisted
---
# Errors and warnings for string literal declarations

There are several errors related to declaring string constants or string literals.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS1009**](#incorrectly-formed-string-literals): *Unrecognized escape sequence.*
- [**CS1010**](#incorrectly-formed-string-literals): *Newline in constant.*
- [**CS1011**](#incorrectly-formed-string-literals): *Empty character literal.*
- [**CS1012**](#incorrectly-formed-string-literals): *Too many characters in character literal.*
- [**CS1039**](#incorrectly-formed-string-literals): *Unterminated string literal.*
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
- [**CS9274**](#literal-strings-in-data-sections): *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- [**CS9315**](#literal-strings-in-data-sections): *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*

The following sections provide examples of common issues and how to fix them.

## Incorrectly formed string literals

The following errors concern string and character literal syntax and common mistakes when declaring literal values.

- **CS1009** - *Unrecognized escape sequence.*
- **CS1010** - *Newline in constant.*
- **CS1011** - *Empty character literal.*
- **CS1012** - *Too many characters in character literal.*
- **CS1039** - *Unterminated string literal.*

Common causes and fixes:

- Invalid escape sequences: An unexpected character follows a backslash (`\\`). Use valid escapes (`\\n`, `\\t`, `\\uXXXX`, `\\xX`) or use verbatim (`@"..."`) or raw string literals for content that includes backslashes.
- Empty or multi-character char literals: Character literals must contain exactly one UTF-16 code unit. Use a single character like `'x'` or a string / `System.Text.Rune` for characters outside the BMP.
- Unterminated strings: Ensure every string or verbatim string has a matching closing quote. For verbatim strings, the final `"` must be present; for normal strings ensure escaped quotes are balanced.
- A string literal spans multiple lines of C# source.

Examples

```csharp
// CS1009 - invalid escape
string a = "\\m";               // CS1009 - invalid escape \m

// Use verbatim strings or escape backslashes
string filename = "c:\\myFolder\\myFile.txt"; // escaped backslashes
string filenameVerbatim = @"c:\myFolder\myFile.txt"; // verbatim string

// CS1011 - empty character literal
// public char CharField = '';   // CS1011 - invalid: empty character literal

// CS1012 - too many characters in char literal
char a = 'xx';   // CS1012 - too many characters

// CS1039 - unterminated verbatim string
// string b = @"hello, world;   // CS1039 - missing closing quote
```

For more information on literal strings and escape sequences, see the articles on [verbatim strings](../tokens/verbatim.md) and [raw strings](../tokens/raw-string.md).

## Incorrectly formed raw string literals

The following errors are related to raw string literal syntax and usage.

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

Check these common causes and fixes:

- Unterminated or mismatched delimiters: Ensure your raw string starts and ends with the same number of consecutive double quotes (`"`). For multi-line raw strings, the opening and closing delimiter lines must appear on their own lines.
- Indentation and whitespace mismatch: The indentation of the closing delimiter defines the trimming of common leading whitespace for content lines. Make sure content lines align with that indentation.
- Insufficient quote or `$` counts for content: If the content begins with runs of quote characters or brace characters, increase the length of the delimiter (more `"`) or the number of leading `$` characters for interpolated raw strings so content can't be confused with delimiters or interpolation.
- Illegal characters or sequences: Avoid multiple `@` characters for verbatim/raw combinations and ensure you use verbatim interpolated forms when combining interpolation with multi-line raw strings.

The following code shows a few examples of incorrectly formed raw string literals.

```csharp
// Unterminated raw string (CS8997)
var s = """This raw string never ends...

// Delimiter must be on its own line (CS9000)
var t = """First line
           More text
          """;
```

For full syntax and more examples, see the [language reference on raw string literals](../tokens/raw-string.md).

## Literal strings in data sections

- **CS9274**: *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- **CS9315**: *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*

**CS9274** indicate that your declaration can't be emitted in the data section. Disable this feature for your application. Debugging tools emit **CS9315** after you changed string data in the data section while debugging and your app must be restarted.
