---
title: "Transaction and Bulk Copy Operations"
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
ms.assetid: f6f0cbc9-f7bf-4d6e-875f-ad1ba0b4aa62
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Transaction and Bulk Copy Operations
Bulk copy operations can be performed as isolated operations or as part of a multiple step transaction. This latter option enables you to perform more than one bulk copy operation within the same transaction, as well as perform other database operations (such as inserts, updates, and deletes) while still being able to commit or roll back the entire transaction.  
  
 By default, a bulk copy operation is performed as an isolated operation. The bulk copy operation occurs in a non-transacted way, with no opportunity for rolling it back. If you need to roll back all or part of the bulk copy when an error occurs, you can use a <xref:System.Data.SqlClient.SqlBulkCopy>-managed transaction, perform the bulk copy operation within an existing transaction, or be enlisted in a **System.Transactions**<xref:System.Transactions.Transaction>.  
  
## Performing a Non-transacted Bulk Copy Operation  
 The following Console application shows what happens when a non-transacted bulk copy operation encounters an error partway through the operation.  
  
 In the example, the source table and destination table each include an `Identity` column named **ProductID**. The code first prepares the destination table by deleting all rows and then inserting a single row whose **ProductID** is known to exist in the source table. By default, a new value for the `Identity` column is generated in the destination table for each row added. In this example, an option is set when the connection is opened that forces the bulk load process to use the `Identity` values from the source table instead.  
  
 The bulk copy operation is executed with the <xref:System.Data.SqlClient.SqlBulkCopy.BatchSize%2A> property set to 10. When the operation encounters the invalid row, an exception is thrown. In this first example, the bulk copy operation is non-transacted. All batches copied up to the point of the error are committed; the batch containing the duplicate key is rolled back, and the bulk copy operation is halted before processing any other batches.  
  
> [!NOTE]
>  This sample will not run unless you have created the work tables as described in [Bulk Copy Example Setup](../../../../../docs/framework/data/adonet/sql/bulk-copy-example-setup.md). This code is provided to demonstrate the syntax for using **SqlBulkCopy** only. If the source and destination tables are located in the same [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] instance, it is easier and faster to use a [!INCLUDE[tsql](../../../../../includes/tsql-md.md)]`INSERT … SELECT` statement to copy the data.  
  
 [!code-csharp[DataWorks SqlBulkCopy.DefaultTransaction#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.DefaultTransaction/CS/source.cs#1)]
 [!code-vb[DataWorks SqlBulkCopy.DefaultTransaction#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.DefaultTransaction/VB/source.vb#1)]  
  
## Performing a Dedicated Bulk Copy Operation in a Transaction  
 By default, a bulk copy operation is its own transaction. When you want to perform a dedicated bulk copy operation, create a new instance of <xref:System.Data.SqlClient.SqlBulkCopy> with a connection string, or use an existing <xref:System.Data.SqlClient.SqlConnection> object without an active transaction. In each scenario, the bulk copy operation creates, and then commits or rolls back the transaction.  
  
 You can explicitly specify the <xref:System.Data.SqlClient.SqlBulkCopyOptions.UseInternalTransaction> option in the <xref:System.Data.SqlClient.SqlBulkCopy> class constructor to explicitly cause a bulk copy operation to execute in its own transaction, causing each batch of the bulk copy operation to execute within a separate transaction.  
  
> [!NOTE]
>  Since different batches are executed in different transactions, if an error occurs during the bulk copy operation, all the rows in the current batch will be rolled back, but rows from previous batches will remain in the database.  
  
 The following console application is similar to the previous example, with one exception: In this example, the bulk copy operation manages its own transactions. All batches copied up to the point of the error are committed; the batch containing the duplicate key is rolled back, and the bulk copy operation is halted before processing any other batches.  
  
> [!IMPORTANT]
>  This sample will not run unless you have created the work tables as described in [Bulk Copy Example Setup](../../../../../docs/framework/data/adonet/sql/bulk-copy-example-setup.md). This code is provided to demonstrate the syntax for using **SqlBulkCopy** only. If the source and destination tables are located in the same [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] instance, it is easier and faster to use a [!INCLUDE[tsql](../../../../../includes/tsql-md.md)]`INSERT … SELECT` statement to copy the data.  
  
 [!code-csharp[DataWorks SqlBulkCopy.InternalTransaction#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.InternalTransaction/CS/source.cs#1)]
 [!code-vb[DataWorks SqlBulkCopy.InternalTransaction#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.InternalTransaction/VB/source.vb#1)]  
  
## Using Existing Transactions  
 You can specify an existing <xref:System.Data.SqlClient.SqlTransaction> object as a parameter in a <xref:System.Data.SqlClient.SqlBulkCopy> constructor. In this situation, the bulk copy operation is performed in an existing transaction, and no change is made to the transaction state (that is, it is neither committed nor aborted). This allows an application to include the bulk copy operation in a transaction with other database operations. However, if you do not specify a <xref:System.Data.SqlClient.SqlTransaction> object and pass a null reference, and the connection has an active transaction, an exception is thrown.  
  
 If you need to roll back the entire bulk copy operation because an error occurs, or if the bulk copy should execute as part of a larger process that can be rolled back, you can provide a <xref:System.Data.SqlClient.SqlTransaction> object to the <xref:System.Data.SqlClient.SqlBulkCopy> constructor.  
  
 The following console application is similar to the first (non-transacted) example, with one exception: in this example, the bulk copy operation is included in a larger, external transaction. When the primary key violation error occurs, the entire transaction is rolled back and no rows are added to the destination table.  
  
> [!IMPORTANT]
>  This sample will not run unless you have created the work tables as described in [Bulk Copy Example Setup](../../../../../docs/framework/data/adonet/sql/bulk-copy-example-setup.md). This code is provided to demonstrate the syntax for using **SqlBulkCopy** only. If the source and destination tables are located in the same [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] instance, it is easier and faster to use a [!INCLUDE[tsql](../../../../../includes/tsql-md.md)]`INSERT … SELECT` statement to copy the data.  
  
 [!code-csharp[DataWorks SqlBulkCopy.SqlTransaction#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.SqlTransaction/CS/source.cs#1)]
 [!code-vb[DataWorks SqlBulkCopy.SqlTransaction#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.SqlTransaction/VB/source.vb#1)]  
  
## See Also  
 [Bulk Copy Operations in SQL Server](../../../../../docs/framework/data/adonet/sql/bulk-copy-operations-in-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
