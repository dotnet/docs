---
title: .NET Core Guide
description: .NET Core is a modular, high-performance implementation of .NET for creating Windows, Linux, and Mac apps. Learn about .NET Core to get started.
author: richlander
ms.author: mairaw
ms.date: 06/20/2016
---
# .NET Core Guide

[.NET Core](about.md) is an [open source](https://github.com/dotnet/coreclr/blob/master/LICENSE.TXT) general purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core). It is cross-platform, supporting Windows, macOS and Linux, and can be used in device, cloud, and embedded/IoT scenarios.

See [About .NET Core](about.md) to learn more about .NET Core.

Check out [.NET Core Tutorials](tutorials/index.md) to learn how to create a simple .NET Core application. It only takes a few minutes to get your first app up and running.

Try .NET Core in your browser:

* [Hello C#](https://docs.microsoft.com/dotnet/csharp/quick-starts/hello-world)
* [Numbers in C#](https://docs.microsoft.com/dotnet/csharp/quick-starts/numbers-in-csharp)
* [Collections in C#](https://docs.microsoft.com/dotnet/csharp/quick-starts/list-collection)

## .NET Core 2.1

The latest version is [.NET Core 2.1](whats-new.md). New features include: global tools, high-performance APIs (such as <xref:System.Span%601?displayProperty=nameWithType>), tiered JIT compilation, [build](https://blogs.msdn.microsoft.com/dotnet/2018/05/30/announcing-net-core-2-1/) and [runtime performance improvements](https://blogs.msdn.microsoft.com/dotnet/2018/04/18/performance-improvements-in-net-core-2-1/), and  support for Alpine and ARM32.

## Download .NET Core 2.1

Download the [.NET Core  2.1 SDK](https://www.microsoft.com/net/download) to try .NET Core on your Windows, macOS or Linux machine. Visit [microsoft/dotnet](https://hub.docker.com/r/microsoft/dotnet/) if you prefer to use Docker containers.

All .NET Core versions are available at [.NET Core Downloads](https://www.microsoft.com/net/download/archives) if you are looking for another .NET Core version.

## Create your first application

After installing the .NET Core SDK, open a command prompt. Type the following `dotnet` commands to create and run a C# application.

```console
dotnet new console
dotnet run
```

You should see the following output:

```console
Hello World!
```
