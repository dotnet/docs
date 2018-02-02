---
title: dotnet remove reference command - .NET Core CLI
description: The dotnet remove reference command provides a convenient option to remove project to project references.
keywords: dotnet-remove, CLI, CLI command, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet remove reference

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet remove reference` - Removes project-to-project references.

## Synopsis

`dotnet remove [<PROJECT>] reference [-f|--framework] <PROJECT_REFERENCES> [-h|--help]`

## Description

The `dotnet remove reference` command provides a convenient option to remove project references from a project.

## Arguments

`PROJECT`

Target project file. If not specified, the command searches the current directory for one.

`PROJECT_REFERENCES`

Project to project (P2P references to remove. You can specify one or multiple projects. [Glob patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux based terminals.

## Options

`-h|--help`

Prints out a short help for the command.

`-f|--framework <FRAMEWORK>`

Removes the reference only when targeting a specific [framework](../../standard/frameworks.md).

## Examples

Remove a project reference from the specified project:

`dotnet remove app/app.csproj reference lib/lib.csproj`

Remove multiple project references from the project in the current directory:

`dotnet remove reference lib1/lib1.csproj lib2/lib2.csproj`

Remove multiple project references using a glob pattern on Unix/Linux:

`dotnet remove app/app.csproj reference **/*.csproj`
