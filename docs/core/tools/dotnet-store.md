---
title: dotnet store command (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: The 'dotnet store' command stores the specified assemblies in the runtime package store.
keywords: dotnet store, dotnet store, CLI, CLI command, .NET Core
author: bleroy
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 1e8e4122-8110-4b48-afce-afffb6737776
---

# dotnet store (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet store` - Stores the specified assemblies in the [runtime package store](../deploying/runtime-package-store.md).

## Synopsis

`dotnet store -m|--manifest -f|--framework -r|--runtime  [--framework-version] [-h|--help] [--output] [--skip-optimization] [--skip-symbols] [-v|--verbosity] [--working-dir]`

## Description

`dotnet store` stores the specified assemblies in the [runtime package store](../deploying/runtime-package-store.md). By default, assemblies are optimized for the target runtime and framework. For more information, see the [runtime package store](../deploying/runtime-package-store.md) topic.

## Required options

`-f|--framework <FRAMEWORK>`

Specifies the [target framework](../../standard/frameworks.md).

`-m|--manifest <MANIFEST_FILE>`

The XML file, or a list of XML files, that contain the list of packages to store. The format of the manifest files is compatible with the *csproj* format, so a *csproj* project file referencing the desired packages can be used with the `-m|--manifest` option to store assemblies in the runtime package store.

`-r|--runtime <RUNTIME_IDENTIFIER>`

The runtime identifier to target.

## Optional options

`--framework-version <FRAMEWORK_VERSION>`

Specifies the .NET Core SDK version. This option enables you to select a specific framework version beyond the framework specified by the `-f|--framework` option.

`-h|--help`

Shows help information.

`-o|--output <OUTPUT_DIRECTORY>`

Specifies the path to the runtime package store. If not specified, it defaults to the *store* subdirectory of the user profile .NET Core installation directory.

`--skip-optimization`

Skips the optimization phase.

`--skip-symbols`

Skips symbol generation. Currently, you can only generate symbols on Windows and Linux.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--working-dir <INTERMEDIATE_WORKING_DIRECTORY>`

The working directory used by the command. If not specified, it uses the *obj* subdirectory of the current directory.

## Examples

Store the packages specified in the *packages.csproj* project file for .NET Core 2.0.0:

`dotnet store --manifest packages.csproj --framework-version 2.0.0-preview1-1234`

Store the packages specified in the *packages.csproj* without optimization:

`dotnet store --manifest packages.csproj --skip-optimization`

## See also

[Runtime package store](../deploying/runtime-package-store.md)   
