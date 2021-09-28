---
description: "Learn more about: Group Join Clause (Visual Basic)"
title: "Group Join Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.QueryGroupJoinIn"
  - "vb.QueryGroupJoinOn"
  - "vb.QueryGroupJoin"
  - "vb.QueryGroupJoinInto"
helpviewer_keywords: 
  - "Group Join clause [Visual Basic]"
  - "Group Join statement [Visual Basic]"
  - "queries [Visual Basic], Group Join"
ms.assetid: 37dbf79c-7b5c-421b-bbb7-dadfd2b92a1c
---
# Group Join Clause (Visual Basic)

Combines two collections into a single hierarchical collection. The join operation is based on matching keys.  
  
## Syntax  
  
```vb  
Group Join element [As type] In collection _  
  On key1 Equals key2 [ And key3 Equals key4 [... ] ] _  
  Into expressionList  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`element`|Required. The control variable for the collection being joined.|  
|`type`|Optional. The type of `element`. If no `type` is specified, the type of `element` is inferred from `collection`.|  
|`collection`|Required. The collection to combine with the collection that is on the left side of the `Group Join` operator. A `Group Join` clause can be nested in a `Join` clause or in another `Group Join` clause.|  
|`key1` `Equals` `key2`|Required. Identifies keys for the collections being joined. You must use the `Equals` operator to compare keys from the collections being joined. You can combine join conditions by using the `And` operator to identify multiple keys. The `key1` parameter must be from the collection on the left side of the `Join` operator. The `key2` parameter must be from the collection on the right side of the `Join` operator.<br /><br /> The keys used in the join condition can be expressions that include more than one item from the collection. However, each key expression can contain only items from its respective collection.|  
|`expressionList`|Required. One or more expressions that identify how the groups of elements from the collection are aggregated. To identify a member name for the grouped results, use the `Group` keyword (`<alias> = Group`). You can also include aggregate functions to apply to the group.|  
  
## Remarks  

 The `Group Join` clause combines two collections based on matching key values from the collections being joined. The resulting collection can contain a member that references a collection of elements from the second collection that match the key value from the first collection. You can also specify aggregate functions to apply to the grouped elements from the second collection. For information about aggregate functions, see [Aggregate Clause](aggregate-clause.md).  
  
 Consider, for example, a collection of managers and a collection of employees. Elements from both collections have a ManagerID property that identifies the employees that report to a particular manager. The results from a join operation would contain a result for each manager and employee with a matching ManagerID value. The results from a `Group Join` operation would contain the complete list of managers. Each manager result would have a member that referenced the list of employees that were a match for the specific manager.  
  
 The collection resulting from a `Group Join` operation can contain any combination of values from the collection identified in the `From` clause and the expressions identified in the `Into` clause of the `Group Join` clause. For more information about valid expressions for the `Into` clause, see [Aggregate Clause](aggregate-clause.md).  
  
 A `Group Join` operation will return all results from the collection identified on the left side of the `Group Join` operator. This is true even if there are no matches in the collection being joined. This is like a `LEFT OUTER JOIN` in SQL.  
  
 You can use the `Join` clause to combine collections into a single collection. This is equivalent to an `INNER JOIN` in SQL.  
  
## Example  

 The following code example joins two collections by using the `Group Join` clause.  
  
 [!code-vb[VbSimpleQuerySamples#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#14)]  
  
## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](index.md)
- [Select Clause](select-clause.md)
- [From Clause](from-clause.md)
- [Join Clause](join-clause.md)
- [Where Clause](where-clause.md)
- [Group By Clause](group-by-clause.md)
