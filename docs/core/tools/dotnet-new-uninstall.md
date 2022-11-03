---
title: dotnet new uninstall
description: The dotnet new uninstall command uninstalls a template package.
ms.date: 04/29/2021
---
# dotnet new uninstall

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet new uninstall` - uninstalls a template package.

## Synopsis

```dotnetcli
dotnet new uninstall <PATH|NUGET_ID> 
    [-d|--diagnostics] [--verbosity <LEVEL>] [-h|--help]
```

## Description

The `dotnet new uninstall` command uninstalls a template package at the `PATH` or `NUGET_ID` provided. When the `<PATH|NUGET_ID>` value isn't specified, all currently installed template packages and their associated templates are displayed. When specifying `NUGET_ID`, don't include the version number.

> [!NOTE]
> [!INCLUDE [new syntax](../../../includes/dotnet-new-7-0-syntax.md)]
>
> Examples of the old syntax:
>
> - List the installed templates and details about them, including how to uninstall them:
>
>   ```dotnetcli
>   dotnet new --uninstall
>   ```
>
> - Uninstall the Azure web jobs project template package:
>
>   ```dotnetcli
>   dotnet new --uninstall Microsoft.Azure.WebJobs.ProjectTemplates
>   ```

## Arguments

- **`<PATH|NUGET_ID>`**

  The folder on the file system or the NuGet package identifier the package was installed from. Note that the version for the NuGet package should not be specified.

## Options

- **`-d|--diagnostics`**

  Enables diagnostic output. Available since .NET SDK 7.0.100.

- **`-h|--help`**

  Prints out help for the uninstall command. Available since .NET SDK 7.0.100.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, and `diag[nostic]`. Available since .NET SDK 7.0.100.

## Examples

- List the installed templates and details about them, including how to uninstall them:

  ```dotnetcli
  dotnet new uninstall
  ```

- Uninstall the SPA templates for ASP.NET Core:

  ```dotnetcli
  dotnet new uninstall Microsoft.DotNet.Web.Spa.ProjectTemplates
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new list command](dotnet-new-list.md)
- [dotnet new search command](dotnet-new-search.md)
- [Custom templates for dotnet new](custom-templates.md)
