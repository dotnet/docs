.NET Core
=========

.NET Core is a general purpose development platform developed by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core). It is cross-platform, supports Windows, OS X and Linux and intends to support a wide variety of CPUs and OSes over time. It can be used in device, cloud and embedded/IoT scenarios. We expect it to be extended to support additional scenarios over time (e.g. WebAssembly), both by Microsoft and the community.

.NET Core is composed of a few parts:

- A [.NET runtime](https://github.com/dotnet/coreclr) that can be used for a wide variety of app types
- A set of [framework libraries]((https://github.com/dotnet/corefx)). 
- A set of tools and compilers that enable the base developer experience, available in the [.NET Core SDK]((https://github.com/dotnet/cli)).

The C#, F# and VB compilers all support targeting and running on .NET Core. .NET Core tools are integrated into severals text editors and IDEs, including Visual Studio, Visual Studio Code, Sublime Text and Vim, providing .NET Core development experiences in your favorite environment. 

.NET Core is open source and was contributed to the [.NET Foundation](http://dotnetfoundation.org) by Microsoft in 2014 and is now one of the most active .NET Foundation projects. It can be freely adopted by individuals and companies, including for personal, academic or commercial purposes. Multiple companies are using .NET Core as part of apps, tools, new platforms and hosting services. Some of these companies make significant contributions to .NET Core on GitHub and provide guidance on the product direction as part of the [.NET Foundation Technical Steering Group](http://www.dotnetfoundation.org/blog/tsg-welcome).

.NET Core v1 supports the following workloads and app-models:

- Class Libraries
- Console apps
- ASP.NET Core websites and services
- UWP Windows 10 apps

You can get started with .NET Core in just a few minutes:

- [Getting started with .NET Core](https://aka.ms/dotnetcoregs)
- [.NET Core samples](https://github.com/dotnet/core)
- [.NET Core OS and CPU Support](link)
- [Explore .NET Core repos](https://github.com/dotnet/core)

Composition of .NET Core
------------------------

**.NET Core is the following:**

- **A set of packages** -- These contain the runtime and the API shape and implementation of .NET Core.
- **A set of metapackages (e.g. .NET Standard Library)** --  They describe various layers of .NET Core by referencing the appropriate set of library packages.
- **A [distribution](https://aka.ms/dotnetcoregs) of .NET Core from Microsoft** -- This includes the CoreCLR runtime, associated libraries, the console application host and the `dotnet` launcher. It is described by the Microsoft.NETCore.App metapackage.
- **A [distribution](https://dotnet.github.io) of the .NET Core SDK from Microsoft** -- This includes a set of tools for restoring NuGet packages and compiling and building apps, also controlled from the `dotnet` launcher. It is extensible, enabling anyone to add commands. The package also includes a copy of .NET Core to use with the tools. Typically, developers will install this distribution.

**Closely affiliated with .NET Core:**

- **The ".NET Standard Library"** - This is the API spec that describes the API evolution of .NET and that .NET Core implements. While many of the additions to the Standard Library will come from API additions to .NET Core, some will come from other platforms, such as the .NET Framework and Mono.
- **System.* packages** - These packages provide the ".NET Core" implementation but contain assets for other platforms, such as the .NET Framework and Mono.

Designed for Adaptibility
-------------------------

.NET Core has been built as a very similar but unique product relative to other .NET products from Microsoft. The primary reason to make changes was to enable broad adaptibility, to new platforms, for new workloads and by new compiler toolchains. In particular, apps should only need to use and distribute the .NET Core libraries and subsystems that they actually depend on. This characteristic is particularly important where either storage space and/or wire cost (download time, data charges) are important. It should also be the case that they do not have to change their code to target a new workload of compiler toolchain. The architecture of .NET Core should enable those outcomes.

By comparison, The .NET Framework was built as a completely integrated product, providing end-to-end experiences across Windows, Visual Studio and even SQL Server. Most customers loved that level of integration, but it was difficult to produce meaningful subsets of it. For example, because of API factoring, some subsystems are always required (e.g. Object.GetType has a dependency on Reflection). With .NET Core, those hard API dependencies have been removed and the APIs redefined, to enable the goal of adaptibility.

Comparison with .NET Framework
------------------------------

The .NET platform was first announced by Microsoft in 2000 and then evolved from there, largely focused on the .NET Framework product. .NET Core conforms to the same [.NET standards](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) (notably ECMA 335), but is a separate product. 

There are three major differences: 

- **App-models** -- .NET Core does not support the .NET Framework app-models, in part because many of them are built on Windows technologies, such as WPF (built on top of DirectX). The console and ASP.NET Core app-models are supported by both .NET implementations. 
- **APIs** -- .NET Core contains many of the same APIs as the .NET Framework, but with a different factoring (assembly names are different; type shape differs in key cases). It also contains significantly fewer APIs. Some of these differences require source changes to port to .NET Core, while others do not.
- **Sub-systems** -- .NET Core implements a smaller set of subsystems than existing in the .NET Framework. For example, AppDomains are not supported, with the goal of a simpler implementation and programming model. 

While .NET Core is unique and has significant differences to the .NET Framework, it is straightforward to share code between them and other .NET platforms, using either source or binary sharing techniques. There are some differences that will exist for .NET Core v1 and that are on the backlog to resolve in a future release.
