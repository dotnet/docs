---
title: MSTest samples and tutorials
description: Explore MSTest sample projects and tutorials covering data-driven testing, parallel execution, platform-specific testing, and more.
author: Evangelink
ms.author: amauryleve
ms.date: 07/15/2025
---

# MSTest samples and tutorials

Learn MSTest through practical examples and tutorials. This page provides links to official sample projects and tutorials covering various MSTest features and scenarios.

## Language-specific tutorials

Get started with MSTest in your preferred .NET language:

| Language | Tutorial | Description |
|----------|----------|-------------|
| C# | [C# unit testing with MSTest](unit-testing-csharp-with-mstest.md) | Create your first C# test project and write basic tests |
| F# | [F# unit testing with MSTest](unit-testing-fsharp-with-mstest.md) | Test F# code with MSTest |
| Visual Basic | [VB unit testing with MSTest](unit-testing-visual-basic-with-mstest.md) | Test Visual Basic code with MSTest |

## Official sample projects

The MSTest team maintains sample projects in the [microsoft/testfx repository](https://github.com/microsoft/testfx/tree/main/samples) demonstrating various features and scenarios.

### Getting started samples

| Sample | Description | Link |
|--------|-------------|------|
| **Simple1** | Basic MSTest runner setup | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/Simple1) |
| **DemoMSTestSdk** | MSTest SDK project setup | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/DemoMSTestSdk) |
| **EnsureTestFramework** | Verify test framework configuration | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/EnsureTestFramework) |

### Platform-specific samples

| Sample | Description | Link |
|--------|-------------|------|
| **BlankUwpNet9App** | UWP testing with .NET 9 | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/BlankUwpNet9App) |
| **BlankWinUINet9App** | WinUI 3 testing with .NET 9 | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/BlankWinUINet9App) |
| **MSTestRunnerWinUI** | MSTest runner with WinUI | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/MSTestRunnerWinUI) |
| **NativeAotRunner** | Native AOT compilation | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/NativeAotRunner) |

### Advanced scenarios

| Sample | Description | Link |
|--------|-------------|------|
| **MSTestProjectWithExplicitMain** | Custom entry point for tests | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/MSTestProjectWithExplicitMain) |
| **RunInDocker** | Containerized test execution | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/RunInDocker) |
| **MTPOTel** | OpenTelemetry integration | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/MTPOTel) |
| **runner_vs_vstest** | Compare MSTest runner vs VSTest | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/runner_vs_vstest) |

## Feature-based learning

Use these guides to learn specific MSTest features:

### Data-driven testing

Run tests with multiple inputs:

- [Data-driven testing guide](unit-testing-mstest-writing-tests-data-driven.md)
- Key features: `DataRow`, `DynamicData`, `TestDataRow`

```csharp
[TestClass]
public class DataDrivenExample
{
    [TestMethod]
    [DataRow(1, 2, 3)]
    [DataRow(0, 0, 0)]
    [DataRow(-1, 1, 0)]
    public void Add_ReturnCorrectSum(int a, int b, int expected)
    {
        Assert.AreEqual(expected, a + b);
    }
}
```

### Test lifecycle

Manage setup and cleanup:

- [Test lifecycle guide](unit-testing-mstest-writing-tests-lifecycle.md)
- Key features: `AssemblyInitialize`, `ClassInitialize`, `TestInitialize`

```csharp
[TestClass]
public class LifecycleExample
{
    private static HttpClient? _client;

    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        _client = new HttpClient();
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        _client?.Dispose();
    }

    [TestMethod]
    public async Task ApiCall_ReturnsSuccess()
    {
        var response = await _client!.GetAsync("https://example.com");
        Assert.IsTrue(response.IsSuccessStatusCode);
    }
}
```

### Parallel execution

Improve test execution time:

- [Test execution and control guide](unit-testing-mstest-writing-tests-execution-control.md)
- Key features: `Parallelize`, `DoNotParallelize`

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]

[TestClass]
public class ParallelExample
{
    [TestMethod]
    public void Test1() { /* Runs in parallel */ }

    [TestMethod]
    public void Test2() { /* Runs in parallel */ }

    [TestMethod]
    [DoNotParallelize]
    public void Test3() { /* Runs isolated */ }
}
```

### Test organization

Filter and categorize tests:

- [Test organization guide](unit-testing-mstest-writing-tests-organization.md)
- Key features: `TestCategory`, `TestProperty`, `Priority`

```csharp
[TestClass]
public class OrganizationExample
{
    [TestMethod]
    [TestCategory("Integration")]
    [Priority(1)]
    [Owner("team-api")]
    public void IntegrationTest()
    {
        // Filter: dotnet test --filter TestCategory=Integration
    }
}
```

## Additional resources

### Documentation

- [MSTest overview](unit-testing-mstest-intro.md)
- [Configure MSTest](unit-testing-mstest-configure.md)
- [MSTest analyzers](mstest-analyzers/overview.md)
- [Microsoft.Testing.Platform](unit-testing-mstest-runner-intro.md)

### Migration guides

- [Migrate from MSTest v1 to v3](unit-testing-mstest-migration-from-v1-to-v3.md)
- [Migrate from MSTest v3 to v4](unit-testing-mstest-migration-v3-v4.md)
- [Migrate from VSTest to Microsoft.Testing.Platform](migrating-vstest-microsoft-testing-platform.md)

### External resources

- [MSTest GitHub repository](https://github.com/microsoft/testfx)
- [MSTest discussions](https://github.com/microsoft/testfx/discussions)
- [Report issues](https://github.com/microsoft/testfx/issues)
- [NuGet packages](https://www.nuget.org/packages?q=mstest)

## See also

- [Unit testing best practices](unit-testing-best-practices.md)
- [Run selective unit tests](selective-unit-tests.md)
- [Order unit tests](order-unit-tests.md)
- [Unit test code coverage](unit-testing-code-coverage.md)
