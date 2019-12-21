---
title: Connection strings
ms.date: 12/13/2019
description: The supported keywords and values of connection strings.
---
# Connection strings

A connection string is used to specify how to connect to the database. Connection strings in Microsoft.Data.Sqlite
follow the standard [ADO.NET syntax](../../../framework/data/adonet/connection-strings.md) as a semicolon-separated list of
keywords and values.

## Keywords

The following connection string keywords can be used with Microsoft.Data.Sqlite:

### Data source

The path to the database file. *DataSource* (without a space) and *Filename* are aliases of this keyword.

SQLite treats paths relative to the current working directory. Absolute paths can also be specified.

If **empty**, SQLite creates a temporary on-disk database that's deleted when the connection is closed.

If `:memory:`, an in-memory database is used. For more information, see [In-Memory databases](in-memory-databases.md).

Paths that start with the `|DataDirectory|` substitution string are treated the same as relative paths. If set, paths are made relative to the DataDirectory application domain property value.

This keyword also supports [URI Filenames](https://www.sqlite.org/uri.html).

### Mode

The connection mode.

| Value           | Description                                                                                        |
| --------------- | -------------------------------------------------------------------------------------------------- |
| ReadWriteCreate | Opens the database for reading and writing, and creates it if it doesn't exist. This is the default. |
| ReadWrite       | Opens the database for reading and writing.                                                        |
| ReadOnly        | Opens the database in read-only mode.                                                              |
| Memory          | Opens an in-memory database.                                                                       |

### Cache

The caching mode used by the connection.

| Value   | Description                                                                                    |
| ------- | ---------------------------------------------------------------------------------------------- |
| Default | Uses the default mode of the underlying SQLite library. This is the default.                   |
| Private | Each connection uses a private cache.                                                          |
| Shared  | Connections share a cache. This mode can change the behavior of transaction and table locking. |

### Password

The encryption key. When specified, `PRAGMA key` is sent immediately after opening the connection.

> [!WARNING]
> Password has no effect when encryption isn't supported by the native SQLite library.

### Foreign Keys

A value indicating whether to enable foreign key constraints.

| Value   | Description
| ------- | --- |
| True    | Sends `PRAGMA foreign_keys = 1` immediately after opening the connection.
| False   | Sends `PRAGMA foreign_keys = 0` immediately after opening the connection.
| (empty) | Doesn't send `PRAGMA foreign_keys`. This is the default. |

There's no need enable foreign keys if, like in e_sqlite3, SQLITE_DEFAULT_FOREIGN_KEYS was used to compile the native
SQLite library.

### Recursive triggers

A value that indicates whether to enable recursive triggers.

| Value | Description                                                                 |
| ----- | --------------------------------------------------------------------------- |
| True  | Sends `PRAGMA recursive_triggers` immediately after opening the connection. |
| False | Doesn't send `PRAGMA recursive_triggers`. This is the default.              |

## Connection string builder

You can use <xref:Microsoft.Data.Sqlite.SqliteConnectionStringBuilder> as a strongly typed way of creating connection strings. It can also be used to prevent connection string injection attacks.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/EncryptionSample/Program.cs?name=snippet_ConnectionStringBuilder)]

## Examples

### Basic

A basic connection string with a shared cache for improved concurrency.

```ConnectionString
Data Source=Application.db;Cache=Shared
```

### Encrypted

An encrypted database.

```ConnectionString
Data Source=Encrypted.db;Password=MyEncryptionKey
```

### Read-only

A read-only database that cannot be modified by the app.

```ConnectionString
Data Source=Reference.db;Mode=ReadOnly
```

### In-memory

A private, in-memory database.

```ConnectionString
Data Source=:memory:
```

### Sharable in-memory

A sharable, in-memory database identified by the name *Sharable*.

```ConnectionString
Data Source=Sharable;Mode=Memory;Cache=Shared
```

## See also

* [Connection Strings in ADO.NET](../../../framework/data/adonet/connection-strings.md)
* [In-Memory databases](in-memory-databases.md)
* [Transactions](transactions.md)
