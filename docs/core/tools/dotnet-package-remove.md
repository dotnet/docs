---
title: dotnet package remove command
description: The dotnet package remove command provides a convenient option to remove NuGet package reference to a project.
ms.date: 09/29/2025
---
# dotnet package remove

**This article applies to:** ✔️ .NET 6 and later versions

## Name

`dotnet package remove` - Removes a package reference from a project file.

> [!NOTE]
> If you're using .NET 9 SDK or earlier, use the "verb first" form (`dotnet remove package`) instead. The "noun first" form was introduced in .NET 10. For more information, see [More consistent command order](../whats-new/dotnet-10/sdk.md#more-consistent-command-order).

## Synopsis

```dotnetcli
dotnet package remove <PACKAGE_NAME> [--project <PROJECT>]  
    [--interactive] [--file <FILE>]

dotnet package remove -h|--help
```

## Description

The `dotnet package remove` command provides a convenient option to remove a NuGet package reference from a project.

## Arguments

`PACKAGE_NAME`

The package reference to remove.

## Options

- **`-p|--project <PROJECT>`**

  The project file to operate on. If a solution file is specified, the command will update the package in all projects in the solution that reference it. If not specified, the command will search the current directory for a project file.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`--file <FILE>`**

  The file-based app to operate on.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Remove `Newtonsoft.Json` NuGet package from a project in the current directory:

  ```dotnetcli
  dotnet package remove Newtonsoft.Json
  ```

- Remove `Newtonsoft.Json` NuGet package from a specific project file:

  ```dotnetcli
  dotnet package remove Newtonsoft.Json --file MyApp.cs
  ```
