---
title: dotnet workload uninstall command
description: The 'dotnet workload uninstall' command uninstalls workloads.
ms.date: 07/08/2021
---
# dotnet workload

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload uninstall` - Uninstalls optional workloads.

## Synopsis

```dotnetcli
dotnet workload uninstall <WORKLOAD_ID>
    [--add-source <SOURCE>] [--configfile <FILE>] [--disable-parallel]
    [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>] [--skip-manifest-update]
    [-v|--verbosity <LEVEL>]

dotnet workload uninstall -?|-h|--help
```

## Arguments

- **`WORKLOAD_ID`**

  The workload ID of the workload to uninstall.

## Options

- **`--add-source <SOURCE>`**

  Adds an additional NuGet package source. Feeds are accessed in parallel, not sequentially in some order of precedence. If the same package and version is in multiple feeds, the fastest feed wins. For more information, see [What happens when a NuGet package is installed?](/nuget/concepts/package-uninstallation-process).

- **`--configfile <FILE>`**

  The NuGet configuration file (*nuget.config*) to use. If specified, only the settings from this file will be used. If not specified, the hierarchy of configuration files from the current directory will be used. For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior).

- **`--disable-parallel`**

  Prevents restoring multiple projects in parallel.

- **`--download-to-cache <PATH_TO_CACHE>`**

  Downloads packages needed for a workload to a folder that can be used for offline uninstallation.

- **`--from-cache <PATH_TO_CACHE>`**

  Complete the operation from cache (offline).

- **`--ignore-failed-sources`**

  Treats package source failures as warnings.

- **`--include-previews`**

  Allows prerelease workload manifests.

- **`--interactive`**

  Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`--no-cache`**

  Prevents caching of packages and http requests.

- **`--sdk-version <VERSION>`**

  The SDK version to use.

- **`--skip-manifest-update`**

  Skip updating the workload manifests.

- **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`.

## Examples

- Uninstall the `microsoft.ios.sdk.full` workload:

  ```dotnetcli
  dotnet workload uninstall microsoft.ios.sdk.full
  ```
