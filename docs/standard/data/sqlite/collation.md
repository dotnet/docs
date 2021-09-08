---
title: Collation
ms.date: 12/13/2019
description: Learn how to create a custom collating sequence.
---
# Collation

Collating sequences are used by SQLite when comparing TEXT values to determine order and equality. You can specify which collation to use when creating columns or per-operation in SQL queries. SQLite includes three collating sequences by default.

| Collation | Description                               |
| --------- | ----------------------------------------- |
| RTRIM     | Ignores trailing whitespace               |
| NOCASE    | Case-insensitive for ASCII characters A-Z |
| BINARY    | Case-sensitive. Compares bytes directly   |

## Custom collation

You can also define your own collating sequences or override the built-in ones using <xref:Microsoft.Data.Sqlite.SqliteConnection.CreateCollation%2A>. The following example shows overriding the NOCASE collation to support Unicode characters. The [full sample code](https://github.com/dotnet/docs/blob/main/samples/snippets/standard/data/sqlite/CollationSample/Program.cs) is available on GitHub.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/CollationSample/Program.cs?name=snippet_Collation)]

## Like operator

The LIKE operator in SQLite doesn't honor collations. The default implementation has the same semantics as the NOCASE collation. It's only case-insensitive for the ASCII characters A through Z.

You can easily make the LIKE operator case-sensitive by using the following pragma statement:

```sql
PRAGMA case_sensitive_like = 1
```

See [User-defined functions](user-defined-functions.md) for details on overriding the implementation of the LIKE operator.

## See also

* [User-defined functions](user-defined-functions.md)
* [SQL Syntax](https://www.sqlite.org/lang.html)
