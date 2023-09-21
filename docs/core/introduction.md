---
title: .NET (and .NET Core) - introduction and overview
description: Learn about .NET (and .NET Core). .NET is a free, open-source development platform for building many kinds of apps.
ms.date: 03/24/2023
ms.custom: "updateeachrelease"
recommendations: false
---
# What is .NET? Introduction and overview

[.NET is a free](https://dotnet.microsoft.com/download/), cross-platform, [open-source developer platform](https://github.com/dotnet/core) for building many kinds of applications. .NET is built on a [high-performance runtime](https://devblogs.microsoft.com/dotnet/category/performance/) that is used in production by many [high-scale apps](https://devblogs.microsoft.com/dotnet/category/developer-stories/).

**Cloud apps**

* [Cloud native apps](../architecture/cloud-native/index.md)
* [Console apps](tutorials/with-visual-studio-code.md)
* [Serverless functions in the cloud](/azure/azure-functions/functions-create-first-function-vs-code?pivots=programming-language-csharp)
* [Web apps, web APIs, and microservices](/aspnet/core/introduction-to-aspnet-core#recommended-learning-path)

**Cross-platform client apps**

* [Desktop apps](https://dotnet.microsoft.com/apps/desktop)
* [Games](https://dotnet.microsoft.com/apps/games)
* [Mobile apps](https://dotnet.microsoft.com/apps/maui)

**Windows apps**

* [Windows Desktop apps](https://dotnet.microsoft.com/apps/desktop)
  * [Windows Forms](/dotnet/desktop/winforms/)
  * [Windows WPF](/dotnet/desktop/wpf/)
  * [Universal Windows Platform (UWP)](/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)
* [Windows services](/aspnet/core/host-and-deploy/windows-service)

**Other app types**

* [Machine learning](../machine-learning/index.yml)
* [Internet of Things (IoT)](../iot/index.yml)

## Features

.NET features allow developers to productively write reliable and performant code.

* [Asynchronous code](../csharp/asynchronous-programming/index.md)
* [Attributes](../standard/attributes/index.md)
* [Reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/)
* [Code analyzers](../fundamentals/code-analysis/overview.md)
* [Delegates and lambdas](../standard/delegates-lambdas.md)
* [Events](../standard/events/index.md)
* [Exceptions](../standard/exceptions/index.md)
* [Garbage collection](../standard/automatic-memory-management.md)
* [Generic types](../standard/generics.md)
* [LINQ (Language Integrated Query)](../standard/linq/index.md).
* [Parallel programming](../standard/parallel-programming/index.md) and [Managed threading](../standard/threading/managed-threading-basics.md)
* Type inference - [C#](../csharp/fundamentals/types/index.md#specifying-types-in-variable-declarations), [F#](../fsharp/language-reference/type-inference.md), [Visual Basic](../visual-basic/programming-guide/language-features/variables/local-type-inference.md).
* [Type system](../standard/base-types/common-type-system.md)
* [Unsafe code](../csharp/language-reference/unsafe-code.md)

## Using .NET

.NET apps and libraries are built from source code and a project file, using the [.NET CLI](tools/index.md) or an Integrated Development Environment (IDE) like [Visual Studio](https://visualstudio.microsoft.com/).

The following example is a minimal .NET app:

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
  </PropertyGroup>
</Project>
```

Source code:

```csharp
Console.WriteLine("Hello, World!");
```

The app can be built and run with the [.NET CLI](tools/index.md):

```dotnetcli
dotnet run
Hello, World!
```

## Binary distributions

* [.NET SDK](sdk.md): Set of tools, libraries, and runtimes for development, building, and testing apps.
* [.NET Runtimes](https://dotnet.microsoft.com/download/dotnet): Set of runtimes and libraries, for running apps.

You can download .NET from:

* [The Microsoft download site](https://dotnet.microsoft.com/download).
* [Containers](https://mcr.microsoft.com/catalog?search=dotnet).
* [Linux package managers](install/linux.md).

## Free and open source

.NET is free, open source, and is a [.NET Foundation](https://dotnetfoundation.org/) project. .NET is maintained by Microsoft and the community on GitHub in [several repositories](https://github.com/dotnet/core/blob/main/Documentation/core-repos.md).

.NET source and binaries are licensed with the [MIT license](https://github.com/dotnet/runtime/blob/main/LICENSE.TXT). Additional [licenses apply on Windows](https://github.com/dotnet/core/blob/main/license-information-windows.md) for binary distributions.

## Support

[Microsoft supports .NET](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md) on Android, Apple, Linux, and Windows operating systems. It can be used on Arm64, x64, and x86 architectures. It's also supported in emulated environments, like [macOS Rosetta 2](https://support.apple.com/HT211861).

New versions of .NET are released annually in November. .NET releases in odd-numbered years are Long-Term Support (LTS) releases and are supported for three years. Releases in even-numbered years are Standard-Term Support (STS) releases and are supported for 18 months. The quality level, breaking change policies, and all other aspects of the releases are the same. For more information, see [Releases and support](releases-and-support.md).

The .NET Team at Microsoft works collaboratively with other organizations to distribute and support .NET in various ways.

[Red Hat supports .NET](https://developers.redhat.com/topics/dotnet/) on Red Hat Enterprise Linux (RHEL).

[Samsung supports .NET](https://developer.tizen.org/development/training/.net-application) on Tizen platforms.

## Runtime

The [Common Language Runtime (CLR)](../standard/clr.md) is the foundation all .NET apps are built on. The [fundamental features of the runtime](https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/botr/intro-to-clr.md) are:

* Garbage collection.
* Memory safety and type safety.
* High level support for programming languages.
* Cross-platform design.

.NET is sometimes called a "managed code" runtime. It's called *managed* primarily because it uses a garbage collector for memory management and because it enforces type and memory safety. The CLR virtualizes (or abstracts) various operating system and hardware concepts, such as memory, threads, and exceptions.

The CLR was designed to be a cross-platform runtime from its inception. It has been ported to multiple operating systems and architectures. Cross-platform .NET code typically does not need to be recompiled to run in new environments. Instead, you just need to install a different runtime to run your app.

The runtime exposes various [diagnostics](/dotnet/core/diagnostics/) services and APIs for debuggers, [dumps](diagnostics/dumps.md) and [tracing](diagnostics/logging-tracing.md) tools, and [observability](diagnostics/index.md#instrumentation-for-observability). The observability implementation is primarily [built around OpenTelemetry](https://devblogs.microsoft.com/dotnet/opentelemetry-net-reaches-v1-0/), enabling [flexible application monitoring](https://devblogs.microsoft.com/dotnet/announcing-dotnet-monitor-in-net-6/) and site reliability engineering (SRE).

The runtime offers low-level C-style interop functionality, via a combination of [P/Invoke](../standard/native-interop/index.md), value types, and the ability to [blit](../framework/interop/blittable-and-non-blittable-types.md) values across the native/managed-code boundary.

## Languages

The runtime is designed to support multiple programming languages. C#, F#, and Visual Basic languages are supported by Microsoft and are designed in collaboration with the community.

* [C#](../csharp/index.yml) is a modern, object-oriented, and type-safe programming language. It has its roots in the C family of languages and will be immediately familiar to C, C++, Java, and JavaScript programmers.

* [F#](../fsharp/index.yml) is an interoperable programming language for writing succinct, robust, and performant code. F# programming is data-oriented, where code involves transforming data with functions.

* [Visual Basic](../visual-basic/index.yml) uses a more verbose syntax that is closer to ordinary human language. It can be an easier language to learn for people new to programming.

## Compilation

.NET apps (as written in a high-level language like C#) are compiled into an [Intermediate Language (IL)](https://en.wikipedia.org/wiki/Common_Intermediate_Language). IL is a compact code format that can be supported on any operating system or architecture. Most .NET apps use APIs that are supported in multiple environments, requiring only the .NET runtime to run.

IL needs to be compiled to native code to execute on a CPU, for example, Arm64 or x64. .NET supports both Ahead-Of-Time (AOT) and Just-In-Time (JIT) compilation models.

* On Android, macOS, and Linux, JIT compilation is the default, and AOT is optional (for example, with [ReadyToRun](deploying/ready-to-run.md)).
* On [iOS](/xamarin/ios/), AOT is mandatory (except when running in the simulator).
* In WebAssembly (Wasm) environments, AOT is mandatory.

The advantage of the JIT is that it can compile an app (unmodified) to the CPU instructions and calling conventions in a given environment, per the underlying operating system and hardware. It can also compile code at higher or lower levels of quality to enable better startup and steady-state throughput performance.

The advantage of AOT is that it provides the best app startup and can (in some cases) result in smaller deployments. The primary downside is that binaries must be built for each separate deployment target (the same as any other native code). AOT code is not compatible with some reflection patterns.

## Runtime libraries

.NET has a comprehensive standard set of class libraries. These libraries provide implementations for many general-purpose and workload-specific types and utility functionality.

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

## Tools

The [.NET SDK](sdk.md) is a set of libraries and [tools](tools/index.md) for developing and running .NET applications. It includes the [MSBuild](/visualstudio/msbuild/msbuild) build engine, the [Roslyn](https://github.com/dotnet/roslyn) (C# and Visual Basic) compiler, and the [F#](https://github.com/microsoft/visualfsharp) compiler. Most commands are run by using the [`dotnet` command](tools/dotnet.md). The CLI tools can be used for local development and continuous integration.

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
* [GitHub Actions and .NET](../devops/github-actions-overview.md)
* [Azure DevOps](/azure/devops/user-guide/what-is-azure-devops)
* [CAKE for C#](https://cakebuild.net/)
* [FAKE for F#](https://fake.build/)

For more information, see [Use the .NET SDK in Continuous Integration (CI) environments](../devops/dotnet-cli-and-continuous-integration.md).

## Deployment models

.NET apps can be [published in two different modes](deploying/index.md):

* *Self-contained* apps include the .NET runtime and dependent libraries. They can be [single-file](deploying/single-file/overview.md) or multi-file. Users of the application can run it on a machine that doesn't have the .NET runtime installed. Self-contained apps always target a single operating system and architecture configuration.
* *Framework-dependent* apps require a compatible version of the .NET runtime, typically installed globally. Framework-dependent apps can be published for a single operating system and architecture configuration or as "portable," targeting all supported configurations.

.NET apps are launched with a native executable, by default. The executable is both operating-system and architecture-specific. Apps can also be launched with the [`dotnet` command](tools/dotnet.md).

Apps can be [deployed in containers](docker/introduction.md). Microsoft provides [container images](https://mcr.microsoft.com/catalog?search=dotnet) for various target environments.

## .NET history

In 2002, Microsoft released [.NET Framework](../framework/get-started/overview.md), a development platform for creating Windows apps. Today .NET Framework is at version 4.8 and remains [fully supported by Microsoft](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework).

In 2014, Microsoft introduced .NET Core as a cross-platform, open-source successor to .NET Framework. This new [implementation of .NET](../standard/glossary.md#implementation-of-net) kept the name .NET Core through version 3.1. The next version after .NET Core 3.1 was named .NET 5.

New .NET versions continue to be released annually, each a major version number higher. They include significant new features and often enable new scenarios.

## .NET ecosystem

There are multiple variants of .NET, each supporting a different type of app. The reason for multiple variants is part historical, part technical.

.NET implementations (historical order):

* **.NET Framework** -- It provides access to the broad capabilities of Windows and Windows Server. Also extensively used for Windows-based cloud computing. The original .NET.
* **Mono** -- A cross-platform implementation of .NET Framework. The original community and open source .NET. Used for Android, iOS, and Wasm apps.
* **.NET (Core)** -- A cross-platform and open source implementation of .NET, rethought for the cloud age while remaining significantly compatible with .NET Framework. Used for Linux, macOS, and Windows apps.

## Next steps

* [Choose a .NET tutorial](tutorials/index.md)
* [Try .NET in your browser](../csharp/tour-of-csharp/tutorials/numbers-in-csharp.yml)
* [Take a tour of C#](../csharp/tour-of-csharp/index.md)
* [Take a tour of F#](../fsharp/tour.md)
