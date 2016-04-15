.NET Core Versioning
==================== 

The .NET Core platform is built and versioned in layers. Each of these layers can be versioned separately for product agility and to accurately describe product changes. While there is significant versioning flexibility, there is a desire to version the platform as a unit to make the product easier to understand.

The product is somewhat unique, being described and delivered via a package manager (NuGet) as packages. While you typically acquire .NET Core as a standalone SDK, the SDK is largely a convenience experience over NuGet packages and therefore not distinct from packages. As a result, versioning is first and foremost in terms of packages and other versioning experiences follow from there.

Semantic Versioning
===================

.NET Core uses [Semantic Versioning (SemVer)](http://semver.org/), adopting the use of major.minor.patch versioning, using the various parts of the version number to describe the degree and kind of change. This applies to both meta packages (for example, `Microsoft.NETCore.App`) and regular packages (for example, `System.Collections`).

Versioning Form
---------------

MAJOR.MINOR.PATCH[-PRERELEASE.BUILDNUMBER]

Decision Tree
-------------

MAJOR when:
  - drop support for a platform
  - adopt a newer MAJOR version of an existing dependency 
  - turn a quirk off by default

MINOR when:
  - add public API surface area 
  - add new behavior
  - adopt a newer MINOR version of an existing dependency
  - introduce a new dependency 
  
PATCH when:
  - make bug fixes
  - add support for a newer platform
  - adopt a newer PATCH version of an existing dependency
  - any other change

When determining what to increment when there are multiple changes, choose the highest kind of change.

Versioning Scheme
=================

.NET Core can be defined as and will version in the following way:

- A runtime and framework implementation, distributed as packages. Each package is versioned independently.
- A set of metapackage packages that reference and make the fine-grained packages easier to reference and use together as a versioned unit. Each metapackage has its own versioning scheme.
- A set of target frameworks (for example, netstandard) that represent a progressively larger API set, described in a set of versioned snapshots.

Packages
--------

Library packages evolve and version independently. Packages that overlap with .NET Framework System.\* assemblies typically use 4.x versions, aligning with the .NET Framework 4.x versioning (a historical choice). Packages that do not overlap with the .NET Framework libraries (for example, System.Metadata) typically start at 1.0 and increment from there.

The lower-level packages (most of the ones with 4.x versions) are treated specially due to being at the base of the platform. Explanation:

- The lower-level packages will typically version as a set, since they have implementation-level dependencies between them. 
- APIs will typically only be added to the lower-level packages as part of a minor or major .NET Core release since adding APIs would require adding a new netstandard version, which currently requires an update to the NuGet client. As a result, these packages will only be updated with patch versions (no new APIs) between .NET Core releases.

Metapackages
-------------

Versioning for .NET Core metapackages is based on the target framework that they map to. The metapackages adopt the version number of the highest version (for example, netstandard1.5) of the target framework it maps to in its package closure. The patch version for the metapackage is used to represent updates to the metapackage to reference updated packages (that don't include a new target framework version). As a result, the metapackages are not strictly SemVer compliant because their versioning scheme doesn't represent the degree of change in the underlying packages, but only API level. 

There are two primary metapackages for .NET Core.

**NETStandard.Library**

- v1.5 as of .NET Core 1.0.
- Maps to `netstandard` target framework. 
- Describes the packages that are considered required for modern app development and that .NET platforms must implement to be considered a ".NET Standard" platform.

**Microsoft.NETCore.App**

- v1.0 as of .NET Core 1.0 (versions intended to match).
- Maps to `netcoreapp` target framework.
- Describes the packages in the .NET Core distribution.

Note: It is reasonable to reference the `Microsoft.NETCore.App` metapackage but use the netstandard framework. You will get access to all of the netstandard-compatible assets from those packages, which will be a subset of all the packages but more than are referenced via `NETStandard.Library`.


Target Frameworks
-----------------

Target Frameworks describe API surface area. As new APIs are added, the framework versions. A new version of a target framework comes into existence when a single package adds a folder with that version and NuGet is updated to respect that new version.

There is a two-way relationship between metapackages and frameworks. One can think of a given metapackage "filling out" the framework. Given that .NET Core is delivered via packages, the .NET Core target frameworks don't inherently define any surface area. It is the presence of the framework folders in the .NET Core packages that defines the APIs available for a given target framework (including version).

### netstandard

.NET Standard is a new concept that came out of the .NET Core project, but is logically separate. It is a a new framework that describes the API evolution of .NET for the lower-most APIs. One could consider it a standardized Base Class Library (BCL) for all .NET implementations. .NET Core implements this spec and is ".NET Standard compliant" at a particular version level. The .NET Standard will be updated regularly, based on new APIs being adding in .NET Standard compliant .NET implementations, such as .NET Core, .NET Framework and Mono. The version number of .NET Standard will not match any of the implementations.

The Target Framework Moniker (TFM) for .NET Standard is `netstandard`. At the release of .NET Core 1.0, there will be several `netstandard` versions, not just a 1.0 version. There was a strong desire to create a bridge between Portable Class Libraries (PCL) and .NET Standard.  To establish the compatibility bridge, .NET Standard was pre-versioned to overlap with existing .NET platforms in a compatible way with PCL. .NET Standard versions 1.0 through 1.4 represent the overlap. The .NET Core 1.0 platform implements all .NET Standard versions up to and including 1.5.

PCL and .NET Standard both enable binary sharing but define the applicable APIs in different ways. .NET Standard is the new binary code sharing mechanism going forward.

### netcoreapp

The `netcoreapp` framework represents the APIs available in the .NET Core distribution, which you can get via the .NET Core installer or a package manager. It matches the `Microsoft.NETCore.App` metapackage. .NET Core apps should use this framework, as should libraries that require significant funtionality beyond .NET Standard.

Other .NET platforms could support this framework, but are not expected to.

.NET Core and .NET Standard Versioning
======================================

The .NET Standard will not adopt the version numbers of .NET Core. They are logically separate. There are three major scenarios to consider.

The following sections discuss API additions. It assumes that the additions are to libraries that are referenced by `NETStandard.Library` metapackage.

Adding APIs to .NET Core
------------------------

When APIs are added to .NET Core, they will also be added .NET Standard. Both .NET Core and .NET Standard will version. The APIs might be added to other .NET implementations at the same time, such as the .NET Framework. 

Adding APIs to another .NET Implementation
------------------------------------------

When APIs are added to the .NET Framework (for example), but not .NET Core, the .NET Standard will version, but .NET Core will not.

The next time .NET Core ships, it will likely add those new APIs such that it now supports that higher .NET Standard version. It can also add additional APIs at the same time, which could create a new .NET Standard version.

.NET Core ships a Major Version
-------------------------------

When .NET Core ships a 2.0 version, the .NET Standard will be updated (assuming new APIs were added), but will stay with is 1.x versioning scheme. 

We intend to move to a 2.0 version of .NET Standard only for very significant changes. We have defined a non-exhaustive set of cases where we would move to `netstandard2.0`, none of which we intend to do:

- Drop APIs.
- Add a major new feature that is potentially breaking for existing runtimes (for example, array slices).
- Update the CLR metadata/assembly format.

Versioning in Practice
======================

There are commits and PRs on .NET Core repos on GitHub on a daily basis, resulting in new builds of many libraries. We don't want to create a new public version of .NET Core for every single change. Instead, we'll take changes for some loosely-defined period of time (for example, weeks or months) before making a new public stable .NET Core version.

A new version of .NET Core could mean several things:

- New versions of packages and metapackages.
- New versions of various target frameworks.
- New version of the .NET Core distribution.

Shipping Bug Fixes (AKA "patch release")
----------------------------------------

After shipping a .NET Core v1.0.0 stable version, patch-level changes (no new APIs) are be made to .NET Core libraries to fix bugs and improve performance and reliability. The various metapackages are updated to reference the updated .NET Core library packages. The metapackages are versioned as patch updates (x.y.z).

You can see patch updates demonstrated in the project.json examples below.

```
{
  "dependencies": {
    "Microsoft.NETCore.App": "1.0.1"
  },
  "frameworks": {
    "netcoreapp1.0": {}
  }
}
```

Target frameworks would not be updated. A new .NET Core distribution would be released with a matching version number to the `Microsoft.NETCore.App` metapackage.

Shipping new APIs (AKA "minor release")
---------------------------------------

After shipping a .NET Core v1.0.0 stable version, new APIs are added to .NET Core libraries to enable new scenarios. The various metapackages are updated to reference the updated .NET Core library packages. The metapackages are versioned as patch updates (x.y) to match the higher target framework version.

You can see minor updates demonstrated in the project.json examples below.

```
{
  "dependencies": {
    "Microsoft.NETCore.App": "1.1.0"
  },
  "frameworks": {
    "netcoreapp1.1": {}
  }
}
```

The various target frameworks would be updated to describe the new APIs. A new .NET Core distribution would be released with a matching version number to the `Microsoft.NETCore.App` metapackage.

Shipping major new Functionality (AKA "major release")
------------------------------------------------------

Given a .NET Core v1.y.z stable version, new APIs will be be added to .NET Core libraries to enable major new scenarios. The various metapackages will be updated to reference the updated .NET Core library packages. The `Microsoft.NETCore.App` metapackage will be versioned as major updates (x.). The `NETStandard.Library` metapackage will be versioned as a minor updates (x.y).

You can see a major update demonstrated in the project.json metapackage reference in the example below.

```
{
  "dependencies": {
    "Microsoft.NETCore.App": "2.0.0"
  },
  "frameworks": {
    "netcoreapp2.0": {}
  }
}
```

The various target frameworks would be updated to describe the new APIs. A new .NET Core distribution would be released with a matching version number to the `Microsoft.NETCore.App` metapackage.
