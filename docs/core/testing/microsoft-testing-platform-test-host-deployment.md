---
title: Microsoft.Testing.Platform (MTP) test host deployment
description: Learn about the MTP extensions that control how and where the test host is deployed and launched.
author: evangelink
ms.author: amauryleve
ms.date: 07/09/2026
ai-usage: ai-assisted
---

# Test host deployment

These extensions control how and where the test host is deployed and launched. They build on the experimental `ITestHostLauncher` extension point, which lets an extension take over the deployment and launch of the test host instead of starting it in place. Each extension requires an additional NuGet package, as described in each section.

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), these extensions are auto-registered when you install their NuGet packages — no code changes needed. The manual registration specified in this article is only required if you disabled the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`.

## Packaged app deployment

The packaged app deployment extension deploys a packaged Windows test host (UWP or packaged WinUI) into an isolated directory and launches it from there, rather than starting the test host in place. It's the reference consumer of the experimental `ITestHostLauncher` extension point for packaged Windows apps. This extension requires the [Microsoft.Testing.Extensions.PackagedApp](https://nuget.org/packages/Microsoft.Testing.Extensions.PackagedApp) NuGet package.

> [!NOTE]
> Available in MTP starting with version 2.3.0. This extension is experimental, and its options and output format might change in a future version.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.AddPackagedAppDeployment();
```
