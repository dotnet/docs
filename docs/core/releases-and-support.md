---
title: .NET releases, patches, and support
description: Learn about releases, patches, and support for .NET 5+ (including .NET Core) and later versions.
ms.date: 7/15/2022
ms.topic: overview
ms.author: tdykstra
author: tdykstra
---
# Releases and support for .NET

This article describes release types, servicing updates, SDK feature bands, support periods, and support options for .NET.

## Release cadence

New major .NET versions are released annually in November, at [.NET Conf](https://www.dotnetconf.net/).

Patch updates are released monthly on the second Tuesday of each month, also known as Patch Tuesday.

Minor versions of the .NET SDK are released approximately quarterly. These are known as [feature bands](#feature-bands-sdk-only).

## Release types

Each .NET release is defined as either  **Short Term Support (STS)** or **Long Term Support (LTS)**, at the beginning of the release.

The release types:

* **STS** releases are  released in even-numbered years and are supported for eighteen months. They are intended for users that want to take advantage of the newest features and improvements and to stay on the leading edge of .NET innovation.
* **LTS** releases are released in odd-numbered years and are supported for three years. They are intended for users that want the stability and lower cost of maintaining an application for an extended period, only needing to upgrade their .NET version for security patches.

Note: **STS** releases were previously called **Current**.

LTS and STS releases differ only by support duration. The .NET team follows the same software engineering and release processes for both release types, including for security, compatibility, and reliability. Both release types may contain major new features and breaking changes. The .NET team aspires to enable straightforward migration from one release to another, independent of release type.

## Support phases

.NET releases go through multiple support phases, with varying support levels.

* **Preview** releases are not supported but are offered for public testing and for the opportunity to give feedback.
* **Go-live** support enables users to deploy a pre-release build in production and be supported by Microsoft. These are typically Release Candidate (RC) releases.
* **Active** support is provided for the majority of the period after a release is Generally Available (GA) and before support ends. Functional and security improvements are provided, including support for new operating system versions.
* **Maintenance** support is provided for the last six months of support. Improvements are limited to security fixes. Support for new operating system versions are provided on a best-effort basis.
* **End-of-life (EOL)** marks the point where a release is no longer supported.

.NET uses the [modern lifecycle](/lifecycle/policies/modern) for support and servicing. It is also used for .NET Framework.

[Support for various operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md) is defined for each release.

## Product behavior

Some .NET behaviors are affected by product version.

### Runtime roll-forward and compatibility

All .NET updates install side-by-side with previous versions. An application built to target a specific *major.minor* version continues to use that targeted runtime even if a newer version is installed. The app doesn't automatically roll forward to use a newer *major.minor* version of the runtime unless you opt in for this behavior. An application that was built to target .NET 6 won't automatically start running on .NET 7.

We recommend rebuilding apps and testing them with a newer major runtime version before deploying to production. For more information, see [Framework-dependent apps roll forward](versions/selection.md#framework-dependent-apps-roll-forward) and [Self-contained deployment runtime roll forward](deploying/runtime-patch-selection.md).

Servicing updates are treated differently from major releases. An application built to target .NET 6.0.0 will automatically roll-forward to use a newer patch -- like 6.0.1 -- when that servicing update is installed.

### Feature bands (SDK only)

Versioning for the .NET SDK works slightly differently from the .NET runtime. To align with new Visual Studio releases, .NET SDK updates sometimes include new features or new versions of components like MSBuild and NuGet.

To differentiate such updates, the .NET SDK uses the concept of feature bands. For example, the first .NET 6 SDK was `6.0.100`. The second one was `6.0.200`.Feature bands are defined in the hundreds groups in the third section of the version number. For example, 6.0.101 and 6.0.200 are versions in two different feature bands while 6.0.101 and 6.0.199 are in the same feature band.

.NET SDK installers are programmed to maintain one version per feature band. For example, when .NET SDK 6.0.101 is installed, .NET SDK 6.0.100 is removed from the machine if it exists. When .NET SDK 6.0.200 is installed on the same machine, .NET SDK 6.0.101 isn't removed.

## Get support

You can get support from Microsoft and the community.

### Microsoft support

For assisted support, [contact a Microsoft Support Professional](https://support.microsoft.com/supportforbusiness/productselection/?sapid=4fd4947b-15ea-ce01-080f-97f2ca3c76e8).

You need to be on a supported servicing level (the latest available servicing update) to be eligible for support. If a system is running .NET 5 and the 5.0.8 servicing update has been released, then 5.0.8 needs to be installed as a first step.

### Community support

For community support, open an issue in the [dotnet/core](https://github.com/dotnet/core) GitHub repo or on our [Community page](https://dotnet.microsoft.com/platform/community).
