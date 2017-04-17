---
title: dotnet-list reference command - .NET Core CLI | Microsoft Docs
description: The dotnet-list reference command provides a convenient option to list project to project references.
keywords: dotnet-list, CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 03/15/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8f954a0c-03f8-4fbc-a529-b313ab12c623
---

# dotnet-list reference

## Name

`dotnet-list reference` - Lists project to project references.

## Synopsis

`dotnet list [<PROJECT>] reference [-h|--help]`

## Description

The `dotnet list reference` command provides a convenient option to list project references for a given project.

## Arguments

`PROJECT`

Specifies the project file to use for listing references. If not specified, the command will search the current directory for a project file.

## Options

`-h|--help`

Prints out a short help for the command.

## Examples

List the project references for the specified project:

`dotnet list app/app.csproj reference`

List the project references for the project in the current directory:

`dotnet list reference`
