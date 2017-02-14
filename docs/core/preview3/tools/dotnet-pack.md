---
title: dotnet-pack command | Microsoft Docs
description: The dotnet-pack command creates NuGet packages for your .NET Core project.
keywords: dotnet-pack, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/12/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8dbbb3f7-b817-4161-a6c8-a3489d05e051
---

#dotnet-pack (.NET Core Tools RC4)

> [!WARNING]
> This topic applies to .NET Core Tools RC4. For the .NET Core Tools Preview 2 version,
> see the [dotnet-pack](../../tools/dotnet-pack.md) topic.

## Name

`dotnet-pack` - Packs the code into a NuGet package.

## Synopsis

`dotnet pack [--help] [--output]  
    [--no-build] [--include-symbols]
    [--include-source] [--servicable]
    [--configuration]  [--version-suffix]
    [project]`  

## Description

The `dotnet pack` command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the `--include-symbols` 
option is present, another package containing the debug symbols will be created. 

NuGet dependencies of the project being packed are added to the `nuspec` file, so they are able to be resolved when the package is installed. 
Project-to-project references are not packaged inside the project. Currently, you need to have a package per project if you have project-to-project dependencies.

`dotnet pack` by default first builds the project. If you wish to avoid this, pass the `--no-build` option. This can be useful in Continuous Integration (CI) build scenarios in which you know the code was just previously built, for example. 

## Options

`-h|--help`

Prints out a short help for the command.  

`[project]` 
    
The project to pack. It can be either a path to a [csproj file](csproj.md) or to a directory. If omitted, it will
default to the current directory. 

`-o|--output <OUTPUT_DIRECTORY>`

Places the built packages in the directory specified. 

`--no-build`

Does not build the project before packing. 

`--include-source`

Includes the source files in the NuGet package. The sources files are included in the `src` folder within the `nupkg`. 

`--include-symbols`

Generate the symbols nupkg. 

`-c|--configuration <Debug|Release>`

Configuration to use when building the project. If not specified, will default to `Debug`.

`--version-suffix`

Updates the star in `-*` package version suffix with a specified string.

## Examples

Pack the project in the current directory:

`dotnet pack`

Pack the app1 project:

`dotnet pack ~/projects/app1/project.csproj`
	
Pack the project in the current directory and place the resulting packages into the specified folder:

`dotnet pack --output nupkgs`

Pack the project in the current directory into the specified folder and skip the build step:

`dotnet pack --no-build --output nupkgs`

Pack the current project and updates the resulting packages version with the given suffix. For example, version `1.0.0-*` will be updated to `1.0.0-ci-1234`.

`dotnet pack --version-suffix "ci-1234"`