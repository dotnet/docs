---
title: dotnet workload config command
description: "The `dotnet workload config` command selects workload set update mode or manifests update mode. It can also display the currently selected update mode."
ms.date: 08/15/2024
---
# dotnet workload config

**This article applies to:** ✔️ .NET 8.0.400 SDK and later versions

## Name

`dotnet workload config` - Enables or disables workload-set update mode.

## Synopsis

```dotnetcli
dotnet workload config
[--update-mode [<workload-set>|<manifests>]]

dotnet workload config -?|-h|--help
```

## Description

For more information about the `dotnet workload config` command, see [.NET SDK workload sets](dotnet-workload-sets.md).

## Options

  [!INCLUDE [help](../../../includes/cli-help.md)]

- **`--update-mode [<workload-set>|<manifests>]`**

  Controls whether updates look for workload set versions or individual manifest versions. To display the current mode, specify this option without an argument. For more information, see [.NET SDK workload sets](dotnet-workload-sets.md).

## Examples

- Enable workload-set update mode:

  ```dotnetcli
  dotnet workload config --update-mode workload-set
  ```

- Disable workload-set update mode:

  ```dotnetcli
  dotnet workload config --update-mode manifests
  ```
