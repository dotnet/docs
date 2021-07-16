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
    [--configfile <FILE>] [--disable-parallel]
    [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>] [--skip-manifest-update]
    [--source <SOURCE>] [--temp-dir <PATH>] [-v|--verbosity <LEVEL>]

dotnet workload install -?|-h|--help
```

## Description

The `dotnet workload install` command installs an *optional workload*. Optional workloads can be installed on top of the .NET SDK to provide support for various application types, such as [.NET MAUI](/dotnet/maui/what-is-maui) and [Blazor WebAssembly AOT](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-4/#blazor-webassembly-ahead-of-time-aot-compilation).

Use [dotnet workload search](dotnet-workload-search.md) to learn what workloads are available to install.

The `dotnet workload install` command installs workload packs, which are packaged and hosted on Nuget.org. For macOS and Linux SDK installations that are installed to a protected directory, the command needs to run elevated. On Windows the command doesn't need to run elevated even if the SDK is installed to the *Program Files* directory. For Windows the command uses MSI installers for that location.

The `dotnet workload` commands operate in the context of specific SDK versions. Suppose you have both .NET 6.0.100 SDK and .NET 7.0.100 SDK installed. The `dotnet workload` commands will give different results depending on which SDK version you select. This behavior applies to major and minor version and feature band differences, not to patch version differences. For example, .NET SDK 6.0.101 and 6.0.102 give the same results, whereas 6.0.100 and 6.0.200 give different results.

 The commands provide the `--sdk-version` option to let you select an SDK version other than the one selected by default or by *global.json*.

## Arguments

- **`WORKLOAD_ID`**

  The workload ID of the workload to install. Use [dotnet workload search](dotnet-workload-search.md) to learn what workloads are available to install.

## Options

<!-- markdownlint-disable MD012 -->

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

  Skip updating the workload manifests. The workload manifests define what assets and versions need to be installed for each workload.

[!INCLUDE [source](../../../includes/cli-source.md)]

- **`--temp-dir <PATH>`**

  Configure the temporary directory used for this command (must be secure).

[!INCLUDE [verbosity](../../../includes/cli-verbosity-packages.md)]

## Examples

- Install the `maui` workload:

  ```dotnetcli
  dotnet workload install maui
  ```

- Download assets needed for the `maui` workload to a cache located in the *workload-cache* directory under the current directory. Then install it from the same cache location:

  ```dotnetcli
  dotnet workload install maui --download-to-cache ./workload-cache
  dotnet workload install maui --from-cache ./workload-cache
  ```
