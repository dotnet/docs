---
title: dotnet remove reference command
description: The dotnet remove reference command provides a convenient option to remove project to project references.
ms.date: 02/14/2020
---
# dotnet remove reference

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet remove reference` - Removes project-to-project (P2P) references.

## Synopsis

```dotnetcli
dotnet remove [<PROJECT>] reference [-f|--framework <FRAMEWORK>]
     <PROJECT_REFERENCES>

dotnet remove reference -h|--help
```

## Description

The `dotnet remove reference` command provides a convenient option to remove project references from a project.

## Arguments

`PROJECT`

Target project file. If not specified, the command searches the current directory for one.

`PROJECT_REFERENCES`

Project-to-project (P2P) references to remove. You can specify one or multiple projects. [Glob patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux based terminals.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`-f|--framework <FRAMEWORK>`**

  Removes the reference only when targeting a specific [framework](../../standard/frameworks.md) using the TFM format.

## Examples

- Remove a project reference from the specified project:

  ```dotnetcli
  dotnet remove app/app.csproj reference lib/lib.csproj
  ```

- Remove multiple project references from the project in the current directory:

  ```dotnetcli
  dotnet remove reference lib1/lib1.csproj lib2/lib2.csproj
  ```

- Remove multiple project references using a glob pattern on Unix/Linux:

  ```dotnetcli
  dotnet remove app/app.csproj reference **/*.csproj`
  ```
