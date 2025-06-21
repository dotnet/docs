---
title: System.Globalization.SortKey class
description: Learn more about the System.Globalization.SortKey class.
ms.date: 12/28/2023
ms.topic: concept-article
---
# <xref:System.Globalization.SortKey> class

[!INCLUDE [context](includes/context.md)]

A culture-sensitive comparison of two strings depends on each character in the strings having several categories of sort weights, including script, alphabetic, case, and diacritic weights. A sort key serves as the repository of these weights for a particular string.

The <xref:System.Globalization.CompareInfo.GetSortKey%2A?displayProperty=nameWithType> method returns an instance of the <xref:System.Globalization.SortKey> class that reflects the culture-sensitive mapping of characters in a specified string. The value of a <xref:System.Globalization.SortKey> object is its key data, which is returned by the <xref:System.Globalization.SortKey.KeyData%2A> property. This key data consists of a series of bytes that encode the string, culture-specific sorting rules, and user-specified comparison options. A comparison using sort keys consists of a bitwise comparison of the corresponding key data in each sort key. For example, if you create a sort key by calling the <xref:System.Globalization.CompareInfo.GetSortKey%28System.String%2CSystem.Globalization.CompareOptions%29> method with a value of <xref:System.Globalization.CompareOptions.IgnoreCase?displayProperty=nameWithType>, a string comparison operation that uses the sort key is case-insensitive.

After you create a sort key for a string, you compare sort keys by calling the static <xref:System.Globalization.SortKey.Compare%2A?displayProperty=nameWithType> method. This method performs a simple byte-by-byte comparison, so it is much faster than the <xref:System.String.Compare%2A?displayProperty=nameWithType> or <xref:System.Globalization.CompareInfo.Compare%2A?displayProperty=nameWithType> method.

> [!NOTE]
> You can download the [Sorting Weight Tables](https://www.microsoft.com/download/details.aspx?id=10921), a set of text files that contain information on the character weights used in sorting and comparison operations for Windows operating systems, the [Default Unicode Collation Element Table](https://www.unicode.org/Public/UCA/latest/allkeys.txt), the sort weight table for Linux and macOS.

## Performance considerations

When performing a string comparison, the <xref:System.Globalization.SortKey.Compare%2A> and <xref:System.Globalization.CompareInfo.Compare%2A?displayProperty=nameWithType> methods yield the same results, but they target different scenarios.

At a high level, the <xref:System.Globalization.CompareInfo.Compare%2A?displayProperty=nameWithType> method generates the sort key for each string, performs the comparison, and then discards the sort key and returns the result of the comparison. However, the <xref:System.Globalization.CompareInfo.Compare%2A?displayProperty=nameWithType> method actually doesn't generate an entire sort key to perform the comparison. Instead, the method generates the key data for each text element (that is, base character, surrogate pair, or combining character sequence) in each string. The method then compares the key data for the corresponding text elements. The operation terminates as soon as the ultimate result of the comparison is determined. Sort key information is computed, but no <xref:System.Globalization.SortKey> object is created. This strategy is economical in terms of performance if both strings are compared once, but becomes expensive if the same strings are compared many times.

The <xref:System.Globalization.SortKey.Compare%2A> method requires generation of a <xref:System.Globalization.SortKey> object for each string before performing the comparison. This strategy is expensive in terms of performance for the first comparison because of the time and memory invested to generate the <xref:System.Globalization.SortKey> objects. However, it becomes economical if the same sort keys are compared many times.

For example, suppose you write an application that searches a database table for the row in which the string-based index column matches a specified search string. The table contains thousands of rows, and comparing the search string to the index in each row will take a long time. Therefore, when the application stores a row and its index column, it also generates and stores the sort key for the index in a column dedicated to improving search performance. When the application searches for a target row, it compares the sort key for the search string to the sort key for the index string, instead of comparing the search string to the index string.

## Security considerations

The <xref:System.Globalization.CompareInfo.GetSortKey%28System.String%2CSystem.Globalization.CompareOptions%29?displayProperty=nameWithType> method returns a <xref:System.Globalization.SortKey> object with the value based on a specified string and <xref:System.Globalization.CompareOptions> value, and the culture associated with the underlying <xref:System.Globalization.CompareInfo> object. If a security decision depends on a string comparison or case change, you should use the <xref:System.Globalization.CompareInfo.GetSortKey%28System.String%2CSystem.Globalization.CompareOptions%29?displayProperty=nameWithType> method of the invariant culture to ensure that the behavior of the operation is consistent, regardless of the culture settings of the operating system.

Use the following steps to obtain a sort key:

1. Retrieve the invariant culture from the <xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType> property.

2. Retrieve a <xref:System.Globalization.CompareInfo> object for the invariant culture from the <xref:System.Globalization.CultureInfo.CompareInfo%2A?displayProperty=nameWithType> property.

3. Call the <xref:System.Globalization.CompareInfo.GetSortKey%28System.String%2CSystem.Globalization.CompareOptions%29?displayProperty=nameWithType> method.

Working with the value of a <xref:System.Globalization.SortKey> object is equivalent to calling the Windows `LCMapString` method with the LCMAP_SORTKEY value specified. However, for the <xref:System.Globalization.SortKey> object, the sort keys for English characters precede the sort keys for Korean characters.

<xref:System.Globalization.SortKey> objects can be serialized, but only so that they can cross <xref:System.AppDomain> objects. If an application serializes a <xref:System.Globalization.SortKey> object, the application must regenerate all the sort keys when there is a new version of .NET.

For more information about sort keys, see Unicode Technical Standard #10, "Unicode Collation Algorithm" on the [Unicode Consortium website](https://go.microsoft.com/fwlink/?linkid=37123).
