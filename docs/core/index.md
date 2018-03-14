---
title: .NET Core Guide
description: .NET Core is a modular, high-performance implementation of .NET for creating Windows, Linux, and Mac apps. Learn about .NET Core to get started.
keywords: .NET, .NET Core
author: richlander
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: f2b312cb-f80c-4b0d-9101-93908f06a6fa
ms.workload: 
  - dotnetcore
---

# .NET Core Guide

> Check out the ["Getting Started" tutorials](get-started.md) to learn how to create a simple .NET Core application. It only takes a few minutes to get your first app up and running.

.NET Core is a general purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core). It is cross-platform, supporting Windows, macOS and Linux, and can be used in device, cloud, and embedded/IoT scenarios. 

The following characteristics best define .NET Core:

- **Flexible deployment:** Can be included in your app or installed side-by-side user- or machine-wide.
- **Cross-platform:** Runs on Windows, macOS and Linux; can be ported to other operating systems. The [supported Operating Systems (OS)](https://github.com/dotnet/core/blob/master/roadmap.md), CPUs and application scenarios will grow over time, provided by Microsoft, other companies, and individuals.
- **Command-line tools:**  All product scenarios can be exercised at the command-line. 
- **Compatible:** .NET Core is compatible with .NET Framework, Xamarin and Mono, via the [.NET Standard](../standard/net-standard.md).
- **Open source:** The .NET Core platform is open source, using MIT and Apache 2 licenses. Documentation is licensed under [CC-BY](https://creativecommons.org/licenses/by/4.0/). .NET Core is a [.NET Foundation](https://dotnetfoundation.org/) project.
- **Supported by Microsoft:** .NET Core is supported by Microsoft, per [.NET Core Support](https://www.microsoft.com/net/core/support/)

## Composition

.NET Core is composed of the following parts:

- A [.NET runtime](https://github.com/dotnet/coreclr), which provides a type system, assembly loading, a garbage collector, native interop and other basic services. 
- A set of [framework libraries](https://github.com/dotnet/corefx), which provide primitive data types, app composition types and fundamental utilities. 
- A [set of SDK tools](https://github.com/dotnet/cli) and [language compilers](https://github.com/dotnet/roslyn) that enable the base developer experience, available in the [.NET Core SDK](sdk.md).
- The 'dotnet' app host, which is used to launch .NET Core apps. It selects the runtime and hosts the runtime, provides an assembly loading policy and launches the app. The same host is also used to launch SDK tools in much the same way.

### Languages

The C#, Visual Basic, and F# languages can be used to write applications and libraries for .NET Core. The compilers run on .NET Core, enabling you to develop for .NET Core anywhere it runs. In general, you will not use the compilers directly, but indirectly using the SDK tools.

The C#, Visual Basic, and F# compilers and the .NET Core tools are or can be integrated into several text editors and IDEs, including Visual Studio, [Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp), Sublime Text and Vim, making .NET Core development an option in your favorite coding environment and OS. This integration is provided, in part, by the good folks of the [OmniSharp project](http://www.omnisharp.net/).

### .NET APIs and Compatibility

.NET Core can be thought of as a cross-platform version of the .NET Framework, at the layer of the .NET Framework Base Class Libraries (BCL). It implements the [.NET Standard](../standard/net-standard.md) specification. .NET Core provides a subset of the APIs that are available in the .NET Framework or Mono/Xamarin. In some cases, types are not fully implemented (some members are not available or have been moved).

Look at the [.NET Core roadmap](https://github.com/dotnet/core/blob/master/roadmap.md) to learn more about the .NET Core API roadmap.

### Relationship to .NET Standard

The [.NET Standard](../standard/net-standard.md) is an API spec that describes the consistent set of .NET APIs that developers can expect in each .NET implementation. .NET implementations need to implement this spec in order to be considered .NET Standard-compliant and to support libraries that target .NET Standard. 

.NET Core implements .NET Standard, and therefore supports .NET Standard libraries.

### Workloads

By itself, .NET Core includes a single application model -- console apps -- which is useful for tools, local services and text-based games. Additional application models have been built on top of .NET Core to extend its functionality, such as:

- [ASP.NET Core](/aspnet/core/)
- [Windows 10 Universal Windows Platform (UWP)](https://developer.microsoft.com/windows)
- [Xamarin.Forms when targeting UWP](https://www.xamarin.com/forms)

### Open Source

[.NET Core](https://github.com/dotnet/core) is open source (MIT license) and was contributed to the [.NET Foundation](https://dotnetfoundation.org) by Microsoft in 2014. It is now one of the most active .NET Foundation projects. It can be freely adopted by individuals and companies, including for personal, academic or commercial purposes. Multiple companies use .NET Core as part of apps, tools, new platforms and hosting services. Some of these companies make significant contributions to .NET Core on GitHub and provide guidance on the product direction as part of the [.NET Foundation Technical Steering Group](https://dotnetfoundation.org/blog/tsg-welcome).

## Acquisition

.NET Core is distributed in two main ways, as packages on NuGet.org and as standalone distributions.

### Distributions

You can download .NET Core at the [.NET Core Getting Started](https://www.microsoft.com/net/core) page.

- The *Microsoft .NET Core* distribution includes the CoreCLR runtime, associated libraries, a console application host and the `dotnet` app launcher. It is described by the [`Microsoft.NETCore.App`](https://www.nuget.org/packages/Microsoft.NETCore.App) metapackage.
- The *Microsoft .NET Core SDK* distribution includes .NET Core and a set of tools for restoring NuGet packages and compiling and building apps. 

Typically, you will first install the .NET Core SDK to get started with .NET Core development. You may choose to install additional .NET Core (perhaps pre-release) builds.

### Packages

- [.NET Core Packages](packages.md) contain the .NET Core runtime and libraries (reference assemblies and implementations). For example, [System.Net.Http](https://www.nuget.org/packages/System.Net.Http/).
- [.NET Core Metapackages](packages.md) describe various layers and app-models by referencing the appropriate set of versioned library packages.

## Architecture

.NET Core is a cross-platform .NET implementation. The primary architectural concerns unique to .NET Core are related to providing platform-specific implementations for supported platforms.

### Environments

.NET Core is supported by Microsoft on Windows, macOS and Linux. On Linux, Microsoft primarily supports .NET Core running on Red Hat Enterprise Linux (RHEL) and Debian distribution families.

.NET Core currently supports X64 CPUs. On Windows, X86 is also supported. ARM64 and ARM32 are in progress.

The [.NET Core Roadmap](https://github.com/dotnet/core/blob/master/roadmap.md) provides more detailed information on workload and OS and CPU environment support and plans.

Other companies or groups may support .NET Core for other app types and environment.

### Designed for Adaptability

.NET Core has been built as a very similar but unique product relative to other .NET products. It has been designed to enable broad adaptability to new platforms, for new workloads and with new compiler toolchains. It has several OS and CPU ports in progress and may be ported to many more. An example is the [LLILC](https://github.com/dotnet/llilc) project, which is an early prototype of native compilation for .NET Core via the [LLVM](http://llvm.org/) compiler.

The product is broken into several pieces, enabling the various parts to be adapted to new platforms on different schedules. The runtime and platform-specific foundational libraries must be ported as a unit. Platform-agnostic libraries should work as-is on all platforms, by construction. There is a project bias to reducing platform-specific implementations to increase developer efficiency, preferring platform-neutral C# code whenever an algorithm or API can be implemented in-full or in-part that way.

People commonly ask how .NET Core is implemented in order to support multiple operating systems. They typically ask if there are separate implementations or if [conditional compilation](https://en.wikipedia.org/wiki/Conditional_compilation) is used. It's both, with a strong bias towards conditional compilation.

You can see in the chart below that the vast majority of [CoreFX](https://github.com/dotnet/corefx) is platform-neutral code that is shared across all platforms. Platform-neutral code can be implemented as a single portable assembly that is used on all platforms.

![CoreFX: Lines of Code per Platform](../images/corefx-platforms-loc.png)

Windows and Unix implementations are similar in size. Windows has a larger implementation since CoreFX implements some Windows-only features, such as [Microsoft.Win32.Registry](https://github.com/dotnet/corefx/tree/master/src/Microsoft.Win32.Registry) but does not yet implement any Unix-only concepts. You will also see that the majority of the Linux and macOS implementations are shared across a Unix implementation, while the Linux- and macOS-specific implementations are roughly similar in size.


There are a mix of platform-specific and platform-neutral libraries in .NET Core. You can see the pattern in a few examples:

- [CoreCLR](https://github.com/dotnet/coreclr) is platform-specific. It's built in C/C++, so is platform-specific by construction.
- [System.IO](https://github.com/dotnet/corefx/tree/master/src/System.IO) and [System.Security.Cryptography.Algorithms](https://github.com/dotnet/corefx/tree/master/src/System.Security.Cryptography.Algorithms) are platform-specific, given that the storage and cryptography APIs differ significantly on each OS. 
- [System.Collections](https://github.com/dotnet/corefx/tree/master/src/System.Collections) and [System.Linq](https://github.com/dotnet/corefx/tree/master/src/System.Linq) are platform-neutral, given that they create and operate over data structures.

## Comparisons to other .NET implementations

It is perhaps easiest to understand the size and shape of .NET Core by comparing it to existing .NET implementations. 

### Comparison with .NET Framework

.NET was first announced by Microsoft in 2000 and then evolved from there. The .NET Framework has been the primary .NET implementation produced by Microsoft during that 15+ year span. 

The major differences between .NET Core and the .NET Framework: 

- **App-models** -- .NET Core does not support all the .NET Framework app-models, in part because many of them are built on Windows technologies, such as WPF (built on top of DirectX). The console and ASP.NET Core app-models are supported by both .NET Core and .NET Framework. 
- **APIs** -- .NET Core contains many of the same, but fewer, APIs as the .NET Framework, and with a different factoring (assembly names are different; type shape differs in key cases). These differences currently typically require changes to port source to .NET Core. .NET Core implements the [.NET Standard](../standard/net-standard.md) API, which will grow to include more of the .NET Framework BCL API over time.
- **Subsystems** -- .NET Core implements a subset of the subsystems in the .NET Framework, with the goal of a simpler implementation and programming model. For example, Code Access Security (CAS) is not supported, while reflection is supported.
- **Platforms** -- The .NET Framework supports Windows and Windows Server while .NET Core also supports macOS and Linux.
- **Open Source** -- .NET Core is open source, while a [read-only subset of the .NET Framework](https://github.com/microsoft/referencesource) is open source.

While .NET Core is unique and has significant differences to the .NET Framework and other .NET implementations, it is straightforward to share code, using either source or binary sharing techniques. 

### Comparison with Mono

[Mono](http://www.mono-project.com/) is the original cross-platform and [open source](https://github.com/mono/mono) .NET implementation, first shipping in 2004. It can be thought of as a community clone of the .NET Framework. The Mono project team relied on the open [.NET standards](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) (notably ECMA 335) published by Microsoft in order to provide a compatible implementation.

The major differences between .NET Core and Mono:

- **App-models** -- Mono supports a subset of the .NET Framework app-models (for example, Windows Forms) and some additional ones (for example, [Xamarin.iOS](https://www.xamarin.com/platform)) through the Xamarin product. .NET Core doesn't support these.
- **APIs** -- Mono supports a [large subset](http://docs.go-mono.com/?link=root%3a%2fclasslib) of the .NET Framework APIs, using the same assembly names and factoring.
- **Platforms** -- Mono supports many platforms and CPUs.
- **Open Source** -- Mono and .NET Core both use the MIT license and are .NET Foundation projects.
- **Focus** -- The primary focus of Mono in recent years is mobile platforms, while .NET Core is focused on cloud workloads.
