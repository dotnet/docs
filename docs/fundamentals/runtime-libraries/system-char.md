---
title: System.Char struct
description: Learn about the System.Char struct through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Char struct

[!INCLUDE [context](includes/context.md)]

The <xref:System.Char> structure represents Unicode code points by using UTF-16 encoding. The value of a <xref:System.Char> object is its 16-bit numeric (ordinal) value.

If you aren't familiar with Unicode, scalar values, code points, surrogate pairs, UTF-16, and the <xref:System.Text.Rune> type, see [Introduction to character encoding in .NET](../../standard/base-types/character-encoding-introduction.md).

This article examines the relationship between a <xref:System.Char> object and a character and discuss some common tasks performed with <xref:System.Char> instances. We recommend that you consider the <xref:System.Text.Rune> type, introduced in .NET Core 3.0, as an alternative to <xref:System.Char> for performing some of these tasks.

## Char objects, Unicode characters, and strings

A <xref:System.String> object is a sequential collection of <xref:System.Char> structures that represents a string of text. Most Unicode characters can be represented by a single <xref:System.Char> object, but a character that is encoded as a base character, surrogate pair, and/or combining character sequence is represented by multiple <xref:System.Char> objects. For this reason, a <xref:System.Char> structure in a <xref:System.String> object is not necessarily equivalent to a single Unicode character.

Multiple 16-bit code units are used to represent single Unicode characters in the following cases:

- Glyphs, which may consist of a single character or of a base character followed by one or more combining characters. For example, the character ä is represented by a <xref:System.Char> object whose code unit is U+0061 followed by a <xref:System.Char> object whose code unit is U+0308. (The character ä can also be defined by a single <xref:System.Char> object that has a code unit of U+00E4.) The following example illustrates that the character ä consists of two <xref:System.Char> objects.

  :::code language="csharp" source="./snippets/System/Char/Overview/csharp/grapheme1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/Char/Overview/fsharp/grapheme1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/Char/Overview/vb/grapheme1.vb" id="Snippet1":::

- Characters outside the Unicode Basic Multilingual Plane (BMP). Unicode supports sixteen planes in addition to the BMP, which represents plane 0. A Unicode code point is represented in UTF-32 by a 21-bit value that includes the plane. For example, U+1D160 represents the MUSICAL SYMBOL EIGHTH NOTE character. Because UTF-16 encoding has only 16 bits, characters outside the BMP are represented by surrogate pairs in UTF-16. The following example illustrates that the UTF-32 equivalent of U+1D160, the MUSICAL SYMBOL EIGHTH NOTE character, is U+D834 U+DD60. U+D834 is the high surrogate; high surrogates range from U+D800 through U+DBFF. U+DD60 is the low surrogate; low surrogates range from U+DC00 through U+DFFF.

  :::code language="csharp" source="./snippets/System/Char/Overview/csharp/surrogate1.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/Char/Overview/fsharp/surrogate1.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/Char/Overview/vb/surrogate1.vb" id="Snippet2":::

## Characters and character categories

Each Unicode character or valid surrogate pair belongs to a Unicode category. In .NET, Unicode categories are represented by members of the <xref:System.Globalization.UnicodeCategory> enumeration and include values such as <xref:System.Globalization.UnicodeCategory.CurrencySymbol?displayProperty=nameWithType>, <xref:System.Globalization.UnicodeCategory.LowercaseLetter?displayProperty=nameWithType>, and <xref:System.Globalization.UnicodeCategory.SpaceSeparator?displayProperty=nameWithType>, for example.

To determine the Unicode category of a character, call the <xref:System.Char.GetUnicodeCategory%2A> method. For example, the following example calls the <xref:System.Char.GetUnicodeCategory%2A> to display the Unicode category of each character in a string. The example works correctly only if there are no surrogate pairs in the <xref:System.String> instance.

:::code language="csharp" source="./snippets/System/Char/Overview/csharp/GetUnicodeCategory3.cs" interactive="try-dotnet" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/Char/Overview/fsharp/GetUnicodeCategory3.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/Char/Overview/vb/GetUnicodeCategory3.vb" id="Snippet6":::

Internally, for characters outside the ASCII range (U+0000 through U+00FF), the <xref:System.Char.GetUnicodeCategory%2A> method depends on Unicode categories reported by the <xref:System.Globalization.CharUnicodeInfo> class. Starting with .NET Framework 4.6.2, Unicode characters are classified based on [The Unicode Standard, Version 8.0.0](https://www.unicode.org/versions/Unicode8.0.0/). In versions of .NET Framework from .NET Framework 4 to .NET Framework 4.6.1, they are classified based on [The Unicode Standard, Version 6.3.0](https://www.unicode.org/versions/Unicode6.3.0/).

## Characters and text elements

Because a single character can be represented by multiple <xref:System.Char> objects, it is not always meaningful to work with individual <xref:System.Char> objects. For instance, the following example converts the Unicode code points that represent the Aegean numbers zero through 9 to UTF-16 encoded code units. Because it erroneously equates <xref:System.Char> objects with characters, it inaccurately reports that the resulting string has 20 characters.

:::code language="csharp" source="./snippets/System/Char/Overview/csharp/textelements2.cs" interactive="try-dotnet" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Char/Overview/fsharp/textelements2.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Char/Overview/vb/textelements2.vb" id="Snippet3":::

You can do the following to avoid the assumption that a <xref:System.Char> object represents a single character:

- You can work with a <xref:System.String> object in its entirety instead of working with its individual characters to represent and analyze linguistic content.

- You can use <xref:System.String.EnumerateRunes%2A?displayProperty=nameWithType> as shown in the following example:

  :::code language="csharp" source="./snippets/System.Text/Rune/Overview/csharp/CountLettersInString.cs" id="SnippetGoodExample":::
  :::code language="fsharp" source="./snippets/System.Text/Rune/Overview/fsharp/CountLettersInString.fs" id="SnippetGoodExample":::

- You can use the <xref:System.Globalization.StringInfo> class to work with text elements instead of individual <xref:System.Char> objects. The following example uses the <xref:System.Globalization.StringInfo> object to count the number of text elements in a string that consists of the Aegean numbers zero through nine. Because it considers a surrogate pair a single character, it correctly reports that the string contains ten characters.

  :::code language="csharp" source="./snippets/System/Char/Overview/csharp/textelements2a.cs" interactive="try-dotnet" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/Char/Overview/fsharp/textelements2a.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/Char/Overview/vb/textelements2a.vb" id="Snippet4":::

- If a string contains a base character that has one or more combining characters, you can call the <xref:System.String.Normalize%2A?displayProperty=nameWithType> method to convert the substring to a single UTF-16 encoded code unit. The following example calls the <xref:System.String.Normalize%2A?displayProperty=nameWithType> method to convert the base character U+0061 (LATIN SMALL LETTER A) and combining character U+0308 (COMBINING DIAERESIS) to U+00E4 (LATIN SMALL LETTER A WITH DIAERESIS).

  :::code language="csharp" source="./snippets/System/Char/Overview/csharp/normalized.cs" interactive="try-dotnet" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/Char/Overview/fsharp/normalized.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/Char/Overview/vb/normalized.vb" id="Snippet5":::

## Common operations

The <xref:System.Char> structure provides methods to compare <xref:System.Char> objects, convert the value of the current <xref:System.Char> object to an object of another type, and determine the Unicode category of a <xref:System.Char> object:

|To do this|Use these `System.Char` methods|
|----------------|-------------------------------------|
|Compare <xref:System.Char> objects|<xref:System.Char.CompareTo%2A> and <xref:System.Char.Equals%2A>|
|Convert a code point to a string|<xref:System.Char.ConvertFromUtf32%2A><br /><br />See also the <xref:System.Text.Rune> type.|
|Convert a <xref:System.Char> object or a surrogate pair of <xref:System.Char> objects to a code point|For a single character: <xref:System.Convert.ToInt32%28System.Char%29?displayProperty=nameWithType><br /><br />For a surrogate pair or a character in a string: <xref:System.Char.ConvertToUtf32%2A?displayProperty=nameWithType><br /><br />See also the <xref:System.Text.Rune> type.|
|Get the Unicode category of a character|<xref:System.Char.GetUnicodeCategory%2A><br /><br />See also <xref:System.Text.Rune.GetUnicodeCategory%2A?displayProperty=nameWithType>.|
|Determine whether a character is in a particular Unicode category such as digit, letter, punctuation, control character, and so on|<xref:System.Char.IsControl%2A>, <xref:System.Char.IsDigit%2A>, <xref:System.Char.IsHighSurrogate%2A>, <xref:System.Char.IsLetter%2A>, <xref:System.Char.IsLetterOrDigit%2A>, <xref:System.Char.IsLower%2A>, <xref:System.Char.IsLowSurrogate%2A>, <xref:System.Char.IsNumber%2A>, <xref:System.Char.IsPunctuation%2A>, <xref:System.Char.IsSeparator%2A>, <xref:System.Char.IsSurrogate%2A>, <xref:System.Char.IsSurrogatePair%2A>, <xref:System.Char.IsSymbol%2A>, <xref:System.Char.IsUpper%2A>, and <xref:System.Char.IsWhiteSpace%2A><br /><br />See also corresponding methods on the <xref:System.Text.Rune> type.|
|Convert a <xref:System.Char> object that represents a number to a numeric value type|<xref:System.Char.GetNumericValue%2A><br /><br />See also <xref:System.Text.Rune.GetNumericValue%2A?displayProperty=nameWithType>.|
|Convert a character in a string into a <xref:System.Char> object|<xref:System.Char.Parse%2A> and <xref:System.Char.TryParse%2A>|
|Convert a <xref:System.Char> object to a <xref:System.String> object|<xref:System.Char.ToString%2A>|
|Change the case of a <xref:System.Char> object|<xref:System.Char.ToLower%2A>, <xref:System.Char.ToLowerInvariant%2A>, <xref:System.Char.ToUpper%2A>, and <xref:System.Char.ToUpperInvariant%2A><br /><br />See also corresponding methods on the <xref:System.Text.Rune> type.|

## Char values and interop

When a managed <xref:System.Char> type, which is represented as a Unicode UTF-16 encoded code unit, is passed to unmanaged code, the interop marshaller converts the character set to ANSI by default. You can apply the <xref:System.Runtime.InteropServices.DllImportAttribute> attribute to platform invoke declarations and the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute to a COM interop declaration to control which character set a marshaled <xref:System.Char> type uses.
