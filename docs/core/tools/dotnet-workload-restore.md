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

[!INCLUDE [disable-parallel](../../../includes/cli-disable-parallel.md)]

[!INCLUDE [download-to-cache](../../../includes/cli-download-to-cache.md)]

[!INCLUDE [from-cache](../../../includes/cli-from-cache.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [ignore-failed-sources](../../../includes/cli-ignore-failed-sources.md)]

[!INCLUDE [include-previews](../../../includes/cli-include-previews.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

[!INCLUDE [no-cache](../../../includes/cli-no-cache.md)]

[!INCLUDE [sdk-version](../../../includes/cli-sdk-version.md)]

[!INCLUDE [skip-manifest-update](../../../includes/cli-skip-manifest-update.md)]

[!INCLUDE [source](../../../includes/cli-source.md)]

[!INCLUDE [temp-dir](../../../includes/cli-temp-dir.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-packages.md)]


## Example

- Restore workloads needed by MyApp.csproj:

  ```dotnetcli
  dotnet workload restore MyApp.csproj
  ```
