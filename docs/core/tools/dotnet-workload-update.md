---
title: dotnet workload update command
description: The 'dotnet workload update' command updates installed workloads.
ms.date: 07/08/2021
---
# dotnet workload update

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload update` - Updates installed workloads.

## Synopsis

```dotnetcli
dotnet workload update
    [--add-source <SOURCE>] [--configfile <FILE>]
    [--disable-parallel] [--download-to-cache <CACHE>]
    [--from-cache <CACHE>] [--from-previous-sdk]
    [--ignore-failed-sources] [--include-previews]
    [--interactive] [--no-cache] [--sdk-version <VERSION>] [--temp-dir <PATH>] [-v|--verbosity <LEVEL>]

dotnet workload update -?|-h|--help
```

## Description

The `dotnet workload update` command queries Nuget.org for updated workload manifests. It then updates local manifests, downloads new versions of the installed workloads, and removes all old versions of each workload.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [add-source](../../../includes/cli-add-source.md)]

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

- **`--temp-dir <PATH>`**

  Configure the temporary directory used for this command (must be secure).

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Examples

- Update the installed workloads:

  ```dotnetcli
  dotnet workload update
  ```

- Download the `microsoft.ios.sdk.full` workload to a cache located in the *workload-cache* directory under the current directory. Then update installed workloads from that cache location:

  ```dotnetcli
  dotnet workload install microsoft-ios-sdk-full --download-to-cache ./workload-cache
  dotnet workload update --from-cache ./workload-cache
  ```
