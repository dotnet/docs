---
title: Organizing Your Project to Support .NET Framework and .NET Core
description: Organizing Your Project to Support .NET Framework and .NET Core
keywords: .NET, .NET Core
author: conniey
ms.author: mairaw
ms.date: 07/18/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 3af62252-1dfa-4336-8d2f-5cfdb57d7724
---

# Organizing Your Project to Support .NET Framework and .NET Core

This article is to help project owners who want to compile their solution against .NET Framework and .NET Core side-by-side.  It provides several options to organize projects to help developers achieve this goal.  Here are some typical scenarios to consider when you are deciding how to setup your project layout with .NET Core.  They may not cover everything you want; prioritize based on your project's needs.

* [**Combine existing projects and .NET Core projects into single projects**][option-xproj]
  
  *What this is good for:*
  * Simplifying your build process by compiling a single project rather than compiling multiple projects, each targeting a different .NET Framework version or platform.
  * Simplifying source file management for multi-targeted projects because you have to manage a single project file.  When adding/removing source files, the alternatives require you to manually sync these with your other projects.
  * Easily generating a NuGet package for consumption.
  * Allows you to write code for a specific .NET Framework version in your libraries through the use of compiler directives.
  
  *Unsupported scenarios:*
  * Does not allow developers without Visual Studio 2015 to open existing projects. To support older versions of Visual Studio, [keeping your project files in different folders](#support-vs) is a better option.
  * Does not allow you to share your .NET Core library across different project types in the same solution file. To support this, [creating a Portable Class Library](#support-pcl) is a better option.
  * Does not allow for project build or load modifications that are supported by MSBuild Targets and Tasks. To support this, [creating a Portable Class Library](#support-pcl) is a better option.

* <a name="support-vs"></a>[**Keep existing projects and new .NET Core projects separate**][option-xproj-folder]
  
  *What this is good for:*
  * Continuing to support development on existing projects without having to upgrade for developers/contributors who may not have Visual Studio 2015.
  * Decreasing the possibility in creating new bugs in existing projects because no code churn is required in those projects.

* <a name="support-pcl"></a>[**Keep existing projects and create Portable Class Libraries (PCLs) targeting .NET Core**][option-pcl]

  *What this is good for:*
  * Referencing your .NET Core libraries in desktop and/or web projects targeting the full .NET Framework in the same solution.
  * Supporting modifications in the project build or load process. These modifications could be the inclusion of MSBuild Tasks and Targets in your `*.csproj` file.

  *Unsupported scenarios:*
  * Does not allow you to write code for a specific .NET Framework version because the [predefined preprocessor symbols][how-to-multitarget] are not supported.

## Example

Consider the repository below:

![Existing project][example-initial-project]

[**Source Code**][example-initial-project-code]

There are several different ways to add support for .NET Core for this repository depending on the constraints and complexity of existing projects which are described below.

## Replace Existing Projects with a Multi-targeted .NET Core Project (xproj)

The repository can be reorganized so that any existing `*.csproj` files are removed and a single `*.xproj` file is created that targets multiple frameworks.  This is a great option because a single project is able to compile for different frameworks.  It also has the power to handle different compilation options, dependencies, etc. per targeted framework.

![Create an xproj that targets multiple frameworks][example-xproj]

[**Source Code**][example-xproj-code]

Changes to note are:
* Addition of `global.json`
* Replacement of `packages.config` and `*.csproj` with `project.json` and `*.xproj`
* Changes in the [Car's project.json][example-xproj-projectjson] and its [test project][example-xproj-projectjson-test] to support building for the existing .NET Framework as well as others

## Create a Portable Class Library (PCL) to target .NET Core

If existing projects contain complex build operations or properties in their `*.csproj` file, it may be easier to create a PCL.

![][example-pcl]

[**Source Code**][example-pcl-code]

Changes to note are:
*  Renaming `project.json` to `{project-name}.project.json`
    * This prevents potential conflict in Visual Studio when trying to restore packages for the libraries in the same directory. For more information, see the [NuGet FAQ](https://docs.nuget.org/consume/nuget-faq#working-with-packages) under "_I have multiple projects in the same folder, how can I use separate packages.config or project.json files for each project?_".
    *  **Alternative**: Create the PCL in another folder and reference the original source code to avoid this issue.  Placing the PCL in another folder has an added benefit that users who do not have Visual Studio 2015 can still work on the older projects without loading the new solution.
*  To target .NET Standard after creating the PCL, in Visual Studio, open the **Project's Properties**. Under the **Targets** section, click on the link **"Target .NET Platform Standard"**.  This change can be reversed by repeating the same steps.

## Keep Existing Projects and Create a .NET Core Project

If there are existing projects that target older frameworks, you may want to leave these projects untouched and use a .NET Core project to target future frameworks.

![.NET Core project with existing PCL in different folder][example-xproj-different-folder]

[**Source Code**][example-xproj-different-code]

Changes to note are:
* The .NET Core and existing projects are kept in separate folders.
    * This avoids the package restore issue that was mentioned above due to multiple project.json/package.config files being in the same folder.
    * Keeping projects in separate folders avoids forcing you to have Visual Studio 2015 (due to project.json).  You can create a separate solution that only opens the old projects.

## See Also

Please see [.NET Core porting documentation][porting-doc] for more guidance on moving to project.json and xproj.

[porting-doc]: index.md
[example-initial-project]: media/project-structure/project.png "Existing project"
[example-initial-project-code]: https://github.com/dotnet/docs/tree/master/samples/framework/libraries/migrate-library/

[example-xproj]: media/project-structure/project.xproj.png "Create an xproj that targets multiple frameworks"
[example-xproj-code]: https://github.com/dotnet/docs/tree/master/samples/framework/libraries/migrate-library-xproj/
[example-xproj-projectjson]: https://github.com/dotnet/docs/tree/master/samples/framework/libraries/migrate-library-xproj/src/Car/project.json
[example-xproj-projectjson-test]: https://github.com/dotnet/docs/tree/master/samples/framework/libraries/migrate-library-xproj/tests/Car.Tests/project.json

[example-xproj-different-folder]: media/project-structure/project.xproj.different.png ".NET Core project with existing PCL in different folder"
[example-xproj-different-code]: https://github.com/dotnet/docs/tree/master/samples/framework/libraries/migrate-library-xproj-keep-csproj/

[example-pcl]: media/project-structure/project.pcl.png "PCL Targeting .NET Core"
[example-pcl-code]: https://github.com/dotnet/docs/tree/master/samples/framework/libraries/migrate-library-pcl

[option-xproj]: #replace-existing-projects-with-a-multi-targeted-net-core-project-xproj
[option-pcl]: #create-a-portable-class-library-pcl-to-target-net-core
[option-xproj-folder]: #keep-existing-projects-and-create-a-net-core-project

[how-to-multitarget]: ../tutorials/libraries.md#how-to-multitarget
