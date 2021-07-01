---
title: "SQL Server and ADO.NET"
description: Learn about features and behaviors of the .NET Framework Data Provider for SQL Server, which encapsulates database-specific protocols.
titleSuffix: ""
ms.date: "03/30/2017"
ms.assetid: c18b1fb1-2af1-4de7-80a4-95e56fd976cb
---
# SQL Server and ADO.NET

This section describes features and behaviors that are specific to the .NET Framework Data Provider for SQL Server (<xref:System.Data.SqlClient>).

 <xref:System.Data.SqlClient> provides access to versions of SQL Server, which encapsulates database-specific protocols. The functionality of the data provider is designed to be similar to that of the .NET Framework data providers for OLE DB, ODBC, and Oracle. <xref:System.Data.SqlClient> includes a tabular data stream (TDS) parser to communicate directly with SQL Server.

> [!NOTE]
> To use the .NET Framework Data Provider for SQL Server, an application must reference the <xref:System.Data.SqlClient> namespace.

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
