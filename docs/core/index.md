---
title: .NET Core Guide
description: .NET Core is a modular, high-performance implementation of .NET for creating Windows, Linux, and macOS apps. Learn about .NET Core to get started.
author: richlander
ms.date: 12/04/2019
ms.custom: "updateeachrelease"
---
# .NET Core Guide

[.NET Core](about.md) is an [open-source](https://github.com/dotnet/coreclr/blob/master/LICENSE.TXT), general-purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core). It's cross-platform (supporting Windows, macOS, and Linux) and can be used to build device, cloud, and IoT applications.

See [About .NET Core](about.md) to learn more about .NET Core, including its characteristics, supported languages and frameworks, and key APIs.

Check out [.NET Core Tutorials](tutorials/index.md) to learn how to create a simple .NET Core application. It only takes a few minutes to get your first app up and running. If you want to try .NET Core in your browser, look at the [Numbers in C#](../csharp/tutorials/intro-to-csharp/numbers-in-csharp.yml) online tutorial.

## Download .NET Core

Download the [.NET Core SDK](https://www.microsoft.com/net/download) to try .NET Core on your Windows, macOS, or Linux machine. And if you prefer to use Docker containers, visit the [.NET Core Docker Hub](https://hub.docker.com/_/microsoft-dotnet-core/).

All .NET Core versions are available at [.NET Core Downloads](https://dotnet.microsoft.com/download/dotnet-core) if you're looking for another .NET Core version.

## .NET Core 3.1

The latest version is .NET Core 3.1. 3.1 includes minor improvements over .NET Core 3.0, however, .NET Core 3.1 is a [long-term supported release](https://dotnet.microsoft.com/platform/support/policy/dotnet-core). For more information about the .NET Core 3.1 release, see [What's new in .NET Core 3.1](./whats-new/dotnet-core-3-1.md).

## Create your first application

After installing the .NET Core SDK, open a command prompt. Enter the following `dotnet` commands to create and run a C# application:

```dotnetcli
dotnet new console
dotnet run
```

You should see the following output:

```output
Hello World!
```

## Support

.NET Core is [supported by Microsoft](https://dotnet.microsoft.com/platform/support/policy), on Windows, macOS, and Linux. It's updated for security and quality several times a year, typically monthly.

.NET Core binary distributions are built and tested on Microsoft-maintained servers in Azure and supported just like any Microsoft product.

[Red Hat supports .NET Core](http://redhatloves.net/) on Red Hat Enterprise Linux (RHEL). Red Hat builds .NET Core from source and makes it available in the [Red Hat Software Collections](https://developers.redhat.com/products/softwarecollections/overview/). Red Hat and Microsoft collaborate to ensure that .NET Core works well on RHEL.
