---
title: dotnet-nuget-locals command | Microsoft Docs
description: The dotnet-nuget-locals command clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder. 
keywords: dotnet-nuget-locals, CLI, CLI command, .NET Core
author: karann-msft
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8440229e-317e-4dc1-9463-cba5fdb12c3b
---
#dotnet-nuget-locals

## Name

`dotnet-nuget-locals` - Clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder. 

## Synopsis

```
dotnet nuget locals <cache_location> [(-c|--clear)|(-l|--list)] [--force-english-output]
dotnet nuget locals [-h|--help]
```

where `<cache_location>` is one of the following values: `all`, `http-cache`, `packages-cache`, `global-packages`, or `temp`.

## Description

The `dotnet nuget locals` command clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder.

## Arguments

`all`

Indicates that the specified operation should be applied to all the cache types, that is, http-request cache, global packages cache and temporary cache.

`http-cache`

Indicates that the specified operation should be applied only to the http-request cache. The other cache locations are not affected.

`global-packages`

Indicates that the specified operation should be applied only to the global packages cache. The other cache locations are not affected.

`temp`

Indicates that the specified operation should be applied only to the temporary cache. The other cache locations are not affected.

## Options

`-h|--help`

Prints out a short help for the command.  

`-c|--clear`

The clear option is used to perform a clear operation on the specified cache type. The contents of the cache directories are deleted recursively. The executing user/group should have permission to the files in the cache directories for the operation to be successful. If not, then an error is displayed indication the files/folders which were not cleared.

`-l|--list`

The list option is used to display the location of the specified cache type. 

`--force-english-output`

Forces command-line output to be in English.

## Examples

Displays the paths of all the local cache directories, that is, http-cache directory, global-packages cache directory and temporary cache directory.

`dotnet nuget locals –l all`

Displays the path for the local http-cache directory:

`dotnet nuget locals --list http-cache`

Clears all the files in all the local cache directories, that is, http-cache directory, global-packages cache directory and temporary cache directory.

`dotnet nuget locals --clear all`

Clears all the files in local global-packages cache directory:

`dotnet nuget locals -c global-packages`

Clears all the files in local temporary cache directory:

`dotnet nuget locals -c temp`

## Troubleshooting

For information about the most commonly faced problems and errors while using the `dotnet-nuget-locals` command, see  [Managing the NuGet cache](https://docs.microsoft.com/nuget/consume-packages/managing-the-nuget-cache).
