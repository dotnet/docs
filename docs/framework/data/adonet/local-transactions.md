---
title: "Local Transactions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 8ae3712f-ef5e-41a1-9ea9-b3d0399439f1
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Local Transactions
Transactions in [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)] are used when you want to bind multiple tasks together so that they execute as a single unit of work. For example, imagine that an application performs two tasks. First, it updates a table with order information. Second, it updates a table that contains inventory information, debiting the items ordered. If either task fails, then both updates are rolled back.  
  
## Determining the Transaction Type  
 A transaction is considered to be a local transaction when it is a single-phase transaction and is handled by the database directly. A transaction is considered to be a distributed transaction when it is coordinated by a transaction monitor and uses fail-safe mechanisms (such as two-phase commit) for transaction resolution.  
  
 Each of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data providers has its own `Transaction` object for performing local transactions. If you require a transaction to be performed in a SQL Server database, select a <xref:System.Data.SqlClient> transaction. For an Oracle transaction, use the <xref:System.Data.OracleClient> provider. In addition, there is a <xref:System.Data.Common.DbTransaction> class that is available for writing provider-independent code that requires transactions.  
  
> [!NOTE]
>  Transactions are most efficient when it is performed on the server. If you are working with a SQL Server database that makes extensive use of explicit transactions, consider writing them as stored procedures using the Transact-SQL BEGIN TRANSACTION statement. For more information about performing server-side transactions, see SQL Server Books Online.  
  
## Performing a Transaction Using a Single Connection  
 In [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)], you control transactions with the `Connection` object. You can initiate a local transaction with the `BeginTransaction` method. Once you have begun a transaction, you can enlist a command in that transaction with the `Transaction` property of a `Command` object. You can then commit or roll back modifications made at the data source based on the success or failure of the components of the transaction.  
  
> [!NOTE]
>  The `EnlistDistributedTransaction` method should not be used for a local transaction.  
  
 The scope of the transaction is limited to the connection. The following example performs an explicit transaction that consists of two separate commands in the `try` block. The commands execute INSERT statements against the Production.ScrapReason table in the AdventureWorks [!INCLUDE[ssNoVersion](../../../../includes/ssnoversion-md.md)] sample database, which are committed if no exceptions are thrown. The code in the `catch` block rolls back the transaction if an exception is thrown. If the transaction is aborted or the connection is closed before the transaction has completed, it is automatically rolled back.  
  
## Example  
 Follow these steps to perform a transaction.  
  
1.  Call the <xref:System.Data.SqlClient.SqlConnection.BeginTransaction%2A> method of the <xref:System.Data.SqlClient.SqlConnection> object to mark the start of the transaction. The <xref:System.Data.SqlClient.SqlConnection.BeginTransaction%2A> method returns a reference to the transaction. This reference is assigned to the <xref:System.Data.SqlClient.SqlCommand> objects that are enlisted in the transaction.  
  
2.  Assign the `Transaction` object to the <xref:System.Data.SqlClient.SqlCommand.Transaction%2A> property of the <xref:System.Data.SqlClient.SqlCommand> to be executed. If a command is executed on a connection with an active transaction, and the `Transaction` object has not been assigned to the `Transaction` property of the `Command` object, an exception is thrown.  
  
3.  Execute the required commands.  
  
4.  Call the <xref:System.Data.SqlClient.SqlTransaction.Commit%2A> method of the <xref:System.Data.SqlClient.SqlTransaction> object to complete the transaction, or call the <xref:System.Data.SqlClient.SqlTransaction.Rollback%2A> method to end the transaction. If the connection is closed or disposed before either the <xref:System.Data.SqlClient.SqlTransaction.Commit%2A> or <xref:System.Data.SqlClient.SqlTransaction.Rollback%2A> methods have been executed, the transaction is rolled back.  
  
 The following code example demonstrates transactional logic using [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)] with Microsoft SQL Server.  
  
 [!code-csharp[DataWorks SqlTransaction.Local#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlTransaction.Local/CS/source.cs#1)]
 [!code-vb[DataWorks SqlTransaction.Local#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlTransaction.Local/VB/source.vb#1)]  
  
## See Also  
 [Transactions and Concurrency](../../../../docs/framework/data/adonet/transactions-and-concurrency.md)  
 [Distributed Transactions](../../../../docs/framework/data/adonet/distributed-transactions.md)  
 [System.Transactions Integration with SQL Server](../../../../docs/framework/data/adonet/system-transactions-integration-with-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
