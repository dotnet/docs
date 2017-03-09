---
title: dotnet-build command | Microsoft Docs
description: The dotnet-build command builds a project and all of its dependencies. 
keywords: dotnet-build, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 5e1a2bc4-a919-4a86-8f33-a9b218b1fcb3
---
#dotnet-build

## Name

`dotnet-build` - Builds a project and all of its dependencies.

## Synopsis

```
dotnet build [project] [-o|--output] [-f|--framework] [-c|--configuration] [-r|--runtime] [--version-suffix] [--no-incremental] [--no-dependencies] [-v|--verbosity]
dotnet build [--help]
```

## Description
The `dotnet build` command builds the project and its dependencies into a set of binaries. The binaries are the symbol files used for debugging (having a `*.pdb` extension) as well as the project's code in Intermediate Language (IL) with a `*.dll` extension. Additionally, a JSON file that lists out the dependencies of the application with the `*.deps.json` extension will be produced. Finally, a `runtime.config.json` file will be produced as well. This file specifies which shared runtime and version the built code will run against. 

If the project has third-party dependencies, such as libraries from NuGet, these will be resolved from the NuGet cache and will not be available with the project's built output. With that in mind, the product of `dotnet build` is not ready to be transferred to another machine to run. This is in contrast to the behavior of .NET Framework in which building an executable project (an application) will produce an output that is possible to run on any machine that has .NET Framework installed. In order to get a similar experience in .NET Core, you have to use the [dotnet publish](dotnet-publish.md) command. More information about this can be found in the [.NET Core Application Deployment](../deploying/index.md) document. 

Building requires the existence of an *assets.json* file (a file that lists all of the dependencies of your application), which means that you have to run [`dotnet restore`](dotnet-restore.md) prior to building the project. Lack of the assets file manifests as the inability of the tooling to resolve reference assemblies which will result in errors. 

`dotnet build` uses MSBuild to build the project, thus it supports both parallel builds and incremental builds. Please refer to [MSBuild documentation](https://docs.microsoft.com/visualstudio/msbuild/msbuild) to get more information on those topics. 

In addition to its options, the `dotnet build` command will accept MSBuild options as well, such as `/p` for setting properties or `/l` to define a logger. You can find out more about these options in the [`dotnet msbuild`](dotnet-msbuild.md) command documentation. 

Whether the project is executable or not is determined by the `<OutputType>` property in the project file. The following example shows a project that will produce executable code: 


```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

In order to produce a library, simply omit that property. The main difference in output is that the IL DLL for a library will not contain any entry points and it will not be possible to execute it. 

## Arguments

`project`

The project file to build.
If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in `proj` and uses that file.

## Options

`-h|--help`

Prints out a short help for the command.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to place the built binaries. You also need to define `--framework` when you specify this option.

`-f|--framework <FRAMEWORK>`

Compiles for a specific framework. The framework needs to be defined in the [project file](csproj.md).

`-c|--configuration [Debug|Release]`

Defines a configuration under which to build. If omitted, it defaults to `Debug`.

`-r|--runtime [RUNTIME_IDENTIFIER]`

Target runtime to build for. For a list of Runtime Identifiers (RIDs) you can use, see the [RID catalog](../rid-catalog.md).

`--version-suffix [VERSION_SUFFIX]`

Defines what `*` should be replaced with in the version field in the project file. The format follows NuGet's version guidelines.

`--no-incremental`

Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project dependency graph.

`--no-dependencies`

Ignores project-to-project references and only builds the root project specified to build.

`-v|--verbosity`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Build a project and its dependencies:

`dotnet build`

Build a project and its dependencies using Release configuration:

`dotnet build --configuration Release`

Build a project and its dependencies for a specific runtime (in this example, Ubuntu 16.04):

`dotnet build --runtime ubuntu.16.04-x64`
