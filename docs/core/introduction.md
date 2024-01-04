---
title: .NET - introduction and overview
description: Learn about .NET (and .NET Core). .NET is a free, open-source development platform for building many kinds of apps.
ms.date: 11/15/2023
ms.custom: "updateeachrelease"
---
# What is .NET? Introduction and overview

.NET is a free, cross-platform, [open-source developer platform](https://github.com/dotnet/core) for building [many kinds of applications](apps.md). It can run programs written in [multiple languages](../fundamentals/languages.md), with [C#](../csharp/index.yml) being the most popular. It relies on a [high-performance](https://devblogs.microsoft.com/dotnet/category/performance/) runtime that is used in production by many [high-scale apps](https://devblogs.microsoft.com/dotnet/category/developer-stories/).

See [Getting started](./get-started.md) to learn how to [download](https://dotnet.microsoft.com/download/) and start writing your first app.

The .NET platform has been designed to deliver productivity, performance, security, and reliability. It provides automatic memory management via a [garbage collector (GC)](../standard/automatic-memory-management.md). It is type- and memory-safe, due to using a GC and strict language compilers. It offers [concurrency](../csharp/asynchronous-programming/index.md) via `async`/`await` and `Task` primitives. It includes a large set of libraries that have broad functionality and have been optimized for performance on multiple operating systems and chip architectures.

.NET has the following [design points](https://devblogs.microsoft.com/dotnet/why-dotnet/):

* **Productivity is full-stack** with runtime, libraries, language, and tools all contributing to developer user experience.
* **Safe code** is the primary compute model, while [unsafe code](../csharp/language-reference/unsafe-code.md) enables additional manual optimizations.
* **Static and dynamic code** are both supported, enabling a broad set of distinct scenarios.
* **Native code interop and hardware intrinsics** are low cost and high-fidelity (raw API and instruction access).
* **Code is portable across platforms** (OS, chip architecture), while platform targeting enables specialization and optimization.
* **Adaptability across programming domains** (cloud, client, gaming) is enabled with specialized implementations of the general-purpose programming model.
* **Industry standards** like OpenTelemetry and gRPC are favored over bespoke solutions.

.NET is maintained by Microsoft and the community. It is regularly updated to ensure users deploy secure and reliable applications to production.

## Overview

.NET includes the following components:

- Runtime -- executes application code.
- Libraries -- provides utility functionality like [JSON parsing](../standard/serialization/system-text-json/overview.md).
- Compiler -- compiles C# (and other languages) source code into (runtime) executable code.
- SDK and other tools -- enable building and monitoring apps with modern workflows.
- App stacks -- like ASP.NET Core and Windows Forms, that enable writing apps.

The runtime, libraries, and languages are the pillars of the .NET stack. Higher-level components, like .NET tools and app stacks like ASP.NET Core, build on top of these pillars. C# is the primary programming language for .NET and much of .NET is written in C#.

C# is object-oriented and the runtime supports object orientation. C# requires garbage collection and the runtime provides a tracing garbage collector. The libraries (and also the app stacks) shape those capabilities into concepts and object models that enable developers to productively write algorithms in intuitive workflows.

The core libraries expose thousands of types, many of which integrate with and fuel the C# language. For example, C#’s `foreach` enables enumerating arbitrary collections, with pattern-based optimizations that enable collections like `List<T>` to be processed simply and efficiently. Resource management may be left up to garbage collection, but prompt cleanup is possible via `IDisposable` and direct language support in `using`.

Support for doing multiple things at the same time is fundamental to practically all workloads, whether it be client applications doing background processing while keeping the UI responsive, services handling many thousands of simultaneous requests, devices responding to a multitude of simultaneous stimuli, or high-powered machines parallelizing the processing of compute-intensive operations. Asynchronous programming support is a first-class feature of the C# programming language, which provides the `async` and `await` keywords that make it easy to write and compose asynchronous operations while still enjoying the full benefits of all the control flow constructs the language has to offer.

The [type system](../standard/base-types/common-type-system.md) offers significant breadth, catering somewhat equally to safety, descriptiveness, dynamism, and native interop. First and foremost, the type system enables an object-oriented programming model. It includes types, (single base class) inheritance, interfaces (including default method implementations), and virtual method dispatch to provide a sensible behavior for all the type layering that object orientation allows. [Generic types](../standard/generics.md) are a pervasive feature that allow specializing classes to one or more types.

The .NET runtime provides automatic memory management via a garbage collector. For any language, its memory management model is likely its most defining characteristic. This is true for .NET languages. .NET has a self-tuning, tracing GC. It aims to deliver “hands off” operation in the general case while offering configuration options for more extreme workloads. The GC is the result of many years of investment, improving and learning from many kinds of workloads.

Value types and stack-allocated memory blocks offer more direct, low-level control over data and native platform interop, in contrast to .NET’s GC-managed types. Most of the primitive types in .NET, like integer types, are value types, and users can define their own types with similar semantics. Value types are fully supported through .NET’s generics system, meaning that generic types like `List<T>` can provide flat, no-overhead memory representations of value type collections.

[Reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/) is a “programs as data” paradigm, allowing one part of a program to dynamically query and/or invoke another, in terms of assemblies, types and members. It is particularly useful for late-bound programming models and tools.

Exceptions are the primary error handling model in .NET. Exceptions have the benefit that error information does not need to be represented in method signatures or handled by every method. Proper exception handling is essential for application reliability. Expected exceptions can be intentionally handled in user code, otherwise an app will crash. A crashed app is more reliable and diagnosable than an app with undefined behavior.

App stacks, like ASP.NET Core and Windows Forms, build on and take advantage of low-level libraries, language, and runtime. The app stacks define the way that apps are constructed and their lifecycle of execution.

The SDK and other tools enable a modern developer experience, both on a developer desktop and for Continuous Integration (CI). This includes being able to build, analyze, and test code. .NET projects can often be built by a single `dotnet build` command, which orchestrates restoring NuGet packages and building dependencies.

NuGet is the package manager for .NET. It contains hundreds of thousands of packages that implement functionality for many scenarios. The majority of apps rely on NuGet packages for some functionality. The [NuGet Gallery](https://nuget.org/) is maintained by Microsoft.

## Free and open source

.NET is free, open source, and is a [.NET Foundation](https://dotnetfoundation.org/) project. .NET is maintained by Microsoft and the community on GitHub in [several repositories](https://github.com/dotnet/core/blob/main/Documentation/core-repos.md).

.NET source and binaries are licensed with the [MIT license](https://github.com/dotnet/runtime/blob/main/LICENSE.TXT). Additional [licenses apply on Windows](https://github.com/dotnet/core/blob/main/license-information-windows.md).

## Support

[Microsoft supports .NET](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md) on Android, Apple, Linux, and Windows operating systems. It can be used on Arm64, x64, and x86 architectures. It's also supported in emulated environments, like [macOS Rosetta 2](https://support.apple.com/HT211861).

New versions of .NET are released annually in November. .NET releases in odd-numbered years are Long-Term Support (LTS) releases and are supported for three years. Releases in even-numbered years are Standard-Term Support (STS) releases and are supported for 18 months. The quality level, breaking change policies, and all other aspects of the releases are the same. For more information, see [Releases and support](releases-and-support.md).

The .NET Team at Microsoft works collaboratively with other organizations to distribute and support .NET in various ways.

[Red Hat supports .NET](https://developers.redhat.com/topics/dotnet/) on Red Hat Enterprise Linux (RHEL).

[Samsung supports .NET](https://developer.tizen.org/development/training/.net-application) on Tizen platforms.

## .NET ecosystem

There are multiple variants of .NET, each supporting a different type of app. The reason for multiple variants is part historical, part technical.

.NET implementations:

* **.NET Framework** -- The original .NET. It provides access to the broad capabilities of Windows and Windows Server. It is actively supported, in maintainenance.
* **Mono** -- The original community and open source .NET. A cross-platform implementation of .NET Framework. Actively supported for Android, iOS, and WebAssembly.
* **.NET (Core)** -- Modern .NET. A cross-platform and open source implementation of .NET, rethought for the cloud age while remaining significantly compatible with .NET Framework. Actively supported for Linux, macOS, and Windows.

## Next steps

* [Choose a .NET tutorial](tutorials/index.md)
* [Try .NET in your browser](../csharp/tour-of-csharp/tutorials/numbers-in-csharp.yml)
* [Take a tour of C#](../csharp/tour-of-csharp/index.md)
* [Take a tour of F#](../fsharp/tour.md)
