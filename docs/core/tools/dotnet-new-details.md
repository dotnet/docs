---
title: dotnet new details
description: The dotnet new details command displays template package metadata.
ms.date: 06/07/2023
---
# dotnet new details

**This article applies to:** ✔️ .NET 8 preview 6

## Name

`dotnet new details` - Displays template package metadata.

## Synopsis

```dotnetcli
dotnet new details [<PACKAGE_NAME>] [--interactive] [--add-source|--nuget-source <SOURCE>] 
    [--force] [-d|--diagnostics] [-h|--help]
```

## Description

The `dotnet new details` command displays the metdata of the template package from the package name provided. For information on a specific version specify the version in with the `--version (check if this is correct)` option. By default, the command searches for the latest available version.
If the package is installed locally or is found on the official NuGet website, it also displays the templates that the package contains, otherwise it will only display basic metadata.

## Arguments

- **`PACKAGE NAME`**

 The package identifier to display the details for.

## Options

- **`--add-source|--nuget-source <SOURCE>`**
  
  By default, `dotnet new details` uses the hierarchy of NuGet configuration files from the current directory to determine the NuGet source the package can be installed from. If `--nuget-source` is specified, the source will be added to the list of sources to be checked.  
  To check the configured sources for the current directory use [`dotnet nuget list source`](dotnet-nuget-list-source.md). For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior)

[!INCLUDE [interactive](../../../includes/cli-interactive-5-0.md)]

- **`-d|--diagnostics`**

  Enables diagnostic output. Available since .NET SDK 7.0.100.

- **`-h|--help`**

  Prints out help for the search command. Available since .NET SDK 7.0.100.

## Examples

- Displays package data from the latest version of SPA templates for ASP.NET Core:

   ```dotnetcli
  dotnet new details Microsoft.DotNet.Web.Spa.ProjectTemplates
  ```

- Displays package data of the SPA templates for ASP.NET Core from a custom NuGet source using interactive mode:

  ```dotnetcli
  dotnet new details Microsoft.DotNet.Web.Spa.ProjectTemplates --add-source "https://api.my-custom-nuget.com/v3/index.json" --interactive
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new uninstall command](dotnet-new-uninstall.md)
- [dotnet new list command](dotnet-new-list.md)
- [dotnet new search command](dotnet-new-search.md)
- [Custom templates for dotnet new](custom-templates.md)
