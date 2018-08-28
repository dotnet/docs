---
title: Order the results of a join clause (LINQ in C#)
description: Learn how to order the results of a LINQ join clause in C#.
ms.date: 12/1/2016
ms.assetid: a7458901-1201-4c25-b8d9-c04ca52e0eb9
---
# Order the results of a join clause

This example shows how to order the results of a join operation. Note that the ordering is performed after the join. Although you can use an `orderby` clause with one or more of the source sequences before the join, generally we do not recommend it. Some LINQ providers might not preserve that ordering after the join.

## Example

This query creates a group join, and then sorts the groups based on the category element, which is still in scope. Inside the anonymous type initializer, a sub-query orders all the matching elements from the products sequence.

[!code-csharp[csProgGuideLINQ#81](~/samples/snippets/csharp/concepts/linq/how-to-order-the-results-of-a-join-clause_1.cs)]

## See also

- [Language Integrated Query (LINQ)](index.md)  
- [orderby clause](../language-reference/keywords/orderby-clause.md)  
- [join clause](../language-reference/keywords/join-clause.md)  