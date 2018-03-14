---
title: "DataAdapters and DataReaders"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cc952ca2-ec19-46ab-9189-15174b52cb74
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# DataAdapters and DataReaders
You can use the ADO.NET **DataReader** to retrieve a read-only, forward-only stream of data from a database. Results are returned as the query executes, and are stored in the network buffer on the client until you request them using the **Read** method of the **DataReader**. Using the **DataReader** can increase application performance both by retrieving data as soon as it is available, and (by default) storing only one row at a time in memory, reducing system overhead.  
  
 A <xref:System.Data.Common.DataAdapter> is used to retrieve data from a data source and populate tables within a <xref:System.Data.DataSet>. The `DataAdapter` also resolves changes made to the `DataSet` back to the data source. The `DataAdapter` uses the `Connection` object of the .NET Framework data provider to connect to a data source, and it uses `Command` objects to retrieve data from and resolve changes to the data source.  
  
 Each .NET Framework data provider included with the .NET Framework has a <xref:System.Data.Common.DbDataReader> and a <xref:System.Data.Common.DbDataAdapter> object: the .NET Framework Data Provider for OLE DB includes an <xref:System.Data.OleDb.OleDbDataReader> and an <xref:System.Data.OleDb.OleDbDataAdapter> object, the .NET Framework Data Provider for SQL Server includes a <xref:System.Data.SqlClient.SqlDataReader> and a <xref:System.Data.SqlClient.SqlDataAdapter> object, the .NET Framework Data Provider for ODBC includes an <xref:System.Data.Odbc.OdbcDataReader> and an <xref:System.Data.Odbc.OdbcDataAdapter> object, and the .NET Framework Data Provider for Oracle includes an <xref:System.Data.OracleClient.OracleDataReader> and an <xref:System.Data.OracleClient.OracleDataAdapter> object.  
  
## In This Section  
 [Retrieving Data Using a DataReader](../../../../docs/framework/data/adonet/retrieving-data-using-a-datareader.md)  
 Describes the ADO.NET **DataReader** object and how to use it to return a stream of results from a data source.  
  
 [Populating a DataSet from a DataAdapter](../../../../docs/framework/data/adonet/populating-a-dataset-from-a-dataadapter.md)  
 Describes how to fill a `DataSet` with tables, columns, and rows by using a `DataAdapter`.  
  
 [DataAdapter Parameters](../../../../docs/framework/data/adonet/dataadapter-parameters.md)  
 Describes how to use parameters with the command properties of a `DataAdapter` including how to map the contents of a column in a `DataSet` to a command parameter.  
  
 [Adding Existing Constraints to a DataSet](../../../../docs/framework/data/adonet/adding-existing-constraints-to-a-dataset.md)  
 Describes how to add existing constraints to a `DataSet`.  
  
 [DataAdapter DataTable and DataColumn Mappings](../../../../docs/framework/data/adonet/dataadapter-datatable-and-datacolumn-mappings.md)  
 Describes how to set up `DataTableMappings` and `ColumnMappings` for a `DataAdapter`.  
  
 [Paging Through a Query Result](../../../../docs/framework/data/adonet/paging-through-a-query-result.md)  
 Provides an example of viewing the results of a query as pages of data.  
  
 [Updating Data Sources with DataAdapters](../../../../docs/framework/data/adonet/updating-data-sources-with-dataadapters.md)  
 Describes how to use a `DataAdapter` to resolve changes in a `DataSet` back to the database.  
  
 [Handling DataAdapter Events](../../../../docs/framework/data/adonet/handling-dataadapter-events.md)  
 Describes `DataAdapter` events and how to use them.  
  
 [Performing Batch Operations Using DataAdapters](../../../../docs/framework/data/adonet/performing-batch-operations-using-dataadapters.md)  
 Describes enhancing application performance by reducing the number of round trips to SQL Server when applying updates from the `DataSet`.  
  
## See Also  
 [Connecting to a Data Source](../../../../docs/framework/data/adonet/connecting-to-a-data-source.md)  
 [Commands and Parameters](../../../../docs/framework/data/adonet/commands-and-parameters.md)  
 [Transactions and Concurrency](../../../../docs/framework/data/adonet/transactions-and-concurrency.md)  
 [DataSets, DataTables, and DataViews](../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
