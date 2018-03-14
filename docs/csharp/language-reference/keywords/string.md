---
title: "string (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "string"
  - "string_CSharpKeyword"
helpviewer_keywords: 
  - "strings [C#], reference"
  - "@ string literal"
  - "string literals [C#]"
  - "string keyword [C#]"
ms.assetid: 3037e558-fb22-494d-bca1-a15ade11b11a
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
---
# string (C# Reference)
The `string` type represents a sequence of zero or more Unicode characters. `string` is an alias for <xref:System.String> in .NET.  
  
 Although `string` is a reference type, the equality operators (`==` and `!=`) are defined to compare the values of `string` objects, not references. This makes testing for string equality more intuitive. For example:  
  
```csharp  
string a = "hello";  
string b = "h";  
// Append to contents of 'b'  
b += "ello";  
Console.WriteLine(a == b);  
Console.WriteLine((object)a == (object)b);  
```  
  
 This displays "True" and then "False" because the content of the strings are equivalent, but `a` and `b` do not refer to the same string instance.  
  
 The + operator concatenates strings:  
  
```csharp  
string a = "good " + "morning";  
```  
  
 This creates a string object that contains "good morning".  
  
 Strings are *immutable*--the contents of a string object cannot be changed after the object is created, although the syntax makes it appear as if you can do this. For example, when you write this code, the compiler actually creates a new string object to hold the new sequence of characters, and that new object is assigned to b. The string "h" is then eligible for garbage collection.  
  
```csharp
string b = "h";  
b += "ello";  
```  
  
 The [] operator can be used for readonly access to individual characters of a `string`:  
  
```csharp  
string str = "test";  
char x = str[2];  // x = 's';  
```  
  
 String literals are of type `string` and can be written in two forms, quoted and @-quoted. Quoted string literals are enclosed in double quotation marks ("):  
  
```csharp  
"good morning"  // a string literal  
```  
  
 String literals can contain any character literal. Escape sequences are included. The following example uses escape sequence `\\` for backslash, `\u0066` for the letter f, and `\n` for newline.  
  
```  
string a = "\\\u0066\n";  
Console.WriteLine(a);  
```  
  
> [!NOTE]
>  The escape code `\udddd` (where `dddd` is a four-digit number) represents the Unicode character U+`dddd`. Eight-digit Unicode escape codes are also recognized: `\Udddddddd`.  
  
 Verbatim string literals start with `@` and are also enclosed in double quotation marks. For example:  
  
```csharp  
@"good morning"  // a string literal  
```  
  
 The advantage of verbatim strings is that escape sequences are *not* processed, which makes it easy to write, for example, a fully qualified file name:  
  
```csharp  
@"c:\Docs\Source\a.txt"  // rather than "c:\\Docs\\Source\\a.txt"  
```  
  
 To include a double quotation mark in an @-quoted string, double it:  
  
```csharp  
@"""Ahoy!"" cried the captain." // "Ahoy!" cried the captain.  
```  
  
 For other uses of the `@` special character, see [@ -- verbatim identifier](../tokens/verbatim.md).  
  
 For more information about strings in C#, see [Strings](../../../csharp/programming-guide/strings/index.md).  
  
## Example  
 [!code-csharp[csrefKeywordsTypes#17](../../../csharp/language-reference/keywords/codesnippet/CSharp/string_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Best Practices for Using Strings](../../../standard/base-types/best-practices-strings.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Reference Types](../../../csharp/language-reference/keywords/reference-types.md)  
 [Value Types](../../../csharp/language-reference/keywords/value-types.md)  
 [Basic String Operations](../../../standard/base-types/basic-string-operations.md)  
 [Creating New Strings](../../../standard/base-types/creating-new.md)  
 [Formatting Numeric Results Table](../../../csharp/language-reference/keywords/formatting-numeric-results-table.md)
