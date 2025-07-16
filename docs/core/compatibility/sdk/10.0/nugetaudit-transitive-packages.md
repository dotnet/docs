---
title: "Breaking change: NuGetAuditMode default changed when targeting .NET 10"
description: "Learn about the breaking change in .NET 10 where NuGetAuditMode defaults to 'all' for projects targeting .NET 10."
ms.date: 07/16/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47383
---
# NuGetAuditMode default changed when targeting .NET 10

When a project targets .NET 10, NuGetAuditMode now defaults to `all`, causing NuGet to report both direct packages and their dependencies (transitive packages) with known vulnerabilities during restore.

## Version introduced

.NET 10 Preview 3

## Previous behavior

Since [NuGetAudit](../8.0/dotnet-restore-audit.md) was introduced in .NET 8, NuGetAuditMode defaulted to `direct`, so only packages referenced directly were scanned for known vulnerabilities, not their dependencies. 

There was an exception in the .NET 9.0.100 SDK where NuGetAuditMode defaulted to `all` for all projects, but this was reverted back to `direct` in the .NET 9.0.101 SDK.

## New behavior

When projects target .NET 10 or higher, `NuGetAuditMode` defaults to `all` if it hasn't been explicitly set. This means that *transitive packages* (dependencies of packages your project directly references) with known vulnerabilities now cause warnings to be reported.

Projects where all target frameworks are .NET 9 or earlier, or other frameworks like .NET Standard or .NET Framework, retain the previous default value of `direct`.

If your project treats warnings as errors, this behavior can cause restore failures.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To improve the security of applications built with .NET, it's important to help developers understand when a package they might be deploying to production has a known security vulnerability. Transitive packages (dependencies of direct packages) can lead to security vulnerabilities even if the project being developed doesn't use that package directly.

.NET 10 includes a new feature, [PrunePackageReference](nu1510-pruned-references.md), which allows NuGet to ignore System.* packages that previously caused false positive audit warnings.

## Recommended action

### Address security vulnerabilities

The preferred approach is to update packages so that versions with known vulnerabilities are no longer used. For detailed guidance on responding to audit warnings, see the [NuGetAudit 2.0 blog post](https://devblogs.microsoft.com/nuget/nugetaudit-2-0-elevating-security-and-trust-in-package-management/#recommended-way-to-resolve-warnings).

1. Use tools such as `dotnet nuget why` to find the top-level package that caused the transitive package with the known vulnerability to be included.
1. Try to upgrade the top-level package to see if the transitive vulnerability is resolved.
1. If not, promote the transitive package to a top-level package by adding a `PackageReference` for it, and upgrade it to a newer version.

### Suppress specific advisories

If you've analyzed a security advisory and determined that your project isn't susceptible, you can suppress specific advisories. This approach allows you to continue receiving notifications for new security advisories in the future.

```xml
<ItemGroup>
    <NuGetAuditSuppress Include="url" />
</ItemGroup>
```

where `url` is the URL reported in NuGet's warning message.

### Configure audit behavior

#### Revert to previous behavior

If you want to only receive warnings for direct package references with known vulnerabilities, set `NuGetAuditMode` to `direct`:

```xml
<PropertyGroup>
  <NuGetAuditMode>direct</NuGetAuditMode>
</PropertyGroup>
```

**Note**: This only hides the warning. Your project will continue to have a transitive dependency on packages with known security vulnerabilities.

#### Prevent audit warnings from breaking builds

To prevent audit warnings from being treated as errors, even when using `TreatWarningsAsErrors`, use:

```xml
<PropertyGroup>
  <WarningsNotAsErrors>NU1901;NU1902;NU1903;NU1904;$(WarningsNotAsErrors)</WarningsNotAsErrors>
</PropertyGroup>
```

## Affected APIs

None.

## See also

- [Audit for security vulnerabilities (`dotnet restore`)](../../../tools/dotnet-restore.md#audit-for-security-vulnerabilities)
- [Auditing package dependencies for security vulnerabilities](/nuget/concepts/auditing-packages)
- [NuGetAudit 2.0: Elevating Security and Trust in Package Management](https://devblogs.microsoft.com/nuget/nugetaudit-2-0-elevating-security-and-trust-in-package-management/)
- [`dotnet restore` produces security vulnerability warnings (.NET 8)](../8.0/dotnet-restore-audit.md)
