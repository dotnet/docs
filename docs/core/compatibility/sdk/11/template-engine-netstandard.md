---
title: "Breaking change: Template engine packages no longer support netstandard2.0"
description: "Learn about the breaking change in .NET 11 where the .NET SDK template engine NuGet packages dropped the netstandard2.0 target framework."
ms.date: 06/10/2026
ai-usage: ai-assisted
---

# Template engine packages no longer support netstandard2.0

The .NET SDK template engine NuGet packages no longer target `netstandard2.0`. Projects that consumed these packages via the `netstandard2.0` target and don't target one of the remaining frameworks can no longer use them.

## Version introduced

.NET 11 Preview 4

## Previous behavior

Previously, to support consumption from projects targeting .NET Standard 2.0 (including .NET Framework 4.6.1+ and .NET Core 2.0+), the following packages included a `netstandard2.0` target:

- [`Microsoft.TemplateEngine.Abstractions`](https://www.nuget.org/packages/Microsoft.TemplateEngine.Abstractions)
- [`Microsoft.TemplateEngine.Core`](https://www.nuget.org/packages/Microsoft.TemplateEngine.Core)
- [`Microsoft.TemplateEngine.Core.Contracts`](https://www.nuget.org/packages/Microsoft.TemplateEngine.Core.Contracts)
- [`Microsoft.TemplateEngine.Edge`](https://www.nuget.org/packages/Microsoft.TemplateEngine.Edge)
- [`Microsoft.TemplateEngine.Orchestrator.RunnableProjects`](https://www.nuget.org/packages/Microsoft.TemplateEngine.Orchestrator.RunnableProjects)
- [`Microsoft.TemplateEngine.Utils`](https://www.nuget.org/packages/Microsoft.TemplateEngine.Utils)
- [`Microsoft.TemplateEngine.IDE`](https://www.nuget.org/packages/Microsoft.TemplateEngine.IDE)
- [`Microsoft.TemplateLocalizer.Core`](https://www.nuget.org/packages/Microsoft.TemplateEngine.TemplateLocalizer.Core)

## New behavior

Starting in .NET 11, these packages only target `net9.0`, `net11.0`, and `net472`. Projects that previously consumed these packages via the `netstandard2.0` target and don't target one of these remaining frameworks can no longer reference these packages.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

NuGet client SDK packages (`NuGet.*`) stopped targeting `netstandard2.0` starting with version 7.0. `Microsoft.TemplateEngine.Edge` depends on NuGet packages (`NuGet.Configuration`, `NuGet.Credentials`, and `NuGet.Protocol`), which made it increasingly difficult to maintain `netstandard2.0` compatibility. To avoid transitive dependency conflicts, the project had to pin these packages to older versions and disable `CentralPackageTransitivePinningEnabled`. Dropping `netstandard2.0` removes this constraint and allows the packages to stay current with their dependencies.

For more context, see [dotnet/sdk#54041](https://github.com/dotnet/sdk/pull/54041).

## Recommended action

Update your consuming project to target `net9.0` or later, or `net472` or later (.NET Framework). If you relied on the `netstandard2.0` target to consume these packages from a .NET Standard class library, retarget that library to one of the supported frameworks.

## Affected APIs

All public APIs in the affected packages remain the same. Only the supported target frameworks have changed.
