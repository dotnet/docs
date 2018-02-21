---
title: "From Clause (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.QueryFrom"
  - "vb.QueryFromIn"
  - "vb.QueryFromLet"
helpviewer_keywords: 
  - "queries [Visual Basic], From"
  - "From clause [Visual Basic]"
  - "From statement [Visual Basic]"
ms.assetid: 83e3665e-68a0-4540-a3a3-3d777a0f95d5
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# From Clause (Visual Basic)
Specifies one or more range variables and a collection to query.  
  
## Syntax  
  
```  
From element [ As type ] In collection [ _ ]  
  [, element2 [ As type2 ] In collection2 [, ... ] ]  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`element`|Required. A *range variable* used to iterate through the elements of the collection. A range variable is used to refer to each member of the `collection` as the query iterates through the `collection`. Must be an enumerable type.|  
|`type`|Optional. The type of `element`. If no `type` is specified, the type of `element` is inferred from `collection`.|  
|`collection`|Required. Refers to the collection to be queried. Must be an enumerable type.|  
  
## Remarks  
 The `From` clause is used to identify the source data for a query and the variables that are used to refer to an element from the source collection. These variables are called *range variables*. The `From` clause is required for a query, except when the `Aggregate` clause is used to identify a query that returns only aggregated results. For more information, see [Aggregate Clause](../../../visual-basic/language-reference/queries/aggregate-clause.md).  
  
 You can specify multiple `From` clauses in a query to identify multiple collections to be joined. When multiple collections are specified, they are iterated over independently, or you can join them if they are related. You can join collections implicitly by using the `Select` clause, or explicitly by using the `Join` or `Group Join` clauses. As an alternative, you can specify multiple range variables and collections in a single `From` clause, with each related range variable and collection separated from the others by a comma. The following code example shows both syntax options for the `From` clause.  
  
 [!code-vb[VbSimpleQuerySamples#21](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/from-clause_1.vb)]  
  
 The `From` clause defines the scope of a query, which is similar to the scope of a `For` loop. Therefore, each `element` range variable in the scope of a query must have a unique name. Because you can specify multiple `From` clauses for a query, subsequent `From` clauses can refer to range variables in the `From` clause, or they can refer to range variables in a previous `From` clause. For example, the following example shows a nested `From` clause where the collection in the second clause is based on a property of the range variable in the first clause.  
  
 [!code-vb[VbSimpleQuerySamples#22](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/from-clause_2.vb)]  
  
 Each `From` clause can be followed by any combination of additional query clauses to refine the query. You can refine the query in the following ways:  
  
-   Combine multiple collections implicitly by using the `From` and `Select` clauses, or explicitly by using the `Join` or `Group Join` clauses.  
  
-   Use the `Where` clause to filter the query result.  
  
-   Sort the result by using the `Order By` clause.  
  
-   Group similar results together by using the `Group By` clause.  
  
-   Use the `Aggregate` clause to identify aggregate functions to evaluate for the whole query result.  
  
-   Use the `Let` clause to introduce an iteration variable whose value is determined by an expression instead of a collection.  
  
-   Use the `Distinct` clause to ignore duplicate query results.  
  
-   Identify parts of the result to return by using the `Skip`, `Take`, `Skip While`, and `Take While` clauses.  
  
## Example  
 The following query expression uses a `From` clause to declare a range variable `cust` for each `Customer` object in the `customers` collection. The `Where` clause uses the range variable to restrict the output to customers from the specified region. The `For Each` loop displays the company name for each customer in the query result.  
  
 [!code-vb[VbSimpleQuerySamples#23](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/from-clause_3.vb)]  
  
## See Also  
 [Queries](../../../visual-basic/language-reference/queries/queries.md)  
 [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [For Each...Next Statement](../../../visual-basic/language-reference/statements/for-each-next-statement.md)  
 [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md)  
 [Select Clause](../../../visual-basic/language-reference/queries/select-clause.md)  
 [Where Clause](../../../visual-basic/language-reference/queries/where-clause.md)  
 [Aggregate Clause](../../../visual-basic/language-reference/queries/aggregate-clause.md)  
 [Distinct Clause](../../../visual-basic/language-reference/queries/distinct-clause.md)  
 [Join Clause](../../../visual-basic/language-reference/queries/join-clause.md)  
 [Group Join Clause](../../../visual-basic/language-reference/queries/group-join-clause.md)  
 [Order By Clause](../../../visual-basic/language-reference/queries/order-by-clause.md)  
 [Let Clause](../../../visual-basic/language-reference/queries/let-clause.md)  
 [Skip Clause](../../../visual-basic/language-reference/queries/skip-clause.md)  
 [Take Clause](../../../visual-basic/language-reference/queries/take-clause.md)  
 [Skip While Clause](../../../visual-basic/language-reference/queries/skip-while-clause.md)  
 [Take While Clause](../../../visual-basic/language-reference/queries/take-while-clause.md)
