---
title: dotnet-store command - .NET Core CLI | Microsoft Docs
description: The dotnet-store command stores the specified assemblies in the runtime package store.
keywords: dotnet-store, dotnet-publish, CLI, CLI command, .NET Core
author: beleroy
manager: wpickett
ms.date: 10/07/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
---

#dotnet-store

## Name

`dotnet-store` - Stores the specified assemblies in the [runtime package store](../deploying/runtime-package-store.md).

## Synopsis

`dotnet store [--manifest] [--framework-version] [--output] [--working-dir] [--preserve-working-dir] [--skip-optimization] [-v|--verbosity] [-h|--help]`

## Description

`dotnet store` stores the specified assemblies in the [runtime package store](../deploying/runtime-package-store.md).

By default, these will be optimized for the target runtime and framework.

For more information, see the [runtime package store](../deploying/runtime-package-store.md) topic.

## Options

`-h|--help`

Prints out a short help for the command.  

`-m|--manifest <TARGET_MANIFEST>`

The XML file, or a list of XML files, that contain the list of packages to be stored. 

`--framework-version <FRAMEWORK_VERSION>`

The Microsoft.NETCore.App package version that will be used to run the assemblies.

`-o|--output <OUTPUT_PATH>`

Specify the path to the runtime package store. If not specified, it will default to the *store* subdirectory of the global .NET Core installation directory.

`--working-dir <WORKING_DIRECTORY>`

The working directory used by the command to execute.

`--preserve-working-dir`

If specified, the working directory is preserved after the command finished executing.

`--skip-optimization`

Skips the optimization phase.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Store the packages specified in the `packages.csproj` for .NET Core 2.0.0:

`dotnet store --manifest packages.csproj --framework-version 2.0.0`

Store the packages specified in the `packages.csproj` without optimization:

`dotnet store --manifest packages.csproj --skip-optimization`

## See also

* [Runtime package store](../deploying/runtime-package-store.md)