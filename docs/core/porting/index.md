---
title: Port from .NET Framework to .NET Core
description: Understand the porting process and discover tools you may find helpful when porting a .NET Framework project to .NET Core.
author: cartermp
ms.date: 10/22/2019
---
# Overview of porting from .NET Framework to .NET Core

You might have code that currently runs on the .NET Framework that you're interested in porting to .NET Core. This article provides:

* An overview of the porting process.
* A list of tools that you may find helpful when you're porting your code to .NET Core.

## Overview of the porting process

Porting to .NET Core (or .NET Standard) from .NET Framework for many projects is relatively straight forward. There are a number of changes that are required, but many of them follow the patterns outlined below. Projects where the app-model is available in .NET Core (such as libraries, console apps, and desktop applications) usually require little changes. Projects that require a new app model, such as moving to ASP.NET Core from ASP.NET, require a bit more work, but many patterns have analogs that can be used during the conversion. This document should help with identifying the main strategies that have been employed by users to successfully convert their code bases to target .NET Standard or .NET Core and will address the conversion at two levels: solution-wide and project specific. See the links at the bottom for directions on app-model specific conversions.

We recommend you use the following process when porting your project to .NET Core. Each of these steps introduces potential places for behavior changes, so ensure that you adequately test your library or application before continuing on to later steps. The first steps are to get your project ready for a switch to .NET Standard or .NET Core. If you have unit tests, it's best to convert them first so that you can continue testing changes in the product you're working on. Because porting to .NET Core is such a significant change to your codebase, it's highly recommended to port your test projects so that you can run tests as you port your code over. MSTest, xUnit, and NUnit all work on .NET Core.

## Getting started

The following tools will be used throughout the process:

- Visual Studio 2019
- Download [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md)
- _Optional_ Install [dotnet try-convert](https://github.com/dotnet/try-convert)

## Porting a solution

When there are multiple projects in a solution, the porting can seem more complicated because you must address projects in a specific order. The conversion process should be a bottom-up approach, where the projects with no dependencies on other projects in the solution are converted first, and continue up through the whole solution.

In order to identify the order projects should be migrated, you can use the following tools:

- [Dependency Diagrams in Visual Studio](/visualstudio/modeling/create-layer-diagrams-from-your-code) can create a directed graph of the code in a solution.
- Run `msbuild _SolutionPath_ /t:GenerateRestoreGraphFile /p:RestoreGraphOutputPath=graph.dg.json` to generate a json document that includes list of project references.
- Run [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) with the `-r DGML` switch to retrieve a dependency diagram of the assemblies. For more information, see [here](../../standard/analyzers/portability-analyzer.md#solution-wide-view).

Once you have dependency information, you can use that information to start at the leaf nodes and work your way up the dependency tree applying the steps in the next section.

## Per project steps

We recommend you use the following process when porting your project to .NET Core:

1. Convert all of your `packages.config` dependencies to the [PackageReference](/nuget/consume-packages/package-references-in-project-files) format with the [conversion tool in Visual Studio](/nuget/consume-packages/migrate-packages-config-to-package-reference).

   This step involves converting your dependencies from the legacy `packages.config` format. `packages.config` doesn't work on .NET Core, so this conversion is required if you have package dependencies. It also only requires the dependencies you are directly using in a project, which makes later steps easier by reducing the number of dependencies you must manage.

1. Convert your project file to the new SDK-style files structure. You can create new projects for .NET Core and copy over source files, or attempt to convert your existing project file with a tool.

   .NET Core uses a simplified (and different) [project file format](../tools/csproj.md) than .NET Framework. You'll need to convert your project files into this format to continue. This project style allows you to also target .NET Framework, which at this point you'll still want to target.

   You can attempt to port smaller solutions or individual projects in one operation to the .NET Core project file format with the [dotnet try-convert](https://github.com/dotnet/try-convert) tool. `dotnet try-convert` is not guaranteed to work for all your projects, and it may cause subtle changes in behavior that you depended on. Use it as a _starting point_ that automates the basic things that can be automated. It isn't a guaranteed solution to migrating a project, as there are many differences in the targets used by the SDK style projects compared to the old-style project files.

1. Retarget all projects you wish to port to target .NET Framework 4.7.2 or higher.

   This step ensures that you can use API alternatives for .NET Framework-specific targets when .NET Core doesn't support a particular API.

1. Update all dependencies to the latest version. Projects may be using older versions of libraries that may not have .NET Standard support. However, later versions may support it with a simple switch. This may require code changes if there are breaking changes in libraries.

1. Use the [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) to analyze your assemblies and see if they're portable to .NET Core.

   The .NET Portability Analyzer tool analyzes your compiled assemblies and generates a report. This report shows a high-level portability summary and a breakdown of each API you're using that isn't available on NET Core. While using the tool, only submit the individual project you are converting to focus on the API changes that are potentially needed. Many of the APIs have equivalent availability in .NET Core, which you'll want to switch to.

   While reading the reports generated by the analyzer, the important information is the actual APIs that are being used and not necessarily the percentage of support for the target platform. Many APIs have equivalent options in .NET Standard/Core, and so understanding the scenarios your library or application needs the API for will help determine the implication for portability.

   There are some cases where APIs are not equivalent and you'll need to do some compiler preprocessor directives (that is, `#if NET45`) to special case the platforms. At this point, your project will still be targeting .NET Framework. For each of these targeted cases, it is recommended to use well-known conditionals that can be understood as a scenario.  For example, AppDomain support in .NET Core is limited, but for the scenario of loading and unloading assemblies, there is a new API that's not available in .NET Core. A common way to handle this in code would be something like this:

   ```csharp
   #if FEATURE_APPDOMAIN_LOADING
   // Code that uses appdomains
   #elif FEATURE_ASSEMBLY_LOAD_CONTEXT
   // Code that uses assembly load context
   #else
   #error Unsupported platform
   #endif
   ```

1. Install the [.NET API analyzer](../../standard/analyzers/api-analyzer.md) into your projects to identify APIs that throw <xref:System.PlatformNotSupportedException> on some platforms and some other potential compatibility issues.

   This tool is similar to the portability analyzer, but instead of analyzing if code can build on .NET Core, it analyzes whether you're using an API in a way that will throw a <xref:System.PlatformNotSupportedException> at run time. Although this isn't common if you're moving from .NET Framework 4.7.2 or higher, it's good to check. For more information about APIs that throw exceptions on .NET Core, see [APIs that always throw exceptions on .NET Core](../compatibility/unsupported-apis.md).

1. At this point, you can switch to targeting .NET Core (generally for applications) or .NET Standard (for libraries).

   The choice between .NET Core and .NET Standard is largely dependent on where the project will be run. If it is a library that will be consumed by other applications or distributed via NuGet, the preference is usually to target .NET Standard. However, there may be APIs that are only available on .NET Core for performance or other reasons; if that's the case, .NET Core should be targeted with potentially a .NET Standard build available as well with reduced performance or functionality. By targeting .NET Standard, the project will be ready to run on new platforms (such as WebAssembly). If the project has dependencies on specific app frameworks (such as ASP.NET Core), then the target will be limited by what the dependencies support.

   If there are no preprocessor directives to conditional compile code for .NET Framework or .NET Standard, this will be as simple as finding the following in the project file:

   ```xml
   <TargetFramework>net472</TargetFramework>
   ```

   and switch it to the desired framework. For .NET Core 3.1, this would be:

   ```xml
   <TargetFramework>netcoreapp3.1</TargetFramework>
   ```

   However, if this is a library for which you want to continue supporting .NET Framework-specific builds, you can [multi-target](../../standard/library-guidance/cross-platform-targeting.md) by replacing it with the following:

   ```xml
   <TargetFrameworks>net472;netstandard2.0</TargetFrameworks>
   ```

   If you're using Windows-specific APIs (such as registry access), install the [Windows Compatibility Pack](./windows-compat-pack.md).

## Next steps

> [!div class="nextstepaction"]
> [Analyze dependencies](third-party-deps.md)
> [Package NuGet Package](../deploying/creating-nuget-packages.md)
> [ASP.NET to ASP.NET Core Migration](/aspnet/core/migration/proper-to-2x)
