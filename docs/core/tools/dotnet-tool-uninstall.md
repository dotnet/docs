---
title: dotnet tool uninstall command
description: The dotnet tool uninstall command uninstalls the specified .NET Core Global Tool from your machine.
ms.date: 05/29/2018
---
# dotnet tool uninstall

[!INCLUDE [topic-appliesto-net-core-21plus.md](../../../includes/topic-appliesto-net-core-21plus.md)]

## Name

`dotnet tool uninstall` - Uninstalls the specified [.NET Core Global Tool](global-tools.md) from your machine.

## Synopsis

```dotnetcli
dotnet tool uninstall <PACKAGE_NAME> <-g|--global>
dotnet tool uninstall <PACKAGE_NAME> <--tool-path>
dotnet tool uninstall <-h|--help>
```

## Description

The `dotnet tool uninstall` command provides a way for you to uninstall .NET Core Global Tools from your machine. To use the command, you either have to specify that you want to remove a user-wide tool using the `--global` option or specify a path to where the tool is installed using the `--tool-path` option.

## Arguments

`PACKAGE_NAME`

Name/ID of the NuGet package that contains the .NET Core Global Tool to uninstall. You can find the package name using the [dotnet tool list](dotnet-tool-list.md) command.

## Options

`-g|--global`

Specifies that the tool to be removed is from a user-wide installation. Can't be combined with the `--tool-path` option. If you don't specify this option, you must specify the `--tool-path` option.

`-h|--help`

Prints out a short help for the command.

`--tool-path <PATH>`

Specifies the location where to uninstall the Global Tool. PATH can be absolute or relative. Can't be combined with the `--global` option. If you don't specify this option, you must specify the `--global` option.

## Examples

Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool:

`dotnet tool uninstall -g dotnetsay`

Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool from a specific Windows folder:

`dotnet tool uninstall dotnetsay --tool-path c:\global-tools`

Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool from a specific Linux/macOS folder:

`dotnet tool uninstall dotnetsay --tool-path ~/bin`

## See also

- [.NET Core Global Tools](global-tools.md)
