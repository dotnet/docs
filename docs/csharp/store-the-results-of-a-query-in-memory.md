---
title: "Store the results of a query in memory"
description: How to store results.
keywords: .NET, .NET Core, C#
author: stevehoag
manager: wpickett
ms.author: wiwagn
ms.date: 11/30/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 5b863961-1750-4cf9-9607-acea5054d15a
---
# Store the results of a query in memory

A query is basically a set of instructions for how to retrieve and organize data. To execute the query requires a call to its <xref:System.Collections.Generic.IEnumerable%601.GetEnumerator%2A> method. This call is made when you use a `foreach` loop to iterate over the elements. To evaluate a query and store its results without executing a `foreach` loop, just call one of the following methods on the query variable:  
  
-   <xref:System.Linq.Enumerable.ToList%2A>  
  
-   <xref:System.Linq.Enumerable.ToArray%2A>  
  
-   <xref:System.Linq.Enumerable.ToDictionary%2A>  
  
-   <xref:System.Linq.Enumerable.ToLookup%2A>  
  
 We recommend that when you store the query results, you assign the returned collection object to a new variable as shown in the following example:  
  
## Example  
 [!code-cs[csProgGuideLINQ#25](../../samples/snippets/csharp/concepts/linq/how-to-store-the-results-of-a-query-in-memory_1.cs)]  
  

## See Also  
 [LINQ Query Expressions](programming-guide/linq-query-expressions/index.md)