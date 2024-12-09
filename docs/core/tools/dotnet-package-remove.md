---
title: dotnet package remove command
description: The dotnet package remove command provides a convenient option to remove NuGet package reference to a project.
ms.date: 02/14/2020
---
# dotnet package remove

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet package remove` - Removes package reference from a project file.

## Synopsis

```dotnetcli
dotnet package remove <PACKAGE_NAME> [--project <PROJECT>]

dotnet package remove -h|--help
```

## Description

The `dotnet package remove` command provides a convenient option to remove a NuGet package reference from a project.

## Arguments

`PROJECT`

Specifies the project file. If not specified, the command searches the current directory for one.

`PACKAGE_NAME`

The package reference to remove.

## Options

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Remove `Newtonsoft.Json` NuGet package from a project in the current directory:

  ```dotnetcli
  dotnet package remove Newtonsoft.Json
  ```
