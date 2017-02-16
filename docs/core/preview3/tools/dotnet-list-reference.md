---
title: dotnet-list reference command | Microsoft Docs
description: The dotnet-list reference command provides a convenient option to list project to project references.
keywords: dotnet-list , CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 02/16/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8f954a0c-03f8-4fbc-a529-b313ab12c623
---
# dotnet-list reference

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name

`dotnet-list reference` - Remove project to project references.

## Synopsis

```
dotnet list [<PROJECT>] reference [-h|--help]
dotnet list reference [-h|--help]
```

## Description

The `dotnet list reference` command provides a convenient option to list project references.

## Arguments

`PROJECT`

Project name to use. If not specified, the command will search the current directory for one.

## Options

`-h|--help`

Show help information for the command and/or argument

## Examples

List project references:

`dotnet list app/app.csproj reference`