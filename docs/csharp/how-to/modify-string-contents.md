---
title: "How to: Modify String Contents (C# Guide)"
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

# How to: Modify String Contents (C# Programming Guide)

You can't modify the contents of a string after it has been created. The <xref:System.String?displayProperty=nameWithType> class is *immutable*. The examples in this topic show how to create a new string object that represents the result of some change to an existing string. 

## Replace text

The following code demonstrates this *immutable* property of strings. It creates a new string by replacing existing text with a substitute.

[!code-csharp-interactive[replace creates a new string](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#1)]  

You can see in the preceding example that the original string, `source`, is not modified. The <xref:System.String.Replace%2A?displayProperty=nameWithType> creates a new `string` that replaces sought text with other text.

The <xref:System.String.Replace%2A> method can replace either strings or single characters. In both cases, every occurence of the sought text is replaced.  The following example replaces all ' ' characters with '_':

[!code-csharp-interactive[replace characters](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#2)]  

The source string is unchanged, and a new string is returned with the replacement.

## Trim whitespace

You can use the <xref:System.String.Trim%2A?displayProperty=nameWithType>, <xref:System.String.TrimStart%2A?displayProperty=nameWithType>, and <xref:System.String.TrimEnd%2A?displayProperty=nameWithType> methods to create a new string that removes any leading or trailing whitespace.  The following code shows an example of each. The source string does not change; these methods return a new string with the modified contents.

[!code-csharp-interactive[trim whitespace](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#3)]  

## Remove text

You can remove text from a string using the <xref:System.String.Remove%2A?displayProperty=nameWithType> method. This method removes a number of characters starting at a specific index. The following examples shows how to use <xref:System.String.IndexOf%2A?displayProperty=nameWithType> followed by <xref:System.String.Remove%2A> to remove text from a string:

[!code-csharp-interactive[remove text](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#4)]  

## Replace patterns

You can use [regular expressions](../../standard/base-types/regular-expressions.md) to replace patterns with new patterns. The following example makes use of the <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class to find a pattern in a source string and replace it with proper capitalization. The <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=nameWithType> method takes a function that provides the logic of the replacement as one of its arguments. That function uses the <xref:System.Text.StringBuilder?displayProperty=nameWithType> class to build the replacement string with proper capitalization.

The search pattern, "the\s" searches for the word "the" followed by a whitespace character. That part of the patern ensures that it doesn't match "there" in the source string. Regular expressions are most useful for searching and replacing text that follows a pattern, rahter than known text. See [How to: search strings](search-strings.md) for more details.

[!code-csharp-interactive[replace creates a new string](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#5)]  

The <xref:System.Text.StringBuilder.ToString%2A?displayProperty=nameWithType> method returns an immutable string with the contents in the <xref:System.Text.StringBuilder> object.

## Modifying individual characters

You can produce a character array from a string, modify the contents of the array, and then create a new string from the modified contents of the array. 

The following example shows the steps to replace a set of characters in a string. First, it uses <xref:System.String.ToCharArray?displayProperty=nameWithName> method to create an array of characters. Then, it uses the <xref:System.String.IndexOf%2A> method to find the starting index of the word "fox". Then, the next three characters are replaced with a different word. Finally, a new string is constructed from the updated character array.

[!code-csharp-interactive[replace creates a new string](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#6)]  

## Unsafe modifications to string

The following example is provided for those very rare situations in which you may want to modify a string in-place by using unsafe code in a manner similar to C-style char arrays. The example shows how to access the individual characters "in-place" by using the fixed keyword. It also demonstrates one possible side effect of unsafe operations on strings that results from the way that the C# compiler stores (interns) strings internally. In general, you should not use this technique unless it is absolutely necessary.  
  
[!code-csharp-interactive[unsafe ways to create a new string](../../../samples/snippets/csharp/how-to/strings/ModifyStrings.cs#7)]  
 
## See Also  
 [.NET Framework Regular Expressions](../../standard/base-types/regular-expressions.md)   
 [Regular Expression Language - Quick Reference](../../standard/base-types/regular-expression-language-quick-reference.md)   
  
