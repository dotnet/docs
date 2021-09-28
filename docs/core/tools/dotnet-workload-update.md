---
title: dotnet workload update command
description: The 'dotnet workload update' command updates installed workloads.
ms.date: 09/10/2021
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
    [--from-previous-sdk] [--ignore-failed-sources]
    [--include-previews] [--interactive] [--no-cache]
    [-s|--source <SOURCE>] [--temp-dir <PATH>]
    [-v|--verbosity <LEVEL>]

dotnet workload update -?|-h|--help
```

## Description

The `dotnet workload update` command updates all installed workloads to the newest available versions. It queries Nuget.org for updated workload manifests. It then updates local manifests, downloads new versions of the installed workloads, and removes all old versions of each workload.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Options

<!-- markdownlint-disable MD012 -->

- **`--advertising-manifests-only`**

  Downloads [advertising manifests](dotnet-workload-install.md#advertising-manifests) but doesn't update any workloads.

[!INCLUDE [config-file](../../../includes/cli-configfile.md)]

[!INCLUDE [disable-parallel](../../../includes/cli-disable-parallel.md)]

- **`--from-previous-sdk`**

  Include workloads installed with previous SDK versions in the update.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [ignore-failed-sources](../../../includes/cli-ignore-failed-sources.md)]

[!INCLUDE [include-previews](../../../includes/cli-include-previews.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

[!INCLUDE [no-cache](../../../includes/cli-no-cache.md)]

[!INCLUDE [source](../../../includes/cli-source.md)]

[!INCLUDE [temp-dir](../../../includes/cli-temp-dir.md)]

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
