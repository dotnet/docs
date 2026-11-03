---
title: "SQL Server and ADO.NET"
description: Learn about SQL Server features and behaviors exposed through Microsoft.Data.SqlClient and the provider requirements of .NET Framework integrations.
titleSuffix: ""
ms.date: "10/19/2026"
ai-usage: ai-assisted
ms.assetid: c18b1fb1-2af1-4de7-80a4-95e56fd976cb
---
# SQL Server and ADO.NET

For new SQL Server applications, use the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package. For runnable C# and Visual Basic examples, see [ADO.NET code examples](../ado-net-code-examples.md#sqlclient). For current provider documentation, see [Microsoft SqlClient Data Provider for SQL Server](/sql/connect/ado-net/overview-sqlclient-driver).

This section describes SQL Server features and behaviors exposed through <xref:Microsoft.Data.SqlClient>. The provider communicates directly with SQL Server through the tabular data stream (TDS) protocol.

Some .NET Framework integrations, including LINQ to SQL and SQL Server common language runtime (CLR) context connections, still require <xref:System.Data.SqlClient>. The relevant articles explain these provider requirements.

## In This Section

 [SQL Server Data Types and ADO.NET](sql-server-data-types.md)\
 Describes how to work with SQL Server data types and how they interact with .NET Framework data types.

 [SQL Server Binary and Large-Value Data](sql-server-binary-and-large-value-data.md)\
 Describes how to work with large value data in SQL Server.

 [SQL Server Data Operations in ADO.NET](sql-server-data-operations.md)\
 Describes how to work with data in SQL Server. Contains sections about bulk copy operations, MARS, asynchronous operations, and table-valued parameters.

 [SQL Server Features and ADO.NET](sql-server-features-and-adonet.md)\
 Describes SQL Server features that are useful for ADO.NET application developers.

 [LINQ to SQL](./linq/index.md)\
 Describes the basic building blocks, processes, and techniques required for creating LINQ to SQL applications.

 For complete documentation of the SQL Server Database Engine, see [SQL Server technical documentation](/sql/sql-server/sql-server-technical-documentation).

## See also

- [Securing ADO.NET Applications](../securing-ado-net-applications.md)
- [Data Type Mappings in ADO.NET](../data-type-mappings-in-ado-net.md)
- [DataSets, DataTables, and DataViews](../dataset-datatable-dataview/index.md)
- [Retrieving and Modifying Data in ADO.NET](../retrieving-and-modifying-data.md)
- [ADO.NET Overview](../ado-net-overview.md)
