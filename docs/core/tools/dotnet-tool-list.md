---
title: dotnet tool list command
description: The dotnet tool list command lists the .NET tools that are installed on your machine.
ms.date: 02/14/2020
---
# dotnet tool list

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet tool list` - Lists all [.NET tools](global-tools.md) of the specified type currently installed on your machine.

## Synopsis

```dotnetcli
dotnet tool list -g|--global

dotnet tool list --tool-path <PATH>

dotnet tool list --local

dotnet tool list [<PACKAGE_ID>]

dotnet tool list

dotnet tool list -h|--help
```

## Description

The `dotnet tool list` command provides a way for you to list .NET global, tool-path, or local tools installed on your machine. The command lists the package name, version installed, and the tool command.  To use the command, you specify one of the following:

* To list global tools installed in the default location, use the `--global` option
* To list global tools installed in a custom location, use the `--tool-path` option.
* To list local tools, use the `--local` option or omit the `--global`, `--tool-path`, and `--local` options.
* To list a specific tool, use the optional `PACKAGE_ID` argument.

## Arguments

- **`PACKAGE_ID`**

  Lists the tool that has the supplied package ID if the tool is installed. Can be used in conjunction with options. Provides a way to check if a specific tool was installed. If no tool with the specified package ID is found, the command lists headings with no detail rows. The command always returns 0.

## Options

- **`-g|--global`**

  Lists user-wide global tools. Can't be combined with the `--tool-path` option. Omitting both `--global` and `--tool-path` lists local tools.

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--local`**

  Lists local tools for the current directory. Can't be combined with the `--global` or `--tool-path` options. Omitting both `--global` and `--tool-path` lists local tools even if `--local` is not specified.

- **`--tool-path <PATH>`**

  Specifies a custom location where to find global tools. PATH can be absolute or relative. Can't be combined with the `--global` option. Omitting both `--global` and `--tool-path` lists local tools.

## Examples

- **`dotnet tool list -g`**

  Lists all global tools installed user-wide on your machine (current user profile).

- **`dotnet tool list --tool-path c:\global-tools`**

  Lists the global tools from a specific Windows directory.

- **`dotnet tool list --tool-path ~/bin`**

  Lists the global tools from a specific Linux/macOS directory.

- **`dotnet tool list`** or **`dotnet tool list --local`**

  Lists all local tools available in the current directory.

- **`dotnet tool list -g dotnetsay`**

  Lists the global tool with the package ID [dotnetsay](https://www.nuget.org/packages/dotnetsay/)

- **`dotnet tool list dotnetsay`**

  Lists the local tool with the package ID [dotnetsay](https://www.nuget.org/packages/dotnetsay/)

## See also

- [.NET tools](global-tools.md)
- [Tutorial: Install and use a .NET global tool using the .NET CLI](global-tools-how-to-use.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)
