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
- You can choose culture specific comparisons.
- Linguistic comparisions are culture and platform dependent.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

When you compare strings, you define an order among them. Comparisons are
used to sort a sequence of strings. Once the sequence is in a known order,
it is easier to search, both for software and for humans. Other comparisons
may check if strings are the same. These sameness checks are similar to
equality, but some differences, such as case differences, may be ignored.

## Default ordinal comparisons

The most common operations, <xref:System.String.CompareTo%2A?displayProperty=nameWithType> and
<xref:System.String.Equals%2A?displayProperty=nameWithType> or <xref:System.String.op_Equality%2A?displayProperty=nameWithType> use
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
enables you to specify a <xref:System.StringComparison> value of
<xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>
to specify a case-insensitive comparison. There is also a static
<xref:System.String.Compare%2A> method that includes a boolean argument to
specify case-insensitive comparisons. These are shown in the following code:

[!code-csharp-interactive[Comparing strings ignoring case](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#2)]

## Linguistic comparisons

Strings can also be ordered using linguistic rules for the current culture.
This is sometimes referred to as "word sort order." When you perform a
linguistic comparision, some nonalphanumeric Unicode characters might have
special weights assigned. For example, the hyphen "-" may have a very small
weight assigned to it so that "co-op" and "coop" appear next to each other
in sort order. In addition, some Unicode characters may be equivalent to a
sequence of alphanumeric characterss. The following example uses the phrase
"They dance in the street." in German with the "ss" and 'ß'. Linguistically
(in Windows), "ss" is equal to the German Essetz: 'ß' character in both "en-US"
and "de-DE" cultures. 

[!code-csharp-interactive[Comparing strings using linguistic rules](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#3)]

This sample demonstrates the operating system dependent nature of linguistic
comparisons. The host for the interactive window is a Linux host. The
linguistic and ordinal comparisons produce the same results. If you
ran this same sample on a Windows host, you would see the following output:

```console
<coop> is less than <co-op> using invariant culture
<coop> is greater than <co-op> using ordinal comparison
<coop> is less than <cop> using invariant culture
<coop> is less than <cop> using ordinal comparison
<co-op> is less than <cop> using invariant culture
<co-op> is less than <cop> using ordinal comparison
```

On Windows, the sort order of "cop", "coop", and "co-op" change when you
change from a linguistic comparison to an ordinal comparison. The two
German sentences also compare differently using the different comparison types.

## Comparisons using specific cultures

This sample stores <xref:System.Globalization.CultureInfo> for the current culture.
The original culture can be set and retrieved on the current thread object. The
comparisons are performed using the <xref:System.StringComparison.CurrentCulture>
value to ensure a culture-specific comparison.

The culture used affects linguistic comparisons. The following example
shows the results of comparing the two German sentences using the "en-US" culture
and the "de-DE" culture:

[!code-csharp-interactive[Comparing strings across cultures](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#4)]

Culture-sensitive comparisons are typically used to compare and sort strings input by users with other strings input by users. The characters and sorting conventions of these strings might vary depending on the locale of the user's computer. Even strings that contain identical characters might sort differently depending on the culture of the current thread. In addition, try this sample code locally on a Windows machine, and you will the following results:

```console
<coop> is less than <co-op> using en-US culture
<coop> is greater than <co-op> using ordinal comparison
<coop> is less than <cop> using en-US culture
<coop> is less than <cop> using ordinal comparison
<co-op> is less than <cop> using en-US culture
<co-op> is less than <cop> using ordinal comparison
```

Linguistic comparisions are dependent on the current culture, and are OS dependent. You must take that into account when you work with string comparisons.

## Linguistic sorting and searching strings in arrays

The following examples show how to sort and search for strings in an array using a linguistic comparison dependent on the current culture. You use the static <xref:System.Array> methods that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter.

This example shows how to sort an array of strings using the current culture: 

[!code-csharp-interactive[Sorting an array of strings](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#5)]

Once the array is sorted, you can search for entries using a binary search. A binary search starts in the middle of the collection to determine which half of the collection would contain the sought string. Each subsequent comparison subdivides the remaining part of the collection in half.  The array is sorted using <xref:System.StringComparer.CurrentCulture?displayProperty=nameWithType>. The local function `ShowWhere` displays information about where the string was found. If the string was not found, the returned value indicates where it would be if it were found.

[!code-csharp-interactive[Searching in a sorted array](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#6)]

## Ordinal sorting and searching in collections

The following code uses the <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> collection class to store strings. The strings are sorted using the <xref:System.Collections.Generic.List%601.Sort%2A?displayProperty=nameWithType> method. This method needs a delegate that compares and orders two strings. The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method provides that comparison function. Run the sample and observe the order. This sort operation uses an ordinal case sensitive sort. You would use the static <xref:System.String.Compare%2A?displayProperty=nameWithType> methods to specify different comparison rules.

[!code-csharp-interactive[Sorting a list of strings](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#7)]

Once sorted, the list of strings can be searched using a binary search. The following sample shows how to search the sorted listed using the same comparison function. The local function `ShowWhere` shows where the sought text is or would be:

[!code-csharp-interactive[csProgGuideStrings#11](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#8)]

Always make sure to use the same type of comparison for sorting and searching. Using different comparison types for sorting and searching produces unexpected results. 

Collection classes such as <xref:System.Collections.Hashtable?displayProperty=nameWithType>, <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>, and <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> have constructors that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter when the type of the elements or keys is `string`. In general, you should use these constructors whenever possible, and specify either <xref:System.StringComparer.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparer.OrdinalIgnoreCase?displayProperty=nameWithType>.

## Reference equality and string interning

None of the samples have used <xref:System.Object.ReferenceEquals%2A>. This method determines if two strings
are the same object. This can lead to inconsistent results in string comparisons. The following example demonstrates the *string interning* feature of C#. When a program declares two or more identical string variables, the compiler stores them all in the same location. By calling the <xref:System.Object.ReferenceEquals%2A> method, you can see that the two strings actually refer to the same object in memory. Use the <xref:System.String.Copy%2A?displayProperty=nameWithType> method to avoid interning. After the copy has been made, the two strings have different storage locations, even though they have the same value. Run the following sample to show that strings `a` and `b` are *interned* meaning they share the same storage. The strings `a` and `c` are not.

[!code-csharp-interactive[Demonstrating string interning](../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs#9)]

> [!NOTE]
> When you test for equality of strings, you should use the methods that explicitly specify what kind of comparison you intend to perform. Your code is much more maintainable and readable. Use the overloads of the methods of the <xref:System.String?displayProperty=nameWithType> and <xref:System.Array?displayProperty=nameWithType> classes that take a <xref:System.StringComparison> enumeration parameter. You specify which type of comparison to perform. Avoid using the `==` and `!=` operators when you test for equality. The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> instance methods always perform an ordinal case-sensitive comparison. They are primarily suited for ordering strings alphabetically.

## See also
 <xref:System.Globalization.CultureInfo?displayProperty=nameWithType>  
 <xref:System.StringComparer?displayProperty=nameWithType>  
 [Strings](../programming-guide/strings/index.md)  
 [Comparing Strings](../../standard/base-types/comparing.md)  
 [Globalizing and Localizing Applications](/visualstudio/ide/globalizing-and-localizing-applications)