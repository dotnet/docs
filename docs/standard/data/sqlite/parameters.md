---
title: Parameters
ms.date: 12/13/2019
description: Learn how to use SQL parameters.
---
# Parameters

Parameters are used to protect against SQL injection attacks. Instead of concatenating user input with SQL statements, use parameters to ensure input is only ever treated as a literal value and never executed. In SQLite, parameters are typically allowed anywhere a literal is allowed in SQL statements.

Parameters can be prefixed with either `:`, `@`, or `$`.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/HelloWorldSample/Program.cs?name=snippet_Parameter)]

See [Data types](types.md) for details about how .NET values are mapped to SQLite values.

## Truncation

Use the <xref:Microsoft.Data.Sqlite.SqliteParameter.Size> property to truncate TEXT and BLOB values.

```csharp
// Truncate name to 30 characters
command.Parameters.AddWithValue("$name", name).Length = 30;
```

## Alternative types

Sometimes, you may want to use an alternative SQLite type. Do this by setting the <xref:Microsoft.Data.Sqlite.SqliteParameter.SqliteType> property.

The following alternative type mappings can be used. For the default mappings, see [Data types](types.md).

| Value          | SqliteType | Remarks          |
| -------------- | ---------- | ---------------- |
| Char           | Integer    | UTF-16           |
| DateTime       | Real       | Julian day value |
| DateTimeOffset | Real       | Julian day value |
| Guid           | Blob       |                  |
| TimeSpan       | Real       | In days          |

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/DateAndTimeSample/Program.cs?name=snippet_SqliteType)]

## Output parameters

SQLite doesn't support output parameters. Return values in the query results instead.

## See also

* [Data types](types.md)
