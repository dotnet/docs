---
title: "SQL Generation in the Sample Provider"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e70f553d-4622-4627-928e-1aa2ee605d8e
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SQL Generation in the Sample Provider
The [Entity Framework Sample Provider](http://go.microsoft.com/fwlink/?LinkId=180616) demonstrates the new components of ADO.NET Data Providers that support the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)].  It works with a SQL Server 2005 database and is implemented as a wrapper for the System.Data.SqlClient ADO.NET 2.0 Data Provider.  
  
 The SQL Generation module of the Sample Provider (located under the SQL Generation folder, except for the file DmlSqlGenerator.cs) takes an input DbQueryCommandTree and produces a single SQL SELECT statement.  
  
## In This Section  
 This section includes the following topics:  
  
 [Architecture and Design](../../../../../docs/framework/data/adonet/ef/architecture-and-design.md)  
  
 [Walkthrough: SQL Generation](../../../../../docs/framework/data/adonet/ef/walkthrough-sql-generation.md)  
  
## See Also  
 [SQL Generation](../../../../../docs/framework/data/adonet/ef/sql-generation.md)
