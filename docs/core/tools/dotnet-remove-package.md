---
title: dotnet remove package command
description: The dotnet remove package command provides a convenient option to remove NuGet package reference to a project.
ms.date: 05/29/2018
---
# dotnet remove package

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet remove package` - Removes package reference from a project file.

## Synopsis

`dotnet remove [<PROJECT>] package <PACKAGE_NAME> [-h|--help]`

## Description

The `dotnet remove package` command provides a convenient option to remove a NuGet package reference from a project.

## Arguments

`PROJECT`

Specifies the project file. If not specified, the command searches the current directory for one.

`PACKAGE_NAME`

The package reference to remove.

## Options

`-h|--help`

Prints out a short help for the command.

## Examples

Removes `Newtonsoft.Json` NuGet package from a project in the current directory:

`dotnet remove package Newtonsoft.Json`