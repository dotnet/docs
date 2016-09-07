---
title: dotnet-build
description: dotnet-build
keywords: .NET, .NET Core
author: mairaw
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 70285a83-4103-4617-be8b-d0e1e9a4a91d
---

dotnet-build
===========

## NAME 
dotnet-build -- Builds a project and all of its dependencies 

## SYNOPSIS

`dotnet build [--output]  
    [--build-base-path] [--framework]  
    [--configuration]  [--runtime] [--version-suffix]
    [--build-profile]  [--no-incremental] [--no-dependencies]
    [<project>]`  

## DESCRIPTION

The `dotnet build` command builds multiple source file from a source project and its dependencies into a binary. 
By default, the resulting binary is in Intermediate Language (IL) and has a DLL extension. 
`dotnet build` also drops a `\*.deps` file which outlines what the host needs to run the application.  

Building requires the existence of a lock file, which means that you have to run [`dotnet restore`](dotnet-restore.md) prior to building your code.

Before any compilation begins, the `build` verb analyzes the project and its dependencies for incremental safety checks.
If all checks pass, then build proceeds with incremental compilation of the project and its dependencies; 
otherwise, it falls back to non-incremental compilation. Via a profile flag, users can choose to receive additional 
information on how they can improve their build times.

All projects in the dependency graph that need compilation must pass the following safety checks in order for the 
compilation process to be incremental:
- not use pre/post compile scripts
- not load compilation tools from PATH (for example, resgen, compilers)
- use only known compilers (csc, vbc, fsc)

In order to build an executable application instead of a library, you need a [special configuration](project-json.md#emitentrypoint) section in your project.json file:

```json
{ 
    "buildOptions": {
      "emitEntryPoint": true
    }
}
```

## OPTIONS

`-o`, `--output` [DIR]

Directory in which to place the built binaries. 

`-b`, `--build-base-path` [DIR]

Directory in which to place temporary outputs.

`-f`, `--framework` [FRAMEWORK]

Compiles for a specific framework. The framework needs to be defined in the project.json file.

`-c`, `--configuration` [Debug|Release]

Defines a configuration under which to build.  If omitted, it defaults to Debug.

`-r`, `--runtime` [RUNTIME_IDENTIFIER]

Target runtime to build for. 

`--version-suffix` [VERSION_SUFFIX]

Defines what `*` should be replaced with in the version field in the project.json file. The format follows NuGet's version guidelines. 

`--build-profile`

Prints out the incremental safety checks that users need to address in order for incremental compilation to be automatically turned on.

`--no-incremental`

Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project dependency graph.

`--no-dependencies`

Ignores project-to-project references and only builds the root project specified to build.
