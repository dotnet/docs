---
title: Blob I/O
ms.date: 12/13/2019
description: Learn how to use SQLite's BLOB I/O feature.
---
# Blob I/O

You can reduce memory usage while reading and writing large objects by streaming the data into and out of the database. This can be especially useful when parsing or transforming the data.

Start by inserting a row as normal. Use the `zeroblob()` SQL function to allocate space in the database to hold the large object. The `last_insert_rowid()` function provides a convenient way to get its rowid.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/StreamingSample/Program.cs?name=snippet_Insert)]

After inserting the row, open a stream to write the large object using <xref:Microsoft.Data.Sqlite.SqliteBlob>.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/StreamingSample/Program.cs?name=snippet_Write)]

To stream the large object out of the database, you must select the rowid or one of its aliases as show here in addition to the large object's column. If you don't select the rowid, the entire object will be loaded into memory. The object returned by `GetStream()` will be a `SqliteBlob` when done correctly.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/StreamingSample/Program.cs?name=snippet_Read)]
