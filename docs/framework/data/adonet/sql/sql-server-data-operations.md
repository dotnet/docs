---
description: "Learn more about: SQL Server Data Operations in ADO.NET"
title: "SQL Server Data Operations"
ms.date: "10/19/2026"
ai-usage: ai-assisted
ms.assetid: b864ebc9-ed8e-4059-85fd-36d9198f5521
---
# SQL Server Data Operations in ADO.NET

This section describes SQL Server features available through <xref:Microsoft.Data.SqlClient>. For standalone client applications, install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package. The examples use version 7.1.1. Import `Microsoft.Data.SqlClient` for connection, command, reader, adapter, and bulk-copy types. Continue to use `System.Data` for provider-independent types such as `DataTable`, `SqlDbType`, and `IsolationLevel`.
  
## In This Section  

 [Bulk Copy Operations in SQL Server](bulk-copy-operations-in-sql-server.md)  
 Describes the bulk copy functionality for Microsoft.Data.SqlClient.
  
 [Multiple Active Result Sets (MARS)](multiple-active-result-sets-mars.md)  
 Describes how to have more than one <xref:Microsoft.Data.SqlClient.SqlDataReader> open on a connection when each instance of <xref:Microsoft.Data.SqlClient.SqlDataReader> is started from a separate command.
  
 [Asynchronous Operations](asynchronous-operations.md)  
 Describes how to perform asynchronous database operations by using an API that is modeled after the asynchronous model used by the .NET Framework.  
  
 [Table-Valued Parameters](table-valued-parameters.md)  
 Describes how to work with table-valued parameters, which were introduced in SQL Server 2008.  
  
## See also

- [Retrieving and Modifying Data in ADO.NET](../retrieving-and-modifying-data.md)
- [SQL Server and ADO.NET](index.md)
- [ADO.NET Overview](../ado-net-overview.md)
