---
title: dotnet list reference command
description: The dotnet list reference command provides a convenient option to list project to project references.
ms.date: 02/14/2020
---
# dotnet list reference

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet list reference` - Lists project-to-project references.

## Synopsis

```dotnetcli
dotnet list [<PROJECT>|<SOLUTION>] reference

dotnet list -h|--help
```

## Description

The `dotnet list reference` command provides a convenient option to list project references for a given project or solution.

## Arguments

* **`PROJECT | SOLUTION`**

  Specifies the project or solution file to use for listing references. If not specified, the command searches the current directory for a project file.

## Options

* **`-h|--help`**

  Prints out a short help for the command.

## Examples

* List the project references for the specified project:

  ```dotnetcli
  dotnet list app/app.csproj reference
  ```

* List the project references for the project in the current directory:

  ```dotnetcli
  dotnet list reference
  ```
