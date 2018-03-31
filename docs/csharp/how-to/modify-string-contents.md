---
title: "How to: Modify string contents - C# Guide"
ms.date: 02/26/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "strings [C#], modifying"
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Modify string contents in C# #

This article demonstrates several techniques to produce a `string` by modifying an existing `string`. All the techniques demonstrated return the result of the modifications as a new `string` object. To clearly demonstrate this, the examples all store the result in a new variable. You can then examine both the original `string` and the `string` resulting from the modification when you run each example.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

There are several techniques demonstrated in this article. You can replace existing text. You can search for patterns and replace matching text with other text. You can treat a string as a sequence of characters. You can also use convenience methods that remove white space. You should choose the techniques that most closely match your scenario.

## Replace text

The following code creates a new string by replacing existing text with a substitute.

[!code-csharp-interactive[replace creates a new string](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#1)]

The preceding code demonstrates this *immutable* property of strings. You can see in the preceding example that the original string, `source`, is not modified. The <xref:System.String.Replace%2A?displayProperty=nameWithType> method creates a new `string` containing the modifications.

The <xref:System.String.Replace%2A> method can replace either strings or single characters. In both cases, every occurrence of the sought text is replaced.  The following example replaces all ' ' characters with '\_':

[!code-csharp-interactive[replace characters](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#2)]

The source string is unchanged, and a new string is returned with the replacement.

## Trim white space

You can use the <xref:System.String.Trim%2A?displayProperty=nameWithType>, <xref:System.String.TrimStart%2A?displayProperty=nameWithType>, and <xref:System.String.TrimEnd%2A?displayProperty=nameWithType> methods to remove any leading or trailing white space.  The following code shows an example of each. The source string does not change; these methods return a new string with the modified contents.

[!code-csharp-interactive[trim white space](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#3)]

## Remove text

You can remove text from a string using the <xref:System.String.Remove%2A?displayProperty=nameWithType> method. This method removes a number of characters starting at a specific index. The following example shows how to use <xref:System.String.IndexOf%2A?displayProperty=nameWithType> followed by <xref:System.String.Remove%2A> to remove text from a string:

[!code-csharp-interactive[remove text](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#4)]

## Replace matching patterns

You can use [regular expressions](../../standard/base-types/regular-expressions.md) to replace text matching patterns with new text, possibly defined by a pattern. The following example uses the <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class to find a pattern in a source string and replace it with proper capitalization. The <xref:System.Text.RegularExpressions.Regex.Replace(System.String,System.String,System.Text.RegularExpressions.MatchEvaluator,System.Text.RegularExpressions.RegexOptions)?displayProperty=nameWithType> method takes a function that provides the logic of the replacement as one of its arguments. In this example, that function, `LocalReplaceMatchCase` is a **local function** declared inside the sample method. `LocalReplaceMatchCase` uses the <xref:System.Text.StringBuilder?displayProperty=nameWithType> class to build the replacement string with proper capitalization.

Regular expressions are most useful for searching and replacing text that follows a pattern, rather than known text. See [How to: search strings](search-strings.md) for more details. The search pattern, "the\s" searches for the word "the" followed by a white-space character. That part of the pattern ensures that it doesn't match "there" in the source string. For more information on regular expression language elements, see [Regular Expression Language - Quick Reference](../../standard/base-types/regular-expression-language-quick-reference.md).

[!code-csharp-interactive[replace creates a new string](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#5)]

The <xref:System.Text.StringBuilder.ToString%2A?displayProperty=nameWithType> method returns an immutable string with the contents in the <xref:System.Text.StringBuilder> object.

## Modifying individual characters

You can produce a character array from a string, modify the contents of the array, and then create a new string from the modified contents of the array.

The following example shows how to replace a set of characters in a string. First, it uses the <xref:System.String.ToCharArray?displayProperty=nameWithName> method to create an array of characters. It uses the <xref:System.String.IndexOf%2A> method to find the starting index of the word "fox." The next three characters are replaced with a different word. Finally, a new string is constructed from the updated character array.

[!code-csharp-interactive[replace creates a new string](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#6)]

## Unsafe modifications to string

Using **unsafe** code, you can modify a string "in place" after it has been created. Unsafe code bypasses many of the features of .NET designed to minimize certain types of bugs in code. You need to use unsafe code to modify a string in place because the string class is designed as an **immutable** type. Once it has been created, its value does not change. Unsafe code circumvents this property by accessing and modifying the memory used by a `string` without using normal `string` methods.
The following example is provided for those rare situations where you want to modify a string in-place using unsafe code. The example shows how to use the `fixed` keyword. The `fixed` keyword prevents the garbage collector (GC) from moving the string object in memory while code accesses the memory using the unsafe pointer. It also demonstrates one possible side effect of unsafe operations on strings that results from the way that the C# compiler stores (interns) strings internally. In general, you shouldn't use this technique unless it is absolutely necessary. You can learn more in the articles on [unsafe](../language-reference/keywords/unsafe.md) and [fixed](../language-reference/keywords/fixed-statement.md). The API reference for <xref:System.String.Intern%2A> includes inforamtion on string interning.

[!code-csharp-interactive[unsafe ways to create a new string](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#7)]

You can try these samples by looking at the code in our [GitHub repository](https://github.com/dotnet/samples/tree/master/snippets/csharp/how-to/strings). Or you can download the samples [as a zip file](https://github.com/dotnet/samples/raw/master/snippets/csharp/how-to/strings.zip).

## See also

[.NET Framework Regular Expressions](../../standard/base-types/regular-expressions.md)  
 [Regular Expression Language - Quick Reference](../../standard/base-types/regular-expression-language-quick-reference.md)  
