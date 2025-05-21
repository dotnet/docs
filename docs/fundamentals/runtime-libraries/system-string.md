---
title: System.String class
description: Learn about the System.String class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: concept-article
---
# System.String class

[!INCLUDE [context](includes/context.md)]

A string is a sequential collection of characters that's used to represent text. A <xref:System.String> object is a sequential collection of <xref:System.Char?displayProperty=nameWithType> objects that represent a string; a <xref:System.Char?displayProperty=nameWithType> object corresponds to a UTF-16 code unit. The value of the <xref:System.String> object is the content of the sequential collection of <xref:System.Char?displayProperty=nameWithType> objects, and that value is immutable (that is, it is read-only). For more information about the immutability of strings, see the [Immutability and the StringBuilder class](#immutability-and-the-stringbuilder-class) section. The maximum size of a <xref:System.String> object in memory is 2-GB, or about 1 billion characters.

For more information about Unicode, UTF-16, code units, code points, and the <xref:System.Char> and <xref:System.Text.Rune> types, see [Introduction to character encoding in .NET](../../standard/base-types/character-encoding-introduction.md).

## Instantiate a String object

You can instantiate a <xref:System.String> object in the following ways:

- By assigning a string literal to a <xref:System.String> variable. This is the most commonly used method for creating a string. The following example uses assignment to create several strings. Note that in C# and F#, because the backslash (\\) is an escape character, literal backslashes in a string must be escaped or the entire string must be @-quoted.

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/program.cs" interactive="try-dotnet-method" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/program.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/instantiate1.vb" id="Snippet1":::

- By calling a <xref:System.String> class constructor. The following example instantiates strings by calling several class constructors. Note that some of the constructors include pointers to character arrays or signed byte arrays as parameters. Visual Basic does not support calls to these constructors. For detailed information about <xref:System.String> constructors, see the <xref:System.String.%23ctor%2A> constructor summary.

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/program.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/program.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/instantiate1.vb" id="Snippet2":::

- By using the string concatenation operator (+ in C# and F#, and & or + in Visual Basic) to create a single string from any combination of <xref:System.String> instances and string literals. The following example illustrates the use of the string concatenation operator.

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/program.cs" interactive="try-dotnet-method" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/program.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/instantiate1.vb" id="Snippet3":::

- By retrieving a property or calling a method that returns a string. The following example uses the methods of the <xref:System.String> class to extract a substring from a larger string.

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/program.cs" interactive="try-dotnet-method" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/program.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/instantiate1.vb" id="Snippet4":::

- By calling a formatting method to convert a value or object to its string representation. The following example uses the [composite formatting](../../standard/base-types/composite-formatting.md) feature to embed the string representation of two objects into a string.

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/program.cs" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/program.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/instantiate1.vb" id="Snippet5":::

## Char objects and Unicode characters

Each character in a string is defined by a Unicode scalar value, also called a Unicode code point or the ordinal (numeric) value of the Unicode character. Each code point is encoded by using UTF-16 encoding, and the numeric value of each element of the encoding is represented by a <xref:System.Char> object.

> [!NOTE]
> Note that, because a <xref:System.String> instance consists of a sequential collection of UTF-16 code units, it is possible to create a <xref:System.String> object that is not a well-formed Unicode string. For example, it is possible to create a string that has a low surrogate without a corresponding high surrogate. Although some methods, such as the methods of encoding and decoding objects in the <xref:System.Text> namespace, may performs checks to ensure that strings are well-formed, <xref:System.String> class members don't ensure that a string is well-formed.

A single <xref:System.Char> object usually represents a single code point; that is, the numeric value of the <xref:System.Char> equals the code point. For example, the code point for the character "a" is U+0061. However, a code point might require more than one encoded element (more than one <xref:System.Char> object). The Unicode standard defines two types of characters that correspond to multiple <xref:System.Char> objects: graphemes, and Unicode supplementary code points that correspond to characters in the Unicode supplementary planes.

- A grapheme is represented by a base character followed by one or more combining characters. For example, the character ä is represented by a <xref:System.Char> object whose code point is U+0061 followed by a <xref:System.Char> object whose code point is U+0308. This character can also be defined by a single <xref:System.Char> object that has a code point of U+00E4. As the following example shows, a culture-sensitive comparison for equality indicates that these two representations are equal, although an ordinary ordinal comparison does not. However, if the two strings are normalized, an ordinal comparison also indicates that they are equal. (For more information on normalizing strings, see the [Normalization](#normalization) section.)

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/grapheme1.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/grapheme1.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/grapheme1.vb" id="Snippet2":::

- A Unicode supplementary code point (a surrogate pair) is represented by a <xref:System.Char> object whose code point is a high surrogate followed by a <xref:System.Char> object whose code point is a low surrogate. The code units of high surrogates range from U+D800 to U+DBFF. The code units of low surrogates range from U+DC00 to U+DFFF. Surrogate pairs are used to represent characters in the 16 Unicode supplementary planes. The following example creates a surrogate character and passes it to the <xref:System.Char.IsSurrogatePair(System.Char%2CSystem.Char)?displayProperty=nameWithType> method to determine whether it is a surrogate pair.

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/surrogate1.cs" interactive="try-dotnet-method" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/surrogate1.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/surrogate1.vb" id="Snippet3":::

## The Unicode standard

Characters in a string are represented by UTF-16 encoded code units, which correspond to <xref:System.Char> values.

Each character in a string has an associated Unicode character category, which is represented in .NET by the <xref:System.Globalization.UnicodeCategory> enumeration. The category of a character or a surrogate pair can be determined by calling the <xref:System.Globalization.CharUnicodeInfo.GetUnicodeCategory%2A?displayProperty=nameWithType> method.

[!INCLUDE[character-categories](./includes/unicode-categories.md)]

In addition, .NET supports string comparison and sorting based on the Unicode standard. Starting with .NET Framework 4.5 running on Windows 8 and later versions of the Windows operating system, the runtime delegates string comparison and sorting operations to the operating system. On .NET Core and .NET 5+, string comparison and sorting information is provided by [International Components for Unicode](https://icu.unicode.org/) libraries (except on Windows versions prior to Windows 10 May 2019 Update). The following table lists the versions of .NET and the versions of the Unicode Standard on which character comparison and sorting are based.

|.NET version|Version of the Unicode Standard|
|----------------------------|-------------------------------------|
|.NET Framework 4.5 and later on Windows 7|[The Unicode Standard, Version 5.0.0](https://www.unicode.org/versions/Unicode5.0.0)|
|.NET Framework 4.5 and later on Windows 8 and later Windows operating systems|[The Unicode Standard, Version 6.3.0](https://www.unicode.org/versions/Unicode6.3.0/)|
|.NET Core and .NET 5+|Depends on the version of the Unicode Standard supported by the underlying operating system.|

## Embedded null characters

In .NET, a <xref:System.String> object can include embedded null characters, which count as a part of the string's length. However, in some languages such as C and C++, a null character indicates the end of a string; it is not considered a part of the string and is not counted as part of the string's length. This means that the following common assumptions that C and C++ programmers or libraries written in C or C++ might make about strings are not necessarily valid when applied to <xref:System.String> objects:

- The value returned by the `strlen` or `wcslen` functions does not necessarily equal <xref:System.String.Length%2A?displayProperty=nameWithType>.

- The string created by the `strcpy_s` or `wcscpy_s` functions is not necessarily identical to the string being copied.

You should ensure that native C and C++ code that instantiates <xref:System.String> objects, and code that is passed <xref:System.String> objects through platform invoke, don't assume that an embedded null character marks the end of the string.

Embedded null characters in a string are also treated differently when a string is sorted (or compared) and when a string is searched. Null characters are ignored when performing culture-sensitive comparisons between two strings, including comparisons using the invariant culture. They are considered only for ordinal or case-insensitive ordinal comparisons. On the other hand, embedded null characters are always considered when searching a string with methods such as <xref:System.String.Contains%2A>, <xref:System.String.StartsWith%2A>, and <xref:System.String.IndexOf%2A>.

## Strings and indexes

An index is the position of a <xref:System.Char> object (not a Unicode character) in a <xref:System.String>. An index is a zero-based, nonnegative number that starts from the first position in the string, which is index position zero. A number of search methods, such as <xref:System.String.IndexOf%2A> and <xref:System.String.LastIndexOf%2A>, return the index of a character or substring in the string instance.

The <xref:System.String.Chars%2A> property lets you access individual <xref:System.Char> objects by their index position in the string. Because the <xref:System.String.Chars%2A> property is the default property (in Visual Basic) or the indexer (in C# and F#), you can access the individual <xref:System.Char> objects in a string by using code such as the following. This code looks for white space or punctuation characters in a string to determine how many words the string contains.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/index11.cs" interactive="try-dotnet-method" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/index11.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/String/Overview/vb/index1.vb" id="Snippet4":::

Because the <xref:System.String> class implements the <xref:System.Collections.IEnumerable> interface, you can also iterate through the <xref:System.Char> objects in a string by using a `foreach` construct, as the following example shows.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/index2.cs" interactive="try-dotnet-method" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/index2.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/String/Overview/vb/index2.vb" id="Snippet5":::

Consecutive index values might not correspond to consecutive Unicode characters, because a Unicode character might be encoded as more than one <xref:System.Char> object. In particular, a string may contain multi-character units of text that are formed by a base character followed by one or more combining characters or by surrogate pairs. To work with Unicode characters instead of <xref:System.Char> objects, use the <xref:System.Globalization.StringInfo?displayProperty=nameWithType> and <xref:System.Globalization.TextElementEnumerator> classes, or the <xref:System.String.EnumerateRunes%2A?displayProperty=nameWithType> method and the <xref:System.Text.Rune> struct. The following example illustrates the difference between code that works with <xref:System.Char> objects and code that works with Unicode characters. It compares the number of characters or text elements in each word of a sentence. The string includes two sequences of a base character followed by a combining character.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/index3.cs" interactive="try-dotnet-method" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/index3.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/String/Overview/vb/index3.vb" id="Snippet6":::

This example works with text elements by using the <xref:System.Globalization.StringInfo.GetTextElementEnumerator%2A?displayProperty=nameWithType> method and the <xref:System.Globalization.TextElementEnumerator> class to enumerate all the text elements in a string. You can also retrieve an array that contains the starting index of each text element by calling the <xref:System.Globalization.StringInfo.ParseCombiningCharacters%2A?displayProperty=nameWithType> method.

For more information about working with units of text rather than individual <xref:System.Char> values, see [Introduction to character encoding in .NET](../../standard/base-types/character-encoding-introduction.md).

## Null strings and empty strings

A string that has been declared but has not been assigned a value is `null`. Attempting to call methods on that string throws a <xref:System.NullReferenceException>. A null string is different from an empty string, which is a string whose value is "" or <xref:System.String.Empty?displayProperty=nameWithType>. In some cases, passing either a null string or an empty string as an argument in a method call throws an exception. For example, passing a null string to the <xref:System.Int32.Parse%2A?displayProperty=nameWithType> method throws an <xref:System.ArgumentNullException>, and passing an empty string throws a <xref:System.FormatException>. In other cases, a method argument can be either a null string or an empty string. For example, if you are providing an <xref:System.IFormattable> implementation for a class, you want to equate both a null string and an empty string with the general ("G") format specifier.

The <xref:System.String> class includes the following two convenience methods that enable you to test whether a string is `null` or empty:

- <xref:System.String.IsNullOrEmpty%2A>, which indicates whether a string is either `null` or is equal to  <xref:System.String.Empty?displayProperty=nameWithType>. This method eliminates the need to use code such as the following:

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/nullorempty1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/nullorempty1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/nullorempty1.vb" id="Snippet1":::

- <xref:System.String.IsNullOrWhiteSpace%2A>, which indicates whether a string is `null`, equals <xref:System.String.Empty?displayProperty=nameWithType>, or consists exclusively of white-space characters. This method eliminates the need to use code such as the following:

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/nullorempty1.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/nullorempty1.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/nullorempty1.vb" id="Snippet2":::

The following example uses the <xref:System.String.IsNullOrEmpty%2A> method in the <xref:System.IFormattable.ToString%2A?displayProperty=nameWithType> implementation of a custom `Temperature` class. The method supports the "G", "C", "F", and "K" format strings. If an empty format string or a format string whose value is `null` is passed to the method, its value is changed to the "G" format string.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/nullorempty1.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/nullorempty1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/String/Overview/vb/nullorempty1.vb" id="Snippet3":::

## Immutability and the StringBuilder class

A <xref:System.String> object is called immutable (read-only), because its value cannot be modified after it has been created. Methods that appear to modify a <xref:System.String> object actually return a new <xref:System.String> object that contains the modification.

Because strings are immutable, string manipulation routines that perform repeated additions or deletions to what appears to be a single string can exact a significant performance penalty. For example, the following code uses a random number generator to create a string with 1000 characters in the range 0x0001 to 0x052F. Although the code appears to use string concatenation to append a new character to the existing string named `str`, it actually creates a new <xref:System.String> object for each concatenation operation.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/immutable.cs" id="Snippet15":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/immutable.fs" id="Snippet15":::
:::code language="vb" source="./snippets/System/String/Overview/vb/immutable.vb" id="Snippet15":::

You can use the <xref:System.Text.StringBuilder> class instead of the <xref:System.String> class for operations that make multiple changes to the value of a string. Unlike instances of the <xref:System.String> class, <xref:System.Text.StringBuilder> objects are mutable; when you concatenate, append, or delete substrings from a string, the operations are performed on a single string. When you have finished modifying the value of a <xref:System.Text.StringBuilder> object, you can call its <xref:System.Text.StringBuilder.ToString%2A?displayProperty=nameWithType> method to convert it to a string. The following example replaces the <xref:System.String> used in the previous example to concatenate 1000 random characters in the range to  0x0001 to 0x052F with a <xref:System.Text.StringBuilder> object.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/immutable1.cs" id="Snippet16":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/immutable1.fs" id="Snippet16":::
:::code language="vb" source="./snippets/System/String/Overview/vb/immutable1.vb" id="Snippet16":::

## Ordinal vs. culture-sensitive operations

Members of the <xref:System.String> class perform either ordinal or culture-sensitive (linguistic) operations on a <xref:System.String> object. An ordinal operation acts on the numeric value of each <xref:System.Char> object. A culture-sensitive operation acts on the value of the <xref:System.String> object, and takes culture-specific casing, sorting, formatting, and parsing rules into account. Culture-sensitive operations execute in the context of an explicitly declared culture or the implicit current culture. The two kinds of operations can produce very different results when they are performed on the same string.

.NET also supports culture-insensitive linguistic string operations by using the invariant culture (<xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType>), which is loosely based on the culture settings of the English language independent of region. Unlike other <xref:System.Globalization.CultureInfo?displayProperty=nameWithType> settings, the settings of the invariant culture are guaranteed to remain consistent on a single computer, from system to system, and across versions of .NET. The invariant culture can be seen as a kind of black box that ensures stability of string comparisons and ordering across all cultures.

> [!IMPORTANT]
> If your application makes a security decision about a symbolic identifier such as a file name or named pipe, or about persisted data such as the text-based data in an XML file, the operation should use an ordinal comparison instead of a culture-sensitive comparison. This is because a culture-sensitive comparison can yield different results depending on the culture in effect, whereas an ordinal comparison depends solely on the binary value of the compared characters.

> [!IMPORTANT]
> Most methods that perform string operations include an overload that has a parameter of type <xref:System.StringComparison>, which enables you to specify whether the method performs an ordinal or culture-sensitive operation. In general, you should call this overload to make the intent of your method call clear. For best practices and guidance for using ordinal and culture-sensitive operations on strings, see [Best Practices for Using Strings](../../standard/base-types/best-practices-strings.md).

Operations for casing, parsing and formatting, comparison and sorting, and testing for equality can be either ordinal or culture-sensitive. The following sections discuss each category of operation.

> [!TIP]
> You should always call a method overload that makes the intent of your method call clear. For example, instead of calling the <xref:System.String.Compare(System.String%2CSystem.String)> method to perform a culture-sensitive comparison of two strings by using the conventions of the current culture, you should call the <xref:System.String.Compare(System.String%2CSystem.String%2CSystem.StringComparison)> method with a value of <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType> for the `comparisonType` argument. For more information, see [Best Practices for Using Strings](../../standard/base-types/best-practices-strings.md).

You can download the sorting weight tables, a set of text files that contain information on the character weights used in sorting and comparison operations, from the following links:

- Windows (.NET Framework and .NET Core): [Sorting Weight Tables](https://www.microsoft.com/download/details.aspx?id=10921)
- Windows 10 May 2019 Update or later (.NET 5+) and Linux and macOS (.NET Core and .NET 5+): [Default Unicode Collation Element Table](https://www.unicode.org/Public/UCA/latest/allkeys.txt)

### Casing

Casing rules determine how to change the capitalization of a Unicode character; for example, from lowercase to uppercase. Often, a casing operation is performed before a string comparison. For example, a string might be converted to uppercase so that it can be compared with another uppercase string. You can convert the characters in a string to lowercase by calling the <xref:System.String.ToLower%2A> or <xref:System.String.ToLowerInvariant%2A> method, and you can convert them to uppercase by calling the <xref:System.String.ToUpper%2A> or <xref:System.String.ToUpperInvariant%2A> method. In addition, you can use the <xref:System.Globalization.TextInfo.ToTitleCase%2A?displayProperty=nameWithType> method to convert a string to title case.

[!INCLUDE[platform-note](./includes/c-and-posix-cultures.md)]

Casing operations can be based on the rules of the current culture, a specified culture, or the invariant culture. Because case mappings can vary depending on the culture used, the result of casing operations can vary based on culture. The actual differences in casing are of three kinds:

- Differences in the case mapping of LATIN CAPITAL LETTER I (U+0049), LATIN SMALL LETTER I (U+0069), LATIN CAPITAL LETTER I WITH DOT ABOVE (U+0130), and LATIN SMALL LETTER DOTLESS I (U+0131). In the tr-TR (Turkish (Turkey)) and az-Latn-AZ (Azerbaijan, Latin) cultures, and in the tr, az, and az-Latn neutral cultures, the lowercase equivalent of LATIN CAPITAL LETTER I is LATIN SMALL LETTER DOTLESS I, and the uppercase equivalent of LATIN SMALL LETTER I is LATIN CAPITAL LETTER I WITH DOT ABOVE. In all other cultures, including the invariant culture, LATIN SMALL LETTER I and LATIN CAPITAL LETTER I are lowercase and uppercase equivalents.

  The following example demonstrates how a string comparison designed to prevent file system access can fail if it relies on a culture-sensitive casing comparison. (The casing conventions of the invariant culture should have been used.)

  :::code language="csharp" source="./snippets/System/String/Overview/csharp/case2.cs" id="Snippet17":::
  :::code language="fsharp" source="./snippets/System/String/Overview/fsharp/case2.fs" id="Snippet17":::
  :::code language="vb" source="./snippets/System/String/Overview/vb/case2.vb" id="Snippet17":::

- Differences in case mappings between the invariant culture and all other cultures. In these cases, using the casing rules of the invariant culture to change a character to uppercase or lowercase returns the same character. For all other cultures, it returns a different character. Some of the affected characters are listed in the following table.

    |Character|If changed to|Returns|
    |---------------|-------------------|-------------|
    |MICRON SIGN (U+00B5)|Uppercase|GREEK CAPITAL LETTER MU (U+-39C)|
    |LATIN CAPITAL LETTER I WITH DOT ABOVE (U+0130)|Lowercase|LATIN SMALL LETTER I (U+0069)|
    |LATIN SMALL LETTER DOTLESS I (U+0131)|Uppercase|LATIN CAPITAL LETTER I (U+0049)|
    |LATIN SMALL LETTER LONG S (U+017F)|Uppercase|LATIN CAPITAL LETTER S (U+0053)|
    |LATIN CAPITAL LETTER D WITH SMALL LETTER Z WITH CARON (U+01C5)|Lowercase|LATIN SMALL LETTER DZ WITH CARON (U+01C6)|
    |COMBINING GREEK YPOGEGRAMMENI (U+0345)|Uppercase|GREEK CAPITAL LETTER IOTA (U+0399)|

- Differences in case mappings of two-letter mixed-case pairs in the ASCII character range. In most cultures, a two-letter mixed-case pair is equal to the equivalent two-letter uppercase or lowercase pair. This is not true for the following two-letter pairs in the following cultures, because in each case they are compared to a digraph:

  - "lJ" and "nJ" in the hr-HR (Croatian (Croatia)) culture.
  - "cH" in the cs-CZ (Czech (Czech Republic)) and sk-SK (Slovak (Slovakia)) cultures.
  - "aA" in the da-DK (Danish (Denmark)) culture.
  - "cS", "dZ", "dZS", "nY", "sZ", "tY", and "zS" in the hu-HU (Hungarian (Hungary)) culture.
  - "cH" and "lL" in the es-ES_tradnl (Spanish (Spain, Traditional Sort)) culture.
  - "cH", "gI", "kH", "nG" "nH", "pH", "qU', "tH", and "tR" in the vi-VN (Vietnamese (Vietnam)) culture.

  However, it is unusual to encounter a situation in which a culture-sensitive comparison of these pairs creates problems, because these pairs are uncommon in fixed strings or identifiers.

The following example illustrates some of the differences in casing rules between cultures when converting strings to uppercase.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/case1.cs" id="Snippet7":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/case1.fs" id="Snippet7":::
:::code language="vb" source="./snippets/System/String/Overview/vb/case1.vb" id="Snippet7":::

### Parsing and formatting

Formatting and parsing are inverse operations. Formatting rules determine how to convert a value, such as a date and time or a number, to its string representation, whereas parsing rules determine how to convert a string representation to a value such as a date and time. Both formatting and parsing rules are dependent on cultural conventions. The following example illustrates the ambiguity that can arise when interpreting a culture-specific date string. Without knowing the conventions of the culture that was used to produce a date string, it is not possible to know whether 03/01/2011, 3/1/2011, and 01/03/2011 represent January 3, 2011 or March 1, 2011.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/format1.cs" id="Snippet8":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/format1.fs" id="Snippet8":::
:::code language="vb" source="./snippets/System/String/Overview/vb/format1.vb" id="Snippet8":::

Similarly, as the following example shows, a single string can produce different dates depending on the culture whose conventions are used in the parsing operation.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/parse1.cs" id="Snippet9":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/parse1.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System/String/Overview/vb/parse1.vb" id="Snippet9":::

### String comparison and sorting

Conventions for comparing and sorting strings vary from culture to culture. For example, the sort order may be based on phonetics or on the visual representation of characters. In East Asian languages, characters are sorted by the stroke and radical of ideographs. Sorting also depends on the order languages and cultures use for the alphabet. For example, the Danish language has an "Æ" character that it sorts after "Z" in the alphabet. In addition, comparisons can be case-sensitive or case-insensitive, and casing rules might differ by culture. Ordinal comparison, on the other hand, uses the Unicode code points of individual characters in a string when comparing and sorting strings.

Sort rules determine the alphabetic order of Unicode characters and how two strings compare to each other. For example, the <xref:System.String.Compare(System.String%2CSystem.String%2CSystem.StringComparison)?displayProperty=nameWithType> method compares two strings based on the <xref:System.StringComparison> parameter. If the parameter value is <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>, the method performs a linguistic comparison that uses the conventions of the current culture; if the parameter value is <xref:System.StringComparison.Ordinal?displayProperty=nameWithType>, the method performs an ordinal comparison. Consequently, as the following example shows, if the current culture is U.S. English, the first call to the <xref:System.String.Compare(System.String%2CSystem.String%2CSystem.StringComparison)?displayProperty=nameWithType> method (using culture-sensitive comparison) considers "a" less than "A", but the second call to the same method (using ordinal comparison) considers "a" greater than "A".

:::code language="csharp" source="./snippets/System/String/Overview/csharp/compare11.cs" id="Snippet10":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/compare11.fs" id="Snippet10":::
:::code language="vb" source="./snippets/System/String/Overview/vb/compare1.vb" id="Snippet10":::

.NET supports word, string, and ordinal sort rules:

- A word sort performs a culture-sensitive comparison of strings in which certain nonalphanumeric Unicode characters might have special weights assigned to them. For example, the hyphen (-) might have a very small weight assigned to it so that "coop" and "co-op" appear next to each other in a sorted list. For a list of the <xref:System.String> methods that compare two strings using word sort rules, see the [String operations by category](#string-operations-by-category) section.

- A string sort also performs a culture-sensitive comparison. It is similar to a word sort, except that there are no special cases, and all nonalphanumeric symbols come before all alphanumeric Unicode characters. Two strings can be compared using string sort rules by calling the <xref:System.Globalization.CompareInfo.Compare%2A?displayProperty=nameWithType> method overloads that have an `options` parameter that is supplied a value of <xref:System.Globalization.CompareOptions.StringSort?displayProperty=nameWithType>. Note that this is the only method that .NET provides to compare two strings using string sort rules.

- An ordinal sort compares strings based on the numeric value of each <xref:System.Char> object in the string. An ordinal comparison is automatically case-sensitive because the lowercase and uppercase versions of a character have different code points. However, if case is not important, you can specify an ordinal comparison that ignores case. This is equivalent to converting the string to uppercase by using the invariant culture and then performing an ordinal comparison on the result. For a list of the <xref:System.String> methods that compare two strings using ordinal sort rules, see the [String operations by category](#string-operations-by-category) section.

A culture-sensitive comparison is any comparison that explicitly or implicitly uses a <xref:System.Globalization.CultureInfo> object, including the invariant culture that is specified by the <xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType> property. The implicit culture is the current culture, which is specified by the <xref:System.Threading.Thread.CurrentCulture%2A?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> properties. There is considerable variation in the sort order of alphabetic characters (that is, characters for which the <xref:System.Char.IsLetter%2A?displayProperty=nameWithType> property returns `true`) across cultures. You can specify a culture-sensitive comparison that uses the conventions of a specific culture by supplying a <xref:System.Globalization.CultureInfo> object to a string comparison method such as <xref:System.String.Compare(System.String%2CSystem.String%2CSystem.Globalization.CultureInfo%2CSystem.Globalization.CompareOptions)>. You can specify a culture-sensitive comparison that uses the conventions of the current culture by supplying <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>, <xref:System.StringComparison.CurrentCultureIgnoreCase?displayProperty=nameWithType>, or any member of the <xref:System.Globalization.CompareOptions> enumeration other than <xref:System.Globalization.CompareOptions.Ordinal?displayProperty=nameWithType> or <xref:System.Globalization.CompareOptions.OrdinalIgnoreCase?displayProperty=nameWithType> to an appropriate overload of the <xref:System.String.Compare%2A> method. A culture-sensitive comparison is generally appropriate for sorting whereas an ordinal comparison is not. An ordinal comparison is generally appropriate for determining whether two strings are equal (that is, for determining identity) whereas a culture-sensitive comparison is not.

The following example illustrates the difference between culture-sensitive and ordinal comparison. The example evaluates three strings, "Apple", "Æble", and "AEble", using ordinal comparison and the conventions of the da-DK and en-US cultures (each of which is the default culture at the time the <xref:System.String.Compare%2A> method is called). Because the Danish language treats the character "Æ" as an individual letter and sorts it after "Z" in the alphabet, the string "Æble" is greater than "Apple". However, "Æble" is not considered equivalent to "AEble", so "Æble" is also greater than "AEble". The en-US culture doesn't include the letter"Æ" but treats it as equivalent to "AE", which explains why  "Æble" is less than "Apple" but equal to "AEble". Ordinal comparison, on the other hand, considers "Apple" to be less than "Æble", and "Æble" to be greater than "AEble".

:::code language="csharp" source="./snippets/System/String/Overview/csharp/compare4.cs" id="Snippet21":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/compare4.fs" id="Snippet21":::
:::code language="vb" source="./snippets/System/String/Overview/vb/compare4.vb" id="Snippet21":::

Use the following general guidelines to choose an appropriate sorting or string comparison method:

- If you want the strings to be ordered based on the user's culture, you should order them based on the conventions of the current culture. If the user's culture changes, the order of sorted strings will also change accordingly. For example, a thesaurus application should always sort words based on the user's culture.

- If you want the strings to be ordered based on the conventions of a specific culture, you should order them by supplying a <xref:System.Globalization.CultureInfo> object that represents that culture to a comparison method. For example, in an application designed to teach students a particular language, you want strings to be ordered based on the conventions of one of the cultures that speaks that language.

- If you want the order of strings to remain unchanged across cultures, you should order them based on the conventions of the invariant culture or use an ordinal comparison. For example, you would use an ordinal sort to organize the names of files, processes, mutexes, or named pipes.

- For a comparison that involves a security decision (such as whether a username is valid), you should always perform an ordinal test for equality by calling an overload of the <xref:System.String.Equals%2A> method.

> [!NOTE]
> The culture-sensitive sorting and casing rules used in string comparison depend on the version of the .NET. On .NET Core, string comparison depends on the version of the Unicode Standard supported by the underlying operating system. In .NET Framework 4.5 and later versions running on Windows 8 or later, sorting, casing, normalization, and Unicode character information conform to the Unicode 6.0 standard. On other Windows operating systems, they conform to the Unicode 5.0 standard.

For more information about word, string, and ordinal sort rules, see the <xref:System.Globalization.CompareOptions?displayProperty=nameWithType> topic. For additional recommendations on when to use each rule, see [Best Practices for Using Strings](../../standard/base-types/best-practices-strings.md).

Ordinarily, you don't call string comparison methods such as <xref:System.String.Compare%2A> directly to determine the sort order of strings. Instead, comparison methods are called by sorting methods such as <xref:System.Array.Sort%2A?displayProperty=nameWithType> or <xref:System.Collections.Generic.List%601.Sort%2A?displayProperty=nameWithType>. The following example performs four different sorting operations (word sort using the current culture, word sort using the invariant culture, ordinal sort, and string sort using the invariant culture) without explicitly calling a string comparison method, although they do specify the type of comparison to use. Note that each type of sort produces a unique ordering of strings in its array.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/compare2.cs" id="Snippet12":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/compare2.fs" id="Snippet12":::
:::code language="vb" source="./snippets/System/String/Overview/vb/compare2.vb" id="Snippet12":::

> [!TIP]
> Internally, .NET uses sort keys to support culturally sensitive string comparison. Each character in a string is given several categories of sort weights, including alphabetic, case, and diacritic. A sort key, represented by the <xref:System.Globalization.SortKey> class, provides a repository of these weights for a particular string. If your app performs a large number of searching or sorting operations on the same set of strings, you can improve its performance by generating and storing sort keys for all the strings that it uses. When a sort or comparison operation is required, you use the sort keys instead of the strings. For more information, see the <xref:System.Globalization.SortKey> class.

If you don't specify a string comparison convention, sorting methods such as <xref:System.Array.Sort(System.Array)?displayProperty=nameWithType> perform a culture-sensitive, case-sensitive sort on strings. The following example illustrates how changing the current culture affects the order of sorted strings in an array. It creates an array of three strings. First, it sets the `System.Threading.Thread.CurrentThread.CurrentCulture` property to en-US and calls the <xref:System.Array.Sort(System.Array)?displayProperty=nameWithType> method. The resulting sort order is based on sorting conventions for the English (United States) culture. Next, the example sets the `System.Threading.Thread.CurrentThread.CurrentCulture` property to da-DK and calls the <xref:System.Array.Sort%2A?displayProperty=nameWithType> method again. Notice how the resulting sort order differs from the en-US results because it uses the sorting conventions for Danish (Denmark).

:::code language="csharp" source="./snippets/System/String/Overview/csharp/sort1.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/sort1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/String/Overview/vb/sort1.vb" id="Snippet3":::

> [!WARNING]
> If your primary purpose in comparing strings is to determine whether they are equal, you should call the <xref:System.String.Equals%2A?displayProperty=nameWithType> method. Typically, you should use <xref:System.String.Equals%2A> to perform an ordinal comparison. The <xref:System.String.Compare%2A?displayProperty=nameWithType> method is intended primarily to sort strings.

String search methods, such as <xref:System.String.StartsWith%2A?displayProperty=nameWithType> and <xref:System.String.IndexOf%2A?displayProperty=nameWithType>, also can perform culture-sensitive or ordinal string comparisons. The following example illustrates the differences between ordinal and culture-sensitive comparisons using the <xref:System.String.IndexOf%2A> method. A culture-sensitive search in which the current culture is English (United States) considers the substring "oe" to match the ligature "œ". Because a soft hyphen (U+00AD) is a zero-width character, the search treats the soft hyphen as equivalent to <xref:System.String.Empty?displayProperty=nameWithType> and finds a match at the beginning of the string. An ordinal search, on the other hand, does not find a match in either case.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/compare3.cs" id="Snippet13":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/compare3.fs" id="Snippet13":::
:::code language="vb" source="./snippets/System/String/Overview/vb/compare3.vb" id="Snippet13":::

### Search in strings

String search methods, such as <xref:System.String.StartsWith%2A?displayProperty=nameWithType> and <xref:System.String.IndexOf%2A?displayProperty=nameWithType>, also can perform culture-sensitive or ordinal string comparisons to determine whether a character or substring is found in a specified string.

The search methods in the <xref:System.String> class that search for an individual character, such as the <xref:System.String.IndexOf%2A> method, or one of a set of characters,   such as the <xref:System.String.IndexOfAny%2A> method, all perform an ordinal search. To perform a culture-sensitive search for a character, you must call a <xref:System.Globalization.CompareInfo> method such as <xref:System.Globalization.CompareInfo.IndexOf(System.String%2CSystem.Char)?displayProperty=nameWithType> or <xref:System.Globalization.CompareInfo.LastIndexOf(System.String%2CSystem.Char)?displayProperty=nameWithType>. Note that the results of searching for a character using ordinal and culture-sensitive comparison can be very different. For example, a search for a precomposed Unicode character such as the ligature "Æ" (U+00C6) might match any occurrence of its components in the correct sequence, such as "AE" (U+041U+0045), depending on the culture. The following example illustrates the difference between the <xref:System.String.IndexOf(System.Char)?displayProperty=nameWithType> and <xref:System.Globalization.CompareInfo.IndexOf(System.String%2CSystem.Char)?displayProperty=nameWithType> methods when searching for an individual character. The ligature "æ" (U+00E6) is found in the string "aerial" when using the conventions of the en-US culture, but not when using the conventions of the da-DK culture or when performing an ordinal comparison.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/search1.cs" id="Snippet22":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/search1.fs" id="Snippet22":::
:::code language="vb" source="./snippets/System/String/Overview/vb/search1.vb" id="Snippet22":::

On the other hand, <xref:System.String> class methods that search for a string rather than a character perform a culture-sensitive search if search options are not explicitly specified by a parameter of type <xref:System.StringComparison>. The sole exception is <xref:System.String.Contains%2A>, which performs an ordinal search.

### Test for equality

Use the <xref:System.String.Compare%2A?displayProperty=nameWithType> method to determine the relationship of two strings in the sort order. Typically, this is a culture-sensitive operation. In contrast, call the <xref:System.String.Equals%2A?displayProperty=nameWithType> method to test for equality. Because the test for equality usually compares user input with some known string, such as a valid user name, a password, or a file system path, it is typically an ordinal operation.

> [!WARNING]
> It is possible to test for equality by calling the <xref:System.String.Compare%2A?displayProperty=nameWithType> method and determining whether the return value is zero. However, this practice is not recommended. To determine whether two strings are equal, you should call one of the overloads of the <xref:System.String.Equals%2A?displayProperty=nameWithType> method. The preferred overload to call is either the instance <xref:System.String.Equals(System.String%2CSystem.StringComparison)> method or the static <xref:System.String.Equals(System.String%2CSystem.String%2CSystem.StringComparison)> method, because both methods include a <xref:System.StringComparison?displayProperty=nameWithType> parameter that explicitly specifies the type of comparison.

The following example illustrates the danger of performing a culture-sensitive comparison for equality when an ordinal one should be used instead. In this case, the intent of the code is to prohibit file system access from URLs that begin with "FILE://" or "file://" by performing a case-insensitive comparison of the beginning of a URL with the string "FILE://". However, if a culture-sensitive comparison is performed using the Turkish (Turkey) culture on a URL that begins with "file://", the comparison for equality fails, because the Turkish uppercase equivalent of the lowercase "i" is "İ" instead of "I". As a result, file system access is inadvertently permitted. On the other hand, if an ordinal comparison is performed, the comparison for equality succeeds, and file system access is denied.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/equality1.cs" id="Snippet11":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/equality1.fs" id="Snippet11":::
:::code language="vb" source="./snippets/System/String/Overview/vb/equality1.vb" id="Snippet11":::

## Normalization

Some Unicode characters have multiple representations. For example, any of the following code points can represent the letter "ắ":

- U+1EAF
- U+0103 U+0301
- U+0061 U+0306 U+0301

Multiple representations for a single character complicate searching, sorting, matching, and other string operations.

The Unicode standard defines a process called normalization that returns one binary representation of a Unicode character for any of its equivalent binary representations. Normalization can use several algorithms, called normalization forms, that follow different rules. .NET supports Unicode normalization forms C, D, KC, and KD. When strings have been normalized to the same normalization form, they can be compared by using ordinal comparison.

An ordinal comparison is a binary comparison of the Unicode scalar value of corresponding <xref:System.Char> objects in each string. The <xref:System.String> class includes a number of methods that can perform an ordinal comparison, including the following:

- Any overload of the <xref:System.String.Compare%2A>, <xref:System.String.Equals%2A>, <xref:System.String.StartsWith%2A>,  <xref:System.String.EndsWith%2A>, <xref:System.String.IndexOf%2A>, and <xref:System.String.LastIndexOf%2A> methods that includes a <xref:System.StringComparison> parameter. The method performs an ordinal comparison if you supply a value of <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase> for this parameter.

- The overloads of the <xref:System.String.CompareOrdinal%2A> method.

- Methods that use ordinal comparison by default, such as <xref:System.String.Contains%2A>, <xref:System.String.Replace%2A>, and <xref:System.String.Split%2A>.

- Methods that search for a <xref:System.Char> value or for the elements in a <xref:System.Char> array in a string instance. Such methods include <xref:System.String.IndexOf(System.Char)> and <xref:System.String.Split(System.Char%5B%5D)>.

You can determine whether a string is normalized to normalization form C by calling the <xref:System.String.IsNormalized?displayProperty=nameWithType> method, or you can call the <xref:System.String.IsNormalized(System.Text.NormalizationForm)?displayProperty=nameWithType> method to determine whether a string is normalized to a specified normalization form. You can also call the <xref:System.String.Normalize?displayProperty=nameWithType> method to convert a string to normalization form C, or you can call the <xref:System.String.Normalize(System.Text.NormalizationForm)?displayProperty=nameWithType> method to convert a string to a specified normalization form. For step-by-step information about normalizing and comparing strings, see the <xref:System.String.Normalize> and <xref:System.String.Normalize(System.Text.NormalizationForm)> methods.

The following simple example illustrates string normalization. It defines the letter "ố" in three different ways in three different strings, and uses an ordinal comparison for equality to determine that each string differs from the other two strings. It then converts each string to the supported normalization forms, and again performs an ordinal comparison of each string in a specified normalization form. In each case, the second test for equality shows that the strings are equal.

:::code language="csharp" source="./snippets/System/String/Overview/csharp/normalize1.cs" id="Snippet14":::
:::code language="fsharp" source="./snippets/System/String/Overview/fsharp/normalize1.fs" id="Snippet14":::
:::code language="vb" source="./snippets/System/String/Overview/vb/normalize1.vb" id="Snippet14":::

For more information about normalization and normalization forms, see <xref:System.Text.NormalizationForm?displayProperty=nameWithType>, as well as [Unicode Standard Annex #15: Unicode Normalization Forms](https://unicode.org/reports/tr15/) and the [Normalization FAQ](https://www.unicode.org/faq/normalization.html) on the unicode.org website.

## String operations by category

The <xref:System.String> class provides members for comparing strings, testing strings for equality, finding characters or substrings in a string, modifying a string, extracting substrings from a string, combining strings, formatting values, copying a string, and normalizing a string.

### Compare strings

You can compare strings to determine their relative position in the sort order by using the following <xref:System.String> methods:

- <xref:System.String.Compare%2A> returns an integer that indicates the relationship of one string to a second string in the sort order.

- <xref:System.String.CompareOrdinal%2A> returns an integer that indicates the relationship of one string to a second string based on a comparison of their code points.

- <xref:System.String.CompareTo%2A> returns an integer that indicates the relationship of the current string instance to a second string in the sort order. The <xref:System.String.CompareTo(System.String)> method provides the <xref:System.IComparable> and <xref:System.IComparable%601> implementations for the <xref:System.String> class.

### Test strings for equality

You call the <xref:System.String.Equals%2A> method to determine whether two strings are equal. The instance <xref:System.String.Equals(System.String%2CSystem.String%2CSystem.StringComparison)> and the static <xref:System.String.Equals(System.String%2CSystem.StringComparison)> overloads let you specify whether the comparison is culture-sensitive or ordinal, and whether case is considered or ignored. Most tests for equality are ordinal, and comparisons for equality that determine access to a system resource (such as a file system object) should always be ordinal.

### Find characters in a string

The <xref:System.String> class includes two kinds of search methods:

- Methods that return a <xref:System.Boolean> value to indicate whether a particular substring is present in a string instance. These include the <xref:System.String.Contains%2A>, <xref:System.String.EndsWith%2A>, and <xref:System.String.StartsWith%2A> methods.

- Methods that indicate the starting position of a substring in a string instance. These include the <xref:System.String.IndexOf%2A>, <xref:System.String.IndexOfAny%2A>, <xref:System.String.LastIndexOf%2A>, and <xref:System.String.LastIndexOfAny%2A> methods.

> [!WARNING]
> If you want to search a string for a particular pattern rather than a specific substring, you should use regular expressions. For more information, see [.NET Regular Expressions](../../standard/base-types/regular-expressions.md).

### Modify a string

The <xref:System.String> class includes the following methods that appear to modify the value of a string:

- <xref:System.String.Insert%2A> inserts a string into the current <xref:System.String> instance.

- <xref:System.String.PadLeft%2A> inserts one or more occurrences of a specified character at the beginning of a string.

- <xref:System.String.PadRight%2A> inserts one or more occurrences of a specified character at the end of a string.

- <xref:System.String.Remove%2A> deletes a substring from the current <xref:System.String> instance.

- <xref:System.String.Replace%2A> replaces a substring with another substring in the current <xref:System.String> instance.

- <xref:System.String.ToLower%2A> and <xref:System.String.ToLowerInvariant%2A> convert all the characters in a string to lowercase.

- <xref:System.String.ToUpper%2A> and <xref:System.String.ToUpperInvariant%2A> convert all the characters in a string to uppercase.

- <xref:System.String.Trim%2A> removes all occurrences of a character from the beginning and end of a string.

- <xref:System.String.TrimEnd%2A> removes all occurrences of a character from the end of a string.

- <xref:System.String.TrimStart%2A> removes all occurrences of a character from the beginning of a string.

> [!IMPORTANT]
> All string modification methods return a new <xref:System.String> object. They don't modify the value of the current instance.

### Extract substrings from a string

The <xref:System.String.Split%2A?displayProperty=nameWithType> method separates a single string into multiple strings. Overloads of the method allow you to specify multiple delimiters, to limit the number of substrings that the method extracts, to trim white space from substrings, and to specify whether empty strings (which occur when delimiters are adjacent) are included among the returned strings.

### Combine strings

The following <xref:System.String> methods can be used for string concatenation:

- <xref:System.String.Concat%2A> combines one or more substrings into a single string.
- <xref:System.String.Join%2A> concatenates one or more substrings into a single element and adds a separator between each substring.

### Format values

The <xref:System.String.Format%2A?displayProperty=nameWithType> method uses the composite formatting feature to replace one or more placeholders in a string with the string representation of some object or value. The <xref:System.String.Format%2A> method is often used to do the following:

- To embed the string representation of a numeric value in a string.
- To embed the string representation of a date and time value in a string.
- To embed the string representation of an enumeration value in a string.
- To embed the string representation of some object that supports the <xref:System.IFormattable> interface in a string.
- To right-justify or left-justify a substring in a field within a larger string.

For detailed information about formatting operations and examples, see the <xref:System.String.Format%2A> overload summary.

### Copy a string

You can call the following <xref:System.String> methods to make a copy of a string:

- <xref:System.String.Clone%2A> returns a reference to an existing <xref:System.String> object.
- <xref:System.String.CopyTo%2A> copies a portion of a string to a character array.

### Normalize a string

In Unicode, a single character can have multiple code points. Normalization converts these equivalent characters into the same binary representation. The <xref:System.String.Normalize%2A?displayProperty=nameWithType> method performs the normalization, and the <xref:System.String.IsNormalized%2A?displayProperty=nameWithType> method determines whether a string is normalized.

For more information and an example, see the [Normalization](#normalization) section earlier in this article.
