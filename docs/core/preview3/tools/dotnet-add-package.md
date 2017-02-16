---
title: dotnet-add package command | Microsoft Docs
description: The dotnet-add package command provides a convenient option to add NuGet package reference to a project.
keywords: dotnet-add , CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 02/16/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 88e0da69-a5ea-46cc-8b46-5493242b7af9
---
# dotnet-add package

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name

`dotnet-add package` - Add package reference to a project file.

## Synopsis

```
dotnet add [<PROJECT>] package <PACKAGE_NAME> [-v|--version] [-f|--framework] [-s|--source] [--package-directory] [-h|--help]
dotnet add package [-h|--help]
```

## Description

The `dotnet add package` command provides a convenient option to add a NuGet package reference to a project.

## Arguments

`PROJECT`

Project name to use. If not specified, the command will search the current directory for one.

`PACKAGE_NAME`

Package reference to add.

## Options

`-h|--help`

Show help information for the command and/or argument

`-v|--version`

Version for the package to be added.

`-f|--framework`

Add reference only when targetting a specific framework

`-n|--no-restore`

Add reference without performing restore preview and compatibility check.

`-s|--source`

Use specific NuGet package sources to use during the restore.

`--package-directory`

Restore the packages to this Directory .

## Examples

Add Newtonsoft.Json NuGet package to a project:

`dotnet add package Newtonsoft.Json`

Add a specific version of a package to a project:

`dotnet add ToDo.csproj package Microsoft.Azure.DocumentDB.Core -v 1.0.0`

Specify NuGet source for package.

`dotnet add package Microsoft.AspNetCore.StaticFiles -s https://dotnet.myget.org/F/dotnet-core/api/v3/index.json`