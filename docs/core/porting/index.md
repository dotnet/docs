---
title: Porting to .NET Core from .NET Framework
description: Understand the porting process and discover tools you may find helpful when porting a .NET Framework project to .NET Core.
author: cartermp
ms.author: mairaw
ms.date: 10/23/2018
---
# Porting to .NET Core from .NET Framework

If you've got code running on the .NET Framework, you may be interested in running your code on .NET Core. This article gives you an overview of the porting process and a list of the tools you may find helpful when porting to .NET Core.

## Overview of the porting process

This is the process we recommend you take when porting your project to .NET Core. Each step of the process is covered in more detail in further articles.

1. Identify and account for your third-party dependencies.

  This step involves understanding what your third-party dependencies are, how you depend on them, how to check if they also run on .NET Core and steps you can take if they don't.

2. Retarget all projects you wish to port to target the latest version of .NET Framework.

   This step ensures that you can use API alternatives for .NET Framework-specific targets when .NET Core doesn't support a particular API.

3. Use the [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) to analyze your assemblies and develop a plan to port based on its results.

   The API Portability Analyzer tool analyzes your compiled assemblies and generates a report that shows a high-level portability summary and a breakdown of each API you're using that isn't available on .NET Core. You can use this report alongside an analysis of your codebase to develop a plan for how you'll port your code over.

4. Port your tests code.

   Because porting to .NET Core is such a significant change to your codebase, it's highly recommended to get your tests ported, so that you can run tests as you port your code over. MSTest, xUnit, and NUnit all support .NET Core.

5. Execute your plan for porting!

## Tools to help

The following list shows tools you might find helpful to use during the porting process:

* NuGet - [Nuget Client](https://dist.nuget.org/index.html) or [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer), Microsoft's package manager for .NET implementations.
* .NET Portability Analyzer - [command line tool](https://github.com/Microsoft/dotnet-apiport/releases) or [Visual Studio Extension](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b), a toolchain that can generate a report of how portable your code is between .NET Framework and .NET Core, with an assembly-by-assembly breakdown of issues. For more information, see [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md).
* .NET API analyzer - A Roslyn analyzer that discovers potential compatibility risks for C# APIs on different platforms and detects calls to deprecated APIs. For more information, see [.NET API analyzer](../../standard/analyzers/api-analyzer.md).
* Reverse Package Search - A [useful web service](https://packagesearch.azurewebsites.net) that allows you to search for a type and find packages containing that type.

>[!div class="step-by-step"]
[Next](third-party-deps.md)
