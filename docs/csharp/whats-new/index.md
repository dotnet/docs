---
title: What's New in C# - C# Guide
description: How is the C# language evolving
ms.date: 11/13/2017
ms.assetid: 77deec51-a14d-46d4-9bb3-faf449477149
---

# What's new in C# #

This page provides a roadmap of new features in each major release of
the C# language. The linked articles detail information on the
major features added in each release. You will find information on new features that have been released, either in a general release, or in a public preview. Detailed language feature status, including features considered for upcoming releases can be found [on the dotnet/roslyn repository](https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md) on GitHub.

> [!IMPORTANT]
> The C# language relies on types and methods in a *standard library* for some of the features. One example is exception processing. Every `throw` statement or expression is checked to ensure the object being thrown is derived from <xref:System.Exception>. Similarly, every `catch` is checked to ensure that the type being caught is derived from <xref:System.Exception>. Each version may add new requirements. To use the latest language features in older environments, you may need to install specific libraries. These dependencies are documented in the page for each specific version. You can learn more about the [relationships between language and library](relationships-between-language-and-library.md) for background on this dependency. 

To use the latest features in a point release, you need to [configure the compiler language version](../language-reference/configure-language-version.md) and select the version.

* [C# 7.3](csharp-7-3.md):
  - This page describes the latest features in the C# language. C# 7.3 is currently available in [Visual Studio 2017 version 15.7](https://visualstudio.microsoft.com/vs/whatsnew/), and in the [.NET Core 2.1 SDK 2.1.300 RC1](../../core/whats-new/index.md).
* [C# 7.2](csharp-7-2.md):
  - This page describes the features added in the C# language. C# 7.2 is currently available in [Visual Studio 2017 version 15.5](https://visualstudio.microsoft.com/vs/whatsnew/), and in the [.NET Core 2.0 SDK](../../core/whats-new/index.md).
* [C# 7.1](csharp-7-1.md):
  - This page describes the features added in C# 7.1. These features were added in [Visual Studio 2017 version 15.3](https://visualstudio.microsoft.com/vs/whatsnew/), and in the [.NET Core 2.0 SDK](../../core/whats-new/index.md).
* [C# 7.0](csharp-7.md):
  - This page describes the features added in C# 7.0. These features were added in [Visual Studio 2017](https://visualstudio.microsoft.com/vs/whatsnew/) and [.NET Core 1.0](../../core/whats-new/index.md) and later
* [C# 6](csharp-6.md):
  - This page describes the features that were added in C# 6. These features are available in Visual Studio 2015 for Windows developers, and on .NET Core 1.0 for developers exploring C# on macOS and Linux.
* [Cross Platform Support](../../core/index.md):
  - C#, through .NET Core support, runs on multiple platforms. If you are interested in trying C# on macOS, or on one of the many supported Linux distributions, learn more about .NET Core.
* [.NET Compiler Platform SDK](../roslyn-sdk/index.md):
  - The .NET Compiler Platform SDK enables you to write code that performs static analysis on C# code. You can use these APIs to find potential errors, or bad practices, suggest fixes, and even implement those fixes.

## Previous Versions

The following lists key features that were introduced in previous versions of the C# language and Visual Studio .NET.

* Visual Studio .NET 2013:
  - This version of Visual Studio included bug fixes, performance improvements, and technology previews of .NET Compiler Platform ("Roslyn") which became the [.NET Compiler Platform SDK](../roslyn-sdk/index.md).
* C# 5, Visual Studio .NET 2012:
  - `Async` / `await`, and [caller information](../programming-guide/concepts/caller-information.md) attributes.
* C# 4, Visual Studio .NET 2010:
  - `Dynamic`, [named arguments](../programming-guide/classes-and-structs/named-and-optional-arguments.md), optional parameters, and generic [covariance and contra variance](../programming-guide/concepts/covariance-contravariance/index.md).
* C# 3, Visual Studio .NET 2008:
  - Object and collection initializers, lambda expressions, extension methods, anonymous types, automatic properties, local `var` type inference, and [Language Integrated Query (LINQ)](../programming-guide/concepts/linq/index.md).
* C# 2, Visual Studio .NET 2005:
  - Anonymous methods, generics, nullable types, iterators/yield, `static` classes, and covariance and contra variance for delegates.
* C# 1.1, Visual Studio .NET 2003:
  - `#line` pragma and xml doc comments.
* C# 1, Visual Studio .NET 2002:
  - The first release of [C#](../csharp.md).
