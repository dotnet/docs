---
description: "Learn more about: Performing culture-insensitive string operations"
title: "Performing Culture-Insensitive String Operations"
ms.date: 08/11/2021
helpviewer_keywords:
    - "case mappings"
    - "custom case mappings"
    - "culture, custom sorting rules"
    - "custom sorting rules"
    - "culture-insensitive string operations, options for performing"
    - "culture, custom case mappings"
    - "culture-insensitive string operations, method overloads"
ms.assetid: 579ef891-1f83-4c63-9ebd-2f40406b5b91
---

# Performing culture-insensitive string operations

Most .NET methods that perform culture-sensitive string operations by default provide method overloads that allow you to explicitly specify the culture to use by passing a <xref:System.Globalization.CultureInfo> parameter. These overloads allow you to eliminate cultural variations in case mappings and sorting rules and guarantee culture-insensitive results.

This section provides the following articles to demonstrate how to perform culture-insensitive string operations using .NET methods that are culture-sensitive by default.

## In this section

[Performing Culture-Insensitive String Comparisons](performing-culture-insensitive-string-comparisons.md)  
 Describes how to use the <xref:System.String.Compare%2A?displayProperty=nameWithType> and <xref:System.String.CompareTo%2A?displayProperty=nameWithType> methods to perform culture-insensitive string comparisons.

[Performing Culture-Insensitive Case Changes](performing-culture-insensitive-case-changes.md)  
 Describes how to use the <xref:System.String.ToUpper%2A?displayProperty=nameWithType>, <xref:System.String.ToLower%2A?displayProperty=nameWithType>, <xref:System.Char.ToUpper%2A?displayProperty=nameWithType>, and <xref:System.Char.ToLower%2A?displayProperty=nameWithType> methods to perform culture-insensitive case changes.

[Performing Culture-Insensitive String Operations in Collections](performing-culture-insensitive-string-operations-in-collections.md)  
 Describes how to use the <xref:System.Collections.CaseInsensitiveComparer>, <xref:System.Collections.CaseInsensitiveHashCodeProvider> class, <xref:System.Collections.SortedList>, <xref:System.Collections.ArrayList.Sort%2A?displayProperty=nameWithType> and <xref:System.Collections.Specialized.CollectionsUtil.CreateCaseInsensitiveHashtable%2A?displayProperty=nameWithType> to perform culture-insensitive operations in collections.

[Performing Culture-Insensitive String Operations in Arrays](performing-culture-insensitive-string-operations-in-arrays.md)  
 Describes how to use the <xref:System.Array.Sort%2A?displayProperty=nameWithType> and <xref:System.Array.BinarySearch%2A?displayProperty=nameWithType> methods to perform culture-insensitive operations in arrays.

## Related sections

[Culture-Insensitive String Operations](culture-insensitive-string-operations.md)  
 Describes why you should be aware of culture when performing operations on strings and provides guidelines for when to perform culture-sensitive operations and when to perform culture-insensitive operations.

## See also

- [Sorting Weight Tables (for .NET on Windows systems)](https://www.microsoft.com/download/details.aspx?id=10921)
- [Default Unicode Collation Element Table (for .NET Core on Linux and macOS)](https://www.unicode.org/Public/UCA/latest/allkeys.txt)
