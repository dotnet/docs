---
title: Microsoft.Testing.Platform (MTP) test host deployment
description: Learn how MTP extensions control test host deployment and startup.
author: evangelink
ms.author: amauryleve
ms.date: 08/06/2026
ai-usage: ai-assisted
---

# Test host deployment

These extensions control how and where MTP deploys and starts the test host. They use the experimental `ITestHostLauncher` extension point to control test host deployment and startup. Each extension requires another NuGet package, as described in each section.

> [!TIP]
> When you use [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild), install an extension's NuGet package to register the extension automatically. MSTest, NUnit, and xUnit runners include `Microsoft.Testing.Platform.MSBuild` transitively. If you disable the generated entry point, call `AddSelfRegisteredExtensions` to register the packages that MSBuild contributes.

## Packaged app deployment

The packaged-app extension registers a full-trust packaged Windows test host from its build-output layout and activates it by Application User Model ID (AUMID). It's the reference consumer of the experimental `ITestHostLauncher` extension point for packaged Windows apps. This extension requires the [Microsoft.Testing.Extensions.PackagedApp](https://nuget.org/packages/Microsoft.Testing.Extensions.PackagedApp) NuGet package.

> [!NOTE]
> The extension package is available starting with MTP version 2.3.0. Full-trust MSIX registration and AUMID activation are implemented in the `microsoft/testfx` repository but aren't available in a public NuGet package as of August 6, 2026. The extension is experimental, and its options and output format might change in a future version.

Meet these requirements before you use the extension:

- Target Windows platform version `10.0.19041.0` or later.
- To register an unsigned build-output layout, enable Developer Mode or configure sideloading.
- Use a full-trust packaged desktop host. The extension doesn't support classic UWP, modern .NET UWP with `UseUwp`, or other AppContainer hosts.

For a complete self-hosted WinUI configuration, see [Test WinUI 3 apps with MSTest and MTP](unit-testing-mstest-winui.md).

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.AddPackagedAppDeployment();
```

Don't call `AddPackagedAppDeployment` if a self-hosted application already calls `AddSelfRegisteredExtensions` and references the package. An MTP run can register only one test host launcher.
