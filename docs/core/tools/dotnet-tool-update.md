---
title: dotnet tool update command
description: The dotnet tool update command updates the specified .NET Core tool on your machine.
ms.date: 02/14/2020
---
# dotnet tool update

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Name

`dotnet tool update` - Updates the specified [.NET Core tool](global-tools.md) on your machine.

## Synopsis

```dotnetcli
dotnet tool update <PACKAGE_NAME> <-g|--global> [--configfile] [--framework] [-v|--verbosity] [--add-source]
dotnet tool update <PACKAGE_NAME> <--tool-path> [--configfile] [--framework] [-v|--verbosity] [--add-source]
dotnet tool update <PACKAGE_NAME> [--configfile] [--framework] [-v|--verbosity] [--add-source]
dotnet tool update <-h|--help>
```

## Description

The `dotnet tool update` command provides a way for you to update .NET Core tools on your machine to the latest stable version of the package. The command uninstalls and reinstalls a tool, effectively updating it. To use the command, you specify one of the following options:

* To update a global tool that was installed in the default location, use the `--global` option
* To update a global tool that was installed in a custom location, use the `--tool-path` option.
* To update a local tool, omit the `--global` and `--tool-path` options.

**Local tools are available starting with .NET Core SDK 3.0.**

## Arguments

- **`PACKAGE_NAME`**

  Name/ID of the NuGet package that contains the .NET Core global tool to update. You can find the package name using the [dotnet tool list](dotnet-tool-list.md) command.

## Options

- **`--add-source <SOURCE>`**

  Adds an additional NuGet package source to use during installation.

- **`--configfile <FILE>`**

  The NuGet configuration (*nuget.config*) file to use.

- **`--framework <FRAMEWORK>`**

  Specifies the [target framework](../../standard/frameworks.md) to update the tool for.

- **`-g|--global`**

  Specifies that the update is for a user-wide tool. Can't be combined with the `--tool-path` option. Omitting both `--global` and `--tool-path` specifies that the tool to be updated is a local tool. 

- **`-h|--help`**

  Prints out a short help for the command.

- **`--tool-path <PATH>`**

  Specifies the location where the global tool is installed. PATH can be absolute or relative. Can't be combined with the `--global` option. Omitting both `--global` and `--tool-path` specifies that the tool to be updated is a local tool. 

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

- **`dotnet tool update -g dotnetsay`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool.

- **`dotnet tool update dotnetsay --tool-path c:\global-tools`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool located in a specific Windows directory.

- **`dotnet tool update dotnetsay --tool-path ~/bin`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool located in a specific Linux/macOS directory.

- **`dotnet tool update dotnetsay`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) local tool installed for the current directory.

## See also

- [.NET Core tools](global-tools.md)
