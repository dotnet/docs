---
title: dotnet-restore command | .NET Core SDK
description: Learn how to restore dependencies and project-specific tools with the dotnet restore command 
keywords: dotnet-restore, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/07/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 60489b25-38de-47e6-bed1-59d9f42e2d46
---

#dotnet-restore

## Name

`dotnet-restore` - Restores the dependencies and tools of a project.

## Synopsis

`dotnet restore [root] [--help] [--force-english-output] [--source]  
    [--packages] [--disable-parallel] [--fallbacksource] [--configfile] 
    [--no-cache] [--infer-runtimes] [--verbosity] [--ignore-failed-sources]`

## Description

The `dotnet restore` command uses NuGet to restore dependencies as well as project-specific tools that are specified in the [project.json](project-json.md) file. 
By default, the restoration of dependencies and tools are done in parallel.

In order to restore the dependencies, NuGet needs the feeds where the packages are located. 
Feeds are usually provided via the NuGet.config configuration file; a default one is present when the CLI tools are installed. 
You can specify more feeds by creating your own NuGet.config file in the project directory. 
Feeds can also be specified per invocation on the command prompt. 

For dependencies, you can specify where the restored packages are placed during the restore operation using the 
`--packages` argument. 
If not specified, the default NuGet package cache is used. 
It is found in the `.nuget/packages` directory in the user's home directory on all operating systems (for example, */home/user1* on Linux or *C:\Users\user1* on Windows).

For project-specific tooling, `dotnet restore` first restores the package in which the tool is packed, and then
proceeds to restore the tool's dependencies as specified in its [project.json](project-json.md). 

## Options

`[root]` 
    
 A list of projects or project folders to restore. Each value can be a path to a [project.json](project-json.md) or [global.json](global-json.md) file, or to a folder. If a folder is specified, the restore operation will recursively search for a [project.json](project-json.md) file in all subdirectories and restores for each [project.json](project-json.md) file found.

`-h|--help`

Prints out a short help for the command.

 `--force-english-output`

Forces the application to run using an invariant, English-based culture.

`-s|--source <SOURCE>`

Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the NuGet.config file(s). Multiple sources can be provided by specifying this option multiple times.

`--packages <PACKAGES_DIRECTORY]`

Specifies the directory to place the restored packages in. 

`--disable-parallel`

Disables restoring multiple projects in parallel. 

`-f|--fallbacksource <FEED>`

Specifies a list of packages sources to use as a fallback in the restore operation if all other sources fail. All valid feed formats are allowed. Multiple fallback sources can be provided by specifying this option multiple times.

`--configfile <FILE>`

The NuGet configuration file (NuGet.config) to use for the restore operation.

`--no-cache`

Specifies to not cache packages and HTTP requests.

`--infer-runtimes`

Temporary option to allow NuGet to infer Runtime Identifiers (RIDs) for legacy repositories.

`--verbosity [LEVEL]`

The verbosity of logging to use. Allowed values: `Debug`, `Verbose`, `Information`, `Minimal`, `Warning`, or `Error`.

` --ignore-failed-sources`

Only warn about failed sources if there are packages meeting version requirement.

## Examples

Restore dependencies and tools for the project in the current directory:

`dotnet restore` 

Restore dependencies and tools for the `app1` project found in the given path:

`dotnet restore ~/projects/app1/project.json`
	
Restore the dependencies and tools for the project in the current directory using the file path provided as the fallback source:

`dotnet restore -f c:\packages\mypackages` 

Restore the dependencies and tools for the project in the current directory using the two file paths provided as the fallback sources:

`dotnet restore -f c:\packages\mypackages -f c:\packages\myotherpackages` 

Restore dependencies and tools for the project in the current directory and shows only errors in the output:

`dotnet restore --verbosity Error`