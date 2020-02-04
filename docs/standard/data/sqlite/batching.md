---
title: Batching
ms.date: 12/13/2019
description: Learn how to execute a batch of SQL statements in a single command.
---
# Batching

SQLite doesn't natively support batching SQL statements together into a single command. But because there's no network involved, it wouldn't really help performance anyway. Microsoft.Data.Sqlite does, however, implement statement batching as a convenience to make it behave more like other ADO.NET providers.

When calling <xref:System.Data.Common.DbCommand.ExecuteReader%2A?displayProperty=nameWithType>, statements are executed up to the first one that returns results. Calling <xref:System.Data.Common.DbDataReader.NextResult%2A?displayProperty=nameWithType> continues executing statements until the next one that returns results or until it reaches the end of the batch. Calling <xref:System.Data.Common.DbDataReader.Dispose%2A?displayProperty=nameWithType> or <xref:System.Data.Common.DbDataReader.Close%2A> executes any remaining statements that haven't been consumed by `NextResult()`. If you don't dispose a data reader, the finalizer tries to execute the remaining statements, but any errors it encounters are ignored. Because of this, it's important to dispose `DbDataReader` objects when using batches.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/BatchingSample/Program.cs?name=snippet_Batching)]

## See also

* [Bulk Insert](bulk-insert.md)
