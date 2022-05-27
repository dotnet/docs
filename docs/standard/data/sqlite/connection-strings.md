---
title: Connection strings
ms.date: 07/14/2021
no-loc: Command Timeout,Default Timeout,Data Source,Recursive Triggers,Pooling
description: The supported keywords and values of connection strings.
---
# Connection strings

A connection string is used to specify how to connect to the database. Connection strings in Microsoft.Data.Sqlite
follow the standard [ADO.NET syntax](../../../framework/data/adonet/connection-strings.md) as a semicolon-separated list of
keywords and values.

## Keywords

The following connection string keywords can be used with Microsoft.Data.Sqlite:

### Data Source

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

> [!NOTE]
> The Password keyword was added in version 3.0.

### Foreign Keys

A value indicating whether to enable foreign key constraints.

> [!NOTE]
> The Foreign Keys keyword was added in version 3.0.

| Value   | Description
| ------- | --- |
| True    | Sends `PRAGMA foreign_keys = 1` immediately after opening the connection.
| False   | Sends `PRAGMA foreign_keys = 0` immediately after opening the connection.
| (empty) | Doesn't send `PRAGMA foreign_keys`. This is the default. |

There's no need enable foreign keys if, like in e_sqlite3, SQLITE_DEFAULT_FOREIGN_KEYS was used to compile the native
SQLite library.

### Recursive Triggers

A value that indicates whether to enable recursive triggers.

> [!NOTE]
> The Recursive Triggers keyword was added in version 3.0.

| Value | Description                                                                 |
| ----- | --------------------------------------------------------------------------- |
| True  | Sends `PRAGMA recursive_triggers` immediately after opening the connection. |
| False | Doesn't send `PRAGMA recursive_triggers`. This is the default.              |

### Default Timeout

The default timeout (in seconds) for executing commands. The default value is 30. *Command Timeout* is an alias of this keyword.

This value can be overridden using <xref:Microsoft.Data.Sqlite.SqliteConnection.DefaultTimeout> which in turn can be overridden using <xref:Microsoft.Data.Sqlite.SqliteCommand.CommandTimeout>.

> [!NOTE]
> The Default Timeout keyword was added in version 6.0.

### Pooling

A value indicating whether the connection will be pooled.

> [!NOTE]
> The Pooling keyword was added in version 6.0.

| Value | Description                                         |
| ----- | --------------------------------------------------- |
| True  | The connection will be pooled. This is the default. |
| False | The connection won't be pooled.                     |

## Connection string builder

You can use <xref:Microsoft.Data.Sqlite.SqliteConnectionStringBuilder> as a strongly typed way of creating connection strings. It can also be used to prevent connection string injection attacks.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/EncryptionSample/Program.cs?name=snippet_ConnectionStringBuilder)]

## Examples

### Basic

A basic connection string with a shared cache for improved concurrency.

```connectionstring
Data Source=Application.db;Cache=Shared
```

### Encrypted

An encrypted database.

```connectionstring
Data Source=Encrypted.db;Password=MyEncryptionKey
```

### Read-only

A read-only database that cannot be modified by the app.

```connectionstring
Data Source=Reference.db;Mode=ReadOnly
```

### In-memory

A private, in-memory database.

```connectionstring
Data Source=:memory:
```

### Sharable in-memory

A sharable, in-memory database identified by the name *Sharable*.

```connectionstring
Data Source=Sharable;Mode=Memory;Cache=Shared
```

## See also

* [Connection Strings in ADO.NET](../../../framework/data/adonet/connection-strings.md)
* [In-Memory databases](in-memory-databases.md)
* [Transactions](transactions.md)
