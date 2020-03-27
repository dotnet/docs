---
title: .NET Core overview
description: Learn about the characteristics and composition of .NET Core, and compare it to other .NET implementations.
ms.date: 09/17/2019
---
# .NET Core overview

.NET Core has the following characteristics:

- **Cross-platform:** Runs on Windows, macOS, and Linux [operating systems](https://github.com/dotnet/core/blob/master/os-lifecycle-policy.md).
- **Consistent across architectures:** Runs your code with the same behavior on multiple architectures, including x64, x86, and ARM.
- **Command-line tools:**  Includes easy-to-use command-line tools that can be used for local development and in continuous-integration scenarios.
- **Flexible deployment:** Can be included in your app or installed side-by-side (user-wide or system-wide installations). Can be used with [Docker containers](docker/introduction.md).
- **Compatible:** .NET Core is compatible with the .NET Framework, Xamarin, and Mono implementations via [.NET Standard](../standard/net-standard.md).
- **Open source:** The .NET Core platform is open source, using MIT and Apache 2 licenses. .NET Core is a [.NET Foundation](https://dotnetfoundation.org/) project.
- **Supported by Microsoft:** .NET Core is [supported by Microsoft](https://dotnet.microsoft.com/platform/support/policy).

## Languages

The C#, Visual Basic, and F# languages can be used to write applications and libraries for .NET Core. These languages can be used in your favorite text editor or Integrated Development Environment (IDE), including:

- [Visual Studio](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link)
- [Visual Studio Code](https://code.visualstudio.com/download)
- Sublime Text
- Vim

Editor integration is provided, in part, by the contributors of the [OmniSharp](https://www.omnisharp.net/) and [Ionide](http://ionide.io) projects.

## APIs

Many APIs are included that satisfy common needs, such as:

- Primitive types, such as <xref:System.Boolean?displayProperty=nameWithType> and <xref:System.Int32?displayProperty=nameWithType>.
- Collections, such as <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> and <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>.
- Utility types, such as <xref:System.Net.Http.HttpClient?displayProperty=nameWithType>, and <xref:System.IO.FileStream?displayProperty=nameWithType>.
- Data types, such as <xref:System.Data.DataSet?displayProperty=nameWithType>, and [DbSet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/).
- High-performance types, such as <xref:System.Numerics.Vector?displayProperty=nameWithType> and [Pipelines](../standard/io/pipelines.md).

.NET Core provides compatibility with .NET Framework and Mono APIs by implementing the [.NET Standard](../standard/net-standard.md) specification.

## Frameworks

Multiple frameworks have been built on top of .NET Core, including:

- [ASP.NET Core](/aspnet/core/)
- [Universal Windows Platform (UWP)](/windows/uwp/)
- [Tizen](https://developer.tizen.org/development/training/.net-application)

## Composition

.NET Core is composed of the following parts:

- The [.NET Core runtime](https://github.com/dotnet/runtime/tree/master/src/coreclr), which provides a type system, assembly loading, a garbage collector, native interop, and other basic services. [.NET Core framework libraries](https://github.com/dotnet/runtime/tree/master/src/libraries) provide primitive data types, app composition types, and fundamental utilities.
- The [ASP.NET Core runtime](https://github.com/dotnet/aspnetcore), which provides a framework for building modern, cloud-based, internet-connected apps, such as web apps, IoT apps, and mobile backends.
- The [.NET Core SDK](https://github.com/dotnet/sdk) and language compilers ([Roslyn](https://github.com/dotnet/roslyn) and [F#](https://github.com/microsoft/visualfsharp)) that enable the .NET Core developer experience.
- The [dotnet command](./tools/dotnet.md), which is used to launch .NET Core apps and CLI commands. It selects and hosts the runtime, provides an assembly loading policy, and launches apps and tools.

These components are distributed in the following ways:

- [.NET Core Runtime](https://dotnet.microsoft.com/download) -- includes the .NET Core runtime and framework libraries.
- [ASP.NET Core Runtime](https://dotnet.microsoft.com/download) -- includes the ASP.NET Core and .NET Core runtimes and framework libraries.
- [.NET Core SDK](https://dotnet.microsoft.com/download) -- includes the .NET Core CLI, ASP.NET Core runtime, and .NET Core runtime and framework.

### Open source

[.NET Core](https://github.com/dotnet/core) is open-source ([MIT license](https://github.com/dotnet/core/blob/master/LICENSE.TXT)) and was contributed to the [.NET Foundation](https://dotnetfoundation.org) by Microsoft in 2014. It's now one of the most active .NET Foundation projects. It can be used by individuals and companies, including for personal, academic, or commercial purposes. Multiple companies use .NET Core as part of apps, tools, new platforms, and hosting services. Some of these companies make significant contributions to .NET Core on GitHub and provide guidance on the product direction as part of the [.NET Foundation Technical Steering Group](https://dotnetfoundation.org/blog/tsg-welcome).

### Designed for adaptability

.NET Core has been built as a similar but unique product compared to other .NET products. It was designed to enable broad adaptability to new platforms and workloads, and it has several OS and CPU ports available (and it may be ported to many more).

The product is broken into several pieces, enabling the various parts to be adapted to new platforms at different times. The runtime and platform-specific foundational libraries must be ported as a unit. Platform-agnostic libraries should work as-is on all platforms, by construction. There's a project bias towards reducing platform-specific implementations to increase developer efficiency, preferring platform-neutral C# code whenever an algorithm or API can be implemented in-full or in-part that way.

People commonly ask how .NET Core is implemented in order to support multiple operating systems. They typically ask if there are separate implementations or if [conditional compilation](https://en.wikipedia.org/wiki/Conditional_compilation) is used. It's both, with a strong bias towards conditional compilation.

You can see in the following chart that the vast majority of [.NET Core libraries](https://github.com/dotnet/runtime/tree/master/src/libraries) are compiled from platform-neutral code that's shared across all platforms. Platform-neutral code can be implemented as a single portable assembly that's used on all platforms.

![CoreFX: Lines of Code per Platform](../images/corefx-platforms-loc.png)

The Windows and Unix implementations are similar in size. The Windows implementation contains some Windows-only features, such as [Microsoft.Win32.Registry](https://github.com/dotnet/runtime/tree/master/src/libraries/Microsoft.Win32.Registry), but doesn't yet implement many Unix-only concepts. Much of the Linux and macOS implementations is shared across a Unix implementation. The Linux-specific and macOS-specific implementations are similar in size.

There's a mix of platform-specific and platform-neutral libraries in .NET Core. You can see the pattern in a few examples:

- [CoreCLR](https://github.com/dotnet/runtime/tree/master/src/coreclr) is platform-specific. It builds on top of OS subsystems, like the memory manager and thread scheduler.
- [System.IO](https://github.com/dotnet/runtime/tree/master/src/libraries/System.IO) and [System.Security.Cryptography.Algorithms](https://github.com/dotnet/runtime/tree/master/src/libraries/System.Security.Cryptography.Algorithms) are platform-specific, given that storage and cryptography APIs are different on each OS.
- [System.Collections](https://github.com/dotnet/runtime/tree/master/src/libraries/System.Collections) and [System.Linq](https://github.com/dotnet/runtime/tree/master/src/libraries/System.Linq) are platform-neutral, given that they create and operate over data structures.

## Comparisons to other .NET implementations

To understand the size and shape of .NET Core, the following sections compare it to existing .NET implementations.

### .NET Core vs. .NET Framework

.NET was first announced by Microsoft in 2000 and evolved from there. .NET Framework has been the primary .NET implementation produced by Microsoft during that nearly two decade period.

The major differences between .NET Core and .NET Framework are:

- **App-models** -- .NET Core doesn't support all the .NET Framework app-models. In particular, it doesn't support ASP.NET Web Forms and ASP.NET MVC, but it supports ASP.NET Core MVC. And starting with .NET Core 3.0, .NET Core also supports WPF and Windows Forms on Windows only.
- **APIs** -- .NET Core contains a large subset of .NET Framework Base Class Library, with a different factoring (assembly names are different; members exposed on types differ in key cases). In some cases, these differences require changes to port source to .NET Core. For more information, see [The .NET Portability Analyzer](../standard/analyzers/portability-analyzer.md). .NET Core implements the [.NET Standard](../standard/net-standard.md) API specification.
- **Subsystems** -- .NET Core implements a subset of the subsystems in .NET Framework, with the goal of a simpler implementation and programming model. For example, Code Access Security (CAS) isn't supported, while reflection is supported.
- **Platforms** -- .NET Framework supports Windows and Windows Server while .NET Core also supports macOS and Linux.
- **Open source** -- .NET Core is open source, while a [read-only subset of .NET Framework](https://github.com/microsoft/referencesource) is open source.

While .NET Core is unique and has significant differences to .NET Framework and other .NET implementations, it's straightforward to share code between these implementations, using either source or binary sharing techniques.

Because .NET Core supports side-by-side installation and its runtime is completely independent of .NET Framework, it can be installed on machines that have .NET Framework installed without any issues.

### .NET Core vs. Mono

[Mono](https://www.mono-project.com/) is the original cross-platform implementation of .NET. It started out as an [open-source](https://github.com/mono/mono) alternative to .NET Framework and transitioned to targeting mobile devices as iOS and Android devices became popular. It can be thought of as a community clone of .NET Framework. To provide a compatible implementation, the Mono project team relied on the open [.NET standards](https://github.com/dotnet/runtime/blob/master/docs/project/dotnet-standards.md) (notably ECMA 335) published by Microsoft.

The major differences between .NET Core and Mono are:

- **App-models** -- Mono supports a subset of the .NET Framework app-models (for example, Windows Forms) and some additional ones for mobile development (for example, [Xamarin.iOS](https://www.xamarin.com/platform)) through the Xamarin product. .NET Core doesn't support Xamarin.
- **APIs** -- Mono supports a [large subset](http://docs.go-mono.com/?link=root%3a%2fclasslib) of the .NET Framework APIs, using the same assembly names and factoring.
- **Platforms** -- Mono supports many platforms and CPUs.
- **Open Source** -- Mono and .NET Core both use the MIT license and are .NET Foundation projects.
- **Focus** -- The primary focus of Mono in recent years is mobile platforms, while .NET Core is focused on cloud and desktop workloads.

## Support

.NET Core is [supported by Microsoft](https://dotnet.microsoft.com/platform/support/policy) on Windows, macOS, and Linux. It's updated for security and quality regularly (second Tuesday of each month).

.NET Core binary distributions from Microsoft are built and tested on Microsoft-maintained servers in Azure and follow Microsoft engineering and security practices.

[Red Hat supports .NET Core](http://redhatloves.net/) on Red Hat Enterprise Linux (RHEL). Red Hat builds .NET Core from source and makes it available in the [Red Hat Software Collections](https://developers.redhat.com/products/softwarecollections/overview/). Red Hat and Microsoft collaborate to ensure that .NET Core works well on RHEL.

[Tizen supports .NET Core](https://developer.tizen.org/development/training/.net-application) on Tizen platforms.
