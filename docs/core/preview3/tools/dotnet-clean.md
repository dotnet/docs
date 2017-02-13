---
title: dotnet-clean command | Microsoft Docs
description: The dotnet-clean command cleans the current directory.
keywords: dotnet-clean, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 01/31/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: eff65fa1-bab4-4421-8260-d0a284b690b2
---

#dotnet-clean

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name 
`dotnet-clean` -- Cleans the output of a project. 

## Synopsis

`dotnet clean [--help] [--output]  [--framework]  
    [--configuration]  [--verbosity]
    [<project>]`

## Description
The `dotnet clean` command will clean the output of the previous build. It is implemented as an MSBuild target, so the project will get evaluated. Only the outputs that were created during the build are cleaned. Both intermediate (`obj`) and final output (`bin`) folders are cleaned. 

## Options

`-h|--help`

Prints out a short help for the command.  

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which the built binaries were placed. You also need to define `--framework` when you specify this option. If you didn't specify this property during build time, you don't have to specify it for clean.

`-f|--framework <FRAMEWORK>`

The framework that was specified at build time. If you didn't specify this property during build time, you don't have to specify it for clean. The framework needs to be defined in the [project file](csproj.md).

`-c|--configuration [Debug|Release]`

Defines a configuration under which the build was running.  If omitted, it defaults to `Debug`. If you didn't specify this property during build time, you don't have to specify it for clean.

`-v|--verbosity [Quiet|Minimal|Normal|Diag]`

Defines verbosity to use for the invocation of the `dotnet clean` command. The verbosity levels are standard [MSBuild verbosity levels](https://msdn.microsoft.com/en-us/library/ms164311.aspx). 


## Examples

Clean a default build of the project:

`dotnet clean`

Clean a project built using the Release configuration:

`dotnet clean --configuration Release`
