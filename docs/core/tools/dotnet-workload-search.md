---
title: dotnet workload search command
description: The 'dotnet workload search' command searches for optional workloads.
ms.date: 11/12/2025
---
# dotnet workload search

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet workload search` - Searches for optional workloads.

## Synopsis

```dotnetcli
dotnet workload search [<SEARCH_STRING>] [-v|--verbosity <LEVEL>] [version <WORKLOAD_VERSION>]

dotnet workload search -?|-h|--help
```

## Description

The `dotnet workload search` command lists available workloads. You can filter the list by specifying all or part of the workload ID you're looking for.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Arguments

- **`SEARCH_STRING`**

  The workload ID to search for, or part of it. For example, if you specify `maui`, the command lists all of the workload IDs that have `maui` in their workload ID.

## Options

- [!INCLUDE [help](includes/cli-help.md)]

- [!INCLUDE [verbosity](includes/cli-verbosity-minimal.md)]

- [!INCLUDE [workload-version](includes/cli-workload-version.md)]

## Examples

- List all available workloads:

  ```dotnetcli
  dotnet workload search
  ```

- List all available workloads that have "maui" in their workload ID:

  ```dotnetcli
  dotnet workload search maui
  ```

- Search for a workload that matches the provided version:

  ```dotnetcli
  dotnet workload search version maui@10.0.100
  ```
