---
title: Batching
ms.date: 12/13/2019
description: Learn how to execute a batch of SQL statements in a single command.
---
# Batching

SQLite doesn't natively support batching SQL statements together into a single command. But because there's no network involved, it wouldn't really help performance anyway. Microsoft.Data.Sqlite does however implements statement batching as a convenience to make it behave more like other ADO.NET providers.

When calling DbCommand.ExecuteReader(), statements are executed up to the first one that returns results. Calling DbDataReader.NextResult() continues executing statements until the next one that returns results or until it reaches the end of the batch. Calling DbDataReader.Dispose() or Close() will execute any remaining statements that haven't been consumed by NextResult(). If you don't dispose a data reader, the finalizer will try to execute the remaining statements, but any errors it encounters will be ignored. Because of this, it's very important to dispose DbDataReader objects when using batches.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/BatchingSample/Program.cs?name=snippet_Batching)]

## See also

* [Bulk Insert](bulk-insert.md)
