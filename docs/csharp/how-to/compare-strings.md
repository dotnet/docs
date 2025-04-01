---
title: "How to compare strings"
description: Learn how to compare and order string values, with or without case, with or without culture specific ordering.
ms.date: 02/18/2025
helpviewer_keywords:
    - "strings [C#], comparison"
    - "comparing strings [C#]"
---

# How to compare strings in C\#

You compare strings to answer one of two questions: "Are these two strings equal?" or "In what order should these strings be placed when sorting them?"

The following factors complicate these two questions:

- You can choose an ordinal or linguistic comparison.
- You can choose if case matters.
- You can choose culture-specific comparisons.
- Linguistic comparisons are culture and platform-dependent.

The <xref:System.StringComparison?displayProperty=fullName> enumeration fields represent these choices:

- **CurrentCulture**: Compare strings using culture-sensitive sort rules and the current culture.
- **CurrentCultureIgnoreCase**: Compare strings using culture-sensitive sort rules, the current culture, and ignoring the case of the strings being compared.
- **InvariantCulture**: Compare strings using culture-sensitive sort rules and the invariant culture.
- **InvariantCultureIgnoreCase**: Compare strings using culture-sensitive sort rules, the invariant culture, and ignoring the case of the strings being compared.
- **Ordinal**: Compare strings using ordinal (binary) sort rules.
- **OrdinalIgnoreCase**: Compare strings using ordinal (binary) sort rules and ignoring the case of the strings being compared.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

When you compare strings, you define an order among them. Comparisons are used to sort a sequence of strings. Once the sequence is in a known order, it's easier to search, both for software and for humans. Other comparisons might check if strings are the same. These sameness checks are similar to equality, but some differences, such as case differences, might be ignored.

## Default ordinal comparisons

By default, the most common operations:

- <xref:System.String.Equals%2A?displayProperty=nameWithType>
- <xref:System.String.op_Equality%2A?displayProperty=nameWithType> and <xref:System.String.op_Inequality%2A?displayProperty=nameWithType>, that is, [equality operators `==` and `!=`](../language-reference/operators/equality-operators.md#string-equality), respectively perform a case-sensitive, ordinal comparison. <xref:System.String.Equals%2A?displayProperty=nameWithType> has an overload where a <xref:System.StringComparison> argument can be provided to alter its sorting rules. The following example demonstrates that:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/CompareStrings.cs" id="Snippet1":::

The default ordinal comparison doesn't take linguistic rules into account when comparing strings. It compares the binary value of each <xref:System.Char> object in two strings. As a result, the default ordinal comparison is also case-sensitive.

The test for equality with <xref:System.String.Equals%2A?displayProperty=nameWithType> and the `==` and `!=` operators differs from string comparison using the <xref:System.String.CompareTo%2A?displayProperty=nameWithType> and <xref:System.String.Compare(System.String,System.String)?displayProperty=nameWithType)> methods. They all perform a case-sensitive comparison. However, while the tests for equality perform an ordinal comparison, the `CompareTo` and `Compare` methods perform a culture-aware linguistic comparison using the current culture. Make the intent of your code clear by calling an overload that explicitly specifies the type of comparison to perform.

You can use the [`is`](../language-reference/operators/is.md) operator and a [constant pattern](../language-reference/operators/patterns.md#constant-pattern) as an alternative to `==` when the right operand is a constant.

## Case-insensitive ordinal comparisons

The <xref:System.String.Equals(System.String,System.StringComparison)?displayProperty=nameWithType> method enables you to specify a <xref:System.StringComparison> value of
<xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> for a case-insensitive ordinal comparison. There's also a static <xref:System.String.Compare(System.String,System.String,System.StringComparison)?displayProperty=nameWithType> method that performs a case-insensitive ordinal comparison if you specify a value of <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> for the <xref:System.StringComparison> argument. These comparisons are shown in the following code:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/CompareStrings.cs" id="Snippet2":::

These methods use the casing conventions of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture) when performing a case-insensitive ordinal comparison.

## Linguistic comparisons

Many string comparison methods (such as <xref:System.String.StartsWith%2A?displayProperty=nameWithType>) use linguistic rules for the _current culture_ by default to order their inputs. This linguistic comparison is sometimes referred to as "word sort order." When you perform a linguistic comparison, some nonalphanumeric Unicode characters might have special weights assigned. For example, the hyphen "-" might have a small weight assigned to it so that "co-op" and "coop" appear next to each other in sort order. Some nonprinting control characters might be ignored. In addition, some Unicode characters might be equivalent to a sequence of <xref:System.Char> instances. The following example uses the phrase "They dance in the street." in German with the "ss" (U+0073 U+0073) in one string and 'ß' (U+00DF) in another. Linguistically (in Windows), "ss" is equal to the German Esszet: 'ß' character in both the "en-US" and "de-DE" cultures.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/CompareStrings.cs" id="Snippet3":::

On Windows, before .NET 5, the sort order of "cop", "coop", and "co-op" changes when you change from a linguistic comparison to an ordinal comparison. The two German sentences also compare differently using the different comparison types. Before .NET 5, the .NET globalization APIs used [National Language Support (NLS)](/windows/win32/intl/national-language-support) libraries. In .NET 5 and later versions, the .NET globalization APIs use [International Components for Unicode (ICU)](https://icu.unicode.org/) libraries, which unify .NET's globalization behavior across all supported operating systems.

## Comparisons using specific cultures

The following example stores <xref:System.Globalization.CultureInfo> objects for the en-US and de-DE cultures. The comparisons are performed using a <xref:System.Globalization.CultureInfo> object to ensure a culture-specific comparison. The culture used affects linguistic comparisons. The following example shows the results of comparing the two German sentences using the "en-US" culture and the "de-DE" culture:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/CompareStrings.cs" id="Snippet4":::

Culture-sensitive comparisons are typically used to compare and sort strings input by users with other strings input by users. The characters and sorting conventions of these strings might vary depending on the locale of the user's computer. Even strings that contain identical characters might sort differently depending on the culture of the current thread.

## Linguistic sorting and searching strings in arrays

The following examples show how to sort and search for strings in an array using a linguistic comparison dependent on the current culture. You use the static <xref:System.Array> methods that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter.

The following example shows how to sort an array of strings using the current culture:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/CompareStrings.cs" id="Snippet5":::

Once the array is sorted, you can search for entries using a binary search. A binary search starts in the middle of the collection to determine which half of the collection would contain the sought string. Each subsequent comparison subdivides the remaining part of the collection in half. The array is sorted using the <xref:System.StringComparer.CurrentCulture?displayProperty=nameWithType>. The local function `ShowWhere` displays information about where the string was found. If the string wasn't found, the returned value indicates where it would be if it were found.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/CompareStrings.cs" id="Snippet6":::

## Ordinal sorting and searching in collections

The following code uses the <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> collection class to store strings. The strings are sorted using the <xref:System.Collections.Generic.List%601.Sort%2A?displayProperty=nameWithType> method. This method needs a delegate that compares and orders two strings. The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method provides that comparison function. Run the sample and observe the order. This sort operation uses an ordinal case-sensitive sort. You would use the static <xref:System.String.Compare%2A?displayProperty=nameWithType> methods to specify different comparison rules.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/CompareStrings.cs" id="Snippet7":::

Once sorted, the list of strings can be searched using a binary search. The following sample shows how to search the sorted list using the same comparison function. The local function `ShowWhere` shows where the sought text is or would be:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/CompareStrings.cs" id="Snippet8":::

Always make sure to use the same type of comparison for sorting and searching. Using different comparison types for sorting and searching produces unexpected results.

Collection classes such as <xref:System.Collections.Hashtable?displayProperty=nameWithType>, <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>, and <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> have constructors that take a <xref:System.StringComparer?displayProperty=nameWithType> parameter when the type of the elements or keys is `string`. In general, you should use these constructors whenever possible, and specify either <xref:System.StringComparer.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparer.OrdinalIgnoreCase?displayProperty=nameWithType>.

## See also

- <xref:System.Globalization.CultureInfo?displayProperty=nameWithType>
- <xref:System.StringComparer?displayProperty=nameWithType>
- [Strings](../programming-guide/strings/index.md)
- [Comparing strings](../../standard/base-types/comparing.md)
- [Globalizing and localizing applications](/visualstudio/ide/globalizing-and-localizing-applications)
