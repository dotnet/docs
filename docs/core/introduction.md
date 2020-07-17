---
title: .NET Core intro and overview
description: .NET Core is a modular, high-performance implementation of .NET for creating Windows, Linux, and macOS apps. Learn about .NET Core to get started.
author: richlander
ms.date: 03/26/2020
ms.custom: "updateeachrelease"
---
# Introduction to .NET Core

[.NET Core](about.md) is an [open-source](https://github.com/dotnet/runtime/blob/master/LICENSE.TXT), general-purpose development platform. You can create .NET Core apps for Windows, macOS, and Linux for x64, x86, ARM32, and ARM64 processors using multiple programming languages. Frameworks and APIs are provided for [cloud](/aspnet/core/), [IoT](/archive/msdn-magazine/2019/august/net-core-cross-platform-iot-programming-with-net-core-3-0), [client UI](../desktop-wpf/overview/index.md), and [machine learning](/dotnet/machine-learning/).

[Download the .NET Core SDK](https://dotnet.microsoft.com/download) to try .NET Core on your machine. The latest version is [.NET Core 3.1](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-1/).

## Download .NET Core

You can get .NET Core in the following ways:

* [Installers for Windows and macOS](https://dotnet.microsoft.com/download)
* [Linux packages](https://docs.microsoft.com/dotnet/core/install/linux-package-managers)
* [Docker containers](https://hub.docker.com/_/microsoft-dotnet-core/)
* [Zips and tarballs](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [Install scripts](https://dotnet.microsoft.com/download/dotnet-core/scripts)
* [Release notes](https://github.com/dotnet/core/tree/master/release-notes)

## Create your first application

After installing the .NET Core SDK, open a command prompt. Use the following commands to create and run an application:

```dotnetcli
dotnet new console
dotnet run
```

You should see the following output:

```output
Hello World!
```

## Contribute

.NET Core is an open platform. Everyone is welcome to participate.

* File product issues and questions at [Developer Community](https://developercommunity.visualstudio.com/spaces/61/index.html).
* Product contributions should be made on one of the project repositories, such as [dotnet/runtime](https://github.com/dotnet/runtime), [dotnet/sdk](https://github.com/dotnet/sdk), [dotnet/rosyln](https://github.com/dotnet/roslyn), or [aspnetcore](https://github.com/dotnet/aspnetcore). For more information, see [.NET Core repos](https://github.com/dotnet/core/blob/master/Documentation/core-repos.md).

## Support

.NET Core is supported by Microsoft on Windows, macOS, and Linux and by Red Hat on Red Hat Enterprise Linux.

## Next steps

> [!div class="nextstepaction"]
> [.NET Core tutorials](tutorials/index.md)

> [!div class="nextstepaction"]
> [Try .NET Core in your browser](../csharp/tutorials/intro-to-csharp/numbers-in-csharp.yml)
