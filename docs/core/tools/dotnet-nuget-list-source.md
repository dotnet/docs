---
title: dotnet nuget list source command
description: The dotnet nuget list source command lists all existing sources from your NuGet configuration files. 
ms.date: 03/20/2020
---
# dotnet nuget list source

**This article applies to:** ✔️ .NET Core 3.1.200 SDK and later versions

## Name

`dotnet nuget list source` - Lists all configured NuGet sources.

## Synopsis

```dotnetcli
dotnet nuget list source [--format [Detailed|Short]] [--configfile <FILE>]

dotnet nuget list source -h|--help
```

## Description

The `dotnet nuget list source` command lists all existing sources from your NuGet configuration files.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [configfile](../../../includes/cli-configfile.md)]

- **`--format [Detailed|Short]`**

  The format of the list command output: `Detailed` (the default) and `Short`.

## Examples

- List configured sources from the current directory:

  ```dotnetcli
  dotnet nuget list source
  ```

## See also

- [Package source sections in NuGet.config files](/nuget/reference/nuget-config-file#package-source-sections)

- [sources command (nuget.exe)](/nuget/reference/cli-reference/cli-ref-sources)
