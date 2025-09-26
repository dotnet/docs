---
title: dotnet package update command
description: The dotnet package update command provides a convenient option to update a NuGet package reference to a project.
ms.date: 09/26/2025
---
# dotnet package update

**This article applies to:** ✔️ .NET 6 and later versions

## Name

`dotnet package update` - Updates referenced packages in a project or solution.

> [!NOTE]
> If you're using .NET 9 SDK or earlier, use the "verb first" form (`dotnet update package`) instead. The "noun first" form was introduced in .NET 10. For more information, see [More consistent command order](../whats-new/dotnet-10/sdk.md#more-consistent-command-order).

## Synopsis

```dotnetcli
dotnet package update <PACKAGE_NAME> [--project <PROJECT>] [--interactive] [-v|--verbosity <LEVEL>]

dotnet package update -h|--help
```

## Description

The `dotnet package update` command provides a convenient option to update a NuGet package reference in a project or solution.

## Arguments

`PACKAGE_NAME`

The package reference to update.

## Options

- **`-p|--project <PROJECT>`**

  The project file to operate on. If a solution file is specified, the command will update the package in all projects in the solution that reference it. If not specified, the command will search the current directory for a project file.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`-v|--verbosity <LEVEL>`**
  
  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `normal`.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Update `Microsoft.Extensions.Logging` NuGet package from a project in the current directory:

  ```dotnetcli
  dotnet package update Microsoft.Extensions.Logging
  ```
