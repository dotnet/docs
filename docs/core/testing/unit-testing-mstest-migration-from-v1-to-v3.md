---
title: MSTest migration to v3
description: Learn about migrating from legacy MSTest (MSTest v1) to latest MSTest (MSTest v3).
author: engyebrahim
ms.author: enjieid
ms.date: 11/06/2024
ms.topic: upgrade-and-migration-article
---

# MSTest v3 migration guide

This guide assists users in upgrading their MSTest projects from MSTest v1 to MSTest v3. MSTest v3 introduces significant new features, optimizations, and some breaking changes to improve test reliability, execution speed, and compatibility with modern .NET frameworks.

### Who is impacted?

This guide is intended for projects currently **.NET Framework projects** using MSTest v1 via either:

- **Assembly references**: Projects referencing `Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll` directly.
- **NuGet packages**: Projects using `MSTest.TestFramework` NuGet package with version 1.0.0-1.4.0.

If your project relies on MSTest for unit testing and includes the above references, it will benefit from the improvements in MSTest v3 and requires adjustments outlined in this guide.

### Why migrate to MSTest v3?

Even if you’re satisfied with your current MSTest setup, upgrading to MSTest v3 unlocks substantial advantages that improve both the quality and future-readiness of your tests. Here’s why making the switch now can be a valuable step forward:

- **Enhanced security**: MSTest v1 has known security vulnerabilities. With MSTest v3, we’ve implemented extensive security improvements to safeguard your testing environment.
- **Immediate Performance Boosts**: MSTest v3 significantly reduces test execution time and optimizes resource usage. This is particularly beneficial in CI/CD pipelines, where faster tests can shorten deployment cycles and cut infrastructure costs.

- **Future-Proofing Your Tests**: MSTest v3 offers robust support for modern .NET versions, including .NET 8, and future iterations, along with cross-platform compatibility. This means your tests will be more adaptable and ready for upgrades, avoiding the technical debt of outdated testing frameworks.

- **Increased Code Reliability with New Analyzers**: MSTest v3 built-in code analyzers enforce best practices, helping to catch issues early and promoting cleaner, more maintainable test code:
  - **Proactive Issue Detection**: The analyzers provide real-time feedback, suggesting improvements and flagging potential issues as you write your tests.
  
  - **Stronger Type-Safe Assertions**: Replacing ambiguous overloads, MSTest v3 enforces type-safe assertions, reducing the risk of incorrect test behavior and making tests more reliable.
  - **Cleaner Code, Less Maintenance**: By aligning your tests with MSTest standards and best practices, MSTest v3 helps you maintain a cleaner, more manageable codebase, reducing technical debt over time.

- **Greater Flexibility and Extensibility**: MSTest v3 supports advanced testing scenarios, including dynamic data sources and in-assembly parallel execution. This flexibility enables more sophisticated testing approaches and speeds up test suites without complex configurations.

By upgrading, you’re setting up your tests to be faster, more reliable, and adaptable to future .NET developments, positioning your project for long-term success and easier maintenance.

## Migration steps

### 1. Remove assembly reference

For projects using MSTest v1 through assembly references, there are a reference to the following DLL:

- `Microsoft.VisualStudio.QualityTools.UnitTestFramework`

In non-SDK style projects, these references are often added through Visual Studio rather than by directly editing the XML. To remove these references using the Visual Studio GUI:

1. **Open Solution Explorer** in Visual Studio.
2. **Expand the project node** for the project using MSTest.
3. Locate the **References** folder within the project.
4. Inside the **References** folder, **find and select** the MSTest DLL references, `Microsoft.VisualStudio.QualityTools.UnitTestFramework`
5. **Right-click** the selected reference(s) and choose **Remove** from the context menu.

    ![image](https://github.com/user-attachments/assets/7aff1afb-e26b-4450-bc2e-903a577e3df2)

6. **Save the project** to apply changes.

### 2. Update your project

You can update your project to MSTest v3 in one of two ways:

- **Update Packages**: If you have NuGet package references to the [MSTest.TestFramework](https://www.nuget.org/packages/MSTest.TestFramework) and the [MSTest.TestAdapter](https://www.nuget.org/packages/MSTest.TestAdapter/), update them using the NuGet Package Manager in Visual Studio or by running the following command in the NuGet Package Manager Console:

    ```shell
    Update-Package MSTest.TestFramework -Version 3.6.2
    Update-Package MSTest.TestAdapter -Version 3.6.2
    ```

- **Or Install MSTest Package**: Install the latest [MSTest](https://www.nuget.org/packages/MSTest) package using the NuGet Package Manager in Visual Studio or by running the following command in the NuGet Package Manager Console:

    ```shell
    Install-Package MSTest -Version 3.6.2
    ```

- **Or update the project file directly** (for SDK-style projects): Update your `.csproj` file to specify the MSTest SDK version.

    ```xml
    <Project Sdk="MSTest.Sdk/3.6.2">
      <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
      </PropertyGroup>
    </Project>
    ```

Choose the option that best suits your project setup. Both methods ensure your project is upgraded to use MSTest v3.

### 3. Update your code

- **Assert.AreEqual/AreNotEqual or Assert.AreSame/AreNotSame (with object)**
  If one of these assertions causes errors, we recommend verifying that the types being compared are compatible. If they are, consider adding explicit generic typing to resolve the issue.

- **using generics**:

    ```csharp
    Assert.AreEqual<customObject>(expectedObject, actualObject);
    Assert.AreNotEqual<customObject>(expectedObject, actualObject);
    ```

- **Test Initialization**: Use `TestInitialize` methods for async initialization.
- **Cleanup**: Use `TestCleanup` methods or the `Dispose` pattern for cleanup.
- **RunSettings**: The `.testsettings` file is no longer supported, meaning `<LegacySettings>` is also no longer available. Use [.runsettings](/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file) for test configuration.

## New Features in MSTest v3

- Improved defaults for test projects
- Simplified setup and usage
- Enhanced extensibility of the MSTest runner
- New Roslyn-based code analyzers for improved test development
- Support for WinUI applications
- In-assembly parallel execution
- Dynamic data sources for data-driven tests

## Deprecated Features

- Dropped support for:
  - **.NET Framework 4.5** (use .NET 4.6.2 or higher)
  - **.NET Standard 1.0** (use .NET Standard 2.0)
  - **UWP versions before 16299**
  - **WinUI versions before 18362**
  - **.NET 5** (use .NET Core 3.1 or .NET 6)

## Breaking Changes and Removed APIs

### Assertion overloads

If AreEqual, AreNotEqual, AreSame, or AreNotSame assertions cause errors, we recommend checking that the types being compared are compatible. If they are, consider adding explicit generic typing to resolve the issue.

### `DataRowAttribute` updates

The DataRowAttribute constructors in MSTest v3 have been simplified to enforce type matching for parameters. This means you must specify values in DataRow that precisely match the types of the method parameters.

**Example**:

```csharp
[TestMethod]
[DataRow(1, "test")] // Correct: matches parameter types (int, string)
public void MyTestMethod(int number, string text) { ... }
```

In cases where types don’t match exactly, MSTest v3 will now raise an error rather than attempting a conversion.

### Timeout settings

In MSTest v3, the handling of `Timeout` settings has been standardized to ensure consistent behavior across different .NET environments. This change may impact tests that rely on specific timeout values, especially if those tests are asynchronous or run under different frameworks.

- In MSTest v1 or v2, certain timeout settings might have been interpreted differently depending on the framework (e.g., .NET Framework vs. .NET Core).
- MSTest v3 enforces consistent timeout behavior, which might mean that tests configured with timeouts in previous versions may fail or behave differently if the timeout values are too short under the new standard.

**What This Means**:

- **Tests with Timeouts Might Need Adjustment**: If your tests have a `Timeout` attribute with specific durations, verify that those values still allow the test to complete under MSTest v3. Tests that previously passed with a certain timeout might need a higher or lower timeout value to work correctly under the new rules.

- **Unified Timeout Handling**: MSTest v3 unified timeout handling makes timeouts more predictable, but requires checking and potentially updating `Timeout` values in older tests.

**Example**:

```csharp
// Old (v1/v2) - Timeout was sometimes interpreted inconsistently
[TestMethod]
[Timeout(2000)] // Timeout in milliseconds
public void TestMethod() { ... }

// New (v3) - Unified handling of timeout
[TestMethod]
[Timeout(2000)] // Verify this value still works under MSTest v3
public async Task TestMethod() { ... } 
```

## Configuration changes

Ensure that `.runsettings` files align with MSTest v3 syntax and structure.

## Parallel execution and performance optimization

Configure parallel execution in _.runsettings_ to improve performance.

**Example**:

```xml
<RunSettings>
  <RunConfiguration>
    <MaxCpuCount>-1</MaxCpuCount> <!-- Uses all available processors -->
  </RunConfiguration>
</RunSettings>
```

### Improved resource usage

MSTest v3 optimizes resource management, resulting in lower memory usage and better CPU efficiency.

## Handling obsolete attributes and migrating custom extensions

Review deprecated attributes, and replace them with MSTest v3 alternatives where possible.

## Code analyzers and best practices

MSTest v3 includes built-in code analyzers for best practices, avoiding configuration pitfalls, and proper use of MSTest attributes and settings. This is automatically available when using MSTest package or MSTest.Sdk, and starting with MSTest 3.7, MSTest.Analyzers is a transitive dependency of MSTest.TestFramework.

## Additional resources

- [Microsoft.Testing.Platform overview](microsoft-testing-platform-intro.md)
