---
title: MSTest overview
description: Learn about MSTest, Microsoft's testing framework for .NET, including supported platforms, key features, and getting started.
author: Evangelink
ms.author: amauryleve
ms.date: 08/06/2026
ai-usage: ai-assisted
---

# MSTest overview

MSTest, Microsoft Testing Framework, is a fully supported, open-source, and cross-platform test framework for .NET applications. It allows you to write and execute tests, and provides test suites with integration to Visual Studio and Visual Studio Code Test Explorers, the .NET CLI, and many CI pipelines.

MSTest is hosted on [GitHub](https://github.com/microsoft/testfx) and works with all supported .NET targets.

## Key features

MSTest provides comprehensive testing capabilities:

- **[Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md)**: Run tests with multiple inputs using `DataRow`, `DynamicData`, and external data sources.
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
| **UWP** | UAP 10, .NET 9+ with UAP | UI thread | `UITestMethod` | Use VSTest. Modern .NET UWP requires `<UseUwp>true</UseUwp>`; see [UWP sample](https://github.com/microsoft/testfx/tree/main/samples/public/BlankUwpNet9App) |
| **WinUI 3** | .NET 8+ | UI thread | `UITestMethod` | Requires Windows App SDK; see [Test WinUI 3 apps with MSTest and MTP](unit-testing-mstest-winui.md) |
| **Native AOT** | .NET 8+ | Full parallelization | Most attributes | Limited feature set; see [Native AOT sample](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/NativeAotRunner) |
| **Browser WebAssembly** | .NET 10+ custom host | Single-threaded | Limited | Custom Microsoft.Testing.Platform host support starts with MSTest 4.4 |

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

Use VSTest for classic UWP and modern .NET UWP because both run in an AppContainer. For a modern .NET UWP setup, see the [BlankUwpNet9App sample](https://github.com/microsoft/testfx/tree/main/samples/public/BlankUwpNet9App).

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

To configure unpackaged or packaged full-trust WinUI 3 tests, see [Test WinUI 3 apps with MSTest and MTP](unit-testing-mstest-winui.md).

Starting with MSTest 4.4, Microsoft.Testing.Platform also supports unpackaged WinUI test applications. VSTest doesn't support this scenario. For setup details, see the [unpackaged WinUI sample](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/MSTestRunnerWinUIUnpackaged).

#### Native AOT

Native AOT compilation is supported with some limitations due to reduced reflection capabilities. Use source generators where possible and test your AOT scenarios with the [NativeAotRunner sample](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/NativeAotRunner).

#### Browser WebAssembly

Starting with MSTest 4.4, a custom .NET 10 browser WebAssembly host can call `AddMSTest` to run tests from a referenced MSTest assembly. In the host project, set `EnableMSTestRunner` to `true` and `GenerateTestingPlatformEntryPoint` to `false` so the custom host owns the application entry point. Keep the MSTest and Microsoft.Testing.Platform package versions aligned.

On a single-threaded WebAssembly runtime, MSTest can't interrupt timed-out tests, and debugger launch options aren't supported. For a complete host, see the [BrowserPlayground sample](https://github.com/microsoft/testfx/tree/main/samples/BrowserPlayground).

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
> MSTest 4.4 is under development as of August 2026. Features marked as introduced in MSTest 4.4 require a preview build until version 4.4.0 is released.

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
- [Test WinUI 3 apps](unit-testing-mstest-winui.md)
- [Configure MSTest](unit-testing-mstest-configure.md)
- [MSTest code analyzers](mstest-analyzers/overview.md)
