---
title: Tools for porting to .NET Core
description: Learn about some of the tools you can use to port to .NET Core
author: cartermp
ms.author: mairaw
ms.date: 12/07/2018
---

# Tools to help with porting to .NET Core

You may find the tools listed in this article helpful when porting:

* .NET Portability Analyzer - [command line tool](https://github.com/Microsoft/dotnet-apiport/releases) or [Visual Studio Extension](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b), a toolchain that can generate a report of how portable your code is between .NET Framework and .NET Core, with an assembly-by-assembly breakdown of issues. For more information, see [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md).
* .NET API analyzer - A Roslyn analyzer that discovers potential compatibility risks for C# APIs on different platforms and detects calls to deprecated APIs. For more information, see [.NET API analyzer](../../standard/analyzers/api-analyzer.md).
* Reverse Package Search - A [useful web service](https://packagesearch.azurewebsites.net) that allows you to search for a type and find packages containing that type.

Additionally, you can attempt to port smaller solutions or individual projects to the .NET Core project file format with the [CsprojToVs2017](https://github.com/hvanbakel/CsprojToVs2017) tool.

> [!WARNING] 
> CsprojToVs2017 is a third-party tool. There is no guarantee that it will work for all of your projects, and it may cause subtle changes in behavior that you depend on. CsprojToVs2017 should be used as a _starting point_ that automates the basic things that can be automated. It is not a guaranteed solution to migrating project file formats.