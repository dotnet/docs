---
title: Overview
ms.date: 12/13/2019
description: An overview of Microsoft.Data.Sqlite
---
# Microsoft.Data.Sqlite overview

Microsoft.Data.Sqlite is a lightweight [ADO.NET](../../../framework/data/adonet/index.md) provider for SQLite. The [Entity Framework Core](/ef/core/) provider for SQLite is built on top of this library. However, it can also be used independently or with other data access libraries.

## Installation

The latest stable version is available on [NuGet](https://www.nuget.org/packages/Microsoft.Data.Sqlite).

### [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet add package Microsoft.Data.Sqlite
```

### [Visual Studio](#tab/visual-studio)

``` PowerShell
Install-Package Microsoft.Data.Sqlite
```

---

## Usage

This library implements the common ADO.NET abstractions for connections, commands, data readers, and so on.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/HelloWorldSample/Program.cs?name=snippet_HelloWorld)]

## See also

* [Connection strings](connection-strings.md)
* [API Reference](../../../../api/index.md?view=msdata-sqlite-3.0&preserve-view=true)
* [SQL Syntax](https://www.sqlite.org/lang.html)
