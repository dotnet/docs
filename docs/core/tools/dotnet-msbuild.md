---
title: dotnet-msbuild command | Microsoft Docs
description: The dotnet-msbuild command provides access to the MSBuild command line.
keywords: dotnet-msmsbuild, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: ffdc40ba-ef33-463e-aa35-b0af1fe615a2
---
#dotnet-msbuild

## Name

`dotnet-msbuild` - Builds a project and all of its dependencies.

## Synopsis

```
dotnet msbuild <msbuild_arguments>
dotnet msbuild [-h]
```

## Description

The `dotnet msbuild` command allows access to a fully functional MSBuild 

The command has the exact same capabilities as existing MSBuild command-line client. The options are all the same. You can 
use the [MSBuild Command-Line Reference](https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference) to get familiar with the options. 

## Examples

Build a project and its dependencies:

`dotnet msbuild`

Build a project and its dependencies using Release configuration:

`dotnet msbuild /p:Configuration=Release`

Run the publish target and publish for the `osx.10.11-x64` RID:

`dotnet msbuild /t:Publish /p:RuntimeIdentifiers=osx.10.11-x64`
