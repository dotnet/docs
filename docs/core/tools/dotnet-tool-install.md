---
title: dotnet tool install command
description: The dotnet tool install command installs the specified .NET tool on your machine.
ms.date: 02/14/2020
---
# dotnet tool install

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Name

`dotnet tool install` - Installs the specified [.NET tool](global-tools.md) on your machine.

## Synopsis

```dotnetcli
dotnet tool install <PACKAGE_NAME> -g|--global
    [--add-source <SOURCE>] [--configfile <FILE>] [--disable-parallel]
    [--framework <FRAMEWORK>] [--ignore-failed-sources] [--interactive]
    [--no-cache] [--tool-manifest <PATH>] [-v|--verbosity <LEVEL>]
    [--version <VERSION_NUMBER>]

dotnet tool install <PACKAGE_NAME> --tool-path <PATH>
    [--add-source <SOURCE>] [--configfile <FILE>] [--disable-parallel]
    [--framework <FRAMEWORK>] [--ignore-failed-sources] [--interactive]
    [--no-cache] [--tool-manifest <PATH>] [-v|--verbosity <LEVEL>]
    [--version <VERSION_NUMBER>]

dotnet tool install <PACKAGE_NAME> [--local]
    [--add-source <SOURCE>] [--configfile <FILE>] [--disable-parallel]
    [--framework <FRAMEWORK>] [--ignore-failed-sources] [--interactive]
    [--no-cache] [--tool-manifest <PATH>] [-v|--verbosity <LEVEL>]
    [--version <VERSION_NUMBER>]

dotnet tool install -h|--help
```

## Description

The `dotnet tool install` command provides a way for you to install .NET tools on your machine. To use the command, you specify one of the following installation options:

* To install a global tool in the default location, use the `--global` option.
* To install a global tool in a custom location,  use the `--tool-path` option.
* To install a local tool, omit the `--global` and `--tool-path` options.

**Local tools are available starting with .NET Core SDK 3.0.**

Global tools are installed in the following directories by default when you specify the `-g` or `--global` option:

| OS          | Path                          |
|-------------|-------------------------------|
| Linux/macOS | `$HOME/.dotnet/tools`         |
| Windows     | `%USERPROFILE%\.dotnet\tools` |

Local tools are added to a *dotnet-tools.json* file in a *.config* directory under the current directory. If a manifest file doesn't exist yet, create it by running the following command:

```dotnetcli
dotnet new tool-manifest
```

For more information, see [Install a local tool](global-tools.md#install-a-local-tool).

## Arguments

- **`PACKAGE_NAME`**

  Name/ID of the NuGet package that contains the .NET tool to install.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [add-source](../../../includes/cli-add-source.md)]

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

- **`--disable-parallel`**

  Prevent restoring multiple projects in parallel.

- **`--framework <FRAMEWORK>`**

  Specifies the [target framework](../../standard/frameworks.md) to install the tool for. By default, the .NET SDK tries to choose the most appropriate target framework.

- **`-g|--global`**

  Specifies that the installation is user wide. Can't be combined with the `--tool-path` option. Omitting both `--global` and `--tool-path` specifies a local tool installation.

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--ignore-failed-sources`**

  Treat package source failures as warnings.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`--local`**

  Update the tool and the local tool manifest. Can't be combined with the `--global` option or the `--tool-path` option.

- **`--no-cache`**

  Do not cache packages and HTTP requests.

- **`--tool-manifest <PATH>`**

  Path to the manifest file.

- **`--tool-path <PATH>`**

  Specifies the location where to install the Global Tool. PATH can be absolute or relative. If PATH doesn't exist, the command tries to create it. Omitting both `--global` and `--tool-path` specifies a local tool installation.

[!INCLUDE [verbosity](../../../includes/cli-verbosity.md)]

- **`--version <VERSION_NUMBER>`**

  The version of the tool to install. By default, the latest stable package version is installed. Use this option to install preview or older versions of the tool.

## Examples

- **`dotnet tool install -g dotnetsay`**

  Installs [dotnetsay](https://www.nuget.org/packages/dotnetsay/) as a global tool in the default location.

- **`dotnet tool install dotnetsay --tool-path c:\global-tools`**

  Installs [dotnetsay](https://www.nuget.org/packages/dotnetsay/) as a global tool in a specific Windows directory.

- **`dotnet tool install dotnetsay --tool-path ~/bin`**

  Installs [dotnetsay](https://www.nuget.org/packages/dotnetsay/) as a global tool in a specific Linux/macOS directory.

- **`dotnet tool install -g dotnetsay --version 2.0.0`**

  Installs version 2.0.0 of [dotnetsay](https://www.nuget.org/packages/dotnetsay/) as a global tool.

- **`dotnet tool install dotnetsay`**

  Installs [dotnetsay](https://www.nuget.org/packages/dotnetsay/) as a local tool for the current directory.

## See also

- [.NET tools](global-tools.md)
- [Tutorial: Install and use a .NET global tool using the .NET CLI](global-tools-how-to-use.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)
