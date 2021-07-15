---
title: dotnet workload install command
description: The 'dotnet workload install' command installs optional workloads.
ms.date: 07/08/2021
---
# dotnet workload install

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload install` - Installs optional workloads.

## Synopsis

```dotnetcli
dotnet workload install <WORKLOAD_ID>
    [--add-source <SOURCE>] [--configfile <FILE>] [--disable-parallel]
    [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>] [--skip-manifest-update]
    [--temp-dir <PATH>] [-v|--verbosity <LEVEL>]

dotnet workload install -?|-h|--help
```

## Description

The `dotnet workload install` command installs an *optional workload*. Optional workloads cn be installed on top of the .NET SDK to provide support for various application types, such as [.NET MAUI](/dotnet/maui/what-is-maui) and [Blazor WebAssembly AOT](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-4/#blazor-webassembly-ahead-of-time-aot-compilation).

Use [dotnet workload search](dotnet-workload-search.md) to learn what workloads are available to install.

The `dotnet workload install` command copies the workloads from NuGet.org into your SDK install folder, so it needs to run elevated if that folder requires administrator write permissions.

The `dotnet workload` commands operate in the context of specific SDK versions. Suppose you have both .NET 6 SDK and .NET 7 SDK  installed. The `dotnet workload` commands will provide different results depending on which SDK version you select. The commands provide the `--sdk-version` option to let you select an SDK other than the default.

## Arguments

- **`WORKLOAD_ID`**

  The workload ID of the workload to install.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [add-source](../../../includes/cli-add-source.md)]

[!INCLUDE [config-file](../../../includes/cli-configfile.md)]

- **`--disable-parallel`**

  Prevents restoring multiple projects in parallel.

- **`--download-to-cache <PATH_TO_CACHE>`**

  Downloads packages needed for a workload to a folder that can be used for offline installation.

- **`--from-cache <PATH_TO_CACHE>`**

  Complete the operation from cache (offline).

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--ignore-failed-sources`**

  Treats package source failures as warnings.

- **`--include-previews`**

  Allows prerelease workload manifests.

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

- **`--no-cache`**

  Prevents caching of packages and http requests.

[!INCLUDE [sdk-version](../../../includes/cli-sdk-version.md)]

- **`--skip-manifest-update`**

  Skip updating the workload manifests.

- **`--temp-dir <PATH>`**

  Configure the temporary directory used for this command (must be secure).

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

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
