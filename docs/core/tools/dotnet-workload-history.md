---
title: dotnet workload history command
description: "The `dotnet workload history` command shows a history of workload installation actions."
ms.date: 09/29/2025
---
# dotnet workload history

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet workload history` - Shows a history of workload installation actions.

## Synopsis

```dotnetcli
dotnet workload history [options]

dotnet workload history -?|-h|--help
```

## Description

The `dotnet workload history` shows a history of workload installation actions.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Options

- **--all**

  Removes and uninstalls all workload components from all SDK versions. Defaults to `false`.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Remove all workflow components:

  ```dotnetcli
  dotnet workload history --all
  ```
