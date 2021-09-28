---
title: "Retrieving and Modifying Data"
description: In the .NET Framework, data providers in ADO.NET serve as a bridge between an application and a data source to read and update data.
ms.date: "03/30/2017"
ms.assetid: 722e7f87-3691-46c6-87e8-7d159722d675
---
# Retrieving and Modifying Data in ADO.NET

A primary function of any database application is connecting to a data source and retrieving the data that it contains. The .NET Framework data providers of ADO.NET serve as a bridge between an application and a data source, allowing you to execute commands as well as to retrieve data by using a **DataReader** or a **DataAdapter**. A key function of any database application is the ability to update the data that is stored in the database. In ADO.NET, updating data involves using the **DataAdapter** and <xref:System.Data.DataSet>, and **Command** objects; and it may also involve using transactions.  
  
## In This Section  

 [Connecting to a Data Source](connecting-to-a-data-source.md)  
 Describes how to establish a connection to a data source and how to work with connection events.  
  
 [Connection Strings](connection-strings.md)  
 Contains topics describing various aspects of using connection strings, including connection string keywords, security info, and storing and retrieving them.  
  
 [Connection Pooling](connection-pooling.md)  
 Describes connection pooling for the .NET Framework data providers.  
  
 [Commands and Parameters](commands-and-parameters.md)  
 Contains topics describing how to create commands and command builders, configure parameters, and how to execute commands to retrieve and modify data.  
  
 [DataAdapters and DataReaders](dataadapters-and-datareaders.md)  
 Contains topics describing DataReaders, DataAdapters, parameters, handling DataAdapter events and performing batch operations.  
  
 [Transactions and Concurrency](transactions-and-concurrency.md)  
 Contains topics describing how to perform local transactions, distributed transactions, and work with optimistic concurrency.  
  
 [Retrieving Identity or Autonumber Values](retrieving-identity-or-autonumber-values.md)  
 Provides an example of mapping the values generated for an **identity** column in a SQL Server table or for an **Autonumber** field in a Microsoft Access table, to a column of an inserted row in a table. Discusses merging identity values in a `DataTable`.  
  
 [Retrieving Binary Data](retrieving-binary-data.md)  
 Describes how to retrieve binary data or large data structures using `CommandBehavior`.`SequentialAccess` to modify the default behavior of a `DataReader`.  
  
 [Modifying Data with Stored Procedures](modifying-data-with-stored-procedures.md)  
 Describes how to use stored procedure input parameters and output parameters to insert a row in a database, returning a new identity value.  
  
 [Retrieving Database Schema Information](retrieving-database-schema-information.md)  
 Describes how to obtain available databases or catalogs, tables and views in a database, constraints that exist for tables, and other schema information from a data source.  
  
 [DbProviderFactories](dbproviderfactories.md)  
 Describes the provider factory model and demonstrates how to use the base classes in the `System.Data.Common` namespace.  
  
 [Data Tracing in ADO.NET](data-tracing.md)  
 Describes how ADO.NET provides built-in data tracing functionality.  
  
 [Performance Counters](performance-counters.md)  
 Describes performance counters available for `SqlClient` and `OracleClient`.  
  
 [Asynchronous Programming](asynchronous-programming.md)  
 Describes ADO.NET support for asynchronous programming.  
  
 [SqlClient Streaming Support](sqlclient-streaming-support.md)  
 Discusses how to write applications that stream data from SQL Server without having it fully loaded in memory.  
  
## See also

- [Data Type Mappings in ADO.NET](data-type-mappings-in-ado-net.md)
- [DataSets, DataTables, and DataViews](./dataset-datatable-dataview/index.md)
- [Securing ADO.NET Applications](securing-ado-net-applications.md)
- [SQL Server and ADO.NET](./sql/index.md)
- [ADO.NET Overview](ado-net-overview.md)
