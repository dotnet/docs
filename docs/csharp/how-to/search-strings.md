---
title: "How to search strings (C# Guide)"
description: Learn about two strategies to search for text in strings in C#. String class methods search for specific text. Regular expressions search for patterns in text.
ms.date: 02/21/2018
helpviewer_keywords: 
  - "searching strings [C#]"
  - "strings [C#], searching with String methods"
  - "strings [C#], searching with regular expressions"
ms.assetid: fb1d9a6d-598d-4a35-bd5f-b86012edcb2b
---

# How to search strings

You can use two main strategies to search for text in strings. Methods of the <xref:System.String> class search for specific text. Regular expressions search for patterns in text.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

The [string](../language-reference/builtin-types/reference-types.md#the-string-type) type, which is an alias for the <xref:System.String?displayProperty=nameWithType> class, provides a number of useful methods for searching the contents of a string. Among them are <xref:System.String.Contains%2A>, <xref:System.String.StartsWith%2A>, <xref:System.String.EndsWith%2A>, <xref:System.String.IndexOf%2A>, <xref:System.String.LastIndexOf%2A>. The <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class provides a rich vocabulary to search for patterns in text. In this article, you learn these techniques and how to choose the best method for your needs.

## Does a string contain text?

The <xref:System.String.Contains%2A?displayProperty=nameWithType>, <xref:System.String.StartsWith%2A?displayProperty=nameWithType>, and <xref:System.String.EndsWith%2A?displayProperty=nameWithType> methods search a string for specific text. The following example shows each of these methods and a variation that uses a case-insensitive search:

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs" id="Snippet1":::

The preceding example demonstrates an important point for using these methods. Searches are **case-sensitive** by default. You use the <xref:System.StringComparison.CurrentCultureIgnoreCase?displayProperty=nameWithType> enumeration value to specify a case-insensitive search.

## Where does the sought text occur in a string?

The <xref:System.String.IndexOf%2A> and <xref:System.String.LastIndexOf%2A> methods also search for text in strings. These methods return the location of the text being sought. If the text isn't found, they return `-1`. The following example shows a search for the first and last occurrence of the word "methods" and displays the text in between.

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs" id="Snippet2":::

## Finding specific text using regular expressions

The <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class can be used to search strings. These searches can range in complexity from simple to complicated text patterns.

The following code example searches for the word "the" or "their" in a sentence, ignoring case. The static method <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> performs the search. You give it the string to search and a search pattern. In this case, a third argument specifies case-insensitive search. For more information, see <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=nameWithType>.

The search pattern describes the text you search for. The following table describes each element of the search pattern. (The table below uses the single `\`, which must be escaped as `\\` in a C# string).

| Pattern  | Meaning                          |
|----------|----------------------------------|
| `the`    | match the text "the"             |
| `(eir)?` | match 0 or 1 occurrence of "eir" |
| `\s`     | match a white-space character    |

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs" id="Snippet3":::

> [!TIP]
> The `string` methods are usually better choices when you are searching for an exact string. Regular expressions are better when you are searching for some pattern in a source string.

## Does a string follow a pattern?

The following code uses regular expressions to validate the format of each string in an array. The validation requires that each string have the form of a telephone number in which three groups of digits are separated by dashes, the first two groups contain three digits, and the third group contains four digits. The search pattern uses the regular expression `^\\d{3}-\\d{3}-\\d{4}$`. For more information, see [Regular Expression Language - Quick Reference](../../standard/base-types/regular-expression-language-quick-reference.md).

| Pattern | Meaning                             |
|---------|-------------------------------------|
| `^`     | matches the beginning of the string |
| `\d{3}` | matches exactly 3 digit characters  |
| `-`     | matches the '-' character           |
| `\d{4}` | matches exactly 4 digit characters  |
| `$`     | matches the end of the string       |

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs" id="Snippet4":::

This single search pattern matches many valid strings. Regular expressions are better to search for or validate against a pattern, rather than a single text string.

## See also

- [C# programming guide](../programming-guide/index.md)
- [Strings](../programming-guide/strings/index.md)
- [LINQ and strings](../programming-guide/concepts/linq/linq-and-strings.md)
- <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>
- [.NET regular expressions](../../standard/base-types/regular-expressions.md)
- [Regular expression language - quick reference](../../standard/base-types/regular-expression-language-quick-reference.md)
- [Best practices for using strings in .NET](../../standard/base-types/best-practices-strings.md)
