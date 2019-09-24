---
title: Port from .NET Framework to .NET Core
description: Understand the porting process and discover tools you may find helpful when porting a .NET Framework project to .NET Core.
author: cartermp
ms.date: 09/23/2019
ms.custom: seodec18
---
# Overview of the porting process from .NET Framework to .NET Core

You might have code that currently runs on the .NET Framework that you're interested in porting to .NET Core. This article provides:

* An overview of the porting process.
* A list of the tools you may find helpful when you're porting your code to .NET Core.

## Overview of the porting process

We recommend you to use the following process when porting your project to .NET Core. Each step of the process is covered in more detail in further articles.

1. Retarget all projects you wish to port to target the .NET Framework 4.7.2 or higher.

   This step ensures that you can use API alternatives for .NET Framework-specific targets when .NET Core doesn't support a particular API.

2. Assess if your first-party .NET dependencies all work on .NET Core. Use the [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) to analyze your assemblies.

   The API Portability Analyzer tool analyzes your compiled assemblies and generates a report. This report shows a high-level portability summary and a breakdown of each API you're using that isn't available on NET Core.

3. Install the [.NET API analyzer](../../standard/analyzers/api-analyzer.md) into your projects to identify APIs throwing <xref:System.PlatformNotSupportedException> on some platforms and some other potential compatibility issues.

4. Convert all of your package dependencies to the [PackageReference](/nuget/consume-packages/package-references-in-project-files) format.

   This step involves converting your dependencies from the legacy `packages.config` format. `packages.config` doesn't work on .NET Core, so this conversion is required if you have package dependencies.

5. Create new projects for .NET Core, or attempt to convert your existing project file with a tool.

   .NET Core uses a simplified (and different) [project file format](../tools/csproj.md) than .NET Framework. You'll need to convert your project files into this format to continue.

6. Port your tests code.

   Because porting to .NET Core is such a significant change to your codebase, it's highly recommended to get your tests ported, so that you can run tests as you port your code over. MSTest, xUnit, and NUnit are all supported in .NET Core.

Additionally, you can attempt to port smaller solutions or individual projects to the .NET Core project file format with the [CsprojToVs2017](https://github.com/hvanbakel/CsprojToVs2017) tool in one operation. CsprojToVs2017 is a third-party tool. There's no guarantee that it works for all your projects, and it may cause subtle changes in behavior that you depend on. It should be used as a _starting point_ that automates the basic things that can be automated. It isn't a guaranteed solution to migrating a project.

>[!div class="step-by-step"]
>[Next](net-framework-tech-unavailable.md)
