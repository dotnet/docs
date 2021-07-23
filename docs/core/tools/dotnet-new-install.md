---
title: dotnet new --install option
description: The dotnet new --install option installs a template package.
ms.date: 04/29/2021
---
# dotnet new --install option

**This article applies to:** ✔️ .NET Core 2.0 SDK and later versions

## Name

`dotnet new --install` - installs a template package.

## Synopsis

```dotnetcli
dotnet new --install <PATH|NUGET_ID>  [--interactive] [--nuget-source <SOURCE>]
```

## Description

The `dotnet new --install` command installs a template package from the `PATH` or `NUGET_ID` provided. If you want to install a prerelease version of a template package, specify the version in the format `<package-name>::<package-version>`. By default, `dotnet new` passes \* for the version, which represents the latest stable package version. For more information, see the [Examples](#examples) section.
  
  If a version of the template was already installed when you run this command, the template will be updated to the specified version, or to the latest stable version if no version was specified.
  For information on creating custom templates, see [Custom templates for dotnet new](custom-templates.md).

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [interactive](../../../includes/cli-interactive-5-0.md)]

- **`--nuget-source <SOURCE>`**
  
  By default, `dotnet new --install` uses the hierarchy of NuGet configuration files from the current directory to determine the NuGet source the package can be installed from. If `--nuget-source` is specified, the source will be added to the list of sources to be checked.  
  To check the configured sources for the current directory use [`dotnet nuget list source`](dotnet-nuget-list-source.md). For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior)

## Examples

- Install the latest version of SPA templates for ASP.NET Core:

  ```dotnetcli
  dotnet new --install Microsoft.DotNet.Web.Spa.ProjectTemplates
  ```

- Install version 2.0 of the SPA templates for ASP.NET Core:

  ```dotnetcli
  dotnet new --install Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0
  ```

- Install version 2.0 of the SPA templates for ASP.NET Core from a custom NuGet source using interactive mode:

  ```dotnetcli
  dotnet new --install Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0 --nuget-source "https://api.my-custom-nuget.com/v3/index.json" --interactive
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new --search option](dotnet-new-search.md)
- [Custom templates for dotnet new](custom-templates.md)
