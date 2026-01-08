---
title: MSTest attributes
description: Learn about the various attributes of MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 05/30/2025
---

# MSTest attributes

MSTest uses custom attributes to identify and customize tests.

To help provide a clearer overview of the testing framework, this section organizes the members of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace into groups of related functionality.

> [!NOTE]
> Attributes, whose names end with "Attribute", can be used with or without "Attribute" at the end. Attributes that have parameterless constructor, can be written with or without parenthesis. The following code examples work identically:
>
> `[TestClass()]`
>
> `[TestClassAttribute()]`
>
> `[TestClass]`
>
> `[TestClassAttribute]`

## Attributes used to identify test classes and methods

Every test class must have the `TestClass` attribute, and every test method must have the `TestMethod` attribute.

### `TestClassAttribute`

The [TestClass](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute) attribute marks a class that contains tests and, optionally, initialize or cleanup methods.

This attribute can be extended to change or extend the default behavior.

Example:

```csharp
[TestClass]
public class MyTestClass
{
}
```

### `TestMethodAttribute`

The [TestMethod](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute) attribute is used inside a `TestClass` to define the actual test method to run.

The method should be an instance `public` method defined as `void`, `Task`, or `ValueTask` (starting with MSTest v3.3). It can optionally be `async` but should not be `async void`.

The method should have zero parameters, unless it's marked with the [DataRow](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute) attribute, the [DynamicData](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute) attribute, or a similar attribute that provides test case data to the test method.

Consider the following example test class:

```csharp
[TestClass]
public class MyTestClass
{
    [TestMethod]
    public void TestMethod()
    {
    }
}
```

### `DiscoverInternalsAttribute`

The [DiscoverInternals](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DiscoverInternalsAttribute) attribute is applied at the assembly level to enable MSTest to discover test classes and test methods that are declared as `internal` rather than `public`. By default, MSTest only discovers public test classes and methods. When this attribute is present, both public and internal tests are discovered.

This attribute is applied in the `AssemblyInfo.cs` file, the `MSTestSettings.cs` file or at the top of any file in the test assembly:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: DiscoverInternals]

namespace MyTests
{
    [TestClass]
    internal class InternalTestClass // This class will be discovered
    {
        [TestMethod]
        internal void InternalTestMethod() // This method will be discovered
        {
            Assert.IsTrue(true);
        }
    }
}
```

## Attributes used for data-driven testing

Use the following elements to set up data-driven tests. For more information, see [Create a data-driven unit test](/visualstudio/test/how-to-create-a-data-driven-unit-test) and [Use a configuration file to define a data source](/visualstudio/test/walkthrough-using-a-configuration-file-to-define-a-data-source).

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataSourceAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute>

> [!TIP]
> MSTest doesn't natively support combinatorial testing, but you can add this capability using the open-source [Combinatorial.MSTest](https://www.nuget.org/packages/Combinatorial.MSTest) NuGet package. It's actively maintained by the [community and available on GitHub](https://github.com/Youssef1313/Combinatorial.MSTest). This package isn't maintained by Microsoft.

### `DataRowAttribute`

The [DataRow](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute) attribute allows you to run the same test method with multiple different inputs. It can appear one or multiple times on a test method. It should be combined with the [TestMethod](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute) attribute.

The number and types of arguments must exactly match the test method signature. Consider the following example of a valid test class demonstrating the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute> usage with inline arguments that align to test method parameters:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DataRow(1, "message", true, 2.0)]
    public void TestMethod1(int i, string s, bool b, float f)
    {
        // Omitted for brevity.
    }

    [TestMethod]
    [DataRow(new string[] { "line1", "line2" })]
    public void TestMethod2(string[] lines)
    {
        // Omitted for brevity.
    }

    [TestMethod]
    [DataRow(null)]
    public void TestMethod3(object o)
    {
        // Omitted for brevity.
    }

    [TestMethod]
    [DataRow(new string[] { "line1", "line2" }, new string[] { "line1.", "line2." })]
    public void TestMethod4(string[] input, string[] expectedOutput)
    {
        // Omitted for brevity.
    }
}
```

> [!NOTE]
> You can also use the `params` feature to capture multiple inputs of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute>.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DataRow(1, 2, 3, 4)]
    public void TestMethod(params int[] values) {}
}
```

Examples of invalid combinations:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DataRow(1, 2)] // Not valid, we are passing 2 inline data but signature expects 1
    public void TestMethod1(int i) {}

    [TestMethod]
    [DataRow(1)] // Not valid, we are passing 1 inline data but signature expects 2
    public void TestMethod2(int i, int j) {}

    [TestMethod]
    [DataRow(1)] // Not valid, count matches but types do not match
    public void TestMethod3(string s) {}
}
```

> [!NOTE]
> Starting with MSTest v3, when you want to pass exactly 2 arrays, you no longer need to wrap the second array in an object array.
> _Before:_
> `[DataRow(new string[] { "a" }, new object[] { new string[] { "b" } })]`
> _Staring with v3:_
> `[DataRow(new string[] { "a" }, new string[] { "b" })]`

You can modify the display name used in Visual Studio and loggers for each instance of <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute> by setting the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute.DisplayName> property.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DataRow(1, 2, DisplayName = "Functional Case FC100.1")]
    public void TestMethod(int i, int j) {}
}
```

You can also create your own specialized `DataRow` attribute by inheriting the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute>.

```csharp
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class MyCustomDataRowAttribute : DataRowAttribute
{
}

[TestClass]
public class TestClass
{
    [TestMethod]
    [MyCustomDataRow(1)]
    public void TestMethod(int i) {}
}
```

Starting with MSTest v3.8, you can use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute.IgnoreMessage> property to conditionally ignore specific test cases:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DataRow(1, 2)]
    [DataRow(3, 4, IgnoreMessage = "Temporarily disabled")]
    [DataRow(5, 6)]
    public void TestMethod(int i, int j)
    {
        // Only the first and third data rows will run
        // The second data row is skipped with the provided message
    }
}
```

### `DynamicDataAttribute`

The [DynamicData](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute) attribute allows you to run the same test method with data provided by a field, a property, or a method. This is useful when you need to generate test data dynamically or when the test data is too complex to define inline with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute>.

The attribute requires the name of a field, a property, or method that provides the test data. The data source can return any of the following types:

- `IEnumerable<object[]>` - each `object[]` represents the arguments for one test case
- `IEnumerable<ValueTuple>` - each tuple represents the arguments for one test case (for example, `IEnumerable<(int, string)>`)
- `IEnumerable<Tuple<...>>` - each `Tuple` represents the arguments for one test case
- `IEnumerable<TestDataRow>` - provides additional control over test case metadata (see [TestDataRow](#testdatarow) subsection)

> [!NOTE]
> Any collection type that inherits from `IEnumerable<T>` works, not just `IEnumerable<T>` itself. For example, `List<object[]>`, `object[][]`, or custom collection types are all supported.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DynamicData(nameof(GetTestData))]
    public void TestMethod(int value1, string value2)
    {
        // Test implementation
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 1, "first" };
        yield return new object[] { 2, "second" };
        yield return new object[] { 3, "third" };
    }
}
```

By default, the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute> looks for the data source in the same class as the test method. You can specify a different class using the `DynamicDataSourceType` parameter:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DynamicData(nameof(TestDataProvider.GetTestData), typeof(TestDataProvider))]
    public void TestMethod(int value1, string value2)
    {
        // Test implementation
    }
}

public class TestDataProvider
{
    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 1, "first" };
        yield return new object[] { 2, "second" };
    }
}
```

You can also use properties or fields instead of methods:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void TestMethod(int value1, string value2)
    {
        // Test implementation
    }

    public static IEnumerable<object[]> TestData => new[]
    {
        new object[] { 1, "first" },
        new object[] { 2, "second" },
        new object[] { 3, "third" }
    };

    // Fields are also supported
    public static IEnumerable<object[]> TestDataField = new[]
    {
        new object[] { 10, "ten" },
        new object[] { 20, "twenty" }
    };
}
```

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute> also supports the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataDisplayName> property to customize how test cases appear in Test Explorer. You can specify the display name format using the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataDisplayNameDeclaringType> to reference a method that generates the display name:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DynamicData(nameof(GetTestData), DynamicDataDisplayName = nameof(GetDisplayName))]
    public void TestMethod(int value1, string value2)
    {
        // Test implementation
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 1, "first" };
        yield return new object[] { 2, "second" };
    }

    public static string GetDisplayName(MethodInfo methodInfo, object[] data)
    {
        return $"{methodInfo.Name} - {data[0]} and {data[1]}";
    }
}
```

> [!NOTE]
> The display name method must be `public static`, return a `string`, and accept two parameters: `MethodInfo` and `object[]`.

Starting with MSTest v3.8, you can use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute.IgnoreMessage> property to conditionally ignore all test cases generated by the dynamic data source:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DynamicData(nameof(GetTestData), IgnoreMessage = "Feature not ready")]
    public void TestMethod(int value1, string value2)
    {
        // All test cases from GetTestData will be skipped
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 1, "first" };
        yield return new object[] { 2, "second" };
    }
}
```

> [!NOTE]
> To ignore individual test cases when using <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute>, use the `TestDataRow` class with its `IgnoreMessage` property (see [TestDataRow](#testdatarow) section).

#### TestDataRow

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestDataRow> class provides enhanced control over test data in data-driven tests. When using `IEnumerable<TestDataRow<T>>` as the return type for your dynamic data source, you can specify additional metadata for each test case, such as custom display names and test properties.

`TestDataRow<T>` offers the following benefits:

- **Custom display names**: Set a unique display name for each test case using the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestDataRow.DisplayName> property.
- **Test properties**: Attach metadata to individual test cases using the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestDataRow.TestProperties> property.
- **Type-safe data**: Use the generic `TestDataRow<T>` to provide strongly-typed test data.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DynamicData(nameof(GetTestDataRows))]
    public void TestMethod(int value1, string value2)
    {
        // Test implementation
    }

    public static IEnumerable<TestDataRow> GetTestDataRows()
    {
        yield return new TestDataRow((1, "first"))
        {
            DisplayName = "Test Case 1: Basic scenario"
        };
        
        yield return new TestDataRow((2, "second"))
        {
            DisplayName = "Test Case 2: Edge case",
            TestProperties = { ["Priority"] = "High", ["Category"] = "Critical" }
        };
    }
}
```

### `UnfoldingStrategy` property

Data-driven test attributes like <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute> and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute> support the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.UnfoldingStrategy> property, which controls how test cases appear in Test Explorer and TRX results. This property also determines whether individual test cases can be run independently.

The `UnfoldingStrategy` property accepts the following values:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.UnfoldingStrategy.Auto?displayProperty=nameWithType> (default): MSTest automatically determines whether to unfold test cases based on the number of data rows. Test cases are collapsed (folded) when there are many data rows to avoid cluttering Test Explorer, and unfolded when there are few data rows for better visibility.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.UnfoldingStrategy.Unfold?displayProperty=nameWithType>: All test cases are expanded and shown individually in Test Explorer and TRX results. Each test case can be run independently.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.UnfoldingStrategy.Fold?displayProperty=nameWithType>: All test cases are collapsed into a single test node. Individual test cases can't be run independently; the entire data-driven test runs as one unit.

For most scenarios, the default `Auto` behavior provides the best balance between usability and performance. Changing this setting is considered an advanced scenario and should only be done when you have specific requirements, such as non-deterministic data source or known limitations or bugs of MSTest.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod(UnfoldingStrategy = UnfoldingStrategy.Unfold)] // Force unfolding/expanding
    [DataRow(1)] 
    [DataRow(2)]
    [DataRow(3)]
    public void TestMethodWithUnfolding(int value)
    {
        // Each test case appears individually in Test Explorer
    }

    [TestMethod(DynamicDataUnfoldingStrategy = UnfoldingStrategy.Fold)] // Force folding/collapsing
    [DynamicData(nameof(GetData))]
    public void TestMethodWithFolding(int value)
    {
        // All test cases appear as a single collapsed node
    }

    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] { 1 };
        yield return new object[] { 2 };
        yield return new object[] { 3 };
    }
}
```

## Attributes used to provide initialization and cleanups

Setup and cleanup that is common to multiple tests can be extracted to a separate method, and marked with one of the attributes listed below, to run it at appropriate time, for example before every test. For more information, see [Anatomy of a unit test](/previous-versions/ms182517(v=vs.110)).

### Assembly level

The [AssemblyInitialize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute) attribute is called right after your assembly is loaded and the [AssemblyCleanup](xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyCleanupAttribute) attribute is called right before your assembly is unloaded.

The methods marked with these attributes should be defined as `static void`, `static Task` or `static ValueTask` (starting with MSTest v3.3), in a class marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute>, and appear only once. The initialize part requires one parameter of type <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> and the cleanup either no parameters, or starting with MSTest 3.8 can have one parameter of type <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>.

```csharp
[TestClass]
public class MyTestClass
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext testContext)
    {
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup() // Starting with MSTest 3.8, it can be AssemblyCleanup(TestContext testContext)
    {
    }
}
```

### Class level

The [ClassInitialize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute) attribute is called right before your class is loaded (but after the static constructor) and the [ClassCleanup](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute) is called right after your class is unloaded.

> [!IMPORTANT]
> By default, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute> will be triggered after the last test of the assembly (similarly to <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyCleanupAttribute>). You can change this behavior by setting the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute.CleanupBehavior> on the attribute. Alternatively, you can set this behavior globally for the assembly using the assembly attribute <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupExecutionAttribute>.

It's also possible to control the inheritance behavior: only for current class using <xref:Microsoft.VisualStudio.TestTools.UnitTesting.InheritanceBehavior.None?displayProperty=nameWithType>, or for all derived classes using <xref:Microsoft.VisualStudio.TestTools.UnitTesting.InheritanceBehavior.BeforeEachDerivedClass?displayProperty=nameWithType>.

The methods marked with these attributes should be defined as `static void`, `static Task` or `static ValueTask` (starting with MSTest v3.3), in a `TestClass`, and appear only once. The initialize part requires one parameter of type <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> and the cleanup either no parameters, or starting with MSTest 3.8 can have one parameter of type <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>.

```csharp
[TestClass]
public class MyTestClass
{
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
    }

    [ClassCleanup]
    public static void ClassCleanup() // Starting with MSTest 3.8, it can be ClassCleanup(TestContext testContext)
    {
    }
}
```

### Test level

The [TestInitialize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute) attribute is called right before your test is started and the [TestCleanup](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute) is called right after your test is finished.

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute> is similar to the class constructor but is usually more suitable for long or async initializations. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute> is always called after the constructor and called for each test (including each entry of [data-driven tests](#attributes-used-for-data-driven-testing)).

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute> is similar to the class `Dispose` (or `DisposeAsync`) but is usually more suitable for long or async cleanups. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute> is always called just before the `DisposeAsync`/`Dispose` and called for each test (including each entry of [data-driven tests](#attributes-used-for-data-driven-testing)).

The methods marked with these attributes should be defined as `void`, `Task` or `ValueTask` (starting with MSTest v3.3), in a `TestClass`, be parameterless, and appear one or multiple times.

```csharp
[TestClass]
public class MyTestClass
{
    [TestInitialize]
    public void TestInitialize()
    {
    }

    [TestCleanup]
    public void TestCleanup()
    {
    }
}
```

### Global test level

The [GlobalTestInitialize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.GlobalTestInitializeAttribute) attribute is called right before every test method in the assembly and the [GlobalTestCleanup](xref:Microsoft.VisualStudio.TestTools.UnitTesting.GlobalTestCleanupAttribute) is called right after every test method in the assembly. These attributes were introduced in MSTest 3.10.0.

These attributes provide a way to define initialization and cleanup logic that applies to all test methods across the entire assembly, without having to add the same initialization/cleanup code in every test class.

The methods marked with these attributes must be defined as `public static void`, `static Task` or `static ValueTask`, in a class marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute>, must be non-generic, must have exactly one parameter of type <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>, and can appear multiple times across different test classes in the assembly.

```csharp
[TestClass]
public class MyTestClass
{
    [GlobalTestInitialize]
    public static void GlobalTestInitialize(TestContext testContext)
    {
        // This runs before every test method in the assembly
    }

    [GlobalTestCleanup]
    public static void GlobalTestCleanup(TestContext testContext)
    {
        // This runs after every test method in the assembly
    }
}
```

> [!NOTE]
> Multiple methods with these attributes in the assembly are allowed, but there is no guarantee of the order in which they will be executed. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute> isn't supported on methods with the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.GlobalTestInitializeAttribute>.

## Attributes used to control test execution

The following attributes can be used to modify the way tests are executed.

### Threading attributes

These attributes control the threading model for test execution.

#### `STATestClassAttribute`

When applied to a test class, the [STATestClass](xref:Microsoft.VisualStudio.TestTools.UnitTesting.STATestClassAttribute) attribute indicates that all test methods (and the `[ClassInitialize]` and `[ClassCleanup]` methods) in the class should be run in a single-threaded apartment (STA). This attribute is useful when the test methods interact with COM objects that require STA.

> [!NOTE]
> This is only supported on Windows and in version 3.6 and later.

#### `STATestMethodAttribute`

When applied to a test method, the [STATestMethod](xref:Microsoft.VisualStudio.TestTools.UnitTesting.STATestMethodAttribute) attribute indicates that the test method should be run in a single-threaded apartment (STA). This attribute is useful when the test method interacts with COM objects that require STA.

> [!NOTE]
> This is only supported on Windows and in version 3.6 and later.

#### `UITestMethodAttribute`

When applied to a test method, the `UITestMethod` attribute indicates that the test method should be scheduled on the UI thread of the platform. This attribute is specifically designed for testing UWP (Universal Windows Platform) and WinUI applications that require UI thread access.

This attribute is useful when testing UI components, controls, or any code that must run on the UI thread to interact with the application's visual elements.

```csharp
[TestClass]
public class MyUITestClass
{
    [UITestMethod]
    public void TestUIComponent()
    {
        // This test runs on the UI thread, allowing interaction with UI elements
        var button = new Button();
        Assert.IsNotNull(button);
    }
}
```

> [!NOTE]
> This attribute is available for UWP and WinUI applications and requires the appropriate MSTest adapter for these platforms.

### Parallelization attributes

These attributes control whether and how tests run in parallel.

#### `ParallelizeAttribute`

By default, MSTest runs tests in a sequential order. The assembly level attribute [Parallelize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ParallelizeAttribute) attribute can be used to run tests in parallel. You can specify if the parallelism should be at [class level](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ExecutionScope.ClassLevel) (multiple classes can be run in parallel but tests in a given class are run sequentially) or at [method level](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ExecutionScope.MethodLevel).

It's also possible to specify the maximum number of threads to use for parallel execution. A value of `0` (default value) means that the number of threads is equal to the number of logical processors on the machine.

It is also possible to specify the parallelism through the [parallelization properties of the runsettings file](./unit-testing-mstest-configure.md#mstest-element).

#### `DoNotParallelizeAttribute`

The [DoNotParallelize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DoNotParallelizeAttribute) attribute can be used to prevent parallel execution of tests in a given assembly. This attribute can be applied at the assembly level, class level or method level.

> [!NOTE]
> By default, MSTest runs tests in sequential order so you only need to use this attribute if you have applied the assembly level [Parallelize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ParallelizeAttribute) attribute.

### Timeout and retry attributes

These attributes control test execution time limits and retry behavior.

#### `TimeoutAttribute`

The [Timeout](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute) attribute can be used to specify the maximum time in milliseconds that a test method is allowed to run. If the test method runs longer than the specified time, the test will be aborted and marked as failed.

This attribute can be applied to any test method or any fixture method (initialization and cleanup methods). It is also possible to specify the timeout globally for either all test methods or all test fixture methods by using the [timeout properties of the runsettings file](./unit-testing-mstest-configure.md#mstest-element).

> [!NOTE]
> The timeout is not guaranteed to be precise. The test will be aborted after the specified time has passed, but it might take longer before the step is cancelled.

When using the timeout feature, a separate thread/task is created to run the test method. The main thread/task is responsible for monitoring the timeout and unobserving the method thread/task if the timeout is reached.

Starting with MSTest 3.6, it is possible to specify <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute.CooperativeCancellation*> property on the attribute (or globally through runsettings) to enable cooperative cancellation. In this mode, the method is responsible for checking the cancellation token and aborting the test if it is signaled as you would do in a typical `async` method. This mode is more performant and allows for more precise control over the cancellation process. This mode can be applied to both async and sync methods.

#### `RetryAttribute`

The [Retry](xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryAttribute) attribute was introduced in MSTest 3.8. This attribute causes the test method to be retried when it fails or timeouts. It allows you to specify the maximum number of retry attempts, the time delay between retries, and a delay backoff type, which is either constant or exponential.

Only one `RetryAttribute` is expected to be present on a test method, and `RetryAttribute` cannot be used on methods that are not marked with [TestMethod](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute).

```csharp
[TestClass]
public class MyTestClass
{
    [TestMethod]
    [Retry(3)] // Retry up to 3 times if the test fails
    public void FlakeyTest()
    {
        // Test implementation that might occasionally fail
    }
}
```

> [!NOTE]
> `RetryAttribute` derives from an abstract [RetryBaseAttribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryBaseAttribute). You can also create your own retry implementations if the built-in `RetryAttribute` isn't suitable for your needs.

### Conditional execution attributes

These attributes control whether tests run based on specific conditions.

#### `ConditionBaseAttribute`

The [ConditionBase](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute) attribute is an abstract base class used to conditionally control whether a test class or test method runs or is ignored. This attribute provides the foundation for creating custom conditional execution logic.

Derived classes, such as [CIConditionAttribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.CIConditionAttribute), [IgnoreAttribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute), and [OSConditionAttribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.OSConditionAttribute), implement specific conditions to determine whether tests should be executed.

> [!NOTE]
> This attribute isn't inherited. Applying it to a base class doesn't affect derived classes.

#### `CIConditionAttribute`

The [CICondition](xref:Microsoft.VisualStudio.TestTools.UnitTesting.CIConditionAttribute) attribute is used to conditionally run or ignore a test class or test method based on whether the test is running in a continuous integration (CI) environment. This attribute derives from [ConditionBaseAttribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute).

You can specify the [ConditionMode](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionMode) to either include (run only in CI) or exclude (skip in CI):

```csharp
[TestClass]
public class MyTestClass
{
    [TestMethod]
    [CICondition] // Run only in CI (default behavior, equivalent to `[CICondition(ConditionMode.Include)]`)
    public void CIOnlyTest()
    {
        // This test runs only when executed in a CI environment
    }

    [TestMethod]
    [CICondition(ConditionMode.Exclude)] // Skip in CI
    public void LocalOnlyTest()
    {
        // This test is skipped when running in a CI environment
    }
}
```

> [!NOTE]
> This attribute isn't inherited. Applying it to a base class doesn't affect derived classes.

#### `OSConditionAttribute`

The [OSCondition](xref:Microsoft.VisualStudio.TestTools.UnitTesting.OSConditionAttribute) attribute is used to conditionally run or ignore a test class or test method based on the operating system where the test is running. This attribute derives from [ConditionBaseAttribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute).

You can specify which operating systems the test supports or doesn't support using the [OperatingSystems](xref:Microsoft.VisualStudio.TestTools.UnitTesting.OperatingSystems) flags enum, which includes `Windows`, `Linux`, `OSX` (macOS), and `FreeBSD`. You can combine multiple operating systems using the bitwise OR operator.

```csharp
[TestClass]
public class MyTestClass
{
    [TestMethod]
    [OSCondition(OperatingSystems.Windows)] // Run only on Windows
    public void WindowsOnlyTest()
    {
        // This test runs only on Windows
    }

    [TestMethod]
    [OSCondition(OperatingSystems.Linux | OperatingSystems.OSX)] // Run on Linux or macOS
    public void UnixLikeTest()
    {
        // This test runs on Linux or macOS
    }

    [TestMethod]
    [OSCondition(ConditionMode.Exclude, OperatingSystems.Windows)] // Skip on Windows
    public void SkipOnWindowsTest()
    {
        // This test is skipped on Windows
    }
}
```

> [!NOTE]
> This attribute isn't inherited. Applying it to a base class doesn't affect derived classes.

#### `IgnoreAttribute`

The [Ignore](xref:Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute) attribute marks a test class or test method to be skipped during test execution. This attribute is useful for temporarily disabling tests without removing them from the codebase.

You can optionally provide a reason for ignoring the test:

```csharp
[TestClass]
public class MyTestClass
{
    [TestMethod]
    [Ignore]
    public void TemporarilyDisabledTest()
    {
        // This test is skipped
    }

    [TestMethod]
    [Ignore("Waiting for bug fix")]
    public void TestWithReason()
    {
        // This test is skipped with a reason
    }
}
```

When ignoring a test due to a specific work item or issue, consider using the [WorkItem](xref:Microsoft.VisualStudio.TestTools.UnitTesting.WorkItemAttribute) or [GitHubWorkItem](xref:Microsoft.VisualStudio.TestTools.UnitTesting.GitHubWorkItemAttribute) attributes to provide a structured link to the ticket instead of a simple string. These attributes provide better traceability and can be used to generate reports linking tests to specific work items:

```csharp
[TestClass]
public class MyTestClass
{
    [TestMethod]
    [Ignore("Waiting for fix")]
    [WorkItem(12345)] // Links to work item 12345 in your tracking system
    public void TestWithWorkItem()
    {
        // This test is skipped and linked to a work item
    }

    [TestMethod]
    [Ignore("Known issue")]
    [GitHubWorkItem("https://github.com/owner/repo/issues/42")] // Links to GitHub issue
    public void TestWithGitHubIssue()
    {
        // This test is skipped and linked to a GitHub issue
    }
}
```

> [!NOTE]
> This attribute isn't inherited. Applying it to a base class doesn't affect derived classes.

## Utilities attributes

### `DeploymentItemAttribute`

The [DeploymentItem](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute) attribute is used for copying files or folders specified as deployment items to the deployment directory (without adding a custom output path the copied files will be in `TestResults` folder inside the project folder). The deployment directory is where all the deployment items are present along with test project DLL.

It can be used either on test classes (classes marked with  the [TestClass](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute) attribute) or on test methods (methods marked with [TestMethod](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute) attribute).

Users can have multiple instances of the attribute to specify more than one item.

And here you can see its [constructors](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute#constructors>).

**Example**

```csharp
[TestClass]
[DeploymentItem(@"C:\classLevelDepItem.xml")]   // Copy file using some absolute path
public class UnitTest1
{
    [TestMethod]
    [DeploymentItem(@"..\..\methodLevelDepItem1.xml")]   // Copy file using a relative path from the dll output location
    [DeploymentItem(@"C:\DataFiles\methodLevelDepItem2.xml", "SampleDataFiles")]   // File will be added under a SampleDataFiles in the deployment directory
    public void TestMethod1()
    {
        string textFromFile = File.ReadAllText("classLevelDepItem.xml");
    }
}
```

> [!WARNING]
> We do not recommend the usage of this attribute for copying files to the deployment directory.

### `ExpectedExceptionAttribute`

The [ExpectedException](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionAttribute) attribute defines the exception that the test method is expected to throw. The test passes if the expected exception is thrown and the exception message matches the expected message.

> [!WARNING]
> This attribute exists for backward compatibility and is not recommended for new tests. Instead, use the `Assert.ThrowsException` (or `Assert.ThrowsExactly` if using MSTest 3.8 and later) method.

## Metadata attributes

The following attributes and the values assigned to them appear in the `Visual Studio` **Properties** window for a particular test method. These attributes aren't meant to be accessed through the code of the test. Instead, they affect the ways the test is used or run, either by you through the IDE of Visual Studio, or by the Visual Studio test engine. For example, some of these attributes appear as columns in the **Test Manager** window and **Test Results** window, which means that you can use them to group and sort tests and test results. One such attribute is <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute>, which you use to add arbitrary metadata to tests.

For example, you could use it to store the name of a "test pass" that this test covers, by marking the test with `[TestProperty("Feature", "Accessibility")]`. Or, you could use it to store an indicator of the kind of test it is with `[TestProperty("ProductMilestone", "42")]`. The property you create by using this attribute, and the property value you assign, are both displayed in the Visual Studio **Properties** window under the heading **Test specific**.

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.GitHubWorkItemAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OwnerAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PriorityAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.WorkItemAttribute>

> [!NOTE]
> For information about the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute>, see the [Conditional execution attributes](#conditional-execution-attributes) section.

The attributes below relate the test method that they decorate to entities in the project hierarchy of a `Team Foundation Server` team project:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CssIterationAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CssProjectStructureAttribute>
