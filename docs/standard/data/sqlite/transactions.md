---
title: Transactions
ms.date: 12/13/2019
description: Learn how to use transactions.
---
# Transactions

Transactions let you group multiple SQL statements into a single unit of work that is committed to the database as one atomic unit. If any statement in the transaction fails, changes made by the previous statements can be rolled back. The initial state of the database when the transaction was started is preserved. Using a transaction can also improve performance on SQLite when making numerous changes to the database at once.

## Concurrency

In SQLite, only one transaction is allowed to have changes pending in the database at a time. Because of this, calls to <xref:Microsoft.Data.Sqlite.SqliteConnection.BeginTransaction%2A> and the `Execute` methods on <xref:Microsoft.Data.Sqlite.SqliteCommand> may time out if another transaction takes too long to complete.

For more information about locking, retries, and timeouts, see [Database errors](database-errors.md).

## Isolation levels

Transactions are **serializable** by default in SQLite. This isolation level guarantees that any changes made within a transaction are completely isolated. Other statements executed outside of the transaction aren't affected by the transaction's changes.

SQLite also supports **read uncommitted** when using a shared cache. This level allows dirty reads, nonrepeatable reads, and phantoms:

- A *dirty read* occurs when changes pending in one transaction are returned by a query outside of the transaction, but the changes in the transaction are rolled back. The results contain data that was never actually committed to the database.

- A *nonrepeatable read* occurs when a transaction queries same row twice, but the results are different because it was changed between the two queries by another transaction.

- *Phantoms* are rows that get changed or added to meet the where clause of a query during a transaction. If allowed, the same query could return different rows when executed twice in the same transaction.

Microsoft.Data.Sqlite treats the IsolationLevel passed to <xref:Microsoft.Data.Sqlite.SqliteConnection.BeginTransaction%2A> as a minimum level. The actual isolation level will be promoted to either read uncommitted or serializable.

The following code simulates a dirty read. Note, the connection string must include `Cache=Shared`.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/DirtyReadSample/Program.cs?name=snippet_DirtyRead)]
