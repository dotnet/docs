---
description: "Learn more about: Transactions and Concurrency"
title: "Transactions and Concurrency"
ms.date: "03/30/2017"
ms.assetid: f46570de-9e50-4fe6-8710-a8c31fa8569b
---
# Transactions and Concurrency

A transaction consists of a single command or a group of commands that execute as a package. Transactions allow you to combine multiple operations into a single unit of work. If a failure occurs at one point in the transaction, all of the updates can be rolled back to their pre-transaction state.  
  
 A transaction must conform to the ACID properties—atomicity, consistency, isolation, and durability—in order to guarantee data consistency. Most relational database systems, such as Microsoft SQL Server, support transactions by providing locking, logging, and transaction management facilities whenever a client application performs an update, insert, or delete operation.  
  
> [!NOTE]
> Transactions that involve multiple resources can lower concurrency if locks are held too long. Therefore, keep transactions as short as possible.  
  
 If a transaction involves multiple tables in the same database or server, then explicit transactions in stored procedures often perform better. You can create transactions in SQL Server stored procedures by using the Transact-SQL `BEGIN TRANSACTION`, `COMMIT TRANSACTION`, and `ROLLBACK TRANSACTION` statements.
  
 Transactions involving different resource managers, such as a transaction between SQL Server and Oracle, require a distributed transaction.  
  
## In This Section  

 [Local Transactions](local-transactions.md)  
 Demonstrates how to perform transactions against a database.  
  
 [Distributed Transactions](distributed-transactions.md)  
 Describes how to perform distributed transactions in ADO.NET.  
  
 [System.Transactions Integration with SQL Server](system-transactions-integration-with-sql-server.md)  
 Describes <xref:System.Transactions> integration with SQL Server for working with distributed transactions.  
  
 [Optimistic Concurrency](optimistic-concurrency.md)  
 Describes optimistic and pessimistic concurrency, and how you can test for concurrency violations.  
  
## See also

- [Transaction Fundamentals](../transactions/transaction-fundamentals.md)
- [Connecting to a Data Source](connecting-to-a-data-source.md)
- [Commands and Parameters](commands-and-parameters.md)
- [DataAdapters and DataReaders](dataadapters-and-datareaders.md)
- [DbProviderFactories](dbproviderfactories.md)
- [ADO.NET Overview](ado-net-overview.md)
