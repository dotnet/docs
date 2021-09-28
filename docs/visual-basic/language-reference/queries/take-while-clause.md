---
description: "Learn more about: Take While Clause (Visual Basic)"
title: "Take While Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.QueryTakeWhile"
helpviewer_keywords: 
  - "queries [Visual Basic], Take While"
  - "Take While clause [Visual Basic]"
  - "Take While statement [Visual Basic]"
ms.assetid: db8f9f2f-fc9f-4a6c-b0b8-1bf048147e11
---
# Take While Clause (Visual Basic)

Includes elements in a collection as long as a specified condition is `true` and bypasses the remaining elements.  
  
## Syntax  
  
```vb  
Take While expression  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`expression`|Required. An expression that represents a condition to test elements for. The expression must return a `Boolean` value or a functional equivalent, such as an `Integer` to be evaluated as a `Boolean`.|  
  
## Remarks  

 The `Take While` clause includes elements from the start of a query result until the supplied `expression` returns `false`. After the `expression` returns `false`, the query will bypass all remaining elements. The `expression` is ignored for the remaining results.  
  
 The `Take While` clause differs from the `Where` clause in that the `Where` clause can be used to include all elements from a query that meet a particular condition. The `Take While` clause includes elements only until the first time that the condition is not satisfied. The `Take While` clause is most useful when you are working with an ordered query result.  
  
## Example  

 The following code example uses the `Take While` clause to retrieve results until the first customer without any orders is found.  
  
 [!code-vb[VbSimpleQuerySamples#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#2)]  
  
## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](index.md)
- [Select Clause](select-clause.md)
- [From Clause](from-clause.md)
- [Take Clause](take-clause.md)
- [Skip While Clause](skip-while-clause.md)
- [Where Clause](where-clause.md)
