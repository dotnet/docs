---
title: NuGet package compatibility rules
description: Learn about the compatibility rules that NuGet packages must follow to ensure consumers can reliably update and use packages across .NET frameworks and versions.
ms.date: 03/31/2026
---

# NuGet package compatibility rules

NuGet packages are the primary distribution mechanism for .NET libraries. To ensure that consumers can reliably update packages and use them across frameworks and versions, package authors must follow a set of compatibility rules. These rules ensure that newer versions of a package can replace older versions without breaking applications at build time or run time.

This article describes the compatibility rules that apply to NuGet packages, with specific attention to framework compatibility, assembly compatibility, dependency compatibility, and assembly versioning.

## Compatible frameworks must provide compatible assemblies

NuGet packages can target multiple frameworks by including assemblies for different [target framework monikers (TFMs)](../frameworks.md). When a package supports multiple frameworks, there is an implied compatibility relationship between those frameworks. Specifically, newer or more specific frameworks are *compatible with* older or more general ones. For example:

- `net8.0` is compatible with `netstandard2.0`
- `net462` (.NET Framework 4.6.2) is compatible with `netstandard2.0`
- `net9.0` is compatible with `net8.0`

When a consumer's project targets a framework that isn't directly included in a package, NuGet selects the *best matching* compatible framework from the package. For example, a `net8.0` application consuming a package that contains only a `netstandard2.0` assembly will use that `netstandard2.0` assembly. If the package also contains a `net8.0` assembly, that more specific assembly is used instead.

Because NuGet can select different assemblies for different consumers, the assemblies provided for compatible frameworks must themselves be compatible. The `netstandard2.0` assembly and the `net8.0` assembly in the same package must expose the same (or a superset of) API, and must not differ in behavior in breaking ways.

For more information about framework compatibility, see [.NET Standard](../net-standard.md) and [Target frameworks in SDK-style projects](../frameworks.md).

### Validate compatible frameworks in your packages

The [Package Validation](../../fundamentals/apicompat/package-validation/overview.md) feature in the .NET SDK automatically validates that assemblies for compatible frameworks within a package are consistent. Enable it by adding the following property to your project file:

```xml
<PropertyGroup>
  <EnablePackageValidation>true</EnablePackageValidation>
</PropertyGroup>
```

The [compatible framework in package validator](../../fundamentals/apicompat/package-validation/compatible-framework-in-package-validator.md) checks, for example, that your `netstandard2.0` assembly and `net8.0` assembly don't have API inconsistencies.

## Assembly compatibility rules

These rules apply whenever one assembly must be compatible with another&mdash;whether it's a newer version of the same assembly replacing a previous version, or an assembly for a more specific framework (such as `net8.0`) that can be substituted for a more general one (such as `netstandard2.0`) within the same package.

For an assembly to be considered *compatible*, it must meet two requirements:

1. **Equal or higher assembly version.** The [assembly version](../assembly/versioning.md) (`AssemblyVersionAttribute`) must be greater than or equal to the previous version. Decreasing an assembly version is never an acceptable change&mdash;it breaks the runtime's ability to load the correct assembly and can cause `FileLoadException` errors at run time.

2. **No breaking API changes.** The assembly must not remove or change public API in any binary-breaking way. This means no removal of public types or members, no changes to method signatures, and no other changes that would cause a `MissingMethodException`, `MissingMemberException`, or `TypeLoadException` at run time.

### Never decrease assembly versions

Decreasing an assembly version is never acceptable, even across major package versions. Assembly versions are used by the runtime to resolve which assembly to load. When a library is compiled against assembly version 2.0.0.0, the runtime requires that version or higher to be present. If a newer package ships with a lower assembly version, any library that was compiled against the higher version fails to load.

While it's technically possible to work around this with a binding redirect or an `AssemblyResolve` handler to redirect the higher version to the lower one, this is always a breaking change in practice. The higher assembly version exists because it shipped with newer API and bug fixes that consumers have come to depend on. Redirecting to an older assembly means those APIs and fixes are no longer present, leading to `MissingMethodException` or incorrect behavior at run time.

### Binary breaking changes

Binary breaking changes&mdash;changes that cause previously compiled code to fail at run time&mdash;may be permissible across major package versions, but authors should understand the ecosystem impact. Any library in the ecosystem that depends on your package also exposes your API surface transitively. A binary breaking change in your package can break consumers of those downstream libraries, even if they don't directly reference your package.

The .NET libraries maintain a [very high bar for binary compatibility](../../core/compatibility/library-change-rules.md). For a detailed list of what constitutes a breaking change, see the [breaking change rules](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-change-rules.md) in the dotnet/runtime repository.

> [!TIP]
> Use [Package Validation](../../fundamentals/apicompat/package-validation/overview.md) with a baseline version to automatically detect binary breaking changes between releases:
>
> ```xml
> <PropertyGroup>
>   <EnablePackageValidation>true</EnablePackageValidation>
>   <PackageValidationBaselineVersion>1.0.0</PackageValidationBaselineVersion>
> </PropertyGroup>
> ```
>
> You can also use the [Microsoft.DotNet.ApiCompat.Tool](../../fundamentals/apicompat/global-tool.md) to compare assemblies or packages outside of the build process.

## Dependency compatibility rules

The dependencies declared by a NuGet package are part of its public contract. When a consumer installs your package, they also get all of its dependencies. Dropping a dependency in a newer version of your package can break consumers who rely on types from that dependency being present at run time.

### Avoid dropping dependencies in compatible versions

Packages should avoid removing dependencies in compatible framework versions or within the same major version series. Dropping a dependency can cause run-time failures for consumers who rely on types from that dependency, even if your own code no longer uses it directly.

Dropping a dependency is more reasonable across major version boundaries. Unlike binary breaking changes, a dropped dependency can be mitigated by the consuming application without recompiling intermediate libraries&mdash;the application can simply add a direct reference to the removed dependency.

### Polyfill package dependencies (Microsoft.BCL.\*)

One place where the .NET libraries intentionally drop dependencies is for *polyfill packages* such as `Microsoft.Bcl.AsyncInterfaces`, `Microsoft.Bcl.HashCode`, and `Microsoft.Bcl.Memory`. These packages provide functionality on older frameworks (such as .NET Standard 2.0 and .NET Framework) that is built into newer .NET versions.

For packages that target multiple frameworks, it's appropriate to include the polyfill dependency only for older TFMs and drop it for the TFMs where the functionality is provided by the framework itself. For example:

```xml
<ItemGroup Condition="'$(TargetFramework)' == 'netstandard2.0'">
  <PackageReference Include="Microsoft.Bcl.AsyncInterfaces" Version="8.0.0" />
</ItemGroup>
<!-- No dependency needed for net8.0, where IAsyncEnumerable is built-in -->
```

We recommend that library authors consuming polyfill packages follow the same pattern to avoid unnecessary assemblies in applications targeting the latest frameworks.

> [!NOTE]
> When a polyfill dependency is dropped for a newer TFM, make sure that the package includes a TFM-specific assembly for that framework. Otherwise, consumers on the newer framework may resolve the `netstandard2.0` assembly, which still expects the polyfill at run time. Multi-targeting with explicit TFM-specific assets avoids this problem.

## Assembly versioning

Assembly versions are distinct from [NuGet package versions](versioning.md). While package versions follow [Semantic Versioning](https://semver.org) (SemVer) conventions, assembly versions are four-part version numbers (`Major.Minor.Build.Revision`) used by the .NET runtime to resolve and load assemblies.

### Why assembly versions matter

The assembly version is embedded in compiled references. When library A is compiled against version 2.0.0.0 of library B, the runtime requires that library B's assembly version be 2.0.0.0 or higher at run time. This binding behavior is what makes assembly version changes important for package compatibility.

### Assembly versioning on .NET Framework

On .NET Framework, assembly versioning has additional implications due to the runtime's loading behavior:

- **Global Assembly Cache (GAC) preference.** The .NET Framework loader always prefers an assembly from the [GAC](/dotnet/framework/app-domains/gac) over an app-local copy. Packages that do not change their assembly version across releases cannot guarantee that serviced (patched) versions will be loaded on .NET Framework, because the GAC may contain an older copy with the same assembly version.

- **Binding redirects are required.** The .NET Framework loader requires [binding redirects](../../framework/configure-apps/redirect-assembly-versions.md) to unify different assembly versions. When an application consumes multiple packages that depend on different versions of a shared library, binding redirects tell the runtime to load a single (higher) version for all callers.

Applications consuming NuGet packages on .NET Framework must account for binding redirects to unify the versions of transitive dependencies. It is never safe to assume that binding redirects won't be required&mdash;doing so makes an application unable to update a mid-stack library in the event of a critical security update.

> [!TIP]
> Enable [`<AutoGenerateBindingRedirects>`](../../framework/configure-apps/redirect-assembly-versions.md) in your application project to have the build system automatically generate the necessary binding redirects.

### Typical versioning policy

For most packages, the assembly version changes with each release. This is essential to ensure loading of patched binaries, particularly on .NET Framework where the GAC and binding redirect behavior require version changes for correct assembly resolution.

## Assembly versioning for .NET libraries that overlap with shared frameworks

Some .NET packages ship assemblies that also exist in .NET [shared frameworks](../../core/deploying/index.md). Examples include packages like `System.Text.Json` and `System.Collections.Immutable`, among others. The specific set of packages that overlap with a given shared framework varies by release and is not a fixed or documented list. These packages are unique: they provide API that is also available in .NET without a package reference, but they allow applications targeting older frameworks to use newer API.

### How conflict resolution and package pruning work

To support these overlapping packages, the .NET SDK and runtime include several features:

- **Conflict resolution.** Conflict resolution occurs at two levels, both following the same principle: prefer the newer version, and prefer the framework's copy when versions are equal.
  - At **build time**, the SDK's `ResolvePackageFileConflicts` task compares assemblies from packages against those provided by the shared framework and selects the winner for the application's output.
  - At **run time**, the .NET host performs the same logic when probing for assemblies, as described in the [assembly conflict resolution](https://github.com/dotnet/runtime/blob/main/docs/design/features/assembly-conflict-resolution.md) design document.

- **NuGet package pruning.** The SDK can [prune packages](../../fundamentals/package-validation/overview.md) from the dependency graph when the shared framework already provides the same functionality. This was introduced as an opt-in feature in the .NET 9 SDK and is enabled by default in the .NET 10 SDK for projects targeting .NET 10. Package pruning reduces restore time, shrinks dependency graphs, and eliminates false positives from vulnerability scanners like [NuGet Audit](https://learn.microsoft.com/nuget/concepts/auditing-packages). For more information, see [NuGet Warning NU1510](https://learn.microsoft.com/nuget/reference/errors-and-warnings/nu1510).

These features allow packages to be used when needed on older frameworks and transparently replaced by the shared framework on newer ones.

### Assembly version policy for shared framework packages

Packages that overlap with .NET shared frameworks follow a special assembly versioning policy:

- **The assembly version is held constant at `Major.Minor.0.0`** for a given major/minor release. For example, all 8.0.x versions of `System.Text.Json` ship with assembly version `8.0.0.0`. This ensures that the package's assembly can be transparently replaced by the shared framework's copy of the same major/minor version.

- **.NET Standard assemblies** in these packages follow the same rule, since they may run on any compatible framework (including .NET itself).

- **.NET Framework assemblies** in these packages are the exception&mdash;they *do* increment their assembly version with each servicing release. This is necessary because .NET Framework's GAC and binding redirect behavior requires version changes to guarantee that patched assemblies are loaded. As a result, the .NET Framework assemblies in these packages are the only ones whose assembly version changes across servicing releases.

This policy ensures that:

1. Applications targeting modern .NET get the shared framework's copy of the assembly seamlessly.
2. Applications targeting .NET Framework get properly serviced assemblies with correct binding behavior.
3. Libraries targeting .NET Standard work correctly on both platforms.

### Packages without the shared framework constraint

Packages that do not overlap with a shared framework are free to increment their assembly version with every release. This is the typical and recommended pattern, as it ensures that patched binaries are always loaded correctly regardless of the target framework.

## Summary of rules

| Rule | Requirement |
|------|------------|
| Compatible frameworks must provide compatible assemblies | Assemblies for more specific TFMs must be API-compatible with assemblies for more general TFMs in the same package. |
| Assembly versions must not decrease | Never ship a newer package version with a lower assembly version than a previous release. |
| API must not break in compatible versions | Don't remove or change public API in binary-breaking ways within compatible versions. Major versions have more latitude. |
| Dependencies should not be dropped in compatible versions | Removing a package dependency can break consumers. Dropping dependencies is more acceptable across major versions. |
| Polyfill dependencies should be dropped for inbox frameworks | When a polyfill (Microsoft.BCL.\*) provides functionality that is built into the target framework, the dependency should be omitted for that TFM. |
| Shared framework packages hold assembly version at Major.Minor.0.0 | Packages overlapping with .NET shared frameworks keep assembly version constant within a release series, except for .NET Framework TFMs. |

## See also

- [Versioning and .NET libraries](versioning.md)
- [Breaking changes and .NET libraries](breaking-changes.md)
- [Dependencies and .NET libraries](dependencies.md)
- [.NET Package Validation overview](../../fundamentals/apicompat/package-validation/overview.md)
- [Microsoft.DotNet.ApiCompat.Tool](../../fundamentals/apicompat/global-tool.md)
- [.NET Standard](../net-standard.md)
- [Target frameworks in SDK-style projects](../frameworks.md)
- [Breaking change rules (dotnet/runtime)](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-change-rules.md)
- [Assembly conflict resolution design](https://github.com/dotnet/runtime/blob/main/docs/design/features/assembly-conflict-resolution.md)
- [Redirecting assembly versions (.NET Framework)](../../framework/configure-apps/redirect-assembly-versions.md)
