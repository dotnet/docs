---
title: "How to: search strings (C# Guide)"
ms.date: 02/21/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "searching strings [C#]"
  - "strings [C#], searching with String methods"
  - "strings [C#], searching with regular expressions"
ms.assetid: fb1d9a6d-598d-4a35-bd5f-b86012edcb2b
ms.author: "wiwagn"
---

# How to: search strings

You can use two main strategies to search for text in strings. Methods of the <xref:System.String> class search for specific text. Regular expressions search for patterns in text.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

The [string](../language-reference/keywords/string.md) type, which is an alias for the <xref:System.String?displayProperty=nameWithType> class, provides a number of useful methods for searching the contents of a string. Among them are <xref:System.String.Contains%2A>, <xref:System.String.StartsWith%2A>, <xref:System.String.EndsWith%2A>, <xref:System.String.IndexOf%2A>, <xref:System.String.LastIndexOf%2A>. The <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class provides a rich vocabulary to search for patterns in text. In this article, you learn these techniques and how to choose the best method for your needs.

## Does a string contain text?

The <xref:System.String.Contains%2A?displayProperty=nameWithType>, <xref:System.String.StartsWith%2A?displayProperty=nameWithType> and <xref:System.String.EndsWith%2A?displayProperty=nameWithType> methods search a string for specific text. The following example shows each of these methods and a variation that uses a case insensitive search:

[!code-csharp-interactive[search strings using methods](../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs#1)]

The preceding example demonstrates an important point for using these methods. Searches are **case-sensitive** by default. You use the <xref:System.StringComparison.CurrentCultureIgnoreCase?displayProperty=nameWithType> enum value to specify a case insensitive search.

## Where does the sought text occur in a string?

The <xref:System.String.IndexOf%2A> and <xref:System.String.LastIndexOf%2A> methods also search for text in strings. These methods return the location of the text being sought. If the text isn't found, they return `-1`. The following example shows a search for the first and last occurrence of the word "methods" and displays the text in between.
  
[!code-csharp-interactive[search strings for indices](../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs#2)]

## Finding specific text using regular expressions

The <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class can be used to search strings. These searches can range in complexity from simple to complicated text patterns.

The following code example searches for the word "the" or "their" in a sentence, ignoring case. The static method <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> performs the search. You give it the string to search and a search pattern. In this case, a third argument specifies case-insensitive search. For more information, see <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=nameWithType>.  

The search pattern describes the text you search for. The following table describes each element of the search pattern. (The table below uses the single `\` which must be escaped as `\\` in a C# string).

| pattern  | Meaning     |
| -------- |-------------|
| the      | match the text "the" |
| (eir)?   | match 0 or 1 occurence of "eir" |
| \s       | match a white-space character    |
  
[!code-csharp-interactive[Search using regular expressions](../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs#3)]
  
> [!TIP]
> The `string` methods are usually better choices when you are searching for an exact string. Regular expressions are better when you are searching for some pattern is a source string.

## Does a string follow a pattern?

The following code uses regular expressions to validate the format of each string in an array. The validation requires that each string have the form of a telephone number in which three groups of digits are separated by dashes, the first two groups contain three digits, and the third group contains four digits. The search pattern uses the regular expression `^\\d{3}-\\d{3}-\\d{4}$`. For more information, see [Regular Expression Language - Quick Reference](../../standard/base-types/regular-expression-language-quick-reference.md).

| pattern  | Meaning                             |
| -------- |-------------------------------------|
| ^        | matches the beginning of the string |
| \d{3}    | matches exactly 3 digit characters  |
| -        | matches the '-' character           |
| \d{3}    | matches exactly 3 digit characters  |
| -        | matches the '-' character           |
| \d{4}    | matches exactly 4 digit characters  |
| $        | matches the end of the string       |


[!code-csharp-interactive[csProgGuideStrings#4](../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs#4)]

This single search pattern matches many valid strings. Regular expressions are better to search for or validate against a pattern, rather than a single text string.

You can try these samples by looking at the code in our [GitHub repository](https://github.com/dotnet/samples/tree/master/snippets/csharp/how-to/strings). Or you can download the samples [as a zip file](https://github.com/dotnet/samples/raw/master/snippets/csharp/how-to/strings.zip).

## See Also  

 [C# Programming Guide](../programming-guide/index.md)  
 [Strings](../programming-guide/strings/index.md)  
 [LINQ and Strings](../programming-guide/concepts/linq/linq-and-strings.md)   
 <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>     
 [.NET Framework Regular Expressions](../../standard/base-types/regular-expressions.md)   
 [Regular Expression Language - Quick Reference](../../standard/base-types/regular-expression-language-quick-reference.md)   
 [Best practices for using strings in .NET](../../standard/base-types/best-practices-strings.md)  
