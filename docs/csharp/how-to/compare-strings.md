---
title: "How to compare strings - C# Guide"
description: Learn how to compare and order string values, with or without case, with or without culture specific ordering
ms.date: 10/03/2018
helpviewer_keywords:
    - "strings [C#], comparison"
    - "comparing strings [C#]"
---

# How to compare strings in C\#

You compare strings to answer one of two questions: "Are these two strings
equal?" or "In what order should these strings be placed when sorting them?"

Those two questions are complicated by factors that affect string comparisons:

- You can choose an ordinal or linguistic comparison.
- You can choose if case matters.
- You can choose culture-specific comparisons.
- Linguistic comparisons are culture and platform-dependent.
[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

When you compare strings, you define an order among them. Comparisons are
used to sort a sequence of strings. Once the sequence is in a known order,
it is easier to search, both for software and for humans. Other comparisons
may check if strings are the same. These sameness checks are similar to
equality, but some differences, such as case differences, may be ignored.

## Default ordinal comparisons

By default, the most common operations:

- <xref:System.String.Equals%2A?displayProperty=nameWithType>
- <xref:System.String.op_Equality%2A?displayProperty=nameWithType> and <xref:System.String.op_Inequality%2A?displayProperty=nameWithType>, that is, [equality operators `==` and `!=`](../language-reference/operators/equality-operators.md#string-equality), respectively

perform a case-sensitive ordinal comparison, and in the case of <xref:System.String.Equals%2A?displayProperty=nameWithType> a <xref:System.StringComparison> argument can be provided to alter its sorting rules. The following example demonstrates that:

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet1":::

The default ordinal comparison doesn't take linguistic rules into account when comparing strings. It compares the binary value of each <xref:System.Char> object in two strings. As a result, the default ordinal comparison is also case-sensitive.

The test for equality with <xref:System.String.Equals%2A?displayProperty=nameWithType> and the `==` and `!=` operators differs from string comparison using the <xref:System.String.CompareTo%2A?displayProperty=nameWithType> and <xref:System.String.Compare(System.String,System.String)?displayProperty=nameWithType)> methods. While the tests for equality perform a case-sensitive ordinal comparison, the comparison methods perform a case-sensitive, culture-sensitive comparison using the current culture. Because the default comparison methods often perform different types of comparisons, we recommend that you always make the intent of your code clear by calling an overload that explicitly specifies the type of comparison to perform.

## Case-insensitive ordinal comparisons

The <xref:System.String.Equals(System.String,System.StringComparison)?displayProperty=nameWithType> method
enables you to specify a <xref:System.StringComparison> value of
<xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>
for a case-insensitive ordinal comparison. There is also a static
<xref:System.String.Compare(System.String,System.String,System.StringComparison)?displayProperty=nameWithType> method that performs a case-insensitive ordinal comparison if you specify a value of <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> for the <xref:System.StringComparison> argument. These are shown in the following code:

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet2":::

When performing a case-insensitive ordinal comparison, these methods use the casing conventions of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture).

## Linguistic comparisons

Strings can also be ordered using linguistic rules for the current culture.
This is sometimes referred to as "word sort order." When you perform a
linguistic comparison, some nonalphanumeric Unicode characters might have
special weights assigned. For example, the hyphen "-" may have a small
weight assigned to it so that "co-op" and "coop" appear next to each other
in sort order. In addition, some Unicode characters may be equivalent to a
sequence of <xref:System.Char> instances. The following example uses the phrase
"They dance in the street." in German with the "ss" (U+0073 U+0073) in one string and 'ß' (U+00DF) in another. Linguistically
(in Windows), "ss" is equal to the German Esszet: 'ß' character in both the "en-US"
and "de-DE" cultures.

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet3":::

This sample demonstrates the operating system-dependent nature of linguistic
comparisons. The host for the interactive window is a Linux host. The
linguistic and ordinal comparisons produce the same results. If you
run this same sample on a Windows host, you see the following output:

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

This sample stores <xref:System.Globalization.CultureInfo> objects for the en-US and de-DE cultures.
The comparisons are performed using a <xref:System.Globalization.CultureInfo> object to ensure a culture-specific comparison.

The culture used affects linguistic comparisons. The following example
shows the results of comparing the two German sentences using the "en-US" culture
and the "de-DE" culture:

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet4":::

Culture-sensitive comparisons are typically used to compare and sort strings input by users with other strings input by users. The characters and sorting conventions of these strings might vary depending on the locale of the user's computer. Even strings that contain identical characters might sort differently depending on the culture of the current thread. In addition, try this sample code locally on a Windows machine, and you'll get the following results:

```console
<coop> is less than <co-op> using en-US culture
<coop> is greater than <co-op> using ordinal comparison
<coop> is less than <cop> using en-US culture
<coop> is less than <cop> using ordinal comparison
<co-op> is less than <cop> using en-US culture
<co-op> is less than <cop> using ordinal comparison
```

Linguistic comparisons are dependent on the current culture, and are OS dependent. Take that into account when you work with string comparisons.

## Linguistic sorting and searching strings in arrays

The following examples show how to sort and search for strings in an array using a linguistic comparison dependent on the current culture. You use the static <xref:System.Array> methods that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter.

This example shows how to sort an array of strings using the current culture:

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet5":::

Once the array is sorted, you can search for entries using a binary search. A binary search starts in the middle of the collection to determine which half of the collection would contain the sought string. Each subsequent comparison subdivides the remaining part of the collection in half. The array is sorted using the <xref:System.StringComparer.CurrentCulture?displayProperty=nameWithType>. The local function `ShowWhere` displays information about where the string was found. If the string wasn't found, the returned value indicates where it would be if it were found.

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet6":::

## Ordinal sorting and searching in collections

The following code uses the <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> collection class to store strings. The strings are sorted using the <xref:System.Collections.Generic.List%601.Sort%2A?displayProperty=nameWithType> method. This method needs a delegate that compares and orders two strings. The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method provides that comparison function. Run the sample and observe the order. This sort operation uses an ordinal case-sensitive sort. You would use the static <xref:System.String.Compare%2A?displayProperty=nameWithType> methods to specify different comparison rules.

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet7":::

Once sorted, the list of strings can be searched using a binary search. The following sample shows how to search the sorted list using the same comparison function. The local function `ShowWhere` shows where the sought text is or would be:

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet8":::

Always make sure to use the same type of comparison for sorting and searching. Using different comparison types for sorting and searching produces unexpected results.

Collection classes such as <xref:System.Collections.Hashtable?displayProperty=nameWithType>, <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>, and <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> have constructors that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter when the type of the elements or keys is `string`. In general, you should use these constructors whenever possible, and specify either <xref:System.StringComparer.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparer.OrdinalIgnoreCase?displayProperty=nameWithType>.

## Reference equality and string interning

None of the samples have used <xref:System.Object.ReferenceEquals%2A>. This method determines if two strings
are the same object, which can lead to inconsistent results in string comparisons. The following example demonstrates the _string interning_ feature of C#. When a program declares two or more identical string variables, the compiler stores them all in the same location. By calling the <xref:System.Object.ReferenceEquals%2A> method, you can see that the two strings actually refer to the same object in memory. Use the <xref:System.String.Copy%2A?displayProperty=nameWithType> method to avoid interning. After the copy has been made, the two strings have different storage locations, even though they have the same value. Run the following sample to show that strings `a` and `b` are _interned_ meaning they share the same storage. The strings `a` and `c` are not.

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/CompareStrings.cs" id="Snippet9":::

> [!NOTE]
> When you test for equality of strings, you should use the methods that explicitly specify what kind of comparison you intend to perform. Your code is much more maintainable and readable. Use the overloads of the methods of the <xref:System.String?displayProperty=nameWithType> and <xref:System.Array?displayProperty=nameWithType> classes that take a <xref:System.StringComparison> enumeration parameter. You specify which type of comparison to perform. Avoid using the `==` and `!=` operators when you test for equality. The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> instance methods always perform an ordinal case-sensitive comparison. They are primarily suited for ordering strings alphabetically.

You can intern a string or retrieve a reference to an existing interned string by calling the <xref:System.String.Intern%2A?displayProperty=nameWithType> method. To determine whether a string is interned, call the <xref:System.String.IsInterned%2A?displayProperty=nameWithType> method.

## See also

- <xref:System.Globalization.CultureInfo?displayProperty=nameWithType>
- <xref:System.StringComparer?displayProperty=nameWithType>
- [Strings](../programming-guide/strings/index.md)
- [Comparing strings](../../standard/base-types/comparing.md)
- [Globalizing and localizing applications](/visualstudio/ide/globalizing-and-localizing-applications)
