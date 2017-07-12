---
title: dotnet-store command (.NET Core SDK 2.0 Preview 1) | .NET Core SDK
description: The dotnet-store Stores the specified assemblies in the runtime package store.
keywords: dotnet-store, dotnet-publish, CLI, CLI command, .NET Core
author: bleroy
ms.author: beleroy
ms.date: 4/13/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 1e8e4122-8110-4b48-afce-afffb6737776
---
# dotnet-store (.NET Core SDK 2.0 Preview 1)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet-store` - Stores the specified assemblies in the [runtime package store](../deploying/runtime-package-store.md).

## Synopsis

`dotnet store -m|--manifest -r|--runtime -f|--framework [--framework-version] [--output] [--working-dir] [--skip-optimization] [--skip-symbols] [-v|--verbosity] [-h|--help]`

## Description

`dotnet store` stores the specified assemblies in the [runtime package store](../deploying/runtime-package-store.md).

By default, these assemblies are optimized for the target runtime and framework.

For more information, see the [runtime package store](../deploying/runtime-package-store.md) topic.

## Options

`-h|--help`

Prints out a short help for the command.

`-m|--manifest <MANIFEST>`

The XML file, or a list of XML files, that contain the list of packages to be stored. The format of the files is compatible with the `csproj` format, so a project file referencing the desired packages can be used. This parameter is mandatory.

`-r|--runtime`

The runtime identifier to target, for example `win7-x64`. This parameter is mandatory.

`-f|--framework`

The framework to target, for example `netcoreapp2.0`. This parameter is mandatory.

`--framework-version <FRAMEWORK_VERSION>`

The .NET Core SDK version to use. This option enables to fine tune to a specific version beyond the one that is part of `-f|--framework`. 
For example: `2.0.0-preview1-1234`.

`-o|--output <OUTPUT_PATH>`

Specify the path to the runtime package store. If not specified, it defaults to the *store* subdirectory of the user profile .NET Core installation directory.

`--working-dir <WORKING_DIRECTORY>`

The working directory used by the command to execute. If not specified, it works under the *obj* subdirectory of the current directory.

`--skip-optimization`

Skips the optimization phase.

`--skip-symbols`

Skips symbol generation. Currently, symbols can only be generated on Windows and Linux.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Store the packages specified in the `packages.csproj` for .NET Core 2.0.0:

`dotnet store --manifest packages.csproj --framework-version 2.0.0`

Store the packages specified in the `packages.csproj` without optimization:

`dotnet store --manifest packages.csproj --skip-optimization`

## See also

 [Runtime package store](../deploying/runtime-package-store.md)   