---
title: "How to: Search Strings Using Regular Expressions (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "searching strings [C#]"
  - "strings [C#], searching with RegEx"
ms.assetid: dcab2150-a4a2-4fe4-87e3-83b83b58d84a
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# How to: Search Strings Using Regular Expressions (C# Programming Guide)
The <xref:System.Text.RegularExpressions.Regex?displayProperty=fullName> class can be used to search strings. These searches can range in complexity from very simple to making full use of regular expressions. The following are two examples of string searching by using the <xref:System.Text.RegularExpressions.Regex> class. For more information, see [.NET Framework Regular Expressions](https://msdn.microsoft.com/library/hs600312).  
  
## Example  
 The following code is a console application that performs a simple case-insensitive search of the strings in an array. The static method <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=fullName> performs the search given the string to search and a string that contains the search pattern. In this case, a third argument is used to indicate that case should be ignored. For more information, see <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=fullName>.  
  
 [!code-cs[csProgGuideStrings#17](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-search-strings-using-regular-expressions_1.cs)]  
  
## Example  
 The following code is a console application that uses regular expressions to validate the format of each string in an array. The validation requires that each string take the form of a telephone number in which three groups of digits are separated by dashes, the first two groups contain three digits, and the third group contains four digits. This is done by using the regular expression `^\\d{3}-\\d{3}-\\d{4}$`. For more information, see [Regular Expression Language - Quick Reference](http://msdn.microsoft.com/library/930653a6-95d2-4697-9d5a-52d11bb6fd4c).  
  
 [!code-cs[csProgGuideStrings#18](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-search-strings-using-regular-expressions_2.cs)]  
  
## See Also  
 <xref:System.Text.RegularExpressions.Regex?displayProperty=fullName>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Strings](../../../csharp/programming-guide/strings/index.md)   
 [.NET Framework Regular Expressions](https://msdn.microsoft.com/library/hs600312)   
 [Regular Expression Language - Quick Reference](http://msdn.microsoft.com/library/930653a6-95d2-4697-9d5a-52d11bb6fd4c)