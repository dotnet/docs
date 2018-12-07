---
title: Runtime roll forward for .NET Core self-contained app deployments.
description: Learn about dotnet publish changes for self-contained deployments.
author: jralexander
ms.author: kdollard
ms.date: 05/31/2018
ms.custom: seodec18
---
# Self-contained deployment runtime roll forward

.NET Core [self-contained application deployments](index.md) include both the .NET Core libraries and the .NET Core runtime. Starting in .NET Core 2.1 SDK (version 2.1.300), a self-contained application deployment [publishes the highest patch runtime on your machine](https://github.com/dotnet/designs/pull/36). By default, [`dotnet publish`](../tools/dotnet-publish.md) for a self-contained deployment selects the latest version installed as part of the SDK on the publishing machine. This enables your deployed application to run with security fixes (and other fixes) available during `publish`. The application must be re-published to obtain a new patch. Self-contained applications are created by specifying `-r <RID>` on the `dotnet publish` command or by specifying the [runtime identifier (RID)](../rid-catalog.md) in the project file (csproj / vbproj) or on the command line.

## Patch version roll forward overview

[`restore`](../tools/dotnet-restore.md), [`build`](../tools/dotnet-build.md) and [`publish`](../tools/dotnet-publish.md) are `dotnet` commands that can run separately. The runtime choice is part of the `restore` operation, not `publish` or `build`. If you call `publish`, the latest patch version will be chosen. If you call `publish` with the `--no-restore` argument, then you may not get the desired patch version because a prior `restore` may not have been executed with the new self-contained application publishing policy. In this case, a build error is generated with text similar to the following:

  "The project was restored using Microsoft.NETCore.App version 2.0.0, but with current settings, version 2.0.6 would be used instead. To resolve this issue, make sure the same settings are used for restore and for subsequent operations such as build or publish. Typically this issue can occur if the RuntimeIdentifier property is set during build or publish but not during restore."

> [!NOTE]
> `restore` and `build` can be run implicitly as part of another command, like `publish`. When run implicitly as part of another command, they are provided with additional context so that the right artifacts are produced. When you `publish` with a runtime (for example, `dotnet publish -r linux-x64`), the implicit `restore` restores packages for the linux-x64 runtime. If you call `restore` explicitly, it does not restore runtime packages by default, because it doesn't have that context.

## How to avoid restore during publish

Running `restore` as part of the `publish` operation may be undesirable for your scenario. To avoid `restore` during `publish` while creating self-contained applications, do the following:

* Set the `RuntimeIdentifiers` property to a semicolon-separated list of all the [RIDs](../rid-catalog.md) to be published.
* Set the `TargetLatestRuntimePatch` property to `true`.

## No-restore argument with dotnet publish options

If you want to create both self-contained applications and [framework-dependent applications](index.md) with the same project file, and you want to use the `--no-restore` argument with `dotnet publish`, then choose one of the following:

1. Prefer the framework-dependent behavior. If the application is framework-dependent, this is the default behavior. If the application is self-contained, and can use an unpatched 2.1.0 local runtime, set the `TargetLatestRuntimePatch` to `false` in the project file.

2. Prefer the self-contained behavior. If the application is self-contained, this is the default behavior. If the application is framework-dependent, and requires the latest patch installed, set `TargetLatestRuntimePatch` to `true` in the project file.

3. Take explicit control of the runtime framework version by setting `RuntimeFrameworkVersion` to the specific patch version in the project file.
