---
title: dotnet help command - .NET Core CLI
description: The dotnet help command shows more detailed documentation online for the specified command.
author: mairaw
ms.author: mairaw
ms.date: 08/17/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet help reference

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-2plus.md)]

## Name

`dotnet help` - Shows more detailed documentation online for the specified command.

## Synopsis

`dotnet help <COMMAND_NAME> [-h|--help]`

## Description

The `dotnet help` command opens up the reference page for more detailed information about the specified command at docs.microsoft.com.

## Arguments

`COMMAND_NAME`

Name of the .NET Core CLI command. For a list of the valid CLI commands, see [CLI commands](index.md#cli-commands).

## Options

`-h|--help`

Prints out a short help for the command.

## Examples

Opens the documentation page for the [dotnet new](dotnet-new.md) command:

`dotnet help new`
