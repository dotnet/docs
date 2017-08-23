---
title: What's New in C# - C# Guide
description: How is the C# language evolving
keywords: C#, Latest Features, What's New, Roslyn
author: BillWagner
ms.author: wiwagn
ms.date: 03/21/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 77deec51-a14d-46d4-9bb3-faf449477149
---

# What's new in C# #

This page provides a roadmap of new features in each major release of
the C# language. The links below provide detailed information on the
major features added in each release.

> [!IMPORTANT]
> The C# language relies on types and methods in a *standard library* for some of the features. One example is exception processing. Every `throw` statement or expression is checked to ensure the object being thrown is derived from @System.Exception. Similarly, every `catch` is checked to ensure that the type being caught is derived from @System.Exception. Each version may add new requirements. To use the latest language features in older environments, you may need to install specific libraries. These are documented in the page for each specific version. You can learn more about the [relationships between language and library](relationships-between-language-and-library.md) for background on this dependency. 

* [C# 7](csharp-7.md):
    - This page describes the latest features in the C# language. This covers C# 7, currently available in [Visual Studio 2017](https://www.visualstudio.com/vs/whatsnew/).

* [C# 6](csharp-6.md):
    - This page describes the features that were added in C# 6. These features are available in Visual Studio 2015 for Windows developers, and on .NET Core 1.0 for developers exploring C# on macOS and Linux.

<!--* [C# Interactive](../interactive/index.md): 
    - This page describes C# Interactive, an interactive Read Eval Print Loop (REPL) that you can use to explore the C# language. You can use it to write code interactively and see it execute immediately, without any compile or build step.
-->
* [Cross Platform Support](../../core/index.md):
    - C#, through .NET Core support, runs on multiple platforms. If you are interested in trying C# on macOS, or on one of the many supported Linux distributions, learn more about .NET Core.

<!--
- [.NET Compiler Platform SDK](../roslyn/index.md):
    - The .NET Compiler Platform SDK enables you to write code that performs static analysis on C# code. You can use these APIs to find potential errors, or bad practices, suggest fixes, and even implement those fixes.
-->
  
## Previous Versions
The following lists key features that were introduced in previous versions of the C# language and Visual Studio .NET.  
  
 * Visual Studio .NET 2013: 
     - This version of Visual Studio included bug fixes, performance improvements, and technology previews of .NET Compiler Platform ("Roslyn") which became the .NET Compiler Platform SDK<!--Link to ../roslyn/index.md-->.

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
