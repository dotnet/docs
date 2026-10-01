---
title: Microsoft.Testing.Platform (MTP) test host deployment
description: Learn how MTP extensions control test host deployment and startup.
author: evangelink
ms.author: amauryleve
ms.date: 10/01/2026
ai-usage: ai-assisted
---

# Test host deployment

These extensions control how and where MTP deploys and starts the test host. They use the experimental `ITestHostLauncher` extension point to control test host deployment and startup.

> [!TIP]
> When you use [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild), install an extension's NuGet package to register the extension automatically. MSTest, NUnit, and xUnit runners include `Microsoft.Testing.Platform.MSBuild` transitively. If you disable the generated entry point, call `AddSelfRegisteredExtensions` to register the packages that MSBuild contributes.

## Packaged app deployment

The [Microsoft.Testing.Extensions.PackagedApp](https://www.nuget.org/packages/Microsoft.Testing.Extensions.PackagedApp) extension registers a packaged Windows test host from its build-output layout and activates it by Application User Model ID (AUMID).

The package was introduced in MTP 2.3. Starting with MTP 2.5, it supports packaged full-trust and AppContainer hosts end to end, including:

- Packaged full-trust WinUI 3 apps.
- Modern UWP apps that use `UseUwp`.
- Classic UWP apps that target `uap10.0`.
- WinUI 3 `packagedClassicApp` hosts that set `TrustLevel="appContainer"`.

MSTest.Sdk 4.5 or later configures this extension and the required full-trust app-model sidecar automatically. For application setup and run commands, see [Test UWP and WinUI 3 apps with MSTest and MTP](unit-testing-mstest-winui.md).

> [!CAUTION]
> Starting with MTP 2.4, `Microsoft.Testing.Extensions.PackagedApp` follows the MTP release version, and its public registration API is no longer experimental. The generic `ITestHostLauncher` extension point remains experimental and might change in a future release.

### Meet the requirements

Meet these requirements before you use the extension:

- Target Windows platform version `10.0.19041.0` or later for a WinUI 3 packaged app.
- To register an unsigned build-output layout, enable Developer Mode or configure sideloading.
- For UWP, use desktop MSBuild from Visual Studio with the UWP workload and required Windows SDK.
- Run AppContainer test hosts from a non-elevated controller process.

### Understand package activation

For a packaged app, the launcher:

1. Locates the `AppxManifest.xml` that describes the test executable.
1. Registers the build-output layout for the current user.
1. Resolves the selected manifest application's AUMID.
1. Activates the application and connects it to the MTP controller.

For `packagedClassicApp` and `win32App` hosts, Windows supplies MTP arguments through the normal process argument array. This behavior also applies to a `packagedClassicApp` that uses AppContainer.

For a UWP `windowsApp`, Windows supplies one opaque activation string through `LaunchActivatedEventArgs.Arguments`. In `OnLaunched`, call `PackagedAppExtensions.GetTestApplicationArguments` before you create the MTP builder.

### Connect an AppContainer host

An AppContainer token includes a restricted package SID. A named pipe that authorizes only the current user rejects the AppContainer process even when it belongs to the same signed-in user.

In MTP 2.5 or later, the packaged-app launcher derives the selected application's exact package SID and asks MTP to grant that SID the minimum client rights on the controller and extension pipes. The extension doesn't grant `ALL APPLICATION PACKAGES`, lower the pipe's integrity level, or require a network loopback exemption.

The sidecar transfers controller metadata through package `LocalState`. It also copies TRX, dump, diagnostic, and retry artifacts from package-owned storage to the requested results directory after the sandboxed host exits.

### Control automatic activation

By default, the launcher enables itself only when it finds a package manifest that describes the test application. An unpackaged WinUI 3 app or ordinary console test app stays on the direct-start path.

Use `TESTINGPLATFORM_PACKAGEDAPP_LAUNCHER` to override package detection:

| Value | Behavior |
|---|---|
| `auto` or unset | Enable only for a packaged layout. |
| `always` | Enable for any layout, including a loose layout that you want to deploy before startup. |
| `never` | Disable the packaged-app launcher. |

Use `TESTINGPLATFORM_PACKAGEDAPP_PIPEAUTHORIZATION` to override package-SID authorization:

| Value | Behavior |
|---|---|
| `auto` or unset | Authorize the package SID only when the manifest declares an AppContainer application. |
| `always` | Request package-SID authorization for any packaged layout. |
| `never` | Keep the current-user-only pipe authorization. |

### Register the extension manually

If you don't use automatic MSBuild registration, register the extension in your MTP builder:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.AddPackagedAppDeployment();
```

Don't call `AddPackagedAppDeployment` if the application already calls `AddSelfRegisteredExtensions` and references the package. An MTP run can register only one test host launcher.
