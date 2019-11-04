---
title: Tools for porting to .NET Core
description: Learn about some of the tools you can use to port to .NET Core
author: cartermp
ms.author: mairaw
ms.date: 12/07/2018
---

# Tools to help with porting to .NET Core

You may find the tools listed in this article helpful when porting:

- [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) - A toolchain that can generate a report of how portable your code is between .NET Framework and .NET Core:
   As a [command-line tool](https://github.com/Microsoft/dotnet-apiport/releases)
   As a [Visual Studio Extension](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b)
- [.NET API analyzer](../../standard/analyzers/api-analyzer.md) - A Roslyn analyzer that discovers potential compatibility risks for C# APIs on different platforms and detects calls to deprecated APIs.

Additionally, you can attempt to port smaller solutions or individual projects to the .NET Core project file format with the [CsprojToVs2017](https://github.com/hvanbakel/CsprojToVs2017) tool.

> [!WARNING] 
> CsprojToVs2017 is a third-party tool. There is no guarantee that it will work for all of your projects, and it may cause subtle changes in behavior that you depend on. CsprojToVs2017 should be used as a _starting point_ that automates the basic things that can be automated. It is not a guaranteed solution to migrating project file formats.
