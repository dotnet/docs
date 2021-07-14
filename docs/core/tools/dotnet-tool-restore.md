---
title: dotnet tool restore command
description: The dotnet tool restore command installs on your machine the .NET local tools that are in scope for the current directory.
ms.date: 02/14/2020
---
# dotnet tool restore

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

## Name

`dotnet tool restore` - Installs the .NET local tools that are in scope for the current directory.

## Synopsis

```dotnetcli
dotnet tool restore
    [--configfile <FILE>] [--add-source <SOURCE>]
    [--tool-manifest <PATH_TO_MANIFEST_FILE>] [--disable-parallel]
    [--ignore-failed-sources] [--no-cache] [--interactive]
    [-v|--verbosity <LEVEL>]

dotnet tool restore -h|--help
```

## Description

The `dotnet tool restore` command finds the tool manifest file that is in scope for the current directory and installs the tools that are listed in it. For information about manifest files, see [Install a local tool](global-tools.md#install-a-local-tool) and [Invoke a local tool](global-tools.md#invoke-a-local-tool).

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

[!INCLUDE [add-source](../../../includes/cli-add-source.md)]

- **`--tool-manifest <PATH>`**

  Path to the manifest file.

- **`--disable-parallel`**

  Prevent restoring multiple projects in parallel.

- **`--ignore-failed-sources`**

  Treat package source failures as warnings.

- **`--no-cache`**

  Do not cache packages and http requests.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity.md)]

## Example

- **`dotnet tool restore`**

  Restores local tools for the current directory.

## See also

- [.NET tools](global-tools.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)
