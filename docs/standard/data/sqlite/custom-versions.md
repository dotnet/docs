---
title: Custom SQLite versions
ms.date: 09/04/2020
description: Learn how to use a custom version of the native SQLite library.
---

# Custom SQLite versions

`Microsoft.Data.Sqlite` is built on top of `SQLitePCLRaw`. You can use custom versions of the native SQLite library by using a bundle or by configuring a `SQLitePCLRaw` provider.

## Bundles

`SQLitePCLRaw` provides convenience-based bundle packages, that make it easy to bring in the right dependencies across different platforms. The main `Microsoft.Data.Sqlite` package brings in `SQLitePCLRaw.bundle_e_sqlite3` by default. To use a different bundle, install the `Microsoft.Data.Sqlite.Core` package instead along with the bundle package you want to use. Bundles are automatically initialized by `Microsoft.Data.Sqlite`.

| Bundle | Description |
|--|--|
| [SQLitePCLRaw.bundle_e_sqlite3](https://www.nuget.org/packages/SQLitePCLRaw.bundle_e_sqlite3) | Provides a consistent version of SQLite on all platforms. Includes the FTS4, FTS5, JSON1, and R*Tree extensions. This is the default. |
| [SQLitePCLRaw.bundle_e_sqlcipher](https://www.nuget.org/packages/SQLitePCLRaw.bundle_e_sqlcipher) | Provides an unofficial, open-source build of `SQLCipher`. |
| [SQLitePCLRaw.bundle_green](https://www.nuget.org/packages/SQLitePCLRaw.bundle_green) | Same as `bundle_e_sqlite3`, except on iOS where it uses the system SQLite library. |
| [SQLitePCLRaw.bundle_sqlite3](https://www.nuget.org/packages/SQLitePCLRaw.bundle_sqlite3) | Uses the system SQLite library. |
| [SQLitePCLRaw.bundle_winsqlite3](https://www.nuget.org/packages/SQLitePCLRaw.bundle_winsqlite3) | Uses `winsqlite3.dll`, the system SQLite library on Windows 10. |
| [SQLitePCLRaw.bundle_zetetic](https://www.nuget.org/packages/SQLitePCLRaw.bundle_zetetic) | Uses the official `SQLCipher` builds from Zetetic (not included). |

For example, to use the unofficial, open-source build of `SQLCipher` use the following commands.

### [.NET CLI](#tab/net-cli)

```dotnetcli
dotnet package add Microsoft.Data.Sqlite.Core
dotnet package add SQLitePCLRaw.bundle_e_sqlcipher
```

### [Visual Studio](#tab/visual-studio)

``` PowerShell
Install-Package Microsoft.Data.Sqlite.Core
Install-Package SQLitePCLRaw.bundle_e_sqlcipher
```

---

## SQLitePCLRaw available providers

When not relying on a bundle, you can use the available providers of SQLite with the core assembly.

| Provider | Description |
|--|--|
| [SQLitePCLRaw.provider.dynamic](https://www.nuget.org/packages/SQLitePCLRaw.provider.dynamic) | The `dynamic` provider loads the native library instead of using <xref:System.Runtime.InteropServices.DllImportAttribute?displayProperty=nameWithType> attributes. For more information on using this provider, see [use the dynamic provider](#use-the-dynamic-provider). |
| [SQLitePCLRaw.provider.e_sqlite3](https://www.nuget.org/packages/SQLitePCLRaw.provider.e_sqlite3) | The `e_sqlite3` is the default provider. |
| [SQLitePCLRaw.provider.e_sqlcipher](https://www.nuget.org/packages/SQLitePCLRaw.provider.e_sqlcipher) | The `e_sqlcipher` provider is the unofficial and unsupported `SQLCipher`. |
| [SQLitePCLRaw.provider.sqlite3](https://www.nuget.org/packages/SQLitePCLRaw.provider.sqlite3) | The `sqlite3` provider is a system-provided `SQLite` for iOS, macOS, and Linux. |
| [SQLitePCLRaw.provider.sqlcipher](https://www.nuget.org/packages/SQLitePCLRaw.provider.sqlcipher) | The `sqlcipher` provider is for official `SQLCipher` builds from `Zetetic`. |
| [SQLitePCLRaw.provider.winsqlite3](https://www.nuget.org/packages/SQLitePCLRaw.provider.winsqlite3) | The `winsqlite3` provider is for Windows 10 environments. |

To use the `sqlite3` provider use the following commands:

### [.NET CLI](#tab/net-cli)

```dotnetcli
dotnet package add Microsoft.Data.Sqlite.Core
dotnet package add SQLitePCLRaw.core
dotnet package add SQLitePCLRaw.provider.sqlite3
```

### [Visual Studio](#tab/visual-studio)

``` PowerShell
Install-Package Microsoft.Data.Sqlite.Core
Install-Package SQLitePCLRaw.core
Install-Package SQLitePCLRaw.provider.sqlite3
```

---

With the packages installed, you then set the provider to the `sqlite3` instance.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/SqliteProviderSample/Program.cs)]

## Use the dynamic provider

You can use your own build of SQLite by leveraging the `SQLitePCLRaw.provider.dynamic_cdecl` package. In this case, you're responsible for deploying the native library with your app. Note, the details of deploying native libraries with your app vary considerably depending on which .NET platform and runtime you're using.

First, you'll need to implement `IGetFunctionPointer`. The implementation on .NET Core is as follows:

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/SystemLibrarySample/Program.cs?name=snippet_NativeLibraryAdapter)]

Next, configure the `SQLitePCLRaw` provider. Ensure this is done before `Microsoft.Data.Sqlite` is used in your app. Also, avoid using a `SQLitePCLRaw` bundle package which might override your provider.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/SystemLibrarySample/Program.cs?name=snippet_SetProvider)]
