---
title: dotnet clean command
description: The 'dotnet clean' command cleans the current directory.
keywords: dotnet clean, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: eff65fa1-bab4-4421-8260-d0a284b690b2
---

# dotnet clean

## Name

`dotnet clean` - Cleans the output of a project. 

## Synopsis

`dotnet clean [<PROJECT>] [-c|--configuration] [-f|--framework] [-h|--help] [-o|--output] [-r|--runtime] [-v|--verbosity]`

## Description

The `dotnet clean` command cleans the output of the previous build. It's implemented as an [MSBuild target](/visualstudio/msbuild/msbuild-targets), so the project is evaluated when the command is run. Only the outputs created from a build are cleaned. Both intermediate (*obj*) and final output (*bin*) folders are cleaned.

> [!NOTE]
> Deployments created with the `dotnet publish` command (*publish* folder contents) aren't cleaned by the `dotnet clean` command.

## Arguments

`PROJECT`

The MSBuild project to clean. If a project file isn't specified, MSBuild searches the current working directory for a file with a *proj* file extension.

## Options

`-c|--configuration <CONFIGURATION>`

Defines the configuration. If omitted, it defaults to `Debug`. This property is only required if you specified it when you built the project.

`-f|--framework <FRAMEWORK>`

The [framework](../../standard/frameworks.md) that was specified when you built the project. The framework must be defined in the [project file](csproj.md). If you specified the framework when you built the project, you must specify the framework when using `dotnet clean`.

`-h|--help`

Shows help information.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which the build outputs are placed. Specify the `-f|--framework <FRAMEWORK>` option with the `-o|--output <OUTPUT_DIRECTORY>` option if you specified the framework when the project was built.

`-r|--runtime <RUNTIME_IDENTIFIER>`

The [runtime](../rid-catalog.md) specified when you built the project. If you specified the runtime when you built the project, you must specify the runtime when using `dotnet clean`.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed levels are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Clean a default build of the project:

`dotnet clean`

Clean a project built using the Release configuration:

`dotnet clean --configuration Release`
