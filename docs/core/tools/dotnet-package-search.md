---
title: dotnet package search command
description: Searches a given source using the query string provided. If no sources are specified, all sources defined in the NuGet.Config file are used
author: Nigusu-Allehu
ms.date: 10/26/2023
---
# dotnet package search

**This article applies to:** ✔️ .NET 8.0.2xx SDK and later versions

## Name

`dotnet package search` - Searches for a NuGet package.

## Synopsis

```dotnetcli
dotnet package search [search terms] [options]
    [--source <SOURCE>]
    [--exact-match]
    [--prerelease]
    [--interactive]
    [--take <TAKE>]
    [--skip <SKIP>]

dotnet package search -h|--help
```

## Description

The `dotnet package search` command searches for a NuGet package.

## Arguments

- **`search terms`**

  Specifies the search term to filter results. Use this argument to search for packages matching the provided query. Example: `dotnet package search json`.

## Options

- **`--source <SOURCE>`**

  The package source to search. You can pass multiple --source options to search multiple package sources.

- **`--exact-match`**

  Return exact matches only as a search result.

- **`--prerelease`**

    Allow prerelease packages to be shown.

- **`--interactive`**

    Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`--take`**

    The number of results to return. The default value is 20.

- **`--skip`**

    The number of results to skip, for pagination. The default value is 0.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

```dotnetcli
dotnet package search Newtonsoft.Json --source https://api.nuget.org/v3/index.json
```

output a list of 20 packages in the source matching the search term.

```
    Source: https://api.nuget.org/v3/index.json
    | Package ID                                  | Latest Version | Authors | Downloads       |
    |---------------------------------------------|----------------|---------|-----------------|
    | Newtonsoft.Json                             | 13.0.3         |         | 3,829,822,911   |
    | Newtonsoft.Json.Bson                        | 1.0.2          |         | 554,641,545     |
    | Newtonsoft.Json.Schema                      | 3.0.15         |         | 39,648,430      |
    | Microsoft.AspNetCore.Mvc.NewtonsoftJson     | 7.0.12         |         | 317,067,823     |
    ...
```

```dotnetcli
dotnet package search Newtonsoft.Json --source https://api.nuget.org/v3/index.json --skip 1 --take 2
```

output a list of 2 packages after skipping 1 in the source matching the search term.

```
    Source: https://api.nuget.org/v3/index.json
    | Package ID                                  | Latest Version | Authors | Downloads       |
    |---------------------------------------------|----------------|---------|-----------------|
    | Newtonsoft.Json.Bson                        | 1.0.2          |         | 554,641,545     |
    | Newtonsoft.Json.Schema                      | 3.0.15         |         | 39,648,430      |
```

```dotnetcli
dotnet package search Newtonsoft.Json --source https://api.nuget.org/v3/index.json --exact-match
```

output only an exact match.

```
    Source: https://api.nuget.org/v3/index.json
    | Package ID                                  | Latest Version | Authors | Downloads       |
    |---------------------------------------------|----------------|---------|-----------------|
    | Newtonsoft.Json                             | 13.0.3         |         | 3,829,822,911   |
```
