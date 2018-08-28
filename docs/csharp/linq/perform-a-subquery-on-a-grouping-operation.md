---
title: Perform a subquery on a grouping operation (LINQ in C#)
description: How to perform a subquery on a grouping operation using LINQ in C#.
ms.date: 12/1/2016
ms.assetid: d75a588e-9b6f-4f37-b195-f99ec8503855
---
# Perform a subquery on a grouping operation

This article shows two different ways to create a query that orders the source data into groups, and then performs a subquery over each group individually. The basic technique in each example is to group the source elements by using a *continuation* named `newGroup`, and then generating a new subquery against `newGroup`. This subquery is run against each new group that is created by the outer query. Note that in this particular example the final output is not a group, but a flat sequence of anonymous types.  
  
For more information about how to group, see [group clause](../language-reference/keywords/group-clause.md).  
  
For more information about continuations, see [into](../language-reference/keywords/into.md). The following example uses an in-memory data structure as the data source, but the same principles apply for any kind of LINQ data source.  
  
## Example

> [!NOTE]
> This example contains references to objects that are defined in the sample code in [Query a collection of objects](query-a-collection-of-objects.md).

[!code-csharp[csProgGuideLINQ#23](~/samples/snippets/csharp/concepts/linq/how-to-perform-a-subquery-on-a-grouping-operation_1.cs)]  

## See also

- [Language Integrated Query (LINQ)](index.md)
