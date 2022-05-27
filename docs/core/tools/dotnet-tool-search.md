---
title: dotnet tool search command
description: The dotnet tool search command searches the .NET tools that are published to NuGet.org.
ms.date: 11/11/2020
---
# dotnet tool search

**This article applies to:** ✔️ .NET 5 SDK and later versions

## Name

`dotnet tool search` - Searches all [.NET tools](global-tools.md) that are published to NuGet.

## Synopsis

```dotnetcli
dotnet tool search [--detail]  [--prerelease]
    [--skip <NUMBER>] [--take <NUMBER>] <SEARCH TERM>

dotnet tool search -h|--help
```

## Description

The `dotnet tool search` command provides a way for you to search NuGet for tools that can be used as .NET global, tool-path, or local tools. The command searches the tool names and metadata such as titles, descriptions, and tags.

The command uses the [NuGet Search API](/nuget/api/search-query-service-resource#search-for-packages). It filters on `packageType=dotnettool` to select only .NET tool packages.

## Options

<!-- markdownlint-disable MD012 -->

- **`--detail`**

  Shows detailed results from the query.

- **`--prerelease`**

  Includes pre-release packages.

- **`--skip <NUMBER>`**

  Specifies the number of query results to skip. Used for pagination.

- **`--take <NUMBER>`**

  Specifies the number of query results to show. Used for pagination.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Search NuGet.org for .NET tools that have "format" in their package name or description:

  ```dotnetcli
  dotnet tool search format
  ```

  The output looks like the following example:

  ```output
  Package ID                              Latest Version      Authors                                                                     Downloads      Verified
  ---------------------------------------------------------------------------------------------------------------------------------------------------------------
  dotnet-format                           4.1.131201          Microsoft                                                                   496746
  bsoa.generator                          1.0.0               Microsoft                                                                   533
  ```

- Search NuGet.org for .NET tools that have "format" in their package name or metadata, show only the first result, and show a detailed view.

  ```dotnetcli
  dotnet tool search format --take 1 --detail
  ```

  The output looks like the following example:

  ```output
  ----------------
  dotnet-format
  Latest Version: 4.1.131201
  Authors: Microsoft
  Tags:
  Downloads: 496746
  Verified: False
  Description: Command line tool for formatting C# and Visual Basic code files based on .editorconfig settings.
  Versions:
          3.0.2 Downloads: 1973
          3.0.4 Downloads: 9064
          3.1.37601 Downloads: 114730
          3.2.107702 Downloads: 13423
          3.3.111304 Downloads: 131195
          4.0.130203 Downloads: 78610
          4.1.131201 Downloads: 145927
  ```

## See also

- [.NET tools](global-tools.md)
- [Tutorial: Install and use a .NET global tool using the .NET CLI](global-tools-how-to-use.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)
