---
title: MSTest overview
description: Learn about MSTest, Microsoft's testing framework for .NET, including supported platforms, key features, and getting started.
author: Evangelink
ms.author: amauryleve
ms.date: 10/01/2026
ai-usage: ai-assisted
---

# MSTest overview

MSTest, Microsoft Testing Framework, is a fully supported, open-source, and cross-platform test framework for .NET applications. It allows you to write and execute tests, and provides test suites with integration to Visual Studio and Visual Studio Code Test Explorers, the .NET CLI, and many CI pipelines.

MSTest is hosted on [GitHub](https://github.com/microsoft/testfx) and works with all supported .NET targets.

## Key features

MSTest provides comprehensive testing capabilities:

- **[Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md)**: Run tests with multiple inputs using `DataRow`, `CombinatorialData`, `DynamicData`, and external data sources.
- **[Test lifecycle management](unit-testing-mstest-writing-tests-lifecycle.md)**: Setup and cleanup at assembly, class, and test levels.
- **[Parallel execution](unit-testing-mstest-writing-tests-controlling-execution.md#parallelization-attributes)**: Run tests concurrently to reduce execution time.
- **[Test organization](unit-testing-mstest-writing-tests-organizing.md)**: Categorize, prioritize, and filter tests with metadata attributes.
- **[Code analyzers](mstest-analyzers/overview.md)**: Detect common issues and enforce best practices at compile time.
- **[Assertions](unit-testing-mstest-writing-tests-assertions.md)**: Comprehensive assertion methods for validating results.

## Supported platforms

MSTest supports a wide range of .NET platforms and target frameworks. The following table summarizes platform support and special considerations:

| Platform | Target frameworks | Threading support | Special attributes | Notes |
|----------|-------------------|-------------------|-------------------|-------|
| **.NET** | .NET 8+ | Full parallelization | All attributes | Recommended for new projects |
| **.NET Framework** | 4.6.2+ | Full parallelization | All attributes | Full feature support |
| **UWP** | UAP 10, .NET 10+ with UWP tooling | UI thread | `UITestMethod` | MSTest 4.5 and MTP 2.5 support classic and modern UWP through the MSTest.Sdk app-model sidecar |
| **WinUI 3** | .NET 8+ | UI thread | `UITestMethod` | MTP supports packaged, unpackaged, and AppContainer hosts; see [Test UWP and WinUI 3 apps with MSTest and MTP](unit-testing-mstest-winui.md) |
| **Windows desktop UI automation** | .NET 8+ Windows target | STA | `STATestClass` | MSTest 4.5 preview can launch unpackaged Win32, Windows Forms, and WPF apps and expose a window through Windows UI Automation |
| **Native AOT** | .NET 8+ | Full parallelization | Most attributes | Limited feature set; see [Native AOT sample](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/NativeAotRunner) |
| **Browser WebAssembly** | .NET 10+ custom host | Single-threaded | Limited | MTP execution support starts with MSTest 4.4 |
| **WASI WebAssembly** | .NET 10+ custom host | Single-threaded | Limited | MTP execution support starts with MSTest 4.4 |

### Platform-specific considerations

#### UWP testing

UWP tests run in the UWP app container and require the UI thread for many operations:

```csharp
[TestClass]
public class UwpTests
{
    [UITestMethod]
    public void TestUwpControl()
    {
        // Test runs on UI thread
        var button = new Button();
        Assert.IsNotNull(button);
    }
}
```

Starting with MSTest 4.5 and MTP 2.5, use MSTest.Sdk to run classic UWP and modern .NET UWP tests through MTP. A full-trust sidecar registers and activates the package, authorizes the app's exact package SID for MTP communication, and copies result artifacts from package storage.

Modern UWP requires .NET 10, `UseUwp`, and the Visual Studio UWP build toolchain. Classic UWP keeps its existing `uap10.0` project shape. For complete configurations, see the [modern UWP sample](https://github.com/microsoft/testfx/tree/main/samples/public/UwpMtpApp) and [classic UWP sample](https://github.com/microsoft/testfx/tree/main/samples/public/ClassicUwpMtpApp).

#### WinUI 3 testing

WinUI 3 tests also require UI thread access for testing visual components:

```csharp
[TestClass]
public class WinUITests
{
    [UITestMethod]
    public void TestWinUIControl()
    {
        // Test runs on UI thread
        var window = new MainWindow();
        Assert.IsNotNull(window);
    }
}
```

MTP supports packaged full-trust, unpackaged, and AppContainer-configured WinUI 3 test applications. MSTest.Sdk starts unpackaged apps directly and uses its app-model sidecar to register and activate packaged apps.

AppContainer support requires MSTest 4.5 and MTP 2.5 or later. VSTest doesn't support unpackaged WinUI 3. For setup details, see [Test UWP and WinUI 3 apps with MSTest and MTP](unit-testing-mstest-winui.md).

#### Windows desktop UI automation

The `MSTest.Windows.UIAutomation` package integrates MSTest lifecycle management with Windows UI Automation for unpackaged Win32, Windows Forms, and WPF applications. For setup, limitations, and the `ApplicationTest` and `WindowTest` base classes, see [Test Windows desktop apps with MSTest UI Automation](unit-testing-mstest-ui-automation.md).

#### Native AOT

Native AOT compilation is supported with some limitations due to reduced reflection capabilities. Use source generators where possible and test your AOT scenarios with the [NativeAotRunner sample](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/NativeAotRunner).

#### Browser and WASI WebAssembly

MSTest 4.4 supports custom .NET 10 browser or WASI WebAssembly hosts. To run tests from a referenced MSTest assembly, call `AddMSTest`. In the host project, set `EnableMSTestRunner` to `true` and `GenerateTestingPlatformEntryPoint` to `false`. Keep the MSTest and MTP package versions aligned.

On a single-threaded WebAssembly runtime, MSTest can't forcibly interrupt a timed-out test. Debugger wait isn't supported on browser or WASI, and browser doesn't support debugger launch options.

MTP can stream TRX data and report test and session file artifacts through the host's WebAssembly virtual file system and artifact channel. Azure DevOps publishing works only when the host provides supported HTTP access and the required pipeline authentication. These features don't grant unrestricted host file-system or network access.

For a complete browser host, see the [BrowserPlayground sample](https://github.com/microsoft/testfx/tree/main/samples/BrowserPlayground).

### STA threading support

For Windows COM interop scenarios, MSTest provides `STATestClass` and `STATestMethod` attributes to run tests in a single-threaded apartment. For details on STA threading, including async continuation support with `UseSTASynchronizationContext`, see [Threading attributes](unit-testing-mstest-writing-tests-controlling-execution.md#threading-attributes).

## Test runners

MSTest supports two test execution platforms:

- **[Microsoft.Testing.Platform (MTP)](unit-testing-mstest-running-tests.md)**: The modern, recommended test platform with improved performance and extensibility.
- **VSTest**: The original and default test platform for .NET.

For new projects, we recommend using [MTP](unit-testing-mstest-running-tests.md) with [MSTest.Sdk](unit-testing-mstest-sdk.md).

## MSTest support policy

Since v3.0.0, MSTest strictly follows [semantic versioning](../../csharp/versioning.md#semantic-versioning).

The MSTest team only supports the latest released version and strongly encourages users to always update to the latest version to benefit from improvements and security patches. Preview releases aren't supported by Microsoft but are offered for public testing ahead of final release.

### Version history

MSTest has undergone significant evolution across major versions:

- **MSTest v1**: The original Visual Studio testing framework
- **MSTest v2**: First open-source release with cross-platform support
- **MSTest v3**: Modern rewrite with improved architecture and features
- **MSTest v4**: Current version with enhanced features

> [!NOTE]
> MSTest 4.5 is under development as of October 2026. Features marked as introduced in MSTest 4.5 require a preview build until version 4.5.0 is released.

For details on all releases, see the [MSTest changelog](https://github.com/microsoft/testfx/blob/main/docs/Changelog.md).

If you're upgrading from an older version, see the migration guides:

- [Migrate from MSTest v1 to v3](unit-testing-mstest-migration-from-v1-to-v3.md)
- [Migrate from MSTest v3 to v4](unit-testing-mstest-migration-v3-v4.md)

### Breaking changes

The MSTest team carefully reviews and minimizes breaking changes. When breaking changes are necessary, the team uses [GitHub Announcements](https://github.com/microsoft/testfx/discussions/categories/announcements) and [breaking change labels](https://github.com/microsoft/testfx/labels/breaking-change) on issues to inform the community early, giving users time to provide feedback and raise concerns before changes are released.

## Next steps

- [Get started with MSTest](unit-testing-mstest-getting-started.md)
- [Write tests](unit-testing-mstest-writing-tests.md)
- [Run tests](unit-testing-mstest-running-tests.md)
- [Test UWP and WinUI 3 apps](unit-testing-mstest-winui.md)
- [Test Windows desktop apps with MSTest UI Automation](unit-testing-mstest-ui-automation.md)
- [Configure MSTest](unit-testing-mstest-configure.md)
- [MSTest code analyzers](mstest-analyzers/overview.md)
