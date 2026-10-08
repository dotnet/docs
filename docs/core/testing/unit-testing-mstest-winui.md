---
title: Test UWP and WinUI 3 apps with MSTest and Microsoft.Testing.Platform
description: Learn how to test classic and modern UWP apps, packaged and unpackaged WinUI 3 apps, and AppContainer hosts with MSTest and Microsoft.Testing.Platform.
author: Evangelink
ms.author: amauryleve
ms.date: 09/30/2026
ai-usage: ai-assisted
---

# Test UWP and WinUI 3 apps with MSTest and Microsoft.Testing.Platform

Use Microsoft.Testing.Platform (MTP) to run MSTest tests inside UWP and WinUI 3 applications. The application acts as the test host and owns its UI thread and process lifetime.

> [!IMPORTANT]
> The complete Windows application support matrix described in this article is available with MSTest 4.5 and MTP 2.5. Until the stable versions are released, use matching 4.5 and 2.5 preview packages. If you manage MTP packages directly, keep the platform and extension package versions aligned.

## Choose an application model

MSTest.Sdk supports the following Windows application models through MTP:

| Application model | Packaging and trust | Test host startup | Run command |
|---|---|---|---|
| Classic UWP (`uap10.0`) | Packaged AppContainer | A full-trust sidecar registers the package and activates the app by Application User Model ID (AUMID). | `MSBuild` with the `InvokeTestingPlatform` target |
| Modern UWP (.NET 10 with `UseUwp`) | Packaged AppContainer | A full-trust sidecar registers the package and activates the app by AUMID. | `MSBuild` with the `InvokeTestingPlatform` target |
| Packaged WinUI 3 | Packaged full trust | A full-trust sidecar registers the package and activates the app by AUMID. | `dotnet run` or `dotnet test --project` |
| Unpackaged WinUI 3 | No package identity, full trust | MTP starts the app executable directly. | `dotnet run` or `dotnet test --project` |
| WinUI 3 `packagedClassicApp` with `TrustLevel="appContainer"` | Packaged AppContainer | A full-trust sidecar activates the app and authorizes its exact package security identifier (SID) on MTP communication pipes. | `dotnet msbuild` with the `InvokeTestingPlatform` target |

Packaging and sandboxing are separate choices. A packaged WinUI 3 desktop app has package identity but runs as a full-trust process by default. A UWP app always runs in AppContainer. A packaged WinUI 3 app runs in AppContainer only when its manifest sets `TrustLevel="appContainer"`.

For older MSTest or MTP versions, keep your existing VSTest configuration for UWP projects. Native MTP execution for UWP and AppContainer hosts requires MSTest 4.5 and MTP 2.5.

## Understand the MTP app-model sidecar

For a packaged app, the initial test tool process can't run inside the package. MSTest.Sdk starts a full-trust sidecar controller that:

- Prepares command-line arguments and owns cancellation, retries, reports, and exit-code handling.
- Registers the build-output package and activates the exact manifest application by AUMID.
- Authorizes only the selected package SID when an AppContainer host connects to MTP named pipes.
- Recovers TRX, dump, diagnostic, and retry artifacts from package-owned storage.

The test application still hosts MTP and MSTest in its own process. UWP execution doesn't require `Microsoft.NET.Test.Sdk`, `vstest.console`, `UwpTestHostRuntimeProvider`, or the Visual Studio deployment runtime.

For a UWP `windowsApp`, Windows provides one activation string through `LaunchActivatedEventArgs.Arguments` instead of normal process arguments. Call `PackagedAppExtensions.GetTestApplicationArguments` before you create the MTP builder. The packaged-app extension restores the original argument array and the controller connection metadata.

For a WinUI 3 `packagedClassicApp`, including one that runs in AppContainer, use the normal process arguments.

## Meet the prerequisites

Use the prerequisites that apply to your project:

- Use .NET SDK 10 or later for the MSTest 4.5 toolchain and `dotnet test --project`.
- For UWP, use desktop MSBuild from Visual Studio with the Universal Windows Platform workload and the required Windows SDK. These components provide build-time support only.
- For WinUI 3, install the Windows application development tools and reference a compatible Windows App SDK version.
- For packaged test apps, enable Windows Developer Mode or configure sideloading so Windows can register an unsigned build-output layout.
- For AppContainer test apps, run the controller as a non-elevated user.

## Configure UWP tests

### Configure a modern UWP project

Use MSTest.Sdk 4.5 or later, target .NET 10 with a Windows platform version, and set `UseUwp` to `true`. Keep your existing UWP XAML, MSIX, architecture, and Native AOT settings.

Visual Studio normally enables `UseUwpTools` during the build. MSTest.Sdk selects the UWP application model when `UseUwpTools` is `true`, or when `UseUwp` is `true` and `UseUwpTools` isn't set yet.

If you only need UWP references in a non-UWP MTP test application, set `UseUwpTools` to `false`. The SDK then uses the direct MTP runner unless another packaged application model requires the sidecar.

For a complete project, see the [modern UWP MTP sample](https://github.com/microsoft/testfx/tree/main/samples/public/UwpMtpApp).

### Configure a classic UWP project

Keep the existing `uap10.0` project shape, desktop MSBuild toolchain, and UWP extension SDK. Import MSTest.Sdk 4.5 or later, and enable the MSTest runner and MTP. MSTest.Sdk supplies the UAP-compatible bootstrap, adapter, and runtime assets.

For a complete project, see the [classic UWP MTP sample](https://github.com/microsoft/testfx/tree/main/samples/public/ClassicUwpMtpApp).

### Run UWP tests

Open a Developer PowerShell for Visual Studio. Build the solution for a concrete architecture, and then invoke MTP:

```powershell
msbuild UwpTests.sln /restore /p:Configuration=Release /p:Platform=x64
msbuild UwpTests.csproj /t:InvokeTestingPlatform /p:Configuration=Release /p:Platform=x64 /p:TestingPlatformCommandLineArguments="--report-trx"
```

The second command registers the package, activates the app by AUMID, runs regular and UI-thread tests, copies result artifacts from package storage, and returns the test run exit code.

## Configure WinUI 3 tests

Use MSTest.Sdk 4.5 or later, set `UseWinUI` to `true`, and target a Windows-specific target framework. For packaged activation, use Windows platform version `10.0.19041.0` or later.

### Host MTP from the WinUI application

For a self-hosted WinUI test app, create and activate the test window in `OnLaunched`, and then publish its dispatcher queue:

```csharp
_window = new UnitTestAppWindow();
_window.Activate();
UITestMethodAttribute.DispatcherQueue = _window.DispatcherQueue;
```

Run the generated MTP helper, assign its result to `Environment.ExitCode`, close the window, and call `Exit`:

```csharp
Environment.ExitCode = await MicrosoftTestingPlatformApplication.RunAsync(
    Environment.GetCommandLineArgs()[1..]);
```

Use `UITestMethod` for tests that create or access WinUI objects. Use `TestMethod` for tests that don't require the UI thread.

> [!WARNING]
> Don't add `[assembly: WinUITestTarget(...)]` to a self-hosted WinUI test app. That attribute starts a WinUI application for a separate test host, but the self-hosted app has already called `Application.Start`.

### Configure an unpackaged app

Set `WindowsPackageType` to `None`. The app has no MSIX identity or `AppxManifest.xml`, so MTP starts its executable directly. Don't add the packaged-app extension manually.

The Windows App SDK normally injects its bootstrap initializer when the project meets these conditions:

- `WindowsPackageType` is `None`.
- `OutputType` is `Exe` or `WinExe`.
- `WindowsAppSDKSelfContained` isn't `true`.

If a host that isn't a Windows App SDK app loads your test library, set `WindowsAppSdkBootstrapInitialize` to `true` in the library.

VSTest doesn't support unpackaged WinUI 3 test apps because its WinUI provider requires an AppX manifest.

For a complete project, see the [unpackaged WinUI MTP sample](https://github.com/microsoft/testfx/tree/main/samples/public/WinUIMtpUnpackagedApp).

### Configure a packaged full-trust app

Keep the default packaged WinUI configuration and its `Package.appxmanifest`. MSTest.Sdk references and registers `Microsoft.Testing.Extensions.PackagedApp` automatically for the packaged project.

Don't also call `AddPackagedAppDeployment`. An MTP run can register only one test host launcher. Set `EnableMicrosoftTestingExtensionsPackagedApp` to `false` only when a custom launcher owns packaged activation.

For a complete project, see the [packaged WinUI MTP sample](https://github.com/microsoft/testfx/tree/main/samples/public/WinUIMtpPackagedApp).

### Configure an AppContainer app

In the WinUI package manifest, configure the application as `packagedClassicApp` and set `TrustLevel="appContainer"`. MTP 2.5 authorizes the exact package SID on the controller and extension pipes. It doesn't grant `ALL APPLICATION PACKAGES` or require a loopback exemption.

Run the sidecar non-elevated. Use the `InvokeTestingPlatform` target so the sidecar can copy results and diagnostics from package `LocalState` to the requested results directory.

For a complete project, see the [AppContainer WinUI MTP sample](https://github.com/microsoft/testfx/tree/main/samples/public/WinUIMtpAppContainerApp).

## Run WinUI 3 tests

Build for a concrete architecture. For a packaged full-trust or unpackaged app, run:

```powershell
dotnet build -p:Platform=x64
dotnet test --project . --no-build -p:Platform=x64
```

You can also use `dotnet run --no-build -p:Platform=x64`.

For an AppContainer WinUI app, use the sidecar target and an absolute results directory:

```powershell
dotnet msbuild .\WinUITests.csproj -t:InvokeTestingPlatform -p:Platform=x64 "-p:TestingPlatformCommandLineArguments=--report-trx --results-directory C:\TestResults"
```

Don't use `dotnet exec` for a WinUI app. WinUI resolves PRI resources relative to the process path.

## Troubleshoot the setup

| Symptom | Check |
|---|---|
| The app reports multiple calls to `Application.Start`. | Remove the `WinUITestTarget` attribute from a self-hosted WinUI test app. |
| The test run finishes but the process stays open. | Close the test window and call `Exit` after the MTP run completes. |
| Failed tests return process exit code `0`. | Assign the MTP run result to `Environment.ExitCode`. |
| An unpackaged WinUI run reports a missing `AppxManifest.xml`. | Confirm that the project uses MTP instead of VSTest. |
| A packaged run can't register or activate the app. | Confirm the Windows target framework, Developer Mode or sideloading policy, architecture, and manifest executable entry. |
| An AppContainer host can't connect to the controller. | Use MSTest 4.5 and MTP 2.5 or later, and run the controller non-elevated. |
| An AppContainer report isn't copied to the requested directory. | Use `InvokeTestingPlatform` and specify an absolute results directory. |

## See also

- [MSTest overview](unit-testing-mstest-intro.md)
- [MSTest SDK configuration](unit-testing-mstest-sdk.md)
- [Run tests with MSTest](unit-testing-mstest-running-tests.md)
- [MTP test host deployment](microsoft-testing-platform-test-host-deployment.md)
- [Windows app testing guidance in the MSTest repository](https://github.com/microsoft/testfx/blob/main/docs/winui-testing.md)
