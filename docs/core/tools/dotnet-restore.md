---
title: dotnet restore command - .NET Core CLI
description: Learn how to restore dependencies and project-specific tools with the dotnet restore command.
keywords: dotnet-restore, CLI, CLI command, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 11/30/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet restore

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet restore` - Restores the dependencies and tools of a project.

## Synopsis

# [.NET Core 2.x](#tab/netcore2x)

```
dotnet restore [<ROOT>] [--configfile] [--disable-parallel] [--force] [--ignore-failed-sources] [--no-cache] [--no-dependencies] [--packages] [-r|--runtime] [-s|--source] [-v|--verbosity]
dotnet restore [-h|--help]
```

# [.NET Core 1.x](#tab/netcore1x)

```
dotnet restore [<ROOT>] [--configfile] [--disable-parallel] [--ignore-failed-sources] [--no-cache] [--no-dependencies] [--packages] [-r|--runtime] [-s|--source] [-v|--verbosity]
dotnet restore [-h|--help]
```

---

## Description

The `dotnet restore` command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the *NuGet.config* configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own *NuGet.config* file in the project directory. You also specify additional feeds per invocation at a command prompt.

For dependencies, you specify where the restored packages are placed during the restore operation using the `--packages` argument. If not specified, the default NuGet package cache is used, which is found in the `.nuget/packages` directory in the user's home directory on all operating systems (for example, */home/user1* on Linux or *C:\Users\user1* on Windows).

For project-specific tooling, `dotnet restore` first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.

The behavior of the `dotnet restore` command is affected by some of the settings in the *Nuget.Config* file, if present. For example, setting the `globalPackagesFolder` in *NuGet.Config* places the restored NuGet packages in the specified folder. This is an alternative to specifying the `--packages` option on the `dotnet restore` command. For more information, see the [NuGet.Config reference](/nuget/schema/nuget-config-file).

## Implicit `dotnet restore`

Starting with .NET Core 2.0, `dotnet restore` is run implicitly if necessary when you issue the following commands:

- [`dotnet new`](dotnet-new.md)
- [`dotnet build`](dotnet-build.md)
- [`dotnet run`](dotnet-run.md)
- [`dotnet test`](dotnet-test.md)
- [`dotnet publish`](dotnet-publish.md)
- [`dotnet pack`](dotnet-pack.md)

In most cases, you no longer need to explicitly use the `dotnet restore` command. 

In some cases, it is inconvenient for `dotnet restore` to run implicitly. For example, some automated systems, such as build systems, need to call `dotnet restore` explicitly to control when the restore occurs so that they can control network usage. To prevent `dotnet restore` from running implicitly, you can use the `--no-restore` switch with any of these commands to disable implicit restore.

## Arguments

`ROOT`

Optional path to the project file to restore.

## Options

# [.NET Core 2.x](#tab/netcore2x)

`--configfile <FILE>`

The NuGet configuration file (*NuGet.config*) to use for the restore operation.

`--disable-parallel`

Disables restoring multiple projects in parallel.

`--force`

Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the *project.assets.json* file.

`-h|--help`

Prints out a short help for the command.

`--ignore-failed-sources`

Only warn about failed sources if there are packages meeting the version requirement.

`--no-cache`

Specifies to not cache packages and HTTP requests.

`--no-dependencies`

When restoring a project with project-to-project (P2P) references, restores the root project and not the references.

`--packages <PACKAGES_DIRECTORY>`

Specifies the directory for restored packages.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the `<RuntimeIdentifiers>` tag in the *.csproj* file. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Provide multiple RIDs by specifying this option multiple times.

`-s|--source <SOURCE>`

Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the *NuGet.config* files. Multiple sources can be provided by specifying this option multiple times.

`--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

# [.NET Core 1.x](#tab/netcore1x)

`--configfile <FILE>`

The NuGet configuration file (*NuGet.config*) to use for the restore operation.

`--disable-parallel`

Disables restoring multiple projects in parallel.

`-h|--help`

Prints out a short help for the command.

`--ignore-failed-sources`

Only warn about failed sources if there are packages meeting the version requirement.

`--no-cache`

Specifies to not cache packages and HTTP requests.

`--no-dependencies`

When restoring a project with project-to-project (P2P) references, restores the root project and not the references.

`--packages <PACKAGES_DIRECTORY>`

Specifies the directory for restored packages.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the `<RuntimeIdentifiers>` tag in the *.csproj* file. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Provide multiple RIDs by specifying this option multiple times.

`-s|--source <SOURCE>`

Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the *NuGet.config* files. Multiple sources can be provided by specifying this option multiple times.

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
