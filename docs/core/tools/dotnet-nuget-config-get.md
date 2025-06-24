---
title: "'dotnet nuget config get' command"
description: "The 'dotnet nuget config get' command helps manage NuGet configuration files."
author: martinrrm
ms.date: 05/14/2024
---
# dotnet nuget config get

**This article applies to:** ✔️ .NET 8.0.2xx SDK and later versions

## Name

`dotnet nuget config get` - Gets the NuGet configuration settings that will be applied.

## Synopsis

```dotnetcli
dotnet nuget config get <ALL | CONFIG_KEY> [--show-path] [--working-directory <DIRECTORY>]

dotnet nuget config get -h|--help
```

## Description

The `dotnet nuget config get` Gets the NuGet configuration settings that will be applied from the config section.

## Arguments

- **`ALL`**

  Get all merged NuGet configuration settings from multiple NuGet configuration files that will be applied, when invoking NuGet command from the working directory path.

- **`CONFIG_KEY`**

  Get the effective value of the specified configuration settings of the config section.

## Options

* **`--show-path`**

  Indicate that the NuGet configuration file path will be shown beside the configuration settings.

* **`--working-directory <DIRECTORY>`**

  Specifies the directory to start from when listing configuration files. If not specified, the current directory is used.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

* Lists all the Nuget configuration settings being applied to the current directory:

  ```dotnetcli
  dotnet nuget config get all
  ```

* Lists the `repositoryPath` value from the config section being applied to the specified directory:

  ```dotnetcli
  dotnet nuget config get repositoryPath --working-directory "C:/working-directory"
  ```

## See also

- [nuGet.config reference](/nuget/reference/nuget-config-file)
