---
title: Bulk Insert - Microsoft.Data.Sqlite
author: bricelam
ms.date: 12/13/2019
description: Performance tips you can use when making a lot of changes to the database.
---
# Bulk Insert

SQLite doesn't have any special way to bulk insert data. To get optimal performance when inserting or updating data, ensure that you do the following.

1. Use a transaction.
2. Reuse the same parameterized command. Subsequent executions will reuse the compilation of the first one.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/BulkInsertSample/Program.cs?name=snippet_BulkInsert)]
