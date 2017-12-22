---
title: dotnet msbuild command - .NET Core CLI
description: The dotnet msbuild command provides access to the MSBuild command line.
author: mairaw
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet msbuild

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet msbuild` - Builds a project and all of its dependencies.

## Synopsis

`dotnet msbuild <msbuild_arguments> [-h]`

## Description

The `dotnet msbuild` command allows access to a fully functional MSBuild.

The command has the exact same capabilities as existing MSBuild command-line client. The options are all the same. Use the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference) to obtain information on the available options. 

## Examples

Build a project and its dependencies:

`dotnet msbuild`

Build a project and its dependencies using Release configuration:

`dotnet msbuild /p:Configuration=Release`

Run the publish target and publish for the `osx.10.11-x64` RID:

`dotnet msbuild /t:Publish /p:RuntimeIdentifiers=osx.10.11-x64`

See the whole project with all targets included by the SDK:

`dotnet msbuild /pp`
