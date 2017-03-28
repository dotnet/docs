---
title: "What's new for Visual Basic | Microsoft Docs"

ms.date: "2017-03-27"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "VB.StartPage.WhatsNew"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "new features, Visual Basic"
  - "what's new [Visual Basic]"
  - "Visual Basic, what's new"
ms.assetid: d7e97396-7f42-4873-a81c-4ebcc4b6ca02
caps.latest.revision: 145
author: "guardrex"
ms.author: "shoag"

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

# What's new for Visual Basic

This page lists key feature names for each version of Visual Basic with descriptions of the new and enhanced features in the lastest version of the language.

## Previous versions

| Visual Studio Release   | Features |
| ----------------------- | -------- |
| Visual Studio .NET 2002 | Initial release |
| Visual Studio .NET 2003 | Bit shift operators, loop variable declaration |
| Visual Studio .NET 2005 | `My` type and helper types (access to app, computer, files system, network |
| Visual Studio .NET 2008 | Language Integrated Query (LINQ), XML literals, local type inference, object initializers, anonymous types, extension methods, local `var` type inference, lambda expressions, `if` operator, partial methods, nullable value types |
| Visual Studio .NET 2010 | Auto-implemented properties, collection initializers, implicit line continuation, dynamic, generic co/contra variance, global namespace access |
| Visual Studio .NET 2012 | `Async`/`await`, iterators, caller info attributes |
| Visual Studio .NET 2013 | Performance improvements and technology previews of .NET Compiler Platform ("Roslyn") |
| Visual Studio .NET 2015 | `nameof`, string interpolation, null-conditional member access and indexing, multi-line string literals, comments features, smarter fully-qualified name resolution, year-first date literals, readonly interface properties, `TypeOf` use with `IsNot`, disable and enable specific warnings, XML doc comment improvements, partial module and interface definitions, region directives inside method bodies, overrides definitions are implicitly `Overloads`, CObj allowed in attribute arguments, declaring and consuming ambiguous methods from different interfaces |
| Visual Studio .NET 2017 | See [Current version](#current-version) section |

## Current version

* [Value tuples](https://github.com/dotnet/roslyn/issues/11370) introduce language support for using tuples to temporarily group a set of typed values: `Dim point As (x As Integer, y As Integer) = GetOffset()`.

* [ByRef return consumption](https://github.com/dotnet/roslyn/issues/11370) extend the language to support consumption of functions and properties from libraries which have ByRef returns.
Binary literals and digit group separators allow native representation of binary numbers. This is super convenient for bitmasks and flags enumerations: `&B1001_0011`.

## See also

* [What's New in Visual Studio 2017](https://docs.microsoft.com/visualstudio/ide/whats-new-in-visual-studio)
* [Visual Studio 2017 Release Notes](https://www.visualstudio.com/news/releasenotes/vs2017-relnotes)
* [Visual Basic .NET Language Design](https://github.com/dotnet/vblang)
