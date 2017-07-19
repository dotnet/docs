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
---

# .NET Glossary

The primary goal of this glossary is to clarify meanings of selected terms and acronyms that appear frequently in the .NET documentation without definitions. Some of these terms are used inconsistently, so a secondary goal is to help reduce the confusion that inconsistent usage causes.

## AOT

Ahead-of-time compiler. Similar to JIT, this compiler also translates IL to machine code. In contrast to JIT compilation, AOT compilation happens before the application is executed and is usually performed on a different machine. AOT tool chains don't trade runtime for compile time and thus can spend more time optimizing. Since the context of AOT is the entire application, the AOT compiler can also perform cross-module linking and whole-program analysis, which means that all references are followed and a single executable is produced.

## ASP.NET 

The original ASP.NET implementation that ships with the .NET Framework.

See [ASP.NET](https://docs.microsoft.com/aspnet/#pivot=aspnet).

Sometimes ASP.NET is an umbrella term that refers to ASP.NET Core as well as the ASP.NET that ships with the .NET Framework. The meaning that the term carries in any given instance is determined by context. 

## ASP.NET Core

A cross-platform, high-performance, open source implementation of ASP.NET built on .NET Core.

See [ASP.NET Core](https://docs.microsoft.com/aspnet/#pivot=core).

## CLR

Common language runtime. The exact meaning depends on context, but this usually refers to the runtime of the .NET Framework and includes several components. The CLR is a virtual machine; that is, it includes the facilities to generate and compile code on-the-fly using a JIT compiler. The existing Microsoft CLR implementation is Windows only.

## CoreCLR

.NET Core common language runtime. This CLR is built from the same code base as the CLR. Originally, CoreCLR was the runtime of Silverlight and was designed to run on multiple platforms, specifically Windows and OS X. CoreCLR is now part of .NET Core and represents a simplified version of the CLR. It's still a cross platform runtime. CoreCLR is also a virtual machine with a JIT.

## CoreFX

.NET Core framework. Also known as the .NET Core Base Class Library (BCL). A set of  System.* (and to a limited extent  Microsoft.* ) libraries. The BCL is a general purpose, lower level set of functionality that higher-level application frameworks, such as ASP.NET Core, build on. The source code of the .NET Core library stack is contained in the CoreFX repository. However, the majority of the .NET Core APIs are also available in the .NET Framework, so you can think of CoreFX as a fork of the .NET Framework library stack.

## CoreRT

.NET Core runtime. In contrast to the CLR/CoreCLR, CoreRT is not a virtual machine, which means it doesn't include the facilities to generate and run code on-the-fly because it doesn't include a JIT. It does, however, include the GC and the ability for runtime type identification (RTTI) as well as reflection. However, its type system is designed so that metadata for reflection can be omitted. This enables having an AOT tool chain that can link away superfluous metadata and (more importantly) identify code that the application doesn't use. CoreRT is still in preview status.

## ecosystem

 All of the runtime software, development tools, and community resources that can be used to build and run applications for a given technology. The term ".NET ecosystem" differs from similar terms such as ".NET stack" in its inclusion of third-party apps and libraries.
Example: "The motivation behind the .NET Standard is establishing greater uniformity in the .NET ecosystem."

## framework

In general: a comprehensive library that facilitates development and deployment of applications that are based on a particular technology. In this general sense, ASP.NET Core and Windows Forms are examples of application frameworks.

See also the following terms, in which "framework" has a more specific technical meaning:
* [.NET Framework](#net-framework)
* [target framework](#target-framework)
* [TFM (target framework moniker)](#tfm)

Existing documentation sometimes use "framework" to refer to an [implementation of .NET](#implementation-of-net). For example, an article may call .NET Core a framework. We plan to eliminate this usage from the documentation, as it can be confusing.

## GC

Garbage collector. Garbage collection is an implementation of automatic memory management. .NET Framework and .NET Core currently use a generational garbage collector; that is, it groups objects into generations to limit the number of nodes it has to walk for determining which objects are alive. This speeds up collection times.

## IL

Intermediate language. Higher-level .NET languages, such as C#, compile down to a hardware-agnostic instruction set, which is called Intermediate Language (IL). IL is sometimes referred to as MSIL (Microsoft IL) or CIL (Common IL).

## JIT

Just-in-time compiler. This technology compiles IL to machine code that the processor understands. It's called JIT because compilation happens on demand and is performed on the same machine that the code needs to run on. Since JIT compilation occurs during execution of the application, compile time is part of the run time. Thus, JIT compilers have to trade spending more time optimizing code with the savings that the resulting code can produce. But a JIT knows the actual hardware and can free developers from having to ship different implementations. For instance, our vector library relies on the JIT to use the highest available SIMD instruction set.

## implementation of .NET

An implementation of .NET includes the following:

* One or more runtimes. Examples:  CLR, CoreCLR, CoreRT.
* A class library that implements a version of the .NET Standard, and optionally includes additional APIs. Examples: .NET Framework Base Class Library, .NET Core Base Class Library.
* Optionally, one or more application frameworks. Examples:  ASP.NET, Windows Forms, and WPF are included in the .NET Framework. ASP.NET Core is not a included in .NET Core.
* Optionally, development tools. Some development tools are shared among multiple implementations.

Examples of .NET implementations:

* .NET Core includes:
  * A JIT-based runtime (CoreCLR)
  * A class library that implements .NET Standard 2.0
  * An SDK that includes cross-platform CLI (command-line interface) tools
* Universal Windows Platform (UWP) includes:
  * A JIT-based runtime for debugging (CoreCLR)
  * An AOT-based runtime for retail (.NET Native)
  * A class library that implements .NET Standard 1.4

## library

 A collection of APIs that can be called by apps or other libraries. A .NET library includes both interfaces and implementations of the interfaces, for use with one or more target frameworks.

Because a library includes API implementations as well as specifications (interfaces), it is misleading to call .NET Standard a "library." We plan to eliminate that usage from the documentation, except in reference to the name of the .NET Standard metapackage.

## metapackage

A NuGet package that has no library of its own but is only a list of dependencies. The included packages can optionally establish the API for a target framework.

See [Packages, Metapackages and Frameworks](../core/packages.md)

## Mono

An open source alternative to the .NET Framework. Mono started around the same time the .NET Framework was first released. Since Microsoft didn't release Rotor as open source, Mono was forced to start from scratch and is thus a complete re-implementation of the .NET Framework with no shared code.

When .NET Core was released under the MIT license, Microsoft also released [large chunks of the .NET Framework under the MIT license](https://github.com/microsoft/referencesource) as well. This enabled the Mono community to use the same code the .NET Framework uses in order to close gaps and avoid behavioral differences.

Mono is primarily used to run .NET applications on Linux and Mac OS X (though to get into the Mac App Store you need [Xamarin](https://www.xamarin.com/). There are ports of Mono to other platforms; see [Mono's Supported Platforms](http://www.mono-project.com/docs/about-mono/supported-platforms/). Mono has implementations (though not necessarily complete) of WinForms, ASP.NET, and System.Drawing.

## .NET

The umbrella term for [.NET Standard](#net-standard) and all [.NET implementations](#implementation-of-net) and workloads. Always capitalized (never ".Net").

See the [.NET Guide](index.md)

## .NET Core 

A cross-platform, high-performance, open source implementation of .NET. Includes the Core Common Language Runtime (CoreCLR), the Core AOT Runtime (CoreRT, in preview), and the Core Base Class Library. .NET Core provides a lightweight development model and the flexibility to work with your favorite development tools on your favorite development platform.

See [.NET Core](../core/index.md).

## .NET Core CLI

A cross-platform toolchain for developing .NET Core applications.

See [.NET Core command-line interface (CLI) tools](../core/tools/index.md).

## .NET Core SDK

A set of libraries and tools that allow developers to create .NET Core applications and libraries. Includes the .NET Core CLI for building apps, .NET Core libraries and runtime for building and running apps, and the dotnet executable that runs CLI commands and runs applications.

See [.NET Core SDK Overview](../core/sdk.md).

## .NET Framework

The original implementation of .NET, which runs only on Windows. Includes the Common Language Runtime (CLR), the Base Class Library, and application framework libraries such as ASP.NET, Windows Forms, and WPF.

See [.NET Framework Guide](../framework/index.md).

## NET Native

.NET Native is a compiler tool chain that produces native code ahead-of-time (AOT), as opposed to just-in-time (JIT). The compilation can happen on the developer machine as well as on the store side, which allows blending AOT with the benefits of servicing. You can think of .NET Native as an evolution of NGEN (Native Image Generator). NGEN has several disadvantages:

* It runs the JIT up front, so the code quality and behavior is identical to the JITed version.
* It compiles on the user's machine, rather than the developer's machine. 
* It compiles at the module level, i.e. for each MSIL assembly there is a corresponding NGEN'ed assembly that contains the native code. 

.NET Native on the other hand is a C++ like compiler and linker. It removes unused code, spends more time optimizing it, and produces a single, merged module that represents the entire application.

UWP was the first application framework that was supported by .NET Native. We now also support building native console applications for Windows, macOS, and Linux.

## .NET Standard

A formal specification of .NET APIs that are intended to be available on all .NET runtimes.

See [.NET Standard](net-standard.md).

## NGEN

Native (image) generation. You can think of this technology as a persistent JIT compiler. It usually compiles code on the machine where the code will be executed, but compilation typically occurs at install time.

## package

For a package-based target framework: a NuGet package that contains an assembly of the same name. The package is a *.zip* file wih  a *.nupkg* extension that may contain assets (such as *.dll* files and *.xml* files) for use with multiple frameworks and versions. When installed in an app or library, the appropriate assets are selected based on the target framework specified by the app or library. The assets that define the interface are in the *ref* folder, and the assets that define the implementation are in the *lib* folder.

## platform

An operating system and the hardware it runs on. Examples: Windows, macOS, Linux, iOS, Android. Example usage in sentences:

* ".NET Core is a cross-platform implementation of .NET." 
* "PCL profiles represent Microsoft platforms while the .NET Standard is agnostic to platform."

The .NET documentation frequently uses ".NET platform" to mean either an implementation of .NET or the .NET stack including all implementations. Both of these usages tend to get confused with the primary (OS/hardware) meaning, so we plan to eliminate these usages from the documentation.

## runtime

The execution environment for a managed program. The OS is part of the runtime environment but is not part of the .NET runtime. Examples:

* Common Language Runtime (CLR)
* Core Common Language Runtime (CoreCLR)
* .NET Native (for UWP)
* Mono runtime

The .NET documentation frequently uses "runtime" to mean an implementation of .NET. We plan to eliminate this inconsistent usage. For example, in the following sentences "runtime" should be replaced with "implementation":

* "The various .NET runtimes implement specific versions of .NET Standard."
* "Libraries that are intended to run on multiple runtimes should target this framework." (referring to .NET Standard)
* "The various .NET runtimes implement specific versions of .NET Standard. … Each .NET runtime version advertises the highest .NET Standard version it supports …"

## stack

A set of programming technologies that are used together to build and run applications. "The .NET stack" refers to the .NET Standard and all .NET implementations. "A .NET stack" may refer to one implementation of .NET. 

## target framework

The collection of APIs that a .NET app or library relies on. An app or library can target a version of .NET Standard (for example, .NET Standard 2.0), which is specification for a standardized set of APIs across all .NET implementations. An app or library can also target a specific .NET implementation, in which case it gets access to implementation-specific APIs. For example, an app that targets Xamarin.iOS gets access to Xamarin-provided iOS API wrappers.

For some target frameworks (for example, the .NET Framework) the available APIs are defined by the assemblies that the framework installs on a system and may include app model APIs (for example, ASP.NET, Windows Forms). For package-based target frameworks (such as .NET Standard and .NET Core), the framework APIs are defined by the packages installed in the app or library. In that case the target framework implicitly specifies a metapackage that references all the packages that together make up the framework.

See [Target Frameworks](frameworks.md).

## TFM

Target framework moniker. A standardized token format for specifying the target framework of a .NET app or library. Target frameworks are typically referenced by a Compact TFM (short name, such as net462). Long form TFMs (such as .NETFramework,Version=4.6.2) exist but are not generally used to specify a target framework.

See [Target Frameworks](frameworks.md).

## UWP

Universal Windows Platform. An implementation of .NET that is used for building modern, touch-enabled Windows applications as well as headless devices for Internet of Things (IoT). It's designed to unify the different types of devices that you may want to target, including PCs, tablets, phablets, phones, and even the Xbox. UWP provides many services, such as a centralized app store, an execution environment (AppContainer), and a set of Windows APIs to use instead of Win32 (WinRT). Apps can be written in C++, C#, VB.NET, and JavaScript. When using C# and VB.NET the .NET APIs are provided by .NET Core.

## See also

[.NET Guide](index.md)  
[.NET Framework Guide](../framework/index.md)  
[.NET Core](../core/index.md)  
[ASP.NET Overview](https://docs.microsoft.com/aspnet/index#pivot=aspnet)  
[ASP.NET Core Overview](https://docs.microsoft.com/aspnet/index#pivot=core)  
