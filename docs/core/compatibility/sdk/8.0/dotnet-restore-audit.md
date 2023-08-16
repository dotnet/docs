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

If you're developing with the .NET 8 SDK or a later version, `dotnet restore` produces security vulnerability warnings by default for *all* restored projects. When you load a solution or project, or run a CI/CD script, this change may break your workflow if you have `<TreatWarningsAsErrors>` enabled.

## Version introduced

.NET 8 Preview 4

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

In most cases when you restore a package, you want to know whether the restored package version contains any known security vulnerabilities. This functionality was added as it is a highly requested feature and security concerns continue to increase each year where known security issues can not be visible enough to taking immediate action.

## Recommended action

- To explicitly reduce the probability of this breaking your build due to warnings, you can re-consider your usage of `<TreatWarningsAsErrors>` and use `<WarningsNotAsErrors>NU1901;NU1902;NU1903;NU1904</WarningsNotAsErrors>` to ensure known security vulnerabilities are still allowed in your environment.

- If you'd like to set a different security audit level, you may consider `<NuGetAuditLevel>moderate</NuGetAuditLevel>` with possible values of `low`, `moderate`, `high`, and `critical`.

- If you're looking to ignore these warnings, you can use `<NoWarn>` to suppress `NU1091-NU104` warnings.

- To disable the new behavior entirely, you can set the `<NuGetAudit>` project property to `false`.

## See also

- [Auditing package dependencies for security vulnerabilities](/nuget/concepts/auditing-packages)
