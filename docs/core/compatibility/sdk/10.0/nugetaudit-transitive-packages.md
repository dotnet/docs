---
title: "Breaking change: 'dotnet restore' audits transitive packages"
description: Learn about a breaking change in the .NET 10 SDK where 'dotnet restore' also produces security vulnerability warnings for transitive packages by default.
ms.date: 03/28/2025
---
# 'dotnet restore' audits transitive packages

The [`dotnet restore` command](../../../tools/dotnet-restore.md), which restores the dependencies and tools of a project, now produces security vulnerability warnings for transitive packages by default when the project targets .NET 10.

## Previous behavior

In .NET 8, [NuGetAudit](../8.0/dotnet-restore-audit.md) was introduced to emit warnings for packages with known security vulnerabilities. By default, only direct package references were audited, however, it was possible to change the `NuGetAuditMode` property to include all packages.

## New behavior

Starting in .NET 10, if the project targets .NET 10 or higher, then `NuGetAuditMode` defaults to `all` if it hasn't been explicitly set. This setting means that *transitive packages* (dependencies of packages your project directly references) with known vulnerabilities now cause warnings to be reported.
If your project treats warnings as errors, this behavior can cause restore failures.

If your project targets .NET 9 or lower, the default for `NuGetAuditMode` remains `direct`.

## Version introduced

.NET 10 Preview 3

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Packages with known vulnerabilities might cause your app to be exploitable, even if your project does not directly reference or directly use the vulnerable package.

## Recommended action

- To prevent audit warnings being treated as errors, even when using `<TreatWarningsAsErrors>`, you can use `<WarningsNotAsErrors>NU1901;NU1902;NU1903;NU1904;$(WarningsNotAsErrors)</WarningsNotAsErrors>`.

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
