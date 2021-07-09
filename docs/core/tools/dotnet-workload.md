---
title: dotnet workload command
description: The 'dotnet workload' command installs, updates, and lists optional workloads.
ms.date: 07/08/2021
---
# dotnet workload

**This article applies to:** ✔️ .NET 6 (preview) and later versions

## Name

`dotnet workload [<COMMAND>]` - Installs or updates or lists optional workloads.

## Synopsis

```dotnetcli
dotnet workload <COMMAND> [<OPTIONS>]

dotnet workload [-h|--help]
```

## Description

The `dotnet workload` commands install or update or list optional workloads.

## Options

- **`-h|--help`**

  Prints out a description of how to use the command.

## `install` command

Installs a workload.

### Synopsis

```dotnetcli
dotnet workload install <PACKAGE_ID> [--add-source <SOURCE>] [--configfile <FILE>]
    [--disable-parallel] [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>] [--skip-manifest-update]
    [-v|--verbosity <LEVEL>]

dotnet workload install -h|--help
```

### Arguments

- **`PACKAGE_ID`**

  The NuGet Package Id of the workload to install.

### Options

- **`--add-source <SOURCE>`**

  Add an additional NuGet package source to use during installation.

- **`--configfile <FILE>`**

  The NuGet configuration file to use.

- **`--disable-parallel`**

  Prevent restoring multiple projects in parallel.

- **`--download-to-cache <CACHE>`**

  Download packages needed to install a workload to a folder which can be used for offline installation.

- **`--from-cache <CACHE>`**

  Complete the operation from cache (offline).

- **`--ignore-failed-sources`**

  Treat package source failures as warnings.

- **`--include-previews`**

  Allow prerelease workload manifests.

- **`--interactive`**

  Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`--no-cache`**

  Do not cache packages and http requests.

- **`--sdk-version <VERSION>`**

  The version of the SDK.

- **`--skip-manifest-update`**

  Skip updating the workload manifests.

- **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`.

## `list` command

Lists available workloads.

### Synopsis

```dotnetcli
dotnet workload list [-v|--verbosity <LEVEL>]

dotnet workload list [-h|--help]
```

### Options

- **`-h|--help`**

  Prints out a description of how to use the command.
  
- **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`.

## `update` command

Installs a workload.

### Synopsis

```dotnetcli
dotnet workload update [--add-source <SOURCE>] [--configfile <FILE>]
    [--disable-parallel] [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>]
    [-v|--verbosity <LEVEL>]

dotnet workload install -h|--help
```

### Options

- **`--add-source <SOURCE>`**

  Add an additional NuGet package source to use during installation.

- **`--configfile <FILE>`**

  The NuGet configuration file to use.

- **`--disable-parallel`**

  Prevent restoring multiple projects in parallel.

- **`--from-cache <CACHE>`**

  Complete the operation from cache (offline).

- **`--ignore-failed-sources`**

  Treat package source failures as warnings.

- **`--include-previews`**

  Allow prerelease workload manifests.

- **`--interactive`**

  Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`--no-cache`**

  Do not cache packages and http requests.

- **`--sdk-version <VERSION>`**

  The version of the SDK.

- **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`.

## Examples

