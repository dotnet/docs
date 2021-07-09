---
title: dotnet workload install command
description: The 'dotnet workload install' command installs optional workloads.
ms.date: 07/08/2021
---
# dotnet workload

**This article applies to:** ✔️ .NET 6 Preview and later versions

## Name

`dotnet workload install` - Installs optional workloads.

## Synopsis

```dotnetcli
dotnet workload install <PACKAGE_ID>
    [--add-source <SOURCE>] [--configfile <FILE>] [--disable-parallel]
    [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>] [--skip-manifest-update]
    [-v|--verbosity <LEVEL>]

dotnet workload install -h|--help
```

## Arguments

- **`PACKAGE_ID`**

  The NuGet Package Id of the workload to install.

## Options

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

## Examples

