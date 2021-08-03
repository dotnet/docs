---
title: dotnet tool update command
description: The dotnet tool update command updates the specified .NET tool on your machine.
ms.date: 07/08/2020
---
# dotnet tool update

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Name

`dotnet tool update` - Updates the specified [.NET tool](global-tools.md) on your machine.

## Synopsis

```dotnetcli
dotnet tool update <PACKAGE_ID> -g|--global
    [--add-source <SOURCE>] [--configfile <FILE>]
    [--disable-parallel] [--framework <FRAMEWORK>]
    [--ignore-failed-sources] [--interactive] [--no-cache]
    [-v|--verbosity <LEVEL>] [--version <VERSION>]

dotnet tool update <PACKAGE_ID> --tool-path <PATH>
    [--add-source <SOURCE>] [--configfile <FILE>]
    [--disable-parallel] [--framework <FRAMEWORK>]
    [--ignore-failed-sources] [--interactive] [--no-cache]
    [-v|--verbosity <LEVEL>] [--version <VERSION>]

dotnet tool update <PACKAGE_ID> --local
    [--add-source <SOURCE>] [--configfile <FILE>]
    [--disable-parallel] [--framework <FRAMEWORK>]
    [--ignore-failed-sources] [--interactive] [--no-cache]
    [--tool-manifest <PATH>]
    [-v|--verbosity <LEVEL>] [--version <VERSION>]

dotnet tool update -h|--help
```

## Description

The `dotnet tool update` command provides a way for you to update .NET tools on your machine to the latest stable version of the package. The command uninstalls and reinstalls a tool, effectively updating it. To use the command, you specify one of the following options:

* To update a global tool that was installed in the default location, use the `--global` option
* To update a global tool that was installed in a custom location, use the `--tool-path` option.
* To update a local tool, use the `--local` option.

**Local tools are available starting with .NET Core SDK 3.0.**

## Arguments

- **`PACKAGE_ID`**

  Name/ID of the NuGet package that contains the .NET global tool to update. You can find the package name using the [dotnet tool list](dotnet-tool-list.md) command.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [add-source](../../../includes/cli-add-source.md)]

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

- **`--disable-parallel`**

  Prevent restoring multiple projects in parallel.

- **`--framework <FRAMEWORK>`**

  Specifies the [target framework](../../standard/frameworks.md) to update the tool for.

- **`-g|--global`**

  Specifies that the update is for a user-wide tool. Can't be combined with the `--tool-path` option. Omitting both `--global` and `--tool-path` specifies that the tool to be updated is a local tool.

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

  Specifies the location where the global tool is installed. PATH can be absolute or relative. Can't be combined with the `--global` option. Omitting both `--global` and `--tool-path` specifies that the tool to be updated is a local tool.

[!INCLUDE [verbosity](../../../includes/cli-verbosity.md)]

- **`--version <VERSION>`**

  The version range of the tool package to update to. This cannot be used to downgrade versions, you must `uninstall` newer versions first.

## Examples

- **`dotnet tool update -g dotnetsay`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool.

- **`dotnet tool update dotnetsay --tool-path c:\global-tools`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool located in a specific Windows directory.

- **`dotnet tool update dotnetsay --tool-path ~/bin`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool located in a specific Linux/macOS directory.

- **`dotnet tool update dotnetsay`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) local tool installed for the current directory.

- **`dotnet tool update -g dotnetsay --version 2.0.*`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool to the latest patch version, with a major version of `2`, and a minor version of `0`.

- **`dotnet tool update -g dotnetsay --version (2.0.*,2.1.4)`**

  Updates the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool to the lowest version within the specified range `(> 2.0.0 && < 2.1.4)`, version `2.1.0` would be installed. For more information on semantic versioning ranges, see [NuGet packaging version ranges](/nuget/concepts/package-versioning#version-ranges).

## See also

- [.NET tools](global-tools.md)
- [Semantic versioning](https://semver.org)
- [Tutorial: Install and use a .NET global tool using the .NET CLI](global-tools-how-to-use.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)
