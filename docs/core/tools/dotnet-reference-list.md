---
title: dotnet reference list command
description: The dotnet reference list command provides a convenient option to list project to project references.
ms.date: 04/02/2025
---
# dotnet reference list

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet reference list` - Lists project-to-project references.

> [!NOTE]
> If you're using .NET 9 SDK or earlier, use the "verb first" form (`dotnet list reference`) instead. The "noun first" form was introduced in .NET 10. For more information, see [More consistent command order](../whats-new/dotnet-10/sdk.md#more-consistent-command-order).

## Synopsis

```dotnetcli
dotnet reference list [--project <PROJECT>]

dotnet reference list -h|--help
```

## Description

The `dotnet reference list` command provides a convenient option to list project references for a given project.

## Arguments

* **`PROJECT`**

  The project file to operate on. If a file is not specified, the command will search the current directory for one.

## Options

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

* List the project references for the specified project:

  ```dotnetcli
  dotnet reference list --project app/app.csproj
  ```

* List the project references for the project in the current directory:

  ```dotnetcli
  dotnet reference list
  ```
