---
title: dotnet nuget config paths command
description: The dotnet-nuget-config command helps list nuget configuration files.
author: martinrrm
ms.date: 05/14/2024
---
# dotnet nuget config paths

**This article applies to:** ✔️ .NET 8.0.2xx SDK and later versions

## Name

`dotnet nuget config paths` - Lists nuget configuration files currently being applied to a directory.

## Synopsis

```dotnetcli
dotnet nuget config paths [--working-directory <DIRECTORY>]

dotnet nuget config paths -h|--help
```

## Description

The `dotnet nuget config paths` Lists the paths to all NuGet configuration files that will be applied when invoking NuGet commands in a specific directory.

## Options

* **`--working-directory <DIRECTORY>`**

  Specifies the directory to start from when listing configuration files. If not specified, the current directory is used.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

* Lists Nuget configuration files being applied to the current directory:

  ```dotnetcli
  dotnet nuget config paths
  ```

* Lists Nuget configuration files being applied to the specified directory:

  ```dotnetcli
  dotnet nuget config paths --working-directory "C:/working-directory"
  ```

## See also

- [nuGet.config reference](/nuget/reference/nuget-config-file)
