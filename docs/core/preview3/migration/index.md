---
title: .NET Core project.json to csproj migration | Microsoft Docs
description: .NET Core project.json to csproj migration
keywords: .NET, .NET Core, .NET Core migration
author: blackdwarf
ms.author: mairaw
ms.date: 02/17/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 1feadf3d-3cfc-41dd-abb5-a4fc303a7b53
---

# Migrating .NET Core projects

[!INCLUDE[preview-warning](../../../includes/warning.md)]

This document will cover migration scenarios for .NET Core projects and will go over the following three migration scenarios:

1. Migration from a valid latest schema of *project.json* to *csproj*.
2. Migration from DNX to a valid Preview 2 project.json.
3. Migration from RC3 and previous .NET Core csproj projects to the final format .

## Migration from project.json to csproj
Migration from project.json to csproj can be done via the [`dotnet migrate`](../tools/dotnet-migrate.md) command-line tool or through Visual Studio 2017. The command-line tool and Visual Studio 2017 use the same underlying engine to migrate projects, so the results will be the same for both. In most cases, using one of these two ways to migrate the project.json to csproj is the only thing that is needed and no further manual editing of the csproj is necessary. The resulting csproj file will be named per the `name` property in project.json or, lacking that, per containing directory name. 

Visual Studio 2017 will migrate the project automatically when you open either the `xproj` file or the solution file which references `xproj` files. If a solution file is opened, Visual Studio 2017 will automatically migrate all of the projects that are specified in the solution. 

In the command line scenario, you can use the `dotnet migrate` command. It will migrate a project, a solution or a set of folders in that order, depending on which ones were found. 

In both migration modalities files that were migrated (project.json, global.json and xproj) will be moved to a `backup` folder (on Windows, the folder will be named `Backup`). The solution file that is migrated will be upgraded to Visual Studio 2017 and you won't be able to open that solution file in previous versions of Visual Studio. 

> [!NOTE]
> If you are using VS Code, the `dotnet migrate` command will modify VS Code-specific files such as `tasks.json`. These files need to be changed manually. 
> This is also true if you are using Project Ryder or any editor or Integrated Development Environment (IDE) other than Visual Studio. 

> [!IMPORTANT]
> Migration is not available in Visual Studio 2015. 

## Migration from DNX to csproj
If you are still using DNX for .NET Core development, your migration process should be done in two stages:

1. Use the [existing DNX migration guidance](migrating-from-dnx.md) to migrate from DNX to project-json enabled CLI.
2. Follow the steps from the previous section to migrate from project.json to csproj.  

> [!NOTE]
> DNX has become officially deprecated during the Preview 1 release of the .NET Core CLI. 

## Migration from earlier .NET Core csproj formats to RTM csproj
The .NET Core csproj format has been changing and evolving with each new pre-release version of the tooling. There is no tool that will migrate your project file from earlier versions of csproj to the latest, so you need to manually edit the project file. The actual steps depend on the version of the project file you are migrating. The following is some guidance to consider based on the changes that happened between versions:

* Remove the tools version property from the `<Project>` element, if it exists. 
* Remove the XML namespace (`xmlns`) from the `<Project>` element.
* If it doesn't exist, add the `Sdk` attribute to the `<Project>` element and set it to the value of `Microsoft.NET.Sdk`. This attribute specifies that the project uses the Core SDK. 
**TODO: add other SDKs here**
* Remove the `<Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" />` and `<Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />` statements from the top and bottom of the project. These import statements are implied by the SDK, so there is no need for them to be in the project. 
* If you have `Microsoft.NETCore.App` or `NETStandard.Library` `<PackageReference>` items in your project, you should remove them. The SDK has these references implied. 
* Remove the `Microsoft.NET.Sdk` `<PackageReference>` element, if it exists. The SDK reference comes through the `Sdk` attribute on the `<Project>` element. 
* Remove the globs that are [implied by the SDK](https://aka.ms/sdkimplicititems). Leaving these globs in your project will cause an error on build because compile items will be duplicated. 

After these steps your project should be fully compatible with the RTM .NET Core csproj format. 