---
title: Comparison to System.Data.SQLite
ms.date: 12/13/2019
description: Describes some of the differences between the Microsoft.Data.Sqlite and System.Data.SQLite libraries.
---
# Comparison to System.Data.SQLite

In 2005, Robert Simpson created System.Data.SQLite, a SQLite provider for ADO.NET 2.0. In 2010, the SQLite team took over maintenance and development of the project. It's also worth noting that the Mono team forked the code in 2007 as Mono.Data.Sqlite. System.Data.SQLite has a long history and has evolved into a stable and full-featured ADO.NET provider complete with Visual Studio tooling. New releases continue to ship assemblies compatible with every version of .NET Framework back to version 2.0 and even .NET Compact Framework 3.5.

The first version of .NET Core (released in 2016) was a single, lightweight, modern, and cross-platform implementation of .NET. Obsolete APIs and APIs with more modern alternatives were intentionally removed. ADO.NET didn't include any of the DataSet APIs (including DataTable and DataAdapter).

The Entity Framework team was somewhat familiar with the System.Data.SQLite codebase. Brice Lambson, a member of the EF team, had previously helped the SQLite team add support for Entity Framework versions 5 and 6. Brice was also experimenting with his own implementation of a SQLite ADO.NET provider around the same time that .NET Core was being planned. After a long discussion, the Entity Framework team decided to create Microsoft.Data.Sqlite based on Brice's prototype. This would allow them to create a new lightweight and modern implementation that would align with the goals of .NET Core.

As an example of what we mean by more modern, here is code to create a [user-defined function](user-defined-functions.md) in both System.Data.SQLite and Microsoft.Data.Sqlite.

```csharp
// System.Data.SQLite
connection.BindFunction(
    new SQLiteFunctionAttribute("ceiling", 1, FunctionType.Scalar),
    (Func<object[], object>)((object[] args) => Math.Ceiling((double)((object[])args[1])[0])),
    null);

// Microsoft.Data.Sqlite
connection.CreateFunction(
    "ceiling",
    (double arg) => Math.Ceiling(arg));
```

In 2017, .NET Core 2.0 experienced a change in strategy. It was decided that compatibility with .NET Framework was vital to the success of .NET Core. Many of the removed APIs, including the DataSet APIs, were added back. Like it did for many others, this unblocked System.Data.SQLite allowing it to also be ported to .NET Core. The original goal of Microsoft.Data.Sqlite to be lightweight and modern, however, still remains. See [ADO.NET limitations](adonet-limitations.md) for details about ADO.NET APIs not implemented by Microsoft.Data.Sqlite.

When new features are added to Microsoft.Data.Sqlite, the design of System.Data.SQLite is taken into account. We try, when possible, to minimize changes between the two to ease transitioning between them.

## Data types

The biggest difference between Microsoft.Data.Sqlite and System.Data.SQLite is how data types are handled. As described in [Data types](types.md), Microsoft.Data.Sqlite doesn't try to hide the underlying quirkiness of SQLite, which allows any arbitrary string to be specified as the column type, and only has four primitive types: INTEGER, REAL, TEXT, and BLOB.

System.Data.SQLite applies additional semantics to column types mapping them directly to .NET types. This gives the provider a more strongly typed feel, but it has some rough edges. For example, they had to introduce a new SQL statement (TYPES) to specify the column types of expressions in SELECT statements.

## Connection strings

Microsoft.Data.Sqlite has a lot fewer [connection string](connection-strings.md) keywords. The following table shows alternatives that can be used instead.

| Keyword          | Alternative                                         |
| ---------------- | --------------------------------------------------- |
| Cache Size       | Send `PRAGMA cache_size = <pages>`                  |
| FailIfMissing    | Use `Mode=ReadWrite`                                |
| FullUri          | Use the Data Source keyword                         |
| Journal Mode     | Send `PRAGMA journal_mode = <mode>`                 |
| Legacy Format    | Send `PRAGMA legacy_file_format = 1`                |
| Max Page Count   | Send `PRAGMA max_page_count = <pages>`              |
| Page Size        | Send `PRAGMA page_size = <bytes>`                   |
| Read Only        | Use `Mode=ReadOnly`                                 |
| Synchronous      | Send `PRAGMA synchronous = <mode>`                  |
| Uri              | Use the Data Source keyword                         |
| UseUTF16Encoding | Send `PRAGMA encoding = 'UTF-16'`                   |

## Authorization

Microsoft.Data.Sqlite doesn't have any API exposing SQLite's authorization callback. Use issue [#13835](https://github.com/dotnet/efcore/issues/13835) to provide feedback about this feature.

## Data change notifications

Microsoft.Data.Sqlite doesn't have any API exposing SQLite's data change notifications. Use issue [#13827](https://github.com/dotnet/efcore/issues/13827) to provide feedback about this feature.

## Virtual table modules

Microsoft.Data.Sqlite doesn't have any API for creating virtual table modules. Use issue [#13823](https://github.com/dotnet/efcore/issues/13823) to provide feedback about this feature.

## See also

* [Data types](types.md)
* [Connection strings](connection-strings.md)
* [Encryption](encryption.md)
* [ADO.NET limitations](adonet-limitations.md)
* [Dapper limitations](dapper-limitations.md)
