---
title: dotnet clean command
description: The dotnet clean command cleans the current directory.
ms.date: 02/14/2020
---
# dotnet clean

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet clean` - Cleans the output of a project.

## Synopsis

```dotnetcli
dotnet clean [<PROJECT>|<SOLUTION>] [--artifacts-path <ARTIFACTS_DIR>]
    [-c|--configuration <CONFIGURATION>]
    [-f|--framework <FRAMEWORK>] [--interactive]
    [--nologo] [-o|--output <OUTPUT_DIRECTORY>]
    [-r|--runtime <RUNTIME_IDENTIFIER>] [--tl:[auto|on|off]]
    [-v|--verbosity <LEVEL>]

dotnet clean -h|--help
```

## Description

The `dotnet clean` command cleans the output of the previous build. It's implemented as an [MSBuild target](/visualstudio/msbuild/msbuild-targets), so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate (*obj*) and final output (*bin*) folders are cleaned.

## Arguments

`PROJECT | SOLUTION`

The MSBuild project or solution to clean. If a project or solution file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* or *sln*, and uses that file.

## Options

[!INCLUDE [artifacts-path](../../../includes/cli-artifacts-path.md)]

[!INCLUDE [configuration](../../../includes/cli-configuration-clean.md)]

* **`-f|--framework <FRAMEWORK>`**

  The [framework](../../standard/frameworks.md) that was specified at build time. The framework must be defined in the [project file](../project-sdk/overview.md). If you specified the framework at build time, you must specify the framework when cleaning.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

* **`--nologo`**

  Doesn't display the startup banner or the copyright message.

* **`-o|--output <OUTPUT_DIRECTORY>`**

  The directory that contains the build artifacts to clean. Specify the `-f|--framework <FRAMEWORK>` switch with the output directory switch if you specified the framework when the project was built.

  - .NET 7.0.200 SDK and later

    If you specify the `--output` option when running this command on a solution, the CLI will emit a warning (an error in 7.0.200) due to the unclear semantics of the output path. The `--output` option is disallowed because all outputs of all built projects would be copied into the specified directory, which isn't compatible with multi-targeted projects, as well as projects that have different versions of direct and transitive dependencies. For more information, see [Solution-level `--output` option no longer valid for build-related commands](../compatibility/sdk/7.0/solution-level-output-no-longer-valid.md).

* **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Cleans the output folder of the specified runtime. This is used when a [self-contained deployment](../deploying/index.md#publish-self-contained) was created.

[!INCLUDE [tl](../../../includes/cli-tl.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-normal.md)]

## Examples

* Clean a default build of the project:

  ```dotnetcli
  dotnet clean
  ```

* Clean a project built using the Release configuration:

  ```dotnetcli
  dotnet clean --configuration Release
  ```
