---
title: dotnet-store command (.NET Core SDK 2.0 Preview 2) | .NET Core SDK
description: The dotnet-store Stores the specified assemblies in the runtime package store.
keywords: dotnet-store, dotnet-publish, CLI, CLI command, .NET Core
author: beleroy
ms.author: beleroy
ms.date: 4/13/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 1e8e4122-8110-4b48-afce-afffb6737776
---

# dotnet-store (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet-store` - Stores the specified assemblies in the [runtime package store](../deploying/runtime-package-store.md).

## Synopsis

`dotnet store -m|--manifest -f|--framework -r|--runtime  [--framework-version] [-h|--help] [--output] [--skip-optimization] [--skip-symbols] [-v|--verbosity] [--working-dir]`

Optional arguments appear in brackets.

## Description

`dotnet store` stores the specified assemblies in the [runtime package store](../deploying/runtime-package-store.md).

By default, these assemblies are optimized for the target runtime and framework.

For more information, see the [runtime package store](../deploying/runtime-package-store.md) topic.

## Arguments

### Command parameters

None

### Required options

`-m|--manifest <MANIFEST>`

The XML file, or a list of XML files, that contain the list of packages to store. The format of the files is compatible with the `csproj` format, so a project file referencing the desired packages can be used.

`-f|--framework <FRAMEWORK>`

The framework to target.

`-r|--runtime <RUNTIME_IDENTIFIER>`

The runtime identifier to target.

### Optional options

`--framework-version <FRAMEWORK_VERSION>`

The .NET Core SDK version to use. This option enables you to select a specific framework version beyond framework specified by the `-f|--framework` option.

`-h|--help`

Show help information.

`-o|--output <OUTPUT_DIR>`

Specify the path to the runtime package store. If not specified, it defaults to the *store* subdirectory of the user profile .NET Core installation directory.

`--skip-optimization`

Skips the optimization phase.

`--skip-symbols`

Skips symbol generation. Currently, you can only generate symbols on Windows and Linux.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--working-dir <INTERMEDIATE_WORKING_DIRECTORY>`

The working directory used by the command. If not specified, it uses the *obj* subdirectory of the current directory.

## Examples

Store the packages specified in the *packages.csproj* for .NET Core 2.0.0:

`dotnet store --manifest packages.csproj --framework-version 2.0.0-preview1-1234`

Store the packages specified in the *packages.csproj* without optimization:

`dotnet store --manifest packages.csproj --skip-optimization`

## See also

 [Runtime package store](../deploying/runtime-package-store.md)   
