---
title: NuGet package compatibility rules
description: Learn about the compatibility rules that NuGet packages must follow to ensure consumers can reliably update and use packages across .NET frameworks and versions.
ms.date: 03/31/2026
ai-usage: ai-assisted
---

# NuGet package compatibility rules

NuGet packages are the primary distribution mechanism for .NET libraries. To ensure that consumers can reliably update packages and use them across frameworks and versions, package authors must follow a set of compatibility rules. These rules ensure that newer versions of a package can replace older versions without breaking applications at build time or runtime.

This article describes the compatibility rules that apply to NuGet packages, with specific attention to framework compatibility, assembly compatibility, dependency compatibility, and assembly versioning.

## Compatible frameworks must provide compatible assemblies

NuGet packages can target multiple frameworks by including assemblies for different [target framework monikers (TFMs)](../frameworks.md). When a package supports multiple frameworks, there is an implied compatibility relationship between those frameworks. Specifically, newer or more specific frameworks are *compatible with* older or more general ones. For example:

- `net8.0` is compatible with `netstandard2.0`
- `net462` (.NET Framework 4.6.2) is compatible with `netstandard2.0`
- `net9.0` is compatible with `net8.0`

When a consumer's project targets a framework that isn't directly included in a package, NuGet selects the *best matching* compatible framework from the package. For details on how this selection works, see [NuGet Target Frameworks](/nuget/reference/target-frameworks). For example, a `net8.0` application consuming a package that contains only a `netstandard2.0` assembly will use that `netstandard2.0` assembly. If the package also contains a `net8.0` assembly, that more specific assembly is used instead.

This framework selection has a direct impact on compatibility. When another library compiles against your package for a particular target framework, that library depends on any compatible build of your package presenting the same (compatible) API surface at both compile time and runtime. If a consumer compiles against the `netstandard2.0` assembly but the application runs with the `net8.0` assembly (or vice versa), both assemblies must expose a compatible API surface. Otherwise, the consumer might encounter `MissingMethodException` or `TypeLoadException` at runtime.

✔️ DO ensure that assemblies for compatible frameworks within the same package expose the same (or a superset of) API surface.

✔️ CONSIDER enabling [Package Validation](../../fundamentals/apicompat/package-validation/overview.md) to automatically check for API inconsistencies across TFMs:

```xml
<PropertyGroup>
  <EnablePackageValidation>true</EnablePackageValidation>
</PropertyGroup>
```

> The [compatible framework in package validator](../../fundamentals/apicompat/package-validation/compatible-framework-in-package-validator.md) checks, for example, that your `netstandard2.0` assembly and `net8.0` assembly don't have API inconsistencies.

For more information about framework compatibility, see [.NET Standard](../net-standard.md) and [Target frameworks in SDK-style projects](../frameworks.md).

## Assembly compatibility rules

These rules apply whenever one assembly must be compatible with another&mdash;whether it's a newer version of the same assembly replacing a previous version, or an assembly for a more specific framework (such as `net8.0`) that can be substituted for a more general one (such as `netstandard2.0`) within the same package.

For an assembly to be considered *compatible*, it must meet two requirements:

1. **Equal or higher assembly version.** The [assembly version](../assembly/versioning.md) (`AssemblyVersionAttribute`) must be greater than or equal to the previous version.

1. **No breaking API changes.** The assembly must not remove or change public API in any binary-breaking way. This means no removal of public types or members, no changes to method signatures, and no other changes that would cause a `MissingMethodException`, `MissingMemberException`, or `TypeLoadException` at runtime.

### Assembly versions

❌ DO NOT decrease the assembly version of a package across releases.

> Decreasing an assembly version breaks the runtime's ability to load the correct assembly and can cause `FileLoadException` errors at runtime. Assembly versions are used by the runtime to resolve which assembly to load. When a library is compiled against assembly version 2.0.0.0, the runtime requires that version or higher to be present. If a newer package ships with a lower assembly version, any library that was compiled against the higher version fails to load.
>
> While it's technically possible to work around this with a binding redirect or an `AssemblyResolve` handler to redirect the higher version to the lower one, this is always a breaking change in practice. The higher assembly version exists because it shipped with newer API and bug fixes that consumers have come to depend on. Redirecting to an older assembly means those APIs and fixes are no longer present, leading to `MissingMethodException` or incorrect behavior at runtime.

### Binary breaking changes

❌ AVOID binary breaking changes to your package's public API.

> Binary breaking changes&mdash;changes that cause previously compiled code to fail at runtime&mdash;might be permissible across major package versions, but authors should understand the ecosystem impact. Any library in the ecosystem that depends on your package also exposes your API surface transitively. A binary breaking change in your package can break consumers of those downstream libraries, even if they don't directly reference your package.

The .NET libraries maintain a [very high bar for binary compatibility](../../core/compatibility/library-change-rules.md). For a detailed list of what constitutes a breaking change, see the [breaking change rules](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-change-rules.md) in the dotnet/runtime repository.

✔️ CONSIDER using [Package Validation](../../fundamentals/apicompat/package-validation/overview.md) with a baseline version to automatically detect binary breaking changes between releases:

```xml
<PropertyGroup>
  <EnablePackageValidation>true</EnablePackageValidation>
  <PackageValidationBaselineVersion>1.0.0</PackageValidationBaselineVersion>
</PropertyGroup>
```

> You can also use the [Microsoft.DotNet.ApiCompat.Tool](../../fundamentals/apicompat/global-tool.md) to compare assemblies or packages outside of the build process.

## Dependency compatibility rules

The dependencies declared by a NuGet package are part of its public contract. When a consumer installs your package, they also get all of its dependencies. Dropping a dependency in a newer version of your package can break consumers who rely on types from that dependency being present at runtime.

❌ AVOID removing package dependencies between compatible versions of the package or between compatible target frameworks within the same package.

> Dropping a dependency can cause runtime failures for consumers who rely on types from that dependency, even if your own code no longer uses it directly. Dropping a dependency is more reasonable across major version boundaries. Unlike binary breaking changes, a dropped dependency can be mitigated by the consuming application without recompiling intermediate libraries&mdash;the application can simply add a direct reference to the removed dependency.

### Polyfill package dependencies (Microsoft.Bcl.\*)

One place where the .NET libraries intentionally drop dependencies is for *polyfill packages* such as `Microsoft.Bcl.AsyncInterfaces`, `Microsoft.Bcl.HashCode`, and `Microsoft.Bcl.Memory`. These packages provide functionality on older frameworks (such as .NET Standard 2.0 and .NET Framework) that is built into newer .NET versions.

✔️ CONSIDER including polyfill dependencies only for older TFMs and omitting them for TFMs where the functionality is provided by the framework itself.

```xml
<ItemGroup Condition="'$(TargetFramework)' == 'netstandard2.0'">
  <PackageReference Include="Microsoft.Bcl.AsyncInterfaces" Version="8.0.0" />
</ItemGroup>
<!-- No dependency needed for net8.0, where IAsyncEnumerable is built-in -->
```

> When a polyfill dependency is dropped for a newer TFM, make sure that the package includes a TFM-specific assembly for that framework. Otherwise, consumers on the newer framework might resolve the `netstandard2.0` assembly, which still expects the polyfill at runtime. Multi-targeting with explicit TFM-specific assets avoids this problem.

## Assembly versioning

Assembly versions are distinct from [NuGet package versions](versioning.md). While package versions follow [Semantic Versioning](https://semver.org) (SemVer) conventions, assembly versions are four-part version numbers (`Major.Minor.Build.Revision`) used by the .NET runtime to resolve and load assemblies.

The assembly version is embedded in compiled references. When library A is compiled against version 2.0.0.0 of library B, the runtime requires that library B's assembly version be 2.0.0.0 or higher at runtime. This binding behavior is what makes assembly version changes important for package compatibility.

✔️ DO change the assembly version with each release of your package.

> This is essential to ensure loading of patched binaries, particularly on .NET Framework where the GAC and binding redirect behavior require version changes for correct assembly resolution.

### Assembly versioning on .NET Framework

On .NET Framework, assembly versioning has additional implications due to the runtime's loading behavior:

- **Global Assembly Cache (GAC) preference.** The .NET Framework loader always prefers an assembly from the [GAC](/dotnet/framework/app-domains/gac) over an app-local copy. Packages that do not change their assembly version across releases cannot guarantee that serviced (patched) versions will be loaded on .NET Framework, because the GAC might contain an older copy with the same assembly version.

- **Binding redirects are required.** The .NET Framework loader requires [binding redirects](../../framework/configure-apps/redirect-assembly-versions.md) to unify different assembly versions. When an application consumes multiple packages that depend on different versions of a shared library, binding redirects tell the runtime to load a single (higher) version for all callers.

✔️ DO design your .NET Framework applications to support binding redirects for any assembly from NuGet packages.

> Without binding redirects, an application might be unable to update a mid-stack library in the event of a critical security update. Enable [`<AutoGenerateBindingRedirects>`](../../framework/configure-apps/redirect-assembly-versions.md) in your application project to have the build system automatically generate the necessary binding redirects.

## Assembly versioning for .NET libraries that overlap with shared frameworks

Some .NET packages ship assemblies that also exist in .NET [shared frameworks](../../core/deploying/index.md). Examples include packages like `System.Text.Json` and `System.Collections.Immutable`, among others. The specific set of packages that overlap with a given shared framework varies by release and is not a fixed or documented list. These packages are unique: they provide APIs that are also available in .NET without a package reference, but they allow applications targeting older frameworks to use newer APIs.

### How conflict resolution and package pruning work

To support these overlapping packages, the .NET SDK and runtime include several features:

- **Conflict resolution.** Conflict resolution occurs at two levels, both following the same principle: prefer the newer version, and prefer the framework's copy when versions are equal.
  - At **build time**, the SDK's `ResolvePackageFileConflicts` task compares assemblies from packages against those provided by the shared framework and selects the winner for the application's output.
  - At **runtime**, the .NET host performs the same logic when probing for assemblies, as described in the [assembly conflict resolution](https://github.com/dotnet/runtime/blob/main/docs/design/features/assembly-conflict-resolution.md) design document.

- **NuGet package pruning.** The SDK can [prune packages](/nuget/consume-packages/package-references-in-project-files#prunepackagereference) from the dependency graph when the shared framework already provides the same functionality. This was introduced as an opt-in feature in the .NET 9 SDK and is enabled by default in the .NET 10 SDK for projects targeting .NET 10. Package pruning reduces restore time, shrinks dependency graphs, and eliminates false positives from vulnerability scanners like [NuGet Audit](/nuget/concepts/auditing-packages).

These features allow packages to be used when needed on older frameworks and transparently replaced by the shared framework on newer ones.

### Assembly version policy for shared framework packages

Packages that overlap with .NET shared frameworks follow a special assembly versioning policy:

- **The assembly version is held constant at `Major.Minor.0.0`** for a given major/minor release. For example, all 8.0.x versions of `System.Text.Json` ship with assembly version `8.0.0.0`. This ensures that the package's assembly can be transparently replaced by the shared framework's copy of the same major/minor version.

- **.NET Standard assemblies** in these packages follow the same rule, since they might run on any compatible framework (including .NET itself).

- **.NET Framework assemblies** in these packages are the exception&mdash;they *do* increment their assembly version with each servicing release. This is necessary because .NET Framework's GAC and binding redirect behavior requires version changes to guarantee that patched assemblies are loaded. As a result, the .NET Framework assemblies in these packages are the only ones whose assembly version changes across servicing releases.

#### Example: System.Text.Json 8.0.5

The following table shows the assembly versions inside the `System.Text.Json` 8.0.5 NuGet package. Notice that the `net462` assembly version is `8.0.0.5`, while all other TFMs remain at `8.0.0.0`:

| TFM | Assembly version |
|-----|-----------------|
| `net462` | 8.0.0.5 |
| `net6.0` | 8.0.0.0 |
| `net7.0` | 8.0.0.0 |
| `net8.0` | 8.0.0.0 |
| `netstandard2.0` | 8.0.0.0 |

This is intentional. The `netstandard2.0` assembly version is *lower* than the `net462` assembly version in the same package. This is safe because these two assemblies never substitute for each other at runtime&mdash;NuGet selects the `net462` assembly for .NET Framework projects and the `netstandard2.0` assembly for other compatible frameworks.

The `net462` assembly must increment because .NET Framework applications need binding redirects to unify callers onto the serviced version, and the GAC requires a version change to prefer the app-local copy. The `net6.0`, `net7.0`, and `net8.0` assemblies stay at `8.0.0.0` so they can be transparently replaced by the shared framework's copy. The `netstandard2.0` assembly also stays at `8.0.0.0` because it might run on modern .NET, where the same conflict resolution and pruning behavior applies.

> [!NOTE]
> Applications on .NET Framework that consume these packages will have binding redirects automatically generated when [`<AutoGenerateBindingRedirects>`](../../framework/configure-apps/redirect-assembly-versions.md) is enabled. This is expected and required for correct servicing behavior.

This policy ensures that:

- Applications targeting modern .NET get the shared framework's copy of the assembly seamlessly.
- Applications targeting .NET Framework get properly serviced assemblies with correct binding behavior.
- Libraries targeting .NET Standard work correctly on both platforms.

### Packages without the shared framework constraint

Packages that don't overlap with a shared framework are free to increment their assembly version with every release. This is the typical and recommended pattern, as it ensures that patched binaries are always loaded correctly regardless of the target framework.

## Summary

The following recommendations summarize the compatibility rules for NuGet packages:

✔️ DO ensure that assemblies for compatible frameworks expose the same (or a superset of) API surface.

❌ DO NOT decrease the assembly version of a package across releases.

❌ AVOID binary breaking changes to your package's public API.

❌ AVOID removing package dependencies between compatible versions or compatible target frameworks.

✔️ CONSIDER omitting polyfill dependencies (Microsoft.Bcl.\*) for TFMs where the functionality is provided by the framework.

✔️ DO change the assembly version with each release, unless the package overlaps with a .NET shared framework.

✔️ DO design your .NET Framework applications to support binding redirects for any assembly from NuGet packages.

✔️ CONSIDER enabling [Package Validation](../../fundamentals/apicompat/package-validation/overview.md) with a baseline version to automatically detect breaking changes.

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
