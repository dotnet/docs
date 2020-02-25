---
title: Bulk insert
ms.date: 12/13/2019
description: Performance tips you can use when making numerous changes to the database.
---
# Bulk insert

SQLite doesn't have any special way to bulk insert data. To get optimal performance when inserting or updating data, ensure that you do the following:

- Use a transaction.
- Reuse the same parameterized command. Subsequent executions will reuse the compilation of the first one.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/BulkInsertSample/Program.cs?name=snippet_BulkInsert)]
