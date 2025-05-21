---
title: MSTest attributes
description: Learn about the various attributes of MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 07/24/2024
ms.topic: article
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

## Attributes used for data-driven testing

Use the following elements to set up data-driven tests. For more information, see [Create a data-driven unit test](/visualstudio/test/how-to-create-a-data-driven-unit-test) and [Use a configuration file to define a data source](/visualstudio/test/walkthrough-using-a-configuration-file-to-define-a-data-source).

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataSourceAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute>

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

## Attributes used to control test execution

The following attributes can be used to modify the way tests are executed.

### `TimeoutAttribute`

The [Timeout](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute) attribute can be used to specify the maximum time in milliseconds that a test method is allowed to run. If the test method runs longer than the specified time, the test will be aborted and marked as failed.

This attribute can be applied to any test method or any fixture method (initialization and cleanup methods). It is also possible to specify the timeout globally for either all test methods or all test fixture methods by using the [timeout properties of the runsettings file](./unit-testing-mstest-configure.md#mstest-element).

> [!NOTE]
> The timeout is not guaranteed to be precise. The test will be aborted after the specified time has passed, but it may take longer before the step is cancelled.

When using the timeout feature, a separate thread/task is created to run the test method. The main thread/task is responsible for monitoring the timeout and unobserving the method thread/task if the timeout is reached.

Starting with MSTest 3.6, it is possible to specify <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute.CooperativeCancellation*> property on the attribute (or globally through runsettings) to enable cooperative cancellation. In this mode, the method is responsible for checking the cancellation token and aborting the test if it is signaled as you would do in a typical `async` method. This mode is more performant and allows for more precise control over the cancellation process. This mode can be applied to both async and sync methods.

### `STATestClassAttribute`

When applied to a test class, the [STATestClass](xref:Microsoft.VisualStudio.TestTools.UnitTesting.STATestClassAttribute) attribute indicates that all test methods (and the `[ClassInitialize]` and `[ClassCleanup]` methods) in the class should be run in a single-threaded apartment (STA). This attribute is useful when the test methods interact with COM objects that require STA.

> [!NOTE]
> This is only supported on Windows and in version 3.6 and later.

### `STATestMethodAttribute`

When applied to a test method, the [STATestMethod](xref:Microsoft.VisualStudio.TestTools.UnitTesting.STATestMethodAttribute) attribute indicates that the test method should be run in a single-threaded apartment (STA). This attribute is useful when the test method interacts with COM objects that require STA.

> [!NOTE]
> This is only supported on Windows and in version 3.6 and later.

### `ParallelizeAttribute`

By default, MSTest runs tests in a sequential order. The assembly level attribute [Parallelize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ParallelizeAttribute) attribute can be used to run tests in parallel. You can specify if the parallelism should be at [class level](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ExecutionScope.ClassLevel) (multiple classes can be run in parallel but tests in a given class are run sequentially) or at [method level](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ExecutionScope.MethodLevel).

It's also possible to specify the maximum number of threads to use for parallel execution. A value of `0` (default value) means that the number of threads is equal to the number of logical processors on the machine.

It is also possible to specify the parallelism through the [parallelization properties of the runsettings file](./unit-testing-mstest-configure.md#mstest-element).

### `DoNotParallelizeAttribute`

The [DoNotParallelize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DoNotParallelizeAttribute) attribute can be used to prevent parallel execution of tests in a given assembly. This attribute can be applied at the assembly level, class level or method level.

> [!NOTE]
> By default, MSTest runs tests in sequential order so you only need to use this attribute if you have applied the assembly level [Parallelize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ParallelizeAttribute) attribute.

### `RetryAttribute`

The `Retry` attribute was introduced in MSTest 3.8. This attribute causes the test method to be retried when it fails or timeouts. It allows you to specify the maximum number of retry attempts, the time delay between retries, and a delay backoff type, which is either constant or exponential.

Only one `RetryAttribute` is expected to be present on a test method, and `RetryAttribute` cannot be used on methods that are not marked with [TestMethod](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute).

> [!NOTE]
> `RetryAttribute` derives from an abstract `RetryBaseAttribute`. You can also create your own retry implementations if the built-in `RetryAttribute` doesn't suite your needs.

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

For example, you could use it to store the name of a "test pass" that this test covers, by marking the test with `[TestProperty("Feature", "Accessibility")]`. Or, you could use it to store an indicator of the kind of test It's with `[TestProperty("ProductMilestone", "42")]`. The property you create by using this attribute, and the property value you assign, are both displayed in the Visual Studio **Properties** window under the heading **Test specific**.

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OwnerAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PriorityAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.WorkItemAttribute>

The attributes below relate the test method that they decorate to entities in the project hierarchy of a `Team Foundation Server` team project:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CssIterationAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CssProjectStructureAttribute>
