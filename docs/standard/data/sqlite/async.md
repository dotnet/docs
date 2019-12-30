---
title: Async limitations
ms.date: 12/13/2019
description: Explains the limitations of the async APIs and some alternatives that you can use instead.
---
# Async limitations

SQLite doesn't support asynchronous I/O. Async ADO.NET methods will execute synchronously in Microsoft.Data.Sqlite. Avoid calling them.

Instead, use [write-ahead logging](https://www.sqlite.org/wal.html) to improve performance and concurrency.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/AsyncSample/Program.cs?name=snippet_WAL)]

> [!TIP]
> Write-ahead logging is enabled by default on databases created using [Entity Framework Core](/ef/core/).
