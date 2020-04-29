---
title: dotnet clean command
description: The dotnet clean command cleans the current directory.
ms.date: 02/14/2020
---
# dotnet clean

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet clean` - Cleans the output of a project.

## Synopsis

```dotnetcli
dotnet clean [<PROJECT>|<SOLUTION>] [-c|--configuration <CONFIGURATION>]
    [-f|--framework <FRAMEWORK>] [--interactive]
    [--nologo] [-o|--output <OUTPUT_DIRECTORY>]
    [-r|--runtime <RUNTIME_IDENTIFIER>] [-v|--verbosity <LEVEL>]

dotnet clean -h|--help
```

## Description

The `dotnet clean` command cleans the output of the previous build. It's implemented as an [MSBuild target](/visualstudio/msbuild/msbuild-targets), so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate (*obj*) and final output (*bin*) folders are cleaned.

## Arguments

`PROJECT | SOLUTION`

The MSBuild project or solution to clean. If a project or solution file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* or *sln*, and uses that file.

## Options

* **`-c|--configuration <CONFIGURATION>`**

  Defines the build configuration. The default for most projects is `Debug`, but you can override the build configuration settings in your project. This option is only required when cleaning if you specified it during build time.

* **`-f|--framework <FRAMEWORK>`**

  The [framework](../../standard/frameworks.md) that was specified at build time. The framework must be defined in the [project file](csproj.md). If you specified the framework at build time, you must specify the framework when cleaning.

* **`-h|--help`**

  Prints out a short help for the command.

* **`--interactive`**

  Allows the command to stop and wait for user input or action. For example, to complete authentication. Available since .NET Core 3.0 SDK.

* **`--nologo`**

  Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.

* **`-o|--output <OUTPUT_DIRECTORY>`**

  The directory that contains the build artifacts to clean. Specify the `-f|--framework <FRAMEWORK>` switch with the output directory switch if you specified the framework when the project was built.

* **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Cleans the output folder of the specified runtime. This is used when a [self-contained deployment](../deploying/index.md#publish-self-contained) was created.

* **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `normal`.

## Examples

* Clean a default build of the project:

  ```dotnetcli
  dotnet clean
  ```

* Clean a project built using the Release configuration:

  ```dotnetcli
  dotnet clean --configuration Release
  ```
