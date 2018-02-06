---
title: "EntityClient Provider for the Entity Framework"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8c5db787-78e6-4a34-8dc1-188bca0aca5e
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# EntityClient Provider for the Entity Framework
The EntityClient provider is a data provider used by Entity Framework applications to access data described in a conceptual model. For information about conceptual models, see [Modeling and Mapping](../../../../../docs/framework/data/adonet/ef/modeling-and-mapping.md). EntityClient uses other .NET Framework data providers to access the data source. For example, EntityClient uses the .NET Framework Data Provider for SQL Server (SqlClient) when accessing a SQL Server database. For information about the SqlClient provider, see [SqlClient for the Entity Framework](../../../../../docs/framework/data/adonet/ef/sqlclient-for-the-entity-framework.md). The EntityClient provider is implemented in the <xref:System.Data.EntityClient> namespace.  
  
## Managing Connections  
 The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] builds on top of storage-specific [!INCLUDE[vstecado](../../../../../includes/vstecado-md.md)] data providers by providing an <xref:System.Data.EntityClient.EntityConnection> to an underlying data provider and relational database. To construct an <xref:System.Data.EntityClient.EntityConnection> object, you have to reference a set of metadata that contains the necessary models and mapping, and also a storage-specific data provider name and connection string. After the <xref:System.Data.EntityClient.EntityConnection> is in place, entities can be accessed through the classes generated from the conceptual model.  
  
 You can specify a connection string in app.config file.  
  
 The <xref:System.Data.EntityClient> also includes the <xref:System.Data.EntityClient.EntityConnectionStringBuilder> class. This class enables developers to programmatically create syntactically correct connection strings, and parse and rebuild existing connection strings, by using properties and methods of the class. For more information, see [How to: Build an EntityConnection Connection String](../../../../../docs/framework/data/adonet/ef/how-to-build-an-entityconnection-connection-string.md).  
  
## Creating Queries  
 The [!INCLUDE[esql](../../../../../includes/esql-md.md)] language is a storage-independent dialect of SQL that works directly with conceptual entity schemas and supports Entity Data Model concepts such as inheritance and relationships. The <xref:System.Data.EntityClient.EntityCommand> class is used to execute an [!INCLUDE[esql](../../../../../includes/esql-md.md)] command against an entity model. When you construct <xref:System.Data.EntityClient.EntityCommand> objects, you can specify a stored procedure name or a query text. The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] works with storage-specific data providers to translate generic [!INCLUDE[esql](../../../../../includes/esql-md.md)] into storage-specific queries. For more information about writing [!INCLUDE[esql](../../../../../includes/esql-md.md)] queries, see [Entity SQL Language](../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-language.md).  
  
 The following example creates an <xref:System.Data.EntityClient.EntityCommand> object and assigns an [!INCLUDE[esql](../../../../../includes/esql-md.md)] query text to its <xref:System.Data.EntityClient.EntityCommand.CommandText%2A?displayProperty=nameWithType> property. This [!INCLUDE[esql](../../../../../includes/esql-md.md)] query requests products ordered by the list price from the conceptual model. The following code has no knowledge of the storage model at all.  
  
 `EntityCommand cmd = conn.CreateCommand();`  
  
 `cmd.CommandText = @"` `SELECT VALUE p`  
  
 `FROM AdventureWorksEntities.Product AS p`  
  
 `ORDER BY p.ListPrice ";`  
  
## Executing Queries  
 When a query is executed, it is parsed and converted into a canonical command tree. All subsequent processing is performed on the command tree. The command tree is the means of communication between the <xref:System.Data.EntityClient> and the underlying [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] data provider, such as <xref:System.Data.SqlClient>.  
  
 The <xref:System.Data.EntityClient.EntityDataReader> exposes the results of executing a <xref:System.Data.EntityClient.EntityCommand> against a conceptual model. To execute the command that returns the <xref:System.Data.EntityClient.EntityDataReader>, call <xref:System.Data.EntityClient.EntityCommand.ExecuteReader%2A>. The <xref:System.Data.EntityClient.EntityDataReader> implements <xref:System.Data.IExtendedDataRecord> to describe rich structured results.  
  
## Managing Transactions  
 In the Entity Framework, there are two ways to use transactions: automatic and explicit. Automatic transactions use the <xref:System.Transactions> namespace, and explicit transactions use the <xref:System.Data.EntityClient.EntityTransaction> class.  
  
 To update data that is exposed through a conceptual model; see [How to: Manage Transactions in the Entity Framework](http://msdn.microsoft.com/library/4a55eb7f-f826-4a48-9df1-aebe2352ebef).  
  
## In This Section  
 [How to: Build an EntityConnection Connection String](../../../../../docs/framework/data/adonet/ef/how-to-build-an-entityconnection-connection-string.md)  
  
 [How to: Execute a Query that Returns PrimitiveType Results](../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-primitivetype-results.md)  
  
 [How to: Execute a Query that Returns StructuralType Results](../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md)  
  
 [How to: Execute a Query that Returns RefType Results](../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-reftype-results.md)  
  
 [How to: Execute a Query that Returns Complex Types](../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-complex-types.md)  
  
 [How to: Execute a Query that Returns Nested Collections](../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-nested-collections.md)  
  
 [How to: Execute a Parameterized Entity SQL Query Using EntityCommand](../../../../../docs/framework/data/adonet/ef/how-to-execute-a-parameterized-entity-sql-query-using-entitycommand.md)  
  
 [How to: Execute a Parameterized Stored Procedure Using EntityCommand](../../../../../docs/framework/data/adonet/ef/how-to-execute-a-parameterized-stored-procedure-using-entitycommand.md)  
  
 [How to: Execute a Polymorphic Query](../../../../../docs/framework/data/adonet/ef/how-to-execute-a-polymorphic-query.md)  
  
 [How to: Navigate Relationships with the Navigate Operator](../../../../../docs/framework/data/adonet/ef/how-to-navigate-relationships-with-the-navigate-operator.md)  
  
## See Also  
 [Managing Connections and Transactions](http://msdn.microsoft.com/library/b6659d2a-9a45-4e98-acaa-d7a8029e5b99)  
 [ADO.NET Entity Framework](../../../../../docs/framework/data/adonet/ef/index.md)  
 [Language Reference](../../../../../docs/framework/data/adonet/ef/language-reference/index.md)
