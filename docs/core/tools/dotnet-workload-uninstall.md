---
title: dotnet workload uninstall command
description: The 'dotnet workload uninstall' command uninstalls workloads.
ms.date: 07/08/2021
---
# dotnet workload uninstall

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload uninstall` - Uninstalls workloads.

## Synopsis

```dotnetcli
dotnet workload uninstall <WORKLOAD_ID>

dotnet workload uninstall -?|-h|--help
```

## Description

The `dotnet workload uninstall` command uninstalls a workload.

## Arguments

- **`WORKLOAD_ID`**

  The workload ID to uninstall.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Uninstall the `microsoft.ios.sdk.full` workload:

  ```dotnetcli
  dotnet workload uninstall microsoft.ios.sdk.full
  ```
