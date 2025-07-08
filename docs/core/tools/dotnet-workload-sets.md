---
title: .NET SDK workload sets
description: "Learn how to use workload sets to control which versions of workloads get installed, updated, or restored."
author: tdykstra
ms.author: tdykstra
ms.service: dotnet
ms.topic: how-to
ms.date: 08/02/2024

#customer intent: As a developer using optional workloads, I want to keep my workload versions in sync so that I can avoid conflicts between versions. I also want to avoid unexpected workload updates, so that I can avoid disruptions in development.
---
# .NET SDK workload sets

The *workload sets* feature provides a version number that represents a group of .NET SDK workloads. The [install](dotnet-workload-install.md), [update](dotnet-workload-update.md), and [restore](dotnet-workload-restore.md) commands use this number in *workload-set update mode* to provide the following benefits:

* You control the cadence of change for installed workload versions. The alternative mode of operation without using workload sets is called *loose manifests update mode*. In this mode, workloads are updated automatically as new versions of individual workloads are released onto any configured NuGet feeds. In `workload-set` update mode, workloads stay at a specific workload-set version until you explicitly change that version.
* You can install and update a combination of workload versions that ship at the same time and are known to work together.
* You can ensure that everyone on your team is always working on the same workload versions.
* You don't have to use a rollback file to specify what workload version you want to be on.

Here are some ways you can use workload sets:

* "Pin" the `install` command to a specific workload-set version.
* Update installed workloads to the latest available workload-set version.
* Update to a specified workload-set version.
* Specify the workload-set version in global.json.
* Check your current update mode and workload-set version.

And you can still choose to install, update, or restore to the latest version of each individual workload, ignoring workload sets.

## Prerequisites

* [.NET 8.0.400 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later.

  In 8.0.400 SDK, the `dotnet workload` commands are in workload-set update mode only when it's explicitly selected. <!--Starting in [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0), `dotnet workload` commands are in workload-set update mode by default.-->

## "Pin" the install command

A `dotnet workload install` command with the `--version` option "pins" the `install` command in `workload-set` update mode with the specified workload-set version.
The command no longer automatically installs the newest workload based on loose manifests.

To "pin" the `install` command:

1. [Choose a workload-set version](#choose-a-workload-set-version). For example, `9.0.100-preview.7.24414.1`.

1. [Choose a workload](dotnet-workload-search.md). For example, `aspire`.

1. ```dotnetcli
   dotnet workload install aspire --version 9.0.100-preview.7.24414.1
   ```

   When this command runs:

   * It selects `workload-set` update mode if that isn't already selected.
   * It gets the workload set that has the specified version.
   * From the workload set, it gets the manifest version of the specified workload.
   * It installs the manifest version of the workload.
   * It stays in `workload-set` update mode when it's done.

1. Choose another workload to install, such as `maui-ios`.

1. ```dotnetcli
   dotnet workload install maui-ios
   ```

   This command installs the `maui-ios` workload using the workload version from the workload-set version `9.0.100-preview.7.24414.1`, since the preceding `install` command example pinned that workload set.

Using `--version` with either `install` or `update` pins `install` to the specified version, but `update` is only configured for `workload-set` update mode, not to a specific workload-set version. If you then run `dotnet workload update` without the `--version` option, the `update` command:

* Updates workloads to the latest available workload-set version.
* "Unpins" the `install` command.
* Stays in `workload-set` update mode.

## Update using latest workload set

To update installed workloads to the latest workload-set version available on the configured feeds, run the following commands:

1. ```dotnetcli
   dotnet workload config --update-mode workload-set
   ```

   The preceding command is necessary only if you are currently in manifests update mode. If you don't know, [check the current update mode](#check-the-update-mode-and-version).

1. ```dotnetcli
   dotnet workload update
   ```

   In `workload-set` update mode, this command updates workloads to the latest workload-set version, unless you have specified the workload-set version in global.json.

## Update to a workload-set version

To specify a workload-set version to update to when you're not specifying it in global.json, use the `--version` option of the `update` command:

1. [Choose a workload-set version](#choose-a-workload-set-version). For example, `8.0.400`.

1. ```dotnetcli
   dotnet workload update --version 8.0.400
   ```

   `workload-set` update mode will be selected if it wasn't already selected.

## Use global.json for the workload-set version

To use a `global.json` file to specify the workload-set version for a repository:

1. [Choose a workload-set version](#choose-a-workload-set-version). For example, `9.0.100-preview.7.24414.1`.

1. Create a `global.json` file that looks like the following example:

   ```json
   {
     "sdk": {
       "workloadVersion": "9.0.100-preview.7.24414.1"
     }
   }
   ```

With the current directory in the same repository and the CLI in `workload-set` update mode, the `install`, `update`, and `restore` commands install workloads for the specified workload-set version. If you don't have a global.json file and you're in `workload-set` update mode, the `restore` command installs the workload-set version that was established when you switched from manifests update mode to `workload-set` update mode.
<!--If you're using SDK 9, you defaulted to `workload-set` update mode, and you might not have established a workload-set version. In that case, `restore` installs the latest workload set available on the configured feeds.-->

If you have a workload-set version in the global.json file, the workload commands are in `workload-set` mode even if you haven't run the `config` command or used `--version`. The global.json file overrides those.
To use the `--version` option in that case, run the command outside of the path containing the global.json file.

If you don't specify the workload-set version in global.json, you can use the `--version` option with the `restore` command. In that case, the `restore` command selects `workload-set` update mode before it restores workloads to the specified workload-set version.

In manifests update mode, `restore` installs or updates workloads to the latest version of each individual workload.

## Check the update mode and version

To see the current update mode, run the `config` command with the `--update-mode` option without an argument. The mode is either `workload-set` or `manifests`. For example:

```dotnetcli
dotnet workload config --update-mode
```

```output
workload-set
```

To see the current workload-set version, run `dotnet workload --version`.  If a workload set is installed, you see a version such as 9.0.100-preview.7.24414.1 or 8.0.402. For example:

```dotnetcli
dotnet workload --version
```

```output
9.0.100-preview.7.24414.1
```

In manifests mode, or if the workload-set version isn't established yet after switching to `workload-set` update mode, you see a version in the form of `<feature band>-manifests.<hash>`. For example:

```dotnetcli
dotnet workload --version
```

```output
9.0.100-manifests.cf958b56
```

## Choose a workload-set version

Workload sets are published to nuget.org with each release of the .NET SDK, under the package ID `Microsoft.NET.Workloads.<feature band>`. For a stable version of the SDK, there is always a matching workload-set version. So 8.0.400 SDK can install an 8.0.400 workload set, and 401 can install a 401 set. In general, we recommend that you install the matching workload set for a stable SDK.

For preview releases, find the corresponding workload-set version in the package's README tab. For example, see [the README tab for the .NET 9 Preview 7 package](https://www.nuget.org/packages/Microsoft.NET.Workloads.9.0.100-preview.7/9.100.0-preview.7.24414.1#readme-body-tab).

In the future, you'll be able to see a list of workload-set versions and what they contain.

## Ignore workload sets

To install, or update to, the latest version of each individual workload available on the configured feeds, select and use manifests update mode by running the workload `config` command:

```dotnetcli
dotnet workload config --update-mode manifests
```

In .NET 8.0.4xx SDK, manifests mode is the default. In this version, you need to select manifests mode explicitly only if you explicitly selected `workload-set` update mode previously.

## Related content

* [dotnet workload command](dotnet-workload.md)
* [dotnet workload install](dotnet-workload-install.md)
* [dotnet workload update](dotnet-workload-update.md)
