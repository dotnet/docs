---
title: dotnet nuget-locals command (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: The 'dotnet nuget locals' command clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder. 
keywords: dotnet nuget-locals, dotnet nuget locals, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8440229e-317e-4dc1-9463-cba5fdb12c3b
---

# dotnet nuget locals (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet nuget locals` - Clears or lists local NuGet resources. 

## Synopsis

`dotnet nuget locals <CACHE_LOCATION> [(-c|--clear)|(-l|--list)] [--force-english-output] [-h|--help]`

## Description

The `dotnet nuget locals` command clears or lists local NuGet resources in the http-request cache, temporary cache, or machine-wide global packages folder.

## Arguments

`CACHE_LOCATION`

| Value             | Cache locations cleared or listed                                        |
| ----------------- | ------------------------------------------------------------------------ |
| `all`             | All cache locations: http-request, global packages, and temporary caches |
| `global-packages` | Only the global packages cache                                           |
| `http-cache`      | Only the http-request cache                                              |
| `temp`            | Only the temporary cache                                                 |

## Options

`-c|--clear`

The clear option performs a clear operation on the specified cache type. The contents of the cache directories are deleted recursively. The executing user/group must have permission to delete the files in the cache directories or an error is displayed indicating the files/folders not cleared. Use either `-c|--clear` or `-l|-list`; don't use both.

`--force-english-output`

Force command-line output in English.

`-h|--help`

Shows help information.

`-l|--list`

The list option is used to display the location of the specified cache type. Use either `-c|--clear` or `-l|-list`; don't use both.

## Examples

Display the paths of the local cache directories (http-cache directory, global-packages cache directory, and temporary cache directory):

`dotnet nuget locals all -l`

Display the path for the local http-cache directory:

`dotnet nuget locals http-cache --list`

Clear the files from the local cache directories (http-cache directory, global-packages cache directory, and temporary cache directory):

`dotnet nuget locals all --clear`

Clear the files in the local global-packages cache directory:

`dotnet nuget locals global-packages -c`

Clear the files in the local temporary cache directory:

`dotnet nuget locals temp -c`

## Troubleshooting

For information on common problems and errors while using the `dotnet nuget locals` command, see [Managing the NuGet cache](/nuget/consume-packages/managing-the-nuget-cache).
