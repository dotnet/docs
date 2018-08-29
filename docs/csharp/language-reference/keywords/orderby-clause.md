---
title: "orderby clause (C# Reference)"
ms.date: 07/20/2015
f1_keywords: 
  - "orderby"
  - "orderby_CSharpKeyword"
helpviewer_keywords: 
  - "orderby clause [C#]"
  - "orderby keyword [C#]"
ms.assetid: 21f87f48-d69d-4e95-9a52-6fec47b37e1f
---
# orderby clause (C# Reference)

In a query expression, the `orderby` clause causes the returned sequence or subsequence (group) to be sorted in either ascending or descending order. Multiple keys can be specified in order to perform one or more secondary sort operations. The sorting is performed by the default comparer for the type of the element. The default sort order is ascending. You can also specify a custom comparer. However, it is only available by using method-based syntax. For more information, see [Sorting Data](../../programming-guide/concepts/linq/sorting-data.md).

## Example

In the following example, the first query sorts the words in alphabetical order starting from A, and second query sorts the same words in descending order. (The `ascending` keyword is the default sort value and can be omitted.)

[!code-csharp[cscsrefQueryKeywords#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsCsrefQueryKeywords/CS/Orderby.cs#20)]

## Example

The following example performs a primary sort on the students' last names, and then a secondary sort on their first names.

[!code-csharp[cscsrefQueryKeywords#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsCsrefQueryKeywords/CS/Orderby.cs#22)]

## Remarks

At compile time, the `orderby` clause is translated to a call to the <xref:System.Linq.Enumerable.OrderBy%2A> method. Multiple keys in the `orderby` clause translate to <xref:System.Linq.Enumerable.ThenBy%2A> method calls.

## See also

- [C# Reference](../index.md)
- [Query Keywords (LINQ)](query-keywords.md)
- [Language Integrated Query (LINQ)](../../linq/index.md)
- [group clause](group-clause.md)
- [Getting Started with LINQ in C#](../../programming-guide/concepts/linq/getting-started-with-linq.md)