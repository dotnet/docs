---
title: .NET SDK workload sets
description: "Learn how to use workload sets to control which versions of workloads get installed, updated, and restored."
author: tdykstra
ms.author: tdykstra
ms.service: dotnet
ms.topic: how-to
ms.date: 08/02/2024

#customer intent: As a developer using multiple workloads in a project, I want to keep my workload versions in sync so that I can avoid problems that might arise from conflicts betwween versions. Even if I only have one workload, I want to avoid having a workload be updated to a different version when I'm not expecting it.
---
# .NET SDK workload sets

A workload set provides a single version number that represents a group of .NET SDK workloads. This enables you to install and update a combination of workload versions that ship at the same time and are known to work together. Workload sets are published to nuget.org with each release of the .NET SDK, under the package ID `Microsoft.NET.Workloads.<feature band>`

Here are some ways you can use workload sets:

* Update to the latest available workload set version.
* Update to a specific workload set version.
* "Pin" the install command to a specific workload set version.
* Restore to a specific workload set version.

You can also:

* Check a project's current workload set version.
* Update to the latest version of each individual workload, ignoring workload sets.

## Prerequisites

* [.NET 8.0.400 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later.

  In 8.0.400 SDK, the `dotnet workload` commands are in workload set update mode when it's explicitly selected. In [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0), `dotnet workload` commands are in workload set update mode by default.

## Update to the latest available workload set version

To update installed workloads to the latest workload set version available on the configured feeds, run these commands:

```dotnetcli
dotnet workload config --update-mode workload-set
dotnet workload update
```

In .NET 9 SDK, workload set update mode is the default, so it isn't necessary to explicitly select it with the `dotnet workload config` command shown here.

## Update to a specific workload set version

Use the `--version` option of the `dotnet workload update` command to specify a workload set version to update to. For example:

```dotnetcli
dotnet workload update --version 8.400.0-preview.0.24219.1.
```

## "Pin" the install command

A `dotnet workload install` command with the `--version` option "pins" the `dotnet workload install` command so that it no longer automatically installs a newer workload set. However, `dotnet workload update` doesn't get pinned. If you run a `dotnet workload update` command without the `--version` option, the command:

* Installs the latest available workload set version.
* "Unpins" the `install` command.
* Stays in workload set update mode.

## Specify the workload set version using global.json

Create a `global.json` file to specify the workload set version for a repository. The format looks like this example:

```json
{
  "sdk": {
    "workloadVersion": "8.400.0-preview.0.24219.1"
  }
}
```

With the current directory in the same repository, `dotnet workload restore` installs workloads for the specified workload set version. If you don't have a global.json file, and you're in workload set update mode, the `restore` command will install the workload set version that was established when you switched from manifests update mode to workload sets update mode.

## Ignore workload set versions

To update to the latest version of each individual workload available on the configured feeds, select and use manifests update mode by running these commands:

```dotnetcli
dotnet workload config --update-mode manifests
dotnet workload update
```

In .NET 8.0.4xx SDK, manifests mode is the default. You need to select manifests mode explicitly only if you explicitly selected workload set update mode.

## Check the workload set version

To see the current workload set version, run `dotnet workload --version`.  If a workload set is installed, you see a version such as `8.0.400-preview.0.24217.2` or `8.0.401`.  If there is no workload set version, you see a version in the form of `<feature band>-manifests.<hash>`, such as `8.0.400-manifests.45f976f0`.

## Related content

[dotnet workload command](dotnet-workload.md)
[dotnet workload install](dotnet-workload-install.md)
[dotnet workload update](dotnet-workload-update.md)
