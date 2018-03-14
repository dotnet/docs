---
title: "Entity SQL Language"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9e7d8837-28c5-429d-a824-7bafb59724cf
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Entity SQL Language
Entity SQL is a storage-independent query language that is similar to SQL. Entity SQL allows you to query entity data, either as objects or in a tabular form. You should consider using Entity SQL in the following cases:  
  
-   When a query must be dynamically constructed at runtime. In this case, you should also consider using the query builder methods of <xref:System.Data.Objects.ObjectQuery%601> instead of constructing an Entity SQL query string at runtime.  
  
-   When you want to define a query as part of the model definition. Only Entity SQL is supported in a data model. For more information, see [QueryView Element (MSL)](http://msdn.microsoft.com/library/f0426b34-45cb-4fd7-9777-e0570c5e0e80)  
  
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
  
 [How to: Execute a Query that Returns Entity Type Objects](http://msdn.microsoft.com/library/f73e137d-1534-42bb-9e31-99ca42c19b48)  
  
 [How to: Execute a Parameterized Query](http://msdn.microsoft.com/library/42048f03-c65c-4d98-b50a-3e7d537a63e8)  
  
 [How to: Navigate Relationships Using Navigation Properties](http://msdn.microsoft.com/library/b1d71c7d-16a7-4b46-96ac-690176bd5057)  
  
 [How to: Call a User-Defined Function](http://msdn.microsoft.com/library/ad131b86-8b4e-4747-8605-d4fc64fb9d02)  
  
 [How to: Filter Data](http://msdn.microsoft.com/library/776f8556-3350-4572-804a-b1513515c1b2)  
  
 [How to: Sort Data](http://msdn.microsoft.com/library/c05f2506-cb9d-4ebc-822b-300042ad53e7)  
  
 [How to: Group Data](http://msdn.microsoft.com/library/df801d9d-9a8a-4157-97a6-5016b18998e1)  
  
 [How to: Aggregate Data](http://msdn.microsoft.com/library/4cf04ce8-3c0f-4f88-9d97-8fac8622598d)  
  
 [How to: Execute a Query that Returns Anonymous Type Objects](http://msdn.microsoft.com/library/3b264025-e911-4d73-90ce-992d2b9d189d)  
  
 [How to: Execute a Query that Returns a Collection of Primitive Types](http://msdn.microsoft.com/library/115b52c0-4f27-4253-8991-284b450000b5)  
  
 [How to: Query Related Objects in an EntityCollection](http://msdn.microsoft.com/library/11ce946f-16f8-4c1d-9d80-f740853807ba)  
  
 [How to: Order the Union of Two Queries](http://msdn.microsoft.com/library/853c583a-eaba-4400-830d-be974e735313)  
  
 [How to: Page Through Query Results](http://msdn.microsoft.com/library/ffc0f920-e7de-42e0-9b12-ef356421d030)  
  
## In This Section  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)  
  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
  
## See Also  
 [ADO.NET Entity Framework](../../../../../../docs/framework/data/adonet/ef/index.md)  
 [Language Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/index.md)
