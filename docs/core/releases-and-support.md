---
title: .NET releases, patches, and support
description: Learn about releases, patches, and support for .NET 5 (including .NET Core) and later versions.
ms.date: 10/07/2020
ms.topic: overview
ms.author: tdykstra
author: tdykstra
---
# Releases and support for .NET Core and .NET 5

Microsoft ships major releases, minor releases, and servicing updates (patches) for .NET Core, .NET 5, and later versions. This article explains release types, servicing updates, SDK feature bands, support periods, and support options.

## Release types

.NET Core, .NET 5, and later versions ship as major releases, minor releases, and servicing updates (patches). Information about the release is encoded in the version number in the form of major.minor.patch.

For example,

* .NET Core 3.0 is a major release of the product.
* .NET Core 3.1 is the first minor release after the .NET Core 3.0 major release.
* .NET Core 3.1.7 is the seventh patch for .NET Core 3.1.

### Major releases

Major releases include new features, new public API surface area, and bug fixes. Examples include .NET Core 3.0 and .NET 5.0.  Due to the nature of the changes, these releases are expected to have breaking changes. Major releases install side by side with previous major releases.

### Minor releases

Minor releases also include new features, public API surface area, and bug fixes, and may also have breaking changes. Examples include .NET Core 2.1 and .NET Core 3.1. The difference between these and major releases is that the magnitude of the changes is generally smaller. An application upgrading from .NET Core 3.0 to 3.1 has a smaller jump to move forward. Minor releases install side by side with previous minor releases.

### Servicing updates

Servicing updates ship almost every month, and these updates carry both security and non-security bug fixes. For example, .NET Core 3.1.8 is the eighth update for .NET Core 3.1. When these updates include security fixes, they're released on "patch Tuesday", which is always the second Tuesday of the month. Servicing updates are expected to maintain compatibility and we take steps to ensure this. Starting with .NET Core 3.1, servicing updates are upgrades, that is, the latest servicing update for 3.1 removes the previous 3.1 update upon successful installation.

### Feature bands (SDK only)

Versioning for the .NET SDK works slightly differently from the .NET runtime. .NET SDK updates sometimes include new features or new versions of components like MSBuild and NuGet to align with new Visual Studio releases. These new features or components may be incompatible with the versions shipping in previous SDK updates for the same major or minor version.

To differentiate across such SDK updates, the .NET SDK uses the concept of feature bands. For example, the first .NET Core 3.1 SDK was 3.1.100. This release corresponds to the 3.1.1xx  *feature band*. Feature bands are defined in the hundreds groups in the third section of the version number. For example, 3.1.101 and 3.1.201 are versions in two different feature bands while 3.1.101 and 3.1.199 are in the same feature band. When .NET Core SDK 3.1.101 is installed, .NET Core SDK 3.1.100 is removed from the machine if it exists. When .NET Core SDK 3.1.200 is installed on the same machine, .NET Core SDK 3.1.101 won't be removed.

### Runtime roll-forward and compatibility

Major and minor updates install side by side with previous versions. An application built to target a specific major/minor version continues to use that targeted runtime even if a newer version is installed. The app does not automatically roll forward to use a newer major/minor version of the runtime unless you opt-in for this behavior. An application that was built to target .NET Core 3.0 will not automatically start running on .NET Core 3.1. In general, we recommend rebuilding the app and testing against a newer major or minor runtime version before deploying this to production. For more information, see [Framework-dependent apps roll forward](versions/selection.md#framework-dependent-apps-roll-forward) and [Self-contained deployment runtime roll forward](deploying/runtime-patch-selection.md).

Servicing updates are treated differently from major and minor releases. An application built to target .NET Core 3.1 targets the 3.1.0 runtime by default and automatically rolls forward to use a newer 3.1.1 runtime when that servicing update is installed. This is the default behavior because we want security fixes to be used as soon as they're installed without any other action needed. You can opt-out from this default roll forward behavior.

## .NET Core and .NET 5 version lifecycles

.NET Core, .NET 5, and later versions adopt the [modern lifecycle](/lifecycle/policies/modern) rather than the [fixed lifecycle](/lifecycle/policies/fixed) that has been used for .NET Framework releases. Products with fixed lifecycles provide a long fixed period of support, for example, 5 years of mainstream support and another 5 years of extended support. Mainstream support includes security and non-security fixes, while extended support provides security fixes only. Products that adopt a modern lifecycle have a more service-like support model, with shorter support periods and more frequent releases.

### Release tracks

There are 2 support tracks for releases:

* *Current* releases

  These versions are supported for a period of 3 months after the next major or minor release ships.

  Example:

  * .NET Core 3.0 shipped in September, 2019 and was followed by .NET Core 3.1 in December 2019.
  * .NET Core 3.0 support ended in March 2020, 3 months after 3.1 shipped.

* *Long Term Support* (LTS) releases

  These versions are supported for a minimum of 3 years, or 1 year after the next LTS release ships (whichever is longer).

  Example:

  * .NET Core 2.1 was released in May 2018 and was deemed an LTS release in August, 2018.
  * .NET Core 3.1 was the next LTS release and was released in December, 2019.
  * Since August, 2021 is later than December, 2020, .NET Core 2.1 will be supported through August 2021.

Releases alternate between LTS and Current, so it's possible for an earlier release to be supported longer than a later release. For example, .NET Core 2.1 is an LTS release with support through August 2021. .NET Core 3.0, which shipped more than a year later, went out of support in December 2019.

Servicing updates ship monthly and include both security and non-security (reliability, compatibility, and stability) fixes. Servicing updates are supported from the time they are released until the next servicing update is released. Servicing updates leverage runtime roll forward behavior. That means that applications default to running on the latest installed runtime servicing update.

### How to choose a release

If you're building a service and expect to continue updating it on a regular basis, then a Current release like .NET 5.0 may be your best option to stay up to date with the latest features .NET has to offer.

On the other hand, if you're building a client application that will be distributed to consumers, stability may be more important than access to the latest features. Your application might need to be supported for a certain period before the consumer can upgrade to the next version of the application. In that case, an LTS release like .NET Core 3.1 might be the right option.

### Servicing releases

.NET servicing releases are supported from the time they are released until the next servicing update is released. The release cadence is monthly.

You need to regularly install servicing releases to ensure that your apps are in a secure and supported state. For example, if the latest servicing release for .NET Core 3.1 is 3.1.8 and we ship 3.1.9, then 3.1.8 is no longer the latest and the supported servicing level for 3.1 is 3.1.9.

More information about the latest shipped servicing updates for all supported versions of .NET Core can be found on the [.NET downloads page](https://dotnet.microsoft.com/download/dotnet-core).

### End of support

End of support refers to the date after which Microsoft no longer provides fixes, updates, or technical assistance for a particular product version. As this date nears, make sure you have moved to using a supported version and have the latest servicing update installed. If you continue to use a version that is out of support, you'll no longer receive security updates that will be required to protect your applications and data.

### Supported operating systems

.NET Core and .NET 5 can be run on a range of operating systems. Each of these operating systems has a lifecycle defined by its sponsor organization (for example, Microsoft, Red Hat, or Apple). The .NET team applies each of those lifecycle schedules to inform adding and removing support for operating system versions.

When an operating system version goes out of support, we stop testing that version and providing support for that version. Users need to move forward to a supported operating system version to get support.

For more information, see the [.NET Core OS Lifecycle Policy](https://github.com/dotnet/core/blob/master/os-lifecycle-policy.md).

## Getting Support

You have a choice between Microsoft assisted support and Community support.

### Microsoft Support

For assisted support with .NET Core and .NET 5, [contact a Microsoft Support Professional](https://support.microsoft.com/supportforbusiness/productselection/?sapid=4fd4947b-15ea-ce01-080f-97f2ca3c76e8).

You need to be on a supported servicing level (the latest available servicing update) to be eligible for support. If a system is running 3.1 and the 3.1.8 servicing update has been released, then 3.1.8 needs to be installed as a first step.

### Community Support

Community support is another great way to get help and even contribute to projects. For more information, see the [Community page](https://dotnet.microsoft.com/platform/community).

## See also

For for more information, including supported date ranges for each version of .NET Core and for .NET 5, see the [Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).
