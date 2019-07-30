---
title: dotnet list reference command
description: The dotnet list reference command provides a convenient option to list project to project references.
ms.date: 06/26/2019
---
# dotnet list reference

**This topic applies to: ✓** .NET Core 1.x SDK and later versions

<!-- todo: uncomment when all CLI commands are reviewed
[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]
-->

## Name

`dotnet list reference` - Lists project-to-project references.

## Synopsis

`dotnet list [<PROJECT>|<SOLUTION>] reference [-h|--help]`

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

  ```console
  dotnet list app/app.csproj reference
  ```

* List the project references for the project in the current directory:

  ```console
  dotnet list reference
  ```
