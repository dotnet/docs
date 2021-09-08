---
title: How the .NET Runtime and SDK are versioned
description: This article explains how the .NET SDK and Runtime are versioned (similar to semantic versioning).
ms.date: 07/08/2021
---

# Overview of how .NET is versioned

The [.NET Runtime and the .NET SDK](../introduction.md#sdk-and-runtimes) add new features at different frequencies. In general, the SDK is updated more frequently than the Runtime. This article explains the runtime and the SDK version numbers.

.NET releases a new major version every November. Even-numbered releases, such as .NET 6 or .NET 8, are long-term supported (LTS). Odd-numbered releases are supported until the next major release. The latest release of .NET is .NET 5.

## Versioning details

The .NET Runtime has a major.minor.patch approach to versioning that follows [semantic versioning](#semantic-versioning).

The .NET SDK, however, doesn't follow semantic versioning. The .NET SDK releases faster and its version numbers must communicate both the aligned runtime and the SDK's own minor and patch releases.

The first two positions of the .NET SDK version number match the .NET Runtime version it released with. Each version of the SDK can create applications for this runtime or any lower version.

The third position of the SDK version number communicates both the minor and patch number. The minor version is multiplied by 100. The final two digits represent the patch number. Minor version 1, patch version 2 would be represented as 102. For example, here's a possible sequence of runtime and SDK version numbers:

| Change                | .NET Runtime      | .NET SDK (\*)     |
|-----------------------|-------------------|-------------------|
| Initial release       | 5.0.0             | 5.0.100           |
| SDK patch             | 5.0.0             | 5.0.101           |
| Runtime and SDK patch | 5.0.1             | 5.0.102           |
| SDK feature change    | 5.0.1             | 5.0.200           |

NOTES:

- If the SDK has 10 feature updates before a runtime feature update, version numbers roll into the 1000 series. Version 5.0.1000 would follow version 5.0.900. This situation isn't expected to occur.
- 99 patch releases without a feature release won't occur. If a release approaches this number, it forces a feature release.

You can see more details in the initial proposal at the [dotnet/designs](https://github.com/dotnet/designs/pull/29) repository.

## Semantic versioning

The .NET *Runtime* roughly adheres to [Semantic Versioning (SemVer)](https://semver.org/), adopting the use of `MAJOR.MINOR.PATCH` versioning, using the various parts of the version number to describe the degree and type of change.

```
MAJOR.MINOR.PATCH[-PRERELEASE-BUILDNUMBER]
```

The optional `PRERELEASE` and `BUILDNUMBER` parts are never part of supported releases and only exist on nightly builds, local builds from source targets, and unsupported preview releases.

### Understand runtime version number changes

- `MAJOR` is incremented once a year and may contain:

  - Significant changes in the product, or a new product direction.
  - API introduced breaking changes. There's a high bar to accepting breaking changes.
  - A newer `MAJOR` version of an existing dependency is adopted.
  
  Major releases happen once a year, even-numbered versions are long-term supported (LTS) releases. The first LTS release using this versioning scheme is .NET 6, which will be released in November 2021. The latest non-LTS version is .NET 5.
  
- `MINOR` is incremented when:

  - Public API surface area is added.
  - A new behavior is added.
  - A newer `MINOR` version of an existing dependency is adopted.
  - A new dependency is introduced.

- `PATCH` is incremented when:

  - Bug fixes are made.
  - Support for a newer platform is added.
  - A newer `PATCH` version of an existing dependency is adopted.
  - Any other change doesn't fit one of the previous cases.

When there are multiple changes, the highest element affected by individual changes is incremented, and the following ones are reset to zero. For example, when `MAJOR` is incremented, `MINOR.PATCH` are reset to zero. When `MINOR` is incremented, `PATCH` is reset to zero while `MAJOR` remains the same.

## Version numbers in file names

The files downloaded for .NET carry the version, for example, `dotnet-sdk-5.0.301-win10-x64.exe`.

### Preview versions

Preview versions have a `-preview.[number].[build]` appended to the version number. For example, `6.0.0-preview.5.21302.13`.

### Servicing versions

After a release goes out, the release branches generally stop producing daily builds and instead start producing servicing builds. Servicing versions have a `-servicing-[number]` appended to the version. For example, `5.0.1-servicing-006924`.

## See also

- [Target frameworks](../../standard/frameworks.md)
- [.NET distribution packaging](../distribution-packaging.md)
- [.NET Support Lifecycle Fact Sheet](https://dotnet.microsoft.com/platform/support/policy)
- [Docker images for .NET](https://hub.docker.com/_/microsoft-dotnet/)
