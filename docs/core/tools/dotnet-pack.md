---
title: dotnet pack command
description: The 'dotnet pack' command creates NuGet packages for your .NET Core project.
keywords: dotnet pack, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8dbbb3f7-b817-4161-a6c8-a3489d05e051
---

# dotnet pack

## Name

`dotnet pack` - Packs the code into a NuGet package.

## Synopsis

`dotnet pack [<PROJECT>] [-c|--configuration] [-h|--help] [--include-source] [--include-symbols] [--no-build] [-o|--output] [-s|--serviceable] [-v|--verbosity] [--version-suffix]`

## Description

The `dotnet pack` command builds the project and creates NuGet packages. If the `--include-symbols` option is present, another package containing the debug symbols is created. 

NuGet dependencies of the packed project are added to the *nuspec* file and properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.

By default, `dotnet pack` builds the project first. If you wish to avoid this behavior, pass the `--no-build` option. This is often useful in Continuous Integration (CI) build scenarios when the code was previously built.

You can provide MSBuild properties to the `dotnet pack` command for the packing process. For more information, see [NuGet metadata properties](csproj.md#nuget-metadata-properties) and the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference).

## Arguments

`PROJECT` 
    
The project to pack. It's either a path to a [*csproj* file](csproj.md) or to a directory. If omitted, the command defaults to the project in the current directory. 

## Options

`-c|--configuration <CONFIGURATION>`

Specifies the build configuration. If not specified, the configuration defaults to `Debug`.

`-h|--help`

Shows help information.

`--include-source`

Includes the source files in the NuGet package. The sources files are included in the *src* folder within the *nupkg*.

`--include-symbols`

Generates the symbols *nupkg*.

`--no-build`

Disables building the project before packing.

`-o|--output <OUTPUT_DIRECTORY>`

Places the built packages in the directory specified.

`-s|--serviceable`

Sets the serviceable flag in the package. For more information, see [.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries](https://aka.ms/nupkgservicing).

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version-suffix <VERSION_SUFFIX>`

Defines the value for the `$(VersionSuffix)` MSBuild property in the project.

## Examples

Pack the project in the current directory:

`dotnet pack`

Pack the `app1` project:

`dotnet pack ~/projects/app1/project.csproj`
	
Pack the project in the current directory and place the resulting packages into the *nupkgs* folder:

`dotnet pack --output nupkgs`

Pack the project in the current directory into the *nupkgs* folder and skip the build step:

`dotnet pack --no-build --output nupkgs`

With the project's version suffix configured as `<VersionSuffix>$(VersionSuffix)</VersionSuffix>` in the *csproj* file, pack the current project and update the resulting package version with a suffix:

`dotnet pack --version-suffix "ci-1234"`

Set the package version to `2.1.0` with the `PackageVersion` MSBuild property:

`dotnet pack /p:PackageVersion=2.1.0`
