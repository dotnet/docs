---
title: Strings
description: Learn how the F# 'string' type represents immutable text as a sequence of Unicode characters.
ms.date: 08/15/2020
---
# Strings

The `string` type represents immutable text as a sequence of Unicode characters. `string` is an alias for `System.String` in .NET.

## Remarks

String literals are delimited by the quotation mark (") character. The backslash character ( \\ ) is used to encode certain special characters. The backslash and the next character together are known as an *escape sequence*. Escape sequences supported in F# string literals are shown in the following table.

|Character|Escape sequence|
|---------|---------------|
|Alert|`\a`|
|Backspace|`\b`|
|Form feed|`\f`|
|Newline|`\n`|
|Carriage return|`\r`|
|Tab|`\t`|
|Vertical tab|`\v`|
|Backslash|`\\`|
|Quotation mark|`\"`|
|Apostrophe|`\'`|
|Unicode character|`\DDD` (where `D` indicates a decimal digit; range of 000 - 255; for example, `\231` = "ç")|
|Unicode character|`\xHH` (where `H` indicates a hexadecimal digit; range of 00 - FF; for example, `\xE7` = "ç")|
|Unicode character|`\uHHHH` (UTF-16) (where `H` indicates a hexadecimal digit; range of 0000 - FFFF;  for example, `\u00E7` = "ç")|
|Unicode character|`\U00HHHHHH` (UTF-32) (where `H` indicates a hexadecimal digit; range of 000000 - 10FFFF;  for example, `\U0001F47D` = "👽")|

> [!IMPORTANT]
> The `\DDD` escape sequence is decimal notation, not octal notation like in most other languages. Therefore, digits `8` and `9` are valid, and a sequence of `\032` represents a space (U+0020), whereas that same code point in octal notation would be `\040`.

> [!NOTE]
> Being constrained to a range of 0 - 255 (0xFF), the `\DDD` and `\x` escape sequences are effectively the [ISO-8859-1](https://en.wikipedia.org/wiki/ISO/IEC_8859-1#Code_page_layout) character set, since that matches the first 256 Unicode code points.

## Verbatim Strings

If preceded by the @ symbol, the literal is a verbatim string. This means that any escape sequences are ignored, except that two quotation mark characters are interpreted as one quotation mark character.

## Triple Quoted Strings

Additionally, a string may be enclosed by triple quotes. In this case, all escape sequences are ignored, including double quotation mark characters. To specify a string that contains an embedded quoted string, you can either use a verbatim string or a triple-quoted string. If you use a verbatim string, you  must specify two quotation mark characters to indicate a single quotation mark character. If you use a triple-quoted string, you can use the single quotation mark characters without them being parsed as the end of the string. This technique can be useful when you work with XML or other structures that include embedded quotation marks.

```fsharp
// Using a verbatim string
let xmlFragment1 = @"<book author=""Milton, John"" title=""Paradise Lost"">"

// Using a triple-quoted string
let xmlFragment2 = """<book author="Milton, John" title="Paradise Lost">"""
```

In code, strings that have line breaks are accepted and the line breaks are interpreted literally as newlines, unless a backslash character is the last character before the line break. Leading white space on the next line is ignored when the backslash character is used. The following code produces a string `str1` that has value `"abc\ndef"` and a string `str2` that has value `"abcdef"`.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1001.fs)]

## String Indexing and Slicing

You can access individual characters in a string by using array-like syntax, as follows.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1002.fs)]

The output is `b`.

Or you can extract substrings by using array slice syntax, as shown in the following code.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1003.fs)]

The output is as follows.

```console
abc
def
```

You can represent ASCII strings by arrays of unsigned bytes, type `byte[]`. You add the suffix `B` to a string literal to indicate that it is an ASCII string. ASCII string literals used with byte arrays support the same escape sequences as Unicode strings, except for the Unicode escape sequences.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1004.fs)]

## String Operators

The `+` operator can be used to concatenate strings, maintaining compatibility with the .NET Framework string handling features. The following example illustrates string concatenation.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1006.fs)]

## String Class

Because the string type in F# is actually a .NET Framework `System.String` type, all the `System.String` members are available. This includes the `+` operator, which is used to concatenate strings, the `Length` property, and the `Chars` property, which returns the string as an array of Unicode characters. For more information about strings, see `System.String`.

By using the `Chars` property of `System.String`, you can access the individual characters in a string by specifying an index, as is shown in the following code.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1005.fs)]

## String Module

Additional functionality for string handling is included in the `String` module in the `FSharp.Core` namespace. For more information, see [String Module](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-stringmodule.html).

## See also

- [Interpolated Strings](interpolated-strings.md)
- [F# Language Reference](index.md)
