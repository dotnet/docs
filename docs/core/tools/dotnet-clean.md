---
title: dotnet clean command - .NET Core CLI
description: The dotnet clean command cleans the current directory.
author: mairaw
ms.author: mairaw
ms.date: 08/13/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet-clean

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet clean` - Cleans the output of a project.

## Synopsis

# [.NET Core 2.x](#tab/netcore2x)
```
dotnet clean [<PROJECT>] [-c|--configuration] [-f|--framework] [-o|--output] [-r|--runtime] [-v|--verbosity]
dotnet clean [-h|--help]
```
# [.NET Core 1.x](#tab/netcore1x)
```
dotnet clean [<PROJECT>] [-c|--configuration] [-f|--framework] [-o|--output] [-v|--verbosity]
dotnet clean [-h|--help]
```
---

## Description

The `dotnet clean` command cleans the output of the previous build. It's implemented as an [MSBuild target](/visualstudio/msbuild/msbuild-targets), so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate (*obj*) and final output (*bin*) folders are cleaned.

## Arguments

`PROJECT`

The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* and uses that file.

## Options

# [.NET Core 2.x](#tab/netcore2x)

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`. This option is only required when cleaning if you specified it during build time.

`-f|--framework <FRAMEWORK>`

The [framework](../../standard/frameworks.md) that was specified at build time. The framework must be defined in the [project file](csproj.md). If you specified the framework at build time, you must specify the framework when cleaning.

`-h|--help`

Prints out a short help for the command.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which the build outputs are placed. Specify the `-f|--framework <FRAMEWORK>` switch with the output directory switch if you specified the framework when the project was built.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Cleans the output folder of the specified runtime. This is used when a [self-contained deployment](../deploying/index.md#self-contained-deployments-scd) was created.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

# [.NET Core 1.x](#tab/netcore1x)

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`. This option is only required when cleaning if you specified it during build time.

`-f|--framework <FRAMEWORK>`

The [framework](../../standard/frameworks.md) that was specified at build time. The framework must be defined in the [project file](csproj.md). If you specified the framework at build time, you must specify the framework when cleaning.

`-h|--help`

Prints out a short help for the command.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which the build outputs are placed. Specify the `-f|--framework <FRAMEWORK>` switch with the output directory switch if you specified the framework when the project was built.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

---

## Examples

Clean a default build of the project:

`dotnet clean`

Clean a project built using the Release configuration:

`dotnet clean --configuration Release`
