---
title: MSTest migration to v3
description: Learn about migrating from legacy MSTest (MSTest v1) to latest MSTest (MSTest v3).
author: engyebrahim
ms.author: enjieid
ms.date: 11/06/2024
---

# MSTest v3 migration guide

## Overview

This guide assists users in upgrading their MSTest projects from MSTest v1 to MSTest v3. MSTest v3 introduces significant new features, optimizations, and some breaking changes to improve test reliability, execution speed, and compatibility with modern .NET frameworks.

---

### Who Is Impacted?

This guide is intended for projects currently **.NET Framework projects** using MSTest v1 via either:

- **Assembly references**: Projects referencing `Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll` directly.
- **NuGet packages**: Projects using `MSTest.TestFramework` NuGet package with version 1.0.0-1.4.0.

If your project relies on MSTest for unit testing and includes the above references, it will benefit from the improvements in MSTest v3 and requires adjustments outlined in this guide.

---

### Why Migrate to MSTest v3?

Even if you’re satisfied with your current MSTest setup, upgrading to MSTest v3 unlocks substantial advantages that improve both the quality and future-readiness of your tests. Here’s why making the switch now can be a valuable step forward:

- **Enhanced security**: MSTest v1 has known security vulnerabilities. With MSTest v3, we’ve implemented extensive security improvements to safeguard your testing environment.
- **Immediate Performance Boosts**: MSTest v3 significantly reduces test execution time and optimizes resource usage. This is particularly beneficial in CI/CD pipelines, where faster tests can shorten deployment cycles and cut infrastructure costs.

- **Future-Proofing Your Tests**: MSTest v3 offers robust support for modern .NET versions, including .NET 6, .NET 7, and future iterations, along with cross-platform compatibility. This means your tests will be more adaptable and ready for upgrades, avoiding the technical debt of outdated testing frameworks.

- **Increased Code Reliability with New Analyzers**: MSTest v3 built-in code analyzers enforce best practices, helping to catch issues early and promoting cleaner, more maintainable test code:
  - **Proactive Issue Detection**: The analyzers provide real-time feedback, suggesting improvements and flagging potential issues as you write your tests.
  
  - **Stronger Type-Safe Assertions**: Replacing ambiguous overloads, MSTest v3 enforces type-safe assertions, reducing the risk of incorrect test behavior and making tests more reliable.
  - **Cleaner Code, Less Maintenance**: By aligning your tests with MSTest standards and best practices, MSTest v3 helps you maintain a cleaner, more manageable codebase, reducing technical debt over time.

- **Greater Flexibility and Extensibility**: MSTest v3 supports advanced testing scenarios, including dynamic data sources and in-assembly parallel execution. This flexibility enables more sophisticated testing approaches and speeds up test suites without complex configurations.

By upgrading, you’re setting up your tests to be faster, more reliable, and adaptable to future .NET developments, positioning your project for long-term success and easier maintenance.

---

## Steps to Migrate

### 1. Remove Assembly Reference

For projects using MSTest v1 through assembly references, it’s common to find references to either or both of the following DLLs:

- `Microsoft.VisualStudio.QualityTools.UnitTestFramework`
- `Microsoft.VisualStudio.TestPlatform.TestFramework`

In non-SDK style projects, these references are often added through Visual Studio rather than by directly editing the XML. To remove these references using the Visual Studio GUI:

1. **Open Solution Explorer** in Visual Studio.
2. **Right-click on the project** using MSTest and select **Properties**.
3. Navigate to the **References** tab.
4. Locate and **select the MSTest DLL references** (`Microsoft.VisualStudio.QualityTools.UnitTestFramework` and/or `Microsoft.VisualStudio.TestPlatform.TestFramework`).
5. **Right-click** the selected reference(s) and choose **Remove**.

For those comfortable editing XML directly, you can manually remove the references from your `.csproj` file as follows:

```xml
<Reference Include="Microsoft.VisualStudio.QualityTools.UnitTestFramework, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
    <Private>False</Private>
</Reference>
```

### 2. Update Your Project

You can update your project to MSTest v3 in one of two ways:

- **Install via NuGet Package** (for SDK-style projects): Install the latest [MSTest](https://www.nuget.org/packages/MSTest) package using the NuGet Package Manager in Visual Studio or by running the following command in the NuGet Package Manager Console:

    ```shell
    Install-Package MSTest-Version 3.6.2
    ```

- **Or update the project file directly**: Update your `.csproj` file to specify the MSTest SDK version.

    ```xml
    <Project Sdk="MSTest.Sdk/3.6.2">
      <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
      </PropertyGroup>
    </Project>
    ```

Choose the option that best suits your project setup. Both methods ensure your project is upgraded to use MSTest v3.

### 3. Update Your Code

- **Replace Deprecated Methods**: Update deprecated methods to newer versions.
  
  - **Assert.AreEqual/AreNotEqual (with object)** → Use generic versions.

    - **Before** (deprecated):

    ```csharp
    Assert.AreEqual(expectedObject, actualObject);
    Assert.AreNotEqual(expectedObject, actualObject);
    ```

    - **After (using generics)**:

    ```csharp
    Assert.AreEqual<object>(expectedObject, actualObject);
    Assert.AreNotEqual<object>(expectedObject, actualObject);
    ```

  - **Assert.AreSame/AreNotSame (with object)** → Use generic versions.

    - **Before** (deprecated):

    ```csharp
    Assert.AreSame(expectedObject, actualObject);
    Assert.AreNotSame(expectedObject, actualObject);
    ```

    - **After (using generics)**:

    ```csharp
    Assert.AreSame<object>(expectedObject, actualObject);
    Assert.AreNotSame<object>(expectedObject, actualObject);
    ```

- **Test Initialization**: Use `TestInitialize` methods for async initialization.
- **Cleanup**: Use `TestCleanup` methods or the `Dispose` pattern for cleanup.
- **RunSettings**: The `.testsettings` file is no longer supported, meaning `<LegacySettings>` is also no longer available. Use [.runsettings](https://learn.microsoft.com/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file) for test configuration.

---

## New Features in MSTest v3

- Improved defaults for test projects
- Simplified setup and usage
- Enhanced extensibility of the MSTest runner
- New Roslyn-based code analyzers for improved test development
- Support for WinUI applications
- In-assembly parallel execution
- Dynamic data sources for data-driven tests

---

## Deprecated Features

- Dropped support for:
  - **.NET Framework 4.5** (use .NET 4.6.2 or higher)
  - **.NET Standard 1.0** (use .NET Standard 2.0)
  - **UWP versions before 16299**
  - **WinUI versions before 18362**
  - **.NET 5** (use .NET Core 3.1 or .NET 6)

---

## Breaking Changes and Removed APIs

### Assertion Overloads

MSTest v3 removes certain `Assert` overloads that accept object types to promote type-safe assertions. Update tests using these overloads to specify types explicitly.

**Example**:

```csharp
// Old (v0/v1)
Assert.AreEqual(expected, actual); // both are objects

// New (v3)
Assert.AreEqual<int>(expectedInt, actualInt); // specify the type
```

### DataRowAttribute Updates

The `DataRowAttribute` constructors have been simplified in MSTest v3. Update parameterized tests using `DataRow` to align with the revised constructors.

**Example**:

```csharp
[TestMethod]
[DataRow(1, "test")]
public void MyTestMethod(int number, string text) { ... }
```

### Timeout Settings

In MSTest v3, the handling of `Timeout` settings has been standardized to ensure consistent behavior across different .NET environments. This change may impact tests that rely on specific timeout values, especially if those tests are asynchronous or run under different frameworks.

- In MSTest v1 or v2, certain timeout settings might have been interpreted differently depending on the framework (e.g., .NET Framework vs. .NET Core).
- MSTest v3 enforces consistent timeout behavior, which might mean that tests configured with timeouts in previous versions may fail or behave differently if the timeout values are too short under the new standard.

**What This Means**:

1. **Tests with Timeouts Might Need Adjustment**: If your tests have a `Timeout` attribute with specific durations, verify that those values still allow the test to complete under MSTest v3. Tests that previously passed with a certain timeout might need a higher or lower timeout value to work correctly under the new rules.

2. **Unified Timeout Handling**: MSTest v3 unified timeout handling makes timeouts more predictable, but requires checking and potentially updating `Timeout` values in older tests.

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

---

## Configuration Changes

### Settings and Configuration Files

MSTest v3 supports both XML and JSON formats for configuration files.

1. **Verify Configurations**: Ensure that existing `.runsettings` files align with MSTest v3 syntax and structure.
2. **Convert to JSON (if applicable)**: For JSON-based configurations, convert XML settings to JSON format.

---

## Parallel Execution and Performance Optimization

### New Parallelism Options

Configure parallel execution in `.runsettings` or JSON configuration files to improve performance.

**Example**:

```json
{
  "RunConfiguration": {
    "MaxCpuCount": -1 // Uses all available processors
  }
}
```

### Improved Resource Usage

MSTest v3 optimizes resource management, resulting in lower memory usage and better CPU efficiency.

---

## Handling Obsolete Attributes and Migrating Custom Extensions

Review deprecated attributes, such as `[DeploymentItem]`, and replace them with MSTest v3 alternatives where possible.

---

## Code Analyzers and Best Practices

MSTest v3 includes built-in code analyzers for best practices, avoiding configuration pitfalls, and proper use of MSTest attributes and settings. This is automatically available when using MSTest package or MSTest.Sdk.

---

## Sample Code: Migration Example

### Before (MSTest v1)

```csharp
[TestMethod]
[Timeout(1000)]
[DataRow(1, "data")]
public void ExampleTestMethod(int number, string data)
{
    Assert.AreEqual(number, Convert.ToInt32(data));
}
```

### After (MSTest v3)

```csharp
[TestMethod]
[Timeout(1000)]
[DataRow(1, "data")]
public void ExampleTestMethod(int number, string data)
{
    Assert.AreEqual<int>(number, Convert.ToInt32(data));
}
```

---

## Additional Resources

- [New testing platform](unit-testing-platform-intro.md)
