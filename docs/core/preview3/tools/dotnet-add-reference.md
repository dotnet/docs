---
title: dotnet-add reference command | Microsoft Docs
description: The dotnet-add reference command provides a convenient option to add project to project references.
keywords: dotnet-add , CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 02/28/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 5e2a3efd-443c-4f23-a1b1-a662a5387879
---
# dotnet-add reference

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name

`dotnet-add reference` - Adds project to project references.

## Synopsis

```
dotnet add [<PROJECT>] reference [-f|--framework] <PROJECT_REFERENCES>
dotnet add reference [-h|--help]
```

## Description

The `dotnet add reference` command provides a convenient option to add project references to a project. After running the command, the [`<ProjectReference>`](https://docs.microsoft.com/visualstudio/msbuild/common-msbuild-project-items) fragments are added to the project file.

```xml
<ItemGroup>
    <ProjectReference Include="app.csproj" />
    <ProjectReference Include="..\lib2\lib2.csproj" />
    <ProjectReference Include="..\lib1\lib1.csproj" />
</ItemGroup>
```

## Arguments

`PROJECT`

Project file to operate on. If not specified, the command will search the current directory for one.

`PROJECT_REFERENCES`

Project to project references to add. You can specify one or multiple projects. Glob pattern is supported on Unix/Linux-based terminals.

## Options

`-h|--help`

Prints out a short help for the command.

`-f|--framework <FRAMEWORK>`

Adds project references only when targeting a specific framework.

## Examples

Add a project reference:

`dotnet add app/app.csproj reference lib/lib.csproj`

Add multiple project references:

`dotnet add reference lib1/lib1.csproj lib2/lib2.csproj`

Add multiple project references using globbing pattern on Linux/Unix:

`dotnet add app/app.csproj reference **/*.csproj`
