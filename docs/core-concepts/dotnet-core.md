.NET Core
=========

.NET Core is a general purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core). It is cross-platform, supporting Windows, OS X and Linux and can be used in device, cloud and embedded/IoT scenarios. The supported Operating Systems (OS), CPUs and application scenarios will grow over time, provided by Microsoft, other companies and individuals.

The following characteritics best define .NET Core:

- **Flexible deployment:** app-local or side-by-side user- or machine-wide installation.
- **Cross-platform:** Runs on Windows, OS X and Linux; Can be ported to other OSes.
- **Compatibility:** .NET Core is compatible with .NET Framework and Xamarin platforms.
- **Open source:** The .NET Core platform is open source, using MIT and Apache 2 licenses.

Composition
===========

.NET Core is composed of a few parts:

- A [.NET runtime](https://github.com/dotnet/coreclr), which provides a type system, assembly loading, a garbage collector, native interop and other basic services. 
- A set of [framework libraries]((https://github.com/dotnet/corefx)), which provide primitive data types, app composition types and fundamental utilities. 
- The 'dotnet' app host, which is used to launched .NET Core apps. It selects the runtime and hosts the runtime, provides an assembly loading policy and launches the app. The same host is also used to launch SDK tools in much the same way.
- A [set of SDK tools](https://github.com/dotnet/cli) and language compilers that enable the base developer experience, available in the [.NET Core SDK](http://dotnet.github.io/docs/core-concepts/core-sdk).

Languages
---------

The C# languages (F# and VB are coming) can be used to write applications and libraries for .NET Core. The compilers run on .NET Core, enabling you to develop for .NET Core anywhere it runs. In general, you will not use the compilers directly, but indirectly by using the SDK tools.

The C# Roslyn compiler and the .NET Core tools have been integrated into several text editors and IDEs, including Visual Studio, Visual Studio Code, Sublime Text and Vim, making .NET Core development an option in your favorite coding environment and OS. This integration is provided, in part, by the good folks of the [OmniSharp project](http://www.omnisharp.net/).

.NET APIs and Compatibility
---------------------------

.NET Core can be thought of as a cross-platform version of the .NET Framework, at the layer of the .NET Framework Base Class Libraries (BCL). It provides a subset of the APIs that are available in the .NET Framework or Mono/Xamarin. In some cases, types have been subseted (some members are not available or have been moved).

The focus of .NET Core 1.0 has been "bringup" of the platform. Post .NET Core 1.0, there will be a focus on compatibility to make it easier to take advantage of .NET Core with existing .NET Framework and Mono codebases.

Relationship to the .NET Standard Library
-----------------------------------------

The [.NET Standard Library](../concepts/standard-library.md) is an API spec that describes the consistent set of .NET APIs that developers can expect in each .NET implementation. .NET implementations need to implement this spec in order to be considered .NET Standard Library compliant and to support libraries that target the .NET Standard Library. 

.NET Core implements the .NET Standard Library, and therefore supports .NET Standard Libraries.

Workloads
---------

.NET Core includes a single application model: console apps. That's useful for tools, local services and console games. Additional application models build on top of .NET Core, such as: 

- [ASP.NET Core](http://asp.net)
- [Windows 10 UWP](https://developer.microsoft.com/windows)
- [Xamarin.Forms](https://www.xamarin.com/forms)

Open Source
-----------

[.NET Core](https://github.com/dotnet/core) is open source (MIT license) and was contributed to the [.NET Foundation](http://dotnetfoundation.org) by Microsoft in 2014. It is now one of the most active .NET Foundation projects. It can be freely adopted by individuals and companies, including for personal, academic or commercial purposes. Multiple companies use .NET Core as part of apps, tools, new platforms and hosting services. Some of these companies make significant contributions to .NET Core on GitHub and provide guidance on the product direction as part of the [.NET Foundation Technical Steering Group](http://www.dotnetfoundation.org/blog/tsg-welcome).

Acquisition
===========

.NET Core is distributed in two main ways, as packages on NuGet.org and as standalone distributions.

Packages
--------

- [.NET Core Packages](packages.md) contain the .NET Core runtime and libraries (reference assemblies and implementations). For example, [System.Net.Http](https://www.nuget.org/packages/System.Net.Http/).
- [.NET Core Metapackages](packages.md) describe various layers and app-models by referencing the appropriate set of versioned library packages.

Distributions
-------------

You can download .NET Core at the [.NET Core Getting Started](https://www.microsoft.com/net/core) page.

- The *Microsoft .NET Core* distribution includes the CoreCLR runtime, associated libraries, a console application host and the `dotnet` app launcher. It is described by the [`Microsoft.NETCore.App`](https://www.nuget.org/packages/Microsoft.NETCore.App) metapackage.
- The *Microsoft .NET Core SDK* distribution includes .NET Core and a set of tools for restoring NuGet packages and compiling and building apps. 

Typically, you will first install the .NET Core SDK to get started with .NET Core development. You may choose to install additional .NET Core (perhaps pre-release) builds. The `dotnet new` command will 

Architecture
============

.NET Core is a cross-platform .NET implementation. The primary architectural concerns unique to .NET Core are related to providing platform-specific implementations for supported platforms.

Environments
------------

.NET Core is supported by Microsoft on Windows, OS X and Linux. On Linux, Microsoft primarily supports .NET Core running on Red Hat Enterprise Linux (RHEL) and Debian distribution families.

.NET Core currently supports X64 CPUs. On Windows, X86 is also supported. ARM64 and ARM32 are in progress.

The [.NET Core Roadmap](https://github.com/dotnet/core/blob/master/roadmap.md) provides more detailed information on workload and OS and CPU environment support and plans.

Other companies or groups may support .NET Core for other app types and environment.

Designed for Adaptability
-------------------------

.NET Core has been built as a very similar but unique product relative to other .NET products. It has been designed to enable broad adaptability, to new platforms, for new workloads and with new compiler toolchains. It has several OS and CPU ports in progress and may be ported to many more. Another example is the [LLILC](https://github.com/dotnet/llilc) project, which is an early prototype of native compilation for .NET Core via the [LLVM](http://llvm.org/) compiler.

The product is broken into several pieces, enabling the various parts to be adapted to new platforms on different schedules. The runtime and platform-specific foundational libraries must be ported as a unit. Platform-agnostic libraries should work as-is on all platforms, by construction. To a large degree, this split is what makes the .NET team efficient. The team invests in reducing platform-specific implementations, prefering platform-neutral C# code whenever an algorithm or API can be implemented in-full or in-part that way.

People commonly ask how .NET Core is implemented, in order to support multiple operating systems. They typically ask if there are separate implementations or if [conditional compilation](https://en.wikipedia.org/wiki/Conditional_compilation) is used. It's both, with a strong bias towards conditional compilation.

You can see in the chart below that the vast majority of [CoreFX](https://github.com/dotnet/corefx) is platform-neutral code that is shared across all platforms. Windows and unix implementations are similar in size. Windows has a larger implementation since CoreFX implements some Windows-only features, such as [Microsoft.Win32.Registry](https://github.com/dotnet/corefx/tree/master/src/Microsoft.Win32.Registry) and [System.Security.Principal.Windows](https://github.com/dotnet/corefx/tree/master/src/System.Security.Principal.Windows) but does not yet implement any unix-only concepts. You will also see that the majority of the Linux and OS X implementations are shared across a unix implementation, while the Linux- and OS X-specific implementations are roughly similar in size.

![CoreFX: Lines of Code per Platform](../corefx-platforms-loc.png)

There are a mix of platform-specific and platform-neutral libraries in .NET Core. You can see the pattern in a few examples:

- [CoreCLR](https://github.com/dotnet/coreclr) is platform-specific. It's built in C/C++, so is platform-specific by construction.
- [System.IO](https://github.com/dotnet/corefx/tree/master/src/System.IO)) and [System.Security.Cryptography.Algorithms](https://github.com/dotnet/corefx/tree/master/src/System.Security.Cryptography.Algorithms) are platform-specific, given that the storage and cryptography APIs differ significantly on each OS. 
- [System.Collections](https://github.com/dotnet/corefx/tree/master/src/System.Collections)) and [System.Linq](https://github.com/dotnet/corefx/tree/master/src/System.Linq)) are platform-neutral, given that they create and operate over data structures.

Comparisons to other .NET Platforms
===================================

It is perhaps easiest to understand the size and shape of .NET Core by comparing it to existing .NET platforms. 

Comparison with .NET Framework
------------------------------

The .NET platform was first announced by Microsoft in 2000 and then evolved from there. The .NET Framework has been the primary .NET product produced by Microsoft during that 15+ year span. 

The major differences between .NET Core and the .NET Framework: 

- **App-models** -- .NET Core does not support the .NET Framework app-models, in part because many of them are built on Windows technologies, such as WPF (built on top of DirectX). The console and ASP.NET Core app-models are supported by both .NET Core and .NET Framework. 
- **APIs** -- .NET Core contains many of the same, but fewer, APIs as the .NET Framework, and with a different factoring (assembly names are different; type shape differs in key cases). These differences currently typically require changes to port source to .NET Core. We intend to make the .NET Core API the same as the .NET Framework BCL API over time.
- **Subsystems** -- .NET Core implements a subset of the subsystems in the .NET Framework, with the goal of a simpler implementation and programming model. For example, Code Access Security is not supported, while  Reflection is supported.
- **Platforms** -- The .NET Framework supports Windows and Windows Server while .NET Core also supports OS X and Linux.
- **Open Source** -- .NET Core is open source, while a [read-only subset of the .NET Framework](https://github.com/microsoft/referencesource) is open source.

While .NET Core is unique and has significant differences to the .NET Framework and other .NET platforms, it is straightforward to share code, using either source or binary sharing techniques. 

Comparison with Mono
--------------------

[Mono](http://www.mono-project.com/) is the original cross-platform and open source .NET implementation, first shipping in 2004. It can be thought of as a community clone of the .NET Framework. The Mono project team relied on the open [.NET standards](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) (notably ECMA 335) published by Microsoft in order to provide a compatible implementation.

The major differences between .NET Core and Mono:

- **App-models** -- Mono supports a subset of the .NET Framework app-models (for example, Windows Forms) and some additional ones (for example, [Xamarin.iOS](https://www.xamarin.com/platform)) through the Xamarin product. .NET Core doesn't support these.
- **APIs** -- Mono supports a [large subset](http://docs.go-mono.com/?link=root%3a%2fclasslib) of the .NET Framework APIs, using the same assembly names and factoring. .NET Core will support this same subset over time.
- **Platforms** -- Mono supports many platforms and CPUs.
- **Open Source** -- Mono and .NET Core both use the MIT license and are .NET Foundation projects.
- **Focus** -- The primary focus of Mono in recent years is mobile platforms, while .NET Core is focussed on cloud workloads.
