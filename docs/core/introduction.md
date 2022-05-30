---
title: .NET (and .NET Core) - introduction and overview
description: Learn about .NET (and .NET Core). .NET is a free, open-source development platform for building many kinds of apps.
author: tdykstra
ms.date: 02/24/2022
ms.custom: "updateeachrelease"
recommendations: false
---
# What is .NET?

NET is a free, cross-platform, open source developer platform for building many different types of [applications](tutorials/with-visual-studio-code.md). .NET is built on a [high-performance runtime](https://devblogs.microsoft.com/dotnet/category/performance/) that is used in production by many [high-scale apps](https://devblogs.microsoft.com/dotnet/category/developer-stories/). It is built with the community on [GitHub](https://github.com/dotnet/core).

You can use .NET for client apps, for [desktop](/dotnet/desktop/), [mobile](/xamarin/), [web](aspnet/core/blazor), and [games](https://dotnet.microsoft.com/apps/games).

You can use .NET for [cloud apps](../architecture/cloud-native/index.md), [Web apps and APIs](/aspnet/core/introduction-to-aspnet-core#recommended-learning-path), and [serverless functions](/azure/azure-functions/functions-create-first-function-vs-code?pivots=programming-language-csharp). .NET cloud apps are competitively measured by the [techempower benchmark](https://www.techempower.com/benchmarks/#test=composite).

.NET can be used for many other apps, like [IoT](dotnet/iot/), [Tools](/dotnet/core/tools/global-tools), and [machine learning](../machine-learning/index.yml).

## Runtime technology

The .NET [Common Language Runtime (CLR)](../standard/clr.md) is a low-level, cross-platform runtime. The CLR provides type and memory safety, it handles memory allocation and garbage collection, creates and manages threads, and affords native API interoperability and many other functions.

.NET apps are compiled to a compact code format that can be supported on any operating system or chip hardware. Most .NET apps use APIs that are supported in multiple environments, requiring only the .NET runtime to run.

## Languages

The CLR is designed to support multiple programming languages. C#, F#, and Visual Basic are supported by Microsoft.

* [C#](../csharp/index.yml) is a modern, object-oriented, and type-safe programming language. It has its roots in the C family of languages and will be immediately familiar to C, C++, Java, and JavaScript programmers.

* [F#](../fsharp/index.yml) is an interoperable programming language for writing succinct, robust and performant code. F# programming is data-oriented, where code involves transforming data with functions.
  
* [Visual Basic](../visual-basic/index.yml) uses a more verbose syntax that is closer to ordinary human language. It can be an easier language to learn for people new to programming.

## Libraries and frameworks

.NET includes libraries and frameworks for many topics and app types. These affordances range from data structures like `string` and `Dictionary`, to utility functions like HTTP and RegEx, to app frameworks like Windows Forms and ASP.NET Core.

[NuGet](https://www.nuget.org/) is the package manager for .NET. It offers many [popular packages](https://www.nuget.org/stats/packages) from the community.

## Tools

The [.NET SDK](sdk.md) includes a set of [CLI](tools/index.md) tools, including the [MSBuild](/visualstudio/msbuild/msbuild) build engine, the [Roslyn](https://github.com/dotnet/roslyn) (C# and Visual Basic) compiler, and the [F#](https://github.com/microsoft/visualfsharp) language compiler. Most commands are run from `dotnet`. The CLI tools can be used for local development and continuous integration.

The [Visual Studio](https://visualstudio.microsoft.com/) family of IDEs offer excellent support for .NET and the C#, F#, and Visual Basic languages.

[GitHub Actions](https://github.com/features/actions), [GitHub Codespaces](https://github.com/features/codespaces), and [GitHub security features](https://github.com/features/security) support .NET.

## Open source

Microsoft is the maintainer of the open souce .NET project. Microsoft, other companies, and many individuals collaborate on [.NET on GitHub](https://github.com/dotnet/core).

.NET is a founding project of the [.NET Foundation](https://dotnetfoundation.org/), and is [licensed by the Foundation](https://github.com/dotnet/runtime/blob/main/LICENSE.TXT).

## Next steps

* [Choose a .NET tutorial](tutorials/index.md)
* [Try .NET in your browser](../csharp/tour-of-csharp/tutorials/numbers-in-csharp.yml)
* [Take a tour of C#](../csharp/tour-of-csharp/index.md)
* [Take a tour of F#](../fsharp/tour.md)
