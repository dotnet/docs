---
title: dotnet workload repair command
description: The 'dotnet workload repair' command repairs workload installations.
ms.date: 07/08/2021
---
# dotnet workload repair

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload repair` - Repairs workloads installations.

## Synopsis

```dotnetcli
dotnet workload repair
    [--configfile <FILE>] [--sdk-version <VERSION>]
    [--source <SOURCE>] [-v|--verbosity <LEVEL>]

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

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [sdk-version](../../../includes/cli-sdk-version.md)]

[!INCLUDE [source](../../../includes/cli-source.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Examples

- Repair all installed workloads:

  ```dotnetcli
  dotnet workload repair
  ```
