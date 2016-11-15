---
title: dotnet-msmsbuild command | .NET Core SDK
description: The dotnet-msmsbuild command provides access to MSmsbuild command line
keywords: dotnet-msmsbuild, CLI, CLI command, .NET Core
author: mairaw
manager: wpickett
ms.date: 10/13/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 70285a83-4103-4617-be8b-d0e1e9a4a91d
---

#dotnet-m/msbuild

## Name 
dotnet-msbuild -- msbuilds a project and all of its dependencies 

## Synopsis

`dotnet msbuild <msbuild_arguments>`

## Description
The `dotnet msbuild` command allows access to a fully functional MSBuild 

The command has the exact same capablities as existing MSBuild command line client. The options are all the same. You can 
use the [existing documentation](https://msdn.microsoft.com/en-us/library/ms164311.aspx) to get familiar with the command 
reference. 

## Examples

Build a project and its dependencies:

`dotnet msbuild`

Build a project and its dependencies using Release configuration:

`dotnet msbuild /p:Configuration=Release--configuration Release`

Run the publish target and publish for the `osx.10.11-x64` RID:

`dotnet msbuild /t:Publish /p:RuntimeIdentifiers=osx.10.11-x64`

