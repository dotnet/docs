---
title: dotnet-pack command | Microsoft Docs
description: The dotnet-pack command creates NuGet packages for your .NET Core project.
keywords: dotnet-pack, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8dbbb3f7-b817-4161-a6c8-a3489d05e051
---
#dotnet-pack

## Name

`dotnet-pack` - Packs the code into a NuGet package.

## Synopsis

```
dotnet pack [<PROJECT>] [-o|--output] [--no-build] [--include-symbols] [--include-source] [-c|--configuration] [--version-suffix] [-s|--serviceable] [-v|--verbosity]
dotnet pack [-h|--help]
```

## Description

The `dotnet pack` command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the `--include-symbols` 
option is present, another package containing the debug symbols will be created. 

NuGet dependencies of the project being packed are added to the `nuspec` file, so they are able to be resolved when the package is installed. 
Project-to-project references are not packaged inside the project. Currently, you need to have a package per project if you have project-to-project dependencies.

`dotnet pack` by default first builds the project. If you wish to avoid this, pass the `--no-build` option. This can be useful in Continuous Integration (CI) build scenarios in which you know the code was just previously built, for example. 

## Arguments

`PROJECT` 
    
The project to pack. It can be either a path to a [csproj file](csproj.md) or to a directory. If omitted, it will
default to the current directory. 

## Options

`-h|--help`

Prints out a short help for the command.  

`-o|--output <OUTPUT_DIRECTORY>`

Places the built packages in the directory specified. 

`--no-build`

Does not build the project before packing. 

`--include-symbols`

Generates the symbols nupkg. 

`--include-source`

Includes the source files in the NuGet package. The sources files are included in the `src` folder within the `nupkg`. 

`-c|--configuration <Debug|Release>`

Configuration to use when building the project. If not specified, will default to `Debug`.

`--version-suffix <VERSION_SUFFIX>`

Defines the value for the $(VersionSuffix) MSBuild property in the project.

`-s|--serviceable`

Sets the serviceable flag in the package. For more information, see https://aka.ms/nupkgservicing.

`--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

## Examples

Pack the project in the current directory:

`dotnet pack`

Pack the app1 project:

`dotnet pack ~/projects/app1/project.csproj`
	
Pack the project in the current directory and place the resulting packages into the specified folder:

`dotnet pack --output nupkgs`

Pack the project in the current directory into the specified folder and skip the build step:

`dotnet pack --no-build --output nupkgs`

Pack the current project and updates the resulting package version with the given suffix. The project's version suffix is configured as `<VersionSuffix>$(VersionSuffix)</VersionSuffix>` in the *.csproj*  file.

`dotnet pack --version-suffix "ci-1234"`
