---
title: Organizing Your Project to Support .NET Framework and .NET Core
description: Organizing Your Project to Support .NET Framework and .NET Core
keywords: .NET, .NET Core
author: conniey
manager: wpickett
ms.date: 07/07/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 3af62252-1dfa-4336-8d2f-5cfdb57d7724
---

# Organizing Your Project to Support .NET Framework and .NET Core

This article is to help project owners who want to compile their solution against .NET Framework and .NET Code side-by-side.  It provides several options to organize projects to help developers achieve this goal.  Here are some typical scenarios to consider when you are deciding how to setup your project layout with .NET Core.

* You want to be able to continue building existing applications for different versions of the .NET Framework (2.0, 3.0, 4.X)
    * [You want to have single projects that build existing .NET Framework versions as well as .NET Core][option-xproj]
      
      This is an option to consider when you have a repository that builds for multiple platforms and you want to simplify the build process by only compiling a single project rather than multiple projects targeting different frameworks.  Using a .NET Core project (xproj) provides an additional benefit of being able to generate a NuGet package with the .NET Core tools.
    * [You want your existing projects to continue building as-is and you want to be able to build new projects for .NET Core][option-xproj-folder]
      
      This is an option to consider when you have an older repository containing legacy projects you don't want to modify but want to support newer platforms.
* [You want to continue supporting your existing projects on older versions of Visual Studio][option-xproj-folder]
  
  This is an option to consider when you have developers/contributors who may not have Visual Studio 2015 and to continue to support their development on existing projects without having to upgrade.
* [Your existing projects contain complex build operations such as custom MSBuild Tasks and Targets][option-pcl]

  This is an option to consider when you have complex modifications in your C# project files (csproj) to support loading or building your existing projects.  Complex modifications could be the inclusion of custom MSBuild Tasks and Targets in your *.csproj file.
* You have several different project types in your solution including things like desktop apps, web apps and libraries
    * [You want to share the libraries across projects][option-pcl]

      This is an option to consider when you have applications targeting the full .NET Framework you do not want to modify but want that project to reference your .NET Core library in the same solution.
    * [You want your existing projects to continue building as-is and you want to be able to build new projects for .NET Core][option-xproj-folder]

      This is an option to consider when you have an older repository containing legacy projects you don't want to modify but want to support newer platforms.

## Example

Consider the repository below:

![][example-initial-project]

[**Source Code**][example-initial-project-code]

There are several different ways to add support for .NET Core for this repository depending on the constraints and complexity of existing projects which are described below.

### Replace Existing Projects with a Multi-targeted .NET Core Project (xproj)

The repository can be reorganized so that any existing *.csproj files are removed and a single *.xproj is created that targets multiple frameworks.  This is a great option because a single project is able to compile for different frameworks.  It also has the power to handle different compilation options, dependencies, etc. per targeted framework.

![][example-xproj]

[**Source Code**][example-xproj-code]

Changes to note are:
* Addition of `global.json`
* Replacement of `packages.config` and `*.csproj` with `project.json` and `*.xproj`
* Changes in the [Car's project.json][example-xproj-projectjson] and its [test project][example-xproj-projectjson-test] to support building for the existing .NET Framework as well as others

### Create a Portable Class Library (PCL) to target .NET Core

If existing projects contain complex build operations or properties in their *.csproj, it may be easier to create a PCL.

![][example-pcl]

[**Source Code**][example-pcl-code]

Changes to note are:
*  Renaming `project.json` to `{project-name}.project.json`
    * This prevents potential conflict in Visual Studio when trying to restore packages for the libraries in the same directory. For more information, see the [NuGet FAQ](https://docs.nuget.org/consume/nuget-faq#working-with-packages) under "_I have multiple projects in the same folder, how can I use separate packages.config or project.json files for each project?_".
    *  **Alternative**: Create the PCL in another folder and reference the original source code to avoid this issue
*  To target .NET Standard after creating the PCL, in Visual Studio, open the **Project's Properties**. Under the **Targets** section, click on the link **"Target .NET Platform Standard"**.  This change can be reversed by repeating the same steps.

### Keep Existing Projects and Create a .NET Core Project

If there are existing projects that target older frameworks, you may want to leave these projects untouched and use a .NET Core project to target future frameworks.

![][example-xproj-different-folder]

[**Source Code**][example-xproj-different-code]

Changes to note are:
* The .NET Core and existing projects are kept in separate folders.
    * This avoids the package restore issue that was mentioned above due to multiple project.json/package.config files being in the same folder.
    * Keeping projects in separate folders avoids forcing you to have Visual Studio 2015 (due to project.json).  You can create a separate solution that only opens the old projects.

## Further Reading

Please see [.NET Core porting documentation][porting-doc] for more guidance on moving to project.json and xproj.

[sln-only-netcore-projects]: ../tutorials/using-on-windows#a-solution-using-only-net-core-projects
[porting-doc]: index.md
[example-initial-project]: _static/project.png "Existing project"
[example-initial-project-code]: ../../../samples/core-projects/libraries/migrate-library/

[example-xproj]: _static/project.xproj.png "Create an xproj that targets multiple frameworks"
[example-xproj-code]: ../../../samples/core-projects/libraries/migrate-library-xproj/
[example-xproj-projectjson]: ../../../samples/core-projects/libraries/migrate-library-xproj/src/Car/project.json
[example-xproj-projectjson-test]: ../../../samples/core-projects/libraries/migrate-library-xproj/tests/Car.Tests/project.json

[example-xproj-different-folder]: _static/project.xproj.different.png ".NET Core project with existing PCL in different folder"
[example-xproj-different-code]: ../../../samples/core-projects/libraries/migrate-library-xproj-keep-csproj/

[example-pcl]: _static/project.pcl.png "PCL Targeting .NET Core"
[example-pcl-code]: ../../../samples/core-projects/libraries/migrate-library-pcl

[option-xproj]: #replace-existing-projects-with-a-multi-targeted-net-core-project-xproj
[option-pcl]: #create-a-portable-class-library-pcl-to-target-net-core
[option-xproj-folder]: #keep-existing-projects-and-create-a-net-core-project