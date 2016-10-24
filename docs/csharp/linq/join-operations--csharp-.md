---
title: "Join Operations (C#)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: 5105e0da-1267-4c00-837a-f0e9602279b8
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Join Operations (C#)
A *join* of two data sources is the association of objects in one data source with objects that share a common attribute in another data source.  
  
 Joining is an important operation in queries that target data sources whose relationships to each other cannot be followed directly. In object-oriented programming, this could mean a correlation between objects that is not modeled, such as the backwards direction of a one-way relationship. An example of a one-way relationship is a Customer class that has a property of type City, but the City class does not have a property that is a collection of Customer objects. If you have a list of City objects and you want to find all the customers in each city, you could use a join operation to find them.  
  
 The join methods provided in the LINQ framework are <xref:System.Linq.Enumerable.Join*> and <xref:System.Linq.Enumerable.GroupJoin*>. These methods perform equijoins, or joins that match two data sources based on equality of their keys. (For comparison, Transact-SQL supports join operators other than 'equals', for example the 'less than' operator.) In relational database terms, <xref:System.Linq.Enumerable.Join*> implements an inner join, a type of join in which only those objects that have a match in the other data set are returned. The <xref:System.Linq.Enumerable.GroupJoin*> method has no direct equivalent in relational database terms, but it implements a superset of inner joins and left outer joins. A left outer join is a join that returns each element of the first (left) data source, even if it has no correlated elements in the other data source.  
  
 The following illustration shows a conceptual view of two sets and the elements within those sets that are included in either an inner join or a left outer join.  
  
 ![Two overlapping circles showing inner&#47;outer.](../linq/media/joincircles.png "JoinCircles")  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|Join|Joins two sequences based on key selector functions and extracts pairs of values.|`join … in … on … equals …`|<xref:System.Linq.Enumerable.Join*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Join*?displayProperty=fullName>|  
|GroupJoin|Joins two sequences based on key selector functions and groups the resulting matches for each element.|`join … in … on … equals … into …`|<xref:System.Linq.Enumerable.GroupJoin*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.GroupJoin*?displayProperty=fullName>|  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [Anonymous Types](../classes-and-structs/anonymous-types--csharp-programming-guide-.md)   
 [Formulate Joins and Cross-Product Queries](../Topic/Formulate%20Joins%20and%20Cross-Product%20Queries.md)   
 [join clause](../keywords/join-clause--csharp-reference-.md)   
 [How to: Join by Using Composite Keys](../linq-query-expressions/how-to--join-by-using-composite-keys--csharp-programming-guide-.md)   
 [How to: Join Content from Dissimilar Files (LINQ) (C#)](../linq/how-to--join-content-from-dissimilar-files--linq---csharp-.md)   
 [How to: Order the Results of a Join Clause](../linq-query-expressions/how-to--order-the-results-of-a-join-clause--csharp-programming-guide-.md)   
 [How to: Perform Custom Join Operations](../linq-query-expressions/how-to--perform-custom-join-operations--csharp-programming-guide-.md)   
 [How to: Perform Grouped Joins](../linq-query-expressions/how-to--perform-grouped-joins--csharp-programming-guide-.md)   
 [How to: Perform Inner Joins](../linq-query-expressions/how-to--perform-inner-joins--csharp-programming-guide-.md)   
 [How to: Perform Left Outer Joins](../linq-query-expressions/how-to--perform-left-outer-joins--csharp-programming-guide-.md)   
 [How to: Populate Object Collections from Multiple Sources (LINQ) (C#)](../linq/how-to--populate-object-collections-from-multiple-sources--linq---csharp-.md)