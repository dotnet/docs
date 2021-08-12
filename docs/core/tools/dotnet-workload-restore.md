---
title: dotnet workload restore command
description: The 'dotnet workload restore' command installs workloads needed for a project or a solution.
ms.date: 08/12/2021
---
# dotnet workload restore

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload restore` - Installs workloads needed for a project or a solution.

## Synopsis

```dotnetcli
dotnet workload restore [<PROJECT | SOLUTION>]
    [--configfile <FILE>] [--disable-parallel]
    [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>] [--skip-manifest-update]
    [-s|--source <SOURCE>] [--temp-dir <PATH>] [-v|--verbosity <LEVEL>]

dotnet workload restore -?|-h|--help
```

## Description

The `dotnet workload restore` command analyzes a project or solution to determine which workloads it needs, then installs any workloads that are missing.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Arguments

- **`PROJECT | SOLUTION`**

  The project or solution file to install workloads for. If a file is not specified, the command searches the current directory for one.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [config-file](../../../includes/cli-configfile.md)]

- **`--disable-parallel`**

  Prevents restoring multiple projects in parallel.

- **`--download-to-cache <PATH_TO_CACHE>`**

  Downloads packages needed for a workload to a folder that can be used for offline installation.

- **`--from-cache <PATH_TO_CACHE>`**

  Complete the operation from cache (offline).

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--ignore-failed-sources`**

  Treats package source failures as warnings.

- **`--include-previews`**

  Allows prerelease workload manifests.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`--no-cache`**

  Prevents caching of packages and http requests.

[!INCLUDE [sdk-version](../../../includes/cli-sdk-version.md)]

- **`--skip-manifest-update`**

  Skip updating the workload manifests. The workload manifests define what assets and versions need to be installed for each workload.

[!INCLUDE [source](../../../includes/cli-source.md)]

- **`--temp-dir <PATH>`**

  Configure the temporary directory used for this command (must be secure).

[!INCLUDE [verbosity](../../../includes/cli-verbosity-packages.md)]


## Example

- Restore workloads needed by MyApp.csproj:

  ```dotnetcli
  dotnet workload restore MyApp.csproj
  ```
