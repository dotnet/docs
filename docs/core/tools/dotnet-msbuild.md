---
title: dotnet msbuild command
description: The 'dotnet msbuild' command provides access to the MSBuild command line.
keywords: dotnet msbuild, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: ffdc40ba-ef33-463e-aa35-b0af1fe615a2
---

# dotnet msbuild

## Name

`dotnet msbuild` - Builds a project and all of its dependencies.

## Synopsis

`dotnet msbuild <msbuild_arguments> [-h|/help]`

## Description

The `dotnet msbuild` command allows access to [MSBuild](https://docs.microsoft.com/visualstudio/msbuild/msbuild). The command has the same capabilities and options as the MSBuild command-line client. For information on the available options, see the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference).

## Options

`-h|/help`

Shows help information.

## Examples

Build a project and its dependencies:

`dotnet msbuild`

Build a project and its dependencies using Release configuration:

`dotnet msbuild /p:Configuration=Release`

Run the publish target and publish for the `osx.10.12-x64` [Runtime IDentifier (RID)](../rid-catalog.md):

`dotnet msbuild /t:Publish /p:RuntimeIdentifiers=osx.10.12-x64`

See the whole project with all targets included by the SDK:

`dotnet msbuild /pp`
