---
title: Running selective unit tests
description: Shows you how to use a filter expression to run selective unit tests with the dotnet test command.
keywords: .NET, .NET Core, unit test, selective test
author: smadala
ms.author: mairaw
ms.date: 03/22/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 13d01272-bbf8-456c-a97a-560001d1a7f2
ms.workload: 
  - dotnetcore
---

# Running selective unit tests

The following examples use `dotnet test`. If you're using `vstest.console.exe`, replace `--filter ` with `--testcasefilter:`.

## MSTest

```csharp
namespace MSTestNamespace
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTestClass1
    {
        [Priority(2)]
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestCategory("CategoryA")]
        [Priority(3)]
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
| `dotnet test --filter ClassName=MSTestNamespace.UnitTestClass1` | Runs tests which are in class `MSTestNamespace.UnitTestClass1`.<br>**Note:** The `ClassName` value should have a namespace, so `ClassName=UnitTestClass1` won't work. |
| `dotnet test --filter FullyQualifiedName!=MSTestNamespace.UnitTestClass1.TestMethod1` | Runs all tests except `MSTestNamespace.UnitTestClass1.TestMethod1`. |
| `dotnet test --filter TestCategory=CategoryA` | Runs tests which are annotated with `[TestCategory("CategoryA")]`. |
| `dotnet test --filter Priority=3` | Runs tests which are annotated with `[Priority(3)]`.<br>**Note:** `Priority~3` is an invalid value, as it isn't a string. |

**Using conditional operators | and &amp;**

| Expression | Result |
| ---------- | ------ |
| <code>dotnet test --filter "FullyQualifiedName~UnitTestClass1&#124;TestCategory=CategoryA"</code> | Runs tests which have `UnitTestClass1` in `FullyQualifiedName` **or** `TestCategory` is `CategoryA`. |
| `dotnet test --filter "FullyQualifiedName~UnitTestClass1&TestCategory=CategoryA"` | Runs tests which have `UnitTestClass1` in `FullyQualifiedName` **and** `TestCategory` is `CategoryA`. |
| <code>dotnet test --filter "(FullyQualifiedName~UnitTestClass1&TestCategory=CategoryA)&#124;Priority=1"</code> | Runs tests which have either `FullyQualifiedName` containing `UnitTestClass1` **and** `TestCategory` is `CategoryA` **or** `Priority` is 1. |

## xUnit

```csharp
namespace XUnitNamespace
{
    public class TestClass1
    {
        [Trait("Category", "bvt")]
        [Trait("Priority", "1")]
        [Fact]
        public void foo()
        {
        }

        [Trait("Category", "Nightly")]
        [Trait("Priority", "2")]
        [Fact]
        public void bar()
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
| `dotnet test --filter Category=bvt` | Runs tests which have `[Trait("Category", "bvt")]`. |

**Using conditional operators | and &amp;**

| Expression | Result |
| ---------- | ------ |
| <code>dotnet test --filter "FullyQualifiedName~TestClass1&#124;Category=Nightly"</code> | Runs tests which has `TestClass1` in `FullyQualifiedName` **or** `Category` is `Nightly`. |
| `dotnet test --filter "FullyQualifiedName~TestClass1&Category=Nightly"` | Runs tests which has `TestClass1` in `FullyQualifiedName` **and** `Category` is `Nightly`. |
| <code>dotnet test --filter "(FullyQualifiedName~TestClass1&Category=Nightly)&#124;Priority=1"</code> | Runs tests which have either `FullyQualifiedName` containing `TestClass1` **and** `Category` is `CategoryA` **or** `Priority` is 1. |
