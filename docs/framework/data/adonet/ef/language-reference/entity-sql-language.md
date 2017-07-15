---
title: "Entity SQL Language | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
ms.assetid: 9e7d8837-28c5-429d-a824-7bafb59724cf
caps.latest.revision: 4
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# Entity SQL Language
Entity SQL is a storage-independent query language that is similar to SQL. Entity SQL allows you to query entity data, either as objects or in a tabular form. You should consider using Entity SQL in the following cases:  
  
-   When a query must be dynamically constructed at runtime. In this case, you should also consider using the query builder methods of <xref:System.Data.Objects.ObjectQuery%601> instead of constructing an Entity SQL query string at runtime.  
  
-   When you want to define a query as part of the model definition. Only Entity SQL is supported in a data model. For more information, see [QueryView Element (MSL)](https://msdn.microsoft.com/library/cc716798.aspx)  
  
-   When using EntityClient to return read-only entity data as rowsets using a <xref:System.Data.EntityClient.EntityDataReader>. For more information, see [EntityClient Provider for the Entity Framework](../../../../../../docs/framework/data/adonet/ef/entityclient-provider-for-the-entity-framework.md).  
  
-   If you are already an expert in SQL-based query languages, Entity SQL may seem the most natural to you.  
  
## Using Entity SQL with the EntityClient provider  
 If you want to use Entity SQL with the EntityClient provider, see the following topics for more information:  
  
 [EntityClient Provider for the Entity Framework](../../../../../../docs/framework/data/adonet/ef/entityclient-provider-for-the-entity-framework.md)  
  
 [How to: Build an EntityConnection Connection String](../../../../../../docs/framework/data/adonet/ef/how-to-build-an-entityconnection-connection-string.md)  
  
 [How to: Execute a Query that Returns PrimitiveType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-primitivetype-results.md)  
  
 [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md)  
  
 [How to: Execute a Query that Returns RefType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-reftype-results.md)  
  
 [How to: Execute a Query that Returns Complex Types](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-complex-types.md)  
  
 [How to: Execute a Query that Returns Nested Collections](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-nested-collections.md)  
  
 [How to: Execute a Parameterized Entity SQL Query Using EntityCommand](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-parameterized-entity-sql-query-using-entitycommand.md)  
  
 [How to: Execute a Parameterized Stored Procedure Using EntityCommand](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-parameterized-stored-procedure-using-entitycommand.md)  
  
 [How to: Execute a Polymorphic Query](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-polymorphic-query.md)  
  
 [How to: Navigate Relationships with the Navigate Operator](../../../../../../docs/framework/data/adonet/ef/how-to-navigate-relationships-with-the-navigate-operator.md)  
  
## Using Entity SQL with object queries  
 If you want to use Entity SQL with object queries, see the following topics for more information:  
  
 [How to: Execute a Query that Returns Entity Type Objects](https://msdn.microsoft.com/library/bb738694(v=vs.110).aspx)  
  
 [How to: Execute a Parameterized Query](https://msdn.microsoft.com/library/bb738521(v=vs.110).aspx)  
  
 [How to: Navigate Relationships Using Navigation Properties](https://msdn.microsoft.com/library/bb896321(v=vs.110).aspx)  
  
 [How to: Call a User-Defined Function](https://msdn.microsoft.com/library/dd490951(v=vs.110).aspx)  
  
 [How to: Filter Data](https://msdn.microsoft.com/library/cc716755(v=vs.110).aspx)  
  
 [How to: Sort Data](https://msdn.microsoft.com/library/cc716784(v=vs.110).aspx)  
  
 [How to: Group Data](https://msdn.microsoft.com/library/bb896341(v=vs.110).aspx)  
  
 [How to: Aggregate Data](https://msdn.microsoft.com/library/cc716738(v=vs.110).aspx)  
  
 [How to: Execute a Query that Returns Anonymous Type Objects](https://msdn.microsoft.com/library/bb738512(v=vs.110).aspx)  
  
 [How to: Execute a Query that Returns a Collection of Primitive Types](https://msdn.microsoft.com/library/bb738451(v=vs.110).aspx)  
  
 [How to: Query Related Objects in an EntityCollection](https://msdn.microsoft.com/library/cc716708(v=vs.110).aspx)  
  
 [How to: Order the Union of Two Queries](https://msdn.microsoft.com/library/bb896299(v=vs.110).aspx)  
  
 [How to: Page Through Query Results](https://msdn.microsoft.com/library/bb738702(v=vs.110).aspx)  
  
## In This Section  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)  
  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
  
## See Also  
 [ADO.NET Entity Framework](../../../../../../docs/framework/data/adonet/ef/index.md)   
 [Language Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/index.md)
