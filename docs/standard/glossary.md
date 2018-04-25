---
title: .NET Glossary
description: Find out the meaning of selected terms used in the .NET documentation.
keywords: .NET glossary, .NET dictionary, .NET terminology, .NET platform, .NET framework, .NET runtime
author: tdykstra
ms.author: tdykstra
ms.date: 07/08/2017
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# .NET Glossary

The primary goal of this glossary is to clarify meanings of selected terms and acronyms that appear frequently in the .NET documentation without definitions.

## AOT

Ahead-of-time compiler.

Similar to [JIT](#jit), this compiler also translates [IL](#il) to machine code. In contrast to JIT compilation, AOT compilation happens before the application is executed and is usually performed on a different machine. Because AOT tool chains don't compile at runtime, they don't have to minimize time spent compiling. That means they can spend more time optimizing. Since the context of AOT is the entire application, the AOT compiler also performs cross-module linking and whole-program analysis, which means that all references are followed and a single executable is produced.

## ASP.NET 

The original ASP.NET implementation that ships with the .NET Framework.

Sometimes ASP.NET is an umbrella term that refers to both ASP.NET implementations including ASP.NET Core. The meaning that the term carries in any given instance is determined by context. Refer to ASP.NET 4.x when you want to make it clear that you’re not using ASP.NET to mean both implementations. 

See [ASP.NET documentation](/aspnet/#pivot=aspnet).

## ASP.NET Core

A cross-platform, high-performance, open source implementation of ASP.NET built on .NET Core.

See [ASP.NET Core documentation](/aspnet/#pivot=core).

## assembly

A *.dll*/*.exe* file that can contain a collection of APIs that can be called by apps or other assemblies.

An assembly may include types such as interfaces, classes, structures, enumerations, and delegates. Assemblies in a project's *bin* folder are sometimes referred to as *binaries*. See also [library](#library).

## CLR

Common Language Runtime.

The exact meaning depends on the context, but this usually refers to the runtime of the .NET Framework. The CLR handles memory allocation and management. The CLR is also a virtual machine that not only executes apps but also generates and compiles code on-the-fly using a JIT compiler. The current Microsoft CLR implementation is Windows only.

## CoreCLR

.NET Core Common Language Runtime.

This CLR is built from the same code base as the CLR. Originally, CoreCLR was the runtime of Silverlight and was designed to run on multiple platforms, specifically Windows and OS X. CoreCLR is now part of .NET Core and represents a simplified version of the CLR. It's still a cross platform runtime, now including support for many Linux distributions. CoreCLR is also a virtual machine with JIT and code execution capabilities.

## CoreFX

.NET Core Base Class Library (BCL)

A set of libraries that comprise the System.* (and to a limited extent  Microsoft.*) namespaces. The BCL is a general purpose, lower-level framework that higher-level application frameworks, such as ASP.NET Core, build on. The source code of the .NET Core BCL is contained in the [CoreFX repository](https://github.com/dotnet/corefx). However, the majority of the .NET Core APIs are also available in the .NET Framework, so you can think of CoreFX as a fork of the .NET Framework BCL.

## CoreRT

.NET Core runtime.

In contrast to the CLR/CoreCLR, CoreRT is not a virtual machine, which means it doesn't include the facilities to generate and run code on-the-fly because it doesn't include a [JIT](#jit). It does, however, include the [GC](#gc) and the ability for runtime type identification (RTTI) and reflection. However, its type system is designed so that metadata for reflection isn't required. This enables having an [AOT](#aot) tool chain that can link away superfluous metadata and (more importantly) identify code that the app doesn't use. CoreRT is in development.

See [Intro to .NET Native and CoreRT](https://github.com/dotnet/corert/blob/master/Documentation/intro-to-corert.md)

## ecosystem

All of the runtime software, development tools, and community resources that are used to build and run applications for a given technology.

The term ".NET ecosystem" differs from similar terms such as ".NET stack" in its inclusion of third-party apps and libraries. Here's an example in a sentence:

- "The motivation behind the [.NET Standard](#net-standard) is to establish greater uniformity in the .NET ecosystem." 

## framework

In general, a comprehensive collection of APIs that facilitates development and deployment of applications that are based on a particular technology. In this general sense, ASP.NET Core and Windows Forms are examples of application frameworks. See also [library](#library).

The word "framework" has a more specific technical meaning in the following terms:
* [.NET Framework](#net-framework)
* [target framework](#target-framework)
* [TFM (target framework moniker)](#tfm)

In the existing documentation, "framework" sometimes refers to an [implementation of .NET](#implementation-of-net). For example, an article may call .NET Core a framework. We plan to eliminate this confusing usage from the documentation.

## GC

Garbage collector.

The garbage collector is an implementation of automatic memory management.  The GC frees memory occupied by objects that are no longer in use. 

See [Garbage Collection](garbage-collection/index.md).

## IL

Intermediate language.

Higher-level .NET languages, such as C#, compile down to a hardware-agnostic instruction set, which is called Intermediate Language (IL). IL is sometimes referred to as MSIL (Microsoft IL) or CIL (Common IL).

## JIT

Just-in-time compiler.

Similar to [AOT](#aot), this compiler translates [IL](#il) to machine code that the processor understands. Unlike AOT, JIT compilation happens on demand and is performed on the same machine that the code needs to run on. Since JIT compilation occurs during execution of the application, compile time is part of the run time. Thus, JIT compilers have to balance time spent optimizing code against the savings that the resulting code can produce. But a JIT knows the actual hardware and can free developers from having to ship different implementations.

## implementation of .NET

An implementation of .NET includes the following:

- One or more runtimes. Examples: CLR, CoreCLR, CoreRT.
- A class library that implements a version of the .NET Standard and may include additional APIs. Examples: .NET Framework Base Class Library, .NET Core Base Class Library.
- Optionally, one or more application frameworks. Examples: ASP.NET, Windows Forms, and WPF are included in the .NET Framework.
- Optionally, development tools. Some development tools are shared among multiple implementations.

Examples of .NET implementations:

- [.NET Framework](#net-framework)
- [.NET Core](#net-core)
- [Universal Windows Platform (UWP)](#uwp)

## library

A collection of APIs that can be called by apps or other libraries. A .NET library is composed of one or more [assemblies](#assembly).

The words library and [framework](#framework) are often used synonymously.

## metapackage

A NuGet package that has no library of its own but is only a list of dependencies. The included packages can optionally establish the API for a target framework.

See [Packages, Metapackages and Frameworks](../core/packages.md)

## Mono

Mono is a .NET implementation that is mainly used when a small runtime is required. It is the runtime that powers Xamarin applications on Android, Mac, iOS, tvOS and watchOS and is focused primarily on apps that require a small footprint.

It supports all of the currently published .NET Standard versions.

Historically, Mono implemented the larger API of the .NET Framework and emulated some of the most popular capabilities on Unix. It is sometimes used to run .NET applications that rely on those capabilities on Unix.

Mono is typically used with a just-in-time compiler, but it also features a full static compiler (ahead-of-time compilation) that is used on platforms like iOS.

To learn more about Mono, see the [Mono documentation](https://www.mono-project.com/docs/).

## .NET

The umbrella term for [.NET Standard](#net-standard) and all [.NET implementations](#implementation-of-net) and workloads. Always capitalized, never ".Net".

See the [.NET Guide](index.md)

## .NET Core 

A cross-platform, high-performance, open source implementation of .NET. Includes the Core Common Language Runtime (CoreCLR), the Core AOT Runtime (CoreRT, in development), the Core Base Class Library, and the Core SDK.

See [.NET Core](../core/index.md).

## .NET Core CLI

A cross-platform toolchain for developing .NET Core applications.

See [.NET Core command-line interface (CLI) tools](../core/tools/index.md).

## .NET Core SDK

A set of libraries and tools that allow developers to create .NET Core applications and libraries. Includes the [.NET Core CLI](#net-core-cli) for building apps, .NET Core libraries and runtime for building and running apps, and the dotnet executable (*dotnet.exe*) that runs CLI commands and runs applications.

See [.NET Core SDK Overview](../core/sdk.md).

## .NET Framework

An implementation of .NET that runs only on Windows. Includes the Common Language Runtime (CLR), the Base Class Library, and application framework libraries such as ASP.NET, Windows Forms, and WPF.

See [.NET Framework Guide](../framework/index.md).

## .NET Native

A compiler tool chain that produces native code ahead-of-time (AOT), as opposed to just-in-time (JIT).

Compilation happens on the developer's machine similar to the way a C++ compiler and linker works. It removes unused code and spends more time optimizing it. It extracts code from libraries and merges them into the executable. The result is a single module that represents the entire app.

UWP was the first application framework supported by .NET Native. Now, we support building native console apps for Windows, macOS, and Linux.

See [Intro to .NET Native and CoreRT](https://github.com/dotnet/corert/blob/master/Documentation/intro-to-corert.md)

## .NET Standard

A formal specification of .NET APIs that are available in each .NET implementation.

The .NET Standard specification is sometimes called a library in the documentation. Because a library includes API implementations, not only specifications (interfaces), it's misleading to call .NET Standard a "library." We plan to eliminate that usage from the documentation, except in reference to the name of the .NET Standard metapackage (`NETStandard.Library`).

See [.NET Standard](net-standard.md).

## NGEN

Native (image) generation.

You can think of this technology as a persistent JIT compiler. It usually compiles code on the machine where the code is executed, but compilation typically occurs at install time.

## package

A NuGet package &mdash; or just a package &mdash; is a *.zip* file with one or more assemblies of the same name along with additional metadata such as the author name.

The *.zip* file has a *.nupkg* extension and may contain assets, such as *.dll* files and *.xml* files, for use with multiple target frameworks and versions. When installed in an app or library, the appropriate assets are selected based on the target framework specified by the app or library. The assets that define the interface are in the *ref* folder, and the assets that define the implementation are in the *lib* folder.

## platform

An operating system and the hardware it runs on, such as Windows, macOS, Linux, iOS, and Android.

Here are examples of usage in sentences:

- ".NET Core is a cross-platform implementation of .NET." 
- "PCL profiles represent Microsoft platforms, while the .NET Standard is agnostic to platform."

The .NET documentation frequently uses ".NET platform" to mean either an implementation of .NET or the .NET stack including all implementations. Both of these usages tend to get confused with the primary (OS/hardware) meaning, so we plan to eliminate these usages from the documentation.

## runtime

The execution environment for a managed program.

The OS is part of the runtime environment but is not part of the .NET runtime. Here are some examples of .NET runtimes:

- Common Language Runtime (CLR)
- Core Common Language Runtime (CoreCLR)
- .NET Native (for UWP)
- Mono runtime

The .NET documentation sometimes uses "runtime" to mean an implementation of .NET. For example, in the following sentences "runtime" should be replaced with "implementation":

- "The various .NET runtimes implement specific versions of .NET Standard."
- "Libraries that are intended to run on multiple runtimes should target this framework." (referring to .NET Standard)
- "The various .NET runtimes implement specific versions of .NET Standard. … Each .NET runtime version advertises the highest .NET Standard version it supports …"

We plan to eliminate this inconsistent usage. 

## stack

A set of programming technologies that are used together to build and run applications.

"The .NET stack" refers to the .NET Standard and all .NET implementations. The phrase "a .NET stack" may refer to one implementation of .NET. 

## target framework

The collection of APIs that a .NET app or library relies on.

An app or library can target a version of .NET Standard (for example, .NET Standard 2.0), which is specification for a standardized set of APIs across all .NET implementations. An app or library can also target a version of a specific .NET implementation, in which case it gets access to implementation-specific APIs. For example, an app that targets Xamarin.iOS gets access to Xamarin-provided iOS API wrappers.

For some target frameworks (for example, the .NET Framework) the available APIs are defined by the assemblies that a .NET implementation installs on a system, which may include application framework APIs (for example, ASP.NET, WinForms). For package-based target frameworks (such as .NET Standard and .NET Core), the framework APIs are defined by the packages installed in the app or library. In that case, the target framework implicitly specifies a metapackage that references all the packages that together make up the framework.

See [Target Frameworks](frameworks.md).

## TFM

Target framework moniker.

A standardized token format for specifying the target framework of a .NET app or library. Target frameworks are typically referenced by a short name, such as `net462`. Long-form TFMs (such as .NETFramework,Version=4.6.2) exist but are not generally used to specify a target framework.

See [Target Frameworks](frameworks.md).

## UWP

Universal Windows Platform.

An implementation of .NET that is used for building modern, touch-enabled Windows applications and software for the Internet of Things (IoT). It's designed to unify the different types of devices that you may want to target, including PCs, tablets, phablets, phones, and even the Xbox. UWP provides many services, such as a centralized app store, an execution environment (AppContainer), and a set of Windows APIs to use instead of Win32 (WinRT). Apps can be written in C++, C#, VB.NET, and JavaScript. When using C# and VB.NET, the .NET APIs are provided by .NET Core.

## See also

[.NET Guide](index.md)  
[.NET Framework Guide](../framework/index.md)  
[.NET Core](../core/index.md)  
[ASP.NET Overview](/aspnet/index#pivot=aspnet)  
[ASP.NET Core Overview](/aspnet/index#pivot=core)  

