---
description: "Learn more about: DbProviderFactories"
title: "DbProviderFactories"
ms.date: "10/19/2026"
ai-usage: ai-assisted
ms.assetid: 2a8e2640-3a49-42a1-a3a9-b43026907ae1
---
# DbProviderFactories

The <xref:System.Data.Common> namespace provides classes for creating <xref:System.Data.Common.DbProviderFactory> instances to work with specific data sources. When you create a <xref:System.Data.Common.DbProviderFactory> instance and pass it information about the data provider, the `DbProviderFactory` can determine the correct, strongly typed connection object to return based on the information it has been provided.  
  
 Beginning in the .NET Framework version 4, built-in data providers such as <xref:System.Data.Odbc>, <xref:System.Data.OleDb>, <xref:System.Data.SqlClient>, and <xref:System.Data.OracleClient> are no longer listed in machine.config file, but custom providers will continue to be listed there.

For SQL Server, use the [Microsoft.Data.SqlClient NuGet package](https://www.nuget.org/packages/Microsoft.Data.SqlClient). Register its <xref:Microsoft.Data.SqlClient.SqlClientFactory> in your application's configuration file on .NET Framework, or call <xref:System.Data.Common.DbProviderFactories.RegisterFactory*> on modern .NET. For both runtimes, use `Microsoft.Data.SqlClient` as the invariant provider name. For more information, see [Obtaining a DbProviderFactory](obtaining-a-dbproviderfactory.md).
  
## In This Section  

 [Factory Model Overview](factory-model-overview.md)  
 Provides an overview of the factory design pattern and programming interface.  
  
 [Obtaining a DbProviderFactory](obtaining-a-dbproviderfactory.md)  
 Demonstrates how to list the installed data providers and create a <xref:System.Data.Common.DbConnection> from a `DbProviderFactory`.  
  
 [DbConnection, DbCommand and DbException](dbconnection-dbcommand-and-dbexception.md)  
 Demonstrates how to create a <xref:System.Data.Common.DbCommand> and <xref:System.Data.Common.DbDataReader>, and how to handle data errors using <xref:System.Data.Common.DbException>.  
  
 [Modifying Data with a DbDataAdapter](modifying-data-with-a-dbdataadapter.md)  
 Demonstrates how to use a <xref:System.Data.Common.DbCommandBuilder> with a <xref:System.Data.Common.DbDataAdapter> to retrieve and modify data.  
  
## See also

- [Retrieving and Modifying Data in ADO.NET](retrieving-and-modifying-data.md)
- [ADO.NET Overview](ado-net-overview.md)
