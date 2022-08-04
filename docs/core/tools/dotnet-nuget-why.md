---
title: dotnet nuget why command
description: The 'dotnet nuget why' command provides the user to view the dependency graph of a package.
ms.date: 08/04/2022
---
# dotnet nuget why

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet nuget why` - Prints the dependency graph for a package.

## Synopsis

```dotnetcli
dotnet nuget why [<PROJECT>|<SOLUTION>] [<PACKAGE_NAME>]
    [--framework <FRAMEWORK>]
dotnet nuget why -h|--help
```

## Description

The `dotnet list package` command provides a way to print out the dependency graph for a package to allow users to understand the nature of top-level packages and their transitive dependencies. This command is dependent on the `project.assets.json` file being present in the project. The following example shows the output of the `dotnet nuget why` command for `packageA` which has dependencies in `projectNameA` and `projectNameB`:

```output
Project 'projectNameA' has the following dependency graph for 'packageA'
   [net6.0]: 
      Microsoft.ML (1.0.0) -> Microsoft.ML.Util (1.0.0) -> packageA (1.0.0)
   [net472]:
      Microsoft.ML (1.0.0) -> Microsoft.ML.Util (1.0.0) -> packageA (1.0.0)

Project 'projectNameB' has the following dependency graph for 'packageA'
   [net6.0]:
      Microsoft.ML (1.1.0) -> Microsoft.ML.Util (1.1.0) -> packageA (1.1.0)
   [net472]:
      Microsoft.ML (1.1.0) -> Microsoft.ML.Util (1.1.0) -> packageA (1.1.0)
```

Use the `--framework` option to find the dependency graph of a package in a specific framework. 

The following example shows the output of the `dotnet nuget why packageA --framework net6.0` command for the same package as the previous example:

```output
Project 'projectNameA' has the following dependency graph for 'packageA'
   [net6.0]:
      Microsoft.ML (1.0.0) -> Microsoft.ML.Util (1.0.0) -> packageA (1.0.0)
```

## Arguments

`PROJECT | SOLUTION`

The project or solution file to operate on. If not specified, the command searches the current directory for one. If more than one solution or project is found, an error is thrown.

`PACKAGE_NAME`

The exact package name/id for which the dependency graph has to be identified. Package name wildcards are not supported.

## Options

- **`--framework <FRAMEWORK>`**

  The NuGet sources to use when searching for newer packages. Requires the `--outdated` option.

## Examples

- Print dependency graph of `packageA` in a specific framework:

  ```dotnetcli
  dotnet nuget why packageA --framework net6.0
  ```

- Print dependency graph of `packageA`, the package has dependencies in multiple projects so all dependencies are printed by default:

  ```dotnetcli
  dotnet nuget why packageA
  ```