---
title: dotnet tool update command - .NET Core CLI
description: The dotnet tool update command updates the specified .NET Core Global Tool on your machine.
author: mairaw
ms.author: mairaw
ms.date: 04/25/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet tool update

[!INCLUDE [topic-appliesto-net-core-2-1plus.md](../../../includes/topic-appliesto-net-core-2-1plus.md)]

## Name

`dotnet tool update` - Updates the specified [.NET Core Global Tool](global-tools.md) on your machine.

## Synopsis

```
dotnet tool update <PACKAGE_ID> <-g|--global> [--configfile] [-f|--framework] [--source-feed] [-v|--verbosity]
dotnet tool update <PACKAGE_ID> <--tool-path> [--configfile] [-f|--framework] [--source-feed] [-v|--verbosity]
dotnet tool update [-h|--help]
```

## Description

The `dotnet tool update` command provides a way for you to update .NET Core Global Tools on your machine to the latest stable version of the package. The command uninstalls and reinstalls a tool, effectively updating it. To use the command, you either have to specify that you want to update a tool from a user-wide installation using the `--global` option or specify a path to where the tool is installed using the `--tool-path` option.

## Arguments

`PACKAGE_ID`

ID of the NuGet package that contains the .NET Core Global tool to update.

## Options

`--configfile <FILE>`

The NuGet configuration (*nuget.config*) file to use.

`-f|--framework <FRAMEWORK>`

Specifies the [target framework](../../standard/frameworks.md) to update the tool for.

`-g|--global`

Specifies that the update is for a user-wide tool. If you don't specify this option, you must specify the `--tool-path` option.

`-h|--help`

Prints out a short help for the command.

`--source-feed <SOURCE_FEED>`

Adds an additional NuGet package source to use during the update.

`--tool-path <PATH>`

Specifies the location where the global tool is installed. PATH can be absolute or relative. Can't be combined with the `--global` option.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) sample Global Tool:

`dotnet tool update -g dotnetsay`

Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) sample Global Tool located on a specific Windows folder:

`dotnet tool update dotnetsay --tool-path c:\global-tools`

## See also

[.NET Core Global Tool](global-tools.md)