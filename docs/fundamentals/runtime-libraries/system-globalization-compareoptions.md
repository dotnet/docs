---
title: System.Globalization.CompareOptions enum
description: Learn more about the System.Globalization.CompareOptions enum.
ms.date: 12/28/2023
ms.topic: concept-article
---
# <xref:System.Globalization.CompareOptions> enum

[!INCLUDE [context](includes/context.md)]

The <xref:System.Globalization.CompareOptions> options denote case sensitivity or necessity to ignore types of characters.

.NET uses three distinct ways of sorting: word sort, string sort, and ordinal sort. Word sort performs a culture-sensitive comparison of strings. Certain nonalphanumeric characters might have special weights assigned to them. For example, the hyphen ("-") might have a very small weight assigned to it so that "coop" and "co-op" appear next to each other in a sorted list. String sort is similar to word sort, except that there are no special cases. Therefore, all nonalphanumeric symbols come before all alphanumeric characters. Ordinal sort compares strings based on the Unicode values of each element of the string. For a downloadable set of text files that contain information on the character weights used in sorting and comparison operations for Windows operating systems, see [Sorting Weight Tables](https://www.microsoft.com/download/details.aspx?id=10921). For the sort weight table for Linux and macOS, see the [Default Unicode Collation Element Table](https://www.unicode.org/Public/UCA/latest/allkeys.txt). The specific version of the sort weight table on Linux and macOS depends on the version of the [International Components for Unicode](https://icu.unicode.org/) libraries installed on the system. For information on ICU versions and the Unicode versions that they implement, see [Downloading ICU](https://icu.unicode.org/download).

The `StringSort` value can only be used with <xref:System.Globalization.CompareInfo.Compare%2A?displayProperty=nameWithType> and <xref:System.Globalization.CompareInfo.GetSortKey%2A?displayProperty=nameWithType>. <xref:System.ArgumentException> is thrown if the StringSort value is used with <xref:System.Globalization.CompareInfo.IsPrefix%2A?displayProperty=nameWithType>, <xref:System.Globalization.CompareInfo.IsSuffix%2A?displayProperty=nameWithType>, <xref:System.Globalization.CompareInfo.IndexOf%2A?displayProperty=nameWithType>, or <xref:System.Globalization.CompareInfo.LastIndexOf%2A?displayProperty=nameWithType>.

> [!NOTE]
> When possible, you should use string comparison methods that accept a <xref:System.Globalization.CompareOptions> value to specify the kind of comparison expected. As a general rule, user-facing comparisons are best served by the use of linguistic options (using the current culture), while security comparisons should specify `Ordinal` or `OrdinalIgnoreCase`.

## Culture-sensitive sorts

[!INCLUDE[platform-note](includes/c-and-posix-cultures.md)]
