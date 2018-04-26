---
title: dotnet tool uninstall command - .NET Core CLI
description: The dotnet tool uninstall command uninstalls the specified .NET Core Global Tool from your machine.
author: mairaw
ms.author: mairaw
ms.date: 04/25/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet tool uninstall

[!INCLUDE [topic-appliesto-net-core-2-1plus.md](../../../includes/topic-appliesto-net-core-2-1plus.md)]

## Name

`dotnet tool uninstall` - Uninstalls the specified [.NET Core Global Tool](global-tools.md) from your machine.

## Synopsis

```
dotnet tool uninstall <PACKAGE_ID> <-g|--global>
dotnet tool uninstall <PACKAGE_ID> <--tool-path>
dotnet tool uninstall [-h|--help]
```

## Description

The `dotnet tool uninstall` command provides a way for you to uninstall .NET Core Global Tools from your machine. To use the command, you either have to specify that you want to remove a user-wide tool using the `--global` option or specify a path to where the tool is installed using the `--tool-path` option.

## Arguments

`PACKAGE_ID`

ID of the NuGet package that contains the .NET Core Global tool to uninstall.

## Options

`-g|--global`

Specifies that the tool to be removed is from a user-wide installation. If you don't specify this option, you must specify the `--tool-path` option.

`-h|--help`

Prints out a short help for the command.

`--tool-path <PATH>`

Specifies the location where to uninstall the global tool. PATH can be absolute or relative. Can't be combined with the `--global` option.

## Examples

Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) sample Global Tool:

`dotnet tool uninstall -g dotnetsay`

Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) sample Global Tool from a specific Windows folder:

`dotnet tool uninstall dotnetsay --tool-path c:\global-tools`

## See also

[.NET Core Global Tool](global-tools.md)