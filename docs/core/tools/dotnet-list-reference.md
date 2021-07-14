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
dotnet list [<PROJECT>] reference

dotnet list -h|--help
```

## Description

The `dotnet list reference` command provides a convenient option to list project references for a given project.

## Arguments

* **`PROJECT`**

  The project file to operate on. If a file is not specified, the command will search the current directory for one.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

* List the project references for the specified project:

  ```dotnetcli
  dotnet list app/app.csproj reference
  ```

* List the project references for the project in the current directory:

  ```dotnetcli
  dotnet list reference
  ```
