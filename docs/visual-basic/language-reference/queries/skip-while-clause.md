---
title: "Skip While Clause (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.QuerySkipWhile"
helpviewer_keywords: 
  - "Skip While statement [Visual Basic]"
  - "Skip While clause [Visual Basic]"
  - "queries [Visual Basic], Skip While"
ms.assetid: 5dee8350-7520-4f1a-b00d-590cacd572d6
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Skip While Clause (Visual Basic)
Bypasses elements in a collection as long as a specified condition is `true` and then returns the remaining elements.  
  
## Syntax  
  
```  
Skip While expression  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`expression`|Required. An expression that represents a condition to test elements for. The expression must return a `Boolean` value or a functional equivalent, such as an `Integer` to be evaluated as a `Boolean`.|  
  
## Remarks  
 The `Skip While` clause bypasses elements from the beginning of a query result until the supplied `expression` returns `false`. After `expression` returns `false`, the query returns all the remaining elements. The `expression` is ignored for the remaining results.  
  
 The `Skip While` clause differs from the `Where` clause in that the `Where` clause can be used to exclude all elements from a query that do not meet a particular condition. The `Skip While` clause excludes elements only until the first time that the condition is not satisfied. The `Skip While` clause is most useful when you are working with an ordered query result.  
  
 You can bypass a specific number of results from the beginning of a query result by using the `Skip` clause.  
  
## Example  
 The following code example uses the `Skip While` clause to bypass results until the first customer from the United States is found.  
  
 [!code-vb[VbSimpleQuerySamples#3](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/skip-while-clause_1.vb)]  
  
## See Also  
 [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [Queries](../../../visual-basic/language-reference/queries/queries.md)  
 [Select Clause](../../../visual-basic/language-reference/queries/select-clause.md)  
 [From Clause](../../../visual-basic/language-reference/queries/from-clause.md)  
 [Skip Clause](../../../visual-basic/language-reference/queries/skip-clause.md)  
 [Take While Clause](../../../visual-basic/language-reference/queries/take-while-clause.md)  
 [Where Clause](../../../visual-basic/language-reference/queries/where-clause.md)
