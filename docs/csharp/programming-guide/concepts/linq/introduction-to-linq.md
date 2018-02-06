---
title: "Introduction to LINQ (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 54874feb-55e5-4ca8-a9d6-1c1127fd7fb1
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Introduction to LINQ (C#)
Language-Integrated Query (LINQ) is an innovation introduced in the .NET Framework version 3.5 that bridges the gap between the world of objects and the world of data.  
  
 Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support. Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on. LINQ makes a *query* a first-class language construct in C#. You write queries against strongly typed collections of objects by using language keywords and familiar operators.  
  
 You can write LINQ queries in C# for SQL Server databases, XML documents, ADO.NET Datasets, and any collection of objects that supports <xref:System.Collections.IEnumerable> or the generic <xref:System.Collections.Generic.IEnumerable%601> interface. LINQ support is also provided by third parties for many Web services and other database implementations.  
  
 You can use LINQ queries in new projects, or alongside non-LINQ queries in existing projects. The only requirement is that the project target .NET Framework 3.5 or later.  
  
 The following illustration from Visual Studio shows a partially-completed LINQ query against a SQL Server database in both C# and Visual Basic with full type checking and IntelliSense support.  
  
 ![LINQ query with Intellisense](../../../../csharp/programming-guide/concepts/linq/media/query_intell.png "Query_Intell")  
  
## Next Steps  
 To learn more details about LINQ, start by becoming familiar with some basic concepts in the Getting Started section [Getting Started with LINQ in C#](../../../../csharp/programming-guide/concepts/linq/getting-started-with-linq.md), and then read the documentation for the LINQ technology in which you are interested:  
  
-   SQL Server databases: [LINQ to SQL](../../../../../docs/framework/data/adonet/sql/linq/index.md)  
  
-   XML documents: [LINQ to XML (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml.md)  
  
-   ADO.NET Datasets: [LINQ to DataSet](../../../../framework/data/adonet/linq-to-dataset.md)  
  
-   .NET collections, files, strings and so on: [LINQ to Objects (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-objects.md)  
  
## See Also  
 [Language-Integrated Query (LINQ) (C#)](../../../../csharp/programming-guide/concepts/linq/index.md)
