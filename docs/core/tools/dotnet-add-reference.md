---
title: dotnet add reference command (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: The 'dotnet add reference' command provides a convenient option to add project to project references.
keywords: dotnet add, dotnet add reference, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 5e2a3efd-443c-4f23-a1b1-a662a5387879
---

# dotnet add reference (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet add reference` - Adds project-to-project (P2P) references.

## Synopsis

`dotnet add [<PROJECT>] reference <PROJECT_REFERENCES> [-f|--framework] [-h|--help]`

## Description

The `dotnet add reference` command adds project references to a project. After running the command, a [**\<ProjectReference>**](/visualstudio/msbuild/common-msbuild-project-items) element is added to the project file.

For example, adding *lib1\lib1.csproj* to *ToDo.csproj* with `dotnet add reference lib1/lib1.csproj` produces:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <OutputType>Exe</OutputType>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="lib1\lib1.csproj" />
  </ItemGroup>
</Project>
```

## Arguments

`PROJECT`

Specifies the project file. If not specified, the command searches the current directory for one.

`PROJECT_REFERENCES`

Project-to-project (P2P) references to add. Specify one or more projects. [Glob patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux-based systems.

## Options

`-f|--framework <FRAMEWORK>`

Adds project references only when targeting a specific [framework](../../standard/frameworks.md).

`-h|--help`

Shows help information.

## Examples

Add a library project reference:

`dotnet add app/app.csproj reference lib/lib.csproj`

Add multiple project references:

`dotnet add reference lib1/lib1.csproj lib2/lib2.csproj`

Add multiple project references using a globbing pattern on Linux/Unix:

`dotnet add app/app.csproj reference **/*.csproj`
