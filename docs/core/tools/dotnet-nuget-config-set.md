---
title: "'dotnet nuget config set' command"
description: "The 'dotnet nuget config set' command helps manage NuGet configuration files."
author: martinrrm
ms.date: 05/14/2024
---
# dotnet nuget config set

**This article applies to:** ✔️ .NET 8.0.2xx SDK and later versions

## Name

`dotnet nuget config set` - Set the value of a specified NuGet configuration setting.

## Synopsis

```dotnetcli
dotnet nuget config set <CONFIG-KEY> <CONFIG-VALUE> [--configfile <FILE>]

dotnet nuget config set -h|--help
```

## Description

The `dotnet nuget config set` sets the values for NuGet configuration settings that will be applied from the config section.

## Arguments

- **`CONFIG_KEY`**

  The key of the settings that are to be set.

- **`CONFIG-VALUE`**

  The value of the settings that are to be set.

## Options

- **`--configfile <FILE>`**

  The NuGet configuration file (*nuget.config*) to use. If specified, only the settings from this file will be used. If not specified, the hierarchy of configuration files from the current directory will be used. For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior).

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

* Sets the `repositoryPath` configuration value `c:\installed_packages` to the current directory:

  ```dotnetcli
  dotnet nuget config set repositoryPath "c:\installed_packages"
  ```

* Sets the `repositoryPath` configuration value `c:\installed_packages` to the specified configuration file:

  ```dotnetcli
  dotnet nuget config set repositoryPath "c:\installed_packages" --configfile "c:\nuget.config"
  ```

## See also

- [nuGet.config reference](/nuget/reference/nuget-config-file)
