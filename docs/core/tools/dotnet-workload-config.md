---
title: dotnet workload config command
description: The 'dotnet workload config' command determines whether updates should look for workload sets or the latest version of each individual manifest.
ms.date: 09/10/2021
---
# dotnet workload config

**This article applies to:** ✔️ .NET 8.0.400 SDK and later versions

## Name

`dotnet workload config` - Enables or disables workload set mode.

## Synopsis

```dotnetcli
dotnet workload config [--update-mode <workload-set>|<manifests>]

dotnet workload config -?|-h|--help
```

## Description

The `dotnet workload config` command selects workload set update mode or manifests update mode. It can also display the currently selected update mode.

For more information about the `dotnet workload config` command, see [.NET SDK workload sets](dotnet-workload-sets.md).

## Options

  [!INCLUDE [help](../../../includes/cli-help.md)]

- **`--update-mode <workload-set>|<manifests>`**

  Controls whether updates should look for workload set versions or the latest version of each individual manifest. To display the current mode, specify this option without an argument. For more information, see [.NET SDK workload sets](dotnet-workload-sets.md).

## Examples

- Enable workload set update mode:

  ```dotnetcli
  dotnet workload config --update-mode workload-set
  ```

- Disable workload set update mode:

  ```dotnetcli
  dotnet workload config --update-mode manifests
  ```
