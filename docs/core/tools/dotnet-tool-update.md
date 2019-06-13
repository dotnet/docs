---
title: dotnet tool update command
description: The dotnet tool update command updates the specified .NET Core Global Tool on your machine.
ms.date: 05/29/2018
---
# dotnet tool update

[!INCLUDE [topic-appliesto-net-core-21plus.md](../../../includes/topic-appliesto-net-core-21plus.md)]

## Name

`dotnet tool update` - Updates the specified [.NET Core Global Tool](global-tools.md) on your machine.

## Synopsis

```console
dotnet tool update <PACKAGE_NAME> <-g|--global> [--configfile] [--framework] [-v|--verbosity]
dotnet tool update <PACKAGE_NAME> <--tool-path> [--configfile] [--framework] [-v|--verbosity]
dotnet tool update <-h|--help>
```

## Description

The `dotnet tool update` command provides a way for you to update .NET Core Global Tools on your machine to the latest stable version of the package. The command uninstalls and reinstalls a tool, effectively updating it. To use the command, you either have to specify that you want to update a tool from a user-wide installation using the `--global` option or specify a path to where the tool is installed using the `--tool-path` option.

## Arguments

`PACKAGE_NAME`

Name/ID of the NuGet package that contains the .NET Core Global Tool to update. You can find the package name using the [dotnet tool list](dotnet-tool-list.md) command.

## Options

`--add-source <SOURCE>`

Adds an additional NuGet package source to use during installation.

`--configfile <FILE>`

The NuGet configuration (*nuget.config*) file to use.

`--framework <FRAMEWORK>`

Specifies the [target framework](../../standard/frameworks.md) to update the tool for.

`-g|--global`

Specifies that the update is for a user-wide tool. Can't be combined with the `--tool-path` option. If you don't specify this option, you must specify the `--tool-path` option.

`-h|--help`

Prints out a short help for the command.

`--tool-path <PATH>`

Specifies the location where the Global Tool is installed. PATH can be absolute or relative. Can't be combined with the `--global` option. If you don't specify this option, you must specify the `--global` option.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool:

`dotnet tool update -g dotnetsay`

Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool located on a specific Windows folder:

`dotnet tool update dotnetsay --tool-path c:\global-tools`

Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool located on a specific Linux/macOS folder:

`dotnet tool update dotnetsay --tool-path ~/bin`

## See also

- [.NET Core Global Tools](global-tools.md)
