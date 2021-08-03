---
title: dotnet workload update command
description: The 'dotnet workload update' command updates installed workloads.
ms.date: 07/20/2021
---
# dotnet workload update

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload update` - Updates installed workloads.

## Synopsis

```dotnetcli
dotnet workload update
    [--advertising-manifests-only]
    [--configfile <FILE>] [--disable-parallel]
    [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--from-previous-sdk] [--ignore-failed-sources]
    [--include-previews] [--interactive] [--no-cache]
    [--sdk-version <VERSION>] [--source <SOURCE>]
    [--temp-dir <PATH>] [-v|--verbosity <LEVEL>]

dotnet workload update -?|-h|--help
```

## Description

The `dotnet workload update` command updates all installed workloads to the newest available versions. It queries Nuget.org for updated workload manifests. It then updates local manifests, downloads new versions of the installed workloads, and removes all old versions of each workload.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Options

<!-- markdownlint-disable MD012 -->

- **`--advertising-manifests-only`**

  Downloads [advertising manifests](dotnet-workload-install.md#advertising-manifests) but doesn't update any workloads. Available starting in .NET 6 Preview 7.

[!INCLUDE [config-file](../../../includes/cli-configfile.md)]

- **`--disable-parallel`**

  Prevents restoring multiple projects in parallel.

- **`--download-to-cache <PATH_TO_CACHE>`**

  Downloads packages needed for a workload to a folder that can be used for offline installation.

- **`--from-cache <PATH_TO_CACHE>`**

  Completes the operation from cache (offline).

- **`--from-previous-sdk`**

  Include workloads installed with previous SDK versions in the update.

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--ignore-failed-sources`**

  Treat package source failures as warnings.

- **`--include-previews`**

  Allow prerelease workload manifests.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`--no-cache`**

  Don't cache packages and HTTP requests.

[!INCLUDE [sdk-version](../../../includes/cli-sdk-version.md)]

[!INCLUDE [source](../../../includes/cli-source.md)]

- **`--temp-dir <PATH>`**

  Configures the temporary directory used for this command (must be secure).

[!INCLUDE [verbosity](../../../includes/cli-verbosity-packages.md)]

## Examples

- Update the installed workloads:

  ```dotnetcli
  dotnet workload update
  ```

- Download the assets needed for updating installed workloads to a cache located in the *workload-cache* directory under the current directory. Then update installed workloads from that cache location:

  ```dotnetcli
  dotnet workload update --download-to-cache ./workload-cache
  dotnet workload update --from-cache ./workload-cache
  ```
