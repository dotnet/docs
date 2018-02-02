---
title: "LINQ to DataSet Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dc20a8fb-03f6-4b68-9c2b-7f7299e3070b
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# LINQ to DataSet Overview
The <xref:System.Data.DataSet> is one of the more widely used components of [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)]. It is a key element of the disconnected programming model that [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)] is based on, and it enables you to explicitly cache data from different data sources. For the presentation tier, the <xref:System.Data.DataSet> is tightly integrated with GUI controls for data-binding. For the middle-tier, it provides a cache that preserves the relational shape of data, and includes fast simple query and hierarchy navigation services. A common technique used to lower the number of requests on a database is to use the <xref:System.Data.DataSet> for caching in the middle-tier. For example, consider a data-driven [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web application. Often, a significant portion of the application data does not change frequently and is common across sessions or users. This data can be kept in memory on the Web server, which reduces the number of requests against the database and speeds up the user’s interactions. Another useful aspect of the <xref:System.Data.DataSet> is that it allows an application to bring subsets of data from one or more data source into the application space. The application can then manipulate the data in-memory, while retaining its relational shape.  
  
 Despite its prominence, the <xref:System.Data.DataSet> has limited query capabilities. The <xref:System.Data.DataTable.Select%2A> method can be used for filtering and sorting, and the <xref:System.Data.DataRow.GetChildRows%2A> and <xref:System.Data.DataRow.GetParentRow%2A> methods can be used for hierarchy navigation. For anything more complex, however, the developer must write a custom query. This can result in applications that perform poorly and are difficult to maintain.  
  
 [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] makes it easier and faster to query over data cached in a <xref:System.Data.DataSet> object. These queries are expressed in the programming language itself, rather than as string literals embedded in the application code. This means that developers do not have to learn a separate query language. Additionally, [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] enables [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] developers to work more productively, because the [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] IDE provides compile-time syntax checking, static typing, and IntelliSense support for [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)]. [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] can also be used to query over data that has been consolidated from one or more data sources. This enables many scenarios that require flexibility in how data is represented and handled. In particular, generic reporting, analysis, and business intelligence applications require this method of manipulation.  
  
## Querying DataSets Using LINQ to DataSet  
 Before you can begin querying a <xref:System.Data.DataSet> object using [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)], you must populate the <xref:System.Data.DataSet>. There are several ways to load data into a <xref:System.Data.DataSet>, such as using the <xref:System.Data.Common.DataAdapter> class or [LINQ to SQL](../../../../docs/framework/data/adonet/sql/linq/index.md). After the data has been loaded into a <xref:System.Data.DataSet> object, you can begin to query it. Formulating queries using [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] is similar to using [!INCLUDE[vbteclinqext](../../../../includes/vbteclinqext-md.md)] against other [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)]-enabled data sources. [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] queries can be performed against single tables in a <xref:System.Data.DataSet> or against more than one table by using the <xref:System.Linq.Enumerable.Join%2A> and <xref:System.Linq.Enumerable.GroupJoin%2A> standard query operators.  
  
 [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] queries are supported against both typed and untyped <xref:System.Data.DataSet> objects. If the schema of the <xref:System.Data.DataSet> is known at application design time, a typed <xref:System.Data.DataSet> is recommended. In a typed <xref:System.Data.DataSet>, the tables and rows have typed members for each of the columns, which makes queries simpler and more readable.  
  
 In addition to the standard query operators implemented in System.Core.dll, [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] adds several <xref:System.Data.DataSet>-specific extensions that make it easier to query over a set of <xref:System.Data.DataRow> objects. These <xref:System.Data.DataSet>-specific extensions include operators for comparing sequences of rows, as well as methods that provide access to the column values of a <xref:System.Data.DataRow>.  
  
## N-tier Applications and LINQ to DataSet  
 N-tier data applications are data-centric applications that are separated into multiple logical layers (or tiers). A typical N-tier application includes a presentation tier, a middle tier, and a data tier. Separating application components into separate tiers increases the maintainability and scalability of the application. For more information about N-tier data applications, see [Work with datasets in n-tier applications](http://msdn.microsoft.com/library/f6ae2ee0-ea5f-4a79-8f4b-e21c115afb20).  
  
 In N-tier applications, the <xref:System.Data.DataSet> is often used in the middle-tier to cache information for a Web application. The [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] querying functionality is implemented through extension methods and extends the existing ADO.NET 2.0 <xref:System.Data.DataSet>.  
  
## See Also  
 [Querying DataSets](../../../../docs/framework/data/adonet/querying-datasets-linq-to-dataset.md)  
 [LINQ (Language-Integrated Query)](http://msdn.microsoft.com/library/a73c4aec-5d15-4e98-b962-1274021ea93d)  
 [LINQ to SQL](../../../../docs/framework/data/adonet/sql/linq/index.md)
