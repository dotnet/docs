---
title: Extensions
ms.date: 12/08/2020
description: Learn how to load SQLite extensions.
---
# Extensions

SQLite supports loading extensions at run time. Extensions include things like additional SQL functions, collations, virtual tables, and more.

.NET Core includes additional logic for locating native libraries in additional places like referenced NuGet packages. Unfortunately, SQLite can't leverage this logic; it calls the platform API directly to load libraries. Because of this, you may need to modify the PATH, LD_LIBRARY_PATH, or DYLD_LIBRARY_PATH environment variables before loading SQLite extensions. There's [a sample](https://github.com/dotnet/docs/blob/main/samples/snippets/standard/data/sqlite/ExtensionsSample/Program.cs) on GitHub that demonstrates finding binaries for the current runtime inside a referenced NuGet package.

To load an extension, call the <xref:Microsoft.Data.Sqlite.SqliteConnection.LoadExtension%2A> method. Microsoft.Data.Sqlite will ensure that the extension remains loaded even if the connection is closed and reopened.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/ExtensionsSample/Program.cs?name=snippet_LoadExtension)]

> [!NOTE]
> The LoadExtension method was added in version 3.0.

## See also

* [Run-Time Loadable Extensions](https://www.sqlite.org/loadext.html)
