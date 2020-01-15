---
title: .NET Core guide
description: .NET Core is a modular, high-performance implementation of .NET for creating Windows, Linux, and macOS apps. Learn about .NET Core to get started.
author: richlander
ms.date: 12/04/2019
ms.custom: "updateeachrelease"
---
# .NET Core guide

[.NET Core](about.md) is an [open-source](https://github.com/dotnet/runtime/blob/master/LICENSE.TXT), general-purpose development platform. You can create .NET Core apps for Windows, macOS, and Linux, for x64, x86, ARM32 and ARM64 processors, with [C#](/dotnet/csharp/), [F#](/dotnet/fsharp/) and [VB](/dotnet/visual-basic/) languages. Frameworks and APIs are provided for [cloud](/aspnet/core/), [IoT](/archive/msdn-magazine/2019/august/net-core-cross-platform-iot-programming-with-net-core-3-0), [client UI](/dotnet/desktop-wpf/overview/index), and [machine learning](/dotnet/machine-learning/).

You can [download the .NET Core SDK](https://dotnet.microsoft.com/download) to try .NET Core on your machine. The latest version is [.NET Core 3.1](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-1/).

See [About .NET Core](about.md) to learn more about .NET Core, and  [What's new in .NET Core 3.1](./whats-new/dotnet-core-3-1.md) to learn about the latest release.

Check out [.NET Core Tutorials](tutorials/index.md) to learn how to create a simple .NET Core application. It only takes a few minutes to get your first app up and running. If you want to try .NET Core in your browser, look at the [Numbers in C#](../csharp/tutorials/intro-to-csharp/numbers-in-csharp.yml) online tutorial.

## Download .NET Core

You can get .NET Core in the following ways:

* [Installers for Windows and macOS](https://dotnet.microsoft.com/download)
* [Linux packages](https://docs.microsoft.com/dotnet/core/install/linux-package-managers)
* [Docker containers](https://hub.docker.com/_/microsoft-dotnet-core/)
* [Zips and tar balls](https://dotnet.microsoft.com/download/dotnet-core/3.1)
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

## Participate

.NET Core is an open platform. Everyone is welcome to participate.

* Product issues and questions should be filed as issues at [dotnet/core](https://github.com/dotnet/core/issues)
* Contributions should be made on one of the project repos, such as [dotnet/runtime](https://github.com/dotnet/runtime), [dotnet/sdk](https://github.com/dotnet/sdk), [dotnet/rosyln](https://github.com/dotnet/roslyn), or [aspnetcore](https://github.com/dotnet/aspnetcore)

Thanks! .NET Core was made with love.

## Support

.NET Core is supported by Microsoft on Windows, macOS and Linux and by Red Hat on Red Hat Enterprise Linux.
