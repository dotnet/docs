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

- **`--configfile <FILE>`**

  The NuGet configuration file. If specified, only the settings from this file will be used. If not specified, the hierarchy of configuration files from the current directory will be used. For more information, see [Common NuGet Configurations](https://docs.microsoft.com/nuget/consume-packages/configuring-nuget-behavior).

## Examples

- Disable a source with name of `mySource`:

  ```dotnetcli
  dotnet nuget disable source mySource
  ```

## See also

- [Package source sections in NuGet.config files](/nuget/reference/nuget-config-file#package-source-sections)

- [sources command (nuget.exe)](/nuget/reference/cli-reference/cli-ref-sources)
