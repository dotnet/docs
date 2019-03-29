---
title: .NET Core Guide
description: .NET Core is a modular, high-performance implementation of .NET for creating Windows, Linux, and Mac apps. Learn about .NET Core to get started.
author: richlander
ms.date: 08/01/2018
ms.custom: "updateeachrelease"
---
# .NET Core Guide

[.NET Core](about.md) is an [open-source](https://github.com/dotnet/coreclr/blob/master/LICENSE.TXT), general-purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core). It's cross-platform (supporting Windows, macOS, and Linux) and can be used to build device, cloud, and IoT applications.

See [About .NET Core](about.md) to learn more about .NET Core, including its characteristics, supported languages and frameworks, and key APIs.

Check out [.NET Core Tutorials](tutorials/index.md) to learn how to create a simple .NET Core application. It only takes a few minutes to get your first app up and running. If you want to try .NET Core in your browser, look at the [Numbers in C#](../csharp/tutorials/intro-to-csharp/numbers-in-csharp.yml) online tutorial.

## Download .NET Core 2.2

Download the [.NET Core  2.2 SDK](https://www.microsoft.com/net/download) to try .NET Core on your Windows, macOS, or Linux machine. Visit [microsoft/dotnet](https://hub.docker.com/r/microsoft/dotnet/) if you prefer to use Docker containers.

All .NET Core versions are available at [.NET Core Downloads](https://www.microsoft.com/net/download/archives) if you're looking for another .NET Core version.

## .NET Core 2.2

The latest version is [.NET Core 2.2](whats-new/dotnet-core-2-2.md). New features include: framework-dependent deployments, startup hooks, AAD authentication with Azure SQL, and support for Windows ARM32.

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

## Support

.NET Core is [supported by Microsoft](https://www.microsoft.com/net/support/policy), on Windows, macOS and Linux. It's updated for security and quality several times a year, typically monthly.

.NET Core binary distributions are built and tested on Microsoft-maintained servers in Azure and supported just like any Microsoft product.

[Red Hat supports .NET Core](http://redhatloves.net/) on Red Hat Enterprise Linux (RHEL). Red Hat builds .NET Core from source and makes it available in the [Red Hat Software Collections](https://developers.redhat.com/products/softwarecollections/overview/). Red Hat and Microsoft collaborate to ensure that .NET Core works well on RHEL.
