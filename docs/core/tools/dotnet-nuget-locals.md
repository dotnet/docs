---
title: dotnet nuget locals command - .NET Core CLI
description: The dotnet nuget locals command clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder.
author: karann-msft
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet nuget locals

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet nuget locals` - Clears or lists local NuGet resources.

## Synopsis

`dotnet nuget locals <CACHE_LOCATION> [(-c|--clear)|(-l|--list)] [--force-english-output] [-h|--help]`

## Description

The `dotnet nuget locals` command clears or lists local NuGet resources in the http-request cache, temporary cache, or machine-wide global packages folder.

## Arguments

`CACHE_LOCATION`

One of the following values:

* `all` - Indicates that the specified operation is applied to all cache types: http-request cache, global packages cache, and the temporary cache.
* `http-cache` - Indicates that the specified operation is applied only to the http-request cache. The other cache locations are not affected.
* `global-packages` - Indicates that the specified operation is applied only to the global packages cache. The other cache locations are not affected.
* `temp` - Indicates that the specified operation is applied only to the temporary cache. The other cache locations are not affected.

## Options

`-h|--help`

Prints out a short help for the command.

`-c|--clear`

The clear option performs a clear operation on the specified cache type. The contents of the cache directories are deleted recursively. The executing user/group must have permission to the files in the cache directories. If not, an error is displayed indicating the files/folders which were not cleared.

`-l|--list`

The list option is used to display the location of the specified cache type. 

`--force-english-output`

Forces command-line output in English.

## Examples

Displays the paths of all the local cache directories (http-cache directory, global-packages cache directory, and temporary cache directory):

`dotnet nuget locals –l all`

Displays the path for the local http-cache directory:

`dotnet nuget locals --list http-cache`

Clears all files from all local cache directories (http-cache directory, global-packages cache directory, and temporary cache directory):

`dotnet nuget locals --clear all`

Clears all files in local global-packages cache directory:

`dotnet nuget locals -c global-packages`

Clears all files in local temporary cache directory:

`dotnet nuget locals -c temp`

## Troubleshooting

For information on common problems and errors while using the `dotnet nuget locals` command, see [Managing the NuGet cache](/nuget/consume-packages/managing-the-nuget-cache).