---
title: Metadata
ms.date: 12/13/2019
description: Learn how to retrieve metadata about the database.
---
# Metadata

There are two APIs for retrieving metadata in ADO.NET. One retrieves metadata about query results. The other retrieves metadata about the database schema.

## Query result metadata

You can retrieve metadata about the results of a query using the <xref:Microsoft.Data.Sqlite.SqliteDataReader.GetSchemaTable%2A> method on `SqliteDataReader`. The returned <xref:System.Data.DataTable> contains the following columns:

| Column             | Type    | Description                                                               |
| ------------------ | ------- | ------------------------------------------------------------------------- |
| `AllowDBNull`      | Boolean | True if the origin column may be NULL.                                    |
| `BaseCatalogName`  | String  | The name of the origin column's database. Always NULL for expressions.    |
| `BaseColumnName`   | String  | The unaliased name of the origin column. Always NULL for expressions.    |
| `BaseSchemaName`   | String  | Always NULL. SQLite doesn't support schemas.                              |
| `BaseServerName`   | String  | The path to the database file specified in the connection string.         |
| `BaseTableName`    | String  | The name of the origin column's table. Always NULL for expressions.       |
| `ColumnName`       | String  | The name or alias of the column in the result set.                        |
| `ColumnOrdinal`    | Int32   | The ordinal of the column in the result set.                              |
| `ColumnSize`       | Int32   | Always -1. This may change in future versions of `Microsoft.Data.Sqlite`.   |
| `DataType`         | Type    | The default .NET data type of the column.                                 |
| `DataTypeName`     | String  | The SQLite data type of the column.                                       |
| `IsAliased`        | Boolean | True if the column name is aliased in the result set.                     |
| `IsAutoIncrement`  | Boolean | True if the origin column was created with the AUTOINCREMENT keyword.     |
| `IsExpression`     | Boolean | True if the column originates from an expression in the query.            |
| `IsKey`            | Boolean | True if the origin column is part of the PRIMARY KEY.                     |
| `IsUnique`         | Boolean | True if the origin column is UNIQUE.                                      |
| `NumericPrecision` | Int16   | Always NULL. This may change in future versions of `Microsoft.Data.Sqlite`. |
| `NumericScale`     | Int16   | Always NULL. This may change in future versions of `Microsoft.Data.Sqlite`. |

The following example shows how to use `GetSchemaTable` to create a debug string that shows metadata about a result:

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/ResultMetadataSample/Program.cs?name=snippet_ResultMetadata)]

For example, this query would produce the following debug string:

```sql
SELECT id AS post_id,
       title,
       body,
       random() AS random
FROM post
```

```output
post.id AS post_id INTEGER PRIMARY KEY AUTOINCREMENT
post.title TEXT NOT NULL UNIQUE
post.body TEXT
(expression) AS random BLOB
```

## Schema metadata

Microsoft.Data.Sqlite doesn't implement the GetSchema method on DbConnection. Instead, you can query directly for schema information using the [sqlite_master](https://www.sqlite.org/fileformat.html#storage_of_the_sql_database_schema) table and PRAGMA statements like [table_info](https://www.sqlite.org/pragma.html#pragma_table_info) and [foreign_key_list](https://www.sqlite.org/pragma.html#pragma_foreign_key_list).

For example, this query will retrieve metadata about all the columns in the database.

```sql
SELECT t.name AS tbl_name, c.name, c.type, c.notnull, c.dflt_value, c.pk
FROM sqlite_master AS t,
     pragma_table_info(t.name) AS c
WHERE t.type = 'table';
```

## See also

* [Storage of the SQL Database Schema](https://www.sqlite.org/fileformat.html#storage_of_the_sql_database_schema)
* [PRAGMA Statements](https://www.sqlite.org/pragma.html)
* [Data types](types.md)
