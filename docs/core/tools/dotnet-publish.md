---
title: dotnet publish command
description: The 'dotnet publish' command publishes your .NET Core project into a directory. 
keywords: dotnet publish, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: ff2471cd-07ed-49cf-bc1c-2a6f20acbd3f
---
# dotnet publish

## Name

`dotnet publish` - Packs the app and its dependencies into a folder for deployment to a hosting system.

## Synopsis

`dotnet publish [<PROJECT>] [-h|--help] [-c|--configuration] [-f|--framework] [--manifest] [-o|--output] [-r|--runtime] [--self-contained] [-v|--verbosity] [--version-suffix]`

## Description

`dotnet publish` compiles the app, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output contains the following:

- Intermediate Language (IL) code in an assembly with a *dll* extension.
- *\<assembly_name>.deps.json* file containing all of the dependencies of the project.
- *\<assembly_name>.runtime.config.json* file specifying the shared runtime that the app expects and other configuration options for the runtime (for example, the garbage collection type).
- The app's dependencies. These are copied from the NuGet cache into the output folder.

The `dotnet publish` command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution and is the only officially-supported way to prepare the app for deployment. The .NET Core shared runtime is required on the hosting system for framework-dependent deployments to run. Self-contained deployments include the runtime, so the hosting system doesn't require pre-installation of the shared runtime. For more information, see [.NET Core Application Deployment](../deploying/index.md). For the directory structure of a published app, see [Directory structure](/aspnet/core/hosting/directory-structure). If you plan to deploy an ASP.NET Core app, see [Hosting and deployment overview for ASP.NET Core apps](/aspnet/core/publishing/). 

## Arguments

`PROJECT`

Optional. The project to publish, which defaults to the current directory if not specified. 

## Options

`-h|--help`

Shows help information.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Specifies the [target framework](../../standard/frameworks.md). You must specify the target framework in the project file in either the **\<TargetFramework>** or **\<TargetFrameworks>** property. For more information, see [Additions to the csproj format for .NET Core](csproj.md).

`-o|--output <OUTPUT_DIRECTORY>`

Specifies the path for the output directory. If not specified, it defaults to *./bin/[configuration]/[framework]/* for a framework-dependent deployment (FDD) or *./bin/[configuration]/[framework]/[runtime]/* for a self-contained deployment (SCD). For more information on the two types of deployement, see [.NET Core application deployment](../deploying/index.md).

`-r|--runtime <RUNTIME_IDENTIFIER>`

Publishes the app for a given runtime. This is used when creating a [self-contained deployment (SCD)](../deploying/index.md#self-contained-deployments-scd). For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). The default is to publish a [framework-dependent deployment (FDD)](../deploying/index.md#framework-dependent-deployments-fdd).

`--self-contained [<true|false>]`

Publishes the .NET Core runtime with your app, so the app can run on hosting systems where the runtime isn't installed. Defaults to `true` if `false` isn't specified or when a runtime identifier (RID) is specified with the `-r|--runtime` option.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix to replace the asterisk (`*`) in the version field (`$(VersionSuffix)`) of the project file. The format follows NuGet's version guidelines. For more information, see [Specifying dependency versions for NuGet Packages](https://docs.microsoft.com/nuget/create-packages/dependency-versions#normalized-version-numbers).

## Examples

Publish the project in the current directory:

`dotnet publish`

Publish the app using the specified project file:

`dotnet publish ~/projects/app1/app1.csproj`

Publish the project in the current directory using the `netcoreapp2.0` framework:

`dotnet publish --framework netcoreapp2.0`

Publish the current app using the `netcoreapp2.0` framework and the runtime for `OS X 10.12` [you must list the runtime (RID) in the project file]:

`dotnet publish --framework netcoreapp2.0 --runtime osx.10.12-x64`

Publish the current app without the packages specified in the *main-manifest.xml* and *other-manifest.xml* target manifests:

`dotnet publish --manifest main-manifest.xml --manifest other-manifest.xml`

## See also

[Target frameworks](../../standard/frameworks.md)   
[Runtime IDentifier (RID) catalog](../rid-catalog.md)
