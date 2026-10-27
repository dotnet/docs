---
description: "Learn more about: Transaction and Bulk Copy Operations"
title: "Transaction and Bulk Copy Operations"
ms.date: "10/23/2026"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: f6f0cbc9-f7bf-4d6e-875f-ad1ba0b4aa62
---
# Transaction and Bulk Copy Operations

Bulk copy operations can be performed as isolated operations or as part of a multiple step transaction. This latter option enables you to perform more than one bulk copy operation within the same transaction, as well as perform other database operations (such as inserts, updates, and deletes) while still being able to commit or roll back the entire transaction.

By default, a bulk copy operation runs without a transaction that the client can roll back. To roll back all or part of a copy after an error, specify `SqlBulkCopyOptions.UseInternalTransaction` for per-batch transactions, use an existing <xref:Microsoft.Data.SqlClient.SqlTransaction>, or enlist the connection in <xref:System.Transactions.Transaction>.

## Performing a Non-transacted Bulk Copy Operation

 The following Console application shows what happens when a non-transacted bulk copy operation encounters an error partway through the operation.

 In the example, the source table and destination table each include an `Identity` column named `ProductID`. The code first prepares the destination table by deleting all rows and then inserting a single row whose `ProductID` is known to exist in the source table. By default, a new value for the `Identity` column is generated in the destination table for each row added. In this example, an option is set when the connection is opened that forces the bulk load process to use the `Identity` values from the source table instead.

 The bulk copy operation is executed with the <xref:Microsoft.Data.SqlClient.SqlBulkCopy.BatchSize> property set to 10. When the operation encounters the invalid row, an exception is thrown. In this first example, the bulk copy operation is non-transacted. All batches copied up to the point of the error are committed; the batch containing the duplicate key is rolled back, and the bulk copy operation is halted before processing any other batches.

> [!NOTE]
> Before you run this sample, create the work tables described in [Bulk Copy Example Setup](bulk-copy-example-setup.md). The sample demonstrates `SqlBulkCopy` syntax. If the source and destination tables are in the same SQL Server instance, use a Transact-SQL (T-SQL) `INSERT ... SELECT` statement for a faster copy.

 [!code-csharp[DataWorks SqlBulkCopy.DefaultTransaction#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.DefaultTransaction/CS/source.cs#1)]
 [!code-vb[DataWorks SqlBulkCopy.DefaultTransaction#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.DefaultTransaction/VB/source.vb#1)]

## Performing a Dedicated Bulk Copy Operation in a Transaction

To let `SqlBulkCopy` manage a separate transaction for each batch, specify <xref:Microsoft.Data.SqlClient.SqlBulkCopyOptions.UseInternalTransaction>. Use a connection string or an existing connection without an active transaction.

Pass this option to the <xref:Microsoft.Data.SqlClient.SqlBulkCopy> constructor. The copy commits each completed batch independently rather than treating the entire operation as one transaction.

> [!NOTE]
> Since different batches are executed in different transactions, if an error occurs during the bulk copy operation, all the rows in the current batch will be rolled back, but rows from previous batches will remain in the database.

 The following console application is similar to the previous example, with one exception: In this example, the bulk copy operation manages its own transactions. All batches copied up to the point of the error are committed; the batch containing the duplicate key is rolled back, and the bulk copy operation is halted before processing any other batches.

> [!IMPORTANT]
> Before you run this sample, create the work tables described in [Bulk Copy Example Setup](bulk-copy-example-setup.md). The sample demonstrates `SqlBulkCopy` syntax. If the source and destination tables are in the same SQL Server instance, use a Transact-SQL `INSERT ... SELECT` statement for a faster copy.

 [!code-csharp[DataWorks SqlBulkCopy.InternalTransaction#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.InternalTransaction/CS/source.cs#1)]
 [!code-vb[DataWorks SqlBulkCopy.InternalTransaction#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.InternalTransaction/VB/source.vb#1)]

## Using Existing Transactions

Pass the existing <xref:Microsoft.Data.SqlClient.SqlTransaction> object to the <xref:Microsoft.Data.SqlClient.SqlBulkCopy> constructor to include the copy in that transaction. The bulk copy doesn't commit or roll back the transaction. Your application controls the transaction, including any other database operations it contains. If the connection has an active transaction but you pass a null transaction reference, the provider throws an exception.

To roll back the entire copy after an error, or include it in a larger operation that you can roll back, provide the <xref:Microsoft.Data.SqlClient.SqlTransaction> object to the <xref:Microsoft.Data.SqlClient.SqlBulkCopy> constructor.

 The following console application is similar to the first (non-transacted) example, with one exception: in this example, the bulk copy operation is included in a larger, external transaction. When the primary key violation error occurs, the entire transaction is rolled back and no rows are added to the destination table.

> [!IMPORTANT]
> Before you run this sample, create the work tables described in [Bulk Copy Example Setup](bulk-copy-example-setup.md). The sample demonstrates `SqlBulkCopy` syntax. If the source and destination tables are in the same SQL Server instance, use a Transact-SQL `INSERT ... SELECT` statement for a faster copy.

 [!code-csharp[DataWorks SqlBulkCopy.SqlTransaction#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.SqlTransaction/CS/source.cs#1)]
 [!code-vb[DataWorks SqlBulkCopy.SqlTransaction#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.SqlTransaction/VB/source.vb#1)]

## See also

- [Bulk Copy Operations in SQL Server](bulk-copy-operations-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
