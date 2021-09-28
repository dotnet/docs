---
title: dotnet store command
description: The 'dotnet store' command stores the specified assemblies in the runtime package store.
ms.date: 02/14/2020
---
# dotnet store

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet store` - Stores the specified assemblies in the [runtime package store](../deploying/runtime-store.md).

## Synopsis

```dotnetcli
dotnet store -m|--manifest <PATH_TO_MANIFEST_FILE>
    -f|--framework <FRAMEWORK_VERSION> -r|--runtime <RUNTIME_IDENTIFIER>
    [--framework-version <FRAMEWORK_VERSION>] [--output <OUTPUT_DIRECTORY>]
    [--skip-optimization] [--skip-symbols] [-v|--verbosity <LEVEL>]
    [--working-dir <WORKING_DIRECTORY>]

dotnet store -h|--help
```

## Description

`dotnet store` stores the specified assemblies in the [runtime package store](../deploying/runtime-store.md). By default, assemblies are optimized for the target runtime and framework. For more information, see the [runtime package store](../deploying/runtime-store.md) topic.

## Required options

<!-- markdownlint-disable MD012 -->

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [target framework](../../standard/frameworks.md). The target framework has to be specified in the project file.

- **`-m|--manifest <PATH_TO_MANIFEST_FILE>`**

  The *package store manifest file* is an XML file that contains the list of packages to store. The format of the manifest file is compatible with the SDK-style project format. So, a project file that references the desired packages can be used with the `-m|--manifest` option to store assemblies in the runtime package store. To specify multiple manifest files, repeat the option and path for each file. For example: `--manifest packages1.csproj --manifest packages2.csproj`.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  The [runtime identifier](../rid-catalog.md) to target.

## Optional options

- **`--framework-version <FRAMEWORK_VERSION>`**

  Specifies the .NET SDK version. This option enables you to select a specific framework version beyond the framework specified by the `-f|--framework` option.

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Specifies the path to the runtime package store. If not specified, it defaults to the *store* subdirectory of the user profile .NET installation directory.

- **`--skip-optimization`**

  Skips the optimization phase.

- **`--skip-symbols`**

  Skips symbol generation. Currently, you can only generate symbols on Windows and Linux.

[!INCLUDE [verbosity](../../../includes/cli-verbosity.md)]

- **`-w|--working-dir <WORKING_DIRECTORY>`**

  The working directory used by the command. If not specified, it uses the *obj* subdirectory of the current directory.

## Examples

- Store the packages specified in the *packages.csproj* project file for .NET Core 2.0.0:

  ```dotnetcli
  dotnet store --manifest packages.csproj --framework-version 2.0.0
  ```

- Store the packages specified in the *packages.csproj* without optimization:

  ```dotnetcli
  dotnet store --manifest packages.csproj --skip-optimization
  ```

## See also

- [Runtime package store](../deploying/runtime-store.md)
