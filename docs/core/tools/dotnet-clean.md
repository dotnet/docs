---
title: dotnet-clean command - .NET Core CLI | Microsoft Docs
description: The dotnet-clean command cleans the current directory.
keywords: dotnet-clean, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/15/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: eff65fa1-bab4-4421-8260-d0a284b690b2
---

# dotnet-clean

## Name

`dotnet-clean` - Cleans the output of a project. 

## Synopsis

`dotnet clean [<PROJECT>] [-o|--output] [-f|--framework] [-c|--configuration] [-v|--verbosity] [-h|--help]`

## Description

The `dotnet clean` command cleans the output of the previous build. It's implemented as an [MSBuild target](https://docs.microsoft.com/visualstudio/msbuild/msbuild-targets), so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate (*obj*) and final output (*bin*) folders are cleaned.

## Arguments

`PROJECT`

The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* and uses that file.

## Options

`-h|--help`

Prints out a short help for the command.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which the build outputs are placed. Specify the `-f|--framework <FRAMEWORK>` switch with the output directory switch if you specified the framework when the project was built.

`-f|--framework <FRAMEWORK>`

The [framework](../../standard/frameworks.md) that was specified at build time. The framework must be defined in the [project file](csproj.md). If you specified the framework at build time, you must specify the framework when cleaning.

`-c|--configuration <CONFIGURATION>`

Defines the configuration. If omitted, it defaults to `Debug`. This property is only required when cleaning if you specified it during build time.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

## Examples

Clean a default build of the project:

`dotnet clean`

Clean a project built using the Release configuration:

`dotnet clean --configuration Release`
