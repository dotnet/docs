---
title: "Breaking change: 'dotnet restore' produces security vulnerability warnings for transitive packages"
description: Learn about a breaking change in the .NET 9 SDK where 'dotnet restore' produces security vulnerability warnings for transitive packages by default.
---
# 'dotnet restore' produces security vulnerability warnings for transitive packages

The [`dotnet restore` command](../../../tools/dotnet-restore.md), which restores the dependencies and tools of a project, now produces security vulnerability warnings for transitive packages by default.

## Previous behavior

In [.NET 8, we introduced NuGetAudit](../8.0/dotnet-restore-audit.md), which emits warnings for packages with known security vulnerabilities.
It was possible to change the `NuGetAuditMode` property to include all packages, but the default was to report only direct package references.

## New behavior

`NuGetAuditMode` now defaults to `all`, if it has not been explicitly set.
This means that transitive packages (dependencies of packages your project directly references) with known vulnerabilities will now cause warnings to be reported.
If your project treats errors as warnings, this can cause restore failures.

## Version introduced

.NET 9 Preview 6

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Packages with known vulnerabilities might cause your app to be exploitable, even if your project does not directly reference or use the vulnerable package.
New features in .NET 9 also make it easier to investigate the package graph, and suppress advisories that are not relevant to how your app uses the vulnerable package.

## Recommended action

- To explicitly reduce the probability of this breaking your build due to warnings, you can consider your usage of `<TreatWarningsAsErrors>` and use `<WarningsNotAsErrors>NU1901;NU1902;NU1903;NU1904</WarningsNotAsErrors>` to ensure known security vulnerabilities are still allowed in your environment.

- Use tools, such as `dotnet nuget why`, to find the top-level package that caused the transitive package with the known vulnerability to be included, and try to upgrade it to see if the transitive vulnerability goes away. If not, promote the transitive package to a top-level package by adding a `PackageReference` for it, and upgrade it to a newer version.

- If you want to suppress a specific advisory, you can add `<NuGetAuditSuppress Include="url" />` within an `<ItemGroup>`, where `url` is the URL reported in NuGet's warning message.

- If you want to only be warned of direct package references with known vulnerabilities, you can set `<NuGetAuditMode>` to `direct`.

## See also

- [Audit for security vulnerabilities (`dotnet restore`)](../../../tools/dotnet-restore.md#audit-for-security-vulnerabilities)
- [Auditing package dependencies for security vulnerabilities](/nuget/concepts/auditing-packages)
- [NuGetAudit 2.0: Elevating Security and Trust in Package Management](https://devblogs.microsoft.com/nuget/nugetaudit-2-0-elevating-security-and-trust-in-package-management/)
