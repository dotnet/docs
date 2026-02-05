---
title: Write tests with MSTest
description: Learn how to write tests using MSTest, including attributes, assertions, data-driven testing, and test lifecycle management.
author: Evangelink
ms.author: amauryleve
ms.date: 07/15/2025
---

# Write tests with MSTest

In this article, you learn about the APIs and conventions used by MSTest to help you write and shape your tests.

> [!NOTE]
> Attribute names ending with "Attribute" can use the short form. `TestClass` and `TestClassAttribute` are equivalent. Attributes with parameterless constructors can omit parentheses.

## Test structure

Every MSTest test class must have the `TestClass` attribute, and every test method must have the `TestMethod` attribute:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Add(2, 3);

        // Assert
        Assert.AreEqual(5, result);
    }
}
```

### `TestClassAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> marks a class that contains tests and, optionally, initialize or cleanup methods. You can extend this attribute to customize test class behavior.

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
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async Task AsynchronousTest()
    {
        await Task.Delay(100);
        Assert.IsTrue(true);
    }
}
```

> [!WARNING]
> Don't use `async void` for test methods. Use `async Task` or `async ValueTask` instead.

### `DiscoverInternalsAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DiscoverInternalsAttribute> assembly attribute enables MSTest to discover `internal` test classes and methods. By default, only `public` tests are discovered.

```csharp
[assembly: DiscoverInternals]

[TestClass]
internal class InternalTests
{
    [TestMethod]
    internal void InternalTest()
    {
        Assert.IsTrue(true);
    }
}
```

## Core concepts

MSTest documentation is organized by topic:

| Topic | Description |
|-------|-------------|
| [Assertions](unit-testing-mstest-writing-tests-assertions.md) | Verify expected results with Assert classes |
| [Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md) | Run tests with multiple inputs (`DataRow`, `DynamicData`) |
| [Test lifecycle](unit-testing-mstest-writing-tests-lifecycle.md) | Setup and cleanup at assembly, class, and test levels |
| [Execution control](unit-testing-mstest-writing-tests-controlling-execution.md) | Threading, parallelization, timeouts, retries, and conditional execution |
| [Test organization](unit-testing-mstest-writing-tests-organizing.md) | Categories, priorities, owners, and metadata |
| [TestContext](unit-testing-mstest-writing-tests-testcontext.md) | Access test runtime information |

## Attribute quick reference

| Category | Attributes | See |
|----------|-----------|------|
| Test identification | `TestClass`, `TestMethod`, `DiscoverInternals` | This page |
| Data-driven | `DataRow`, `DynamicData`, `TestDataRow` | [Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md) |
| Lifecycle | `AssemblyInitialize`, `ClassInitialize`, `TestInitialize`, and cleanup counterparts | [Test lifecycle](unit-testing-mstest-writing-tests-lifecycle.md) |
| Threading | `STATestClass`, `STATestMethod`, `UITestMethod` | [Execution control](unit-testing-mstest-writing-tests-controlling-execution.md) |
| Parallelization | `Parallelize`, `DoNotParallelize` | [Execution control](unit-testing-mstest-writing-tests-controlling-execution.md) |
| Timeout/Retry | `Timeout`, `Retry` | [Execution control](unit-testing-mstest-writing-tests-controlling-execution.md) |
| Conditional | `Ignore`, `OSCondition`, `CICondition` | [Execution control](unit-testing-mstest-writing-tests-controlling-execution.md) |
| Metadata | `TestCategory`, `TestProperty`, `Owner`, `Priority` | [Test organization](unit-testing-mstest-writing-tests-organizing.md) |
| Work tracking | `WorkItem`, `GitHubWorkItem` | [Test organization](unit-testing-mstest-writing-tests-organizing.md) |

## Assertions

Use the Assert classes of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace to verify specific functionality. A test method exercises code in your application, but it reports correctness only when you include Assert statements.

MSTest assertions are divided into:

- **[`Assert` class](unit-testing-mstest-writing-tests-assertions.md#the-assert-class)**: General-purpose assertions (`AreEqual`, `IsTrue`, `ThrowsException`)
- **[`StringAssert` class](unit-testing-mstest-writing-tests-assertions.md#the-stringassert-class)**: String-specific assertions (`Contains`, `Matches`, `StartsWith`)
- **[`CollectionAssert` class](unit-testing-mstest-writing-tests-assertions.md#the-collectionassert-class)**: Collection assertions (`Contains`, `AllItemsAreUnique`, `AreEquivalent`)

## Testing private members

You can test private members using reflection wrapper classes:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject>: For private instance methods
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType>: For private static methods

> [!TIP]
> Consider whether private methods need direct testing. Often, testing through public interfaces provides better coverage and more maintainable tests.

## See also

- [Get started with MSTest](unit-testing-mstest-getting-started.md)
- [MSTest analyzers](mstest-analyzers/overview.md)
- [Unit testing best practices](unit-testing-best-practices.md)
- [Run selective unit tests](selective-unit-tests.md)
