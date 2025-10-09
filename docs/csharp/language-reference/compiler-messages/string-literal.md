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
- [**CS9274**](#literal-strings-in-data-sections): *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*
- [**CS9315**](#literal-strings-in-data-sections): *Combined length of user strings used by the program exceeds allowed limit. Adding a string literal requires restarting the application.*
 - [**CS1009**](#cs1009-unrecognized-escape-sequence): *Unrecognized escape sequence.*
 - [**CS1011**](#cs1011-empty-character-literal): *Empty character literal.*
 - [**CS1012**](#cs1012-too-many-characters-in-character-literal): *Too many characters in character literal.*
 - [**CS1039**](#cs1039-unterminated-string-literal): *Unterminated string literal.*
 - [**CS8997**](#cs8997-unterminated-raw-string-literal): *Unterminated raw string literal.*
 - [**CS9000**](#cs9000-raw-string-delimiter-placement): *Raw string literal delimiter must be on its own line.*
 - [**CS8998**](#cs8998-too-many-quotes-for-raw-string): *Not enough starting quotes for this raw string content.*
 - [**CS8999**](#cs8999-line-whitespace-mismatch): *Line does not start with the same whitespace as the closing line of the raw string literal.*
 - [**CS9001**](#cs9001-rawstring-in-verbatim-interpolated-strings): *Multi-line raw string literals are only allowed in verbatim interpolated strings.*
 - [**CS9002**](#cs9002-rawstring-must-contain-content): *Multi-line raw string literals must contain at least one line of content.*
 - [**CS9003**](#cs9003-line-contains-different-whitespace): *Line contains different whitespace than expected.*
 - [**CS9004**](#cs9004-not-enough-quotes-for-raw-string): *Not enough quotes for raw string literal.*
 - [**CS9005**](#cs9005-not-enough-close-braces-for-raw-string): *Not enough closing braces for interpolated raw string literal.*
 - [**CS9006**](#cs9006-too-many-open-braces-for-raw-string): *Too many opening braces for interpolated raw string literal.*
 - [**CS9007**](#cs9007-too-many-close-braces-for-raw-string): *Too many closing braces for interpolated raw string literal.*
 - [**CS9008**](#cs9008-illegal-at-sequence): *Sequence of '@' characters is not allowed.*
 - [**CS9009**](#cs9009-string-must-start-with-quote): *String must start with quote character.*
 - [**CS1010**](#cs1010-newline-in-constant): *Newline in constant.*

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

## CS8997 - Unterminated raw string literal

**CS8997**: *Unterminated raw string literal.*

The compiler detected a raw string literal that does not have a terminating delimiter sequence. Raw string literals in C# begin and end with a sequence of three or more double-quote characters (`"""`). Multi-line raw string literals require the opening and closing delimiter sequences to be on their own lines.

How to fix:

- Make sure the raw string literal has a matching closing delimiter sequence using the same number of consecutive `"` characters as the opening delimiter.
- For multi-line raw string literals, place the closing delimiter on its own line and outdent the content appropriately.

See the language reference on [raw string literals](../tokens/raw-string.md) for syntax and examples.

Example

```csharp
// CS8997.cs
class Sample
{
  void M()
  {
    var s = """This is a raw string literal
that never ends...   // CS8997 - unterminated raw string literal
  }
}
```

## CS9000 - Raw string literal delimiter must be on its own line

**CS9000**: *Raw string literal delimiter must be on its own line.*

This error occurs when the compiler finds an opening or closing raw string literal delimiter that isn't placed according to the multi-line raw string literal rules. In a multi-line raw string literal the opening and closing delimiter sequences must appear on lines by themselves; extra content on those lines can make the literal ill-formed.

How to fix:

- Move the opening or closing delimiter so it appears on a line by itself.
- Ensure that the number of quotes in the closing delimiter matches the number of quotes in the opening delimiter.

See the language reference on [raw string literals](../tokens/raw-string.md) for syntax and examples.

Example

```csharp
// CS9000.cs
class Sample
{
  void M()
  {
    var s = """Start of raw string"""More text"""; // CS9000 - delimiter must be on its own line
  }
}
```


## CS8998 - Not enough starting quotes for this raw string content

**CS8998**: *The raw string literal does not start with enough quote characters to allow this many consecutive quote characters as content.*

Raw string literals start with a sequence of three or more double-quote characters. If the content begins with additional consecutive quotes, the compiler requires you to use more starting quotes than the minimum so the ending delimiter can be distinguished from content.

How to fix:

- Increase the number of starting and ending quote characters so the delimiter sequence is longer than any same-length quote run in the content. For an example and detailed guidance, see the raw string literal reference: `../tokens/raw-string.md`.

## CS8999 - Line whitespace mismatch in raw string

**CS8999**: *Line does not start with the same whitespace as the closing line of the raw string literal.*

Multiline raw string literals determine the final content's indentation from the closing quote sequence. Every content line must align with that indentation rules; otherwise the compiler reports this diagnostic.

How to fix:

- Ensure every line of the raw string is indented so that the closing delimiter's leftmost column defines the indentation. See `../tokens/raw-string.md` for examples.

## CS9001 - Raw string literals only in verbatim interpolated strings

**CS9001**: *Multi-line raw string literals are only allowed in verbatim interpolated strings.*

This diagnostic appears when a multi-line raw string is used incorrectly with interpolation or verbatim markers.

How to fix:

- Use a verbatim interpolated form when combining raw multiline content with interpolation, or adjust your formatting to follow the raw string literal rules in `../tokens/raw-string.md`.

## CS9002 - Raw string must contain content

**CS9002**: *Multi-line raw string literals must contain at least one line of content.*

An empty raw string with only opening and closing delimiters on separate lines is not valid. Add at least one content line between the delimiters.

How to fix:

- Add content lines or use a single-line raw string format where applicable. See `../tokens/raw-string.md`.

## CS9003 - Line contains different whitespace

**CS9003**: *Line contains different whitespace than expected.*

This is a variant of indentation/whitespace mismatch errors for raw string literals.

How to fix:

- Align the whitespace of all lines in the literal with the closing delimiter's indentation.

## CS9004 - Not enough quotes for raw string literal

**CS9004**: *Not enough quotes for raw string literal.*

This message indicates the opening delimiter doesn't provide enough quote characters for the content; choose a longer opening delimiter.

How to fix:

- Increase the number of `"` characters in the opening and closing delimiters.

## CS9005 - Not enough closing braces for interpolated raw string

**CS9005**: *The interpolation must end with the same number of closing braces as the number of '$' characters that the raw string literal started with.*

When using interpolated raw strings, you prefix the literal with `$` characters to indicate interpolation nesting; the same number of closing braces is required to terminate each interpolation expression.

How to fix:

- Use the same number of closing braces as `$` characters used to start the interpolated raw string.

## CS9006 - Too many opening braces for interpolated raw string

**CS9006**: *The interpolated raw string literal does not start with enough '$' characters to allow this many consecutive opening braces as content.*

If your content contains many consecutive opening braces, the interpolated raw string must start with enough `$` characters to disambiguate them from interpolation delimiters.

How to fix:

- Increase the number of leading `$` characters on the raw string literal to match the maximum brace run in the content.

## CS9007 - Too many closing braces for interpolated raw string

**CS9007**: *The interpolated raw string literal does not start with enough '$' characters to allow this many consecutive closing braces as content.*

Similar to CS9006 but for consecutive closing braces.

How to fix:

- Increase the count of leading `$` characters to allow the content's closing-brace runs.

## CS9008 - Illegal '@' sequence

**CS9008**: *Sequence of '@' characters is not allowed. A verbatim string or identifier can only have one '@' character and a raw string cannot have any.*

The '@' character has special meaning for verbatim strings and identifiers; multiple '@' characters or '@' in raw strings are not valid.

How to fix:

- Remove extra '@' characters or use an alternative literal form.

## CS9009 - String must start with quote character

**CS9009**: *String must start with quote character: "* 

This diagnostic appears when a string-like token does not begin with a quote character.

How to fix:

- Ensure string literals begin with `"` (or the appropriate raw/verbatim delimiter).

## CS1010 - Newline in constant

**CS1010**: *Newline in constant.*

This diagnostic appears when a constant literal contains an unescaped newline (for example, trying to put an actual newline inside a non-verbatim string constant).

How to fix:

- Use verbatim or raw string literals for multi-line content, or escape newline sequences (`\n`) in normal string literals. See `../tokens/raw-string.md` and `../tokens/verbatim.md` for guidance.
