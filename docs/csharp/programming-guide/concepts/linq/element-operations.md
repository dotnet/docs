---
title: "Element operations (C#)"
description: Learn about the standard query operator methods that do element operations, which return a single element from a sequence in C#.
ms.date: 09/07/2021
ms.assetid: 283206c9-3246-4c48-b01a-d9de409a7231
---

# Element operations (C#)

Element operations return a single, specific element from a sequence.

The standard query operator methods that perform element operations are listed in the following section.

## Methods

| Method name | Description | C# query expression syntax | More information |
|--|--|--|--|
| ElementAt | Returns the element at a specified index in a collection. | Not applicable. | <xref:System.Linq.Enumerable.ElementAt%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.ElementAt%2A?displayProperty=nameWithType> |
| ElementAtOrDefault | Returns the element at a specified index in a collection or a default value if the index is out of range. | Not applicable. | <xref:System.Linq.Enumerable.ElementAtOrDefault%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.ElementAtOrDefault%2A?displayProperty=nameWithType> |
| First | Returns the first element of a collection, or the first element that satisfies a condition. | Not applicable. | <xref:System.Linq.Enumerable.First%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.First%2A?displayProperty=nameWithType> |
| FirstOrDefault | Returns the first element of a collection, or the first element that satisfies a condition. Returns a default value if no such element exists. | Not applicable. | <xref:System.Linq.Enumerable.FirstOrDefault%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.FirstOrDefault%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.FirstOrDefault%60%601%28System.Linq.IQueryable%7B%60%600%7D%29?displayProperty=nameWithType> |
| Last | Returns the last element of a collection, or the last element that satisfies a condition. | Not applicable. | <xref:System.Linq.Enumerable.Last%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.Last%2A?displayProperty=nameWithType> |
| LastOrDefault | Returns the last element of a collection, or the last element that satisfies a condition. Returns a default value if no such element exists. | Not applicable. | <xref:System.Linq.Enumerable.LastOrDefault%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.LastOrDefault%2A?displayProperty=nameWithType> |
| Single | Returns the only element of a collection or the only element that satisfies a condition. Throws an <xref:System.InvalidOperationException> if there is no element or more than one element to return. | Not applicable. | <xref:System.Linq.Enumerable.Single%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.Single%2A?displayProperty=nameWithType> |
| SingleOrDefault | Returns the only element of a collection or the only element that satisfies a condition. Returns a default value if there is no element to return. Throws an <xref:System.InvalidOperationException> if there is more than one element to return. | Not applicable. | <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType><br /> <xref:System.Linq.Queryable.SingleOrDefault%2A?displayProperty=nameWithType> |

## See also

- <xref:System.Linq>
- [Standard Query Operators Overview (C#)](./standard-query-operators-overview.md)
- [How to query for the largest file or files in a directory tree (LINQ) (C#)](./how-to-query-for-the-largest-file-or-files-in-a-directory-tree-linq.md)
