---
title: dotnet-publish command (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: The dotnet-publish command publishes your .NET Core project into a directory. 
keywords: dotnet-publish, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/07/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: ff2471cd-07ed-49cf-bc1c-2a6f20acbd3f
---

# dotnet-publish (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet-publish` - Packs the application and its dependencies into a folder for deployment to a hosting system.

## Synopsis

`dotnet publish [<PROJECT>] [-h|--help] [-c|--configuration] [-f|--framework] [--manifest] [-o|--output] [-r|--runtime] [--self-contained] [-v|--verbosity] [--version-suffix]`

Optional arguments appear in brackets.

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output contains the following:

- Intermediate Language (IL) code in an assembly with a *.dll* extension.
- *\*.deps.json* file containing all of the dependencies of the project.
- *\*.runtime.config.json* file specifying the shared runtime that the application expects and other configuration options for the runtime (for example, garbage collection type).
- The application's dependencies. These are copied from the NuGet cache into the output folder.

The `dotnet publish` command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution and is the only officially supported way to prepare the application for deployment. The .NET Core shared runtime is required on the hosting system for framework-dependent deployments to run. Self-contained deployments include the runtime, so the hosting system doesn't require pre-installation of the shared runtime. For more information, see [.NET Core Application Deployment](../deploying/index.md). For the directory structure of a published application, see [Directory structure](https://docs.microsoft.com/aspnet/core/hosting/directory-structure).

## Arguments

### Command parameters

`PROJECT`

Optional. The project to publish, which defaults to the current directory if not specified. 

### Required options

None

### Optional options

`-h|--help`

Show help information.

`-c|--configuration <CONFIGURATION>`

Configuration to use when building the project. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Publishes the application for the specified [target framework](../../standard/frameworks.md). You must specify the target framework in the project file.

`--manifest <manifest.xml>`

Specifies one or several [target manifests](../deploying/runtime-package-store.md) to use to trim the set of packages that published with the application. The manifest file is part of the output of the [`dotnet store` command](dotnet-store.md). To specify multiple manifests, add a `--manifest` option for each manifest.

`-o|--output <OUTPUT_DIRECTORY>`

Specifies the path for the output directory. If not specified, it defaults to *./bin/[configuration]/[framework]/* for a framework-dependent deployment or *./bin/[configuration]/[framework]/[runtime]/* for a self-contained deployment.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Publishes the application for a given runtime. This is used when creating a [self-contained deployment (SCD)](../deploying/index.md#self-contained-deployments-scd). For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Default is to publish a [framework-dependent deployment (FDD)](../deploying/index.md#framework-dependent-deployments-fdd).

`--self-contained`

Publish the .NET Core runtime with your application so the app can run on the hosting system without having the runtime installed. Defaults to `true` when a runtime identifier (RID) is specified.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix to replace the asterisk (`*`) in the version field (`$(VersionSuffix)`) of the project file.

## Examples

Publish the project in the current directory:

`dotnet publish`

Publish the application using the specified project file:

`dotnet publish ~/projects/app1/app1.csproj`

Publish the project in the current directory using the `netcoreapp2.0` framework:

`dotnet publish --framework netcoreapp2.0`

Publish the current application using the `netcoreapp2.0` framework and the runtime for `OS X 10.12` [you must list the runtime (RID) in the project file]:

`dotnet publish --framework netcoreapp2.0 --runtime osx.10.12-x64`

Publish the current application without the packages specified in the *main-manifest.xml* and *other-manifest.xml* target manifests:

`dotnet publish --manifest main-manifest.xml --manifest other-manifest.xml`

## See also

[Target frameworks](../../standard/frameworks.md)   
[Runtime IDentifier (RID) catalog](../rid-catalog.md)
