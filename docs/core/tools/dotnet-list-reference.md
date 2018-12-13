---
title: dotnet list reference command
description: The dotnet list reference command provides a convenient option to list project to project or project to package references.
ms.date: 12/03/2018
---
# dotnet list reference

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet list reference` - Lists project-to-project references.

`dotnet list package` - Lists project-to-project or project-to-package references.

## Synopsis

`dotnet list [<PROJECT>] reference [-h|--help]`

`dotnet list [<PROJECT>] package [-h|--help]`

## Description

The `dotnet list reference` command provides a convenient option to list project references for a given project or solution.

The `dotnet list package` command provides a convenient option to list package references for a given project or solution.

## Arguments

* **`PROJECT`**

  Specifies the project file to use for listing references. If not specified, the command searches the current directory for a project file.

## Options

* **`-h|--help`**

  Prints out a short help for the command.

## Examples

* List the project references for the specified project:

  ```console
  dotnet list app/app.csproj reference
  ```

* List the package references for the specified project:

  ```console
  dotnet list package app/app.csproj reference
  ```
  
* List the project references for the project in the current directory:

  ```console
  dotnet list reference
  ```
    
* List the package references for the project in the current directory:

  ```console
  dotnet list package
  ```
