---
title: dotnet-publish command - .NET Core CLI | Microsoft Docs
description: The dotnet-publish command publishes your .NET Core project into a directory. 
keywords: dotnet-publish, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/15/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: f2ef275a-7c5e-430a-8c30-65f52af62771
---

# dotnet-publish

## Name

`dotnet-publish` - Packs the application and its dependencies into a folder for deployment to a hosting system.

## Synopsis

`dotnet publish [<PROJECT>] [-f|--framework] [-r|--runtime] [-o|--output] [-c|--configuration] [--version-suffix] [-v|--verbosity] [-h|--help]`

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output will contain the following:

* Intermediate Language (IL) code in an assembly with a `*.dll` extension.
* *\*.deps.json* file that contains all of the dependencies of the project.
* *\*.runtime.config.json* file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).
* The application's dependencies. These are copied from the NuGet cache into the output folder.

The `dotnet publish` command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution and is the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET Core shared runtime installed on it. For more information, see [.NET Core Application Deployment](../deploying/index.md). For the directory structure of a published application, see [Directory structure](https://docs.microsoft.com/en-us/aspnet/core/hosting/directory-structure).

## Arguments

`PROJECT` 

The project to publish, which defaults to the current directory if not specified. 

## Options

`-h|--help`

Prints out a short help for the command.  

`-f|--framework <FRAMEWORK>`

Publishes the application for the specified [target framework](../../standard/frameworks.md). You must specify the target framework in the project file.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Publishes the application for a given runtime. This is used when creating a [self-contained deployment (SCD)](../deploying/index.md#self-contained-deployments-scd). For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Default is to publish a [framework-dependent deployment (FDD)](../deploying/index.md#framework-dependent-deployments-fdd).

`-o|--output <OUTPUT_DIRECTORY>`

Specifies the path for the output directory. If not specified, it defaults to *./bin/[configuration]/[framework]/* for a framework-dependent deployment or *./bin/[configuration]/[framework]/[runtime]* for a self-contained deployment.

`-c|--configuration <CONFIGURATION>`

Configuration to use when building the project. The default value is `Debug`.

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix to replace the asterisk (`*`) in the version field of the project file.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Publish the project in the current directory:

`dotnet publish`

Publish the application using the specified project file:

`dotnet publish ~/projects/app1/app1.csproj`
	
Publish the project in the current directory using the `netcoreapp1.1` framework:

`dotnet publish --framework netcoreapp1.1`
	
Publish the current application using the `netcoreapp1.1` framework and the runtime for `OS X 10.10` (you must list this RID in the project file).

`dotnet publish --framework netcoreapp1.1 --runtime osx.10.11-x64`

## See also

* [Target frameworks](../../standard/frameworks.md)
* [Runtime IDentifier (RID) catalog](../rid-catalog.md)