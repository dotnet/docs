---
title: Perform custom join operations
description: How to perform custom join operations.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 12/1/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: 56a2a4a5-7299-497d-b3c3-23c848678911
---
# Perform custom join operations

This example shows how to perform join operations that are not possible with the `join` clause. In a query expression, the `join` clause is limited to, and optimized for, equijoins, which are by far the most common type of join operation. When performing an equijoin, you will probably always get the best performance by using the `join` clause.  
  
 However, the `join` clause cannot be used in the following cases:  
  
-   When the join is predicated on an expression of inequality (a non-equijoin).  
  
-   When the join is predicated on more than one expression of equality or inequality.  
  
-   When you have to introduce a temporary range variable for the right side (inner) sequence before the join operation.  
  
 To perform joins that are not equijoins, you can use multiple `from` clauses to introduce each data source independently. You then apply a predicate expression in a `where` clause to the range variable for each source. The expression also can take the form of a method call.  
  
> [!NOTE]
>  Do not confuse this kind of custom join operation with the use of multiple `from` clauses to access inner collections. For more information, see [join clause](../language-reference/keywords/join-clause.md).  
  
## Example  
 The first method in the following example shows a simple cross join. Cross joins must be used with caution because they can produce very large result sets. However, they can be useful in some scenarios for creating source sequences against which additional queries are run.  
  
 The second method produces a sequence of all the products whose category ID is listed in the category list on the left side. Note the use of the `let` clause and the `Contains` method to create a temporary array. It also is possible to create the array before the query and eliminate the first `from` clause.  
  
 [!code-csharp[csProgGuideLINQ#64](../../../samples/snippets/csharp/concepts/linq/how-to-perform-custom-join-operations_1.cs)]  
  
## Example  
 In the following example, the query must join two sequences based on matching keys that, in the case of the inner (right side) sequence, cannot be obtained prior to the join clause itself. If this join were performed with a `join` clause, then the `Split` method would have to be called for each element. The use of multiple `from` clauses enables the query to avoid the overhead of the repeated method call. However, since `join` is optimized, in this particular case it might still be faster than using multiple `from` clauses. The results will vary depending primarily on how expensive the method call is.  
  
 [!code-csharp[csProgGuideLINQ#13](../../../samples/snippets/csharp/concepts/linq/how-to-perform-custom-join-operations_2.cs)]  
  
## See also  
 [LINQ query expressions](index.md)  
 [join clause](../language-reference/keywords/join-clause.md)  
 [Order the results of a join clause](order-the-results-of-a-join-clause.md)
