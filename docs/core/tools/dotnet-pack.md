---
title: dotnet-pack command - .NET Core CLI | Microsoft Docs
description: The dotnet-pack command creates NuGet packages for your .NET Core project.
keywords: dotnet-pack, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/15/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8dbbb3f7-b817-4161-a6c8-a3489d05e051
---

# dotnet-pack

## Name

`dotnet-pack` - Packs the code into a NuGet package.

## Synopsis

`dotnet pack [<PROJECT>] [-o|--output] [--no-build] [--include-symbols] [--include-source] [-c|--configuration] [--version-suffix <VERSION_SUFFIX>] [-s|--serviceable] [-v|--verbosity] [-h|--help]`

## Description

The `dotnet pack` command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the `--include-symbols` option is present, another package containing the debug symbols is created. 

NuGet dependencies of the packed project are added to the *.nuspec* file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.

By default, `dotnet pack` builds the project first. If you wish to avoid this behavior, pass the `--no-build` option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.

You can provide MSBuild properties to the `dotnet pack` command for the packing process. For more information, see [NuGet metadata properties](csproj.md#nuget-metadata-properties) and the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference).

## Arguments

`PROJECT` 
    
The project to pack. It's either a path to a [csproj file](csproj.md) or to a directory. If omitted, it defaults to the current directory. 

## Options

`-h|--help`

Prints out a short help for the command.  

`-o|--output <OUTPUT_DIRECTORY>`

Places the built packages in the directory specified. 

`--no-build`

Don't build the project before packing. 

`--include-symbols`

Generates the symbols `nupkg`. 

`--include-source`

Includes the source files in the NuGet package. The sources files are included in the `src` folder within the `nupkg`. 

`-c|--configuration <CONFIGURATION>`

Configuration to use when building the project. If not specified, configuration defaults to `Debug`.

`--version-suffix <VERSION_SUFFIX>`

Defines the value for the `$(VersionSuffix)` MSBuild property in the project.

`-s|--serviceable`

Sets the serviceable flag in the package. For more information, see [.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries](https://aka.ms/nupkgservicing).

`--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Pack the project in the current directory:

`dotnet pack`

Pack the `app1` project:

`dotnet pack ~/projects/app1/project.csproj`
	
Pack the project in the current directory and place the resulting packages into the `nupkgs` folder:

`dotnet pack --output nupkgs`

Pack the project in the current directory into the `nupkgs` folder and skip the build step:

`dotnet pack --no-build --output nupkgs`

With the project's version suffix configured as `<VersionSuffix>$(VersionSuffix)</VersionSuffix>` in the *.csproj* file, pack the current project and update the resulting package version with the given suffix:

`dotnet pack --version-suffix "ci-1234"`

Set the package version to `2.1.0` with the `PackageVersion` MSBuild property:

`dotnet pack /p:PackageVersion=2.1.0`
