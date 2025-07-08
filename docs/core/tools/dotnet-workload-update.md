---
title: dotnet workload update command
description: The 'dotnet workload update' command updates installed workloads.
ms.date: 09/10/2021
---
# dotnet workload update

**This article applies to:** ✔️ .NET 6 SDK and later versions

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
    [-v|--verbosity <LEVEL>] [--version]

dotnet workload update -?|-h|--help
```

## Description

The `dotnet workload update` command updates all installed workloads to the newest available versions. It queries Nuget.org for updated workload manifests. It then updates local manifests, downloads new versions of the installed workloads, and removes all old versions of each workload.

When the command is in `workload-set` update mode, workloads are updated according to the workload-set version, not the latest version of each individual workload. For more information, see [.NET SDK workload sets](dotnet-workload-sets.md). `workload-set` mode is available since 8.0.400 SDK.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Options

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

[!INCLUDE [version](../../../includes/cli-version.md)]

## Examples

- Update the installed workloads to the latest version of each individual workload:

  ```dotnetcli
  dotnet workload config --update-mode manifests
  dotnet workload update
  ```

- Update the installed workloads to the latest workload set version:

  ```dotnetcli
  dotnet workload config --update-mode workload-set
  dotnet workload update
  ```
