---
title: dotnet reference add command
description: The dotnet reference add command provides a convenient option to add project-to-project references.
ms.date: 03/21/2023
---
# dotnet reference add

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet reference add` - Adds project-to-project (P2P) references.

## Synopsis

```dotnetcli
dotnet reference add reference [-f|--framework <FRAMEWORK>]
     [--interactive] <PROJECT_REFERENCES> [--project <PROJECT>]

dotnet reference add -h|--help
```

## Description

The `dotnet reference add` command provides a convenient option to add project references to a project. After running the command, the `<ProjectReference>` elements are added to the project file.

```xml
<ItemGroup>
  <ProjectReference Include="app.csproj" />
  <ProjectReference Include="..\lib2\lib2.csproj" />
  <ProjectReference Include="..\lib1\lib1.csproj" />
  <ProjectReference Include="..\lib3\lib3.fsproj" />
</ItemGroup>
```

## Add a reference to an assembly that isn't in a project

There's no CLI command to add a reference to an assembly that isn't in a project or a package. But you can do that by editing your *.csproj* file and adding markup similar to the following example:

```xml
<ItemGroup>
  <Reference Include="MyAssembly">
    <HintPath>.\MyDLLFolder\MyAssembly.dll</HintPath>
  </Reference>
</ItemGroup>
```

## Arguments

- **`PROJECT`**

  Specifies the project file. If not specified, the command searches the current directory for one.

- **`PROJECT_REFERENCES`**

  Project-to-project (P2P) references to add. Specify one or more projects. [Glob patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux-based systems.

## Options

- **`-f|--framework <FRAMEWORK>`**

  Adds project references only when targeting a specific [framework](../../standard/frameworks.md) using the TFM format.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

## Examples

- Add a project reference:

  ```dotnetcli
  dotnet reference add lib/lib.csproj --project app/app.csproj
  ```

- Add a compatible .NET language (for example, F#) project reference, which works in both directions:

  ```dotnetcli
  dotnet add app/app.csproj reference lib/lib.fsproj
  ```

- Add multiple project references to the project in the current directory:

  ```dotnetcli
  dotnet reference add lib1/lib1.csproj lib2/lib2.csproj
  ```

- Add multiple project references using a globbing pattern on Linux/Unix:

  ```dotnetcli
  dotnet reference add **/*.csproj --project app/app.csproj
  ```
