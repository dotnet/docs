---
title: MSTest migration to v3
description: Migration guide.
author: engyebrahim
ms.author: enjieid
ms.date: 11/06/2024
---

# MSTest v3 migration guide

## Overview

This guide assists users in upgrading their MSTest projects from v0/v1 to MSTest v3. MSTest v3 introduces new features, improvements, and some breaking changes.

---

## Introduction and Motivation

Migrating to MSTest v3 offers several benefits:

- Improved test execution speeds and memory efficiency.
- Stricter validation for more reliable tests.
- Leveraging modern .NET features and cross-platform compatibility.

---

## Steps to Migrate

### 1. Remove Assembly Reference

Remove the `Microsoft.VisualStudio.QualityTools.UnitTestFramework` reference from your project.

```xml
<Reference Include="Microsoft.VisualStudio.QualityTools.UnitTestFramework, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
    <Private>False</Private>
</Reference>
```

### 2. Update Your Project

- **NuGet Package**: Install the latest [MSTest](https://www.nuget.org/packages/MSTest).
- **Project File**: Update your project file to use MSTest SDK.

```xml
<Project Sdk="MSTest.Sdk/3.3.1">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
</Project>
```

### 3. Update Your Code

- **Replace Deprecated Methods**: Update deprecated methods to newer versions.
  
  - **Assert.AreEqual/AreNotEqual (with object)** → Use generic versions.

    **Before** (deprecated):

    ```csharp
    Assert.AreEqual(expectedObject, actualObject);
    Assert.AreNotEqual(expectedObject, actualObject);
    ```

    **After** (using generics):

    ```csharp
    Assert.AreEqual<object>(expectedObject, actualObject);
    Assert.AreNotEqual<object>(expectedObject, actualObject);
    ```

  - **Assert.AreSame/AreNotSame (with object)** → Use generic versions.

    **Before** (deprecated):

    ```csharp
    Assert.AreSame(expectedObject, actualObject);
    Assert.AreNotSame(expectedObject, actualObject);
    ```

    **After** (using generics):

    ```csharp
    Assert.AreSame<object>(expectedObject, actualObject);
    Assert.AreNotSame<object>(expectedObject, actualObject);
    ```

- **Test Initialization**: Use `TestInitialize` methods for async initialization.
- **Cleanup**: Use `TestCleanup` methods or the `Dispose` pattern for cleanup.
- **RunSettings**: The `.testsettings` file is no longer supported, meaning `<LegacySettings>` is also no longer available. Use [.runsettings](https://learn.microsoft.com/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2022) for test configuration.

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

Timeout settings are standardized across frameworks in MSTest v3. Verify and adjust any timeout configurations in existing tests for compatibility.

---

## Configuration Changes

### Settings and Configuration Files

MSTest v3 supports both XML and JSON formats for configuration files.

1. **Verify Configurations**: Ensure that existing `.runsettings` files align with MSTest v3’s syntax and structure.
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

MSTest v3 includes built-in code analyzers for best practices, avoiding configuration pitfalls, and proper use of MSTest attributes and settings.

---

## Sample Code: Migration Example

### Before (MSTest v1)

```csharp
[TestMethod]
[Timeout(1000)]
[DataRow(1, "data")]
public void ExampleTestMethod(int number, string data) {
    Assert.AreEqual(number, Convert.ToInt32(data));
}
```

### After (MSTest v3)

```csharp
[TestMethod]
[Timeout(1000)]
[DataRow(1, "data")]
public void ExampleTestMethod(int number, string data) {
    Assert.AreEqual<int>(number, Convert.ToInt32(data));
}
```

---

## Additional Resources

- [New testin platform](https://learn.microsoft.com/dotnet/core/testing/unit-testing-platform-intro?tabs=dotnetcli)
