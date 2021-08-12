---
title: dotnet workload repair command
description: The 'dotnet workload repair' command repairs workload installations.
ms.date: 08/12/2021
---
# dotnet workload repair

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload repair` - Repairs workloads installations.

## Synopsis

```dotnetcli
dotnet workload repair
    [--configfile] [--disable-parallel] [--ignore-failed-sources]
    [--interactive] [--no-cache] [--sdk-version <VERSION>]
    [-s|--source <SOURCE>] [--temp-dir <PATH>]
    [-v|--verbosity <LEVEL>]

dotnet workload repair -?|-h|--help
```

## Description

The `dotnet workload repair` command reinstalls all installed workloads. Workloads are made up of multiple workload packs and it's possible to get into a state where some installed successfully but others didn't. For example, a [`dotnet workload install`](dotnet-workload-install.md) command might not finish installing because of a dropped internet connection.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Arguments

- **`WORKLOAD_ID`**

  The workload ID of the workload to repair.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [config-file](../../../includes/cli-configfile.md)]

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

[!INCLUDE [source](../../../includes/cli-source.md)]

- **`--temp-dir <PATH>`**

  Specify the temporary directory used to download and extract NuGet packages (must be secure).

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Examples

- Repair all installed workloads:

  ```dotnetcli
  dotnet workload repair
  ```
