---
title: dotnet-build command - .NET Core CLI | Microsoft Docs
description: The dotnet-build command builds a project and all of its dependencies. 
keywords: dotnet-build, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/15/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 5e1a2bc4-a919-4a86-8f33-a9b218b1fcb3
---

# dotnet-build

## Name

`dotnet-build` - Builds a project and all of its dependencies.

## Synopsis

`dotnet build [<PROJECT>] [-o|--output] [-f|--framework] [-c|--configuration] [-r|--runtime] [--version-suffix] [--no-incremental] [--no-dependencies] [-v|--verbosity] [-h|--help]`

## Description

The `dotnet build` command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a *.dll* extension and symbol files used for debugging with a *.pdb* extension. A dependencies JSON file (*\*.deps.json*) is produced that lists the dependencies of the application. A *\*.runtimeconfig.json* file is produced, which specifies the shared runtime and its version for the application.

If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of `dotnet build` isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the [dotnet publish](dotnet-publish.md) command. For more information, see [.NET Core Application Deployment](../deploying/index.md). 

Building requires the *project.assets.json* file, which lists the dependencies of your application. The file is created when you execute [`dotnet restore`](dotnet-restore.md) before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.

`dotnet build` uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to [Incremental Builds](https://docs.microsoft.com/visualstudio/msbuild/incremental-builds) for more information. 

In addition to its options, the `dotnet build` command accepts MSBuild options, such as `/p` for setting properties or `/l` to define a logger. Learn more about these options in the [MSBuild Command-Line Reference](https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference). 

Whether the project is executable or not is determined by the `<OutputType>` property in the project file. The following example shows a project that will produce executable code:

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

In order to produce a library, omit the `<OutputType>` property. The main difference in built output is that the IL DLL for a library doesn't contain entry points and can't be executed. 

## Arguments

`PROJECT`

The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* and uses that file.

## Options

`-h|--help`

Prints out a short help for the command.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to place the built binaries. You also need to define `--framework` when you specify this option.

`-f|--framework <FRAMEWORK>`

Compiles for a specific [framework](../../standard/frameworks.md). The framework must be defined in the [project file](csproj.md).

`-c|--configuration <CONFIGURATION>`

Defines the build configuration. If omitted, the build configuration defaults to `Debug`. Use `Release` build a Release configuration.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix for an asterisk (`*`) in the version field of the project file. The format follows NuGet's version guidelines.

`--no-incremental`

Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.

`--no-dependencies`

Ignores project-to-project (P2P) references and only builds the root project specified to build.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Build a project and its dependencies:

`dotnet build`

Build a project and its dependencies using Release configuration:

`dotnet build --configuration Release`

Build a project and its dependencies for a specific runtime (in this example, Ubuntu 16.04):

`dotnet build --runtime ubuntu.16.04-x64`
