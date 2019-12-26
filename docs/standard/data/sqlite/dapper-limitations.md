---
title: Dapper limitations
ms.date: 12/13/2019
description: Describes some of the limitations you will encounter when using Dapper.
---
# Dapper limitations

There are a few limitations you should be aware of when using Microsoft.Data.Sqlite with [Dapper](https://stackexchange.github.io/Dapper/).

## Parameters

SQLite parameter names are case-sensitive. Ensure that the parameter names used in SQL match the case of the anonymous object's properties. Issue [#18861](https://github.com/aspnet/EntityFrameworkCore/issues/18861) would improve this experience.

Dapper also expects parameters to use the `@` prefix. Other prefixes won't work.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/DapperSample/Program.cs?name=snippet_Parameter)]

## Data types

Dapper reads values using the SqliteDataReader indexer. The return type of this indexer is object, which means it will only ever return long, double, string, or byte[] values. For more information, see [Data types](types.md). Dapper handles most conversions between these and other primitive types. Unfortunately, it doesn't handle `DateTimeOffset`, `Guid`, or `TimeSpan`. Create type handlers if you want to use these types in your results.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/DapperSample/Program.cs?name=snippet_TypeHandlers)]

Don't forget to add the type handlers before querying.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/DapperSample/Program.cs?name=snippet_AddTypeHandlers)]

## See also

* [Data types](types.md)
* [Async limitations](async.md)
