---
title: Porting to .NET Core from .NET Framework
description: Understand the porting process and discover tools you may find helpful when porting a .NET Framework project to .NET Core.
keywords: .NET, .NET Core
author: cartermp
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 00d00d38-99af-44f4-a75f-defcd9729dc5
ms.workload: 
  - dotnetcore
---

# Porting to .NET Core from .NET Framework

If you've got code running on the .NET Framework, you may be interested in running your code on .NET Core 1.0.  This article covers an overview of the porting process and a list of the tools you may find helpful when porting to .NET Core.

## Overview of the Porting Process

The recommended process for porting follows the following series of steps.  Each of these parts of the process are covered in more detail in further articles.

1. Identify and account for your third-party dependencies.

   This will involve understanding what your third-party dependencies are, how you depend on them, how to see if they also run on .NET Core, and steps you can take if they don't.
   
2. Retarget all projects you wish to port to target .NET Framework 4.6.2.

   This ensures that you can use API alternatives for .NET Framework-specific targets in the cases where .NET Core can't support a particular API.
   
3. Use the [API Portability Analyzer tool](https://github.com/Microsoft/dotnet-apiport/) to analyze your assemblies and develop a plan to port based on its results.

   The API Portability Analyzer tool will analyze your compiled assemblies and generate a report which shows a high-level portability summary and a breakdown of each API you're using that isn't available on .NET Core.  You can use this report alongside an analysis of your codebase to develop a plan for how you'll port your code over.
   
4. Port your tests code.

   Because porting to .NET Core is such a big change to your codebase, it's highly recommended to get your tests ported so that you can run tests as you port code over.  MSTest, xUnit, and NUnit all support .NET Core 1.0 today.
   
6. Execute your plan for porting!

## Tools to help

Here's a short list of the tools you'll find helpful:

* NuGet - [Nuget Client](https://dist.nuget.org/index.html) or [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer), Microsoft's package manager for .NET implementations.
* Api Portability Analyzer - [command line tool](https://github.com/Microsoft/dotnet-apiport/releases) or [Visual Studio Extension](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b), a toolchain that can generate a report of how portable your code is between .NET Framework and .NET Core, with an assembly-by-assembly breakdown of issues.  See [Tooling to help you on the process](https://github.com/Microsoft/dotnet-apiport/blob/master/docs/HowTo/) for more information.
* Reverse Package Search - A [useful web service](https://packagesearch.azurewebsites.net) that allows you to search for a type and find packages containing that type.

## Next steps

[Analyzing your third-party dependencies.](third-party-deps.md)
   
