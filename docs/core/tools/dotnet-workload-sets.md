---
title: .NET SDK workload sets
description: "Learn how to use workload sets to control which versions of workloads get installed, updated, or restored."
author: tdykstra
ms.author: tdykstra
ms.service: dotnet
ms.topic: how-to
ms.date: 08/02/2024

#customer intent: As a developer using optional workloads, I want to keep my workload versions in sync so that I can avoid conflicts betwween versions. I also want to avoid unexpected workload updates, so that I can avoid disruptions in development.
---
<!--https://aka.ms/patterns-feedback-->

# .NET SDK workload sets

The *workload sets* feature provides a version number that represents a group of .NET SDK workloads. The [install](dotnet-workload-install.md), [update](dotnet-workload-update.md), and [restore](dotnet-workload-restore.md) commands use this number in *workload set update mode* to provide the following benefits:

* You get control of the cadence of change for installed workload versions. The alternative mode of operation without using workload sets is called *loose manifests update mode*. In this mode, workloads are updated automatically as new versions of individual workloads are released onto any configured NuGet feeds. In workload set update mode, workloads stay at a specific workload set version until you explicitly change that version. So workloads stay at the same manifest version, which is specified by the workload set.
* You can install and update a combination of workload versions that ship at the same time and are known to work together. When you update, the workload manifests stay in sync.

<!--Workload sets are published to nuget.org with each release of the .NET SDK, under the package ID `Microsoft.NET.Workloads.<feature band>`-->

Here are some ways you can use workload sets:

* "Pin" the `install` command to a specific workload set version.
* Update installed workloads to the latest available workload set version.
* Install or update to a specified workload set version.

* Restore to a specific workload set version.

You can also:

* Check a repository's current workload set version.
* Update to the latest version of each individual workload, ignoring workload sets.

## Prerequisites

* [.NET 8.0.400 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later.

  In 8.0.400 SDK, the `dotnet workload` commands are in workload set update mode only when it's explicitly selected. Starting in [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0), `dotnet workload` commands are in workload set update mode by default.

## "Pin" the install command

A `dotnet workload install` command with the `--version` option "pins" the `install` command in workload set update mode with the specified workload set version. The command no longer automatically installs the newest workload based on loose manifests. For example:

1. ```dotnetcli
   dotnet workload install aspire --version 9.0.100-preview.7.24407.1
   ```

   When this command runs:

* It gets the workload set with the specified version.
* From the workload set, it gets the manifest version.
* It installs the manifest version of the workload.
* It leaves you in workload set update mode.

1. ```dotnetcli
   dotnet workload install maui-ios
   ```

   This example installs the workload set version 9.0.100-preview.7.24407.1, since the first install command example pinned that workload set.

The `update` command is pinned to workload set update mode but not to a workload set version. If you then run `dotnet workload update` without the `--version` option, the `update` command:

* Updates to the latest available workload set version.
* "Unpins" the `install` command.
* Stays in workload set update mode.

## Update using latest workload set

To update installed workloads to the latest workload set version available on the configured feeds, run the following commands:

1. ```dotnetcli
   dotnet workload config --update-mode workload-set
   ```

   The preceding command is necessary only if you are currently in manifests update mode. If that isn't known, [check the current update mode](check-the-currrent-update-mode). Workload set update mode is the default starting in .NET 9 SDK

1. ```dotnetcli
   dotnet workload update
   ```

## Install or update to a workload set

To specify a workload set version to install or update to, use the `--version` option of the `install` or `update` command. For example:

```dotnetcli
dotnet workload install --version  9.0.100-preview.7.24407.1
```

```dotnetcli
dotnet workload update --version 9.0.100-preview.7.24407.1
```

In both cases, workload set update mode will be selected if it wasn't already selected.

## Restore workload sets using global.json

Create a `global.json` file to specify the workload set version for the restore command for a repository. The format looks like this example:

```json
{
  "sdk": {
    "workloadVersion": " 9.0.100-preview.7.24407.1"
  }
}
```

With the current directory in the same repository, `dotnet workload restore` installs workloads for the specified workload set version. If you don't have a global.json file, and you're in workload set update mode: the `restore` command installs the workload set version that was established when you switched from manifests update mode to workload sets update mode.
<!--what about if it's SDK 9 so you defaulted to workload set update mode, and you never established a workload set version -- does it go for latest available then?-->

The `--version` option for specifying workload set version is also available for the `restore` comand.

## Ignore workload sets

To install, or update to, the latest version of each individual workload available on the configured feeds, select and use manifests update mode by running the workload `config` command:

```dotnetcli
dotnet workload config --update-mode manifests
```

In .NET 8.0.4xx SDK, manifests mode is the default. You need to select manifests mode explicitly only if you explicitly selected workload set update mode.

## Check the workload set version

To see the current workload set version, run `dotnet workload --version`.  If a workload set is installed, you see a version such as 9.0.100-preview.7.24407.1 or 8.0.401. For example:

```dotnetcli
dotnet workload --version
```

```output
9.0.100-preview.7.24407.1
```

If there is no workload set version, you see a version in the form of `<feature band>-manifests.<hash>`. For example:

```dotnetcli
dotnet workload --version
```

```output
9.0.100-manifests.cf958b56
```

## Related content

[dotnet workload command](dotnet-workload.md)
[dotnet workload install](dotnet-workload-install.md)
[dotnet workload update](dotnet-workload-update.md)
