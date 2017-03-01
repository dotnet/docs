---
title: dotnet-remove reference command | Microsoft Docs
description: The dotnet-remove reference command provides a convenient option to remove project to project references.
keywords: dotnet-remove , CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 02/28/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 889c6b7e-a313-40b1-9fd3-6a6f4c52f1d0
---
# dotnet-remove reference

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name

`dotnet-remove reference` - Removes project to project references.

## Synopsis

```
dotnet remove [<PROJECT>] reference [-f|--framework] <PROJECT_REFERENCES>
dotnet remove reference [-h|--help]
```

## Description

The `dotnet remove reference` command provides a convenient option to remove project references from a project.

## Arguments

`PROJECT`

Project file to operate on. If not specified, the command will search the current directory for one.

`PROJECT_REFERENCES`

Project to project references to remove. You can specify one or multiple projects. Glob pattern is supported on Unix/Linux based terminals.

## Options

`-h|--help`

Prints out a short help for the command.

`-f|--framework <FRAMEWORK>`

Removes reference only when targeting a specific framework.

## Examples

Remove a project reference from the specified project:

`dotnet remove app/app.csproj reference lib/lib.csproj`

Remove multiple project references from the project in the current directory:

`dotnet remove reference lib1/lib1.csproj lib2/lib2.csproj`

Remove multiple project references using globbing pattern:

`dotnet remove app/app.csproj reference **/*.csproj`