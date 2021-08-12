---
title: dotnet workload list command
description: The 'dotnet workload list' command lists installed workloads.
ms.date: 08/12/2021
---
# dotnet workload list

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload list` - Lists installed workloads.

### Synopsis

```dotnetcli
dotnet workload list [--disable-parallel]
    [--ignore-failed-sources] [--include-previews]
    [--interactive] [--no-cache] [--sdk-version <VERSION>]
    [--temp-dir <PATH>] [-v|--verbosity <LEVEL>]

dotnet workload list [-?|-h|--help]
```

## Description

The `dotnet workload list` command lists all installed workloads.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Options

<!-- markdownlint-disable MD012 -->

- **`--disable-parallel`**

  Prevents restoring multiple projects in parallel.

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--ignore-failed-sources`**

  Treats package source failures as warnings.

- **`--include-previews`**

  Allows prerelease workload manifests.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`--no-cache`**

  Prevents caching of packages and http requests.

[!INCLUDE [sdk-version](../../../includes/cli-sdk-version.md)]

- **`--temp-dir <PATH>`**

  Specify the temporary directory used to download and extract NuGet packages (must be secure).

[!INCLUDE [verbosity](../../../includes/cli-verbosity-packages.md)]

## Examples

- List the installed workloads:

  ```dotnetcli
  dotnet workload list
  ```
