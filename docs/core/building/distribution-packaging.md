---
title: .NET Core distribution packaging
description: .NET Core distribution packaging
keywords: .NET, .NET Core, source, build
author: beleroy
ms.author: mairaw
ms.date: 03/29/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
---

.NET Core distribution packaging
================================

As .NET Core becomes available on more and more platforms, thanks to the efforts of dedicated contributors, it is useful to provide guidelines on how to package, name, and version it, in order to ensure a consistency of experience no matter where you choose to run .NET.
This document provides such guidelines.

What .NET Core is made of
-------------------------

.NET Core is made of three major parts that need to be packaged:

1. **The host** (also known as the "muxer") has two distinct roles: activate a runtime to launch an application, and activate an SDK to dispatch commands to it. The host is a native executable (`dotnet.exe`) and its supporting policy libraries (installed in `host/fxr`). It's built from the code in the [`dotnet/core-setup`](https://github.com/dotnet/core-setup/) repository. There is typically only one host on a given machine, although that is not a strict requirement.
2. **The framework** is made of a runtime and supporting managed libraries. A framework may be installed as part of an application, or as a shared framework in a central location that can be re-used by multiple applications. There may be any number of shared frameworks installed on a given machine. Shared frameworks live under `shared/Microsoft.NETCore.App/<version>`. The host will roll forward across patch versions, so if an application targets `Microsoft.NETCore.App` 1.0.0, and only 1.0.4 is present, it will be launched against 1.0.4.
3. **The SDK** (also sometimes referred to as "the tooling") is a set of managed tools that can be used to write and build .NET Core libraries and applications. This includes MS Build and associated build tasks and targets, NuGet, new project templates, etc. It is possible to have multiple SDKs on a machine (in order, for example, to allow for building projects that explicitly require an older version), but the recommendation is to use the latest available tools whenever possible.

Recommended package names
-------------------------

These are recommendations, and a specific package maintainer may choose to diverge from it, for example based on different tradition of the specific distro they're targeting.

### Minimum package set

* `dotnet-[major].[minor]`: a shared framework with the specified version (only the latest patch version for a given major+minor combination should be available in the package manager). **dependencies**: `dotnet-host`
* `dotnet-sdk`: the latest SDK. **dependencies**: the latest `dotnet-sdk-[major].[minor]`.
* `dotnet-sdk-[major].[minor]`: the SDK with the specified version. The version specified is the highest included version of included shared frameworks, so that users can easily relate an SDK to a shared framework. **dependencies**: `dotnet-host`, one or more `dotnet-[major].[minor]` (one of those is used by the SDK code itself, the others are here for users to build and run against).
* `dotnet-host`: the latest host.

#### Preview versions

Package maintainers may decide to include preview versions of the shared framework and SDK. Those should never be included in the unversioned package (`dotnet` and `dotnet-sdk`), but may be released as versioned packages with an additional preview marker appended to the major and minor version sections of the name. For example, there may be a `dotnet-sdk-2.0-preview-final` package.

### Optional additional packages

Some maintainers may choose to provide additional packages such as:

* `dotnet-lts`: the latest "Long-Term Support" version of the shared framework. [LTS and Current release trains](https://docs.microsoft.com/en-us/dotnet/articles/core/versions/lts-current) correspond to different cadences at which .NET Core gets released. Users have a choice of adopting one or the other train, based on how often they are willing to update. This is a concept that is also tied to support levels, so it may or may not make sense depending on the distro being considered.

Disk layout
-----------

When installing .NET Core packages, the relative placement of their target destinations on disk matter.
The `dotnet.exe` host should be placed next to `sdk` and `shared` folders that contain the versioned contents of the `dotnet-sdk` SDK package, and `dotnet` shared framework package.

The disk layout of files and directories inside the packages is versioned. This means that updating to the latest `dotnet` will effectively install the new version side-by-side with the ones that were previously there, reducing the possibility of breaking existing applications by updating the package. Package updates should not remove previous versions.

Update policies
---------------

When an `update` is performed, the behavior of each package is as follows:

* `dotnet-[major].[minor]`: new patch versions update the package, but new minor or major versions are separate packages.
* `dotnet-sdk`: `update` rolls forward major, minor, and patch versions.
* `dotnet-sdk-[major].[minor]`: new patch versions update the package, but new minor or major versions are separate packages.
* `dotnet-lts`: `update` rolls forward major, minor, and patch versions.
