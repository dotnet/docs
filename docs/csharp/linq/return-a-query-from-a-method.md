---
title: Return a query from a method
description: How to return a query.
ms.date: 11/30/2016
ms.assetid: db220f79-c35b-41f2-886c-cd068672d42d
---
# How to return a query from a method (C# Programming Guide)

This example shows how to return a query from a method as the return value and as an `out` parameter.  
  
 Query objects are composable, meaning that you can return a query from a method. Objects that represent queries do not store the resulting collection, but rather the steps to produce the results when needed. The advantage of returning query objects from methods is that they can be further composed or modified. Therefore any return value or `out` parameter of a method that returns a query must also have that type. If a method materializes a query into a concrete <xref:System.Collections.Generic.List%601> or <xref:System.Array> type, it is considered to be returning the query results instead of the query itself. A query variable that is returned from a method can still be composed or modified.  
  
## Example  

 In the following example, the first method returns a query as a return value, and the second method returns a query as an `out` parameter. Note that in both cases it is a query that is  returned, not query results.  
  
 [!code-csharp[csProgGuideLINQ#80](~/samples/snippets/csharp/concepts/linq/how-to-return-a-query-from-a-method_1.cs)]  

## See also

- [Language Integrated Query (LINQ)](index.md)
