---
title: How the .NET Runtime and SDK are versioned
description: This article explains how the .NET SDK and Runtime are versioned (similar to semantic versioning).
ms.date: 04/26/2023
---

# How .NET is versioned

The [.NET Runtime and the .NET SDK](../introduction.md) add new features at different frequencies. In general, the SDK is updated more frequently than the Runtime. This article explains the runtime and the SDK version numbers.

.NET releases a new major version every November. Even-numbered releases, such as .NET 6 or .NET 8, are long-term supported (LTS). LTS releases get free support and patches for three years. Odd-numbered releases are standard-term support. Standard-term support releases get free support and patches for 18 months.

## Versioning details

The .NET Runtime has a major.minor.patch approach to versioning that follows [semantic versioning](#semantic-versioning).

The .NET SDK, however, doesn't follow semantic versioning. The .NET SDK releases faster and its version numbers must communicate both the aligned runtime and the SDK's own minor and patch releases.

The first two positions of the .NET SDK version number match the .NET Runtime version it released with. Each version of the SDK can create applications for this runtime or any lower version.

The third position of the SDK version number communicates both the minor and patch number. The minor version is multiplied by 100. The final two digits represent the patch number. Minor version 1, patch version 2 would be represented as 102. For example, here's a possible sequence of runtime and SDK version numbers:

| Change                | .NET Runtime      | .NET SDK (\*)     | Notes |
|-----------------------|-------------------|-------------------|-------------------------------------------------------------------------------------|
| Initial release       | 5.0.0             | 5.0.100           | Initial release.                                                                    |
| SDK patch             | 5.0.0             | 5.0.101           | Runtime didn't change with this SDK patch. SDK patch bumps last digit in SDK patch. |
| Runtime and SDK patch | 5.0.1             | 5.0.102           | Runtime patch bumps Runtime patch number. SDK patch bumps last digit in SDK patch.  |
| SDK feature change    | 5.0.1             | 5.0.200           | Runtime patch didn't change. New SDK feature bumps first digit in SDK patch.        |
| Runtime patch         | 5.0.2             | 5.0.200           | Runtime patch bumps Runtime patch number. SDK doesn't change.                       |

From the preceding table you can see several policies:

- The Runtime and SDK share major and minor versions. The first two numbers for a given SDK and runtime should match. All the preceding examples are part of the .NET 5.0 release stream.
- The patch version of the runtime revs only when the runtime is updated. The SDK patch number doesn't update for a runtime patch.
- The patch version of the SDK updates only when the SDK is updated. It's possible that a runtime patch doesn't require an SDK patch.

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
  
  Major releases happen once a year, even-numbered versions are long-term supported (LTS) releases. The first LTS release using this versioning scheme is .NET 6. The latest non-LTS version is .NET 5.
  
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

## .NET runtime compatibility

The .NET runtime maintains a high level of compatibility between versions. .NET apps should, by and large, continue to work after upgrading to a new major .NET runtime version.

Each major .NET runtime version contains intentional, carefully vetted, and documented [breaking changes](../compatibility/breaking-changes.md). The documented breaking changes aren't the only source of issues that can affect an app after upgrade. For example, a performance improvement in the .NET runtime (that's not considered a breaking change) can expose latent app threading bugs that cause the app to not work on that version. It's expected for large apps to require a few fixes after upgrading to a new .NET runtime major version.

By default, .NET apps are configured to run on a given .NET runtime major version, so recompilation is highly recommended to upgrade the app to run on a new .NET runtime major version. Then retest the app after upgrading to identify any issues.

Suppose upgrading via app recompilation isn't feasible. In that case, the .NET runtime provides [additional settings](selection.md#control-roll-forward-behavior) to enable an app to run on a higher major .NET runtime version than the version it was compiled for. These settings don't change the risks involved in upgrading the app to a higher major .NET runtime version, and it's still required to retest the app post upgrade.

The .NET runtime supports loading libraries that target older .NET runtime versions. An app that's upgraded to a newer major .NET runtime version can reference libraries and NuGet packages that target older .NET runtime versions. It's unnecessary to simultaneously upgrade the target runtime version of all libraries and NuGet packages referenced by the app.

## See also

- [Breaking changes in .NET](../compatibility/breaking-changes.md)
- [Target frameworks](../../standard/frameworks.md)
- [.NET distribution packaging](../distribution-packaging.md)
- [.NET Support Lifecycle Fact Sheet](https://dotnet.microsoft.com/platform/support/policy)
- [Docker images for .NET](https://hub.docker.com/_/microsoft-dotnet/)
