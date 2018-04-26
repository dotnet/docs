---
title: dotnet tool install command - .NET Core CLI
description: The dotnet tool install command installs the specified .NET Core Global Tool on your machine.
author: mairaw
ms.author: mairaw
ms.date: 04/25/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet tool install

[!INCLUDE [topic-appliesto-net-core-2-1plus.md](../../../includes/topic-appliesto-net-core-2-1plus.md)]

## Name

`dotnet tool install` - Installs the specified [.NET Core Global Tool](global-tools.md) on your machine.

## Synopsis

```
dotnet tool install <PACKAGE_ID> <-g|--global> [--configfile] [-f|--framework] [--source-feed] [-v|--verbosity] [--version]
dotnet tool install <PACKAGE_ID> <--tool-path> [--configfile] [-f|--framework] [--source-feed] [-v|--verbosity] [--version]
dotnet tool install [-h|--help]
```

## Description

The `dotnet tool install` command provides a way for you to install .NET Core Global Tools on your machine. To use the command, you either have to specify that you want a user-wide installation using the `--global` option or you specify a path to install it using the `--tool-path` option.

## Arguments

`PACKAGE_ID`

ID of the NuGet package that contains the .NET Core Global tool to install.

## Options

`--configfile <FILE>`

The NuGet configuration (*nuget.config*) file to use.

`-f|--framework <FRAMEWORK>`

Specifies the [target framework](../../standard/frameworks.md) to install the tool for.

`-g|--global`

Specifies that the installation is user wide. If you don't specify this option, you must specify the `--tool-path` option.

`-h|--help`

Prints out a short help for the command.

`--source-feed <SOURCE_FEED>`

Adds an additional NuGet package source to use during installation.

`--tool-path <PATH>`

Specifies the location where to install the global tool. PATH can be absolute or relative. If PATH doesn't exist, the command tries to create it. Can't be combined with the `--global` option.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version <VERSION_NUMBER>`

The version of the tool to install. By default, the latest stable package version is installed.

## Examples

Installs the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) sample Global Tool:

`dotnet tool install -g dotnetsay`

Installs the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) sample Global Tool on a specific Windows folder:

`dotnet tool install dotnetsay --tool-path c:\global-tools`

Installs version 1.0.0 of the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) sample Global Tool:

`dotnet tool install -g dotnetsay --version 1.0.0`