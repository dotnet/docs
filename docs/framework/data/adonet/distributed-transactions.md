---
title: "Distributed Transactions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 718b257c-bcb2-408e-b004-a7b0adb1c176
caps.latest.revision: 7
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Distributed Transactions
A transaction is a set of related tasks that either succeeds (commit) or fails (abort) as a unit, among other things. A *distributed transaction* is a transaction that affects several resources. For a distributed transaction to commit, all participants must guarantee that any change to data will be permanent. Changes must persist despite system crashes or other unforeseen events. If even a single participant fails to make this guarantee, the entire transaction fails, and any changes to data within the scope of the transaction are rolled back.  
  
> [!NOTE]
>  An exception will be thrown if you attempt to commit or roll back a transaction if a `DataReader` is started while the transaction is active.  
  
## Working with System.Transactions  
 In the .NET Framework, distributed transactions are managed through the API in the <xref:System.Transactions> namespace. The <xref:System.Transactions> API will delegate distributed transaction handling to a transaction monitor such as the Microsoft Distributed Transaction Coordinator (MS DTC) when multiple persistent resource managers are involved. For more information, see [Transaction Fundamentals](../../../../docs/framework/data/transactions/transaction-fundamentals.md).  
  
 ADO.NET 2.0 introduced support for enlisting in a distributed transaction using the `EnlistTransaction` method, which enlists a connection in a <xref:System.Transactions.Transaction> instance. In previous versions of ADO.NET, explicit enlistment in distributed transactions was performed using the `EnlistDistributedTransaction` method of a connection to enlist a connection in a <xref:System.EnterpriseServices.ITransaction> instance, which is supported for backwards compatibility. For more information on Enterprise Services transactions, see [Interoperability with Enterprise Services and COM+ Transactions](../../../../docs/framework/data/transactions/interoperability-with-enterprise-services-and-com-transactions.md).  
  
 When using a <xref:System.Transactions> transaction with the .NET Framework Provider for SQL Server against a SQL Server database, a lightweight <xref:System.Transactions.Transaction> will automatically be used. The transaction can then be promoted to a full distributed transaction on an as-needed basis. For more information, see [System.Transactions Integration with SQL Server](../../../../docs/framework/data/adonet/system-transactions-integration-with-sql-server.md).  
  
> [!NOTE]
>  The maximum number of distributed transactions that an Oracle database can participate in at one time is set to 10 by default. After the 10th transaction when connected to an Oracle database, an exception is thrown. Oracle does not support `DDL` inside of a distributed transaction.  
  
## Automatically Enlisting in a Distributed Transaction  
 Automatic enlistment is the default (and preferred) way of integrating ADO.NET connections with `System.Transactions`. A connection object will automatically enlist in an existing distributed transaction if it determines that a transaction is active, which, in `System.Transaction` terms, means that `Transaction.Current` is not null. Automatic transaction enlistment occurs when the connection is opened. It will not happen after that even if a command is executed inside of a transaction scope. You can disable auto-enlistment in existing transactions by specifying `Enlist=false` as a connection string parameter for a <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A?displayProperty=nameWithType>, or `OLE DB Services=-7` as a connection string parameter for an <xref:System.Data.OleDb.OleDbConnection.ConnectionString%2A?displayProperty=nameWithType>. For more information on Oracle and ODBC connection string parameters, see <xref:System.Data.OracleClient.OracleConnection.ConnectionString%2A?displayProperty=nameWithType> and <xref:System.Data.Odbc.OdbcConnection.ConnectionString%2A?displayProperty=nameWithType>.  
  
## Manually Enlisting in a Distributed Transaction  
 If auto-enlistment is disabled or you need to enlist a transaction that was started after the connection was opened, you can enlist in an existing distributed transaction using the `EnlistTransaction` method of the <xref:System.Data.Common.DbConnection> object for the provider you are working with. Enlisting in an existing distributed transaction ensures that, if the transaction is committed or rolled back, modifications made by the code at the data source will be committed or rolled back as well.  
  
 Enlisting in distributed transactions is particularly applicable when pooling business objects. If a business object is pooled with an open connection, automatic transaction enlistment only occurs when that connection is opened. If multiple transactions are performed using the pooled business object, the open connection for that object will not automatically enlist in newly initiated transactions. In this case, you can disable automatic transaction enlistment for the connection and enlist the connection in transactions using `EnlistTransaction`.  
  
 `EnlistTransaction` takes a single argument of type <xref:System.Transactions.Transaction> that is a reference to the existing transaction. After calling the connection's `EnlistTransaction` method, all modifications made at the data source using the connection are included in the transaction. Passing a null value unenlists the connection from its current distributed transaction enlistment. Note that the connection must be opened before calling `EnlistTransaction`.  
  
> [!NOTE]
>  Once a connection is explicitly enlisted on a transaction, it cannot be un-enlisted or enlisted in another transaction until the first transaction finishes.  
  
> [!CAUTION]
>  `EnlistTransaction` throws an exception if the connection has already begun a transaction using the connection's <xref:System.Data.Common.DbConnection.BeginTransaction%2A> method. However, if the transaction is a local transaction started at the data source (for example, executing the BEGIN TRANSACTION statement explicitly using a <xref:System.Data.SqlClient.SqlCommand>), `EnlistTransaction` will roll back the local transaction and enlist in the existing distributed transaction as requested. You will not receive notice that the local transaction was rolled back, and must manage any local transactions not started using <xref:System.Data.Common.DbConnection.BeginTransaction%2A>. If you are using the .NET Framework Data Provider for SQL Server (`SqlClient`) with SQL Server, an attempt to enlist will throw an exception. All other cases will go undetected.  
  
## Promotable Transactions in SQL Server  
 SQL Server supports promotable transactions in which a local lightweight transaction can be automatically promoted to a distributed transaction only if it is required. A promotable transaction does not invoke the added overhead of a distributed transaction unless the added overhead is required. For more information and a code sample, see [System.Transactions Integration with SQL Server](../../../../docs/framework/data/adonet/system-transactions-integration-with-sql-server.md).  
  
## Configuring Distributed Transactions  
 You may need to enable the MS DTC over the network in order to use distributed transactions. If have the Windows Firewall enabled, you must allow the MS DTC service to use the network or open the MS DTC port.  
  
## See Also  
 [Transactions and Concurrency](../../../../docs/framework/data/adonet/transactions-and-concurrency.md)  
 [System.Transactions Integration with SQL Server](../../../../docs/framework/data/adonet/system-transactions-integration-with-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
