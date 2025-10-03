---
title: dotnet nuget why command
description: Shows the dependency graph for a particular package for a given project or solution.
author: advay26
ms.date: 05/30/2024
---
# dotnet nuget why

**This article applies to:** ✔️ .NET 8.0.4xx SDK and later versions

## Name

`dotnet nuget why` - Shows the dependency graph for a particular package.

## Synopsis

```dotnetcli
dotnet nuget why [<PROJECT|SOLUTION>] <PACKAGE> [-f|--framework <FRAMEWORK>]

dotnet nuget why -h|--help
```

## Description

The `dotnet nuget why` command shows the dependency graph for a particular package for a given project or solution.

Starting with version 9.0.200, the command introduces support for runtime identifier (RID) specific packages by generating separate dependency trees for each RID and framework combination.
For example, if a project targets `net9.0` with the `win-x64` RID, the command generates trees for `net9.0/win-x64` and `net9.0`.

### Older project format

To use the command with projects that can't be restored with the .NET SDK, you can pass a NuGet assets file in place of the project file (starting with the .NET 9 SDK):

1. First, restore the project in Visual Studio or using `msbuild.exe`. By default, the assets file is in the project's `obj\` directory, but you can find the location with `msbuild.exe path\to\project.proj -getProperty:ProjectAssetsFile`.
2. Run `dotnet nuget why path\to\project.assets.json SomePackage`.

## Arguments

- **`PROJECT|SOLUTION`**

  The project or solution file to operate on. 
  If a directory is specified, the command searches the directory for a project or solution file.
  If more than one project or solution is found, an error is thrown.
  If no value is provided, the current working directory is used by default.

- **`PACKAGE`**

  The package name to look up in the dependency graph.

## Options

- **`-f|--framework <FRAMEWORK>`**

    The target framework(s) for which dependency graphs are shown. You can pass multiple `--framework` options to see graphs for more than one framework.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Show the dependency graph for the package "System.Text.Json":

    ```dotnetcli
    dotnet nuget why System.Text.Json
    ```

    ![Example: Solution with multiple projects](media/dotnet-nuget-why/dotnet-nuget-why-solution-with-multiple-projects.png)

- Show the dependency graph for the package "System.Text.Json" for a specific project:

    ```dotnetcli
    dotnet nuget why path\to\DotnetNuGetWhyPackage.csproj System.Text.Json
    ```

- Show the dependency graph for a specific target framework:

    ```dotnetcli
    dotnet nuget why System.Text.Json --framework net6.0
    ```
