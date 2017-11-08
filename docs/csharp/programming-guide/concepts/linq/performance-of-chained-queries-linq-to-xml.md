---
title: "Performance of Chained Queries (LINQ to XML) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: b2f1d715-8946-4dc0-8d56-fb3d1bba54a6
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# Performance of Chained Queries (LINQ to XML) (C#)
One of the most important benefits of LINQ (and LINQ to XML) is that chained queries can perform as well as a single larger, more complicated query.  
  
 A chained query is a query that uses another query as its source. For example, in the following simple code, `query2` has `query1` as its source:  
  
```csharp  
XElement root = new XElement("Root",  
    new XElement("Child", 1),  
    new XElement("Child", 2),  
    new XElement("Child", 3),  
    new XElement("Child", 4)  
);  
  
var query1 = from x in root.Elements("Child")  
             where (int)x >= 3  
             select x;  
  
var query2 = from e in query1  
             where (int)e % 2 == 0  
             select e;  
  
foreach (var i in query2)  
    Console.WriteLine("{0}", (int)i);  
```  
  
 This example produces the following output:  
  
```  
4  
```  
  
 This chained query provides the same performance profile as iterating through a linked list.  
  
-   The <xref:System.Xml.Linq.XContainer.Elements%2A> axis has essentially the same performance as iterating through a linked list. <xref:System.Xml.Linq.XContainer.Elements%2A> is implemented as an iterator with deferred execution. This means that it does some work in addition to iterating through the linked list, such as allocating the iterator object and keeping track of execution state. This work can be divided into two categories: the work that is done at the time the iterator is set up, and the work that is done during each iteration. The setup work is a small, fixed amount of work and the work done during each iteration is proportional to the number of items in the source collection.  
  
-   In `query1`, the `where` clause causes the query to call the <xref:System.Linq.Enumerable.Where%2A> method. This method is also implemented as an iterator. The setup work consists of instantiating the delegate that will reference the lambda expression, plus the normal setup for an iterator. With each iteration, the delegate is called to execute the predicate. The setup work and the work done during each iteration is the similar to the work done while iterating through the axis.  
  
-   In `query1`, the select clause causes the query to call the <xref:System.Linq.Enumerable.Select%2A> method. This method has the same performance profile as the <xref:System.Linq.Enumerable.Where%2A> method.  
  
-   In `query2`, both the `where` clause and the `select` clause have the same performance profile as in `query1`.  
  
 The iteration through `query2` is therefore directly proportional to the number of items in the source of the first query, in other words, linear time. A corresponding Visual Basic example would have the same performance profile.  
  
 For more information on iterators, see [yield](../../../../csharp/language-reference/keywords/yield.md).  
  
 For a more detailed tutorial on chaining queries together, see [Tutorial: Chaining Queries Together](http://msdn.microsoft.com/library/c08d228a-f07a-4c98-810f-1bf0e8f2257c).  
  
## See Also  
 [Performance (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/performance-linq-to-xml.md)
