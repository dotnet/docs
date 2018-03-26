---
title: Query a collection of objects
description: How query collections.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 11/30/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: 87a76f8a-0b58-4791-90ea-2fe0a30416c9
---
# Query a collection of objects
This example shows how to perform a simple query over a list of `Student` objects. Each `Student` object contains some basic information about the student, and a list that represents the student's scores on four examinations.  
  
 This application serves as the framework for many other examples in this section that use the same `students` data source.  
  
## Example  
 The following query returns the students who received a score of 90 or greater on their first exam.  
  
 [!code-csharp[csProgGuideLINQ#15](../../../samples/snippets/csharp/concepts/linq/how-to-query-a-collection-of-objects_1.cs)]  
  
 This query is intentionally simple to enable you to experiment. For example, you can try more conditions in the `where` clause, or use an `orderby` clause to sort the results.  
  

## See also  
 [LINQ Query Expressions](index.md)  
 [String interpolation](../language-reference/tokens/interpolated.md)
