---
title: dotnet workload update command
description: The 'dotnet workload update' command updates installed workloads.
ms.date: 07/08/2021
---
# dotnet workload update

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload update` - Updates installed workloads.

## Synopsis

```dotnetcli
dotnet workload update
    [--add-source <SOURCE>] [--configfile <FILE>] [--disable-parallel]
    [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>]
    [-v|--verbosity <LEVEL>]

dotnet workload update -?|-h|--help
```

## Description

The `dotnet workload update` command queries Nuget.org for updated workload manifests, updates local manifests, downloads new versions of the installed workloads, and then removes all old versions of a workload.

## Options

- **`--add-source <SOURCE>`**

  Adds an additional NuGet package source. Feeds are accessed in parallel, not sequentially in some order of precedence. If the same package and version is in multiple feeds, the fastest feed wins. For more information, see [What happens when a NuGet package is installed?](/nuget/concepts/package-installation-process).

- **`--configfile <FILE>`**

  The NuGet configuration file (*nuget.config*) to use. If specified, only the settings from this file will be used. If not specified, the hierarchy of configuration files from the current directory will be used. For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior).

- **`--disable-parallel`**

  Prevents restoring multiple projects in parallel.

- **`--from-cache <PATH_TO_CACHE>`**

  Completes the operation from cache (offline).

- **`--ignore-failed-sources`**

  Treat package source failures as warnings.

- **`--include-previews`**

  Allow prerelease workload manifests.

- **`--interactive`**

  Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`--no-cache`**

  Don't cache packages and HTTP requests.

- **`--sdk-version <VERSION>`**

   Specifies the version of the .NET SDK to use.

- **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`.

## Examples

- Update the installed workloads:

  ```dotnetcli
  dotnet workload update
  ```

- Download the `microsoft.ios.sdk.full` workload to a cache located in the *workload-cache* directory under the current directory. Then update installed workloads from that cache location:

  ```dotnetcli
  dotnet workload install microsoft-ios-sdk-full --download-to-cache ./workload-cache
  dotnet workload update --from-cache ./workload-cache
  ```
