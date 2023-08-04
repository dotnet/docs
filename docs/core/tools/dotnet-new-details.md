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

The `dotnet new details` command displays the metadata of the template package from the package name provided. By default, the command searches for the latest available version.
If the package is installed locally or is found on the official NuGet website, it also displays the templates that the package contains, otherwise it only displays basic metadata.

## Arguments

- **`PACKAGE_NAME`**

  The package identifier to display the details for.

## Options

- **`--add-source|--nuget-source <SOURCE>`**

  By default, `dotnet new details` uses the hierarchy of NuGet configuration files from the current directory to determine the NuGet source the package can be installed from. If `--nuget-source` is specified, the source is added to the list of sources to be checked.
  To check the configured sources for the current directory use [`dotnet nuget list source`](dotnet-nuget-list-source.md). For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior)

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`-d|--diagnostics`**

  Enables diagnostic output.

- **`-h|--help`**

  Prints help for the search command.

## Examples

- Display package data from the latest version of NUnit templates:

   ```dotnetcli
  dotnet new details NUnit3.DotNetNew.Template
  ```

- Display package data of the NUnit templates from a custom NuGet source using interactive mode:

  ```dotnetcli
  dotnet new details NUnit3.DotNetNew.Template --add-source "https://api.my-custom-nuget.com/v3/index.json" --interactive
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new uninstall command](dotnet-new-uninstall.md)
- [dotnet new list command](dotnet-new-list.md)
- [dotnet new search command](dotnet-new-search.md)
- [Custom templates for dotnet new](custom-templates.md)
