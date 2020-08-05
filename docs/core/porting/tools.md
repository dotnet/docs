---
title: Tools for porting to .NET Core
description: Learn about some of the tools you can use to port to .NET Core
author: cartermp
ms.date: 05/03/2020
---
# Tools to help with porting to .NET Core

You may find the tools listed in this article helpful when porting:

- [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) - A toolchain that can generate a report of how portable your code is between .NET Framework and .NET Core:
  - As a [command-line tool](https://github.com/Microsoft/dotnet-apiport/releases)
  - As a [Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer)
- [.NET API analyzer](../../standard/analyzers/api-analyzer.md) - A Roslyn analyzer that discovers potential compatibility risks for C# APIs on different platforms and detects calls to deprecated APIs.
- [try-convert](https://www.nuget.org/packages/try-convert/) - A .NET Core global tool that can convert a project or entire solution to the .NET SDK, including moving desktop apps to .NET Core. It is not recommended if you have a more complicated build established (such as custom tasks, targets, or imports), and it rejects many project types that are incompatible with .NET Core.
