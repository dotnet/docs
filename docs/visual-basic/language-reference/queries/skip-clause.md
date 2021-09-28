---
description: "Learn more about: Skip Clause (Visual Basic)"
title: "Skip Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.QuerySkip"
helpviewer_keywords: 
  - "queries [Visual Basic], Skip"
  - "Skip statement [Visual Basic]"
  - "Skip clause [Visual Basic]"
ms.assetid: f00eb172-3907-4c43-9745-d8546ab86234
---
# Skip Clause (Visual Basic)

Bypasses a specified number of elements in a collection and then returns the remaining elements.  
  
## Syntax  
  
```vb  
Skip count  
```  
  
## Parts  

 `count`  
 Required. A value or an expression that evaluates to the number of elements of the sequence to skip.  
  
## Remarks  

 The `Skip` clause causes a query to bypass elements at the beginning of a results list and return the remaining elements. The number of elements to skip is identified by the `count` parameter.  
  
 You can use the `Skip` clause with the `Take` clause to return a range of data from any segment of a query. To do this, pass the index of the first element of the range to the `Skip` clause and the size of the range to the `Take` clause.  
  
 When you use the `Skip` clause in a query, you may also need to ensure that the results are returned in an order that will enable the `Skip` clause to bypass the intended results. For more information about ordering query results, see [Order By Clause](order-by-clause.md).  
  
 You can use the `SkipWhile` clause to specify that only certain elements are ignored, depending on a supplied condition.  
  
## Example  

 The following code example uses the `Skip` clause together with the `Take` clause to return data from a query in pages. The `GetCustomers` function uses the `Skip` clause to bypass the customers in the list until the supplied starting index value, and uses the `Take` clause to return a page of customers starting from that index value.  
  
 [!code-vb[VbSimpleQuerySamples#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#1)]  
  
## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](index.md)
- [Select Clause](select-clause.md)
- [From Clause](from-clause.md)
- [Order By Clause](order-by-clause.md)
- [Skip While Clause](skip-while-clause.md)
- [Take Clause](take-clause.md)
