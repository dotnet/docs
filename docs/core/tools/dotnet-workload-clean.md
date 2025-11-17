---
title: dotnet workload clean command
description: "The `dotnet workload clean` command removes workload components that might have been left behind from previous updates and uninstallations."
ms.date: 09/29/2025
---
# dotnet workload clean

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet workload clean` - Removes workload components that might have been left behind from previous updates and uninstallations.

## Synopsis

```dotnetcli
dotnet workload clean [options]

dotnet workload clean -?|-h|--help
```

## Description

The `dotnet workload clean` command removes all workload components that have been uninstalled.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Options

- **--all**

  Removes and uninstalls all workload components from all SDK versions. Defaults to `false`.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Remove all workflow components:

  ```dotnetcli
  dotnet workload clean --all
  ```
