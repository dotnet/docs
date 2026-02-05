---
title: MSTest attributes
description: Learn about the core MSTest attributes for identifying test classes and methods, plus utility attributes for deployment and exception handling.
author: Evangelink
ms.author: amauryleve
ms.date: 07/15/2025
---

# MSTest attributes

MSTest uses custom attributes to identify and customize tests. This page covers the core test identification attributes and utility attributes. For topic-specific attributes, see:

- **[Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md)**: `DataRow`, `DynamicData`, `TestDataRow`
- **[Test lifecycle](unit-testing-mstest-writing-tests-lifecycle.md)**: `AssemblyInitialize`, `ClassInitialize`, `TestInitialize`, cleanup attributes
- **[Test execution and control](unit-testing-mstest-writing-tests-execution-control.md)**: Threading, parallelization, timeout, retry, conditional execution
- **[Test organization](unit-testing-mstest-writing-tests-organization.md)**: Categories, priorities, owners, work items

> [!NOTE]
> Attribute names ending with "Attribute" can use the short form. `TestClass` and `TestClassAttribute` are equivalent. Attributes with parameterless constructors can omit parentheses.

## Test identification attributes

Every test class must have the `TestClass` attribute, and every test method must have the `TestMethod` attribute.

### `TestClassAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> marks a class that contains tests and, optionally, initialize or cleanup methods.

```csharp
[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        var calculator = new Calculator();
        Assert.AreEqual(5, calculator.Add(2, 3));
    }
}
```

You can extend this attribute to customize test class behavior:

```csharp
public class MyCustomTestClassAttribute : TestClassAttribute
{
    // Add custom behavior
}

[MyCustomTestClass]
public class CustomizedTests
{
    [TestMethod]
    public void MyTest() { }
}
```

### `TestMethodAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> marks a method as a test to run. Test methods must be:

- Instance methods (not static)
- Public
- Return `void`, `Task`, or `ValueTask` (MSTest v3.3+)
- Parameterless, unless using [data-driven attributes](unit-testing-mstest-writing-tests-data-driven.md)

```csharp
[TestClass]
public class TestMethodExamples
{
    [TestMethod]
    public void SynchronousTest()
    {
        // Synchronous test
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async Task AsynchronousTest()
    {
        // Async test
        await Task.Delay(100);
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async ValueTask ValueTaskTest()
    {
        // ValueTask test (MSTest v3.3+)
        await Task.Delay(100);
        Assert.IsTrue(true);
    }
}
```

> [!WARNING]
> Don't use `async void` for test methods. Use `async Task` or `async ValueTask` instead.

### `DiscoverInternalsAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DiscoverInternalsAttribute> assembly attribute enables MSTest to discover `internal` test classes and methods. By default, only `public` tests are discovered.

Apply this attribute at the assembly level:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: DiscoverInternals]

namespace MyTests
{
    [TestClass]
    internal class InternalTests
    {
        [TestMethod]
        internal void InternalTest()
        {
            Assert.IsTrue(true);
        }
    }
}
```

Place this attribute in `AssemblyInfo.cs`, a dedicated `MSTestSettings.cs` file, or any source file in the test assembly.

## Utility attributes

### `DeploymentItemAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute> copies files or folders to the deployment directory during test execution. Use this attribute when tests need access to external files.

```csharp
[TestClass]
[DeploymentItem(@"TestData\config.xml")]
public class DeploymentTests
{
    [TestMethod]
    [DeploymentItem(@"TestData\input.txt")]
    [DeploymentItem(@"TestData\expected.txt", "Expected")]
    public void ProcessFile_ReturnsExpectedOutput()
    {
        // Files are copied to the deployment directory
        string input = File.ReadAllText("input.txt");
        string expected = File.ReadAllText(@"Expected\expected.txt");
        
        // Test implementation
    }
}
```

#### Constructor overloads

| Constructor | Description |
|-------------|-------------|
| `DeploymentItem(string path)` | Copies file or folder to deployment directory root |
| `DeploymentItem(string path, string outputDirectory)` | Copies to specified subdirectory |

> [!WARNING]
> We don't recommend using `DeploymentItem` for copying files to the deployment directory. Consider embedding test data as resources or using relative paths from your test project.

### `ExpectedExceptionAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionAttribute> specifies that a test should throw a particular exception to pass.

```csharp
[TestClass]
public class ExceptionTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Method_NullInput_ThrowsArgumentNullException()
    {
        var service = new MyService();
        service.Process(null!);
    }
}
```

> [!WARNING]
> `ExpectedException` exists for backward compatibility. The analyzer [MSTEST0006](mstest-analyzers/mstest0006.md) flags usages of this attribute.
>
> The main limitation of `ExpectedException` is that it doesn't specify *which line* should throw the exception. Most tests contain multiple lines of code, and any of them could throw the expected exception type—including setup code or unrelated operations. This makes tests less precise and can mask bugs when the wrong line throws.
>
> For new tests, use `Assert.ThrowsExactly` or `Assert.ThrowsException` instead. These methods wrap only the specific code that should throw, providing precise control over exception expectations:
>
> ```csharp
> [TestMethod]
> public void Method_NullInput_ThrowsArgumentNullException()
> {
>     var service = new MyService();
>     
>     // MSTest v3.8+: Assert.ThrowsExactly
>     Assert.ThrowsExactly<ArgumentNullException>(() => service.Process(null!));
>     
>     // Or for base exception matching: Assert.ThrowsException
>     Assert.ThrowsException<ArgumentException>(() => service.Process(null!));
> }
> ```

## Attribute quick reference

| Category | Attributes | See |
|----------|-----------|------|
| Test identification | `TestClass`, `TestMethod`, `DiscoverInternals` | This page |
| Data-driven | `DataRow`, `DynamicData`, `TestDataRow`, `DataSource` | [Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md) |
| Lifecycle | `AssemblyInitialize`, `AssemblyCleanup`, `ClassInitialize`, `ClassCleanup`, `TestInitialize`, `TestCleanup`, `GlobalTestInitialize`, `GlobalTestCleanup` | [Test lifecycle](unit-testing-mstest-writing-tests-lifecycle.md) |
| Threading | `STATestClass`, `STATestMethod`, `UITestMethod` | [Test execution and control](unit-testing-mstest-writing-tests-execution-control.md) |
| Parallelization | `Parallelize`, `DoNotParallelize` | [Test execution and control](unit-testing-mstest-writing-tests-execution-control.md) |
| Timeout/Retry | `Timeout`, `Retry` | [Test execution and control](unit-testing-mstest-writing-tests-execution-control.md) |
| Conditional | `Ignore`, `OSCondition`, `CICondition` | [Test execution and control](unit-testing-mstest-writing-tests-execution-control.md) |
| Metadata | `TestCategory`, `TestProperty`, `Owner`, `Priority`, `Description` | [Test organization](unit-testing-mstest-writing-tests-organization.md) |
| Work tracking | `WorkItem`, `GitHubWorkItem` | [Test organization](unit-testing-mstest-writing-tests-organization.md) |
| Utilities | `DeploymentItem`, `ExpectedException` | This page |

## See also

- [Write tests in MSTest](unit-testing-mstest-writing-tests.md)
- [MSTest assertions](unit-testing-mstest-writing-tests-assertions.md)
- [TestContext class](unit-testing-mstest-writing-tests-testcontext.md)
- [Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md)
- [Test lifecycle](unit-testing-mstest-writing-tests-lifecycle.md)
- [Test execution and control](unit-testing-mstest-writing-tests-execution-control.md)
- [Test organization](unit-testing-mstest-writing-tests-organization.md)
