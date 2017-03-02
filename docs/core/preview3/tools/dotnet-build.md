---
title: dotnet-build command | Microsoft Docs
description: The dotnet-build command builds a project and all of its dependencies. 
keywords: dotnet-build, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/13/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 5e1a2bc4-a919-4a86-8f33-a9b218b1fcb3
---

#dotnet-build (.NET Core Tools RC4)

> [!WARNING]
> This topic applies to .NET Core Tools RC4. For the .NET Core Tools Preview 2 version,
> see the [dotnet-build](../../tools/dotnet-build.md) topic.

## Name 
dotnet-build -- Builds a project and all of its dependencies 

## Synopsis

`dotnet build [--help] [--output]  [--framework]  
    [--configuration]  [--runtime] [--version-suffix]
    [--build-profile]  [--no-incremental] [--no-dependencies]
    [<project>]`

## Description

The `dotnet build` command builds multiple source file from a source project and its dependencies into a binary. 
By default, the resulting binary is in Intermediate Language (IL) and has a DLL extension. 
`dotnet build` also drops a `*.deps` file which outlines what the host needs to run the application.  

Building requires the existence of an asset file (a file that lists all of the dependencies of your application), which 
means that you have to run [`dotnet restore`](dotnet-restore.md) prior to building your code.

Before any compilation begins, the `build` verb analyzes the project and its dependencies for incremental safety checks.
If all checks pass, then build proceeds with incremental compilation of the project and its dependencies; 
otherwise, it falls back to non-incremental compilation. Via a profile flag, users can choose to receive additional 
information on how they can improve their build times.

In order to build an executable application instead of a library, you need to set the `<OutputType>` property:

```xml
<PropertyGroup>
    <OutputType>Exe</OutputType>
</PropertyGroup>
```

## Options

`-h|--help`

Prints out a short help for the command.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to place the built binaries. You also need to define `--framework` when you specify this option.

`-f|--framework <FRAMEWORK>`

Compiles for a specific framework. The framework needs to be defined in the [project file](csproj.md).

`-c|--configuration [Debug|Release]`

Defines a configuration under which to build.  If omitted, it defaults to `Debug`.

`-r|--runtime [RUNTIME_IDENTIFIER]`

Target runtime to build for. For a list of Runtime Identifiers (RIDs) you can use, see the [RID catalog](../../rid-catalog.md).

`--version-suffix [VERSION_SUFFIX]`

Defines what `*` should be replaced with in the version field in the project file. The format follows NuGet's version guidelines.

`--build-profile`

Prints out the incremental safety checks that users need to address in order for incremental compilation to be automatically turned on.

`--no-incremental`

Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project dependency graph.

`--no-dependencies`

Ignores project-to-project references and only builds the root project specified to build.

## Examples

Build a project and its dependencies:

`dotnet build`

Build a project and its dependencies using Release configuration:

`dotnet build --configuration Release`

Build a project and its dependencies for a specific runtime (in this example, Ubuntu 16.04):

`dotnet build --runtime ubuntu.16.04-x64`
