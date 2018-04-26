---
title: dotnet tool list command - .NET Core CLI
description: The dotnet tool list command lists the specified .NET Core Global Tool from your machine.
author: mairaw
ms.author: mairaw
ms.date: 04/25/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet tool list

[!INCLUDE [topic-appliesto-net-core-2-1plus.md](../../../includes/topic-appliesto-net-core-2-1plus.md)]

## Name

`dotnet tool list` - Lists all [.NET Core Global Tools](global-tools.md) currently installed on your machine or specified path.

## Synopsis

```
dotnet tool list <-g|--global>
dotnet tool list <--tool-path>
dotnet tool list [-h|--help]
```

## Description

The `dotnet tool list` command provides a way for you to list all .NET Core Global Tools installed on your machine (current user profile) or specified path. The command lists the package name, version installed, and the global tool command. To use the list command, you either have to specify that you want to see all user-wide tools using the `--global` option or specify a custom path using the `--tool-path` option.

## Options

`-g|--global`

Specifies that the tool to be removed is from a user-wide installation. If you don't specify this option, you must specify the `--tool-path` option.

`-h|--help`

Prints out a short help for the command.

`--tool-path <PATH>`

Specifies a custom location where to find global tools. PATH can be absolute or relative. Can't be combined with the `--global` option.

## Examples

Lists all Global Tools installed in your machine (current user profile):

`dotnet tool list -g`

Lists the sample Global Tools from a specific Windows folder:

`dotnet tool list --tool-path c:\global-tools`

## See also

[.NET Core Global Tool](global-tools.md)