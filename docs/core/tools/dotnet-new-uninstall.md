---
title: dotnet new uninstall
description: The dotnet new --uninstall option uninstalls a template package.
ms.date: 04/29/2021
---
# dotnet new uninstall

**This article applies to:** ✔️ .NET Core 2.0 SDK and later versions

## Name

`dotnet new --uninstall` - uninstalls a template package.

## Synopsis

```dotnetcli
dotnet new --uninstall <PATH|NUGET_ID>
```

## Description

The `dotnet new --uninstall` command uninstalls a template package at the `PATH` or `NUGET_ID` provided. When the `<PATH|NUGET_ID>` value isn't specified, all currently installed template packages and their associated templates are displayed. When specifying `NUGET_ID`, don't include the version number.

<!-- markdownlint-disable MD012 -->
[!INCLUDE [new syntax](../../../includes/dotnet-new-7-0-syntax.md)]

Examples of the new syntax:

- Show help for the `uninstall` subcommand.

  ```dotnetcli
  dotnet new uninstall --help
  ```

- List the installed templates and details about them, including how to uninstall them:

  ```dotnetcli
  dotnet new uninstall
  ```

- Uninstall the Azure web jobs project template package:

  ```dotnetcli
  dotnet new uninstall Microsoft.Azure.WebJobs.ProjectTemplates
  ```

## Examples

- List the installed templates and details about them, including how to uninstall them:

  ```dotnetcli
  dotnet new --uninstall
  ```

- Uninstall the SPA templates for ASP.NET Core:

  ```dotnetcli
  dotnet new --uninstall Microsoft.DotNet.Web.Spa.ProjectTemplates
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new --list option](dotnet-new-list.md)
- [dotnet new --search option](dotnet-new-search.md)
- [Custom templates for dotnet new](custom-templates.md)
