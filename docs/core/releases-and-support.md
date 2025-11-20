---
title: .NET releases, patches, and support
description: Learn about releases, patches, and support for .NET.
ms.date: 11/18/2025
ms.custom: updateeachrelease
ms.topic: overview
ai-usage: ai-assisted
---
# Releases and support for .NET

Microsoft ships major releases, minor releases, and servicing updates (patches) for .NET. This article explains release types, servicing updates, SDK feature bands, support periods, and support options.

> [!NOTE]
> For information about versioning and support for .NET Framework, see [.NET Framework Lifecycle](/lifecycle/products/microsoft-net-framework).

## Currently supported versions

The following versions of .NET are currently supported:

- .NET 10 ([Long Term Support](#release-tracks)) - supported until November 2028.
- .NET 9 ([Standard Term Support](#release-tracks)) - supported until November 2026.
- .NET 8 ([Long Term Support](#release-tracks)) - supported until November 2026.

For the complete list of supported versions and their end-of-support dates, see the [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## Release types

The version number encodes information about each release type in the form *major.minor.patch*.

For example:

* .NET 8 and .NET 9 are major releases.
* .NET 9.0.1 is the first patch for .NET 9.

For a list of released versions of .NET and information about how often .NET ships, see the [Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core#lifecycle).

### Major releases

Major releases include new features, new public API surface area, and bug fixes. Examples include .NET 8 and .NET 9. Due to the nature of the changes, these releases are expected to have breaking changes. Major releases install side by side with previous major releases.

### Minor releases

Minor releases also include new features, public API surface area, and bug fixes, and might also have breaking changes. The difference between these and major releases is that the magnitude of the changes is smaller. Minor releases install side by side with previous minor releases.

### Servicing updates

Servicing updates (patches) ship almost every month, and these updates carry both security and non-security bug fixes. For example, .NET 9.0.1 is the first update for .NET 9. When these updates include security fixes, they're released on "patch Tuesday," which is always the second Tuesday of the month. Servicing updates maintain compatibility. Servicing updates remove the preceding update. For example, the latest servicing update for .NET 9 removes the previous .NET 9 update upon successful installation.

### Feature bands (SDK only)

The .NET SDK versioning works differently from the .NET runtime. To align with new Visual Studio releases, .NET SDK updates sometimes include new features or new versions of components like MSBuild and NuGet. These new features or components might be incompatible with the versions that shipped in previous SDK updates for the same major or minor version.

To differentiate such updates, the .NET SDK uses feature bands. For example, the first .NET 9 SDK was 9.0.100. This release corresponds to the 9.0.1xx *feature band*. Feature bands are defined in the hundreds groups in the third section of the version number. For example, 9.0.101 and 9.0.201 are versions in two different feature bands while 9.0.101 and 9.0.199 are in the same feature band. When .NET SDK 9.0.101 is installed, .NET SDK 9.0.100 is removed from the machine if it exists. When .NET SDK 9.0.200 is installed on the same machine, .NET SDK 9.0.101 isn't removed.

For more information about the relationship between .NET SDK and Visual Studio versions, see [.NET SDK, MSBuild, and Visual Studio versioning](porting/versioning-sdk-msbuild-vs.md).

### Runtime roll forward and compatibility

Major and minor updates install side by side with previous versions. An application built to target a specific *major.minor* version continues to use that targeted runtime even if you install a newer version. By default, an app targeting .NET 8 doesn't automatically roll forward to .NET 9 (a major version change), but it can roll forward to a newer minor version like .NET 8.1 if .NET 8.0 isn't available. For more information about controlling this behavior, see [Framework-dependent apps roll forward](versions/selection.md#framework-dependent-apps-roll-forward) and [Self-contained deployment runtime roll forward](deploying/runtime-patch-selection.md).

Patch version roll-forward happens automatically. An application built to target .NET 9 uses the latest installed patch version. For example, if you specify .NET 9.0 in your project and .NET 9.0.3 is installed, the app uses .NET 9.0.3. This automatic patch roll-forward is the default because you should use security fixes as soon as they're available. You can opt out of this default roll-forward behavior.

## .NET version lifecycles

.NET versions use the [modern lifecycle](/lifecycle/policies/modern) rather than the [fixed lifecycle](/lifecycle/policies/fixed) that .NET Framework releases use. Products that use a modern lifecycle have a service-like support model, with shorter support periods and more frequent releases.

### Release tracks

Two support tracks exist for releases:

* *Standard Term Support* (STS) releases

  These versions are supported for two years (24 months).

  Example:

  * .NET 9 is an STS release that was released in November 2024. It's supported for two years, until November 2026.

* *Long Term Support* (LTS) releases

  These versions are supported for a minimum of three years, or one year after the next LTS release ships if that date is later.

  Example:

  * .NET 8 is an LTS release that was released in November 2023. It's supported for three years, until November 2026.

Releases alternate between LTS and STS.

Servicing updates ship monthly and include both security and non-security (reliability, compatibility, and stability) fixes. Servicing updates are supported until the next servicing update is released. Servicing updates have runtime roll forward behavior. That means that applications default to running on the latest installed runtime servicing update.

## How to choose a release

If you're building a service and expect to continue updating it regularly, use the latest release, whether LTS or STS, to stay up to date with the latest features .NET offers.

If you're building a client application for distribution to consumers, stability might be more important than access to the latest features. Your application might need support for a certain period before the consumer can upgrade to the next version of the application. In that case, an LTS release like the .NET 8 runtime could be the right option.

> [!NOTE]
> Upgrade to the latest SDK version, even if it's an STS release, as it can target all available runtimes.

### Support for servicing updates

.NET servicing updates are supported until the next servicing update is released. The release cadence is monthly.

Regularly install servicing updates to ensure that your apps are in a secure and supported state. For example, if the latest servicing update for .NET 9 is 9.0.1 and Microsoft ships 9.0.2, then 9.0.1 is no longer the latest. The supported servicing level for .NET 9 is then 9.0.2.

For information about the latest servicing updates for each major and minor version, see the [.NET downloads page](https://dotnet.microsoft.com/download/dotnet).

## End of support

End of support refers to the date after which Microsoft no longer provides fixes, updates, or technical assistance for a product version. Before this date, move to a supported version. Versions that are out of support no longer receive security updates that protect your applications and data. For the supported date ranges for each version of .NET, see the [Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## Supported operating systems

You can run .NET on a range of operating systems. Each operating system has a lifecycle defined by its sponsor organization (for example, Microsoft, Red Hat, or Apple). .NET considers these lifecycle schedules when adding and removing support for operating system versions.

When an operating system version reaches end of support, Microsoft stops testing and providing support for that version. Move to a supported operating system version to get support.

For more information, see the [.NET OS Lifecycle Policy](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

## Get support

You have a choice between Microsoft-assisted support and Community support.

### Microsoft support

For assisted support, [contact a Microsoft Support Professional](https://support.microsoft.com/supportforbusiness/productselection/?sapid=4fd4947b-15ea-ce01-080f-97f2ca3c76e8).

Use a supported servicing level (the latest available servicing update) to be eligible for support. If a system runs .NET 8 and the 8.0.11 servicing update has been released, then install 8.0.11 as a first step.

### Community support

For community support, see the [Community page](https://dotnet.microsoft.com/platform/community).
