---
title: Port code from .NET Framework to .NET Core
description: Understand the porting process and discover tools you may find helpful when porting a .NET Framework project to .NET Core.
author: cartermp
ms.date: 09/13/2019
ms.custom: seodec18
---
# Port your code from .NET Framework to .NET Core

If you've got code that runs on the .NET Framework, you may be interested in running your code on .NET Core, too. Here's an overview of the porting process and a list of the tools you may find helpful when porting your code to .NET Core.

## Overview of the porting process

This is the process we recommend you take when porting your project to .NET Core. Each step of the process is covered in more detail in further articles.

1. Identify and account for your third-party dependencies.

   This step involves understanding what your third-party dependencies are, how you depend on them, how to check if they also run on .NET Core, and steps you can take if they don't. It also covers how you can migrate your dependencies over to the [PackageReference](/nuget/consume-packages/package-references-in-project-files) format that is used in .NET Core.

2. Retarget all projects you wish to port to target the .NET Framework 4.7.2 or higher.

   This step ensures that you can use API alternatives for .NET Framework-specific targets when .NET Core doesn't support a particular API.

3. Use the [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) to analyze your assemblies and develop a plan to port based on its results.

   The API Portability Analyzer tool analyzes your compiled assemblies and generates a report that shows a high-level portability summary and a breakdown of each API you're using that isn't available on targeted .NET Core platform public surface. You can use this report alongside an analysis of your codebase to develop a plan for how you'll port your code over.

4. Once you have your project file converted to your targeted .NET Core version, you can use Roslyn based [.NET API analyzer](../../standard/analyzers/api-analyzer.md) to identify APIs throwing <xref:System.PlatformNotSupportedException> on some platforms and some other potential compatibility issues.

5. Port your tests code.

   Because porting to .NET Core is such a significant change to your codebase, it's highly recommended to get your tests ported, so that you can run tests as you port your code over. MSTest, xUnit, and NUnit all support .NET Core.

6. Execute your plan for porting!

The following list shows tools you might find helpful to use during the porting process:

* .NET Portability Analyzer - [command line tool](https://github.com/Microsoft/dotnet-apiport/releases) or [Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer), a tool that can generate a report of how portable your code is between .NET Framework and your target .NET Core platform. The report contains an assembly-by-assembly breakdown of the Type and APIs missing on the target .NET Core platform. For more information, see [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md). It is recommended to run the .NET Portability Analyzer tool before you start porting, as it will help you identify any gaps in missing APIs in specific targeted .NET platform public surface.
* .NET API Analyzer - A Roslyn analyzer that discovers .NET Standard API that throws <xref:System.PlatformNotSupportedException> on some platforms, detects calls to deprecated APIs, and discovers some other potential compatibility risks for C# APIs on different platforms. For more information, see [.NET API analyzer](../../standard/analyzers/api-analyzer.md). This analyzer is helpful after you already created your .NET Core project to identify runtime behavior differences on different platforms.
* Reverse Package Search - A [useful web service](https://packagesearch.azurewebsites.net) that allows you to search for a type and find packages containing that type.

Additionally, you can attempt to port smaller solutions or individual projects to the .NET Core project file format with the [CsprojToVs2017](https://github.com/hvanbakel/CsprojToVs2017) tool.

> [!WARNING]
> CsprojToVs2017 is a third-party tool. There is no guarantee that it will work for all of your projects, and it may cause subtle changes in behavior that you depend on. CsprojToVs2017 should be used as a _starting point_ that automates the basic things that can be automated. It is not a guaranteed solution to migrating project file formats.

>[!div class="step-by-step"]
>[Next](net-framework-tech-unavailable.md)
