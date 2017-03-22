---
title: Running selective unit tests | Microsoft Docs
description: Shows you how to use a filter expression to run selective unit tests with the dotnet test command.
keywords: .NET, .NET Core, unit test, selective test
author: smadala
ms.author: mairaw
ms.date: 03/22/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 13d01272-bbf8-456c-a97a-560001d1a7f2
---

# Running selective unit tests

Following examples use `dotnet test`, if you're using `vstest.console.exe` replace `--filter ` with `--testcasefilter:`.

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
| --- | --- |
| `dotnet test --filter Method` | Runs tests whose `FullyQualifiedName` contains `Method`. Available in `vstest 15.1+`. |
| `dotnet test --filter Name~TestMethod1` | Runs tests whose name contains `TestMethod1`. |
| `dotnet test --filter ClassName=MSTestNamespace.UnitTestClass1` | Runs tests which are in class  `MSTestNamespace.UnitTestClass1`. <br/>**Note:** ClassName value should have namespace, ClassName=UnitTestClass1 won't work. |
| `dotnet test --filter FullyQualifiedName!=MSTestNamespace.UnitTestClass1.TestMethod1` | Runs all tests excepts `MSTestNamespace.UnitTestClass1.TestMethod1`. |
| `dotnet test --filter TestCategory=CategoryA` | Runs tests which are annotated with `[TestCategory("CategoryA")]` |
| `dotnet test --filter Priority=3` | Runs tests which are annotated with `[Priority(3)]`.**Note:** `Priority~3` is invalid as Priority is int not a string. |

**Using conditional operators | and &nbsp;**

| Expression | Result |
| --- | --- |
| `dotnet test --filter "FullyQualifiedName~UnitTestClass1|TestCategory=CategoryA"` | Runs tests which have `UnitTestClass1` in FullyQualifiedName **or** TestCategory is CategoryA. |
| `dotnet test --filter "FullyQualifiedName~UnitTestClass1&TestCategory=CategoryA"` | Runs tests which have `UnitTestClass1` in FullyQualifiedName **and** TestCategory is CategoryA. |
| `dotnet test --filter "(FullyQualifiedName~UnitTestClass1&TestCategory=CategoryA)|Priority=1"` | Runs tests which have either FullyQualifiedName contains `UnitTestClass1` and TestCategory is CategoryA or Priority is 1. |

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
| --- | --- |
| `dotnet test --filter DisplayName=XUnitNamespace.TestClass1.Test1` | Runs only one test `XUnitNamespace.TestClass1.Test1`. |
| `dotnet test --filter FullyQualifiedName!=XUnitNamespace.TestClass1.Test1` | Runs all tests except `XUnitNamespace.TestClass1.Test1` |
| `dotnet test --filter DisplayName~TestClass1` | Runs tests whose display name containts `TestClass1`. |

In the code example, the defined traits with keys `Category` and `Priority` can be used for filtering.

| Expression | Result |
| --- | --- |
| `dotnet test --filter XUnit` | Runs tests whose `FullyQualifiedName` contains `XUnit`.  Available in `vstest 15.1+`. |
| `dotnet test --filter Category=bvt` | Runs tests which has `[Trait("Category", "bvt")]`. |

**Using conditional operators | and &nbsp;**

| Expression | Result |
| --- | --- |
| `dotnet test --filter "FullyQualifiedName~TestClass1|Category=Nightly"` | Runs tests which has `TestClass1` in FullyQualifiedName **or** Category is Nightly. |
| `dotnet test --filter "FullyQualifiedName~TestClass1&Category=Nightly"` | Runs tests which has `TestClass1` in FullyQualifiedName **and** Category is Nightly. |
| `dotnet test --filter "(FullyQualifiedName~TestClass1&Category=Nightly)|Priority=1"` | Runs tests which have either FullyQualifiedName contains `TestClass1` and Category is CategoryA or Priority is 1. |
