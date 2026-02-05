---
title: Write tests with MSTest
description: Learn how to write tests using MSTest, including attributes, assertions, data-driven testing, and test lifecycle management.
author: Evangelink
ms.author: amauryleve
ms.date: 07/15/2025
---

# Write tests with MSTest

In this article, you learn about the APIs and conventions used by MSTest to help you write and shape your tests.

## Test structure

Every MSTest test class and method uses attributes to identify tests:

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

For complete attribute documentation, see [MSTest attributes](unit-testing-mstest-writing-tests-attributes.md).

## Core concepts

MSTest documentation is organized by topic:

| Topic | Description | Guide |
|-------|-------------|-------|
| **Test attributes** | Core attributes for test identification | [Attributes](unit-testing-mstest-writing-tests-attributes.md) |
| **Assertions** | Verify expected results with Assert classes | [Assertions](unit-testing-mstest-writing-tests-assertions.md) |
| **Data-driven testing** | Run tests with multiple inputs | [Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md) |
| **Test lifecycle** | Setup and cleanup at assembly, class, and test levels | [Test lifecycle](unit-testing-mstest-writing-tests-lifecycle.md) |
| **Execution control** | Threading, parallelization, timeouts, and retries | [Execution control](unit-testing-mstest-writing-tests-execution-control.md) |
| **Test organization** | Categories, priorities, and metadata | [Test organization](unit-testing-mstest-writing-tests-organization.md) |
| **TestContext** | Access test runtime information | [TestContext](unit-testing-mstest-writing-tests-testcontext.md) |

## Attributes

MSTest uses custom attributes to identify and customize tests. Attribute elements whose names end with "Attribute" can use the short form (`TestClass` or `TestClassAttribute`). Attributes with parameterless constructors can omit parentheses.

MSTest attributes are organized by purpose:

- **[Test identification](unit-testing-mstest-writing-tests-attributes.md#test-identification-attributes)**: `TestClass`, `TestMethod`, `DiscoverInternals`
- **[Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md)**: `DataRow`, `DynamicData`, `TestDataRow`
- **[Test lifecycle](unit-testing-mstest-writing-tests-lifecycle.md)**: `AssemblyInitialize`, `ClassInitialize`, `TestInitialize`, and cleanup counterparts
- **[Execution control](unit-testing-mstest-writing-tests-execution-control.md)**: Threading (`STATestClass`, `UITestMethod`), parallelization (`Parallelize`), timeouts, retries, conditional execution
- **[Test organization](unit-testing-mstest-writing-tests-organization.md)**: `TestCategory`, `Priority`, `Owner`, `WorkItem`
- **[Utilities](unit-testing-mstest-writing-tests-attributes.md#utility-attributes)**: `DeploymentItem`, `ExpectedException`

## Assertions

Use the Assert classes of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace to verify specific functionality. A test method exercises code in your application, but it reports correctness only when you include Assert statements.

MSTest assertions are divided into:

- **[`Assert` class](unit-testing-mstest-writing-tests-assertions.md#the-assert-class)**: General-purpose assertions (`AreEqual`, `IsTrue`, `ThrowsException`)
- **[`StringAssert` class](unit-testing-mstest-writing-tests-assertions.md#the-stringassert-class)**: String-specific assertions (`Contains`, `Matches`, `StartsWith`)
- **[`CollectionAssert` class](unit-testing-mstest-writing-tests-assertions.md#the-collectionassert-class)**: Collection assertions (`Contains`, `AllItemsAreUnique`, `AreEquivalent`)

## The `TestContext` class

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> class provides contextual information and support for test execution, making it easier to retrieve information about the test run and manipulate aspects of the environment.

For more information, see [TestContext class](unit-testing-mstest-writing-tests-testcontext.md).

## Testing private members

You can test private members using reflection wrapper classes:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject>: For private instance methods
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType>: For private static methods

> [!TIP]
> Consider whether private methods need direct testing. Often, testing through public interfaces provides better coverage and more maintainable tests.

## See also

- [MSTest samples and tutorials](unit-testing-mstest-samples.md)
- [MSTest analyzers](mstest-analyzers/overview.md)
- [Unit testing best practices](unit-testing-best-practices.md)
- [Run selective unit tests](selective-unit-tests.md)
