---
title: "Retrieving and Modifying Data in ADO.NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 722e7f87-3691-46c6-87e8-7d159722d675
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Retrieving and Modifying Data in ADO.NET
A primary function of any database application is connecting to a data source and retrieving the data that it contains. The .NET Framework data providers of ADO.NET serve as a bridge between an application and a data source, allowing you to execute commands as well as to retrieve data by using a **DataReader** or a **DataAdapter**. A key function of any database application is the ability to update the data that is stored in the database. In ADO.NET, updating data involves using the **DataAdapter** and <xref:System.Data.DataSet>, and **Command** objects; and it may also involve using transactions.  
  
## In This Section  
 [Connecting to a Data Source](../../../../docs/framework/data/adonet/connecting-to-a-data-source.md)  
 Describes how to establish a connection to a data source and how to work with connection events.  
  
 [Connection Strings](../../../../docs/framework/data/adonet/connection-strings.md)  
 Contains topics describing various aspects of using connection strings, including connection string keywords, security info, and storing and retrieving them.  
  
 [Connection Pooling](../../../../docs/framework/data/adonet/connection-pooling.md)  
 Describes connection pooling for the .NET Framework data providers.  
  
 [Commands and Parameters](../../../../docs/framework/data/adonet/commands-and-parameters.md)  
 Contains topics describing how to create commands and command builders, configure parameters, and how to execute commands to retrieve and modify data.  
  
 [DataAdapters and DataReaders](../../../../docs/framework/data/adonet/dataadapters-and-datareaders.md)  
 Contains topics describing DataReaders, DataAdapters, parameters, handling DataAdapter events and performing batch operations.  
  
 [Transactions and Concurrency](../../../../docs/framework/data/adonet/transactions-and-concurrency.md)  
 Contains topics describing how to perform local transactions, distributed transactions, and work with optimistic concurrency.  
  
 [Retrieving Identity or Autonumber Values](../../../../docs/framework/data/adonet/retrieving-identity-or-autonumber-values.md)  
 Provides an example of mapping the values generated for an **identity** column in a [!INCLUDE[ssNoVersion](../../../../includes/ssnoversion-md.md)] table or for an **Autonumber** field in a Microsoft Access table, to a column of an inserted row in a table. Discusses merging identity values in a `DataTable`.  
  
 [Retrieving Binary Data](../../../../docs/framework/data/adonet/retrieving-binary-data.md)  
 Describes how to retrieve binary data or large data structures using `CommandBehavior`.`SequentialAccess` to modify the default behavior of a `DataReader`.  
  
 [Modifying Data with Stored Procedures](../../../../docs/framework/data/adonet/modifying-data-with-stored-procedures.md)  
 Describes how to use stored procedure input parameters and output parameters to insert a row in a database, returning a new identity value.  
  
 [Retrieving Database Schema Information](../../../../docs/framework/data/adonet/retrieving-database-schema-information.md)  
 Describes how to obtain available databases or catalogs, tables and views in a database, constraints that exist for tables, and other schema information from a data source.  
  
 [DbProviderFactories](../../../../docs/framework/data/adonet/dbproviderfactories.md)  
 Describes the provider factory model and demonstrates how to use the base classes in the `System.Data.Common` namespace.  
  
 [Data Tracing in ADO.NET](../../../../docs/framework/data/adonet/data-tracing.md)  
 Describes how ADO.NET provides built-in data tracing functionality.  
  
 [Performance Counters](../../../../docs/framework/data/adonet/performance-counters.md)  
 Describes performance counters available for `SqlClient` and `OracleClient`.  
  
 [Asynchronous Programming](../../../../docs/framework/data/adonet/asynchronous-programming.md)  
 Describes [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)] support for asynchronous programming.  
  
 [SqlClient Streaming Support](../../../../docs/framework/data/adonet/sqlclient-streaming-support.md)  
 Discusses how to write applications that stream data from [!INCLUDE[ssNoVersion](../../../../includes/ssnoversion-md.md)] without having it fully loaded in memory.  
  
## See Also  
 [Data Type Mappings in ADO.NET](../../../../docs/framework/data/adonet/data-type-mappings-in-ado-net.md)  
 [DataSets, DataTables, and DataViews](../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [Securing ADO.NET Applications](../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [SQL Server and ADO.NET](../../../../docs/framework/data/adonet/sql/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
