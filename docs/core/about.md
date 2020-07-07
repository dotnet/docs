---
title: .NET Core overview
description: Learn about the characteristics and composition of .NET Core, and compare it to other .NET implementations.
ms.date: 03/26/2020
---
# .NET Core overview

> [!div class="button"]
> [Download .NET Core](https://dotnet.microsoft.com/download)

.NET Core has the following characteristics:

- **Cross platform:** Runs on Windows, macOS, and Linux [operating systems](https://github.com/dotnet/core/blob/master/os-lifecycle-policy.md).
- **Open source:** The .NET Core framework is [open source](https://github.com/dotnet/core), using MIT and Apache 2 licenses. .NET Core is a [.NET Foundation](https://dotnetfoundation.org/) project.
- **Modern:** It implements modern paradigms like asynchronous programming, no-copy patterns using structs, and resource governance for containers.
- **Performance:**  Delivers [high performance](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-core-3-0/) with features like [hardware intrinsics](https://devblogs.microsoft.com/dotnet/hardware-intrinsics-in-net-core/), [tiered compilation](https://github.com/dotnet/coreclr/blob/master/Documentation/design-docs/tiered-compilation.md), and [Span\<T>](../standard/memory-and-spans/index.md).
- **Consistent across environments:** Runs your code with the same behavior on multiple operating systems and architectures, including x64, x86, and ARM.
- **Command-line tools:**  Includes easy-to-use command-line tools that can be used for local development and for continuous integration.
- **Flexible deployment:** You can include .NET Core in your app or install it side-by-side (user-wide or system-wide installations). Can be used with [Docker containers](docker/introduction.md).

## Languages

The [C#](../csharp/index.yml), [Visual Basic](../visual-basic/index.yml), and [F#](../fsharp/index.yml) languages can be used to write applications and libraries for .NET Core. These languages can be used in your favorite text editor or Integrated Development Environment (IDE), including:

- [Visual Studio](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link)
- [Visual Studio Code](https://code.visualstudio.com/download)

Editor integration is provided, in part, by the contributors of the [OmniSharp](https://www.omnisharp.net/) and [Ionide](https://ionide.io) projects.

## APIs

.NET Core exposes frameworks for building any kind of app:

* Cloud apps with [ASP.NET Core](/aspnet/core/)
* Mobile apps with [Xamarin](/xamarin)
* IoT apps with [System.Device.GPIO](https://docs.microsoft.com/archive/msdn-magazine/2019/august/net-core-cross-platform-iot-programming-with-net-core-3-0)
* Windows client apps with [WPF](../desktop-wpf/overview/index.md) and Windows Forms
* Machine learning [ML.NET](../machine-learning/index.yml)

Many APIs are included that satisfy common needs:

- Primitive types, such as <xref:System.Boolean?displayProperty=nameWithType> and <xref:System.Int32?displayProperty=nameWithType>.
- Collections, such as <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> and <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>.
- Utility types, such as <xref:System.Net.Http.HttpClient?displayProperty=nameWithType>, and <xref:System.IO.FileStream?displayProperty=nameWithType>.
- Data types, such as <xref:System.Data.DataSet?displayProperty=nameWithType>, and <xref:System.Data.Entity.DbSet?displayProperty=nameWithType>.
- High-performance types, such as <xref:System.Span%601?displayProperty=nameWithType>, <xref:System.Numerics.Vector?displayProperty=nameWithType>, and [Pipelines](../standard/io/pipelines.md).

.NET Core provides compatibility with .NET Framework and Mono APIs by implementing the [.NET Standard](../standard/net-standard.md) specification.

## Composition

.NET Core is composed of the following parts:

- The [.NET Core runtime](https://github.com/dotnet/runtime/tree/master/src/coreclr), which provides a type system, assembly loading, a garbage collector, native interop, and other basic services. [.NET Core framework libraries](https://github.com/dotnet/runtime/tree/master/src/libraries) provide primitive data types, app composition types, and fundamental utilities.
- The [ASP.NET Core runtime](https://github.com/dotnet/aspnetcore), which provides a framework for building modern, cloud-based, internet-connected apps, such as web apps, IoT apps, and mobile backends.
- The [.NET Core SDK](https://github.com/dotnet/sdk) and language compilers ([Roslyn](https://github.com/dotnet/roslyn) and [F#](https://github.com/microsoft/visualfsharp)) that enable the .NET Core developer experience.
- The [dotnet command](./tools/dotnet.md), which is used to launch .NET Core apps and CLI commands. It selects and hosts the runtime, provides an assembly loading policy, and launches apps and tools.

### Open source

[.NET Core](about.md) is an [open-source](https://github.com/dotnet/runtime/blob/master/LICENSE.TXT), general-purpose development platform. You can create .NET Core apps for Windows, macOS, and Linux for x64, x86, ARM32, and ARM64 processors. Frameworks and APIs are provided for [cloud](/aspnet/core/), [IoT](https://docs.microsoft.com/archive/msdn-magazine/2019/august/net-core-cross-platform-iot-programming-with-net-core-3-0), [client UI](../desktop-wpf/overview/index.md), and [machine learning](../machine-learning/index.yml).

## Support

.NET Core is [supported by Microsoft](https://dotnet.microsoft.com/platform/support/policy) on Windows, macOS, and Linux. It's updated for security and quality regularly (the second Tuesday of each month).

.NET Core binary distributions from Microsoft are built and tested on Microsoft-maintained servers in Azure and follow Microsoft engineering and security practices.

[Red Hat supports .NET Core](https://developers.redhat.com/topics/dotnet/) on Red Hat Enterprise Linux (RHEL). Red Hat builds .NET Core from source and makes it available in the [Red Hat Software Collections](https://developers.redhat.com/products/softwarecollections/overview/). Red Hat and Microsoft collaborate to ensure that .NET Core works well on RHEL.

[Tizen supports .NET Core](https://developer.tizen.org/development/training/.net-application) on Tizen platforms.
