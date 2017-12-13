---
title: "Skip Clause (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.QuerySkip"
helpviewer_keywords: 
  - "queries [Visual Basic], Skip"
  - "Skip statement [Visual Basic]"
  - "Skip clause [Visual Basic]"
ms.assetid: f00eb172-3907-4c43-9745-d8546ab86234
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Skip Clause (Visual Basic)
Bypasses a specified number of elements in a collection and then returns the remaining elements.  
  
## Syntax  
  
```  
Skip count  
```  
  
## Parts  
 `count`  
 Required. A value or an expression that evaluates to the number of elements of the sequence to skip.  
  
## Remarks  
 The `Skip` clause causes a query to bypass elements at the beginning of a results list and return the remaining elements. The number of elements to skip is identified by the `count` parameter.  
  
 You can use the `Skip` clause with the `Take` clause to return a range of data from any segment of a query. To do this, pass the index of the first element of the range to the `Skip` clause and the size of the range to the `Take` clause.  
  
 When you use the `Skip` clause in a query, you may also need to ensure that the results are returned in an order that will enable the `Skip` clause to bypass the intended results. For more information about ordering query results, see [Order By Clause](../../../visual-basic/language-reference/queries/order-by-clause.md).  
  
 You can use the `SkipWhile` clause to specify that only certain elements are ignored, depending on a supplied condition.  
  
## Example  
 The following code example uses the `Skip` clause together with the `Take` clause to return data from a query in pages. The `GetCustomers` function uses the `Skip` clause to bypass the customers in the list until the supplied starting index value, and uses the `Take` clause to return a page of customers starting from that index value.  
  
 [!code-vb[VbSimpleQuerySamples#1](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/skip-clause_1.vb)]  
  
## See Also  
 [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [Queries](../../../visual-basic/language-reference/queries/queries.md)  
 [Select Clause](../../../visual-basic/language-reference/queries/select-clause.md)  
 [From Clause](../../../visual-basic/language-reference/queries/from-clause.md)  
 [Order By Clause](../../../visual-basic/language-reference/queries/order-by-clause.md)  
 [Skip While Clause](../../../visual-basic/language-reference/queries/skip-while-clause.md)  
 [Take Clause](../../../visual-basic/language-reference/queries/take-clause.md)
