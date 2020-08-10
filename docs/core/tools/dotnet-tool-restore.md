---
title: dotnet tool restore command
description: The dotnet tool restore command installs on your machine the .NET Core local tools that are in scope for the current directory.
ms.date: 02/14/2020
---
# dotnet tool restore

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

## Name

`dotnet tool restore` - Installs on your machine the .NET Core local tools that are in scope for the current directory.

## Synopsis

```dotnetcli
dotnet tool restore
    [--configfile <FILE>] [--add-source <SOURCE>]
    [tool-manifest <PATH_TO_MANIFEST_FILE>] [--disable-parallel]
    [--ignore-failed-sources] [--no-cache] [--interactive]
    [-v|--verbosity <LEVEL>]

dotnet tool restore -h|--help
```

## Description

The `dotnet tool restore` command finds the tool manifest file that is in scope for the current directory and installs the tools that are listed in it. For information about manifest files, see [Install a local tool](global-tools.md#install-a-local-tool) and [Invoke a local tool](global-tools.md#invoke-a-local-tool).

## Options

- **`--configfile <FILE>`**

  The NuGet configuration (*nuget.config*) file to use.

- **`--add-source <SOURCE>`**

  Adds an additional NuGet package source to use during installation.

- **`--tool-manifest <PATH>`**

  Path to the manifest file.

- **`--disable-parallel`**

  Prevent restoring multiple projects in parallel.

- **`--ignore-failed-sources`**

  Treat package source failures as warnings.

- **`--no-cache`**

  Do not cache packages and http requests.

- **`--interactive`**

  Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`-h|--help`**

  Prints out a short help for the command.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Example

- **`dotnet tool restore`**

  Restores local tools for the current directory.

## See also

- [.NET Core tools](global-tools.md)
- [Tutorial: Install and use a .NET Core local tool using the .NET Core CLI](local-tools-how-to-use.md)
