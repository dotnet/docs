---
title: "How to: Search Strings (C# Guide)"
ms.date: 02/16/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "searching strings [C#]"
  - "strings [C#], searching with String methods"
ms.assetid: fb1d9a6d-598d-4a35-bd5f-b86012edcb2b
ms.author: "wiwagn"
---

# How to: Search Strings Using String Methods (C# Programming Guide)

The [string](../language-reference/keywords/string.md) type, which is an alias for the <xref:System.String?displayProperty=nameWithType> class, provides a number of useful methods for searching the contents of a string.  
  
## Example  

The following example uses the <xref:System.String.IndexOf%2A>, <xref:System.String.LastIndexOf%2A>, <xref:System.String.StartsWith%2A>, and <xref:System.String.EndsWith%2A> methods to search the strings.  
  
[!code-csharp-interactive[csProgGuideStrings#1](../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs#1)]
  
## See Also  
 [C# Programming Guide](../programming-guide/index.md)  
 [Strings](../programming-guide/strings/index.md)  
 [LINQ and Strings](http://msdn.microsoft.com/library/6c34169f-7a39-436a-98d8-9a7283043942)

## Search Strings Using Regular Expressions

The <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class can be used to search strings. These searches can range in complexity from very simple to making full use of regular expressions. The following are two examples of string searching by using the <xref:System.Text.RegularExpressions.Regex> class. For more information, see [.NET Framework Regular Expressions](https://msdn.microsoft.com/library/hs600312).  
  
## Example  

The following code is a console application that performs a simple case-insensitive search of the strings in an array. The static method <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> performs the search given the string to search and a string that contains the search pattern. In this case, a third argument is used to indicate that case should be ignored. For more information, see <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=nameWithType>.  
  
[!code-csharp-interactive[csProgGuideStrings#2](../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs#2)]
  
## Example  

The following code is a console application that uses regular expressions to validate the format of each string in an array. The validation requires that each string take the form of a telephone number in which three groups of digits are separated by dashes, the first two groups contain three digits, and the third group contains four digits. This is done by using the regular expression `^\\d{3}-\\d{3}-\\d{4}$`. For more information, see [Regular Expression Language - Quick Reference](http://msdn.microsoft.com/library/930653a6-95d2-4697-9d5a-52d11bb6fd4c).  
  
[!code-csharp-interactive[csProgGuideStrings#3](../../../samples/snippets/csharp/how-to/strings/SearchStrings.cs#3)]  
  
## See Also  

 <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>  
 [Strings](../programming-guide/strings/index.md)  
 [.NET Framework Regular Expressions](https://msdn.microsoft.com/library/hs600312)  
 [Regular Expression Language - Quick Reference](http://msdn.microsoft.com/library/930653a6-95d2-4697-9d5a-52d11bb6fd4c)
