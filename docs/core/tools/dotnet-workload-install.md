---
title: dotnet workload install command
description: The 'dotnet workload install' command installs optional workloads.
ms.date: 09/10/2021
---
# dotnet workload install

**This article applies to:** ✔️ .NET 6 Preview SDK and later versions

## Name

`dotnet workload install` - Installs optional workloads.

## Synopsis

```dotnetcli
dotnet workload install <WORKLOAD_ID>...
    [--configfile <FILE>] [--disable-parallel]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--skip-manifest-update]
    [--source <SOURCE>] [--temp-dir <PATH>] [-v|--verbosity <LEVEL>]

dotnet workload install -?|-h|--help
```

## Description

The `dotnet workload install` command installs one or more *optional workloads*. Optional workloads can be installed on top of the .NET SDK to provide support for various application types, such as [.NET MAUI](/dotnet/maui/what-is-maui) and [Blazor WebAssembly AOT](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-4/#blazor-webassembly-ahead-of-time-aot-compilation).

Use [dotnet workload search](dotnet-workload-search.md) to learn what workloads are available to install.

### When to run elevated

For macOS and Linux SDK installations that are installed to a protected directory, the command needs to run elevated (use the `sudo` command). On Windows, the command doesn't need to run elevated even if the SDK is installed to the *Program Files* directory. For Windows, the command uses MSI installers for that location.

### Results vary by SDK version

The `dotnet workload` commands operate in the context of specific SDK versions. Suppose you have both .NET 6.0.100 SDK and .NET 6.0.200 SDK installed. The `dotnet workload` commands will give different results depending on which SDK version you select. This behavior applies to major and minor version and feature band differences, not to patch version differences. For example, .NET SDK 6.0.101 and 6.0.102 give the same results, whereas 6.0.100 and 6.0.200 give different results. You can specify the SDK version by using the [*global.json* file](global-json.md) or the `--sdk-version` option of the `dotnet workload` commands.

### Advertising manifests

The names and versions of the assets that a workload installation requires are maintained in *manifests*. By default, the `dotnet workload install` command downloads the latest available manifests before it installs a workload. The local copy of a manifest then provides the information needed to find and download the assets for a workload.

The `dotnet workload list` command compares the versions of installed workloads with the currently available versions.  When it finds that a version newer than the installed version is available, it advertises that fact in the command output. These newer-version notifications in `dotnet workload list` are available starting in .NET 6 Preview 7.

To enable these notifications, the latest available versions of the manifests are downloaded and stored as *advertising manifests*.  These downloads happen asynchronously in the background when any of the following commands are run.

* [dotnet build](dotnet-build.md)
* [dotnet pack](dotnet-pack.md)
* [dotnet publish](dotnet-publish.md)
* [dotnet restore](dotnet-restore.md)
* [dotnet run](dotnet-run.md)
* [dotnet test](dotnet-test.md)

If a command finishes before the manifest download finishes, the download is stopped. The download is tried again the next time one of these commands is run. You can set environment variables to [disable these background downloads](dotnet-environment-variables.md#dotnet_cli_workload_update_notify_disable) or [control their frequency](dotnet-environment-variables.md#dotnet_cli_workload_update_notify_interval_hours). By default, they don't happen more than once a day.

You can prevent the `dotnet workload install` command from doing manifest downloads by using the `--skip-manifest-update` option.

The `dotnet workload update` command also downloads advertising manifests. The downloads are required to learn if an update is available, so there is no option to prevent them from running. However, you can use the `--advertising-manifests-only` option to skip workload updates and only do the manifest downloads. This option is available starting in .NET 6 Preview 7.

## Arguments

- **`WORKLOAD_ID`...**

  The workload ID or multiple IDs to install. Use [dotnet workload search](dotnet-workload-search.md) to learn what workloads are available.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [config-file](../../../includes/cli-configfile.md)]

[!INCLUDE [disable-parallel](../../../includes/cli-disable-parallel.md)]

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [ignore-failed-sources](../../../includes/cli-ignore-failed-sources.md)]

[!INCLUDE [include-previews](../../../includes/cli-include-previews.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive.md)]

[!INCLUDE [no-cache](../../../includes/cli-no-cache.md)]

[!INCLUDE [skip-manifest-update](../../../includes/cli-skip-manifest-update.md)]

[!INCLUDE [source](../../../includes/cli-source.md)]

[!INCLUDE [temp-dir](../../../includes/cli-temp-dir.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-packages.md)]

## Examples

- Install the `maui` workload:

  ```dotnetcli
  dotnet workload install maui
  ```
  
- Install the `maui-android` and `maui-ios` workloads:
  
  ```dotnetcli
  dotnet workload install maui-android maui-ios
  ```

- Download assets needed for the `maui` workload to a cache located in the *workload-cache* directory under the current directory. Then install it from the same cache location:

  ```dotnetcli
  dotnet workload install maui --download-to-cache ./workload-cache
  dotnet workload install maui --from-cache ./workload-cache
  ```
