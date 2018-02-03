---
title: "Join Operations (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 39ab4854-ac84-4738-9d0b-3cb79be84db4
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Join Operations (Visual Basic)
A *join* of two data sources is the association of objects in one data source with objects that share a common attribute in another data source.  
  
 Joining is an important operation in queries that target data sources whose relationships to each other cannot be followed directly. In object-oriented programming, this could mean a correlation between objects that is not modeled, such as the backwards direction of a one-way relationship. An example of a one-way relationship is a Customer class that has a property of type City, but the City class does not have a property that is a collection of Customer objects. If you have a list of City objects and you want to find all the customers in each city, you could use a join operation to find them.  
  
 The join methods provided in the LINQ framework are <xref:System.Linq.Enumerable.Join%2A> and <xref:System.Linq.Enumerable.GroupJoin%2A>. These methods perform equijoins, or joins that match two data sources based on equality of their keys. (For comparison, Transact-SQL supports join operators other than 'equals', for example the 'less than' operator.) In relational database terms, <xref:System.Linq.Enumerable.Join%2A> implements an inner join, a type of join in which only those objects that have a match in the other data set are returned. The <xref:System.Linq.Enumerable.GroupJoin%2A> method has no direct equivalent in relational database terms, but it implements a superset of inner joins and left outer joins. A left outer join is a join that returns each element of the first (left) data source, even if it has no correlated elements in the other data source.  
  
 The following illustration shows a conceptual view of two sets and the elements within those sets that are included in either an inner join or a left outer join.  
  
 ![Two overlapping circles showing inner&#47;outer.](../../../../csharp/programming-guide/concepts/linq/media/joincircles.png "JoinCircles")  
  
## Methods  
  
|Method Name|Description|Visual Basic Query Expression Syntax|More Information|  
|-----------------|-----------------|------------------------------------------|----------------------|  
|Join|Joins two sequences based on key selector functions and extracts pairs of values.|`From x In …, y In … Where x.a = y.a`<br /><br /> -or-<br /><br /> `Join … [As …]In … On …`|<xref:System.Linq.Enumerable.Join%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Join%2A?displayProperty=nameWithType>|  
|GroupJoin|Joins two sequences based on key selector functions and groups the resulting matches for each element.|`Group Join … In … On …`|<xref:System.Linq.Enumerable.GroupJoin%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.GroupJoin%2A?displayProperty=nameWithType>|  
  
## See Also  
 <xref:System.Linq>  
 [Standard Query Operators Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md)  
 [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)  
 [Formulate Joins and Cross-Product Queries](http://msdn.microsoft.com/library/d8072ede-0521-4670-9bec-1778ceeb875b)  
 [Join Clause](../../../../visual-basic/language-reference/queries/join-clause.md)  
 [How to: Join Content from Dissimilar Files (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-join-content-from-dissimilar-files-linq.md)  
 [How to: Populate Object Collections from Multiple Sources (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-populate-object-collections-from-multiple-sources-linq.md)
