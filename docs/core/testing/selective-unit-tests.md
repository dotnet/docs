---
title: Running selective unit tests
description: How to use a filter expression to run selective unit tests with the dotnet test command in .NET Core.
author: smadala
ms.date: 03/22/2017
ms.custom: seodec18
---

# Running selective unit tests

With the `dotnet test` command in .NET Core, you can use a filter expression to run selective tests. This article demonstrates how to filter which test are run. The following examples use `dotnet test`. If you're using `vstest.console.exe`, replace `--filter` with `--testcasefilter:`.

## MSTest

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestNamespace
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory("CategoryA")]
        [Priority(1)]
        [TestMethod]
        public void TestMethod1()
        {
        }

        [Priority(2)]
        [TestMethod]
        public void TestMethod2()
        {
        }
    }
}
```

| Expression | Result |
| ---------- | ------ |
| `dotnet test --filter Method` | Runs tests whose `FullyQualifiedName` contains `Method`. Available in `vstest 15.1+`. |
| `dotnet test --filter Name~TestMethod1` | Runs tests whose name contains `TestMethod1`. |
| `dotnet test --filter ClassName=MSTestNamespace.UnitTest1` | Runs tests which are in class `MSTestNamespace.UnitTest1`.<br>**Note:** The `ClassName` value should have a namespace, so `ClassName=UnitTest1` won't work. |
| `dotnet test --filter FullyQualifiedName!=MSTestNamespace.UnitTest1.TestMethod1` | Runs all tests except `MSTestNamespace.UnitTest1.TestMethod1`. |
| `dotnet test --filter TestCategory=CategoryA` | Runs tests which are annotated with `[TestCategory("CategoryA")]`. |
| `dotnet test --filter Priority=2` | Runs tests which are annotated with `[Priority(2)]`.<br>

**Using conditional operators | and &amp;**

| Expression | Result |
| ---------- | ------ |
| <code>dotnet test --filter "FullyQualifiedName~UnitTest1&#124;TestCategory=CategoryA"</code> | Runs tests which have `UnitTest1` in `FullyQualifiedName` **or** `TestCategory` is `CategoryA`. |
| `dotnet test --filter "FullyQualifiedName~UnitTest1&TestCategory=CategoryA"` | Runs tests which have `UnitTest1` in `FullyQualifiedName` **and** `TestCategory` is `CategoryA`. |
| <code>dotnet test --filter "(FullyQualifiedName~UnitTest1&TestCategory=CategoryA)&#124;Priority=1"</code> | Runs tests which have either `FullyQualifiedName` containing `UnitTest1` **and** `TestCategory` is `CategoryA` **or** `Priority` is 1. |

## xUnit

```csharp
using Xunit;

namespace XUnitNamespace
{
    public class TestClass1
    {
        [Trait("Category", "CategoryA")]
        [Trait("Priority", "1")]
        [Fact]
        public void Test1()
        {
        }

        [Trait("Priority", "2")]
        [Fact]
        public void Test2()
        {
        }
    }
}
```

| Expression | Result |
| ---------- | ------ |
| `dotnet test --filter DisplayName=XUnitNamespace.TestClass1.Test1` | Runs only one test, `XUnitNamespace.TestClass1.Test1`. |
| `dotnet test --filter FullyQualifiedName!=XUnitNamespace.TestClass1.Test1` | Runs all tests except `XUnitNamespace.TestClass1.Test1`. |
| `dotnet test --filter DisplayName~TestClass1` | Runs tests whose display name contains `TestClass1`. |

In the code example, the defined traits with keys `Category` and `Priority` can be used for filtering.

| Expression | Result |
| ---------- | ------ |
| `dotnet test --filter XUnit` | Runs tests whose `FullyQualifiedName` contains `XUnit`.  Available in `vstest 15.1+`. |
| `dotnet test --filter Category=CategoryA` | Runs tests which have `[Trait("Category", "CategoryA")]`. |

**Using conditional operators | and &amp;**

| Expression | Result |
| ---------- | ------ |
| <code>dotnet test --filter "FullyQualifiedName~TestClass1&#124;Category=CategoryA"</code> | Runs tests which has `TestClass1` in `FullyQualifiedName` **or** `Category` is `CategoryA`. |
| `dotnet test --filter "FullyQualifiedName~TestClass1&Category=CategoryA"` | Runs tests which has `TestClass1` in `FullyQualifiedName` **and** `Category` is `CategoryA`. |
| <code>dotnet test --filter "(FullyQualifiedName~TestClass1&Category=CategoryA)&#124;Priority=1"</code> | Runs tests which have either `FullyQualifiedName` containing `TestClass1` **and** `Category` is `CategoryA` **or** `Priority` is 1. |

## NUnit

```csharp
using NUnit.Framework;

namespace NUnitNamespace
{
    public class UnitTest1
    {
        [Category("CategoryA")]
        [Property("Priority", 1)]
        [Test]
        public void TestMethod1()
        {
        }

        [Property("Priority", 2)]
        [Test]
        public void TestMethod2()
        {
        }
    }
}
```

| Expression | Result |
| ---------- | ------ |
| `dotnet test --filter Method` | Runs tests whose `FullyQualifiedName` contains `Method`. Available in `vstest 15.1+`. |
| `dotnet test --filter Name~TestMethod1` | Runs tests whose name contains `TestMethod1`. |
| `dotnet test --filter FullyQualifiedName~NUnitNamespace.UnitTest1` | Runs tests which are in class `NUnitNamespace.UnitTest1`.<br>
| `dotnet test --filter FullyQualifiedName!=NUnitNamespace.UnitTest1.TestMethod1` | Runs all tests except `NUnitNamespace.UnitTest1.TestMethod1`. |
| `dotnet test --filter TestCategory=CategoryA` | Runs tests which are annotated with `[Category("CategoryA")]`. |
| `dotnet test --filter Priority=2` | Runs tests which are annotated with `[Priority(2)]`.<br>

**Using conditional operators | and &amp;**

| Expression | Result |
| ---------- | ------ |
| <code>dotnet test --filter "FullyQualifiedName~UnitTest1&#124;TestCategory=CategoryA"</code> | Runs tests which have `UnitTest1` in `FullyQualifiedName` **or** `TestCategory` is `CategoryA`. |
| `dotnet test --filter "FullyQualifiedName~UnitTest1&TestCategory=CategoryA"` | Runs tests which have `UnitTest1` in `FullyQualifiedName` **and** `TestCategory` is `CategoryA`. |
| <code>dotnet test --filter "(FullyQualifiedName~UnitTest1&TestCategory=CategoryA)&#124;Priority=1"</code> | Runs tests which have either `FullyQualifiedName` containing `UnitTest1` **and** `TestCategory` is `CategoryA` **or** `Priority` is 1. |
