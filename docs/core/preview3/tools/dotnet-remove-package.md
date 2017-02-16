---
title: dotnet-remove package command | Microsoft Docs
description: The dotnet-remove package command provides a convenient option to remove NuGet package reference to a project.
keywords: dotnet-remove , CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 02/16/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 2fcc8d37-16b3-4581-8038-832160e72d36
---
# dotnet-remove package

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name

`dotnet-remove package` - Remove package reference to a project file.

## Synopsis

```
dotnet remove [<PROJECT>] package <PACKAGE_NAME> [-h|--help]
dotnet remove package [-h|--help]
```

## Description

The `dotnet remove package` command provides a convenient option to remove a NuGet package reference to a project.

## Arguments

`PROJECT`

Project name to use. If not specified, the command will search the current directory for one.

`PACKAGE_NAME`

Package reference to remove.

## Options

`-h|--help`

Show help information for the command and/or argument

## Examples

Add Newtonsoft.Json NuGet package to a project:

`dotnet remove package Newtonsoft.Json`