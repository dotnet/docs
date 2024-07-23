---
title: MSTest writing tests
description: Learn about how to write tests using MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 07/18/2024
---

# Writing tests with MSTest

In this article, you will learn about the APIs and conventions used by MSTest to help you write and shape your tests.

## Attributes

MSTest uses custom attributes to identify and customize tests.

To help provide a clearer overview of the testing framework, this section organizes the members of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace into groups of related functionality.

> [!NOTE]
> Attribute elements, whose names end with "Attribute", can be used with or without "Attribute" at the end. Attributes that have parameterless constructor, can be written with or without parenthesis. 
> The following code examples work identically:
>
> `[TestClass()]`
>
> `[TestClassAttribute()]`
>
> `[TestClass]`
>
> `[TestClassAttribute]`

### Attributes used to identify test classes and methods

Every test class must have the `TestClass` attribute, and every test method must have the `TestMethod` attribute. For more information, see [Anatomy of a unit test](https://learn.microsoft.com/previous-versions/ms182517(v=vs.110)).

#### TestClassAttribute

The [TestClass](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute>) attribute marks a class that contains tests and, optionally, initialize or cleanup methods.

This attribute can be extended to change or extend the default behavior.

Example:

```csharp
[TestClass]
public class MyTestClass
{    
}
```

#### TestMethodAttribute

The [TestMethod](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute>) attribute is used inside a `TestClass` to define the actual test method to run.

The method should be an instance method defined as `public void` or `public Task` (optionally `async`) and be parameterless.

**Example**

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

```csharp
[TestClass]
public class MyTestClass
{
    [TestMethod]
    public async Task TestMethod()
    {
    }
}
```

### Attributes used for data-driven testing

Use the following elements to set up data-driven tests. For more information, see [Create a data-driven unit test](/visualstudio/test/how-to-create-a-data-driven-unit-test.md) and [Use a configuration file to define a data source](/visualstudio/test/walkthrough-using-a-configuration-file-to-define-a-data-source.md).

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataTestMethodAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataSourceAttribute>

#### DataRow

The `DataRowAttribute` allows you to run the same test method with multiple different inputs. It can appear one or multiple times on a test method. It should be combined with `TestMethodAttribute` or `DataTestMethodAttribute`.

The number and types of arguments must exactly match the test method signature.

Examples of valid calls:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DataRow(1, "message", true, 2.0)]
    public void TestMethod1(int i, string s, bool b, float f) {}
    
    [TestMethod]
    [DataRow(new string[] { "line1", "line2" })]
    public void TestMethod2(string[] lines) {}

    [TestMethod]
    [DataRow(null)]
    public void TestMethod3(object o) {}

    [TestMethod]
    [DataRow(new string[] { "line1", "line2" }, new string[] { "line1.", "line2." })]
    public void TestMethod4(string[] input, string[] expectedOutput) {}
}
```

Note that you can also use the `params` feature to capture multiple inputs of the `DataRow`.

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
> Before:
> [DataRow(new string[] { "a" }, new object[] { new string[] { "b" } })]
> In v3 onward:
> [DataRow(new string[] { "a" }, new string[] { "b" })]

You can modify the display name used in Visual Studio and loggers for each instance of `DataRowAttribute` by setting the `DisplayName` property.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [DataRow(1, 2, DisplayName= "Functional Case FC100.1")]
    public void TestMethod(int i, int j) {}
}
```

You can also create your own specialized data row attribute by inheriting the `DataRowAttribute`.

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

### Attributes used to provide initialization and cleanups

Setup and cleanup that is common to multiple tests can be extracted to a separate method, and marked with one of the attributes listed below, to run it at appropriate time, for example before every test. For more information, see [Anatomy of a unit test](/previous-versions/ms182517(v=vs.110)).

#### Assembly level

[AssemblyInitialize](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute>) is called right after your assembly is loaded and [AssemblyCleanup](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyCleanupAttribute>) is called right before your assembly is unloaded.

The methods marked with these attributes should be defined as `static void` or `static Task`, in a `TestClass`, and appear only once. The initialize part requires one argument of type [TestContext](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext) and the cleanup no argument.

```csharp
[TestClass]
public class MyTestClass
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext testContext)
    {
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
    }
}
```

```csharp
[TestClass]
public class MyOtherTestClass
{
    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
    }
}
```

#### Class level

[ClassInitialize](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute>) is called right before your class is loaded (but after static constructor) and [ClassCleanup](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute>) is called right after your class is unloaded.

It's possible to control the inheritance behavior: only for current class using `InheritanceBehavior.None` or for all derived classes using `InheritanceBehavior.BeforeEachDerivedClass`.

It's also possible to configure whether the class cleanup should be run at the end of the class or at the end of the assembly.

The methods marked with these attributes should be defined as `static void` or `static Task`, in a `TestClass`, and appear only once. The initialize part requires one argument of type [TestContext](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext) and the cleanup no argument.

```csharp
[TestClass]
public class MyTestClass
{
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
    }
}
```

```csharp
[TestClass]
public class MyOtherTestClass
{
    [ClassInitialize]
    public static async Task ClassInitialize(TestContext testContext)
    {
    }

    [ClassCleanup]
    public static async Task ClassCleanup()
    {
    }
}
```

#### Test level

[TestInitialize](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute>) is called right before your test is started and [TestCleanup](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute>) is called right after your test is finished.

The `TestInitialize` is similar to the class constructor but is usually more suitable for long or async initializations. The `TestInitialize` is always called after the constructor and called for each test (including each data row of data-driven tests).

The `TestCleanup` is similar to the class `Dispose` (or `DisposeAsync`) but is usually more suitable for long or async cleanups. The `TestCleanup` is always called just before the `DisposeAsync`/`Dispose` and called for each test (including each data row of data-driven tests).

The methods marked with these attributes should be defined as `void` or `Task`, in a `TestClass`, be parameterless, and appear one or multiple times.

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

```csharp
[TestClass]
public class MyOtherTestClass
{
    [TestInitialize]
    public async Task TestInitialize()
    {
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
    }
}
```

### DeploymentItemAttribute

The MSTest framework introduced <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute> for copying files or folders specified as deployment items to the deployment directory (without adding a custom output path the copied files will be in TestResults folder inside the project folder). The deployment directory is where all the deployment items are present along with test project DLL.

It can be used either on test classes (classes marked with `TestClass` attribute) or on test methods (methods marked with `TestMethod` attribute).

Users can have multiple instances of the attribute to specify more than one item.

And here you can see its [constructors](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute>).

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

### Metadata attributes

The following attributes and the values assigned to them appear in the `Visual Studio` **Properties** window for a particular test method. These attributes aren't meant to be accessed through the code of the test. Instead, they affect the ways the test is used or run, either by you through the IDE of Visual Studio, or by the Visual Studio test engine. For example, some of these attributes appear as columns in the **Test Manager** window and **Test Results** window, which means that you can use them to group and sort tests and test results. One such attribute is <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute>, which you use to add arbitrary metadata to tests.

For example, you could use it to store the name of a "test pass" that this test covers, by marking the test with `[TestProperty("TestPass", "Accessibility")]`. Or, you could use it to store an indicator of the kind of test It's with `[TestProperty("TestKind", "Localization")]`. The property you create by using this attribute, and the property value you assign, are both displayed in the Visual Studio **Properties** window under the heading **Test specific**.

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OwnerAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PriorityAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.WorkItemAttribute>

The attributes below relate the test method that they decorate to entities in the project hierarchy of a `Team Foundation Server` team project.

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CssIterationAttribute>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CssProjectStructureAttribute>

## Assertions

Use the Assert classes of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace to verify specific functionality. A test method exercises the code of a method in your application's code, but it reports the correctness of the code's behavior only if you include Assert statements.

### Assertions exceptions

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestAssertException> is the base of all assertion exceptions thrown by MSTest. If you write a new assert exception class, inherit from this base class to make it easier to identify the exception as an assertion failure instead of an unexpected exception thrown from your test or production code.

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException> exception is thrown whenever a test fails. A test fails if it times out, throws an unexpected exception, or contains an assert statement that produces a **Failed** result.

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssertInconclusiveException> is thrown whenever a test produces an **Inconclusive** result. Typically, you add an <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive%2A?displayProperty=nameWithType> statement to a test that you are still working on, to indicate it's not yet ready to be run. This is also useful when you want to skip a test based on certain runtime conditions.

### The `Assert` class

In your test method, you can call any methods of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert?displayProperty=fullName> class, such as <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual%2A?displayProperty=nameWithType>. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> class has many methods to choose from, and many of the methods have several overloads.

### The `StringAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> class to compare and examine strings. This class contains a variety of useful methods, such as <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Contains%2A?displayProperty=nameWithType>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Matches%2A?displayProperty=nameWithType>, and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.StartsWith%2A?displayProperty=nameWithType>.

### The `CollectionAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> class to compare collections of objects, or to verify the state of a collection.

## Testing private members

You can generate a test for a private method. This generation creates a private accessor class, which instantiates an object of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject> class. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject> class is a wrapper class that uses reflection as part of the private accessor process. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType> class is similar, but is used for calling private static methods instead of calling private instance methods.

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject>

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType>
