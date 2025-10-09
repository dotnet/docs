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

There are a few *errors* related to declaring string constants or string literals.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS1009**](#string-literal-errors): *Unrecognized escape sequence.*
- [**CS1010**](#string-literal-errors): *Newline in constant.*
- [**CS1011**](#string-literal-errors): *Empty character literal.*
- [**CS1012**](#string-literal-errors): *Too many characters in character literal.*
- [**CS1039**](#string-literal-errors): *Unterminated string literal.*
- [**CS8997**](#raw-string-literal-errors): *Unterminated raw string literal.*
- [**CS8998**](#raw-string-literal-errors): *Not enough starting quotes for this raw string content.*
- [**CS8999**](#raw-string-literal-errors): *Line does not start with the same whitespace as the closing line of the raw string literal.*
- [**CS9000**](#raw-string-literal-errors): *Raw string literal delimiter must be on its own line.*
- [**CS9001**](#raw-string-literal-errors): *Multi-line raw string literals are only allowed in verbatim interpolated strings.*
- [**CS9002**](#raw-string-literal-errors): *Multi-line raw string literals must contain at least one line of content.*
- [**CS9003**](#raw-string-literal-errors): *Line contains different whitespace than expected.*
- [**CS9004**](#raw-string-literal-errors): *Not enough quotes for raw string literal.*
- [**CS9005**](#raw-string-literal-errors): *Not enough closing braces for interpolated raw string literal.*
- [**CS9006**](#raw-string-literal-errors): *Too many opening braces for interpolated raw string literal.*
- [**CS9007**](#raw-string-literal-errors): *Too many closing braces for interpolated raw string literal.*
- [**CS9008**](#raw-string-literal-errors): *Sequence of '@' characters is not allowed.*
- [**CS9009**](#raw-string-literal-errors): *String must start with quote character.*
- [**CS9274**](#literal-strings-in-data-sections): *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- [**CS9315**](#literal-strings-in-data-sections): *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*

## Literal strings in data sections

- **CS9274**: *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- **CS9315**: *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*

**CS9274** indicate that your declaration can't be emitted in the data section. Turn this feature off for your application. Debugging tools emit **CS9315** when the you've changed string data in the data section and your app must be restarted.

## String literal errors

The following errors concern string and character literal syntax and common mistakes when declaring literal values. They are grouped here so you can review related diagnostics together.

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

See the articles on [verbatim strings](../tokens/verbatim.md) and [raw strings](../tokens/raw-string.md) for more guidance on literal strings and escape sequences.

## Raw string literal errors

The following errors are related to raw string literal syntax and usage. They are listed here so readers can see the family of diagnostics together and learn about common causes and fixes.

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
- **CS9008** - *Sequence of '`@`' characters is not allowed.*
- **CS9009** - *String must start with quote character.*

Check these common causes and fixes:

- Unterminated or mismatched delimiters: Ensure your raw string starts and ends with the same number of consecutive double quotes (`"`). For multi-line raw strings, the opening and closing delimiter lines must appear on their own lines.
- Indentation and whitespace mismatch: The indentation of the closing delimiter defines the trimming of common leading whitespace for content lines. Make sure content lines align with that indentation.
- Insufficient quote or `$` counts for content: If the content begins with runs of quote characters or brace characters, increase the length of the delimiter (more `"`) or the number of leading `$` characters for interpolated raw strings so content can't be confused with delimiters or interpolation.
- Illegal characters or sequences: Avoid multiple `@` characters for verbatim/raw combinations and ensure you use verbatim interpolated forms when combining interpolation with multi-line raw strings.

The following shows a few examples of incorrectly formed raw string literals.

```csharp
// Unterminated raw string (CS8997)
var s = """This raw string never ends...

// Delimiter must be on its own line (CS9000)
var t = """First line"""More text""";

// Use more quotes when content contains quote runs (CS8998 / CS9004)
var u = """""content with """ quotes"""""; // use 5 quotes to allow 3 consecutive quotes in content
```

For full syntax and more examples, see the [language reference on raw string literals](../tokens/raw-string.md).
