---
title: .NET Core versioning
description: Understand how .NET Core versioning works.
author: bleroy
ms.author: mairaw
ms.date: 02/13/2018
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: f6f684b1-1d2c-4105-8376-7c1959e23803
ms.workload: 
  - dotnetcore
---
# .NET Core versioning

.NET Core is made of [NuGet packages](../packages.md), tools, and frameworks that are distributed as a unit. Each of these platform layers can be versioned separately, enabling better agility. While there is significant versioning flexibility in that regard, there's also a desire to version the platform as a unit to make the product easier to understand.

This article aims at clarifying how the .NET Core SDK and runtime are versioned.

There are lots of moving parts that version independently in .NET Core. However, starting with .NET Core 2.0, there is an easy to understand top-level version number that everybody understands to be *the* version of ".NET Core" as a whole. The rest of this document goes into the details of the versioning of all those parts. These details can be important if you're a package manager, for example.

> [!IMPORTANT]
> The versioning details explained on this topic don't apply to the current version of the .NET Core SDK and runtime.
> The version scheme is changing in future releases. You can see the current proposal at the [dotnet/designs](https://github.com/dotnet/designs/pull/29) repository.

## Versioning details

With .NET Core 2.0, downloads show a single version number in their file name. The following version numbers were unified:

* The shared framework and associated runtime.
* The .NET Core SDK and associated .NET Core CLI.
* The `Microsoft.NETCore.App` metapackage.

The use of a single version number makes it easier for users to know what version of the SDK to install on their dev machines, and what the corresponding version of the shared framework should be when time comes to provision a production environment. When downloading an SDK or runtime, the version number you see is going to be the same.

### Installers

With .NET Core 2.0, downloads for the [daily builds](https://github.com/dotnet/core-setup#daily-builds) and [releases](https://www.microsoft.com/net/download/core) adhere to a new naming scheme that is easier to understand.
The installer UI in those downloads was also modified to clearly present the names and versions of the components being installed. In particular, titles now show the same version number that is in the download's file name.

#### File name format

`[product]-[component]-[major].[minor].[patch]-[previewN]-[optional build #]-[rid].[file ext]`

Here are some examples of this format:

```
dotnet-runtime-2.0.4-macos.10.12-x64.pkg            # Mac runtime installer
dotnet-sdk-2.0.4-win10-x64.exe                      # Windows SDK installer
dotnet-sdk-2.0.4-fedora.24-x64.tar.gz               # Fedora 24 binary archive

#Ubuntu file set needed for the SDK
dotnet-host-2.0.4-ubuntu.16.04-x64.deb              # Host / muxer and host policy
dotnet-runtime-2.0.4-ubuntu.16.04-x64.deb           # runtime
dotnet-sdk-2.0.4-ubuntu.16.04-x64.deb               # SDK tools
```

The format is readable and clearly shows what you're downloading, what version it is, and where you can use it. The runtime package name includes `runtime`, and the SDK includes `SDK`.

#### UI string format

All web site descriptions and UI strings in the installers are kept consistent, accurate, and simple. The following table shows some examples:

| Installer | Window Title                          | Other content in installer | What is installed                               |
| :--       | :--                                   | :--                        | :--                                             |
| SDK       | .NET Core 2.0 SDK (x64) Installer     | .NET Core 2.0.4 SDK        | .NET Core 2.0.4 Tools + .NET Core 2.0.4 Runtime |
| Runtime   | .NET Core 2.0 Runtime (x64) Installer | .NET Core 2.0.4 Runtime    | .NET Core 2.0.4 Runtime                         |

Preview releases differ only slightly:

| Installer | Window Title                                    | Other content in installer        | What is installed                                                   |
| :--       | :--                                             | :--                               | :--                                                                 |
| SDK       | .NET Core 2.0 Preview 1 SDK (x64) Installer     | .NET Core 2.0.0 Preview 1 SDK     | .NET Core 2.0.0 Preview 1 Tools + .NET Core 2.0.0 Preview 1 Runtime |
| Runtime   | .NET Core 2.0 Preview 1 Runtime (x64) Installer | .NET Core 2.0.0 Preview 1 Runtime | .NET Core 2.0.0 Preview 1 Runtime                                   |

It may happen that an SDK release contains more than one version of the runtime. When that happens, the installer UX looks like the following (only the SDK version is shown and the installed Runtime versions are shown on a summary page at the end of the installation process on Windows and Mac):

| Installer | Window Title                      | Other content in installer                                   | What is installed                                                         |
| :--       | :--                               | :--                                                          | :--                                                                       |
| SDK       | .NET Core 2.1 SDK (x64) Installer | .NET Core 2.1.1 SDK <br> .NET Core 2.1.1 Runtime <br> .NET Core 2.0.6 Runtime | .NET Core 2.1.1 Tools + .NET Core 2.1.1 Runtime + .NET Core 2.0.6 Runtime |

It's also possible that .NET Core Tools need to be updated, without runtime changes. In that case, the SDK version is increased (for example, to 2.1.2) and then the Runtime catches up the next time it ships (for example, both the Runtime and SDK ship the next time as 2.1.3).

### Package managers

.NET Core can be distributed by other entities than Microsoft. In particular, Linux distribution owners and package maintainers may add .NET Core packages to their package managers. For recommendations on how those packages should be named and versioned, see [.NET Core distribution packaging](../build/distribution-packaging.md).

#### Minimum package set

* `dotnet-runtime-[major].[minor]`: a runtime with the specified version (only the latest patch version for a given major+minor combination should be available in the package manager). New patch versions update the package, but new minor or major versions are separate packages.

  **Dependencies**: `dotnet-host`

* `dotnet-sdk`: the latest SDK. `update` rolls forward major, minor, and patch versions.

  **Dependencies**: the latest `dotnet-sdk-[major].[minor]`.

* `dotnet-sdk-[major].[minor]`: the SDK with the specified version. The version specified is the highest included version of included shared frameworks, so that users can easily relate an SDK to a shared framework. New patch versions update the package, but new minor or major versions are separate packages.

  **Dependencies**: `dotnet-host`, one or more `dotnet-runtime-[major].[minor]` (one of those is used by the SDK code itself, the others are here for users to build and run against).

* `dotnet-host`: the latest host.

##### Preview versions

Package maintainers may decide to include preview versions of the runtime and SDK. Don't include those preview versions in the unversioned `dotnet-sdk` package, but you can release them as versioned packages with an additional preview marker appended to the major and minor version sections of the name. For example, there may be a `dotnet-sdk-2.0-preview1-final` package.

### Docker

A general Docker tag naming convention is to place the version number before the component name. This convention may continue to be utilized. The current tags include only the Runtime version as follows.

* 1.0.8-runtime
* 1.0.8-sdk
* 2.0.4-runtime
* 2.0.4-sdk
* 2.1.1-runtime
* 2.1.1-sdk

The SDK tags should be updated to represent the SDK version rather than Runtime.

It's also possible that the .NET Core CLI tools (included in the SDK) are fixed but reship with an existing runtime. In that case, the SDK version is increased (for example, to 2.1.2), and then the Runtime catches up the next time it ships (for example, both the Runtime and SDK ship the following time as 2.1.3).

## Semantic Versioning

.NET Core uses [Semantic Versioning (SemVer)](http://semver.org/), adopting the use of `MAJOR.MINOR.PATCH` versioning, using the various parts of the version number to describe the degree and type of change.

```
MAJOR.MINOR.PATCH[-PRERELEASE-BUILDNUMBER]
```

The optional `PRERELEASE` and `BUILDNUMBER` parts are never part of supported releases and only exist on nightly builds, local builds from source targets, and unsupported preview releases.

### How version numbers are incremented?

`MAJOR` is incremented when:

- An old version is no longer supported.
- A newer `MAJOR` version of an existing dependency is adopted.
- The default setting of a compatibility quirk is changed to "off."

`MINOR` is incremented when:

- Public API surface area is added.
- A new behavior is added.
- A newer `MINOR` version of an existing dependency is adopted.
- A new dependency is introduced.

`PATCH` is incremented when:

- Bug fixes are made.
- Support for a newer platform is added.
- A newer `PATCH` version of an existing dependency is adopted.
- Any other change doesn't fit one of the previous cases.

When there are multiple changes, the highest element affected by individual changes is incremented, and the following ones are reset to zero. For example, when `MAJOR` is incremented, `MINOR` and `PATCH` are reset to zero. When `MINOR` is incremented, `PATCH` is reset to zero while `MAJOR` is left untouched.

### Preview versions

Preview versions have a `-preview[number]-([build]|"final")` appended to the version. For example, `2.0.0-preview1-final`.

### Servicing versions

After a release goes out, the release branches generally stop producing daily builds and instead start producing servicing builds. Servicing versions have a `-servicing-[number]` appended to the version. For example, `2.0.1-servicing-006924`.

### LTS vs. current

There are two trains of releases for .NET Core: Long Term Support (LTS) and Current. That enables users to pick the level of stability and new features they want, while still being supported.

- LTS means you get new features less frequently, but you have a more mature platform. LTS also has a longer period of support.
- Current means you get new features and APIs more frequently, but the disadvantage is that you have a shorter window of time to install updates, and those updates happen more frequently. Current is also fully supported but the support period is shorter than LTS.

A "Current" version may get promoted to LTS.

"LTS" and "Current" should be considered as labels that we put on specific releases to make a statement about the associated level of support.

For more information, see [.NET Core Support Lifecycle Fact Sheet](https://www.microsoft.com/net/core/support).

## Versioning scheme details

.NET Core is made of the following parts:

- A host: either *dotnet.exe* for framework-dependent applications, or *\<appname>.exe* for self-contained applications.
- An SDK (the set of tools necessary on a developer's machine, but not in production).
- A runtime.
- A shared framework implementation, distributed as packages. Each package is versioned independently, particularly for patch versioning.
- Optionally, a set of [metapackages](../packages.md) that reference fine-grained packages as a versioned unit. Metapackages can be versioned separately from packages.

.NET Core also includes a set of target frameworks (for example, `netstandard` or `netcoreapp`) that represent a progressively larger API set, as version numbers are incremented.

### .NET Standard

.NET Standard has been using a `MAJOR.MINOR` versioning scheme. `PATCH` level isn't useful for .NET Standard because it expresses a set of contracts that are iterated on less often and doesn't present the same requirements for versioning as an actual implementation.

There is no real coupling between .NET Standard versions and .NET Core versions: .NET Core 2.0 happens to implement .NET Standard 2.0, but there is no guarantee that future versions of .NET Core will map to the same .NET Standard version. .NET Core can ship APIs that aren't defined by .NET Standard, and, as such, may ship new versions without requiring a new .NET Standard. .NET Standard is also a concept that applies to other targets, such as .NET Framework or Mono, even if its inception happened to coincide with that of .NET Core.

### Packages

Library packages evolve and version independently. Packages that overlap with .NET Framework System.\* assemblies typically use 4.x versions, aligning with the .NET Framework 4.x versioning (a historical choice). Packages that do not overlap with the .NET Framework libraries (for example, [`System.Reflection.Metadata`](https://www.nuget.org/packages/System.Reflection.Metadata)) typically start at 1.0 and increment from there.

The packages described by [`NETStandard.Library`](https://www.nuget.org/packages/NETStandard.Library) are treated specially due to being at the base of the platform.

`NETStandard.Library` packages will typically version as a set, since they have implementation-level dependencies between them.

### Metapackages

Versioning for .NET Core metapackages is based on the .NET Core version they are a part of.

For instance, the metapackages in .NET Core 2.1.3 should all have 2.1 as their `MAJOR` and `MINOR` version numbers.

The patch version for the metapackage is incremented every time any referenced package is updated. Patch versions don't include an updated framework version. As a result, the metapackages aren't strictly SemVer-compliant because their versioning scheme doesn't represent the degree of change in the underlying packages, but primarily of the API level.

There are currently two primary metapackages for .NET Core:

**Microsoft.NETCore.App**

- v1.0 as of .NET Core 1.0 (these versions match).
- Maps to the `netcoreapp` framework.
- Describes the packages in the .NET Core distribution.

Note: [`Microsoft.NETCore.Portable.Compatibility`](https://www.nuget.org/packages/Microsoft.NETCore.Portable.Compatibility) is another .NET Core metapackage that exists to enable compatibility with pre-.NET Standard implementation of .NET. It doesn't map to a particular framework, so it versions like a package.

**NETStandard.Library**

[`NETStandard.Library`](https://www.nuget.org/packages/NETStandard.Library) describes the libraries that are part of the [.NET Standard](../../standard/library.md). Applies to all .NET implementations that support .NET Standard, such as .NET Framework, .NET Core, and Mono.

### Target frameworks

Target framework versions are updated when new APIs are added. They have no concept of patch version, since they represent API shape and not implementation concerns. Major and minor versioning follows the SemVer rules specified earlier, and coincides with the `MAJOR` and `MINOR` numbers of the .NET Core distributions that implement them.

## Versioning in practice

When you download .NET Core, the name of the downloaded file carries the version, for example, `dotnet-sdk-2.0.4-win10-x64.exe`.

There are commits and pull requests on .NET Core repos on GitHub on a daily basis, resulting in new builds of many libraries. It isn't practical to create new public versions of .NET Core for every change. Instead, changes are aggregated over an undetermined period of time (for example, weeks or months) before making a new public stable .NET Core version.

A new version of .NET Core could mean several things:

- New versions of packages and metapackages.
- New versions of various frameworks, assuming the addition of new APIs.
- New version of the .NET Core distribution.

### Shipping a patch release

After shipping a major release of .NET Core, such as version 2.0.0, patch-level changes are made to .NET Core libraries to fix bugs and improve performance and reliability. That means that no new APIs are introduced. The various metapackages are updated to reference the updated .NET Core library packages. The metapackages are versioned as patch updates (`MAJOR.MINOR.PATCH`). Target frameworks are never updated as part of patch releases. A new .NET Core distribution is released with a version number that matches that of the `Microsoft.NETCore.App` metapackage.

### Shipping a minor release

After shipping a .NET Core version with an incremented `MAJOR` version number, new APIs are added to .NET Core libraries to enable new scenarios. The various metapackages are updated to reference the updated .NET Core library packages. The metapackages are versioned as patch updates with `MAJOR` and `MINOR` version numbers matching the new framework version. New target framework names with the new `MAJOR.MINOR` version are added to describe the new APIs (for example, `netcoreapp2.1`). A new .NET Core distribution is released with a matching version number to the `Microsoft.NETCore.App` metapackage.

### Shipping a major release

Every time a new major version of .NET Core ships, the `MAJOR` version number gets incremented, and the `MINOR` version number gets reset to zero. The new major version contains at least all the APIs that were added by minor releases after the previous major version. A new major version should enable important new scenarios, and it may also drop support for an older platform.

The various metapackages are updated to reference the updated .NET Core library packages. The [`Microsoft.NETCore.App`](https://www.nuget.org/packages/Microsoft.NETCore.App) metapackage and the `netcore` target framework are versioned as a major update matching the `MAJOR` version number of the new release.

## See also

[Target frameworks](../../standard/frameworks.md)  
[.NET Core distribution packaging](../build/distribution-packaging.md)  
[.NET Core Support Lifecycle Fact Sheet](https://www.microsoft.com/net/core/support)  
[.NET Core 2+ Version Binding](https://github.com/dotnet/designs/issues/3)  
