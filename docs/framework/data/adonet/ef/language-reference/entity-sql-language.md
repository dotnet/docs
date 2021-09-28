---
description: "Learn more about: Entity SQL Language"
title: "Entity SQL Language"
ms.date: "03/30/2017"
ms.assetid: 9e7d8837-28c5-429d-a824-7bafb59724cf
---
# Entity SQL Language

Entity SQL is a storage-independent query language that is similar to SQL. Entity SQL allows you to query entity data, either as objects or in a tabular form. You should consider using Entity SQL in the following cases:  
  
- When a query must be dynamically constructed at runtime. In this case, you should also consider using the query builder methods of <xref:System.Data.Objects.ObjectQuery%601> instead of constructing an Entity SQL query string at runtime.  
  
- When you want to define a query as part of the model definition. Only Entity SQL is supported in a data model. For more information, see [QueryView Element (MSL)](/ef/ef6/modeling/designer/advanced/edmx/msl-spec#queryview-element-msl)  
  
- When using EntityClient to return read-only entity data as rowsets using a <xref:System.Data.EntityClient.EntityDataReader>. For more information, see [EntityClient Provider for the Entity Framework](../entityclient-provider-for-the-entity-framework.md).  
  
- If you are already an expert in SQL-based query languages, Entity SQL may seem the most natural to you.  
  
## Using Entity SQL with the EntityClient provider  

 If you want to use Entity SQL with the EntityClient provider, see the following topics for more information:  
  
 [EntityClient Provider for the Entity Framework](../entityclient-provider-for-the-entity-framework.md)  
  
 [How to: Build an EntityConnection Connection String](../how-to-build-an-entityconnection-connection-string.md)  
  
 [How to: Execute a Query that Returns PrimitiveType Results](../how-to-execute-a-query-that-returns-primitivetype-results.md)  
  
 [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md)  
  
 [How to: Execute a Query that Returns RefType Results](../how-to-execute-a-query-that-returns-reftype-results.md)  
  
 [How to: Execute a Query that Returns Complex Types](../how-to-execute-a-query-that-returns-complex-types.md)  
  
 [How to: Execute a Query that Returns Nested Collections](../how-to-execute-a-query-that-returns-nested-collections.md)  
  
 [How to: Execute a Parameterized Entity SQL Query Using EntityCommand](../how-to-execute-a-parameterized-entity-sql-query-using-entitycommand.md)  
  
 [How to: Execute a Parameterized Stored Procedure Using EntityCommand](../how-to-execute-a-parameterized-stored-procedure-using-entitycommand.md)  
  
 [How to: Execute a Polymorphic Query](../how-to-execute-a-polymorphic-query.md)  
  
 [How to: Navigate Relationships with the Navigate Operator](../how-to-navigate-relationships-with-the-navigate-operator.md)  
  
## Using Entity SQL with object queries  

 If you want to use Entity SQL with object queries, see the following topics for more information:  
  
 [How to: Execute a Query that Returns Entity Type Objects](/previous-versions/dotnet/netframework-4.0/bb738694(v=vs.100))  
  
 [How to: Execute a Parameterized Query](/previous-versions/dotnet/netframework-4.0/bb738521(v=vs.100))  
  
 [How to: Navigate Relationships Using Navigation Properties](/previous-versions/dotnet/netframework-4.0/bb896321(v=vs.100))  
  
 [How to: Call a User-Defined Function](/previous-versions/dotnet/netframework-4.0/dd490951(v=vs.100))  
  
 [How to: Filter Data](/previous-versions/dotnet/netframework-4.0/cc716755(v=vs.100))  
  
 [How to: Sort Data](/previous-versions/dotnet/netframework-4.0/cc716784(v=vs.100))  
  
 [How to: Group Data](/previous-versions/dotnet/netframework-4.0/bb896341(v=vs.100))  
  
 [How to: Aggregate Data](/previous-versions/dotnet/netframework-4.0/cc716738(v=vs.100))  
  
 [How to: Execute a Query that Returns Anonymous Type Objects](/previous-versions/dotnet/netframework-4.0/bb738512(v=vs.100))  
  
 [How to: Execute a Query that Returns a Collection of Primitive Types](/previous-versions/dotnet/netframework-4.0/bb738451(v=vs.100))  
  
 [How to: Query Related Objects in an EntityCollection](/previous-versions/dotnet/netframework-4.0/cc716708(v=vs.100))  
  
 [How to: Order the Union of Two Queries](/previous-versions/dotnet/netframework-4.0/bb896299(v=vs.100))  
  
 [How to: Page Through Query Results](/previous-versions/dotnet/netframework-4.0/bb738702(v=vs.100))  
  
## In This Section  

 [Entity SQL Overview](entity-sql-overview.md)  
  
 [Entity SQL Reference](entity-sql-reference.md)  
  
## See also

- [ADO.NET Entity Framework](../index.md)
- [Language Reference](index.md)
