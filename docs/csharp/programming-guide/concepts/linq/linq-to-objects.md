---
title: "LINQ to Objects (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: c5c2c178-3529-4f6c-b3df-2d5267af7f22
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# LINQ to Objects (C#)
The term "LINQ to Objects" refers to the use of LINQ queries with any <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601> collection directly, without the use of an intermediate LINQ provider or API such as [LINQ to SQL](../../../../../docs/framework/data/adonet/sql/linq/index.md) or [LINQ to XML](http://msdn.microsoft.com/library/f0fe21e9-ee43-4a55-b91a-0800e5782c13). You can use LINQ to query any enumerable collections such as <xref:System.Collections.Generic.List%601>, <xref:System.Array>, or <xref:System.Collections.Generic.Dictionary%602>. The collection may be user-defined or may be returned by a .NET Framework API.  
  
 In a basic sense, LINQ to Objects represents a new approach to collections. In the old way, you had to write complex `foreach` loops that specified how to retrieve data from a collection. In the LINQ approach, you write declarative code that describes what you want to retrieve.  
  
 In addition, LINQ queries offer three main advantages over traditional `foreach` loops:  
  
1.  They are more concise and readable, especially when filtering multiple conditions.  
  
2.  They provide powerful filtering, ordering, and grouping capabilities with a minimum of application code.  
  
3.  They can be ported to other data sources with little or no modification.  
  
 In general, the more complex the operation you want to perform on the data, the more benefit you will realize by using LINQ instead of traditional iteration techniques.  
  
 The purpose of this section is to demonstrate the LINQ approach with some select examples. It is not intended to be exhaustive.  
  
## In This Section  
 [LINQ and Strings (C#)](../../../../csharp/programming-guide/concepts/linq/linq-and-strings.md)  
 Explains how LINQ can be used to query and transform strings and collections of strings. Also includes links to topics that demonstrate these principles.  
  
 [LINQ and Reflection (C#)](../../../../csharp/programming-guide/concepts/linq/linq-and-reflection.md)  
 Links to a sample that demonstrates how LINQ uses reflection.  
  
 [LINQ and File Directories (C#)](../../../../csharp/programming-guide/concepts/linq/linq-and-file-directories.md)  
 Explains how LINQ can be used to interact with file systems. Also includes links to topics that demonstrate these concepts.  
  
 [How to: Query an ArrayList with LINQ (C#)](../../../../csharp/programming-guide/concepts/linq/how-to-query-an-arraylist-with-linq.md)  
 Demonstrates how to query an ArrayList in C#.  
  
 [How to: Add Custom Methods for LINQ Queries (C#)](../../../../csharp/programming-guide/concepts/linq/how-to-add-custom-methods-for-linq-queries.md)  
 Explains how to extend the set of methods that you can use for LINQ queries by adding extension methods to the <xref:System.Collections.Generic.IEnumerable%601> interface.  
  
 [Language-Integrated Query (LINQ) (C#)](../../../../csharp/programming-guide/concepts/linq/index.md)  
 Provides links to topics that explain LINQ and provide examples of code that perform queries.
