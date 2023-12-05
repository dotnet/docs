---
title: "Strings - C# Programming Guide"
description: Learn about strings in C# programming. See information on declaring and initializing strings, the immutability of string objects, and string escape sequences.
ms.date: 04/15/2022
helpviewer_keywords:
  - "C# language, strings"
  - "strings [C#]"
ms.assetid: 21580405-cb25-4541-89d5-037846a38b07
---
# Strings and string literals

A string is an object of type <xref:System.String> whose value is text. Internally, the text is stored as a sequential read-only collection of <xref:System.Char> objects. There's no null-terminating character at the end of a C# string; therefore a C# string can contain any number of embedded null characters ('\0'). The <xref:System.String.Length%2A> property of a string represents the number of `Char` objects it contains, not the number of Unicode characters. To access the individual Unicode code points in a string, use the <xref:System.Globalization.StringInfo> object.

## string vs. System.String

In C#, the `string` keyword is an alias for <xref:System.String>; therefore, `String` and `string` are equivalent. It's recommended to use the provided alias `string` as it works even without `using System;`. The `String` class provides many methods for safely creating, manipulating, and comparing strings. In addition, the C# language overloads some operators to simplify common string operations. For more information about the keyword, see [string](../../language-reference/builtin-types/reference-types.md). For more information about the type and its methods, see <xref:System.String>.

## Declaring and initializing strings

You can declare and initialize strings in various ways, as shown in the following example:

:::code language="csharp" source="./snippets/Declarations.cs" id="StringDeclarations":::

You don't use the [new](../../language-reference/operators/new-operator.md) operator to create a string object except when initializing the string with an array of chars.

Initialize a string with the <xref:System.String.Empty> constant value to create a new <xref:System.String> object whose string is of zero length. The string literal representation of a zero-length string is "". By initializing strings with the <xref:System.String.Empty> value instead of [null](../../language-reference/keywords/null.md), you can reduce the chances of a <xref:System.NullReferenceException> occurring. Use the static <xref:System.String.IsNullOrEmpty%28System.String%29> method to verify the value of a string before you try to access it.

## Immutability of strings

String objects are *immutable*: they can't be changed after they've been created. All of the <xref:System.String> methods and C# operators that appear to modify a string actually return the results in a new string object. In the following example, when the contents of `s1` and `s2` are concatenated to form a single string, the two original strings are unmodified. The `+=` operator creates a new string that contains the combined contents. That new object is assigned to the variable `s1`, and the original object that was assigned to `s1` is released for garbage collection because no other variable holds a reference to it.

:::code language="csharp" source="./snippets/Declarations.cs" id="StringImmutability":::

Because a string "modification" is actually a new string creation, you must use caution when you create references to strings. If you create a reference to a string, and then "modify" the original string, the reference will continue to point to the original object instead of the new object that was created when the string was modified. The following code illustrates this behavior:

:::code language="csharp" source="./snippets/Declarations.cs" id="ModifyIsCopy":::

For more information about how to create new strings that are based on modifications such as search and replace operations on the original string, see [How to modify string contents](../../how-to/modify-string-contents.md).

## Quoted string literals

*Quoted string literals* start and end with a single double quote character (`"`) on the same line. Quoted string literals are best suited for strings that fit on a single line and don't include any [escape sequences](#string-escape-sequences). A quoted string literal must embed escape characters, as shown in the following example:

:::code language="csharp" source="./snippets/StringLiterals.cs" id="EscapeSequences":::

## Verbatim string literals

*Verbatim string literals* are more convenient for multi-line strings, strings that contain backslash characters, or embedded double quotes. Verbatim strings preserve new line characters as part of the string text. Use double quotation marks to embed a quotation mark inside a verbatim string. The following example shows some common uses for verbatim strings:

:::code language="csharp" source="./snippets/StringLiterals.cs" id="VerbatimLiterals":::

## Raw string literals

Beginning with C# 11, you can use *raw string literals* to more easily create strings that are multi-line, or use any characters requiring escape sequences. *Raw string literals* remove the need to ever use escape sequences. You can write the string, including whitespace formatting, how you want it to appear in output. A *raw string literal*:

- Starts and ends with a sequence of at least three double quote characters (`"""`). You're allowed more than three consecutive characters to start and end the sequence in order to support string literals that contain three (or more) repeated quote characters.
- Single line raw string literals require the opening and closing quote characters on the same line.
- Multi-line raw string literals require both opening and closing quote characters on their own line.
- In multi-line raw string literals, any whitespace to the left of the closing quotes is removed from all lines of the raw string literal.
- In multi-line raw string literals, whitespace following the opening quote on the same line is ignored.
- In multi-line raw string literals, whitespace only lines following the opening quote are included in the string literal.

The following examples demonstrate these rules:

:::code language="csharp" source="./snippets/StringLiterals.cs" id="RawStringLiteralSyntax":::

The following examples demonstrate the compiler errors reported based on these rules:

:::code language="csharp" source="./snippets/StringLiterals.cs" id="ErrorExamples":::

The first two examples are invalid because multiline raw string literals require the opening and closing quote sequence on its own line. The third example is invalid because the text is outdented from the closing quote sequence.

You should consider raw string literals when you're generating text that includes characters that require [escape sequences](#string-escape-sequences) when using quoted string literals or verbatim string literals. Raw string literals will be easier for you and others to read because it will more closely resemble the output text. For example, consider the following code that includes a string of formatted JSON:

:::code language="csharp" source="./snippets/StringLiterals.cs" id="JSONString":::

Compare that text with the equivalent text in the sample on [JSON deserialization](../../../standard/serialization/system-text-json/deserialization.md), which doesn't make use of this new feature.

### String escape sequences

Escape sequence|Character name|Unicode encoding|
|---------------------|--------------------|----------------------|
|\\'|Single quote|0x0027|
|\\"|Double quote|0x0022|
|\\\\ |Backslash|0x005C|
|\0|Null|0x0000|
|\a|Alert|0x0007|
|\b|Backspace|0x0008|
|\f|Form feed|0x000C|
|\n|New line|0x000A|
|\r|Carriage return|0x000D|
|\t|Horizontal tab|0x0009|
|\v|Vertical tab|0x000B|
|\u|Unicode escape sequence (UTF-16)|`\uHHHH` (range: 0000 - FFFF; example: `\u00E7` = "ç")|
|\U|Unicode escape sequence (UTF-32)|`\U00HHHHHH` (range: 000000 - 10FFFF; example: `\U0001F47D` = "&#x1F47D;")|
|\x|Unicode escape sequence similar to "\u" except with variable length|`\xH[H][H][H]` (range: 0 - FFFF; example: `\x00E7` or `\x0E7` or `\xE7` = "ç")|

> [!WARNING]
> When using the `\x` escape sequence and specifying less than 4 hex digits, if the characters that immediately follow the escape sequence are valid hex digits (i.e. 0-9, A-F, and a-f), they will be interpreted as being part of the escape sequence. For example, `\xA1` produces "&#161;", which is code point U+00A1. However, if the next character is "A" or "a", then the escape sequence will instead be interpreted as being `\xA1A` and produce "&#x0A1A;", which is code point U+0A1A. In such cases, specifying all 4 hex digits (for example, `\x00A1`) prevents any possible misinterpretation.

> [!NOTE]
> At compile time, verbatim and raw strings are converted to ordinary strings with all the same escape sequences. Therefore, if you view a verbatim or raw string in the debugger watch window, you will see the escape characters that were added by the compiler, not the verbatim or raw version from your source code. For example, the verbatim string `@"C:\files.txt"` will appear in the watch window as "C:\\\files.txt".

## Format strings

A format string is a string whose contents are determined dynamically at run time. Format strings are created by embedding *interpolated expressions* or placeholders inside of braces within a string. Everything inside the braces (`{...}`) will be resolved to a value and output as a formatted string at run time. There are two methods to create format strings: string interpolation and composite formatting.

### String interpolation

[*Interpolated strings*](../../language-reference/tokens/interpolated.md) are identified by the `$` special character and include interpolated expressions in braces. If you're new to string interpolation, see the [String interpolation - C# interactive tutorial](../../tutorials/exploration/interpolated-strings.yml) for a quick overview.

Use string interpolation to improve the readability and maintainability of your code. String interpolation achieves the same results as the `String.Format` method, but improves ease of use and inline clarity.

:::code language="csharp" source="./snippets/StringInterpolation.cs" id="StringInterpolation":::

Beginning with C# 10, you can use string interpolation to initialize a constant string when all the expressions used for placeholders are also constant strings.

Beginning with C# 11, you can combine *raw string literals* with string interpolations. You start and end the format string with three or more successive double quotes. If your output string should contain the `{` or `}` character, you can use extra `$` characters to specify how many `{` and `}` characters start and end an interpolation. Any sequence of fewer `{` or `}` characters is included in the output.  The following example shows how you can use that feature to display the distance of a point from the origin, and place the point inside braces:

:::code language="csharp" source="./snippets/StringInterpolation.cs" id="InterpolationExample":::

### Verbatim string interpolation

C# also allows verbatim string interpolation, for example across multiple lines, using the `$@` or `@$` syntax.

To interpret escape sequences literally, use a [verbatim](../../language-reference/tokens/verbatim.md) string literal. An interpolated verbatim string starts with the `$` character followed by the `@` character. You can use the `$` and `@` tokens in any order: both `$@"..."` and `@$"..."` are valid interpolated verbatim strings.

:::code language="csharp" source="./snippets/VerbatimStringInterpolation.cs" id="VerbatimStringInterpolation":::

### Composite formatting

The <xref:System.String.Format%2A?displayProperty=nameWithType> utilizes placeholders in braces to create a format string. This example results in similar output to the string interpolation method used above.

:::code language="csharp" source="./snippets/StringInterpolation.cs" id="StringFormat":::

For more information on formatting .NET types, see [Formatting Types in .NET](../../../standard/base-types/formatting-types.md).

## Substrings

A substring is any sequence of characters that is contained in a string. Use the <xref:System.String.Substring%2A> method to create a new string from a part of the original string. You can search for one or more occurrences of a substring by using the <xref:System.String.IndexOf%2A> method. Use the <xref:System.String.Replace%2A> method to replace all occurrences of a specified substring with a new string. Like the <xref:System.String.Substring%2A> method, <xref:System.String.Replace%2A> actually returns a new string and doesn't modify the original string. For more information, see [How to search strings](../../how-to/search-strings.md) and [How to modify string contents](../../how-to/modify-string-contents.md).

:::code language="csharp" source="./snippets/StringCharacters.cs" id="Substrings":::

## Accessing individual characters

You can use array notation with an index value to acquire read-only access to individual characters, as in the following example:

:::code language="csharp" source="./snippets/StringCharacters.cs" id="ReverseChars":::

If the <xref:System.String> methods don't provide the functionality that you must have to modify individual characters in a string, you can use a <xref:System.Text.StringBuilder> object to modify the individual chars "in-place", and then create a new string to store the results by using the <xref:System.Text.StringBuilder> methods. In the following example, assume that you must modify the original string in a particular way and then store the results for future use:

:::code language="csharp" source="./snippets/StringCharacters.cs" id="AccessChars":::

## Null strings and empty strings

An empty string is an instance of a <xref:System.String?displayProperty=nameWithType> object that contains zero characters. Empty strings are used often in various programming scenarios to represent a blank text field. You can call methods on empty strings because they're valid <xref:System.String?displayProperty=nameWithType> objects. Empty strings are initialized as follows:

```csharp
string s = String.Empty;
```

By contrast, a null string doesn't refer to an instance of a <xref:System.String?displayProperty=nameWithType> object and any attempt to call a method on a null string causes a <xref:System.NullReferenceException>. However, you can use null strings in concatenation and comparison operations with other strings. The following examples illustrate some cases in which a reference to a null string does and doesn't cause an exception to be thrown:

:::code language="csharp" source="./snippets/StringCharacters.cs" id="BuildString":::

## Using StringBuilder for fast string creation

String operations in .NET are highly optimized and in most cases don't significantly impact performance. However, in some scenarios such as tight loops that are executing many hundreds or thousands of times, string operations can affect performance. The <xref:System.Text.StringBuilder> class creates a string buffer that offers better performance if your program performs many string manipulations. The <xref:System.Text.StringBuilder> string also enables you to reassign individual characters, something the built-in string data type doesn't support. This code, for example, changes the content of a string without creating a new string:

:::code language="csharp" source="./snippets/StringCharacters.cs" id="MutateStringBuilder":::

In this example, a <xref:System.Text.StringBuilder> object is used to create a string from a set of numeric types:

:::code language="csharp" source="./snippets/StringCharacters.cs" id="TestStringBuilder":::

## Strings, extension methods and LINQ

Because the <xref:System.String> type implements <xref:System.Collections.Generic.IEnumerable%601>, you can use the extension methods defined in the <xref:System.Linq.Enumerable> class on strings. To avoid visual clutter, these methods are excluded from IntelliSense for the <xref:System.String> type, but they're available nevertheless. You can also use LINQ query expressions on strings. For more information, see [LINQ and Strings](/dotnet/csharp/linq).

## Related articles

- [How to modify string contents](../../how-to/modify-string-contents.md): Illustrates techniques to transform strings and modify the contents of strings.
- [How to compare strings](../../how-to/compare-strings.md): Shows how to perform ordinal and culture specific comparisons of strings.
- [How to concatenate multiple strings](../../how-to/concatenate-multiple-strings.md): Demonstrates various ways to join multiple strings into one.
- [How to parse strings using String.Split](../../how-to/parse-strings-using-split.md): Contains code examples that illustrate how to use the <xref:System.String.Split%2A?displayProperty=nameWithType> method to parse strings.
- [How to search strings](../../how-to/search-strings.md): Explains how to use search for specific text or patterns in strings.
- [How to determine whether a string represents a numeric value](./how-to-determine-whether-a-string-represents-a-numeric-value.md): Shows how to safely parse a string to see whether it has a valid numeric value.
- [String interpolation](../../language-reference/tokens/interpolated.md): Describes the string interpolation feature that provides a convenient syntax to format strings.
- [Basic String Operations](../../../standard/base-types/basic-string-operations.md): Provides links to articles that use <xref:System.String?displayProperty=nameWithType> and <xref:System.Text.StringBuilder?displayProperty=nameWithType> methods to perform basic string operations.
- [Parsing Strings](../../../standard/base-types/parsing-strings.md): Describes how to convert string representations of .NET base types to instances of the corresponding types.
- [Parsing Date and Time Strings in .NET](../../../standard/base-types/parsing-datetime.md): Shows how to convert a string such as "01/24/2008" to a <xref:System.DateTime?displayProperty=nameWithType> object.
- [Comparing Strings](../../../standard/base-types/comparing.md): Includes information about how to compare strings and provides examples in C# and Visual Basic.
- [Using the StringBuilder Class](../../../standard/base-types/stringbuilder.md): Describes how to create and modify dynamic string objects by using the <xref:System.Text.StringBuilder> class.
- [LINQ and Strings](/dotnet/csharp/linq): Provides information about how to perform various string operations by using LINQ queries.
