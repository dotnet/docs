---
title: "string (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "string"
  - "string_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "strings [C#], reference"
  - "@ string literal"
  - "string literals [C#]"
  - "string keyword [C#]"
ms.assetid: 3037e558-fb22-494d-bca1-a15ade11b11a
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# string (C# Reference)
The `string` type represents a sequence of zero or more Unicode characters. `string` is an alias for <xref:System.String> in the .NET Framework.  
  
 Although `string` is a reference type, the equality operators (`==` and `!=`) are defined to compare the values of `string` objects, not references. This makes testing for string equality more intuitive. For example:  
  
```c#  
  
      string a = "hello";  
string b = "h";  
// Append to contents of 'b'  
b += "ello";  
Console.WriteLine(a == b);  
Console.WriteLine((object)a == (object)b);  
```  
  
 This displays "True" and then "False" because the content of the strings are equivalent, but `a` and `b` do not refer to the same string instance.  
  
 The + operator concatenates strings:  
  
```c#  
  
string a = "good " + "morning";  
```  
  
 This creates a string object that contains "good morning".  
  
 Strings are *immutable*--the contents of a string object cannot be changed after the object is created, although the syntax makes it appear as if you can do this. For example, when you write this code, the compiler actually creates a new string object to hold the new sequence of characters, and that new object is assigned to b. The string "h" is then eligible for garbage collection.  
  
```c#  
  
      string b = "h";  
b += "ello";  
```  
  
 The [] operator can be used for readonly access to individual characters of a `string`:  
  
```c#  
  
      string str = "test";  
char x = str[2];  // x = 's';  
```  
  
 String literals are of type `string` and can be written in two forms, quoted and @-quoted. Quoted string literals are enclosed in double quotation marks ("):  
  
```c#  
"good morning"  // a string literal  
```  
  
 String literals can contain any character literal. Escape sequences are included. The following example uses escape sequence `\\` for backslash, `\u0066` for the letter f, and `\n` for newline.  
  
```  
  
      string a = "\\\u0066\n";  
Console.WriteLine(a);  
```  
  
> [!NOTE]
>  The escape code `\`u`dddd` (where `dddd` is a four-digit number) represents the Unicode character U+`dddd`. Eight-digit Unicode escape codes are also recognized: `\Udddddddd`.  
  
 Verbatim string literals start with @ and are also enclosed in double quotation marks. For example:  
  
```c#  
@"good morning"  // a string literal  
```  
  
 The advantage of verbatim strings is that escape sequences are *not* processed, which makes it easy to write, for example, a fully qualified file name:  
  
```c#  
@"c:\Docs\Source\a.txt"  // rather than "c:\\Docs\\Source\\a.txt"  
```  
  
 To include a double quotation mark in an @-quoted string, double it:  
  
```c#  
@"""Ahoy!"" cried the captain." // "Ahoy!" cried the captain.  
```  
  
 Another use of the @ symbol is to use referenced ([/reference](../compiler-options/-reference--csharp-compiler-options-.md)) identifiers that are C# keywords.  
  
 For more information about strings in C#, see [Strings](../strings/strings--csharp-programming-guide-.md).  
  
## Example  
 [!code[csrefKeywordsTypes#17](../keywords/codesnippet/CSharp/string--csharp-reference-_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Best Practices for Using Strings](../Topic/Best%20Practices%20for%20Using%20Strings%20in%20the%20.NET%20Framework.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Reference Types](../keywords/reference-types--csharp-reference-.md)   
 [Value Types](../keywords/value-types--csharp-reference-.md)   
 [Basic String Operations](../Topic/Basic%20String%20Operations%20in%20the%20.NET%20Framework.md)   
 [Creating New Strings](../Topic/Creating%20New%20Strings%20in%20the%20.NET%20Framework.md)   
 [Formatting Numeric Results Table](../keywords/formatting-numeric-results-table--csharp-reference-.md)