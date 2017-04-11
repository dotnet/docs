---
title: dotnet-restore command - .NET Core CLI | Microsoft Docs
description: Learn how to restore dependencies and project-specific tools with the dotnet restore command.
keywords: dotnet-restore, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/24/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: fd7a5769-afbe-4838-bbaf-3ae0cfcbb914
---

# dotnet-restore

## Name

`dotnet-restore` - Restores the dependencies and tools of a project.

## Synopsis

`dotnet restore [<ROOT>] [-s|--source] [-r|--runtime] [--packages] [--disable-parallel] [--configfile] [--no-cache] [--ignore-failed-sources] [--no-dependencies] [-v|--verbosity] [-h|--help]`

## Description

The `dotnet restore` command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.

In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the *NuGet.config* configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own *NuGet.config* file in the project directory. You also specify additional feeds per invocation at a command prompt. 

For dependencies, you specify where the restored packages are placed during the restore operation using the `--packages` argument. If not specified, the default NuGet package cache is used, which is found in the `.nuget/packages` directory in the user's home directory on all operating systems (for example, */home/user1* on Linux or *C:\Users\user1* on Windows).

For project-specific tooling, `dotnet restore` first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.

The behavior of the `dotnet restore` command is affected by some of the settings in the *Nuget.Config* file, if present. For example, setting the `globalPackagesFolder` in *NuGet.Config* places the restored NuGet packages in the specified folder. This is an alternative to specifying the `--packages` option on the `dotnet restore` command. For more information, see the [NuGet.Config reference](https://docs.microsoft.com/nuget/schema/nuget-config-file).

## Arguments

`ROOT` 
    
Optional path to the project file to restore.

## Options

`-h|--help`

Prints out a short help for the command.

`-s|--source <SOURCE>`

Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the *NuGet.config* file(s). Multiple sources can be provided by specifying this option multiple times.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the `<RuntimeIdentifiers>` tag in the *.csproj* file. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Provide multiple RIDs by specifying this option multiple times.

`--packages <PACKAGES_DIRECTORY>`

Specifies the directory for restored packages. 

`--disable-parallel`

Disables restoring multiple projects in parallel. 

`--configfile <FILE>`

The NuGet configuration file (*NuGet.config*) to use for the restore operation.

`--no-cache`

Specifies to not cache packages and HTTP requests.

`--ignore-failed-sources`

Only warn about failed sources if there are packages meeting the version requirement.

`--no-dependencies`

When restoring a project with project-to-project (P2P) references, restore the root project and not the references.

`--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Restore dependencies and tools for the project in the current directory:

`dotnet restore` 

Restore dependencies and tools for the `app1` project found in the given path:

`dotnet restore ~/projects/app1/app1.csproj`
	
Restore the dependencies and tools for the project in the current directory using the file path provided as the source:

`dotnet restore -s c:\packages\mypackages` 

Restore the dependencies and tools for the project in the current directory using the two file paths provided as sources:

`dotnet restore -s c:\packages\mypackages -s c:\packages\myotherpackages` 

Restore dependencies and tools for the project in the current directory and shows only minimal output:

`dotnet restore --verbosity minimal`
