---
title: dotnet build command
description: The 'dotnet build' command builds a project and all of its dependencies. 
keywords: dotnet build, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 5e1a2bc4-a919-4a86-8f33-a9b218b1fcb3
---
# dotnet build

## Name

`dotnet build` - Builds a project and all of its dependencies.

## Synopsis

`dotnet build [<PROJECT>] [-c|--configuration] [-f|--framework] [-h|--help] [--no-dependencies] [--no-incremental] [-o|--output] [-r|--runtime] [-v|--verbosity] [--version-suffix]`

## Description

The `dotnet build` command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a *dll* extension (for example, *\<assembly_name>.dll*) and symbol files used for debugging with a *pdb* extension (for example, *\<assembly_name>.pdb*). A dependencies JSON file (*\<assembly_name>.deps.json*) is produced that lists the dependencies of the app. A *\<assembly_name>.runtimeconfig.json* file is produced, which specifies the shared runtime and its version for the app.

If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of `dotnet build` isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an app) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, use the [dotnet publish](dotnet-publish.md) command. For more information, see [.NET Core Application Deployment](../deploying/index.md). 

Building requires the *project.assets.json* file in the intermediate output folder (*obj*), which lists the dependencies of your app. The file is created when you execute [`dotnet restore`](dotnet-restore.md) before building the project. Without the assets file in place, the tooling can't resolve reference assemblies, which results in errors.

`dotnet build` uses [MSBuild](/visualstudio/msbuild/msbuild) to build the project, so it supports both parallel and incremental builds. Refer to [Incremental Builds](/visualstudio/msbuild/incremental-builds) for more information. 

In addition to its own options, the `dotnet build` command accepts MSBuild options, such as `/p` for setting properties or `/l` to define a logger. Learn more about these options in the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference). 

The `<OutputType>` property in the project file determines if the build output is an executable app or a non-executable library. The following example shows a project file that produces executable code (a .NET Core console app):

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <OutputType>Exe</OutputType>
  </PropertyGroup>
</Project>
```

In order to produce a library, omit the `<OutputType>` property or set `<OutputType>` to `Library`. The main difference in the output for a library is that the IL DLL for a library doesn't contain entry points and can't be executed. The following example shows a project file that produces a non-executable library:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard1.4</TargetFramework>
  </PropertyGroup>
</Project>
```

## Arguments

`PROJECT`

The project file to build. If a project file isn't specified, MSBuild searches the current working directory for a file with a *proj* file extension.

## Options

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Compiles for a specific [framework](../../standard/frameworks.md). The framework must be defined in the [project file](csproj.md).

`-h|--help`

Shows help information.

`--no-dependencies`

Ignores project-to-project (P2P) references and only builds the root project specified to build.

`--no-incremental`

Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.

`-o|--output <OUTPUT_DIRECTORY>`

Places the built binaries into a specific directory. You must define the framework (`-f|--framework <FRAMEWORK>`) when you specify this option.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix to replace the asterisk (`*`) in the version field (`$(VersionSuffix)`) of the project file. The format follows NuGet's version guidelines.

## Examples

Build a project and its dependencies:

`dotnet build`

Build a project and its dependencies using Release configuration:

`dotnet build --configuration Release`

Build a project and its dependencies for a specific runtime (in this example, Ubuntu 16.04):

`dotnet build --runtime ubuntu.16.04-x64`
