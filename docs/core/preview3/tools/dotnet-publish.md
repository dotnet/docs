---
title: dotnet-publish command | Microsoft Docs
description: The dotnet-publish command publishes your .NET Core project into a directory. 
keywords: dotnet-publish, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/07/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: f2ef275a-7c5e-430a-8c30-65f52af62771
---

#dotnet-publish (.NET Core Tools RC4)

> [!WARNING]
> This topic applies to .NET Core Tools RC4. For the .NET Core Tools Preview 2 version,
> see the [dotnet-publish](../../tools/dotnet-publish.md) topic.

## Name

`dotnet-publish` - Packs the application and all of its dependencies into a folder getting it ready for publishing.

## Synopsis

`dotnet publish [project] 
    [--help] [--framework]  
    [--runtime] [--output]  
    [--version-suffix] [--configuration]`

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the project file and publishes the resulting set of files to a directory. 

Depending on the type of portable app, the resulting directory will contain the following:

1. *Framework-dependent deployment* - application's intermediate language (IL) code and all of application's managed dependencies.
2. *Self-contained deployment* - same as above plus the entire runtime for the targeted platform.

For more information, see the [.NET Core Application Deployment](../deploying/index.md) topic.

## Options

`[project]` 

The project to publish, which defaults to the current directory if `[project]` is not specified. 

`-h|--help`

Prints out a short help for the command.  

`-f|--framework <FRAMEWORK>`

Publishes the application for a given framework identifier (FID). 

`-r|--runtime <RUNTIME_IDENTIFIER>`

Publishes the application for a given runtime. For a list of Runtime Identifiers (RIDs) you can use, see the [RID catalog](../../rid-catalog.md).

`-o|--output <OUTPUT_PATH>`

Specify the path where to place the directory. If not specified, it will default to *_./bin/[configuration]/[framework]/_* 
for portable applications or *_./bin/[configuration]/[framework]/[runtime]_* for self-contained deployments.

`--version-suffix [VERSION_SUFFIX]`

Defines what `*` should be replaced with in the version field in the project file.

`-c|--configuration [Debug|Release]`

Configuration to use when publishing. The default value is `Debug`.

## Examples

Publish an application.

`dotnet publish`

Publish the application using the specified project file

`dotnet publish ~/projects/app1/app1.csproj`
	
Publish the current application using the `netcoreapp1.0` framework:

`dotnet publish --framework netcoreapp1.0`
	
Publish the current application using the `netcoreapp1.0` framework and runtime for `OS X 10.10` (this RID has to 
exist in the project file).

`dotnet publish --framework netcoreapp1.0 --runtime osx.10.11-x64`

## See also
* [Frameworks](../../../standard/frameworks.md)
* [Runtime IDentifier (RID) catalog](../../rid-catalog.md)
