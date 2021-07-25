---
title: dotnet add reference command
description: The dotnet add reference command provides a convenient option to add project to project references.
ms.date: 02/14/2020
---
# dotnet add reference

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet add reference` - Adds project-to-project (P2P) references.

## Synopsis

```dotnetcli
dotnet add [<PROJECT>] reference [-f|--framework <FRAMEWORK>]
     [--interactive] <PROJECT_REFERENCES>

dotnet add reference -h|--help
```

## Description

The `dotnet add reference` command provides a convenient option to add project references to a project. After running the command, the `<ProjectReference>` elements are added to the project file.

```xml
<ItemGroup>
  <ProjectReference Include="app.csproj" />
  <ProjectReference Include="..\lib2\lib2.csproj" />
  <ProjectReference Include="..\lib1\lib1.csproj" />
</ItemGroup>
```

## Arguments

- **`PROJECT`**

  Specifies the project file. If not specified, the command searches the current directory for one.

- **`PROJECT_REFERENCES`**

  Project-to-project (P2P) references to add. Specify one or more projects. [Glob patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux-based systems.

## Options

<!-- markdownlint-disable MD012 -->

- **`-f|--framework <FRAMEWORK>`**

  Adds project references only when targeting a specific [framework](../../standard/frameworks.md) using the TFM format.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

## Examples

- Add a project reference:

  ```dotnetcli
  dotnet add app/app.csproj reference lib/lib.csproj
  ```

- Add multiple project references to the project in the current directory:

  ```dotnetcli
  dotnet add reference lib1/lib1.csproj lib2/lib2.csproj
  ```

- Add multiple project references using a globbing pattern on Linux/Unix:

  ```dotnetcli
  dotnet add app/app.csproj reference **/*.csproj
  ```
