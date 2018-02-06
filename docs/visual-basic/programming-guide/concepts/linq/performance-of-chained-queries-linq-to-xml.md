---
title: "Performance of Chained Queries (LINQ to XML) (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 589f2adc-69f9-404d-b9d6-4c28dabea7f7
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent

---
# Performance of Chained Queries (LINQ to XML) (Visual Basic)
One of the most important benefits of LINQ (and LINQ to XML) is that chained queries can perform as well as a single larger, more complicated query.  
  
 A chained query is a query that uses another query as its source. For example, in the following simple code, `query2` has `query1` as its source:  
  
```vb  
Dim root As New XElement("Root", New XElement("Child", 1), New XElement("Child", 2), New XElement("Child", 3), New XElement("Child", 4))  
  
Dim query1 = From x In root.Elements("Child") Where CInt(x) >= 3x  
  
Dim query2 = From e In query1 Where CInt(e) Mod 2 = 0e  
  
For Each i As var In query2  
	Console.WriteLine("{0}", CInt(i))  
Next  
```  
  
 This example produces the following output:  
  
```  
4  
```  
  
 This chained query provides the same performance profile as iterating through a linked list.  
  
-   The <xref:System.Xml.Linq.XContainer.Elements%2A> axis has essentially the same performance as iterating through a linked list. <xref:System.Xml.Linq.XContainer.Elements%2A> is implemented as an iterator with deferred execution. This means that it does some work in addition to iterating through the linked list, such as allocating the iterator object and keeping track of execution state. This work can be divided into two categories: the work that is done at the time the iterator is set up, and the work that is done during each iteration. The setup work is a small, fixed amount of work and the work done during each iteration is proportional to the number of items in the source collection.  
  
-   In `query1`, the `Where` clause causes the query to call the <xref:System.Linq.Enumerable.Where%2A> method. This method is also implemented as an iterator. The setup work consists of instantiating the delegate that will reference the lambda expression, plus the normal setup for an iterator. With each iteration, the delegate is called to execute the predicate. The setup work and the work done during each iteration is the similar to the work done while iterating through the axis.  
  
-   In `query1`, the select clause causes the query to call the <xref:System.Linq.Enumerable.Select%2A> method. This method has the same performance profile as the <xref:System.Linq.Enumerable.Where%2A> method.  
  
-   In `query2`, both the `Where` clause and the `Select` clause have the same performance profile as in `query1`.  
  
 The iteration through `query2` is therefore directly proportional to the number of items in the source of the first query, in other words, linear time.  
  
## See Also  
 [Performance (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/performance-linq-to-xml.md)
