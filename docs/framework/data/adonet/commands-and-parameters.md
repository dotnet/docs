---
title: "Commands and Parameters"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b623f810-d871-49a5-b0f5-078cc3c34db6
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Commands and Parameters
After establishing a connection to a data source, you can execute commands and return results from the data source using a <xref:System.Data.Common.DbCommand> object. You can create a command using one of the command constructors for the .NET Framework data provider you are working with. Constructors can take optional arguments, such as an SQL statement to execute at the data source, a <xref:System.Data.Common.DbConnection> object, or a <xref:System.Data.Common.DbTransaction> object. You can also configure those objects as properties of the command. You can also create a command for a particular connection using the <xref:System.Data.Common.DbConnection.CreateCommand%2A> method of a `DbConnection` object. The SQL statement being executed by the command can be configured using the <xref:System.Data.Common.DbCommand.CommandText%2A> property.  
  
 Each .NET Framework data provider included with the .NET Framework has a `Command` object. The .NET Framework Data Provider for OLE DB includes an <xref:System.Data.OleDb.OleDbCommand> object, the .NET Framework Data Provider for SQL Server includes a <xref:System.Data.SqlClient.SqlCommand> object, the .NET Framework Data Provider for ODBC includes an <xref:System.Data.Odbc.OdbcCommand> object, and the .NET Framework Data Provider for Oracle includes an <xref:System.Data.OracleClient.OracleCommand> object.  
  
## In This Section  
 [Executing a Command](../../../../docs/framework/data/adonet/executing-a-command.md)  
 Describes the ADO.NET `Command` object and how to use it to execute queries and commands against a data source.  
  
 [Configuring Parameters and Parameter Data Types](../../../../docs/framework/data/adonet/configuring-parameters-and-parameter-data-types.md)  
 Describes working with `Command` parameters, including direction, data types, and parameter syntax.  
  
 [Generating Commands with CommandBuilders](../../../../docs/framework/data/adonet/generating-commands-with-commandbuilders.md)  
 Describes how to use command builders to automatically generate INSERT, UPDATE, and DELETE commands for a `DataAdapter` that has a single-table SELECT command.  
  
 [Obtaining a Single Value from a Database](../../../../docs/framework/data/adonet/obtaining-a-single-value-from-a-database.md)  
 Describes how to use the `ExecuteScalar` method of a `Command` object to return a single value from a database query.  
  
 [Using Commands to Modify Data](../../../../docs/framework/data/adonet/using-commands-to-modify-data.md)  
 Describes how to use a data provider to execute stored procedures or data definition language (DDL) statements.  
  
## See Also  
 [DataAdapters and DataReaders](../../../../docs/framework/data/adonet/dataadapters-and-datareaders.md)  
 [DataSets, DataTables, and DataViews](../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [Connecting to a Data Source](../../../../docs/framework/data/adonet/connecting-to-a-data-source.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
