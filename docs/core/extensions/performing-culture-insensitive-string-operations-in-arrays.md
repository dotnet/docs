---
title: Perform culture-insensitive string operations in arrays
description: Learn how to perform culture-insensitive string operations in arrays.
ms.date: 03/13/2023
helpviewer_keywords:
    - "culture-insensitive string operations, in arrays"
    - "arrays [.NET], culture-insensitive string operations"
    - "comparer parameter"
ms.assetid: f12922e1-6234-4165-8896-63f0653ab478
---

# Perform culture-insensitive string operations in arrays

Overloads of the <xref:System.Array.Sort%2A?displayProperty=nameWithType> and <xref:System.Array.BinarySearch%2A?displayProperty=nameWithType> methods perform culture-sensitive sorts by default using the <xref:System.Threading.Thread.CurrentCulture%2A?displayProperty=nameWithType> property. Culture-sensitive results returned by these methods can vary by culture due to differences in sort orders. To eliminate culture-sensitive behavior, use one of the overloads of this method that accepts a `comparer` parameter. The `comparer` parameter specifies the <xref:System.Collections.IComparer> implementation to use when comparing elements in the array. For the parameter, specify a custom invariant comparer class that uses <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType>. An example of a custom invariant comparer class is provided in the "Using the SortedList Class" subtopic of the [Perform culture-insensitive string operations in collections](performing-culture-insensitive-string-operations-in-collections.md) topic.

> [!NOTE]
> Passing **CultureInfo.InvariantCulture** to a comparison method does perform a culture-insensitive comparison. However, it does not cause a non-linguistic comparison, for example, for file paths, registry keys, and environment variables. Neither does it support security decisions based on the comparison result. For a non-linguistic comparison or support for result-based security decisions, the application should use a comparison method that accepts a <xref:System.StringComparison> value. The application should then pass <xref:System.StringComparison.Ordinal>.

## See also

- <xref:System.Array.Sort%2A?displayProperty=nameWithType>
- <xref:System.Array.BinarySearch%2A?displayProperty=nameWithType>
- <xref:System.Collections.IComparer>
- [Perform culture-insensitive string operations](performing-culture-insensitive-string-operations.md)
