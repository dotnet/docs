---
title: .NET Glossary
description: Find out the meaning of selected terms used in the .NET documentation.
ms.date: 11/30/2021
author: tdykstra
ms.author: tdykstra
ms.topic: reference
---
# .NET Glossary

The primary goal of this glossary is to clarify meanings of selected terms and acronyms that appear frequently in the .NET documentation.

## AOT

Ahead-of-time compiler.

Similar to [JIT](#jit), this compiler also translates [IL](#il) to machine code. In contrast to JIT compilation, AOT compilation happens before the application is executed and is usually performed on a different machine. Because AOT tool chains don't compile at run time, they don't have to minimize time spent compiling. That means they can spend more time optimizing. Since the context of AOT is the entire application, the AOT compiler also performs cross-module linking and whole-program analysis, which means that all references are followed and a single executable is produced.

See [CoreRT](#corert) and [.NET Native](#net-native).

## app model

A [workload](#workload)-specific API. Here are some examples:

* ASP.NET
* ASP.NET Web API
* Entity Framework (EF)
* Windows Presentation Foundation (WPF)
* Windows Communication Foundation (WCF)
* Windows Workflow Foundation (WF)
* Windows Forms (WinForms)

## ASP.NET

The original ASP.NET implementation that ships with the .NET Framework, also known as ASP.NET 4.x.

Sometimes ASP.NET is an umbrella term that refers to both the original ASP.NET and ASP.NET Core. The meaning that the term carries in any given instance is determined by context. Refer to ASP.NET 4.x when you want to make it clear that you're not using ASP.NET to mean both implementations.

See [ASP.NET documentation](/aspnet/overview).

## ASP.NET Core

A cross-platform, high-performance, open-source implementation of ASP.NET.

See [ASP.NET Core documentation](/aspnet/core).

## assembly

A *.dll* or *.exe* file that can contain a collection of APIs that can be called by applications or other assemblies.

An assembly may include types such as interfaces, classes, structures, enumerations, and delegates. Assemblies in a project's *bin* folder are sometimes referred to as *binaries*. See also [library](#library).

## BCL

Base Class Library.

A set of libraries that comprise the System.\* (and to a limited extent Microsoft.\*) namespaces. The BCL is a general purpose, lower-level framework that higher-level application frameworks, such as ASP.NET Core, build on.

The source code of the BCL for [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions) is contained in the [.NET runtime repository](https://github.com/dotnet/runtime). Most of these BCL APIs are also available in .NET Framework, so you can think of this source code as a fork of the .NET Framework BCL source code.

The following terms often refer to the same collection of APIs that BCL refers to:

- [core .NET libraries](../core/compatibility/corefx.md)
- [framework libraries](#framework-libraries)
- [runtime libraries](#runtime)
- [shared framework](#shared-framework)

## CLR

Common Language Runtime.

The exact meaning depends on the context. Common Language Runtime usually refers to the runtime of [.NET Framework](#net-framework) or the runtime of [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions).

A CLR handles memory allocation and management. A CLR is also a virtual machine that not only executes apps but also generates and compiles code on-the-fly using a [JIT](#jit) compiler.

The CLR implementation for .NET Framework is Windows only.

The CLR implementation for .NET 5 and later versions (also known as the Core CLR) is built from the same code base as the .NET Framework CLR. Originally, the Core CLR was the runtime of Silverlight and was designed to run on multiple platforms, specifically Windows and OS X. It's still a [cross-platform](#cross-platform) runtime, now including support for many Linux distributions.

See also [runtime](#runtime).

## Core CLR

The Common Language Runtime for [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions).

See [CLR](#clr).

## CoreRT

In contrast to the [CLR](#clr), CoreRT is not a virtual machine, which means it doesn't include the facilities to generate and run code on-the-fly because it doesn't include a [JIT](#jit). It does, however, include the [GC](#gc) and the ability for run-time type identification (RTTI) and reflection. However, its type system is designed so that metadata for reflection isn't required. Not requiring metadata enables having an [AOT](#aot) tool chain that can link away superfluous metadata and (more importantly) identify code that the app doesn't use. CoreRT is in development.

See [Intro to CoreRT](https://github.com/dotnet/corert/blob/master/Documentation/intro-to-corert.md) and [.NET Runtime Lab](https://github.com/dotnet/runtimelab/blob/docs/README.md).

## cross-platform

The ability to develop and execute an application that can be used on multiple different operating systems, such as Linux, Windows, and iOS, without having to rewrite specifically for each one. This enables code reuse and consistency between applications on different platforms.

See [platform](#platform).

## ecosystem

All of the runtime software, development tools, and community resources that are used to build and run applications for a given technology.

The term ".NET ecosystem" differs from similar terms such as ".NET stack" in its inclusion of third-party apps and libraries. Here's an example in a sentence:

- "The motivation behind [.NET Standard](#net-standard) was to establish greater uniformity in the .NET ecosystem."

## framework

In general, a comprehensive collection of APIs that facilitates development and deployment of applications that are based on a particular technology. In this general sense, ASP.NET Core and Windows Forms are examples of application frameworks. The words framework and [library](#library) are often used synonymously.

The word "framework" has a different meaning in the following terms:

- [framework libraries](#framework-libraries)
- [.NET Framework](#net-framework)
- [shared framework](#shared-framework)
- [target framework](#target-framework)
- [TFM (target framework moniker)](#tfm)
- [framework-dependent app](../core/deploying/index.md#publish-framework-dependent)

Sometimes "framework" refers to an [implementation of .NET](#implementation-of-net). For example, an article may call .NET 5+ a framework.

## framework libraries

Meaning depends on context. May refer to the framework libraries for [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions), in which case it refers to the same libraries that [BCL](#bcl) refers to. It may also refer to the [ASP.NET Core](#aspnet-core) framework libraries, which build on the BCL and provide additional APIs for web apps.

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

An implementation of .NET includes:

- One or more runtimes. Examples: [CLR](#clr), [CoreRT](#corert).
- A class library that implements a version of .NET Standard and may include additional APIs. Examples: the [BCLs](#bcl) for [.NET Framework](#net-framework) and [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions).
- Optionally, one or more application frameworks. Examples: [ASP.NET](#aspnet), Windows Forms, and WPF are included in the .NET Framework and .NET 5+.
- Optionally, development tools. Some development tools are shared among multiple implementations.

Examples of .NET implementations:

- [.NET Framework](#net-framework)
- [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions)
- [Universal Windows Platform (UWP)](#uwp)
- [Mono](#mono)

## library

A collection of APIs that can be called by apps or other libraries. A .NET library is composed of one or more [assemblies](#assembly).

The words library and [framework](#framework) are often used synonymously.

## Mono

Mono is an open source, [cross-platform](#cross-platform) [.NET implementation](#implementation-of-net) that is mainly used when a small runtime is required. It is the runtime that powers Xamarin applications on Android, Mac, iOS, tvOS, and watchOS and is focused primarily on apps that require a small footprint.

It supports all of the currently published .NET Standard versions.

Historically, Mono implemented the larger API of the .NET Framework and emulated some of the most popular capabilities on Unix. It is sometimes used to run .NET applications that rely on those capabilities on Unix.

Mono is typically used with a [just-in-time compiler](#jit), but it also features a full [static compiler (ahead-of-time compilation)](#aot) that is used on platforms like iOS.

See the [Mono documentation](https://www.mono-project.com/docs/).

## .NET

* In general, *.NET* is the umbrella term for [.NET Standard](#net-standard) and all [.NET implementations](#implementation-of-net) and workloads.
* More specifically, .NET refers to the implementation of .NET that is recommended for all new development: [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions).

For example, the first meaning is intended in phrases such as "implementations of .NET" or "the .NET development platform." The second meaning is intended in names such as [.NET SDK](#net-sdk) and [.NET CLI](#net-cli).

.NET is always fully capitalized, never ".Net".

See [.NET documentation](../fundamentals/index.yml)

## .NET 5+

The plus sign after a version number means "and later versions." See [.NET 5 and later versions](#net-5-and-later-versions).

## .NET 5 and later versions

A cross-platform, high-performance, open-source implementation of .NET. Also referred to as .NET 5+. Includes a Common Language Runtime ([CLR](#clr)), an [AOT](#aot) runtime ([CoreRT](#corert), in development), a Base Class Library ([BCL](#bcl)), and the [.NET SDK](#net-sdk).

Earlier versions of this .NET implementation are known as [.NET Core](#net-core). .NET 5 is the next version following .NET Core 3.1. Version 4 was skipped to avoid confusing this newer implementation of .NET with the older implementation that is known as [.NET Framework](#net-framework). The current version of .NET Framework is 4.8.

See [.NET documentation](../fundamentals/index.yml).

## .NET CLI

A cross-platform toolchain for developing applications and libraries for [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions). Also known as the .NET Core CLI.

See [.NET CLI](../core/tools/index.md).

## .NET Core

See [.NET 5 and later versions](#net-5-and-later-versions).

## .NET Framework

An [implementation of .NET](#implementation-of-net) that runs only on Windows. Includes the Common Language Runtime ([CLR](#clr)), the Base Class Library ([BCL](#bcl)), and application framework libraries such as [ASP.NET](#aspnet), Windows Forms, and WPF.

See [.NET Framework Guide](../framework/index.yml).

## .NET Native

A compiler tool chain that produces native code ahead-of-time ([AOT](#aot)), as opposed to just-in-time ([JIT](#jit)).

Compilation happens on the developer's machine similar to the way a C++ compiler and linker works. It removes unused code and spends more time optimizing it. It extracts code from libraries and merges them into the executable. The result is a single module that represents the entire app.

UWP is the application framework supported by .NET Native.

See [.NET Native documentation](/windows/uwp/dotnet-native/).

## .NET SDK

A set of libraries and tools that allow developers to create .NET applications and libraries for [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions). Also known as the .NET Core SDK.

Includes the [.NET CLI](#net-cli) for building apps, .NET libraries and runtime for building and running apps, and the dotnet executable (*dotnet.exe*) that runs CLI commands and runs applications.

See [.NET SDK Overview](../core/sdk.md).

## .NET Standard

A formal specification of .NET APIs that are available in each [.NET implementation](#implementation-of-net).

The .NET Standard specification is sometimes called a library. Because a library includes API implementations, not only specifications (interfaces), it's misleading to call .NET Standard a "library."

See [.NET Standard](net-standard.md).

## NGEN

Native (image) generation.

You can think of this technology as a persistent [JIT](#jit) compiler. It usually compiles code on the machine where the code is executed, but compilation typically occurs at install time.

## package

A NuGet package&mdash;or just a package&mdash;is a *.zip* file with one or more assemblies of the same name along with additional metadata such as the author name.

The *.zip* file has a *.nupkg* extension and may contain assets, such as *.dll* files and *.xml* files, for use with multiple [target frameworks](#target-framework) and versions. When installed in an app or library, the appropriate assets are selected based on the target framework specified by the app or library. The assets that define the interface are in the *ref* folder, and the assets that define the implementation are in the *lib* folder.

## platform

An operating system and the hardware it runs on, such as Windows, macOS, Linux, iOS, and Android.

Here are examples of usage in sentences:

- ".NET Core is a cross-platform implementation of .NET."
- "PCL profiles represent Microsoft platforms, while .NET Standard is agnostic to platform."

Legacy .NET documentation sometimes uses ".NET platform" to mean either an [implementation of .NET](#implementation-of-net) or the .NET [stack](#stack) including all implementations. Both of these usages tend to get confused with the primary (OS/hardware) meaning, so we try to avoid these usages.

"Platform" has a different meaning in the phrase "developer platform," which refers to software that provides tools and libraries for building and running apps. .NET is a cross-platform, open-source developer platform for building many different types of applications.

## runtime

In general, the execution environment for a managed program. The OS is part of the runtime environment but is not part of the .NET runtime. Here are some examples of .NET runtimes in this sense of the word:

- Common Language Runtime ([CLR](#clr))
- .NET Native (for UWP)
- Mono runtime

The word "runtime" has a different meaning in some contexts:

* *.NET runtime* on the [.NET 5 download page](https://dotnet.microsoft.com/download/dotnet/5.0).

  You can download the *.NET runtime* or other runtimes, such as the *ASP.NET Core runtime*. A *runtime* in this usage is the set of components that must be installed on a machine to run a [framework-dependent](../core/deploying/index.md#publish-framework-dependent) app on the machine. The .NET runtime includes the [CLR](#clr) and the .NET [shared framework](#shared-framework), which provides the [BCL](#bcl).

* *.NET runtime libraries*

  Refers to the same libraries that [BCL](#bcl) refers to. However, other runtimes, such as the ASP.NET Core runtime, have different [shared frameworks](#shared-framework), with additional libraries that build on the BCL.

* [Runtime Identifier (RID)](../core/rid-catalog.md).

  *Runtime* here means the OS platform and CPU architecture that a .NET app runs on, for example: `linux-x64`.

* Sometimes "runtime" is used in the sense of an [implementation of .NET](#implementation-of-net), as in the following examples:

  - "The various .NET runtimes implement specific versions of .NET Standard. … Each .NET runtime version advertises the highest .NET Standard version it supports …"
  - "Libraries that are intended to run on multiple runtimes should target this framework." (referring to .NET Standard)

## shared framework

Meaning depends on context. The *.NET shared framework* refers to the libraries included in the [.NET runtime](#runtime). In this case, the *shared framework* for [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions) refers to the same libraries that [BCL](#bcl) refers to.

There are other shared frameworks. The *ASP.NET Core shared framework* refers to the libraries included in the [ASP.NET Core runtime](#runtime), which includes the BCL plus additional APIs for use by web apps.

For [framework-dependent apps](../core/deploying/index.md#publish-framework-dependent), the shared framework consists of libraries that are contained in assemblies installed in a folder on the machine that runs the app. For [self-contained apps](../core/deploying/index.md#publish-self-contained), the shared framework assemblies are included with the app.

For more information, see [Deep-dive into .NET Core primitives, part 2: the shared framework](https://natemcmaster.com/blog/2018/08/29/netcore-primitives-2/).

## stack

A set of programming technologies that are used together to build and run applications.

"The .NET stack" refers to .NET Standard and all .NET implementations. The phrase "a .NET stack" may refer to one implementation of .NET.

## target framework

The collection of APIs that a .NET app or library relies on.

An app or library can target a version of [.NET Standard](#net-standard) (for example, .NET Standard 2.0), which is a specification for a standardized set of APIs across all [.NET implementations](#implementation-of-net). An app or library can also target a version of a specific .NET implementation, in which case it gets access to implementation-specific APIs. For example, an app that targets Xamarin.iOS gets access to Xamarin-provided iOS API wrappers.

For some target frameworks (for example, [.NET Framework](#net-framework)) the available APIs are defined by the assemblies that a .NET implementation installs on a system, which may include application framework APIs (for example, ASP.NET, WinForms). For package-based target frameworks, the framework APIs are defined by the packages installed in the app or library.

See [Target Frameworks](frameworks.md).

## TFM

Target framework moniker.

A standardized token format for specifying the [target framework](#target-framework) of a .NET app or library. Target frameworks are typically referenced by a short name, such as `net462`. Long-form TFMs (such as .NETFramework,Version=4.6.2) exist but are not generally used to specify a target framework.

See [Target Frameworks](frameworks.md).

## UWP

Universal Windows Platform.

An [implementation of .NET](#implementation-of-net) that is used for building touch-enabled Windows applications and software for the Internet of Things (IoT). It's designed to unify the different types of devices that you may want to target, including PCs, tablets, phones, and even the Xbox. UWP provides many services, such as a centralized app store, an execution environment (AppContainer), and a set of Windows APIs to use instead of Win32 (WinRT). Apps can be written in C++, C#, Visual Basic, and JavaScript. When using C# and Visual Basic, the .NET APIs are provided by [.NET 5 (and .NET Core) and later versions](#net-5-and-later-versions).

## workload

A type of app someone is building. More generic than [app model](#app-model). For example, at the top of every .NET documentation page, including this one, is a drop-down list for **Workloads**, which lets you switch to documentation for **Web**, **Mobile**, **Cloud**, **Desktop**, and **Machine Learning \& Data**.

In some contexts, *workload* refers to a collection of Visual Studio features that you can choose to install to support a particular type of app. For an example, see [Select a workload](../core/install/windows.md#select-a-workload).

## See also

- [.NET fundamentals](../fundamentals/index.yml)
- [.NET Framework Guide](../framework/index.yml)
- [ASP.NET Overview](/aspnet/index#pivot=aspnet)
- [ASP.NET Core Overview](/aspnet/index#pivot=core)
