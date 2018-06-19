## Versioning scheme details

.NET Core is made of the following parts:

- A host: either *dotnet.exe* for framework-dependent applications, or *\<appname>.exe* for self-contained applications.
- An SDK (the set of tools necessary on a developer's machine, but not in production).
- A runtime.
- A shared framework implementation, distributed as packages. Each package is versioned independently, particularly for patch versioning.
- Optionally, a set of [metapackages](../packages.md) that reference fine-grained packages as a versioned unit. Metapackages can be versioned separately from packages.

.NET Core also includes a set of target frameworks (for example, `netstandard` or `netcoreapp`) that represent a progressively larger API set, as version numbers are incremented.

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

There are commits and pull requests on .NET Core repos on GitHub on a daily basis, resulting in new builds of many libraries. It isn't practical to create new public versions of .NET Core for every change. Instead, changes are aggregated over an undetermined period of time (for example, weeks or months) before making a new public stable .NET Core version.

A new version of .NET Core could mean several things:

- New versions of packages and metapackages.
- New versions of various frameworks, assuming the addition of new APIs.
- New version of the .NET Core distribution.