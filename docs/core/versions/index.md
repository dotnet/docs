---
title: .NET Core Versioning | Microsoft Docs
description: .NET Core Versioning
keywords: .NET, .NET Core
author: richlander
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: f6f684b1-1d2c-4105-8376-7c1959e23803
---

# .NET Core Versioning

.NET Core is made of [NuGet packages](../packages.md), tools, and frameworks that are distributed as a unit. Each of these platform layers can be versioned separately, enabling better agility. While there is significant versioning flexibility in that regard, we also have a desire to version the platform as a unit to make the product easier to understand.

This article aims at clarifying how the .NET Core SDK and runtime are versioned.

TL;DR: There are lots of moving parts that version independently in .NET Core, but going forward we'll make sure that there is an easy to understand top-level version number that everybody understands to be *the* version of ".NET Core" as a whole. The rest of this document goes into the minute details of the versioning of all those parts, but you shouldn't need to know all those in order to use .NET Core, or build libraries that target it.

## The past

While our intent has always been clarity, in the past we've been erring too far on the side of accuracy about the contents of our downloads when naming them. The file name contained both the version of the runtime and of the tooling, but without clarity about which was which. This greatly confused some of our users.

## The future

Starting with the 2.0 release, we'll make sure that our downloads show a single version number in their file name.

We're unifying several version numbers:

* The shared framework and associated runtime
* The SDK and CLI
* The `Microsoft.NETCore.App` metapackage

This makes it easier for users to know what version of the SDK to install on their dev machines, and what the corresponding version of the shared framework should be when time comes to provision a production environment. When downloading a SDK or runtime, the version number you'll see is going to be the same, the one you care about. The tooling you'll get with that will be guaranteed to work with the runtime, but its version will no longer be part of the download name.

### NET Core 2 Releases

There will be a number of preview releases during the 2.0 cycle culminating in the final late-summer release. All aspects of naming, versioning and branding will be consistent and understandable.

| Date  | Release                     | Base Branding and Versioning |
| :--   | :--                         | :--                          |
| April | Private VS 15.3 Preview     | 2.0.0-Preview 1-[build]      |
| May   | Microsoft Build 2017        | 2.0.0-Preview 1-final        |
| June  | Public Preview (RC)         | 2.0.0-Preview 2-final        |
| July  | Final Release               | 2.0.0                        |

### Installers

Going forward, downloads for our [daily builds](https://github.com/dotnet/core-setup#daily-builds) and [our releases](https://www.microsoft.com/net/download/core) will adhere to a new naming scheme that will be easier to understand.
The installer UI in those downloads will also be modified to clearly present the names and versions of the components being installed. In particular, titles will show the same version number that is in the download's file name.

#### Current name format

`[product]-[component]-[platform]-[arch].[major].[minor].[patch]-[previewN]-[optional build #].[file ext]`

Notice a few things with the list:

1. It's difficult to easily scan the component / version pair
2. Nothing is obviously presented as a Runtime component
3. Naming inconsistency between sdk and dev packages across platforms.

```
dotnet-osx-x64.1.0.4.pkg                            # Mac runtime installer
dotnet-dev-win-x64.1.0.1.exe                        # Windows SDK installer
dotnet-dev-fedora.24-x64.1.0.1.tar.gz               # Fedora 24 binary archive

#Ubuntu file set needed for the SDK
dotnet-host-ubuntu.16.04-x64.1.0.1.deb              # Host / muxer
dotnet-hostfxr-ubuntu.16.04-x64.1.0.1.deb           # Host policy
dotnet-sharedframework-ubuntu.16.04-x64.1.0.4.deb   # Runtime
dotnet-sdk-ubuntu.16.04-x64.1.0.1.deb               # SDK
```

#### Proposed name format change

`[product]-[major].[minor].[patch]-[previewN]-[optional build #]-[rid]-[component].[file ext]`

The proposed format change mitigates the issues highlighted above in a few ways.

1. Readability is greatly enhanced by ordering the information in increasing level of granularity from left to right: `product->version->platform->component`.
1. The runtime/shared framework package name includes 'runtime'.
1. The SDK package is named to consistently represent what is being installed. 'sdk' is renamed 'tools' and the top-level aggregate package is renamed 'sdk'.

```
dotnet-1.0.4-osx.10.12-x64-runtime.pkg              # Mac runtime installer
dotnet-1.0.1-win10-x64-sdk.exe                      # Windows SDK installer
dotnet-1.0.1-fedora.24-x64-sdk.tar.gz               # Fedora 24 binary archive

#Ubuntu file set needed for the SDK
dotnet-1.0.1-ubuntu.16.04-x64-host.deb              # Host / muxer
dotnet-1.0.1-ubuntu.16.04-x64-hostfxr.deb           # Host policy
dotnet-1.0.4-ubuntu.16.04-x64-runtime.deb           # rename component to runtime from sharedframework
dotnet-1.0.1-ubuntu.16.04-x64-tools.deb             # rename component to tools from sdk
```

### Package managers

.NET Core can be distributed by other entities than Microsoft. In particular, Linux distribution owners and package maintainers may add .NET Core packages to their package managers. We are issuing recommendations for how those packages should be named and versioned.

#### Minimum package set

* `dotnet-[major].[minor]`: a shared framework with the specified version (only the latest patch version for a given major+minor combination should be available in the package manager). New patch versions update the package, but new minor or major versions are separate packages.
  **Dependencies**: `dotnet-host`
* `dotnet-sdk`: the latest SDK. `update` rolls forward major, minor, and patch versions.
  **Dependencies**: the latest `dotnet-sdk-[major].[minor]`.
* `dotnet-sdk-[major].[minor]`: the SDK with the specified version. The version specified is the highest included version of included shared frameworks, so that users can easily relate an SDK to a shared framework. New patch versions update the package, but new minor or major versions are separate packages.
  **Dependencies**: `dotnet-host`, one or more `dotnet-[major].[minor]` (one of those is used by the SDK code itself, the others are here for users to build and run against).
* `dotnet-host`: the latest host.

##### Preview versions

Package maintainers may decide to include preview versions of the shared framework and SDK. Those should never be included in the unversioned package (`dotnet` and `dotnet-sdk`), but may be released as versioned packages with an additional preview marker appended to the major and minor version sections of the name. For example, there may be a `dotnet-sdk-2.0-preview-1-final` package.

### Docker

A general Docker tag naming convention is to place the version number before the component name, such as: `2.0.4-runtime`, or `2.0.4-sdk`.

## Semantic Versioning

.NET Core uses [Semantic Versioning (SemVer)](http://semver.org/), adopting the use of `MAJOR.MINOR.PATCH` versioning, using the various parts of the version number to describe the degree and kind of change.

```
MAJOR.MINOR.PATCH[-PRERELEASE-BUILDNUMBER]
```

The optional `PRERELEASE` and `BUILDNUMBER` parts will never be part of supported releases, and will only exist on nightly builds, locally built from source targets, and unsupported preview releases.

### How do we increment version numbers?

We increment `MAJOR` when:
  - we stop support for an old platform
  - we adopt a newer `MAJOR` version of an existing dependency 
  - we change the default setting of a compatibility quirk to "off"

We increment `MINOR` when:
  - we add public API surface area 
  - we add new behavior
  - we adopt a newer `MINOR` version of an existing dependency
  - we introduce a new dependency 
  
We increment `PATCH` when:
  - we make bug fixes
  - we add support for a newer platform
  - we adopt a newer `PATCH` version of an existing dependency
  - we make any other change that doesn't fit one of the above cases

When there are multiple changes, we increment the highest element that would be affected by individual changes, and reset the following ones to zero. For instance, when `MAJOR` is incremented, `MINOR` and `PATCH` are reset to zero. When `MINOR` is incremented, `PATCH` is reset to zero while `MAJOR` is left untouched.

### Preview versions

Preview versions have a `-preview-[number]-([build]|"final)"` appended to the version, e.g. `2.0.0-preview-1-final`.

### LTS vs. current

We maintain two trains of releases for .NET Core, to enable users to pick the level of stability and new features they want, while being supported.

- Long Term Support (LTS) means you'll get new features less frequently, but you'll have a more mature platform, that will be supported for a longer period.
- Current means you'll get new features and APIs more frequently, but the flipside is that you'll have a shorter window of time to install updates, and those will happen more frequently. Current is also fully supported.

An increment of the `MAJOR` number means a new LTS. For LTS, the `MINOR` number is always 0. We do release patches for LTS when necessary, however, so you may have LTS versions such as `2.0.3`.

A new Current version will have an incremented `MINOR` or `PATCH` number, but `MAJOR` number changes are reserved for LTS.

This makes it easy to recognize what train a release belongs to: if the `MINOR` number is zero, it's LTS. If it's not zero, it's a Current train version.

## Versioning Scheme

.NET Core is made of the following parts:

- a host, a.k.a. muxer (`dotnet.exe`) with `hostfxr` policy libraries
- an SDK (the set of tools necessary on a developer's machine, but not in production)
- a runtime
- a shared framework implementation, distributed as packages. Each package is versioned independently, particularly for patch versioning.
- Optionally, a set of metapackages that reference fine-grained packages as a versioned unit. Metapackages can be versioned separately from packages.

.NET Core also includes a set of target frameworks (for example, `netstandard` or `netcoreapp`) that represent a progressively larger API set, described in a set of snapshots with version numbers that grow with the API surface.

### .NET Standard

.NET Standard has been using a `MAJOR.MINOR` versioning scheme. `PATCH` level is not useful for .NET Standard because it expresses a set of contracts that will be iterated on less often, and doesn't present the same requirements for versioning as an actual implementation.

There is no real coupling between .NET Standard versions and .NET Core versions: .NET Core 2.0 happens to implement .NET Standard 2.0, but there is no guarantee that future versions of .NET Core will map to the same .NET Standard version. .NET Core can ship APIs that are not defined by .NET Standard, and as such may ship new versions without requiring a new .NET Standard. .NET Standard is also a concept that applies to other targets (.NET Framework, Mono, etc.), even if its inception happened to coincide with that of .NET Core.

### Packages

Library packages evolve and version independently. Packages that overlap with .NET Framework System.\* assemblies typically use 4.x versions, aligning with the .NET Framework 4.x versioning (a historical choice). Packages that do not overlap with the .NET Framework libraries (for example, [`System.Reflection.Metadata`](https://www.nuget.org/packages/System.Reflection.Metadata)) typically start at 1.0 and increment from there.

The packages described by [`NETStandard.Library`](https://www.nuget.org/packages/NETStandard.Library) are treated specially due to being at the base of the platform.

`NETStandard.Library` packages will typically version as a set, since they have implementation-level dependencies between them.

### Metapackages

Versioning for .NET Core metapackages is based on the .NET Core version they are a part of.

For instance, the metapackages in .NET Core 2.1.3 should all have 2.1 as their `MAJOR` and `MINOR` version numbers.

The patch version for the metapackage is incremented every time any referenced package is updated. Patch versions will never include an updated framework version. As a result, the metapackages are not strictly SemVer compliant because their versioning scheme doesn't represent the degree of change in the underlying packages, but primarily the API level. 

There are currently two primary metapackages for .NET Core.

**Microsoft.NETCore.App**

- v1.0 as of .NET Core 1.0 (these versions will match).
- Maps to the `netcoreapp` framework.
- Describes the packages in the .NET Core distribution.

Note: [`Microsoft.NETCore.Portable.Compatibility`](https://www.nuget.org/packages/Microsoft.NETCore.Portable.Compatibility) is another .NET Core metapackage that exists to enable compatibility with pre .NET Standard implementation of .NET. It doesn't map to a particular framework, so versions like a package.

**NETStandard.Library**

`NETStandard.Library` describes the packages that are considered required for modern app development and that .NET platforms must implement to be considered a [.NET Standard](../../standard/library.md) platform.

### Target Frameworks

Target framework versions are updated when new APIs are added. They have no concept of patch version, since they represent API shape and not implementation concerns. Major and minor versioning will follow the SemVer rules specified earlier, and will coincide with the `MAJOR` and `MINOR` numbers of the .NET Core distributions that implement them.

## Versioning in Practice

When you download .NET Core, the name of the file you download carries the version, e.g. `dotnet-1.0.1-win10-x64-sdk.exe`.

There are commits and pull requests on .NET Core repos on GitHub on a daily basis, resulting in new builds of many libraries. It is not practical to create new public versions of .NET Core for every change. Instead, changes will be aggregated over some loosely-defined period of time (for example, weeks or months) before making a new public stable .NET Core version.

A new version of .NET Core could mean several things:

- New versions of packages and metapackages.
- New versions of various frameworks, assuming the addition of new APIs.
- New version of the .NET Core distribution.

### Shipping a patch release

After shipping a .NET Core v1.0.0 stable version, patch-level changes (no new APIs) are made to .NET Core libraries to fix bugs and improve performance and reliability. The various metapackages are updated to reference the updated .NET Core library packages. The metapackages are versioned as patch updates (`MAJOR.MINOR.PATCH`). Target frameworks are never updated as part of patch releases. A new .NET Core distribution is released with a version number that matches that of the `Microsoft.NETCore.App` metapackage. That release may be made on the LTS or Current release train.

### Shipping a minor release

After shipping a .NET Core stable (LTS) version with an incremented `MAJOR` version number, new APIs are added to .NET Core libraries to enable new scenarios. The various metapackages are updated to reference the updated .NET Core library packages. The metapackages are versioned as patch updates with `MAJOR` and `MINOR` version numbers matching the new framework version. New target framework names with the new `MAJOR.MINOR` version are added to describe the new APIs (e.g. `netcoreapp2.1`). A new .NET Core distribution is released with a matching version number to the `Microsoft.NETCore.App` metapackage. That release is made on the Current release train.

### Shipping a major release

Every time a new LTS version of .NET Core ships, the `MAJOR` version number gets incremented, and the `MINOR` version number gets reset to zero. The new LTS contains at least all the APIs that were added by minor releases after the previous LTS. A new LTS should enable major new scenarios, and may also drop support for an older platform.

The various metapackages are updated to reference the updated .NET Core library packages. The `Microsoft.NETCore.App` metapackage and the `netcore` framework are versioned as a major update matching the `MAJOR` version number of the new LTS release.
