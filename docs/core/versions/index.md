---
title: How the .NET Core Runtime and SDK are versioned
description: This article teaches you how the .NET Core SDK and Runtime are versioned (similar to semantic versioning).
author: bleroy
ms.date: 07/26/2018
ms.custom: "seodec18"
---

# Overview of how .NET Core is versioned

.NET Core refers to the .NET Core Runtime and the .NET Core SDK, which contains the tools you need to develop applications. .NET Core SDKs are designed to work with any previous version of the .NET Core Runtime. This article explains the runtime and the SDK version strategy. An explanation of version numbers for .NET Standard can be found in the article introducing [.NET Standard](../../standard/net-standard.md#net-implementation-support).

The .NET Core Runtime and .NET Core SDK add new features at a different rate - in general the .NET Core SDK provides updated tools more quickly than the .NET Core Runtime changes the runtime you use in production.

## Versioning details

".NET Core 2.1" refers to the .NET Core Runtime version number. The .NET Core Runtime has a major/minor/patch approach to versioning that follows [semantic versioning](#semantic-versioning).

The .NET Core SDK doesn't follow semantic versioning. The .NET Core SDK releases faster and its versions must communicate both the aligned runtime and the SDK's own minor and patch releases. The first two positions of the .NET Core SDK version are locked to the .NET Core Runtime it released with. Each version of the SDK can create applications for this runtime or any lower version.

The third position of the SDK version number communicates both the minor and patch number. The minor version is multiplied by 100. Minor version 1, patch version 2 would be represented as 102. The final two digits represent the patch number. For example, the release of .NET Core 2.2 may create releases like the following table:

| Change                | .NET Core Runtime | .NET Core SDK (*) |
|-----------------------|-------------------|-------------------|
| Initial release       | 2.2.0             | 2.2.100           |
| SDK Patch             | 2.2.0             | 2.2.101           |
| Runtime and SDK Patch | 2.2.1             | 2.2.102           |
| SDK Feature change    | 2.2.1             | 2.2.200           |

(\*) This chart uses a future 2.2 .NET Core Runtime as the example because a historic artifact meant the first SDK for .NET Core 2.1 is 2.1.300. For more information, See the [.NET Core version selection](selection.md).

NOTES:

* If the SDK has 10 feature updates before a runtime feature update, version numbers roll into the 1000 series with numbers like 2.2.1000 as the feature release following 2.2.900. This situation isn't expected to occur.
* 99 patch releases without a feature release won't occur. If a release approaches this number, it forces a feature release.

You can see more details in the initial proposal at the [dotnet/designs](https://github.com/dotnet/designs/pull/29) repository.

## Semantic versioning

The .NET Core *Runtime* roughly adheres to [Semantic Versioning (SemVer)](https://semver.org/), adopting the use of `MAJOR.MINOR.PATCH` versioning, using the various parts of the version number to describe the degree and type of change.

```
MAJOR.MINOR.PATCH[-PRERELEASE-BUILDNUMBER]
```

The optional `PRERELEASE` and `BUILDNUMBER` parts are never part of supported releases and only exist on nightly builds, local builds from source targets, and unsupported preview releases.

### Understand runtime version number changes

`MAJOR` is incremented when:

* Significant changes occur to the product, or a new product direction.
* Breaking changes were taken. There's a high bar to accepting breaking changes.
* An old version is no longer supported.
* A newer `MAJOR` version of an existing dependency is adopted.

`MINOR` is incremented when:

* Public API surface area is added.
* A new behavior is added.
* A newer `MINOR` version of an existing dependency is adopted.
* A new dependency is introduced.

`PATCH` is incremented when:

* Bug fixes are made.
* Support for a newer platform is added.
* A newer `PATCH` version of an existing dependency is adopted.
* Any other change doesn't fit one of the previous cases.

When there are multiple changes, the highest element affected by individual changes is incremented, and the following ones are reset to zero. For example, when `MAJOR` is incremented, `MINOR` and `PATCH` are reset to zero. When `MINOR` is incremented, `PATCH` is reset to zero while `MAJOR` is left untouched.

## Version numbers in file names

The files downloaded for .NET Core carry the version, for example, `dotnet-sdk-2.1.300-win10-x64.exe`.

### Preview versions

Preview versions have a `-preview[number]-([build]|"final")` appended to the version. For example, `2.0.0-preview1-final`.

### Servicing versions

After a release goes out, the release branches generally stop producing daily builds and instead start producing servicing builds. Servicing versions have a `-servicing-[number]` appended to the version. For example, `2.0.1-servicing-006924`.

## Relationship to .NET Standard versions

.NET Standard consists of a .NET reference assembly. There are multiple implementations specific to each platform. The reference assembly contains the definition of .NET APIs which are part of a given .NET Standard version. Each implementation fulfills the .NET Standard contract on the specific platform. You can learn more about .NET Standard in the article on [.NET Standard](../../standard/net-standard.md) in the .NET Guide.

The .NET Standard reference assembly uses a `MAJOR.MINOR` versioning scheme. `PATCH` level isn't useful for .NET Standard because it exposes only an API specification (no implementation) and by definition any change to the API would represent a change in the feature set, and thus a new `MINOR` version.

The implementations on each platform may be updated, typically as part of the platform release, and thus not evident to the programmers using .NET Standard on that platform.

Each version of .NET Core implements a version of .NET Standard. Implementing a version of .NET Standard implies support for previous versions of .NET Standard. .NET Standard and .NET Core version independently. It's a coincidence that .NET Core 2.0 implements .NET Standard 2.0. .NET Core 2.1 also implements .NET Standard 2.0. .NET Core will support future versions of .NET Standard as they become available.

| .NET Core | .NET Standard |
|-----------|---------------|
| 1.0       | up to 1.6     |
| 2.0       | up to 2.0     |
| 2.1       | up to 2.0     |

## See also

* [Target frameworks](../../standard/frameworks.md)  
* [.NET Core distribution packaging](../build/distribution-packaging.md)  
* [.NET Core Support Lifecycle Fact Sheet](https://www.microsoft.com/net/core/support)  
* [.NET Core 2+ Version Binding](https://github.com/dotnet/designs/issues/3)  
* [Docker images for .NET Core](https://hub.docker.com/r/microsoft/dotnet/)
