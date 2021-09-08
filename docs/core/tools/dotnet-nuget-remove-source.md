---
title: dotnet nuget remove source command
description: The dotnet nuget remove source command removes an existing source from your NuGet configuration files. 
ms.date: 03/20/2020
---
# dotnet nuget remove source

**This article applies to:** ✔️ .NET Core 3.1.200 SDK and later versions

## Name

`dotnet nuget remove source` - Remove a NuGet source.

## Synopsis

```dotnetcli
dotnet nuget remove source <NAME> [--configfile <FILE>]

dotnet nuget remove source -h|--help
```

## Description

The `dotnet nuget remove source` command removes an existing source from your NuGet configuration files.

## Arguments

- **`NAME`**

  Name of the source.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

## Examples

- Remove a source with name of `mySource`:

  ```dotnetcli
  dotnet nuget remove source mySource
  ```

## See also

- [Package source sections in NuGet.config files](/nuget/reference/nuget-config-file#package-source-sections)

- [sources command (nuget.exe)](/nuget/reference/cli-reference/cli-ref-sources)
