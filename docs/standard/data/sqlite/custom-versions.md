---
title: Custom SQLite versions
ms.date: 12/13/2019
description: Learn how to use a custom version of the native SQLite library.
---
# Custom SQLite versions

Microsoft.Data.Sqlite is built on top of SQLitePCLRaw. You can use custom versions of the native SQLite library by using a bundle or by configuring a SQLitePCLRaw provider.

## Bundles

SQLitePCLRaw provides bundle packages that make it easy to bring in the right dependencies across different platforms.

The main Microsoft.Data.Sqlite package brings in SQLitePCLRaw.bundle_e_sqlite3 by default.

To use a different bundle, install the `Microsoft.Data.Sqlite.Core` package instead along with the bundle package you want to use. Bundles are automatically initialized by Microsoft.Data.Sqlite.

| Bundle | Description |
| --- | --- |
| SQLitePCLRaw.bundle_e_sqlite3 | Provides a consistent version of SQLite on all platforms. Includes the FTS4, FTS5, JSON1, and | R*Tree extensions. This is the default. |
| SQLitePCLRaw.bundle_green | Same as bundle_e_sqlite3, except on iOS where it uses the system SQLite library. |
| SQLitePCLRaw.bundle_zetetic | Uses the official SQLCipher builds from Zetetic (not included). |
| SQLitePCLRaw.bundle_winsqlite3 | Uses winsqlite3.dll, the system SQLite library on Windows 10. |
| SQLitePCLRaw.bundle_e_sqlcipher | Provides an unofficial, open-source build of SQLCipher. |

For example, to use the unofficial, open-source build of SQLCipher use the following commands.

### [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet add package Microsoft.Data.Sqlite.Core
dotnet add package SQLitePCLRaw.bundle_e_sqlcipher
```

### [Visual Studio](#tab/visual-studio)

``` PowerShell
Install-Package Microsoft.Data.Sqlite.Core
Install-Package SQLitePCLRaw.bundle_e_sqlcipher
```

---

## SQLitePCLRaw providers

You can use your own build of SQLite by leveraging the `SQLitePCLRaw.provider.dynamic_cdecl` package. In this case, you're responsible for deploying the native library with your app. Note, the details of deploying native libraries with your app vary considerably depending on which .NET platform and runtime you're using.

First, you'll need to implement IGetFunctionPointer. The implementation is fairly trivial on .NET Core.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/SystemLibrarySample/Program.cs?name=snippet_NativeLibraryAdapter)]

Next, configure the SQLitePCLRaw provider. Ensure this is done before Microsoft.Data.Sqlite is used in your app. Also, avoid using a SQLitePCLRaw bundle package which might override your provider.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/SystemLibrarySample/Program.cs?name=snippet_SetProvider)]
