---
description: "Learn more about: LINQ to DataSet Overview"
title: "LINQ to DataSet Overview"
ms.date: "03/30/2017"
ms.assetid: dc20a8fb-03f6-4b68-9c2b-7f7299e3070b
---
# LINQ to DataSet Overview

The <xref:System.Data.DataSet> is one of the more widely used components of ADO.NET. It is a key element of the disconnected programming model that ADO.NET is based on, and it enables you to explicitly cache data from different data sources. For the presentation tier, the <xref:System.Data.DataSet> is tightly integrated with GUI controls for data-binding. For the middle-tier, it provides a cache that preserves the relational shape of data, and includes fast simple query and hierarchy navigation services. A common technique used to lower the number of requests on a database is to use the <xref:System.Data.DataSet> for caching in the middle-tier. For example, consider a data-driven ASP.NET Web application. Often, a significant portion of the application data does not change frequently and is common across sessions or users. This data can be kept in memory on the Web server, which reduces the number of requests against the database and speeds up the user’s interactions. Another useful aspect of the <xref:System.Data.DataSet> is that it allows an application to bring subsets of data from one or more data source into the application space. The application can then manipulate the data in-memory, while retaining its relational shape.  
  
 Despite its prominence, the <xref:System.Data.DataSet> has limited query capabilities. The <xref:System.Data.DataTable.Select%2A> method can be used for filtering and sorting, and the <xref:System.Data.DataRow.GetChildRows%2A> and <xref:System.Data.DataRow.GetParentRow%2A> methods can be used for hierarchy navigation. For anything more complex, however, the developer must write a custom query. This can result in applications that perform poorly and are difficult to maintain.  
  
 LINQ to DataSet makes it easier and faster to query over data cached in a <xref:System.Data.DataSet> object. These queries are expressed in the programming language itself, rather than as string literals embedded in the application code. This means that developers do not have to learn a separate query language. Additionally, LINQ to DataSet enables Visual Studio developers to work more productively, because the Visual Studio IDE provides compile-time syntax checking, static typing, and IntelliSense support for LINQ. LINQ to DataSet can also be used to query over data that has been consolidated from one or more data sources. This enables many scenarios that require flexibility in how data is represented and handled. In particular, generic reporting, analysis, and business intelligence applications require this method of manipulation.  
  
## Querying DataSets Using LINQ to DataSet  

 Before you can begin querying a <xref:System.Data.DataSet> object using LINQ to DataSet, you must populate the <xref:System.Data.DataSet>. There are several ways to load data into a <xref:System.Data.DataSet>, such as using the <xref:System.Data.Common.DataAdapter> class or [LINQ to SQL](./sql/linq/index.md). After the data has been loaded into a <xref:System.Data.DataSet> object, you can begin to query it. Formulating queries using LINQ to DataSet is similar to using Language-Integrated Query (LINQ) against other LINQ-enabled data sources. LINQ queries can be performed against single tables in a <xref:System.Data.DataSet> or against more than one table by using the <xref:System.Linq.Enumerable.Join%2A> and <xref:System.Linq.Enumerable.GroupJoin%2A> standard query operators.  
  
 LINQ queries are supported against both typed and untyped <xref:System.Data.DataSet> objects. If the schema of the <xref:System.Data.DataSet> is known at application design time, a typed <xref:System.Data.DataSet> is recommended. In a typed <xref:System.Data.DataSet>, the tables and rows have typed members for each of the columns, which makes queries simpler and more readable.  
  
 In addition to the standard query operators implemented in System.Core.dll, LINQ to DataSet adds several <xref:System.Data.DataSet>-specific extensions that make it easier to query over a set of <xref:System.Data.DataRow> objects. These <xref:System.Data.DataSet>-specific extensions include operators for comparing sequences of rows, as well as methods that provide access to the column values of a <xref:System.Data.DataRow>.  
  
## N-tier Applications and LINQ to DataSet  

 N-tier data applications are data-centric applications that are separated into multiple logical layers (or tiers). A typical N-tier application includes a presentation tier, a middle tier, and a data tier. Separating application components into separate tiers increases the maintainability and scalability of the application. For more information about N-tier data applications, see [Work with datasets in n-tier applications](/visualstudio/data-tools/work-with-datasets-in-n-tier-applications).  
  
 In N-tier applications, the <xref:System.Data.DataSet> is often used in the middle-tier to cache information for a Web application. The LINQ to DataSet querying functionality is implemented through extension methods and extends the existing ADO.NET 2.0 <xref:System.Data.DataSet>.  
  
## See also

- [Querying DataSets](querying-datasets-linq-to-dataset.md)
- [Language-Integrated Query (LINQ) - C#](../../../csharp/programming-guide/concepts/linq/index.md)
- [Language-Integrated Query (LINQ) - Visual Basic](../../../visual-basic/programming-guide/concepts/linq/index.md)
- [LINQ to SQL](./sql/linq/index.md)
