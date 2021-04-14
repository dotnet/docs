---
title: In-memory databases
ms.date: 12/13/2019
description: Learn how to use in-memory SQLite databases.
---
# In-memory databases

SQLite in-memory databases are databases stored entirely in memory, not on disk. Use the special data source filename `:memory:` to create an in-memory database. When the connection is closed, the database is deleted. When using `:memory:`, each connection creates its own database.

```connectionstring
Data Source=:memory:
```

## Shareable in-memory databases

In-memory databases can be shared between multiple connections by using `Mode=Memory` and `Cache=Shared` in the connection string. The `Data Source` keyword is used to give the in-memory database a name. Connection strings using the same name will access the same in-memory database. The database persists as long as at least one connection to it remains open. A [sample](https://github.com/dotnet/docs/blob/main/samples/snippets/standard/data/sqlite/InMemorySample/Program.cs) demonstrating this is available on GitHub.

```connectionstring
Data Source=InMemorySample;Mode=Memory;Cache=Shared
```
