---
title: dotnet-remove reference command | Microsoft Docs
description: The dotnet-remove reference command provides a convenient option to remove project to project references.
keywords: dotnet-remove , CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 02/16/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 889c6b7e-a313-40b1-9fd3-6a6f4c52f1d0
---
# dotnet-remove reference

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name

`dotnet-remove reference` - Remove project to project references.

## Synopsis

```
dotnet remove [<PROJECT>] reference [-f|--framework] [args] [-h|--help]
dotnet remove reference [-h|--help]
```

## Description

The `dotnet remove reference` command provides a convenient option to remove a project references from a project.

## Arguments

`PROJECT`

Project name to use. If not specified, the command will search the current directory for one.

## Additional arguments

`<project>`

Project to project references to remove. A project or multiple projects to the project file. Glob pattern is supported on Unix/Linux based terminals.

## Options

`-f|--framework`

Remove reference only when targetting a specific framework

`-h|--help`

Show help information for the command and/or argument

## Examples

Remove a project reference:

`dotnet remove app/app.csproj reference lib/lib.csproj`

Remove multiple project references:

`dotnet remove reference lib1/lib1.csproj lib2/lib2.csproj`

Remove multiple project references using globbing pattern:

`dotnet remove app/app.csproj reference **/*.csproj`

