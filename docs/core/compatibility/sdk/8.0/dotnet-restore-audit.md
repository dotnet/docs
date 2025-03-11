---
title: "Breaking change: 'dotnet restore' produces security vulnerability warnings"
description: Learn about a breaking change in the .NET 8 SDK where 'dotnet restore' produces security vulnerability warnings by default.
ms.date: 08/15/2023
---
# 'dotnet restore' produces security vulnerability warnings

The [`dotnet restore` command](../../../tools/dotnet-restore.md), which restores the dependencies and tools of a project, now produces security vulnerability warnings by default.

## Previous behavior

Previously, `dotnet restore` did not emit any security vulnerability warnings by default.

## New behavior

If you're developing with the .NET 8 SDK or a later version, `dotnet restore` produces security vulnerability warnings by default for *all* restored projects. When you load a solution or project, or run a CI/CD script, this change might break your workflow if you have `<TreatWarningsAsErrors>` enabled.

## Version introduced

.NET 8 Preview 4

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Many users want to know whether the packages they restore contain any known security vulnerabilities. This functionality was a highly requested feature. Security concerns continue to increase each year and some known security issues aren't visible enough to take immediate action.

## Recommended action

The properties mentioned in the recommended actions can be set either in your project file (for example, \*.csproj or \*.fsproj file) or *Directory.Build.props* file.

- To explicitly reduce the probability of this breaking your build due to warnings, you can consider your usage of `<TreatWarningsAsErrors>` and set `<WarningsNotAsErrors>NU1901;NU1902;NU1903;NU1904</WarningsNotAsErrors>` to ensure known security vulnerabilities are still allowed in your environment.

  ```xml
  <PropertyGroup>
    ...
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <WarningsNotAsErrors>NU1901;NU1902;NU1903;NU1904</WarningsNotAsErrors>
  </PropertyGroup>
  ```

- If you want to set a different security audit level, add the `<NuGetAuditLevel>` property to your project file with possible values of `low`, `moderate`, `high`, and `critical`.

  ```xml
  <PropertyGroup>
    ...
    <NuGetAuditLevel>low</NuGetAuditLevel>
  </PropertyGroup>
  ```

- If you want to ignore these warnings, you can use `<NoWarn>` to suppress `NU1901-NU1904` warnings.

  ```xml
  <PropertyGroup>
    ...
    <NoWarn>$(NoWarn);NU1901-NU1904</NoWarn>
  </PropertyGroup>
  ```

- To disable the new behavior entirely, you can set the `<NuGetAudit>` project property to `false`.

  ```xml
  <PropertyGroup>
    ...
    <NuGetAudit>false</NuGetAudit>
  </PropertyGroup>
  ```

## See also

- [Audit for security vulnerabilities (`dotnet restore`)](../../../tools/dotnet-restore.md#audit-for-security-vulnerabilities)
- [Auditing package dependencies for security vulnerabilities](/nuget/concepts/auditing-packages)
