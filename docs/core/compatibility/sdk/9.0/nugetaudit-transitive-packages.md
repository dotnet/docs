---
title: "Breaking change: 'dotnet restore' audits transitive packages"
description: Learn about a breaking change in the .NET 9 SDK where 'dotnet restore' also produces security vulnerability warnings for transitive packages by default.
ms.date: 11/14/2024
---
# 'dotnet restore' audits transitive packages

The [`dotnet restore` command](../../../tools/dotnet-restore.md), which restores the dependencies and tools of a project, now produces security vulnerability warnings for transitive packages by default.

## Previous behavior

In .NET 8, [NuGetAudit](../8.0/dotnet-restore-audit.md) was introduced to emit warnings for packages with known security vulnerabilities. By default, only direct package references were audited, however, it was possible to change the `NuGetAuditMode` property to include all packages.

## New behavior

Starting in .NET 9, `NuGetAuditMode` defaults to `all` if it hasn't been explicitly set. This setting means that *transitive packages* (dependencies of packages your project directly references) with known vulnerabilities now cause warnings to be reported.
If your project treats warnings as errors, this behavior can cause restore failures.

## Version introduced

.NET 9 Preview 6

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Packages with known vulnerabilities might cause your app to be exploitable, even if your project does not directly reference or use the vulnerable package.
New features in .NET 9 also make it easier to investigate the package graph and to suppress advisories that aren't relevant to how your app uses the vulnerable package.

## Recommended action

- To explicitly reduce the probability of this change breaking your build due to warnings, you can consider your usage of `<TreatWarningsAsErrors>` and use `<WarningsNotAsErrors>NU1901;NU1902;NU1903;NU1904</WarningsNotAsErrors>` to ensure known security vulnerabilities are still allowed in your environment.

- Use tools such as `dotnet nuget why` to find the top-level package that caused the transitive package with the known vulnerability to be included, and try to upgrade it to see if the transitive vulnerability goes away. If not, promote the transitive package to a top-level package by adding a `PackageReference` for it, and upgrade it to a newer version.

- If you want to suppress a specific advisory, you can add `<NuGetAuditSuppress Include="url" />` item to your project file, where `url` is the URL reported in NuGet's warning message.

  ```xml
  <ItemGroup>
      <NuGetAuditSuppress Include="url" />
  </ItemGroup>
  ```

- If you want to only be warned of direct package references with known vulnerabilities, you can set `<NuGetAuditMode>` to `direct` in your project file.

  ```xml
  <PropertyGroup>
    <NuGetAuditMode>direct</NuGetAuditMode>
  </PropertyGroup>
  ```

## See also

- [Audit for security vulnerabilities (`dotnet restore`)](../../../tools/dotnet-restore.md#audit-for-security-vulnerabilities)
- [Auditing package dependencies for security vulnerabilities](/nuget/concepts/auditing-packages)
- [NuGetAudit 2.0: Elevating Security and Trust in Package Management](https://devblogs.microsoft.com/nuget/nugetaudit-2-0-elevating-security-and-trust-in-package-management/)
