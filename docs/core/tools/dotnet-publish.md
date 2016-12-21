---
title: dotnet-publish command | .NET Core SDK
description: The dotnet-publish command publishes your .NET Core project into a directory. 
keywords: dotnet-publish, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/07/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 8a7e1c52-5c57-4bf5-abad-727450ebeefd
---

#dotnet-publish

## Name

`dotnet-publish` - Packs the application and all of its dependencies into a folder getting it ready for publishing.

## Synopsis

`dotnet publish [project] 
    [--help] [--framework]  
    [--runtime] [--build-base-path] [--output]  
    [--version-suffix] [--configuration] [--native-subdirectory] [--no-build]`

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the [project.json](project-json.md) file and publishes the resulting set of files to a directory. 

Depending on the type of portable app, the resulting directory will contain the following:

1. *Portable application* - application's intermediate language (IL) code and all of application's managed dependencies.
    * *Portable application with native dependencies* - same as above with a sub-directory for the supported platform of each native
    dependency. 
2. *Self-contained application* - same as above plus the entire runtime for the targeted platform.

For more information, see the [.NET Core Application Deployment](../deploying/index.md) topic.

## Options

`[project]` 

The project to publish, which defaults to the current directory if `[project]` is not specified. This value can be a path to the [project.json](project-json.md) file or to the project 
directory that contains the [project.json](project-json.md) file. If no [project.json](project-json.md) file can be found, `dotnet publish` throws an error. 

`-h|--help`

Prints out a short help for the command.  

`-f|--framework <FRAMEWORK>`

Publishes the application for a given framework identifier (FID). If not specified, FID is read from [project.json](project-json.md#frameworks). If no valid framework is found, the command throws an error. If multiple valid frameworks are found, the command publishes for all valid frameworks. 

`-r|--runtime <RUNTIME_IDENTIFIER>`

Publishes the application for a given runtime. For a list of Runtime Identifiers (RIDs) you can use, see the [RID catalog](../rid-catalog.md).

`-b|--build-base-path <OUTPUT_DIRECTORY>`

Directory in which to place temporary outputs.

`-o|--output <OUTPUT_PATH>`

Specify the path where to place the directory. If not specified, it will default to *_./bin/[configuration]/[framework]/_* 
for portable applications or *_./bin/[configuration]/[framework]/[runtime]_* for self-contained deployments.

`--version-suffix [VERSION_SUFFIX]`

Defines what `*` should be replaced with in the version field in the project.json file.

`-c|--configuration [Debug|Release]`

Configuration to use when publishing. The default value is `Debug`.

`[--native-subdirectory]`
Temporary mechanism to include subdirectories from native assets of dependency packages in output. 

`[--no-build]`
Does not build projects before publishing.

## Examples

Publish an application using the framework found in `project.json`. If `project.json` contains [runtimes](project-json.md#runtimes) node, publish for the RID of the current platform.

`dotnet publish`

Publish the application using the specified [project.json](project-json.md):

`dotnet publish ~/projects/app1/project.json`
	
Publish the current application using the `netcoreapp1.0` framework:

`dotnet publish --framework netcoreapp1.0`
	
Publish the current application using the `netcoreapp1.0` framework and runtime for `OS X 10.10` (this RID has to 
exist in the `project.json` [runtimes](project-json.md#runtimes) node):

`dotnet publish --framework netcoreapp1.0 --runtime osx.10.11-x64`

## See also
* [Frameworks](../../standard/frameworks.md)
* [Runtime IDentifier (RID) catalog](../rid-catalog.md)