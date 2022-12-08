---
title: dotnet new install
description: The dotnet new install command installs a template package.
ms.date: 04/15/2022
---
# dotnet new install

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet new install` - installs a template package.

## Synopsis

```dotnetcli
dotnet new install <PATH|NUGET_ID>  [--interactive] [--add-source|--nuget-source <SOURCE>] [--force] 
    [-d|--diagnostics] [--verbosity <LEVEL>] [-h|--help]
```

## Description

The `dotnet new install` command installs a template package from the `PATH` or `NUGET_ID` provided. If you want to install a specific version or prerelease version of a template package, specify the version in the format `<package-name>::<package-version>`. By default, `dotnet new` passes \* for the version, which represents the latest stable package version. For more information, see the [Examples](#examples) section.

If a version of the template package was already installed when you run this command, the template package will be updated to the specified version. If no version is specified, the package is updated to the latest stable version.
Starting with .NET SDK 6.0.100, if the argument specifies the version, and that version of the NuGet package is already installed, it won't be reinstalled.
If the argument is a `PATH` and it's already installed, it won't be reinstalled.

Prior to .NET SDK 6.0.100, template packages were managed individually for each .NET SDK version, including [patch versions](../releases-and-support.md#servicing-updates).
For example, if you install the template package using `dotnet new --install` in .NET SDK 5.0.100, it will be installed only for .NET SDK 5.0.100. Templates from the package won't be available in other .NET SDK versions installed on your machine.

Starting with .NET SDK 6.0.100, installed template packages are available in later .NET SDK versions installed on your machine. A template package installed in .NET SDK 6.0.100 will also be available in .NET SDK 6.0.101, .NET SDK 6.0.200, and so on. However, these template packages won't be available in .NET SDK versions prior to .NET SDK 6.0.100. To use a template package installed in .NET SDK 6.0.100 or later in earlier .NET SDK versions, you need to install it using `dotnet new install` in that .NET SDK version.

> [!NOTE]
> [!INCLUDE [new syntax](../../../includes/dotnet-new-7-0-syntax.md)]
>
> Examples of old syntax:
>
> - Install the latest version of Azure web jobs project template package:
>
>   ```dotnetcli
>   dotnet new --install Microsoft.Azure.WebJobs.ProjectTemplates
>   ```

## Arguments

- **`<PATH|NUGET_ID>`**

  The folder on the file system or the NuGet package identifier to install the template package from. `dotnet new` attempts to install the NuGet package from the NuGet sources available for the current working directory and the sources specified via the `--add-source` option.
  If you want to install a specific version or prerelease version of a template package from NuGet source, specify the version in the format `<package-name>::<package-version>`.

## Options

- **`--add-source|--nuget-source <SOURCE>`**
  
  By default, `dotnet new install` uses the hierarchy of NuGet configuration files from the current directory to determine the NuGet source the package can be installed from. If `--nuget-source` is specified, the source will be added to the list of sources to be checked.  
  To check the configured sources for the current directory use [`dotnet nuget list source`](dotnet-nuget-list-source.md). For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior)

- **`-d|--diagnostics`**

  Enables diagnostic output. Available since .NET SDK 7.0.100.

- **`--force`**

  Allows installing template packages from the specified sources even if they would override a template package from another source. Available since .NET SDK 7.0.100.

- **`-h|--help`**

  Prints out help for the install command. Available since .NET SDK 7.0.100.

[!INCLUDE [interactive](../../../includes/cli-interactive-5-0.md)]

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, and `diag[nostic]`. Available since .NET SDK 7.0.100.

## Examples

- Install the latest version of SPA templates for ASP.NET Core:

  ```dotnetcli
  dotnet new install Microsoft.DotNet.Web.Spa.ProjectTemplates
  ```

- Install version 2.0 of the SPA templates for ASP.NET Core:

  ```dotnetcli
  dotnet new install Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0
  ```

- Install version 2.0 of the SPA templates for ASP.NET Core from a custom NuGet source using interactive mode:

  ```dotnetcli
  dotnet new --install Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0 --add-source "https://api.my-custom-nuget.com/v3/index.json" --interactive
  ```

## See also

- [`dotnet new` command](dotnet-new.md)
- [`dotnet new search` command](dotnet-new-search.md)
- [Custom templates for `dotnet new`](custom-templates.md)
