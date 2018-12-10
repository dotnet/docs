---
title: dotnet clean command
description: The dotnet clean command cleans the current directory.
ms.date: 12/04/2018
---
# dotnet clean

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet clean` - Cleans the output of a project.

## Synopsis

```
dotnet clean [<PROJECT>] [-c|--configuration] [-f|--framework] [-o|--output] [-r|--runtime] [-v|--verbosity]
dotnet clean [-h|--help]
```

## Description

The `dotnet clean` command cleans the output of the previous build. It's implemented as an [MSBuild target](/visualstudio/msbuild/msbuild-targets), so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate (*obj*) and final output (*bin*) folders are cleaned.

## Arguments

`PROJECT`

The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* and uses that file.

## Options

* **`-c|--configuration {Debug|Release}`**

  Defines the build configuration. The default value is `Debug`. This option is only required when cleaning if you specified it during build time.

* **`-f|--framework <FRAMEWORK>`**

  The [framework](../../standard/frameworks.md) that was specified at build time. The framework must be defined in the [project file](csproj.md). If you specified the framework at build time, you must specify the framework when cleaning.

* **`-h|--help`**

  Prints out a short help for the command.

* **`-o|--output <OUTPUT_DIRECTORY>`**

  Directory in which the build outputs are placed. Specify the `-f|--framework <FRAMEWORK>` switch with the output directory switch if you specified the framework when the project was built.

* **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Cleans the output folder of the specified runtime. This is used when a [self-contained deployment](../deploying/index.md#self-contained-deployments-scd) was created. Option available since .NET Core 2.0 SDK.

* **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].

## Examples

* Clean a default build of the project:

  ```console
  dotnet clean
  ```

* Clean a project built using the Release configuration:

  ```console
  dotnet clean --configuration Release
  ```