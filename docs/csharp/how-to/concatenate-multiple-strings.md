---
title: "How to: Concatenate Multiple Strings (C# Guide)"
description: There are multiple ways to concatenate strings in C#. Learn the options and the reasons behind different choices.
ms.date: 01/11/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "joining strings [C#]"
  - "concatenating strings [C#]"
  - "strings [C#], concatenation"
ms.assetid: 8e16736f-4096-4f3f-be0f-9d4c3ff63520
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Concatenate Multiple Strings (C# Guide)

*Concatenation* is the process of appending one string to the end of another string. You concatenate strings by using the + operator. For string literals and string constants, concatenation occurs at compile time; no run-time concatenation occurs. For string variables, concatenation occurs only at run time.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

The following example uses concatenation to split a long string literal into smaller strings in order to improve readability in the source code. These parts will be concatenated into a single string at compile time. There is no run-time performance cost regardless of the number of strings involved.  
  
 [!code-csharp-interactive[Combining strings at compile time](../../../samples/snippets/csharp/how-to/strings/Concatenate.cs#1)]  
  

To concatenate string variables, you can use the `+` or `+=` operators, [string interpolation](../tutorials/string-interpolation.md) or the <xref:System.String.Concat%2A?displayProperty=nameWithType>, <xref:System.String.Format%2A?displayProperty=nameWithType> or <xref:System.Text.StringBuilder.Append%2A?displayProperty=nameWithType> methods. The `+` operator is easy to use and makes for intuitive code. Even if you use several + operators in one statement, the string content is copied only once. The following code shows two examples of using the `+` operator to concatenate
strings:

[!code-csharp-interactive[combining strings using +](../../../samples/snippets/csharp/how-to/strings/Concatenate.cs#2)]  

In some expressions, it is easier to concatenate strings using string interpolation, as the following code shows:
  
[!code-csharp-interactive[building strings using string interpolation](../../../samples/snippets/csharp/how-to/strings/Concatenate.cs#3)]  
  
> [!NOTE]
>  In string concatenation operations, the C# compiler treats a null string the same as an empty string.

Other methods to concatenate strings are <xref:System.String.Concat%2A?displayProperty=nameWithType> and <xref:System.String.Format%2A?displayProperty=nameWithType>. These methods work well when you are building a string from a small number of component strings. These methdos are also a great choice when you know the number of strings that make up your concatenated string.

In other cases you may be combining strings in a loop, where you don't know how many source strings you are combining, and the actual number of source strings may be quite large. The <xref:System.Text.StringBuilder> class was designed for these scenarios. The following code uses the <xref:System.Text.StringBuilder.Append%2A> method of the <xref:System.Text.StringBuilder> class to concatenate strings.  
  
[!code-csharp-interactive[string concatenation using string builder](../../../samples/snippets/csharp/how-to/strings/Concatenate.cs#4)]  

You can read more about the [reasons to choose string concatenation or the `StringBuilder` class](xref:System.Text.StringBuilder#StringAndSB)

Another option to join strings from a collection is to use [LINQ](../programming-guide/concepts/linq/index.md)
and the <xref:System.Linq.Enumerable.Aggregate%2A?displayProperty=nameWithType> method. This method combines 
the source strings using a lambda expression. The lambda expression does the
work to add each string to the existing accumulation. The following example
combines an array of words by adding a space between each word in the array:

[!code-csharp-interactive[string concatenation using LINQ expressions](../../../samples/snippets/csharp/how-to/strings/Concatenate.cs#5)]  


## See Also  
 <xref:System.String>  
 <xref:System.Text.StringBuilder>  
 [C# Programming Guide](../programming-guide/index.md)  
 [Strings](../programming-guide/strings/index.md)
