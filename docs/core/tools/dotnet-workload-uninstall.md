---
title: dotnet workload uninstall command
description: The 'dotnet workload uninstall' command uninstalls a specified workload.
ms.date: 07/08/2021
---
# dotnet workload uninstall

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet workload uninstall` - Uninstalls a specified workload.

## Synopsis

```dotnetcli
dotnet workload uninstall <WORKLOAD_ID...>

dotnet workload uninstall -?|-h|--help
```

## Description

The `dotnet workload uninstall` command uninstalls one or more workloads.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Arguments

- **`WORKLOAD_ID...`**

  The workload ID or multiple IDs to uninstall.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Uninstall the `maui` workload:

  ```dotnetcli
  dotnet workload uninstall maui
  ```

- Uninstall the `maui-android` and `maui-ios` workloads:

  ```dotnetcli
  dotnet workload uninstall maui-android maui-ios
  ```
