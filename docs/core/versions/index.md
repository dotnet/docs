---
title: .NET Core versioning
description: Understand how .NET Core versioning works.
author: bleroy
ms.author: mairaw
ms.date: 02/13/2018
---
# .NET Core versioning

.NET Core refers to the .NET Core Runtime and the .NET Core SDK which contains the tools you need to develop applications. A version of the .NET Core Runtime. .NET Core SDKs are designed to work with any previous version of the .NET Core Runtime.

This article aims at clarifying version numbers for .NET Core SDK and .NET Core Runtime. [An explanation of version numbers for .NET Standard can be found here]().

The central problem of versioning is that the .NET Core Runtime and .NET Core SDK add new features at a different rate - in general the .NET Core SDK provides updated tools more quickly than the .NET Core Runtime changes the runtime you use in production. Unfortunately, this problem has resulted in several versioning strategies over the last few years. You can learn about the [history of .NET Core versioning here]().

## Versioning details

.NET Core 2.1 aligns to the .NET Core Runtime version number. .NET Core Runtime has a major/minor/patch approach to versioning that is roughly aligned with the [semantic versioning]([[Link to semantic versioning later in this doc]]).

The .NET Core SDK will not follow semantic versioning. Since the .NET Core SDK will release faster, we need to communicate both the aligned runtime and the communicate the SDK's own minor and patch releases. To do this, the first two positions of the .NET Core SDK is locked to the .NET Core Runtime it is released with. Each version of the SDK can create applications in this runtime or any lower version.

The third position of the SDK version number will be used to communicate both the minor and patch number. We will do this by multiplying the minor version by 100 (starting at 100). The final two digits will be the patch number. For example, the release of .NET Core 2.2 are expected to be similar to:

| Change                | .NET Core Runtime | .NET Core SDK (*) |
|-----------------------|-------------------|-------------------|
| Initial release       | 2.2.0             | 2.2.100           |
| SDK Patch             | 2.2.0             | 2.2.101           |
| Runtime and SDK Patch | 2.2.1             | 2.2.102           |
| SDK Feature change    | 2.2.1             | 2.2.200           |

(*) this chart uses .NET Core Runtime as the example because a historic artifact meant the first SDK for .NET Core 2.1 is 2.1.300. See the [history of .NET Core versioning here]()

NOTES: 

* If the SDK has ten feature updates before a runtime feature update we will roll into the 1000 series with numbers like 2.2.1000 as the feature release following 2.2.900. This is not expected to occur.
* 99 patch releases without a feature release will not occur. If we approach this number, we will force a feature release.

You can see more details in the initial proposal at the [dotnet/designs](https://github.com/dotnet/designs/pull/29) repository.

## Product naming

Web site descriptions and UI strings in the installers use the .NET Core Runtime major and minor version numbers. The following table shows some examples:

| Installer       | Description                            |
|-----------------|----------------------------------------|
| SDK             | .NET Core 2.1 SDK (v2.1.300)           |
| Runtime         | .NET Core 2.0 Runtime                  |
| SDK Preview     | .NET Core 2.1 SDK (v2.1.300) Preview 1 |
| Runtime Preview | .NET Core 2.1 Runtime Preview 1        |

## Package managers

.NET Core can be distributed by other entities than Microsoft. In particular, Linux distribution owners and package maintainers may add .NET Core packages to their package managers. For recommendations on how those packages should be named and versioned, see [.NET Core distribution packaging](../build/distribution-packaging.md).

## Semantic Versioning

.NET Core *Runtime* roughly adheres to [Semantic Versioning (SemVer)](http://semver.org/), adopting the use of `MAJOR.MINOR.PATCH` versioning, using the various parts of the version number to describe the degree and type of change.

```
MAJOR.MINOR.PATCH[-PRERELEASE-BUILDNUMBER]
```

The optional `PRERELEASE` and `BUILDNUMBER` parts are never part of supported releases and only exist on nightly builds, local builds from source targets, and unsupported preview releases.

### Guidelines for incrementing runtime version numbers

`MAJOR` is incremented when:

- Significant changes occur to the product, or a new product direction.
- Breaking changes need to be taken. The bar for breaking changes will be high.
- An old version is no longer supported.
- A newer `MAJOR` version of an existing dependency is adopted.

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

## Version numbers in file names

When you download .NET Core, the name of the downloaded file carries the version, for example, `dotnet-sdk-2.1.300-win10-x64.exe`.

### Preview versions

Preview versions have a `-preview[number]-([build]|"final")` appended to the version. For example, `2.0.0-preview1-final`.

### Servicing versions

After a release goes out, the release branches generally stop producing daily builds and instead start producing servicing builds. Servicing versions have a `-servicing-[number]` appended to the version. For example, `2.0.1-servicing-006924`.

## See also

[Target frameworks](../../standard/frameworks.md)  
[.NET Core distribution packaging](../build/distribution-packaging.md)  
[.NET Core Support Lifecycle Fact Sheet](https://www.microsoft.com/net/core/support)  
[.NET Core 2+ Version Binding](https://github.com/dotnet/designs/issues/3)  
