---
description: "Learn more about: Take Clause (Visual Basic)"
title: "Take Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.QueryTake"
helpviewer_keywords: 
  - "Take statement [Visual Basic]"
  - "queries [Visual Basic], Take"
  - "Take clause [Visual Basic]"
ms.assetid: 77bf87b2-1476-4456-957f-fee922fbad8c
---
# Take Clause (Visual Basic)

Returns a specified number of contiguous elements from the start of a collection.  
  
## Syntax  
  
```vb  
Take count  
```  
  
## Parts  

 `count`  
 Required. A value or an expression that evaluates to the number of elements of the sequence to return.  
  
## Remarks  

 The `Take` clause causes a query to include a specified number of contiguous elements from the start of a results list. The number of elements to include is specified by the `count` parameter.  
  
 You can use the `Take` clause with the `Skip` clause to return a range of data from any segment of a query. To do this, pass the index of the first element of the range to the `Skip` clause and the size of the range to the `Take` clause. In this case, the `Take` clause must be specified after the `Skip` clause.  
  
 When you use the `Take` clause in a query, you may also need to ensure that the results are returned in an order that will enable the `Take` clause to include the intended results. For more information about ordering query results, see [Order By Clause](order-by-clause.md).  
  
 You can use the `TakeWhile` clause to specify that only certain elements be returned, depending on a supplied condition.  
  
## Example  

 The following code example uses the `Take` clause together with the `Skip` clause to return data from a query in pages. The GetCustomers function uses the `Skip` clause to bypass the customers in the list until the supplied starting index value, and uses the `Take` clause to return a page of customers starting from that index value.  
  
 [!code-vb[VbSimpleQuerySamples#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#1)]  
  
## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](index.md)
- [Select Clause](select-clause.md)
- [From Clause](from-clause.md)
- [Order By Clause](order-by-clause.md)
- [Take While Clause](take-while-clause.md)
- [Skip Clause](skip-clause.md)
