---
title: About .NET Core
description: Learn about .NET Core.
ms.date: 09/17/2019
---
# About .NET Core

.NET Core is/has:

- **Cross-platform:** Runs on Windows, macOS, and Linux [operating systems](https://github.com/dotnet/core/blob/master/os-lifecycle-policy.md).
- **Open source:** The .NET Core platform is [open source](https://github.com/dotnet/core), using MIT and Apache 2 licenses. .NET Core is a [.NET Foundation](https://dotnetfoundation.org/) project.
- **Modern:** It implements modern paradigms like asyncronous programming, no-copy patterns using structs, and resource governance for containers.
- **High performance:** Uses [hardware intrinsics](https://devblogs.microsoft.com/dotnet/hardware-intrinsics-in-net-core/) and [constant investment](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-core-3-0/) to improve performance with every release.
- **Consistent across environments:** Runs your code with the same behavior on multiple OSes and architectures, including x64, x86, and ARM.
- **Command-line tools:**  Includes easy-to-use command-line tools that can be used for local development and for continuous-integration.
- **Flexible deployment:** You can include .NET Core in your app or install it side-by-side (user-wide or system-wide installations). Can be used with [Docker containers](docker/introduction.md).

## Languages

C#, Visual Basic, and F# languages can be used to write applications and libraries for .NET Core. These languages can be used in your favorite text editor or Integrated Development Environment (IDE), including:

- [Visual Studio](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link)
- [Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

Editor integration is provided, in part, by the contributors of the [OmniSharp](https://www.omnisharp.net/) and [Ionide](http://ionide.io) projects.

## APIs

.NET Core exposes frameworks for building any kind of app:

* [Cloud apps, with ASP.NET Core](/aspnet/core/)
* [Mobile apps, with Xamarin](/xamarin)
* [IoT apps, with System.Device.GPIO](/archive/msdn-magazine/2019/august/net-core-cross-platform-iot-programming-with-net-core-3-0)
* [Windows client apps, with WPF and Windows Forms](https://docs.microsoft.com/dotnet/desktop-wpf/overview/index)
* [Machine learning, ML.NET](https://docs.microsoft.com/dotnet/machine-learning/).

Many APIs are included that satisfy common needs, such as:

- Primitive types, such as <xref:System.Boolean?displayProperty=nameWithType> and <xref:System.Int32?displayProperty=nameWithType>.
- Collections, such as <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> and <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>.
- Utility types, such as <xref:System.Net.Http.HttpClient?displayProperty=nameWithType>, and <xref:System.IO.FileStream?displayProperty=nameWithType>.
- Data types, such as <xref:System.Data.DataSet?displayProperty=nameWithType>, and [DbSet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/).
- High-performance types, such as <xref:System.Span%601?displayProperty=nameWithType>,  <xref:System.Numerics.Vector?displayProperty=nameWithType> and [Pipelines](../standard/io/pipelines.md).

.NET Core provides compatibility with .NET Framework and Mono APIs by implementing the [.NET Standard](../standard/net-standard.md) specification.

## Composition

.NET Core is composed of the following parts:

- The [.NET Core runtime](https://github.com/dotnet/runtime/tree/master/src/coreclr), which provides a type system, assembly loading, a garbage collector, native interop, and other basic services. [.NET Core framework libraries](https://github.com/dotnet/runtime/tree/master/src/libraries) provide primitive data types, app composition types, and fundamental utilities.
- The [ASP.NET Core runtime](https://github.com/dotnet/aspnetcore), which provides a framework for building modern cloud-based internet connected applications, such as web apps, IoT apps, and mobile backends.
- The [.NET Core CLI tools](https://github.com/dotnet/sdk) and language compilers ([Roslyn](https://github.com/dotnet/roslyn) and [F#](https://github.com/microsoft/visualfsharp)) that enable the .NET Core developer experience.
- The [dotnet tool](https://github.com/dotnet/core-setup), which is used to launch .NET Core apps and CLI tools. It selects the runtime and hosts the runtime, provides an assembly loading policy, and launches apps and tools.

### Open source

[.NET Core](https://github.com/dotnet/core) is open source ([MIT license](https://github.com/dotnet/core/blob/master/LICENSE.TXT)) and was contributed to the [.NET Foundation](https://dotnetfoundation.org) by Microsoft in 2014. It's now one of the most active .NET Foundation projects. It can be used by individuals and companies, including for personal, academic, or commercial purposes. Multiple companies use .NET Core as part of apps, tools, new platforms, and hosting services. Some of these companies make significant contributions to .NET Core on GitHub and provide guidance on the product direction as part of the [.NET Foundation Technical Steering Group](https://dotnetfoundation.org/blog/tsg-welcome).

## Support

.NET Core is [supported by Microsoft](https://dotnet.microsoft.com/platform/support/policy), on Windows, macOS, and Linux. It's updated for security and quality regularly (second tuesday of each month).

.NET Core binary distributions from Microsoft are built and tested on Microsoft-maintained servers in Azure and follow Microsoft engineering and security practices.

[Red Hat supports .NET Core](http://redhatloves.net/) on Red Hat Enterprise Linux (RHEL). Red Hat builds .NET Core from source and makes it available in the [Red Hat Software Collections](https://developers.redhat.com/products/softwarecollections/overview/). Red Hat and Microsoft collaborate to ensure that .NET Core works well on RHEL.
