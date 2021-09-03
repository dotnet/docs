---
title: dotnet nuget disable source command
description: The dotnet nuget disable source command disables an existing source in your NuGet configuration files. 
ms.date: 03/20/2020
---
# dotnet nuget disable source

**This article applies to:** ✔️ .NET Core 3.1.200 SDK and later versions

## Name

`dotnet nuget disable source` - Disable a NuGet source.

## Synopsis

```dotnetcli
dotnet nuget disable source <NAME> [--configfile <FILE>]

dotnet nuget disable source -h|--help
```

## Description

The `dotnet nuget disable source` command disables an existing source in your NuGet configuration files.

## Arguments

- **`NAME`**

  Name of the source.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

## Examples

- Disable a source with name of `mySource`:

  ```dotnetcli
  dotnet nuget disable source mySource
  ```

## See also

- [Package source sections in NuGet.config files](/nuget/reference/nuget-config-file#package-source-sections)

- [sources command (nuget.exe)](/nuget/reference/cli-reference/cli-ref-sources)
