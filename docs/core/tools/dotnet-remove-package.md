---
title: dotnet remove package command
description: The dotnet remove package command provides a convenient option to remove NuGet package reference to a project.
ms.date: 02/14/2020
---
# dotnet remove package

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet remove package` - Removes package reference from a project file.

## Synopsis

```dotnetcli
dotnet remove [<PROJECT>] package <PACKAGE_NAME>

dotnet remove package -h|--help
```

## Description

The `dotnet remove package` command provides a convenient option to remove a NuGet package reference from a project.

## Arguments

`PROJECT`

Specifies the project file. If not specified, the command searches the current directory for one.

`PACKAGE_NAME`

The package reference to remove.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Remove `Newtonsoft.Json` NuGet package from a project in the current directory:

  ```dotnetcli
  dotnet remove package Newtonsoft.Json
  ```
