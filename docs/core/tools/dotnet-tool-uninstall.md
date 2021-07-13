---
title: dotnet tool uninstall command
description: The dotnet tool uninstall command uninstalls the specified .NET tool from your machine.
ms.date: 02/14/2020
---
# dotnet tool uninstall

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Name

`dotnet tool uninstall` - Uninstalls the specified [.NET tool](global-tools.md) from your machine.

## Synopsis

```dotnetcli
dotnet tool uninstall <PACKAGE_NAME> -g|--global

dotnet tool uninstall <PACKAGE_NAME> --tool-path <PATH>

dotnet tool uninstall <PACKAGE_NAME>

dotnet tool uninstall -h|--help
```

## Description

The `dotnet tool uninstall` command provides a way for you to uninstall .NET tools from your machine. To use the command, you specify one of the following options:

* To uninstall a global tool that was installed in the default location, use the `--global` option.
* To uninstall a global tool that was installed in a custom location,  use the `--tool-path` option.
* To uninstall a local tool, omit the `--global` and `--tool-path` options.

**Local tools are available starting with .NET Core SDK 3.0.**

## Arguments

- **`PACKAGE_NAME`**

  Name/ID of the NuGet package that contains the .NET tool to uninstall. You can find the package name using the [dotnet tool list](dotnet-tool-list.md) command.

## Options

<!-- markdownlint-disable MD012 -->

- **`-g|--global`**

  Specifies that the tool to be removed is from a user-wide installation. Can't be combined with the `--tool-path` option. Omitting both `--global` and `--tool-path` specifies that the tool to be removed is a local tool.

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--tool-path <PATH>`**

  Specifies the location where to uninstall the tool. PATH can be absolute or relative. Can't be combined with the `--global` option. Omitting both `--global` and `--tool-path` specifies that the tool to be removed is a local tool.

## Examples

- **`dotnet tool uninstall -g dotnetsay`**

  Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool.

- **`dotnet tool uninstall dotnetsay --tool-path c:\global-tools`**

  Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool from a specific Windows directory.

- **`dotnet tool uninstall dotnetsay --tool-path ~/bin`**

  Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) global tool from a specific Linux/macOS directory.

- **`dotnet tool uninstall dotnetsay`**

  Uninstalls the [dotnetsay](https://www.nuget.org/packages/dotnetsay/) local tool from the current directory.

## See also

- [.NET tools](global-tools.md)
- [Tutorial: Install and use a .NET global tool using the .NET CLI](global-tools-how-to-use.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)
