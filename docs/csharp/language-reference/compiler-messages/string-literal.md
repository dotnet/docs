---
title: Errors and warnings for string literal declarations
description: This article helps you diagnose and correct compiler errors and warnings when you declare string literals as constants or variables.
f1_keywords:
  - "CS1009"
  - "CS1011"
  - "CS1012"
  - "CS1039"
  - "CS9274"
  - "CS9315"
helpviewer_keywords:
  - "CS1009"
  - "CS1011"
  - "CS1012"
  - "CS1039"
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
- [**CS9274**](#literal-strings-in-data-sections): *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- [**CS9315**](#literal-strings-in-data-sections): *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*
 - [**CS1009**](#cs1009-unrecognized-escape-sequence): *Unrecognized escape sequence.*
 - [**CS1011**](#cs1011-empty-character-literal): *Empty character literal.*
 - [**CS1012**](#cs1012-too-many-characters-in-character-literal): *Too many characters in character literal.*
 - [**CS1039**](#cs1039-unterminated-string-literal): *Unterminated string literal.*

## Literal strings in data sections

- **CS9274**: *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- **CS9315**: *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*

**CS9274** indicate that your declaration can't be emitted in the data section. Turn this feature off for your application. Debugging tools emit **CS9315** when the you've changed string data in the data section and your app must be restarted.

## CS1009 - Unrecognized escape sequence

**CS1009**: *Unrecognized escape sequence.*

An unexpected character follows a backslash (\\) in a [string](../builtin-types/reference-types.md#the-string-type) or character literal. The compiler expects one of the valid escape characters (for example `\\n`, `\\t`, `\\uXXXX`, `\\xX`).

Common causes:

- Typing an invalid escape such as `"\\m"`.
- Using a Windows file path without escaping backslashes (for example `"c:\\myFolder\\myFile.txt"`).
- Malformed Unicode or hex escapes (wrong number of hex digits, wrong case for `\\x`).

How to fix:

- Use a valid escape sequence (`"\\t"`, `"\\n"`, etc.).
- Escape the backslash (`"c:\\myFolder\\myFile.txt"`) or use a verbatim string literal (`@"c:\myFolder\myFile.txt"`).
- Make sure `\\u` uses exactly 4 hex digits and `\\U` uses exactly 8 hex digits when used in character literals or string literals.

Examples

```csharp
// CS1009 examples
string a = "\m";               // CS1009 - invalid escape \m
string filename = "c:\\myFolder\\myFile.txt"; // correct: escaped backslashes
string filenameVerbatim = @"c:\myFolder\myFile.txt"; // correct: verbatim string
char unicodeChar = '\u0061';    // correct: \u must have exactly 4 hex digits
char badUnicode = '\u061';      // CS1009 - too few hex digits
```

## CS1011 - Empty character literal


## CS1039 - Unterminated string literal

**CS1039**: *Unterminated string literal.*

The compiler detected an ill-formed string literal that does not have a terminating quotation mark. This commonly happens with verbatim string literals (`@"..."`) when the closing quote is missing.

How to fix:

- Add the missing closing quotation mark for the string literal.
- For verbatim strings, ensure the final `"` is present; for regular strings, ensure any escaped quotes are properly balanced.

Example

```csharp
// CS1039.cs
public class MyClass
{
  public static void Main()
  {
    string b = @"hello, world;   // CS1039 - missing closing quote
  }
}
```
**CS1011**: *Empty character literal.*

A `char` value was declared and initialized with an empty character literal. Character literals in C# must contain exactly one character; an empty pair of single quotes (`''`) is invalid.

Example

```csharp
// CS1011.cs
class Sample
{
  public char CharField = '';   // CS1011
}
```

## CS1012 - Too many characters in character literal

**CS1012**: *Too many characters in character literal.*

An attempt was made to initialize a [char](../builtin-types/char.md) with more than one character. Character literals must represent a single UTF-16 code unit. Common causes:

- Initializing a `char` with multiple characters, e.g. `char a = 'xx';`.
- Using Unicode escape sequences representing code points above the UTF-16 range (greater than 0xFFFF) in a single character literal, e.g. `char b = '\U00010000';`.

How to fix:

- Use a single character in the character literal: `char c = 'x';`.
- For characters outside the BMP (above 0xFFFF), use a string with surrogate pair handling or use `System.Text.Rune` in modern APIs instead of a single `char` literal.

Example

```csharp
// CS1012.cs
class Sample
{
  static void Main()
  {
    char a = 'xx';   // CS1012 - too many characters
    char b = '\U00010000';   // CS1012 - exceeds UTF-16 range (> 0xFFFF)

    char c = 'x';    // OK
    char d = '\u0061';   // OK - represents 'a' within UTF-16 range
    System.Console.WriteLine($"{c}, {d}");
  }
}
```
