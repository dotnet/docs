---
title: dotnet tool install command
description: The dotnet tool install command installs the specified .NET Core Global Tool on your machine.
ms.date: 05/29/2018
---
# dotnet tool install

[!INCLUDE [topic-appliesto-net-core-21plus.md](../../../includes/topic-appliesto-net-core-21plus.md)]

## Name

`dotnet tool install` - Installs the specified [.NET Core Global Tool](global-tools.md) on your machine.

## Synopsis

```dotnetcli
dotnet tool install <PACKAGE_NAME> <-g|--global> [--add-source] [--configfile] [--framework] [-v|--verbosity] [--version]
dotnet tool install <PACKAGE_NAME> <--tool-path> [--add-source] [--configfile] [--framework] [-v|--verbosity] [--version]
dotnet tool install <-h|--help>
```

## Description

The `dotnet tool install` command provides a way for you to install .NET Core Global Tools on your machine. To use the command, you either have to specify that you want a user-wide installation using the `--global` option or you specify a path to install it using the `--tool-path` option.

Global Tools are installed in the following directories by default when you specify the `-g` (or `--global`) option:

| OS          | Path                          |
|-------------|-------------------------------|
| Linux/macOS | `$HOME/.dotnet/tools`         |
| Windows     | `%USERPROFILE%\.dotnet\tools` |

## Arguments

`PACKAGE_NAME`

Name/ID of the NuGet package that contains the .NET Core Global Tool to install.

## Options

`--add-source <SOURCE>`

Adds an additional NuGet package source to use during installation.

`--configfile <FILE>`

The NuGet configuration (*nuget.config*) file to use.

`--framework <FRAMEWORK>`

Specifies the [target framework](../../standard/frameworks.md) to install the tool for. By default, the .NET Core SDK tries to choose the most appropriate target framework.

`-g|--global`

Specifies that the installation is user wide. Can't be combined with the `--tool-path` option. If you don't specify this option, you must specify the `--tool-path` option.

`-h|--help`

Prints out a short help for the command.

`--tool-path <PATH>`

Specifies the location where to install the Global Tool. PATH can be absolute or relative. If PATH doesn't exist, the command tries to create it. Can't be combined with the `--global` option. If you don't specify this option, you must specify the `--global` option.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version <VERSION_NUMBER>`

The version of the tool to install. By default, the latest stable package version is installed. Use this option to install preview or older versions of the tool.

## Examples

Installs the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool in the default location:

`dotnet tool install -g dotnetsay`

Installs the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool on a specific Windows folder:

`dotnet tool install dotnetsay --tool-path c:\global-tools`

Installs the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool on a specific Linux/macOS folder:

`dotnet tool install dotnetsay --tool-path ~/bin`

Installs version 2.0.0 of the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) Global Tool:

`dotnet tool install -g dotnetsay --version 2.0.0`

## See also

- [.NET Core Global Tools](global-tools.md)
