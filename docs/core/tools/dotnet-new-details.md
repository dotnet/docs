---
title: dotnet new details
description: The dotnet new details command displays template package metadata.
ms.date: 04/15/2022
---
# dotnet new details

**This article applies to:** ✔️ .NET Core ??? SDK and later versions

## Name

`dotnet new details` - Displays template package metadata.

## Synopsis

```
add the thingS
```

## Description

The `dotnet new details` command displays the metdata of the template package from the package name provided. For information on a specific version specify the version in with the `--version (check if this is correct)` option. By default, the command searches for the latest available version.
If the package is installed locally or is found on the official NuGet website, it also displays the templates that the package contains, otherwise it will only display basic package metadata.

## Arguments

- **`PACKAGE NAME`**

Name of the package being searched for metadata.


## Options

- **`--version <VERSION>`**
Specific version of the package being searched. If this is not specified, the command will look for the latest version.

- **`--add-source|--nuget-source <SOURCE>`**
  
  By default, `dotnet new details` uses the hierarchy of NuGet configuration files from the current directory to determine the NuGet source the package can be installed from. If `--nuget-source` is specified, the source will be added to the list of sources to be checked.  
  To check the configured sources for the current directory use [`dotnet nuget list source`](dotnet-nuget-list-source.md). For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior)

[!INCLUDE [interactive](../../../includes/cli-interactive-5-0.md)]

- **`-d|--diagnostics`**

  Enables diagnostic output. Available since .NET SDK 7.0.100.

- **`-h|--help`**

  Prints out help for the search command. Available since .NET SDK 7.0.100.


## Examples


## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new uninstall command](dotnet-new-uninstall.md)
- [dotnet new list command](dotnet-new-list.md)
- [dotnet new search command](dotnet-new-search.md)
- [Custom templates for dotnet new](custom-templates.md)