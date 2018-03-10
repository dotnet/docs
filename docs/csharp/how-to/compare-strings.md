---
title: "How to: Compare strings - C# Guide"
description: Learn how to compare and order string values, with or without case, with or without culture specific ordering
ms.date: 03/09/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "strings [C#], comparison"
  - "comparing strings [C#]"
author: "BillWagner"
ms.author: "wiwagn"
---
# How to compare strings in C# #

When you compare strings, you are producing a result that says one string is greater than or less than the other, or that the two strings are equal. The rules by which the result is determined are different depending on whether you are performing *ordinal comparison* or *culture-sensitive comparison*. It is important to use the correct kind of comparison for the specific task.

 Use basic ordinal comparisons when you have to compare or sort the values of two strings without regard to linguistic conventions. A basic ordinal comparison (`System.StringComparison.Ordinal`) is case-sensitive, which means that the two strings must match character for character: "and" does not equal "And" or "AND". A frequently-used variation is `System.StringComparison.OrdinalIgnoreCase`, which will match "and", "And", and "AND". `StringComparison.OrdinalIgnoreCase` is often used to compare file names, path names, network paths, and any other string whose value does not change based on the locale of the user's computer. For more information, see <xref:System.StringComparison?displayProperty=nameWithType>.

 Culture-sensitive comparisons are typically used to compare and sort strings that are input by end users, because the characters and sorting conventions of these strings might vary depending on the locale of the user's computer. Even strings that contain identical characters might sort differently depending on the culture of the current thread.

> [!NOTE]
> When you compare strings, you should use the methods that explicitly specify what kind of comparison you intend to perform. This makes your code much more maintainable and readable. Whenever possible, use the overloads of the methods of the <xref:System.String?displayProperty=nameWithType> and <xref:System.Array?displayProperty=nameWithType> classes that take a <xref:System.StringComparison> enumeration parameter, so that you can specify which type of comparison to perform. It is best to avoid using the `==` and `!=` operators when you compare strings. Also, avoid using the <xref:System.String.CompareTo%2A?displayProperty=nameWithType> instance methods because none of the overloads takes a <xref:System.StringComparison>.

## Example

The following example shows how to correctly compare strings whose values will not change based on the locale of the user's computer. In addition, it also demonstrates the *string interning* feature of C#. When a program declares two or more identical string variables, the compiler stores them all in the same location. By calling the <xref:System.Object.ReferenceEquals%2A> method, you can see that the two strings actually refer to the same object in memory. Use the <xref:System.String.Copy%2A?displayProperty=nameWithType> method to avoid interning, as shown in the example.


<!-- Now snippets 1 thru 4 -->
[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#1)]

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#2)]

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#3)]

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#4)]

## Example

The following example shows how to sort and search for strings in an array in a culture-sensitive manner by using the static <xref:System.Array> methods that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter.

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#5)]

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#6)]

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#7)]

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#8)]


Collection classes such as <xref:System.Collections.Hashtable?displayProperty=nameWithType>, <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>, and <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> have constructors that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter when the type of the elements or keys is `string`. In general, you should use these constructors whenever possible, and specify either `Ordinal` or `OrdinalIgnoreCase`.

## Example

The following example shows how to compare strings the preferred way by using the <xref:System.String?displayProperty=nameWithType> methods that take a <xref:System.StringComparison> enumeration. Note that the <xref:System.String.CompareTo%2A?displayProperty=nameWithType> instance methods are not used here, because none of the overloads takes a <xref:System.StringComparison>.

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#9)]


## See also
 <xref:System.Globalization.CultureInfo?displayProperty=nameWithType>  
 <xref:System.StringComparer?displayProperty=nameWithType>  
 [Strings](../../../csharp/programming-guide/strings/index.md)  
 [Comparing Strings](../../../standard/base-types/comparing.md)  
 [Globalizing and Localizing Applications](/visualstudio/ide/globalizing-and-localizing-applications)