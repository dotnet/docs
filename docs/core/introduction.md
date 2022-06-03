---
title: .NET (and .NET Core) - introduction and overview
description: Learn about .NET (and .NET Core). .NET is a free, open-source development platform for building many kinds of apps.
author: tdykstra
ms.date: 02/24/2022
ms.custom: "updateeachrelease"
recommendations: false
---
# What is .NET? Introduction and overview

.NET is a free, cross-platform, open source developer platform for building applications. .NET is built on a [high-performance runtime](https://devblogs.microsoft.com/dotnet/category/performance/) that is used in production by many [high-scale apps](https://devblogs.microsoft.com/dotnet/category/developer-stories/).

You can [download .NET](https://dotnet.microsoft.com/download) and use it for building many types of apps.

**Cloud apps**

* [Web apps, web APIs, and microservices](/aspnet/core/introduction-to-aspnet-core#recommended-learning-path)
* [Serverless functions in the cloud](/azure/azure-functions/functions-create-first-function-vs-code?pivots=programming-language-csharp)
* [Cloud native apps](../architecture/cloud-native/index.md)

**Cross-platform client apps**

* [Mobile apps](https://dotnet.microsoft.com/apps/maui)
* [Games](https://dotnet.microsoft.com/apps/games)

**Other app types**

* [Console apps](tutorials/with-visual-studio-code.md)
* [Windows Desktop apps](https://dotnet.microsoft.com/apps/desktop)
  * [Windows WPF](/dotnet/desktop/wpf/)
  * [Windows Forms](/dotnet/desktop/winforms/)
  * [Universal Windows Platform (UWP)](/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)
* [Windows services](/aspnet/core/host-and-deploy/windows-service)
* [Machine learning](../machine-learning/index.yml)
* [Internet of Things (IoT)](../iot/index.yml)

## Features

.NET includes many features that enable developers to productively write reliable and performant code.

* [Asynchronous code](../csharp/programming-guide/concepts/async/index.md)
* [Attributes](../standard/attributes/index.md)
* [Delegates and lambdas](../standard/delegates-lambdas.md)
* [Events](../standard/events/index.md)
* [Exceptions](../standard/exceptions/index.md)
* [Garbage collection](../standard/automatic-memory-management.md)
* [Generic types](../standard/generics.md)
* [LINQ (Language Integrated Query)](../standard/linq/index.md).
* [Parallel programming](../standard/parallel-programming/index.md)
* [Type system](../standard/base-types/common-type-system.md)
* [Unsafe code](../csharp/language-reference/unsafe-code.md)

Compilers and other tools offer:

* [Code analyzers](../fundamentals/code-analysis/overview.md)
* [Source Link (source maps)](https://github.com/dotnet/sourcelink/blob/main/README.md)
* Type inference - [C#](../csharp/fundamentals/types/index.md#specifying-types-in-variable-declarations), [F#](../fsharp/language-reference/type-inference.md), [Visual Basic](../visual-basic/programming-guide/language-features/variables/local-type-inference.md).

## Using .NET

.NET apps and libraries are built from source code and a project file, using the .[NET CLI](tools/index.md) or an IDE like [Visual Studio](https://visualstudio.microsoft.com/).

The most minimal app looks like the following and can be built with a simple workflow.

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>
</Project>
```

Source:

```csharp
Console.WriteLine("Hello, World!");
```

The app can be built and run with the [.NET CLI](tools/index.md):

```bash
% dotnet run
Hello, World!
```

It can also be built and run as two separate steps (assuming an app called `app`):

```bash
% dotnet build
% ./bin/Debug/net6.0/app 
Hello, World!
```

## Free and open source

.NET is free, open source, and is a [.NET Foundation](https://dotnetfoundation.org/) [project](https://dotnetfoundation.org/projects/netcore/). .NET is maintained by Microsoft and the community on GitHub in [several repositories](https://github.com/dotnet/core/blob/main/Documentation/core-repos.md).

.NET source and and binaries are licensed with the [MIT license](https://github.com/dotnet/runtime/blob/main/LICENSE.TXT). Additional [licenses apply on Windows](https://github.com/dotnet/core/blob/main/license-information-windows.md) for binary distributions.

## Binary distributions

You can [download .NET](https://dotnet.microsoft.com/download/dotnet/6.0) for development or production scenarios:

* [.NET SDK](sdk.md) -- enables development and CI scenarios.
* [.NET Runtimes](https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime) -- required for framework-dependent apps for test or production deployment. For more information, see [Deployment models](#deployment-models) later in this article.


.NET is also distributed via [containers](https://hub.docker.com/_/microsoft-dotnet), [Linux package managers](install/linux.md), and the [Microsoft download site](https://dotnet.microsoft.com/download/).

## Support

.NET is [supported by Microsoft on multiple operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md). The .NET Team at Microsoft works collaboratively with other organizations to distribute and support .NET in various ways.

[Red Hat supports .NET](https://developers.redhat.com/topics/dotnet/) on Red Hat Enterprise Linux (RHEL).

.NET is [supported](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md) on Android, Apple, Linux, and Windows operating systems. It can be used on Arm64, x64, and x86 chips. It is also supported in emulated environments, like [macOS Rosetta 2](https://support.apple.com/HT211861).

.NET is [released annually](https://github.com/dotnet/core/blob/main/releases.md) in November, as either of two [release types](https://github.com/dotnet/core/blob/main/release-policies.md). .NET releases in odd-numbered years are Long-term Support (LTS) releases and are supported for three years. Releases in even-numbered years are Short-team Support (STS) releases and are supported for 18 months. All other aspects of the releases are the same, like quality level and breaking change policies.

## Runtime technology

The [Common Language Runtime (CLR)](../standard/clr.md) provides capabilities and services to apps that govern their function and also define their basic security and reliability behavior. The [fundamental features of the runtime](https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/botr/intro-to-clr.md) are:


* Garbage collection
* Memory safety and type safety
* High level support for programming languages
* Cross-platform design

.NET is sometimes called a "managed code" runtime. It is called *managed* primarily because it uses a garbage collector for memory management and because it enforces type and memory safety. The CLR is also called a *virtual machine*. It virtualizes (or abstracts) a variety of operating system and hardware concepts, such as memory, threads, and exceptions.

The CLR was designed to be a cross-platform runtime from its inception. It has been ported to multiple operating systems and chip architectures. Cross-platform .NET code typically does not need to be recompiled to run in new environments.

.NET apps are compiled to an [Intermediate Language (IL)](https://en.wikipedia.org/wiki/Common_Intermediate_Language). IL is a compact code format that can be supported on any operating system or chip hardware. Most .NET apps use APIs that are supported in multiple environments, requiring only the .NET runtime to run.

The CLR includes a Just-In-Time (JIT) compiler that compiles IL to native code at run time, targeting the underlying operating system and hardware. The JIT (called RyuJIT) can compile code at higher or lower levels of quality to enable better startup and steady-state throughput performance.

The CLR also offers some "native code" capabilities, primarily oriented on performance. Applications can be ahead-of-time compiled to avoid most of the cost of the JIT at runtime. The CLR offers low-level C-style interop functionality, via a combination of [P/Invoke](../standard/native-interop/index.md), value types, and the ability to [blit](../framework/interop/blittable-and-non-blittable-types) values across the native/managed-code boundary.

The CLR enables access to native memory and pointer arithmetic via [`unsafe` code](../csharp/language-reference/unsafe-code.md). These operations are needed for certain algorithms, system interoperability, or to implement the most efficient algorithm. Unsafe code might not execute the same way in different environments and also loses the benefits of the garbage collector and type safety. We recommend that you avoid unsafe code and centralize it as much as possible when it's used.

## Languages

The CLR is designed to support multiple programming languages. C#, F#, and Visual Basic languages are supported by Microsoft and are designed in collaboration with the community.

* [C#](../csharp/index.yml) is a modern, object-oriented, and type-safe programming language. It has its roots in the C family of languages and will be immediately familiar to C, C++, Java, and JavaScript programmers.

* [F#](../fsharp/index.yml) is an interoperable programming language for writing succinct, robust, and performant code. F# programming is data-oriented, where code involves transforming data with functions.
  
* [Visual Basic](../visual-basic/index.yml) uses a more verbose syntax that is closer to ordinary human language. It can be an easier language to learn for people new to programming.

## Runtime libraries

.NET has an expansive standard set of class libraries. These libraries provide implementations for many general-purpose and workload-specific types and utility functionality.

Here are some examples of types defined in the .NET runtime libraries:

* Every .NET type derives from the <xref:System.Object?displayProperty=fullName> type.
* Primitive value types, such as <xref:System.Boolean?displayProperty=nameWithType> and <xref:System.Int32?displayProperty=nameWithType>.
* Collections, such as <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> and <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>.
* Data types, such as <xref:System.Data.DataSet?displayProperty=nameWithType> and <xref:System.Data.DataTable?displayProperty=nameWithType>.
* Network utility types, such as <xref:System.Net.Http.HttpClient?displayProperty=nameWithType>.
* [File and stream I/O](../standard/io/index.md) utility types, such as <xref:System.IO.FileStream?displayProperty=nameWithType> and <xref:System.IO.TextWriter?displayProperty=nameWithType>.
* [Serialization](../standard/serialization/index.md) utility types, such as <xref:System.Text.Json.JsonSerializer?displayProperty=nameWithType> and <xref:System.Xml.Serialization.XmlSerializer?displayProperty=nameWithType>.
* High-performance types, such as <xref:System.Span%601?displayProperty=nameWithType>, <xref:System.Numerics.Vector?displayProperty=nameWithType>, and [Pipelines](../standard/io/pipelines.md).

For more information, see the [Runtime libraries overview](../standard/runtime-libraries-overview.md).

## NuGet Package Manager

[NuGet](/nuget/what-is-nuget) is the package manager for .NET. It enables developers to share compiled binaries with each other. [NuGet.org](https://www.nuget.org/) offers many [popular packages](https://www.nuget.org/stats/packages) from the community.

The following table lists NuGet packages from the .NET Team:

| NuGet package | Documentation |
|---------|---------|
| [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore) | [Entity Framework Core](/ef/core/) and [Database Providers](/ef/core/providers/) |
| [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) | [Application lifetime management (Generic Host)](extensions/generic-host.md) |
| [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) | [Dependency injection (DI)](extensions/dependency-injection.md)
| [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration) | [Configuration](extensions/configuration.md) |
| [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging) | [Logging](extensions/logging.md) |
| [Microsoft.Extensions.Options](https://www.nuget.org/packages/Microsoft.Extensions.Options) | [Options pattern](extensions/options.md) |

## Tools

The [.NET SDK](sdk.md) includes a set of [CLI](tools/index.md) tools, including the [MSBuild](/visualstudio/msbuild/msbuild) build engine, the [Roslyn](https://github.com/dotnet/roslyn) (C# and Visual Basic) compiler, and the [F#](https://github.com/microsoft/visualfsharp) compiler. Most commands are run by using the [`dotnet` command](tools/dotnet.md). The CLI tools can be used for local development and continuous integration.

The [Visual Studio](https://visualstudio.microsoft.com/) family of IDEs offer excellent support for .NET and the C#, F#, and Visual Basic languages.

[GitHub Codespaces](https://github.com/features/codespaces) and [GitHub security features](https://github.com/features/security) support .NET.

## Notebooks

.NET Interactive is a group of CLI tools and APIs that enable users to create interactive experiences across the web, markdown, and notebooks.

For more information, see the following resources:

* [.NET In-Browser Tutorial](https://dotnet.microsoft.com/learn/dotnet/in-browser-tutorial/1)
* [Using .NET notebooks with Jupyter on your machine](https://github.com/dotnet/interactive/blob/main/docs/NotebookswithJupyter.md)
* [.NET Interactive documentation](https://github.com/dotnet/interactive/blob/main/docs/README.md)

## CI/CD

MSBuild and the .NET CLI can be used with various continuous integration tools and environments, such as:

* [GitHub Actions](https://github.com/features/actions)
* [Azure DevOps](/azure/devops/user-guide/what-is-azure-devops)
* [CAKE for C#](https://cakebuild.net/)
* [FAKE for F#](https://fake.build/)

For more information, see [Using .NET SDK and tools in Continuous Integration (CI)](tools/using-ci-with-cli.md)

## Deployment models

.NET apps can be [published in two different modes](deploying/index.md):

* *Self-contained* apps include the .NET runtime and dependent libraries. They can be [single-file](deploying/single-file/overview) or multi-file. Users of the application can run it on a machine that doesn't have the .NET runtime installed. Self-contained apps always target a single operating system and chip configuration.
* *Framework-dependent* apps require a compatible version of the .NET runtime, typically installed globally. Framework-dependent apps can be published for a single operating system and chip configuration or as "portable," targeting all supported configurations.

.NET apps are launched with a native executable, by default. The executable is both operating system and chip-specific. Apps can also be launched with the [`dotnet` command](tools/dotnet.md).

Apps can be [deployed in containers](docker/introduction.md). Microsoft provides [container images](https://hub.docker.com/_/microsoft-dotnet) for a variety of target environments.

## History

In 2002, Microsoft released [.NET Framework](../framework/get-started/overview.md), a development platform for creating Windows apps. Today .NET Framework is at version 4.8 and remains [supported by Microsoft](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework).

In 2014, Microsoft introduced .NET Core as a cross-platform, open-source successor to .NET Framework. This new [implementation of .NET](../standard/glossary.md#implementation-of-net) kept the name .NET Core through version 3.1. The next version after .NET Core 3.1 was named .NET 5. New .NET versions continue to be released annually, with a growing set of features and supported scenarios.

## Next steps

* [Choose a .NET tutorial](tutorials/index.md)
* [Try .NET in your browser](../csharp/tour-of-csharp/tutorials/numbers-in-csharp.yml)
* [Take a tour of C#](../csharp/tour-of-csharp/index.md)
* [Take a tour of F#](../fsharp/tour.md)
