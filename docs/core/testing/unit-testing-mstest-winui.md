---
title: Test WinUI 3 apps with MSTest and Microsoft.Testing.Platform
description: Learn how to configure unpackaged and packaged full-trust WinUI 3 test apps with MSTest and Microsoft.Testing.Platform.
author: Evangelink
ms.author: amauryleve
ms.date: 08/06/2026
ai-usage: ai-assisted
---

# Test WinUI 3 apps with MSTest and Microsoft.Testing.Platform

Use Microsoft.Testing.Platform (MTP) to run MSTest tests inside a WinUI 3 app. The WinUI app acts as the test host. It owns the application entry point, UI thread, and process lifetime.

Choose between two WinUI 3 deployment models:

- An **unpackaged app** runs as a regular Windows executable.
- A **packaged full-trust app** keeps MSIX package identity and uses the experimental `Microsoft.Testing.Extensions.PackagedApp` extension to register and activate the test host.

> [!IMPORTANT]
> The packaged-app extension supports full-trust packaged desktop apps. It doesn't support UWP or other AppContainer test hosts.
>
> Packaged full-trust AUMID activation is implemented in the `microsoft/testfx` repository but isn't available in a public NuGet package as of August 6, 2026. The current `1.0.0-alpha` packages don't contain the Windows-specific activation implementation. Use the packaged setup only after a package release identifies support for full-trust MSIX registration and AUMID activation.

## Choose a deployment model

Choose the deployment model before you configure the test project.

| Requirement | Choose | Test host startup |
|---|---|---|
| Your tests don't need package identity or APIs that require package identity. | Unpackaged | MTP starts the app executable directly. |
| Your tests require MSIX package identity or packaged-app behavior. | Packaged full-trust after the MTP preview becomes publicly available | The packaged-app extension registers the build output and activates the app by Application User Model ID (AUMID). |
| Your tests must run in UWP or another AppContainer. | VSTest | The MTP packaged-app extension doesn't support AppContainer isolation. |

Unless your tests require package identity, use an unpackaged app. The unpackaged model doesn't require package registration, Developer Mode, or the experimental packaged-app extension.

Until a public MTP preview includes full-trust MSIX registration and AUMID activation, use VSTest for packaged full-trust WinUI 3 tests.

### Understand the UWP boundary

Don't treat UWP as another packaged WinUI 3 model. Both classic UWP projects that target UAP 10 and modern .NET UWP projects that set `UseUwp` to `true` run in an AppContainer. Packaging a WinUI 3 desktop app doesn't place it in that app model.

Use VSTest for classic UWP and modern .NET UWP tests. The MTP packaged-app launcher targets full-trust packaged desktop hosts. It can't deliver its activation arguments or controller connection to an AppContainer host.

For a modern .NET UWP configuration, see the [MSTest .NET 9 UWP sample](https://github.com/microsoft/testfx/tree/main/samples/public/BlankUwpNet9App).

## Configure the WinUI test host

Both deployment models use the same self-hosted MTP setup.

### Set the common project properties

Set these properties in the WinUI test project:

```xml
<OutputType>Exe</OutputType>
<TargetFramework>net8.0-windows10.0.19041.0</TargetFramework>
<UseWinUI>true</UseWinUI>
<EnableMSTestRunner>true</EnableMSTestRunner>
<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>
```

Use .NET 8 or a later supported .NET version. The example targets Windows platform version `10.0.19041.0`. The packaged-app extension requires this version or later.

Keep the WinUI `ApplicationDefinition` item that points to your test app's XAML file. WinUI generates an entry point from that item. To prevent MTP from generating a second entry point, set `GenerateTestingPlatformEntryPoint` to `false`.

Add package references to the current compatible versions of [MSTest](https://www.nuget.org/packages/MSTest) and [Microsoft.WindowsAppSDK](https://www.nuget.org/packages/Microsoft.WindowsAppSDK).

### Host MTP from the application

Override `OnLaunched` in the WinUI `Application` class. Create and activate the test window, and then publish its dispatcher queue:

```csharp
_window = new UnitTestAppWindow();
_window.Activate();
UITestMethodAttribute.DispatcherQueue = _window.DispatcherQueue;
```

Add `using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;` for `UITestMethodAttribute`.

Create the MTP application from the command-line arguments. Then register the extensions that MSBuild contributes:

```csharp
string[] cliArgs = Environment.GetCommandLineArgs().Skip(1)
    .Where(arg => !arg.Contains("EnableMSTestRunner")).ToArray();
ITestApplicationBuilder builder = await TestApplication.CreateBuilderAsync(cliArgs);
builder.AddSelfRegisteredExtensions(cliArgs);
using ITestApplication app = await builder.BuildAsync();
```

Add `using Microsoft.Testing.Platform.Builder;` for the MTP builder types. The WinUI build adds `EnableMSTestRunner` to the process arguments. Because it isn't an MTP command-line option, remove it before you create the test application.

The project disables the generated MTP entry point, so call `AddSelfRegisteredExtensions`. For a packaged app, the method also registers the `Microsoft.Testing.Extensions.PackagedApp` launcher.

In `OnLaunched`, put test application creation and execution in a `try` block. Assign the result of `await app.RunAsync()` to `Environment.ExitCode`. In a `finally` block, close the window and call the application's `Exit` method.

The lifecycle steps provide two guarantees:

- The process returns the MTP exit code, so a failed test produces a nonzero process exit code.
- The WinUI message loop stops after the run instead of leaving the test process active.

> [!WARNING]
> Don't add `[assembly: WinUITestTarget(...)]` to a self-hosted WinUI test app. The attribute starts a WinUI application for a separate test host. A self-hosted app calls `Application.Start` first. The attribute then tries to start a second application in the same process.

For a complete implementation, see the [unpackaged WinUI sample](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/MSTestRunnerWinUIUnpackaged) and the [packaged WinUI sample](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/MSTestRunnerWinUI).

### Run tests on the UI thread

Use `UITestMethod` for a test that creates or accesses WinUI objects. MSTest schedules the test on the dispatcher queue that you assigned during `OnLaunched`.

```csharp
[UITestMethod]
public void CreatesControlOnUiThread()
{
    var grid = new Grid();
    Assert.IsTrue(grid.DispatcherQueue.HasThreadAccess);
}
```

A regular `TestMethod` doesn't run on the WinUI dispatcher queue. Use it for tests that don't require the UI thread.

## Configure an unpackaged test app

For an unpackaged app, add these properties:

```xml
<WindowsPackageType>None</WindowsPackageType>
<EnableMsixTooling>false</EnableMsixTooling>
```

Don't reference `Microsoft.Testing.Extensions.PackagedApp`. The unpackaged app has no MSIX identity or `AppxManifest.xml` in its output, so MTP can start its executable directly.

By default, the Windows App SDK injects its bootstrap initializer when the project meets these conditions:

- `WindowsPackageType` is `None`.
- `OutputType` is `Exe` or `WinExe`.
- `WindowsAppSDKSelfContained` isn't `true`.

If a host that isn't a Windows App SDK app loads your test library, set `WindowsAppSdkBootstrapInitialize` to `true` in the library.

> [!NOTE]
> VSTest doesn't support this unpackaged WinUI configuration. Run the project with MTP.

## Configure a packaged full-trust test app

Keep the default packaged WinUI configuration:

- Don't set `WindowsPackageType` to `None`.
- Keep `Package.appxmanifest` and the package assets in the project.
- Set `EnableMsixTooling` to `true` if your project uses the single-project MSIX packaging tools.

After a preview that includes full-trust MSIX registration and AUMID activation becomes available, add that specific version of the [Microsoft.Testing.Extensions.PackagedApp](https://www.nuget.org/packages/Microsoft.Testing.Extensions.PackagedApp) package. Don't use an earlier `1.0.0-alpha` package for this setup.

The package's MSBuild props register the launcher through `AddSelfRegisteredExtensions`. Don't also call `AddPackagedAppDeployment`. An MTP run can register only one test host launcher.

The launcher performs these actions:

1. It checks for an `AppxManifest.xml` that describes the test executable.
1. It registers the build-output layout with Windows.
1. It resolves the app's AUMID from the registered package and manifest application ID.
1. It activates the app by AUMID and connects the activated process to the MTP controller.

The launcher ignores an unrelated manifest in an ancestor directory unless an `Application` entry points to the test executable. An unpackaged app that references the package indirectly remains on the direct-start path.

Meet these requirements before you run a packaged test app:

- Use a Windows-specific target framework with platform version `10.0.19041.0` or later.
- To register the unsigned build-output layout, enable Developer Mode or configure sideloading.
- Use a full-trust packaged desktop app. The extension doesn't support UWP or other AppContainer hosts.

> [!CAUTION]
> `Microsoft.Testing.Extensions.PackagedApp` and the `ITestHostLauncher` extension point are experimental. A future release might change or remove their APIs and behavior. Evaluate the risks before you use the packaged model in production test infrastructure.

## Run the tests

From the directory that contains the WinUI test project, run:

```dotnetcli
dotnet run
```

To specify the project, use `dotnet run --project .\WinUITests.csproj`.

For an unpackaged app, MTP starts the executable directly. For a packaged app, the packaged-app launcher registers the layout and activates the app by AUMID.

In both models, the test window opens, MTP runs the tests, and the window closes. The terminal then reports the test summary. A successful run exits with code `0`. When a test fails, `OnLaunched` assigns the nonzero `RunAsync` result to `Environment.ExitCode`.

Use `dotnet run` for either model. To run an unpackaged app directly, use the generated app executable. Don't use `dotnet exec` because WinUI resolves PRI resources relative to the process path.

## Troubleshoot the setup

Use these checks for the most common setup failures:

| Symptom | Check |
|---|---|
| The app reports multiple calls to `Application.Start`. | Remove the `WinUITestTarget` attribute from the self-hosted test app. |
| The test run finishes but the process stays open. | Close the test window and call `Exit` in a `finally` block after `RunAsync`. |
| Failed tests still return process exit code `0`. | Assign the result of `RunAsync` to `Environment.ExitCode`. |
| An unpackaged run fails because `AppxManifest.xml` is missing. | Confirm that the project enables MTP and that the run doesn't use VSTest. |
| A packaged run can't register or activate the app. | Confirm the Windows-specific target framework, Developer Mode or sideloading configuration, full-trust app model, and manifest executable entry. |

## See also

- [MSTest overview](unit-testing-mstest-intro.md)
- [Run tests with MSTest](unit-testing-mstest-running-tests.md)
- [MTP test host deployment](microsoft-testing-platform-test-host-deployment.md)
- [WinUI testing guidance in the MSTest repository](https://github.com/microsoft/testfx/blob/main/docs/winui-testing.md)
