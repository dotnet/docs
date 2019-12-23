---
title: Xamarin limitations
ms.date: 12/13/2019
description: Describes some of the limitations you will encounter when using Xamarin.
---
# Xamarin limitations

Microsoft.Data.Sqlite targets .NET Standard 2.0 and is supported on Xamarin. The following table shows which platforms the default SQLitePCLRaw bundle provides native SQLite binaries for. See [Custom SQLite versions](custom-versions.md) for details on using a different bundle or providing your own native SQLite binaries.

| Platform | SQLite binaries |
| --- | --- |
| **Xamarin.Android** | — |
| &nbsp;&nbsp;&nbsp;&nbsp;`arm64-v8a` | ✔ |
| &nbsp;&nbsp;&nbsp;&nbsp;`armeabi-v7a` | ✔ |
| &nbsp;&nbsp;&nbsp;&nbsp;`x86` | ✔ |
| &nbsp;&nbsp;&nbsp;&nbsp;`x86_64` | ✔ |
| **Xamarin.iOS** | ✔ |
| **Xamarin.Mac** | ✔ |
| **Xamarin.TVOS** | ✔ |
| **UWP** | — |
| &nbsp;&nbsp;&nbsp;&nbsp;`arm` | ✔ |
| &nbsp;&nbsp;&nbsp;&nbsp;`arm64` | ✔ |
| &nbsp;&nbsp;&nbsp;&nbsp;`x64` | ✔ |
| &nbsp;&nbsp;&nbsp;&nbsp;`x86` | ✔ |

## iOS

Microsoft.Data.Sqlite tries to automatically initialize SQLitePCLRaw bundles. Unfortunately, because of limitations in the ahead-of-time (AOT) compilation for Xamarin.iOS, the attempt fails and you get the following error.

> You need to call `SQLitePCL.raw.SetProvider()`. If you're using a bundle package, this is done by calling `SQLitePCL.Batteries.Init()`.

To initialize the bundle, add the following line of code to your app before using Microsoft.Data.Sqlite.

```csharp
SQLitePCL.Batteries_V2.Init();
```

## See also

* [Async limitations](async.md)
* [Custom SQLite versions](custom-versions.md)
