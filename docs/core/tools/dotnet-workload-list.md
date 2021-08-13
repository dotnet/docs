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

[!INCLUDE [disable-parallel](../../../includes/cli-disable-parallel.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [ignore-failed-sources](../../../includes/cli-ignore-failed-sources.md)]

[!INCLUDE [include-previews](../../../includes/cli-include-previews.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

[!INCLUDE [no-cache](../../../includes/cli-no-cache.md)]

[!INCLUDE [sdk-version](../../../includes/cli-sdk-version.md)]

[!INCLUDE [temp-dir](../../../includes/cli-temp-dir.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Examples

- List the installed workloads:

  ```dotnetcli
  dotnet workload list
  ```
