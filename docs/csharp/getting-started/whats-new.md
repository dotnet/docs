---
title: "What's new for Visual C# | Microsoft Docs"
ms.date: "2017-03-27"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: 9f18dc26-27fa-4603-a639-b573f07a117b
caps.latest.revision: 39
author: "guardrex"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---

# What's new for Visual C#

This page lists key feature names for each version of C# with descriptions of the new and enhanced features in the lastest version of the language.

## Previous versions

| C# Version | Visual Studio Release   | Features |
| :--------: | ----------------------- | -------- |
| 1          | Visual Studio .NET 2002 | Initial release |
| 1.1        | Visual Studio .NET 2003 | `#line` pragma and xml doc comments |
| 2          | Visual Studio .NET 2005 | Anonymous methods, generics, nullable types, iterators/yield, `static` classes, co/contra variance for delegates |
| 3          | Visual Studio .NET 2008 | Object and collection initializers, lambda expressions, extension methods, anonymous types, automatic properties, Language Integrated Query (LINQ), anonymous types, local `var` type inference, LINQ |
| 4          | Visual Studio .NET 2010 | `Dynamic`, named arguments, optional parameters, generic co/contra variance |
| 5          | Visual Studio .NET 2012 | `Async`/`await`, caller information attributes |
|            | Visual Studio .NET 2013 | Performance improvements and technology previews of .NET Compiler Platform ("Roslyn") |
| 6          | Visual Studio .NET 2015 | `nameof`, string interpolation, null-conditional member access and indexing, index initializers, collection initializer and Add Extension methods, improved overload resolution, exception filters, `await` in `catch` and `finally` blocks, auto-property initializers, getter-only auto-properties, function members with expression bodies, `using static` | 
| 7          | Visual Studio .NET 2017 | See [Current version](#current-version) section |

## Current version

* [Task-like return types for async methods](https://github.com/dotnet/roslyn/issues/7169) introduces the ability to return any task-like type from an async method. Previously these return types were constrained to `Task<T>` and `Task`.

* [Value tuples](https://github.com/dotnet/roslyn/blob/master/docs/features/tuples.md) introduce language support for using tuples to temporarily group a set of typed values. To learn more, please review the [design notes](https://github.com/dotnet/roslyn/blob/master/docs/features/tuples.md) on GitHub.

* [Nested local functions](https://github.com/dotnet/roslyn/issues/259) extend the language to support declaration of functions in a block scope.

* [Pattern matching extensions](https://github.com/dotnet/roslyn/blob/master/docs/features/patterns.md) enable many of the benefits of algebraic data types and pattern matching from functional languages.

* [Ref returns](https://github.com/dotnet/roslyn/issues/118) enable functions to return values by reference.

## See also

* [What's New in Visual Studio 2017: Overview at visualstudio.com](https://www.visualstudio.com/vs/whatsnew/)
* [What's New in Visual Studio 2017](https://docs.microsoft.com/visualstudio/ide/whats-new-in-visual-studio)
* [Visual Studio 2017 Release Notes](https://www.visualstudio.com/news/releasenotes/vs2017-relnotes)
* [C# Language Design](https://github.com/dotnet/csharplang)
