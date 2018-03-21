---
title: "How to: Compare strings - C# Guide"
description: Learn how to compare and order string values, with or without case, with or without culture specific ordering
ms.date: 03/20/2018
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

You compare strings to answer one of two questions: "Are these two strings
equal?" or "In what order should these strings be placed when sorting them?"

Those two questions are complicated by factors that affect string
comparisons: 
- You can choose an ordinal or linguistic comparison.
- You can choose if case matters.
- You can choose to compare string values, or the references to the string storage.
- You can choose culture specific comparisons.
- Culture sensitive comparisons are platform-dependent.

<< Insert table when done>>

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

When you compare strings, you define an order among them. Comparisons are
used to sort a sequence of strings. Once the sequence is in a known order,
it is easier to search, both for software and for humans. Other comparisons
may check if strings are the same. These sameness checks are similar to
equality, but some differences, such as case differences, may be ignored.

## Default ordinal comparisons

The most common operations, <xref:System.String.CompareTo%2A?displayProperty=nameWithType> and
<xref:System.String.Equals%2A?displayProperty=nameWithType> or <xref:System.String.op_equality?displayProperty=nameWithType> use
an ordinal comparison, a case-sensitive comparison, and use the current
culture. The results are shown in the following example.

[!code-csharp-interactive[Comparing strings using an ordinal comparison](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#1)]

Ordinal comparisons do not take linguistic rules into account when comparing
strings. They will compare the strings character by character. Case-sensitive
comparisons use capitalization in their comparisons. The most important point
about these default comparison methods is that because they use the current
culture, the results depend on the locale and language settings of the
machine where they run. These comparisons are unsuitable for comparisons
where order should be consistent across machines or locations.

## Case-insensitive ordinal comparisons

The <xref:System.String.Equals%2A?displayProperty=nameWithType> method
enables you to specify a <xref:System.StringComparison> value to specify
a case-insensitive comparison. There is also a static <xref:System.String.Compare%2A>
method that supports this option as well. All of these methods are shown
in the following code:

[!code-csharp-interactive[Comparing strings ignoring case](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#2)]

You use the <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>
value to specify that you want case-insensitive comparisons. 

## Linguistic comparisons


The methods that compare strings indicate that one string is greater than or less than the other, or that the two strings are equal. The comparison result depends on rules that specify whether to perform an *ordinal comparison* or a *culture-sensitive comparison* and if case should be considered. You pick the rules that match your scenario.

Use basic ordinal comparisons when you have to compare two strings without regard to linguistic conventions. A basic ordinal comparison (<xref:System.StringComparison.Ordinal?displayProperty=nameWithType>) is case-sensitive, which means that the two strings must match character for character: "and" does not equal "And" or "AND". A frequently used variation is <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>, which will consider "and", "And", and "AND" all equal. <xref:System.StringComparison.OrdinalIgnoreCase> is often used to compare file names, path names, network paths, and any other string whose value does not change based on the locale of the user's computer.

Culture-sensitive comparisons are typically used to compare and sort strings input by users with other strings input by users. The characters and sorting conventions of these strings might vary depending on the locale of the user's computer. Even strings that contain identical characters might sort differently depending on the culture of the current thread.

> [!NOTE]
> When you test for equality of strings, you should use the methods that explicitly specify what kind of comparison you intend to perform. Your code is much more maintainable and readable. Use the overloads of the methods of the <xref:System.String?displayProperty=nameWithType> and <xref:System.Array?displayProperty=nameWithType> classes that take a <xref:System.StringComparison> enumeration parameter. You specify which type of comparison to perform. Avoid using the `==` and `!=` operators when you test for equality. The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> instance methods always perform a case-sensitive and culture-sensitive comparison. They are primarily suited for ordering strings alphabetically.

## Ordinal comparison examples

The following example shows how to correctly compare strings whose sort order will not change based on the locale of the user's computer. It declares and initializes two string variables. The two strings are compared for equality using an ordinal comparison. Try it yourself to see that the two strings are not considered equal using an ordinal comparison.


The following code compares the two strings using a case insensitive ordinal comparison. Case-insensitive means "user" equals "User". The result is the same as comparing the value returned by <xref:System.String.ToUpperInvariant%2A?displayProperty=nameWithType> using an ordinal comparison. Run it to verify that the two strings are equal.

The <xref:System.String> class also contains static <xref:System.String.Equals%2A> methods you can use similar to the instance methods. The following code shows both case-sensitive and case-insensitive ordinal comparisons using the static methods: 

The following example demonstrates the *string interning* feature of C#. When a program declares two or more identical string variables, the compiler stores them all in the same location. By calling the <xref:System.Object.ReferenceEquals%2A> method, you can see that the two strings actually refer to the same object in memory. Use the <xref:System.String.Copy%2A?displayProperty=nameWithType> method to avoid interning. After the copy has been made, the two strings have different storage locations, even though they have the same value. Run the following sample to show that strings `a` and `b` are *interned* meaning they share the same storage. The strings `a` and `c` are not.

[!code-csharp-interactive[Demonstrating string interning](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#4)]

## Ordinal sorting and searching strings in arrays

The following examples show how to sort and search for strings in an array in a culture-sensitive manner by using the static <xref:System.Array> methods that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter.

This example shows how to search an array of strings using an ordinal search: 

[!code-csharp-interactive[Sorting an array of strings](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#5)]

Once the array is sorted, you can search for entries using a binary search. A binary search starts in the middle of the collection to determine which half of the collection would contain the sought string. Each subsequent comparison subdivides the remaining part of the collection in half. The following sample demonstrates the importance of using the same comparison rules for both sorting and searching. The array is sorted using <xref:System.StringComparer.Ordinal?displayProperty=nameWithType>. However, the search uses <xref:System.StringComparer.OrdinalIgnoreCase?displayProperty=nameWithType>. The local function `ShowWhere` displays information about where the string was found. If the string was not found, the returned value indicates where it would be if it were found.

[!code-csharp-interactive[Searching in a sorted array](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#6)]

## Case sensitive and culture sensitive sorting and searching in collections

The following code uses the <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> collection class to store strings. The strings are sorted using the <xref:System.Collections.Generic.List%601.Sort%2A?displayProperty=nameWithType> method. This method needs a delegate that compares and orders two strings. The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method provides that comparison function. Run the sample and observe the order. This sort operation is both case sensitive and culture sensitive. You would use the static <xref:System.String.Compare%2A?displayProperty=nameWithType> methods to specify different comparison rules.

[!code-csharp-interactive[Sorting a list of strings](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#7)]

Once sorted, the list of strings can be searched using a binary search. The following sample shows how to search the sorted listed using the same comparison function. The local function `ShowWhere` shows where the sought text is or would be:

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#8)]

Collection classes such as <xref:System.Collections.Hashtable?displayProperty=nameWithType>, <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>, and <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> have constructors that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter when the type of the elements or keys is `string`. In general, you should use these constructors whenever possible, and specify either <xref:System.StringComparer.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparer.OrdinalIgnoreCase?displayProperty=nameWithType>.

## Comparing across cultures

The following example shows several aspects of comparing strings across cultures. A string is initialized to the phrase "They dance in the street." in German. Linguistically (in Windows), "ss" is equal to the German essetz: 'ß' character in both "en-US" and "de-DE" cultures. This sample stores <xref:System.Globalization.CultureInfo> for the current culture. The original culture can be set and retrieved on the current thread object. The comparisons are performed using the <xref:System.StringComparison.CurrentCulture> value to ensure a culture-specific comparison.

The following example shows how to compare strings using the <xref:System.String?displayProperty=nameWithType> methods that take a <xref:System.StringComparison> enumeration. The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> instance methods are not used here, because overloads take a <xref:System.StringComparison>. Restrict your use of the <xref:System.String.CompareTo%2A?displayProperty=nameWithType> instance methods to when you want an alphabetic ordering. The host for the interactive REPL uses the **invariant culture**, which does not have a name. The sample uses the <xref:System.Globalization.CultureInfo.EnglishName?displayName=nameWithType> property to display a human readable string for this culture. 

[!code-csharp-interactive[Comparing strings across cultures](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#9)]

## See also
 <xref:System.Globalization.CultureInfo?displayProperty=nameWithType>  
 <xref:System.StringComparer?displayProperty=nameWithType>  
 [Strings](../programming-guide/strings/index.md)  
 [Comparing Strings](../../standard/base-types/comparing.md)  
 [Globalizing and Localizing Applications](/visualstudio/ide/globalizing-and-localizing-applications)