---
title: dotnet restore command
description: Learn how to restore dependencies and project-specific tools with the dotnet restore command.
keywords: dotnet restore, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: fd7a5769-afbe-4838-bbaf-3ae0cfcbb914
---

# dotnet restore

## Name

`dotnet restore` - Restores the dependencies and tools of a project.

## Synopsis

`dotnet restore [<ROOT>] [--configfile] [--disable-parallel] [-h|--help] [--ignore-failed-sources] [--no-cache] [--no-dependencies] [--packages] [-r|--runtime] [-s|--source] [-v|--verbosity]`

## Description

The `dotnet restore` command uses NuGet to restore dependencies and project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel. The outputs of `dotnet restore` are placed in an intermediate outputs folder named *obj*.

In order to restore dependencies, NuGet requires feed locations where the packages are located. Feeds are usually provided with the *NuGet.config* configuration file. A default configuration file is provided when the CLI tools are installed.

You can specify additional feeds by creating your own *NuGet.config* file in the project directory. For example when you need to obtain packages from the "nightly" development feed for bleeding edge ASP.NET Core development, you can specify the ASP.NET Core "dev" branch feed (`aspnetcore-dev`) by placing a *NuGet.config* file in the project's directory that includes the development feed:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="aspnetcore-dev" value="https://dotnet.myget.org/F/aspnetcore-dev/api/v2/" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

You can also specify additional feeds when running the `dotnet restore` command at a command prompt using the `--configfile <FILE>` or `-s|--source <SOURCE>` options. `--configfile <FILE>` specifies a config file, while `-s|--source <SOURCE>` specifies a NuGet package source.

For dependencies, you specify where the restored packages are placed during the restore operation using the `--packages <PACKAGES_DIRECTORY>` option. If not specified, the default NuGet package cache is used, which is found in the `.nuget/packages` directory in the user's home directory on all operating systems (for example, */home/user1* on Linux or *C:\Users\user1* on Windows).

For project-specific tooling, `dotnet restore` first restores the package in which the tool is packed and then proceeds to restore the tool's dependencies as specified in its project file.

Settings in a *Nuget.Config* file affect the behavior of the `dotnet restore` command. For example, setting the `globalPackagesFolder` in *NuGet.Config* places the restored NuGet packages in the specified folder. This is an alternative to specifying the `--packages` option on the `dotnet restore` command. For more information, see the [NuGet.Config reference](/nuget/schema/nuget-config-file).

## Arguments

`ROOT` 
    
Optional path to the project file to restore.

## Options

`--configfile <FILE>`

Specifies the NuGet configuration file (*NuGet.config*) to use for the restore operation.

`--disable-parallel`

Disables restoring multiple projects in parallel. 

`-h|--help`

Shows help information.

`--ignore-failed-sources`

Treat package source failures as warnings.

`--no-cache`

Specifies to not cache packages and HTTP requests.

`--no-dependencies`

When restoring a project with project-to-project (P2P) references, restore the root project and not the references.

`--packages <PACKAGES_DIRECTORY>`

Specifies the directory for restored packages. 

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the `<RuntimeIdentifiers>` tag in the *csproj* file. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Provide multiple RIDs by specifying this option and value multiple times.

`-s|--source <SOURCE>`

Specifies a NuGet package source to use during the restore operation. This overrides the sources specified in the *NuGet.config* files. Specify multiple sources by specifying this option/value multiple times.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Restore dependencies and tools for the project in the current directory:

`dotnet restore` 

Restore dependencies and tools for the `app1` project found on a path:

`dotnet restore ~/projects/app1/app1.csproj`
	
Restore the dependencies and tools for the project in the current directory using the file path provided as the source:

`dotnet restore -s c:\packages\mypackages` 

Restore the dependencies and tools for the project in the current directory using two file paths provided as sources:

`dotnet restore -s c:\packages\mypackages -s c:\packages\myotherpackages` 

Restore dependencies and tools for the project in the current directory and show minimal output:

`dotnet restore --verbosity minimal`
