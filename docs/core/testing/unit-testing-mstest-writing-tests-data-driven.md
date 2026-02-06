---
title: Data-driven testing in MSTest
description: Learn how to use data-driven testing in MSTest with DataRow, DynamicData, and TestDataRow to run the same test with multiple inputs.
author: Evangelink
ms.author: amauryleve
ms.date: 02/05/2026
---

# Data-driven testing in MSTest

Data-driven testing lets you run the same test method with multiple sets of input data. Instead of writing separate test methods for each test case, define your test logic once and supply different inputs through attributes or external data sources.

## Overview

MSTest provides several attributes for data-driven testing:

| Attribute | Use case | Best for |
|-----------|----------|----------|
| [`DataRow`](#datarowattribute) | Inline test data | Simple, static test cases |
| [`DynamicData`](#dynamicdataattribute) | Data from methods, properties, or fields | Complex or computed test data |
| [`TestDataRow<T>`](#testdatarow) | Enhanced data with metadata | Test cases needing display names or categories |
| [`DataSource`](#datasourceattribute) | External data files or databases | Legacy scenarios with external data sources |
| [`ITestDataSource`](#itestdatasource) | Custom data source attributes | Fully custom data-driven scenarios |

> [!TIP]
> For combinatorial testing (testing all combinations of multiple parameter sets), use the open-source [Combinatorial.MSTest](https://www.nuget.org/packages/Combinatorial.MSTest) NuGet package. This community-maintained package is [available on GitHub](https://github.com/Youssef1313/Combinatorial.MSTest) but isn't maintained by Microsoft.

## `DataRowAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute> allows you to run the same test method with multiple different inputs. Apply one or multiple `DataRow` attributes to a test method, and combine it with the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute>.

The number and types of arguments must exactly match the test method signature.

### Basic usage

```csharp
[TestClass]
public class CalculatorTests
{
    [TestMethod]
    [DataRow(1, 2, 3)]
    [DataRow(0, 0, 0)]
    [DataRow(-1, 1, 0)]
    [DataRow(100, 200, 300)]
    public void Add_ReturnsCorrectSum(int a, int b, int expected)
    {
        var calculator = new Calculator();
        Assert.AreEqual(expected, calculator.Add(a, b));
    }
}
```

### Supported argument types

`DataRow` supports various argument types including primitives, strings, arrays, and null values:

```csharp
[TestClass]
public class DataRowExamples
{
    [TestMethod]
    [DataRow(1, "message", true, 2.0)]
    public void TestWithMixedTypes(int i, string s, bool b, float f)
    {
        // Test with different primitive types
    }

    [TestMethod]
    [DataRow(new string[] { "line1", "line2" })]
    public void TestWithArray(string[] lines)
    {
        Assert.AreEqual(2, lines.Length);
    }

    [TestMethod]
    [DataRow(null)]
    public void TestWithNull(object o)
    {
        Assert.IsNull(o);
    }

    [TestMethod]
    [DataRow(new string[] { "a", "b" }, new string[] { "c", "d" })]
    public void TestWithMultipleArrays(string[] input, string[] expected)
    {
        // Starting with MSTest v3, two arrays don't need wrapping
    }
}
```

### Using params for variable arguments

Use the `params` keyword to accept a variable number of arguments:

```csharp
[TestClass]
public class ParamsExample
{
    [TestMethod]
    [DataRow(1, 2, 3, 4)]
    [DataRow(10, 20)]
    [DataRow(5)]
    public void TestWithParams(params int[] values)
    {
        Assert.IsTrue(values.Length > 0);
    }
}
```

### Custom display names

Set the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute.DisplayName> property to customize how test cases appear in Test Explorer:

```csharp
[TestClass]
public class DisplayNameExample
{
    [TestMethod]
    [DataRow(1, 2, DisplayName = "Functional Case FC100.1")]
    [DataRow(3, 4, DisplayName = "Edge case: small numbers")]
    public void TestMethod(int i, int j)
    {
        Assert.IsTrue(i < j);
    }
}
```

> [!TIP]
> For more control over test metadata, consider using [TestDataRow\<T>](#testdatarow) with `DynamicData`. `TestDataRow<T>` supports display names along with test categories and ignore messages for individual test cases.

### Ignoring specific test cases

Starting with MSTest v3.8, use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute.IgnoreMessage> property to skip specific data rows:

```csharp
[TestClass]
public class IgnoreDataRowExample
{
    [TestMethod]
    [DataRow(1, 2)]
    [DataRow(3, 4, IgnoreMessage = "Temporarily disabled - bug #123")]
    [DataRow(5, 6)]
    public void TestMethod(int i, int j)
    {
        // Only the first and third data rows run
        // The second is skipped with the provided message
    }
}
```

### Custom DataRow attributes

Create specialized `DataRow` attributes by inheriting from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute>:

```csharp
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class MyCustomDataRowAttribute : DataRowAttribute
{
    public MyCustomDataRowAttribute(params object[] data) : base(data)
    {
        // Add custom logic if needed
    }
}

[TestClass]
public class CustomDataRowExample
{
    [TestMethod]
    [MyCustomDataRow(1, 2)]
    [MyCustomDataRow(3, 4)]
    public void TestMethod(int i, int j)
    {
        Assert.IsTrue(i < j);
    }
}
```

> [!TIP]
> Related analyzer: [MSTEST0014](mstest-analyzers/mstest0014.md) detects type mismatches between `DataRow` arguments and method parameters.

## `DynamicDataAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute> lets you provide test data from methods, properties, or fields. Use this attribute when test data is complex, computed dynamically, or too verbose for inline `DataRow` attributes.

### Supported data source types

The data source can return any `IEnumerable<T>` where `T` is one of the types listed in the following table. Any collection implementing `IEnumerable<T>` works, including `List<T>`, arrays like `T[]`, or custom collection types. Choose based on your needs:

| Return type | Type safety | Metadata support | Best for |
|-------------|-------------|------------------|----------|
| `ValueTuple` (for example, `(int, string)`) | Compile-time | No | Most scenarios - simple syntax with full type checking |
| `Tuple<...>` | Compile-time | No | When you can't use `ValueTuple` |
| `TestDataRow<T>` | Compile-time | Yes | Test cases needing display names, categories, or ignore messages |
| `object[]` | Runtime only | No | Legacy code - avoid for new tests |

> [!TIP]
> For new test data methods, use `ValueTuple` for simple cases or `TestDataRow<T>` when you need metadata. Avoid `object[]` because it lacks compile-time type checking and can cause runtime errors from type mismatches.

### Data sources

The data source can be a method, property, or field. All three are interchangeable—choose based on your preference:

```csharp
[TestClass]
public class DynamicDataExample
{
    // Method - best for computed or yielded data
    public static IEnumerable<(int Value, string Name)> GetTestData()
    {
        yield return (1, "first");
        yield return (2, "second");
    }

    // Property - concise for static data
    public static IEnumerable<(int Value, string Name)> TestDataProperty =>
    [
        (1, "first"),
        (2, "second")
    ];

    // Field - simplest for static data
    public static IEnumerable<(int Value, string Name)> TestDataField =
    [
        (1, "first"),
        (2, "second")
    ];

    [TestMethod]
    [DynamicData(nameof(GetTestData))]
    public void TestWithMethod(int value, string name)
    {
        Assert.IsTrue(value > 0);
    }

    [TestMethod]
    [DynamicData(nameof(TestDataProperty))]
    public void TestWithProperty(int value, string name)
    {
        Assert.IsTrue(value > 0);
    }

    [TestMethod]
    [DynamicData(nameof(TestDataField))]
    public void TestWithField(int value, string name)
    {
        Assert.IsTrue(value > 0);
    }
}
```

> [!NOTE]
> Data source methods, properties, and fields must be `public static` and return an `IEnumerable<T>` of a supported type.

> [!TIP]
> Related analyzer: [MSTEST0018](mstest-analyzers/mstest0018.md) validates that the data source exists, is accessible, and has the correct signature.

### Data source from a different class

Specify a different class using the type parameter:

```csharp
public class TestDataProvider
{
    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 1, "first" };
        yield return new object[] { 2, "second" };
    }
}

[TestClass]
public class DynamicDataExternalExample
{
    [TestMethod]
    [DynamicData(nameof(TestDataProvider.GetTestData), typeof(TestDataProvider))]
    public void TestMethod(int value1, string value2)
    {
        Assert.IsTrue(value1 > 0);
    }
}
```

### Custom display names

Customize test case display names using the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute.DynamicDataDisplayName> property:

```csharp
using System.Reflection;

[TestClass]
public class DynamicDataDisplayNameExample
{
    [TestMethod]
    [DynamicData(nameof(GetTestData), DynamicDataDisplayName = nameof(GetDisplayName))]
    public void TestMethod(int value1, string value2)
    {
        Assert.IsTrue(value1 > 0);
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 1, "first" };
        yield return new object[] { 2, "second" };
    }

    public static string GetDisplayName(MethodInfo methodInfo, object[] data)
    {
        return $"{methodInfo.Name} with value {data[0]} and '{data[1]}'";
    }
}
```

> [!NOTE]
> The display name method must be `public static`, return a `string`, and accept two parameters: `MethodInfo` and `object[]`.

> [!TIP]
> For a simpler approach to custom display names, consider using [TestDataRow\<T>](#testdatarow) with its `DisplayName` property instead of a separate method.

### Ignoring all test cases from a data source

Starting with MSTest v3.8, use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute.IgnoreMessage> to skip all test cases:

```csharp
[TestClass]
public class IgnoreDynamicDataExample
{
    [TestMethod]
    [DynamicData(nameof(GetTestData), IgnoreMessage = "Feature not ready")]
    public void TestMethod(int value1, string value2)
    {
        // All test cases from GetTestData are skipped
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 1, "first" };
        yield return new object[] { 2, "second" };
    }
}
```

> [!TIP]
> To ignore individual test cases, use `TestDataRow<T>` with its `IgnoreMessage` property. See the [TestDataRow\<T>](#testdatarow) section.

> [!TIP]
> Related analyzers:
>
> - [MSTEST0018](mstest-analyzers/mstest0018.md) - validates `DynamicData` source exists and is accessible.
> - [MSTEST0042](mstest-analyzers/mstest0042.md) - ensures `DynamicData` returns the correct type.

## TestDataRow

The `TestDataRow<T>` class provides enhanced control over test data in data-driven tests. Use `IEnumerable<TestDataRow<T>>` as your data source return type to specify:

- **Custom display names**: Set a unique display name per test case
- **Test categories**: Attach metadata to individual test cases
- **Ignore messages**: Skip specific test cases with reasons
- **Type-safe data**: Use generics for strongly-typed test data

### Basic usage

```csharp
[TestClass]
public class TestDataRowExample
{
    [TestMethod]
    [DynamicData(nameof(GetTestDataRows))]
    public void TestMethod(int value1, string value2)
    {
        Assert.IsTrue(value1 > 0);
    }

    public static IEnumerable<TestDataRow> GetTestDataRows()
    {
        yield return new TestDataRow((1, "first"))
        {
            DisplayName = "Test Case 1: Basic scenario",
        };

        yield return new TestDataRow((2, "second"))
        {
            DisplayName = "Test Case 2: Edge case",
            TestCategories = ["HighPriority", "Critical"],
        };

        yield return new TestDataRow((3, "third"))
        {
            IgnoreMessage = "Not yet implemented",
        };
    }
}
```

## `DataSourceAttribute`

> [!NOTE]
> `DataSource` is only available in .NET Framework. For .NET (Core) projects, use `DataRow` or `DynamicData` instead.

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataSourceAttribute> connects tests to external data sources like CSV files, XML files, or databases.

For detailed information, see:

- [Create a data-driven unit test](/visualstudio/test/how-to-create-a-data-driven-unit-test)
- [Use a configuration file to define a data source](/visualstudio/test/walkthrough-using-a-configuration-file-to-define-a-data-source)

## `ITestDataSource`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ITestDataSource> interface lets you create completely custom data source attributes. Implement this interface when you need behavior that the built-in attributes don't support, such as generating test data based on environment variables, configuration files, or other runtime conditions.

### Interface members

The interface defines two methods:

| Method | Purpose |
|--------|--------|
| `GetData(MethodInfo)` | Returns test data as `IEnumerable<object?[]>` |
| `GetDisplayName(MethodInfo, object?[]?)` | Returns the display name for a test case |

### Creating a custom data source attribute

To create a custom data source, define an attribute class that inherits from `Attribute` and implements `ITestDataSource`:

```csharp
using System.Globalization;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class MyDataSourceAttribute : Attribute, ITestDataSource
{
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
    {
        // Return test data based on your custom logic
        yield return [1, "first"];
        yield return [2, "second"];
        yield return [3, "third"];
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
    {
        return data is null
            ? null
            : string.Format(CultureInfo.CurrentCulture, "{0} ({1})", methodInfo.Name, string.Join(",", data));
    }
}

[TestClass]
public class CustomDataSourceExample
{
    [TestMethod]
    [MyDataSource]
    public void TestWithCustomDataSource(int value, string name)
    {
        Assert.IsTrue(value > 0);
        Assert.IsNotNull(name);
    }
}
```

### Real-world example: Environment-based test data

This example shows a custom attribute that generates test data based on target frameworks, filtering based on the operating system:

```csharp
using System.Globalization;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class TargetFrameworkDataAttribute : Attribute, ITestDataSource
{
    private readonly string[] _frameworks;

    public TargetFrameworkDataAttribute(params string[] frameworks)
    {
        _frameworks = frameworks;
    }

    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
    {
        bool isWindows = OperatingSystem.IsWindows();

        foreach (string framework in _frameworks)
        {
            // Skip .NET Framework on non-Windows platforms
            if (!isWindows && framework.StartsWith("net4", StringComparison.Ordinal))
            {
                continue;
            }

            yield return [framework];
        }
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
    {
        return data is null
            ? null
            : string.Format(CultureInfo.CurrentCulture, "{0} ({1})", methodInfo.Name, data[0]);
    }
}

[TestClass]
public class CrossPlatformTests
{
    [TestMethod]
    [TargetFrameworkData("net48", "net8.0", "net9.0")]
    public void TestOnMultipleFrameworks(string targetFramework)
    {
        // Test runs once per applicable framework
        Assert.IsNotNull(targetFramework);
    }
}
```

> [!TIP]
> For simple cases where you just need to customize display names or add metadata, consider using [TestDataRow\<T>](#testdatarow) with `DynamicData` instead of implementing `ITestDataSource`. Reserve custom `ITestDataSource` implementations for scenarios that require dynamic filtering or complex data generation logic.

## Unfolding strategy

Data-driven test attributes support the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestDataSourceUnfoldingStrategy> property, which controls how test cases appear in Test Explorer and TRX results. This property also determines whether you can run individual test cases independently.

### Available strategies

| Strategy | Behavior |
|----------|----------|
| `Auto` (default) | MSTest determines unfolding best strategy |
| `Unfold` | All test cases are expanded and shown individually |
| `Fold` | All test cases are collapsed into a single test node |

### When to change the strategy

For most scenarios, the default `Auto` behavior provides the best balance. Consider changing this setting only when you have specific requirements:

- Non-deterministic data sources
- Known limitations or bugs in MSTest
- Performance concerns with many test cases

### Example usage

```csharp
[TestClass]
public class UnfoldingExample
{
    [TestMethod(UnfoldingStrategy = TestDataSourceUnfoldingStrategy.Unfold)] // That's the default behavior
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(3)]
    public void TestMethodWithUnfolding(int value, string text)
    {
        // Each test case appears individually in Test Explorer
    }

    [TestMethod(UnfoldingStrategy = TestDataSourceUnfoldingStrategy.Fold)]
    [DynamicData(nameof(GetData))]
    public void TestMethodWithFolding(int value, string text)
    {
        // All test cases appear as a single collapsed node
    }

    public static IEnumerable<(int, string)> GetData()
    {
        yield return (1, "one");
        yield return (2, "two");
        yield return (3, "three");
    }
}
```

## Best practices

1. **Choose the right attribute**: Use `DataRow` for simple, inline data. Use `DynamicData` for complex or computed data.

1. **Name your test cases**: Use `DisplayName` to make test failures easier to identify.

1. **Keep data sources close**: Define data sources in the same class when possible for better maintainability.

1. **Use meaningful data**: Choose test data that exercises edge cases and boundary conditions.

1. **Consider combinatorial testing**: For testing parameter combinations, use the [Combinatorial.MSTest](https://www.nuget.org/packages/Combinatorial.MSTest) package.

## See also

- [Write tests in MSTest](unit-testing-mstest-writing-tests.md)
- [TestContext class](unit-testing-mstest-writing-tests-testcontext.md)
- [MSTEST0014: DataRow should be valid](mstest-analyzers/mstest0014.md)
- [MSTEST0018: DynamicData should be valid](mstest-analyzers/mstest0018.md)
- [MSTEST0042: Avoid duplicated 'DataRow' entries](mstest-analyzers/mstest0042.md)
- [MSTEST0052: Avoid passing an explicit 'DynamicDataSourceType' and use the default auto detect behavior](mstest-analyzers/mstest0052.md)
