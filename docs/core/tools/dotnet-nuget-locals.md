---
title: dotnet nuget locals command
description: The dotnet nuget locals command clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder.
author: karann-msft
ms.date: 02/14/2020
---
# dotnet nuget locals

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet nuget locals` - Clears or lists local NuGet resources.

## Synopsis

```dotnetcli
dotnet nuget locals <CACHE_LOCATION> [(-c|--clear)|(-l|--list)] [--force-english-output]

dotnet nuget locals -h|--help
```

## Description

The `dotnet nuget locals` command clears or lists local NuGet resources in the http-request cache, temporary cache, or machine-wide global packages folder.

## Arguments

- **`CACHE_LOCATION`**

  The cache location to list or clear. It accepts one of the following values:

  * `all` - Indicates that the specified operation is applied to all cache types: http-request cache, global packages cache, and the temporary cache.
  * `http-cache` - Indicates that the specified operation is applied only to the http-request cache. The other cache locations aren't affected.
  * `global-packages` - Indicates that the specified operation is applied only to the global packages cache. The other cache locations aren't affected.
  * `temp` - Indicates that the specified operation is applied only to the temporary cache. The other cache locations aren't affected.

## Options

<!-- markdownlint-disable MD012 -->

- **`--force-english-output`**

  Forces the application to run using an invariant, English-based culture.

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`-c|--clear`**

  The clear option executes a clear operation on the specified cache type. The contents of the cache directories are deleted recursively. The executing user/group must have permission to the files in the cache directories. If not, an error is displayed indicating the files/folders that weren't cleared.

- **`-l|--list`**

  The list option is used to display the location of the specified cache type.

## Examples

- Displays the paths of all the local cache directories (http-cache directory, global-packages cache directory, and temporary cache directory):

  ```dotnetcli
  dotnet nuget locals all -l
  ```

- Displays the path for the local http-cache directory:

  ```dotnetcli
  dotnet nuget locals http-cache --list
  ```

- Clears all files from all local cache directories (http-cache directory, global-packages cache directory, and temporary cache directory):

  ```dotnetcli
  dotnet nuget locals all --clear
  ```

- Clears all files in local global-packages cache directory:

  ```dotnetcli
  dotnet nuget locals global-packages -c
  ```

- Clears all files in local temporary cache directory:

  ```dotnetcli
  dotnet nuget locals temp -c
  ```

## Troubleshooting

For information on common problems and errors while using the `dotnet nuget locals` command, see [Managing the NuGet cache](/nuget/consume-packages/managing-the-nuget-cache).
