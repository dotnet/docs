---
title: dotnet reference remove command
description: The dotnet reference remove command provides a convenient option to remove project to project references.
ms.date: 04/02/2025
---
# dotnet reference remove

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet reference remove` - Removes project-to-project (P2P) references.

> [!NOTE]
> If you're using .NET 9 SDK or earlier, use the "verb first" form (`dotnet reference remove`) instead. The "noun first" form was introduced in .NET 10. For more information, see [More consistent command order](../whats-new/dotnet-10/sdk.md#more-consistent-command-order).

## Synopsis

```dotnetcli
dotnet reference remove [-f|--framework <FRAMEWORK>] [--project <PROJECT>]
     <PROJECT_REFERENCES>

dotnet reference remove -h|--help
```

## Description

The `dotnet reference remove` command provides a convenient option to remove project references from a project.

## Arguments

`PROJECT`

Target project file. If not specified, the command searches the current directory for one.

`PROJECT_REFERENCES`

Project-to-project (P2P) references to remove. You can specify one or multiple projects. [Glob patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux based terminals.

## Options

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`-f|--framework <FRAMEWORK>`**

  Removes the reference only when targeting a specific [framework](../../standard/frameworks.md) using the TFM format.

## Examples

- Remove a project reference from the specified project:

  ```dotnetcli
  dotnet reference remove lib/lib.csproj --project app/app.csproj
  ```

- Remove multiple project references from the project in the current directory:

  ```dotnetcli
  dotnet reference remove lib1/lib1.csproj lib2/lib2.csproj
  ```

- Remove multiple project references using a glob pattern on Unix/Linux:

  ```dotnetcli
  dotnet reference remove **/*.csproj` --project app/app.csproj
  ```
