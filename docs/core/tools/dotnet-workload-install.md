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

  Adds an additional NuGet package source to use during installation. Feeds are accessed in parallel, not sequentially in some order of precedence. If the same package and version is in multiple feeds, the fastest feed wins. For more information, see [What happens when a NuGet package is installed?](/nuget/concepts/package-installation-process).

- **`--configfile <FILE>`**

  The NuGet configuration file (*nuget.config*) to use. If specified, only the settings from this file will be used. If not specified, the hierarchy of configuration files from the current directory will be used. For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior).

- **`--disable-parallel`**

  Prevents restoring multiple projects in parallel.

- **`--download-to-cache <PATH_TO_CACHE>`**

  Downloads packages needed for a workload to a folder that can be used for offline installation.

- **`--from-cache <PATH_TO_CACHE>`**

  Installs the workload from cache (offline).

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

- Install the `microsoft.ios.sdk.full` workload:

  ```dotnetcli
  dotnet workload install microsoft.ios.sdk.full
  ```

- Download the `microsoft.ios.sdk.full` workload to a cache located in the *workload-cache* directory under the current directory. Then install it from the same cache location:

  ```dotnetcli
  dotnet workload install microsoft-ios-sdk-full --download-to-cache ./workload-cache
  dotnet workload install microsoft-ios-sdk-full --from-cache ./workload-cache
  ```
