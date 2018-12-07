---
title: dotnet tool list command
description: The dotnet tool list command lists the specified .NET Core Global Tool from your machine.
ms.date: 05/29/2018
---
# dotnet tool list

[!INCLUDE [topic-appliesto-net-core-21plus.md](../../../includes/topic-appliesto-net-core-21plus.md)]

## Name

`dotnet tool list` - Lists all [.NET Core Global Tools](global-tools.md) currently installed in the default directory on your machine or in the specified path.

## Synopsis

```console
dotnet tool list <-g|--global>
dotnet tool list <--tool-path>
dotnet tool list <-h|--help>
```

## Description

The `dotnet tool list` command provides a way for you to list all .NET Core Global Tools installed user-wide on your machine (current user profile) or in the specified path. The command lists the package name, version installed, and the Global Tool command. To use the list command, you either have to specify that you want to see all user-wide tools using the `--global` option or specify a custom path using the `--tool-path` option.

## Options

`-g|--global`

Lists user-wide Global Tools. Can't be combined with the `--tool-path` option. If you don't specify this option, you must specify the `--tool-path` option.

`-h|--help`

Prints out a short help for the command.

`--tool-path <PATH>`

Specifies a custom location where to find Global Tools. PATH can be absolute or relative. Can't be combined with the `--global` option. If you don't specify this option, you must specify the `--global` option.

## Examples

Lists all Global Tools installed user-wide on your machine (current user profile):

`dotnet tool list -g`

Lists the Global Tools from a specific Windows folder:

`dotnet tool list --tool-path c:\global-tools`

Lists the Global Tools from a specific Linux/macOS folder:

`dotnet tool list --tool-path ~/bin`

## See also

* [.NET Core Global Tools](global-tools.md)