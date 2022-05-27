---
title: Run selected unit tests
description: How to use a filter expression to run selected unit tests with the dotnet test command in .NET Core.
author: smadala
ms.date: 10/29/2021
zone_pivot_groups: unit-testing-framework-set-one
ms.topic: reference
---

# Run selected unit tests

With the [`dotnet test`](../tools/dotnet-test.md) command in .NET Core, you can use a filter expression to run selected tests. This article demonstrates how to filter tests. The examples use `dotnet test`. If you're using `vstest.console.exe`, replace `--filter` with `--testcasefilter:`.

## Syntax

```dotnetcli
dotnet test --filter <Expression>
```

* **Expression** is in the format `<Property><Operator><Value>[|&<Expression>]`.

  Expressions can be joined with boolean operators: `|` for boolean **or**, `&` for boolean **and**.

  Expressions can be enclosed in parentheses. For example: `(Name~MyClass) | (Name~MyClass2)`.

  An expression without any **operator** is interpreted as a **contains** on the `FullyQualifiedName` property. For example, `dotnet test --filter xyz` is the same as `dotnet test --filter FullyQualifiedName~xyz`.

* **Property** is an attribute of the `Test Case`. For example, the following properties are supported by popular unit test frameworks.

  | Test framework | Supported properties |
  | -------------- | -------------------- |
  | MSTest         | `FullyQualifiedName`<br>`Name`<br>`ClassName`<br>`Priority`<br>`TestCategory` |
  | xUnit          | `FullyQualifiedName`<br>`DisplayName`<br>`Traits` |
  | Nunit          | `FullyQualifiedName`<br>`Name`<br>`Priority`<br>`TestCategory` |

* **Operators**

  * `=` exact match
  * `!=`not exact match
  * `~` contains
  * `!~` doesn't contain

* **Value** is a string. All the lookups are case insensitive.

## Character escaping

To use an exclamation mark (`!`) in a filter expression on Linux or macOS, escape it by putting a backslash in front of it (`\!`). For example, the following filter skips all tests in a namespace that contains `IntegrationTests`:

```dotnetcli
dotnet test --filter FullyQualifiedName\!~IntegrationTests
```

For `FullyQualifiedName` values that include a comma for generic type parameters, escape the comma with `%2C`. For example:

```dotnetcli
dotnet test --filter "FullyQualifiedName=MyNamespace.MyTestsClass<ParameterType1%2CParameterType2>.MyTestMethod"
```

:::zone pivot="mstest"

## MSTest examples

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestNamespace
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, Priority(1), TestCategory("CategoryA")]
        public void TestMethod1()
        {
        }

        [TestMethod, Priority(2)]
        public void TestMethod2()
        {
        }
    }
}
```

| Expression | Result |
|--|--|
| `dotnet test --filter Method` | Runs tests whose <xref:System.Reflection.Module.FullyQualifiedName> contains `Method`. |
| `dotnet test --filter Name~TestMethod1` | Runs tests whose name contains `TestMethod1`. |
| `dotnet test --filter ClassName=MSTestNamespace.UnitTest1` | Runs tests that are in class `MSTestNamespace.UnitTest1`.<br>**Note:** The `ClassName` value should have a namespace, so `ClassName=UnitTest1` won't work. |
| `dotnet test --filter FullyQualifiedName!=MSTestNamespace.UnitTest1.TestMethod1` | Runs all tests except `MSTestNamespace.UnitTest1.TestMethod1`. |
| `dotnet test --filter TestCategory=CategoryA` | Runs tests that are annotated with `[TestCategory("CategoryA")]`. |
| `dotnet test --filter Priority=2` | Runs tests that are annotated with `[Priority(2)]`. |

Examples using the conditional operators `|` and `&`:

* To run tests that have `UnitTest1` in their <xref:System.Reflection.Module.FullyQualifiedName> **or** <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute> is `"CategoryA"`.

  ```dotnetcli
  dotnet test --filter "FullyQualifiedName~UnitTest1|TestCategory=CategoryA"
  ```

* To run tests that have `UnitTest1` in their <xref:System.Reflection.Module.FullyQualifiedName> **and** have a <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute> of `"CategoryA"`.

  ```dotnetcli
  dotnet test --filter "FullyQualifiedName~UnitTest1&TestCategory=CategoryA"
  ```

* To run tests that have either <xref:System.Reflection.Module.FullyQualifiedName> containing `UnitTest1` **and** have a <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute> of `"CategoryA"` **or** have a <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PriorityAttribute> with a priority of `1`.

  ```dotnetcli
  dotnet test --filter "(FullyQualifiedName~UnitTest1&TestCategory=CategoryA)|Priority=1"
  ```

:::zone-end
:::zone pivot="xunit"

## xUnit examples

```csharp
using Xunit;

namespace XUnitNamespace
{
    public class TestClass1
    {
        [Fact, Trait("Priority", "1"), Trait("Category", "CategoryA")]
        public void Test1()
        {
        }

        [Fact, Trait("Priority", "2")]
        public void Test2()
        {
        }
    }
}
```

| Expression | Result |
|--|--|
| `dotnet test --filter DisplayName=XUnitNamespace.TestClass1.Test1` | Runs only one test, `XUnitNamespace.TestClass1.Test1`. |
| `dotnet test --filter FullyQualifiedName!=XUnitNamespace.TestClass1.Test1` | Runs all tests except `XUnitNamespace.TestClass1.Test1`. |
| `dotnet test --filter DisplayName~TestClass1` | Runs tests whose display name contains `TestClass1`. |

In the code example, the defined traits with keys `"Category"` and `"Priority"` can be used for filtering.

| Expression | Result |
|--|--|
| `dotnet test --filter XUnit` | Runs tests whose <xref:System.Reflection.Module.FullyQualifiedName> contains `XUnit`.|
| `dotnet test --filter Category=CategoryA` | Runs tests that have `[Trait("Category", "CategoryA")]`. |

Examples using the conditional operators `|` and `&`:

* To run tests that have `TestClass1` in their <xref:System.Reflection.Module.FullyQualifiedName> **or** have a `Trait` with a key of `"Category"` and value of `"CategoryA"`.

  ```dotnetcli
  dotnet test --filter "FullyQualifiedName~TestClass1|Category=CategoryA"
  ```

* To run tests that have `TestClass1` in their <xref:System.Reflection.Module.FullyQualifiedName> **and** have a `Trait` with a key of `"Category"` and value of `"CategoryA"`.

  ```dotnetcli
  dotnet test --filter "FullyQualifiedName~TestClass1&Category=CategoryA"
  ```

* To run tests that have either <xref:System.Reflection.Module.FullyQualifiedName> containing `TestClass1` **and** have a `Trait` with a key of `"Category"` and value of `"CategoryA"` **or** have a `Trait` with a key of `"Priority"` and value of `1`.

  ```dotnetcli
  dotnet test --filter "(FullyQualifiedName~TestClass1&Category=CategoryA)|Priority=1"
  ```

:::zone-end
:::zone pivot="nunit"

## NUnit examples

```csharp
using NUnit.Framework;

namespace NUnitNamespace
{
    public class UnitTest1
    {
        [Test, Property("Priority", 1), Category("CategoryA")]
        public void TestMethod1()
        {
        }

        [Test, Property("Priority", 2)]
        public void TestMethod2()
        {
        }
    }
}
```

| Expression | Result |
|--|--|
| `dotnet test --filter Method` | Runs tests whose <xref:System.Reflection.Module.FullyQualifiedName> contains `Method`. |
| `dotnet test --filter Name~TestMethod1` | Runs tests whose name contains `TestMethod1`. |
| `dotnet test --filter FullyQualifiedName~NUnitNamespace.UnitTest1` | Runs tests that are in class `NUnitNamespace.UnitTest1`. |
| `dotnet test --filter FullyQualifiedName!=NUnitNamespace.UnitTest1.TestMethod1` | Runs all tests except `NUnitNamespace.UnitTest1.TestMethod1`. |
| `dotnet test --filter TestCategory=CategoryA` | Runs tests that are annotated with `[Category("CategoryA")]`. |
| `dotnet test --filter Priority=2` | Runs tests that are annotated with `[Priority(2)]`. |

Examples using the conditional operators `|` and `&`:

To run tests that have `UnitTest1` in their <xref:System.Reflection.Module.FullyQualifiedName> **or** have a `Category` of `"CategoryA"`.

```dotnetcli
dotnet test --filter "FullyQualifiedName~UnitTest1|TestCategory=CategoryA"
```

To run tests that have `UnitTest1` in their <xref:System.Reflection.Module.FullyQualifiedName> **and** have a `Category` of `"CategoryA"`.

```dotnetcli
dotnet test --filter "FullyQualifiedName~UnitTest1&TestCategory=CategoryA"
```

To run tests that have either a <xref:System.Reflection.Module.FullyQualifiedName> containing `UnitTest1` **and** have a `Category` of `"CategoryA"` **or** have a `Property` with a `"Priority"` of `1`.

```dotnetcli
dotnet test --filter "(FullyQualifiedName~UnitTest1&TestCategory=CategoryA)|Priority=1"
```

For more information, see [TestCase filter](https://github.com/Microsoft/vstest-docs/blob/main/docs/filter.md).

:::zone-end

## See also

- [dotnet test](../tools/dotnet-test.md)
- [dotnet test --filter](../tools/dotnet-test.md#filter-option-details)

## Next steps

> [!div class="nextstepaction"]
> [Order unit tests](order-unit-tests.md)
