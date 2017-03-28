---
title: dotnet-remove package command - .NET Core CLI | Microsoft Docs
description: The dotnet-remove package command provides a convenient option to remove NuGet package reference to a project.
keywords: dotnet-remove, CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 03/15/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 2fcc8d37-16b3-4581-8038-832160e72d36
---

# dotnet-remove package

## Name

`dotnet-remove package` - Removes package reference from a project file.

## Synopsis

`dotnet remove [<PROJECT>] package <PACKAGE_NAME> [-h|--help]`

## Description

The `dotnet remove package` command provides a convenient option to remove a NuGet package reference from a project.

## Arguments

`PROJECT`

Specifies the project file. If not specified, the command will search the current directory for one.

`PACKAGE_NAME`

The package reference to remove.

## Options

`-h|--help`

Prints out a short help for the command.

## Examples

Removes `Newtonsoft.Json` NuGet package from a project in the current directory:

`dotnet remove package Newtonsoft.Json`