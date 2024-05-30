---
title: dotnet nuget why command
description: Shows the dependency graph for a particular package for a given project or solution.
author: advay26
ms.date: 05/30/2024
---
# dotnet nuget why

**This article applies to:** ✔️ .NET 9 SDK and later versions

## Name

`dotnet nuget why` - Shows the dependency graph for a particular package.

## Synopsis

```dotnetcli
dotnet nuget why <PROJECT|SOLUTION> <PACKAGE> [-f|--framework <FRAMEWORK>]

dotnet nuget why -h|--help
```

## Description

The `dotnet nuget why` command shows the dependency graph for a particular package for a given project or solution.

## Arguments

- **`PROJECT|SOLUTION`**

  A path to a project, solution file, or directory.

- **`PACKAGE`**

  The package name to lookup in the dependency graph.

## Options

- **`-f|--framework <FRAMEWORK>`**

    The target framework(s) for which dependency graphs are shown.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Show the dependency graph for the package "System.Text.Json" for a given solution:

    ```dotnetcli
    dotnet nuget why .\DotnetNuGetWhyPackage.sln System.Text.Json
    ```

    ![Example: Solution with multiple projects](media/dotnet-nuget-why/dotnet-nuget-why-solution-with-multiple-projects.png)

- Show the dependency graph for the package "System.Text.Json" for a single project:

    ```dotnetcli
    dotnet nuget why .\DotnetNuGetWhyPackage.csproj System.Text.Json
    ```

- Show the dependency graph for the package "System.Text.Json" for a project targeting a specific framework:

    ```dotnetcli
    dotnet nuget why .\DotnetNuGetWhyPackage.csproj System.Text.Json --framework net6.0
    ```