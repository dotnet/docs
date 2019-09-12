---
title: dotnet-add reference command
description: The dotnet add reference command provides a convenient option to add project to project references.
ms.date: 06/26/2019
---
# dotnet-add reference

**This article applies to: ✓** .NET Core 1.x SDK and later versions

<!-- todo: uncomment when all CLI commands are reviewed
[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]
-->

## Name

`dotnet add reference` - Adds project-to-project (P2P) references.

## Synopsis

`dotnet add [<PROJECT>] reference [-f|--framework] <PROJECT_REFERENCES> [-h|--help] [--interactive]`

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

* **`PROJECT`**

  Specifies the project file. If not specified, the command searches the current directory for one.

* **`PROJECT_REFERENCES`**

  Project-to-project (P2P) references to add. Specify one or more projects. [Glob patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux-based systems.

## Options

* **`-h|--help`**

  Prints out a short help for the command.

* **`-f|--framework <FRAMEWORK>`**

  Adds project references only when targeting a specific [framework](../../standard/frameworks.md).

* **`--interactive`**

  Allows the command to stop and wait for user input or action (for example, to complete authentication). Available since .NET Core 3.0 SDK.

## Examples

* Add a project reference:

  ```console
  dotnet add app/app.csproj reference lib/lib.csproj
  ```

* Add multiple project references to the project in the current directory:

  ```console
  dotnet add reference lib1/lib1.csproj lib2/lib2.csproj
  ```

* Add multiple project references using a globbing pattern on Linux/Unix:

  ```console
  dotnet add app/app.csproj reference **/*.csproj
  ```
