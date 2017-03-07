---
title: dotnet-publish command | Microsoft Docs
description: The dotnet-publish command publishes your .NET Core project into a directory. 
keywords: dotnet-publish, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/07/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: f2ef275a-7c5e-430a-8c30-65f52af62771
---
#dotnet-publish

## Name

`dotnet-publish` - Packs the application and all of its dependencies into a folder getting it ready for publishing.

## Synopsis

```
dotnet publish [project] [-f|--framework] [-r|--runtime] [-o|--output] [-c|--configuration] [--version-suffix] [-v|--verbosity]
dotnet publish [-h|--help]
```

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the project file and publishes the resulting set of files to a directory. The output will contain the following:

1. Intermediate Language (IL) code in an assembly with a `*.dll` extension.
2. *deps.json* file that contains all of the dependencies of the project. 
3. *Runtime.config.json* file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).
4. All of the application's dependencies. These are copied out of the NuGet cache and into the output folder. 

The `dotnet publish` command's output is ready to be deployed in a remote machine for execution and is the only officially supported way to prepare the application to be deployed to another machine (for example, a server) for execution. Depending on the type of deployment that the project specifies, the remote machine will have to have .NET Core shared runtime installed on it. For more information, see the [.NET Core Application Deployment](../deploying/index.md) topic.

## Arguments

`project` 

The project to publish, which defaults to the current directory if `project` is not specified. 

## Options

`-h|--help`

Prints out a short help for the command.  

`-f|--framework <FRAMEWORK>`

Publishes the application for specified target framework. The target framework has to be specified in the project file.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Publishes the application for a given runtime. This is used when creating a [self-contained deployment](../deploying/index.md#self-contained-deployments-scd). For a list of Runtime Identifiers (RIDs) you can use, see the [RID catalog](../rid-catalog.md). Default is to publish a [framework-dependented app](../deploying/index.md#framework-dependent-deployments-fdd).

`-o|--output <OUTPUT_PATH>`

Specify the path where to place the directory. If not specified, it will default to *_./bin/[configuration]/[framework]/_* 
for portable applications or *_./bin/[configuration]/[framework]/[runtime]_* for self-contained deployments.

`-c|--configuration {Debug|Release}`

Configuration to use when building the project. The default value is `Debug`.

`--version-suffix <VERSION_SUFFIX>`

Defines what `*` should be replaced with in the version field in the project file.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Publish the project found in the current directory:

`dotnet publish`

Publish the application using the specified project file:

`dotnet publish ~/projects/app1/app1.csproj`
	
Publish the project found in the current directory using the `netcoreapp1.1` framework:

`dotnet publish --framework netcoreapp1.1`
	
Publish the current application using the `netcoreapp1.1` framework and runtime for `OS X 10.10` (this RID has to 
exist in the project file).

`dotnet publish --framework netcoreapp1.1 --runtime osx.10.11-x64`

## See also
* [Frameworks](../../standard/frameworks.md)
* [Runtime IDentifier (RID) catalog](../rid-catalog.md)