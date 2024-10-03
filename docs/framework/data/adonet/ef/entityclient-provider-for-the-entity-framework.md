---
description: "Learn more about EntityClient Provider for Entity Framework, a data provider used by Entity Framework apps to access data described in a conceptual model."
title: "EntityClient Provider for the Entity Framework"
ms.date: "03/30/2017"
---
# EntityClient Provider for Entity Framework

The EntityClient provider is a data provider used by Entity Framework applications to access data described in a conceptual model. For information about conceptual models, see [Modeling and Mapping](modeling-and-mapping.md). EntityClient uses other .NET Framework data providers to access the data source. For example, EntityClient uses the .NET Framework Data Provider for SQL Server (SqlClient) when accessing a SQL Server database. For information about the SqlClient provider, see [SqlClient for the Entity Framework](sqlclient-for-the-entity-framework.md). The EntityClient provider is implemented in the <xref:System.Data.EntityClient> namespace.

## Managing Connections

 The Entity Framework builds on top of storage-specific ADO.NET data providers by providing an <xref:System.Data.EntityClient.EntityConnection> to an underlying data provider and relational database. To construct an <xref:System.Data.EntityClient.EntityConnection> object, you have to reference a set of metadata that contains the necessary models and mapping, and also a storage-specific data provider name and connection string. After the <xref:System.Data.EntityClient.EntityConnection> is in place, entities can be accessed through the classes generated from the conceptual model.

 You can specify a connection string in app.config file.

 The <xref:System.Data.EntityClient> also includes the <xref:System.Data.EntityClient.EntityConnectionStringBuilder> class. This class enables developers to programmatically create syntactically correct connection strings, and parse and rebuild existing connection strings, by using properties and methods of the class.

## Creating Queries

 The Entity SQL language is a storage-independent dialect of SQL that works directly with conceptual entity schemas and supports Entity Data Model concepts such as inheritance and relationships. The <xref:System.Data.EntityClient.EntityCommand> class is used to execute an Entity SQL command against an entity model. When you construct <xref:System.Data.EntityClient.EntityCommand> objects, you can specify a stored procedure name or a query text. The Entity Framework works with storage-specific data providers to translate generic Entity SQL into storage-specific queries. For more information about writing Entity SQL queries, see [Entity SQL Language](./language-reference/entity-sql-language.md).

 The following example creates an <xref:System.Data.EntityClient.EntityCommand> object and assigns an Entity SQL query text to its <xref:System.Data.EntityClient.EntityCommand.CommandText%2A?displayProperty=nameWithType> property. This Entity SQL query requests products ordered by the list price from the conceptual model. The following code has no knowledge of the storage model at all.

 ```csharp
EntityCommand cmd = conn.CreateCommand();
cmd.CommandText = @"SELECT VALUE p
  FROM AdventureWorksEntities.Product AS p
  ORDER BY p.ListPrice";
```

## Executing Queries

 When a query is executed, it is parsed and converted into a canonical command tree. All subsequent processing is performed on the command tree. The command tree is the means of communication between the <xref:System.Data.EntityClient> and the underlying .NET Framework data provider, such as <xref:System.Data.SqlClient>.

 The <xref:System.Data.EntityClient.EntityDataReader> exposes the results of executing a <xref:System.Data.EntityClient.EntityCommand> against a conceptual model. To execute the command that returns the <xref:System.Data.EntityClient.EntityDataReader>, call <xref:System.Data.EntityClient.EntityCommand.ExecuteReader%2A>. The <xref:System.Data.EntityClient.EntityDataReader> implements <xref:System.Data.IExtendedDataRecord> to describe rich structured results.

## Managing Transactions

 In the Entity Framework, there are two ways to use transactions: automatic and explicit. Automatic transactions use the <xref:System.Transactions> namespace, and explicit transactions use the <xref:System.Data.EntityClient.EntityTransaction> class.

 To update data that is exposed through a conceptual model, see [How to: Manage Transactions in the Entity Framework](/previous-versions/dotnet/netframework-4.0/bb738523(v=vs.100)).

## In This Section

 [How to: Execute a Query that Returns PrimitiveType Results](how-to-execute-a-query-that-returns-primitivetype-results.md)

 [How to: Execute a Query that Returns StructuralType Results](how-to-execute-a-query-that-returns-structuraltype-results.md)

 [How to: Execute a Query that Returns RefType Results](how-to-execute-a-query-that-returns-reftype-results.md)

 [How to: Execute a Query that Returns Complex Types](how-to-execute-a-query-that-returns-complex-types.md)

 [How to: Execute a Query that Returns Nested Collections](how-to-execute-a-query-that-returns-nested-collections.md)

 [How to: Execute a Parameterized Entity SQL Query Using EntityCommand](how-to-execute-a-parameterized-entity-sql-query-using-entitycommand.md)

 [How to: Execute a Parameterized Stored Procedure Using EntityCommand](how-to-execute-a-parameterized-stored-procedure-using-entitycommand.md)

 [How to: Execute a Polymorphic Query](how-to-execute-a-polymorphic-query.md)

 [How to: Navigate Relationships with the Navigate Operator](how-to-navigate-relationships-with-the-navigate-operator.md)

## See also

- [Managing Connections and Transactions](/previous-versions/dotnet/netframework-4.0/bb896325(v=vs.100))
- [ADO.NET Entity Framework](index.md)
- [Language Reference](./language-reference/index.md)
