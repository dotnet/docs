---
title: "MSTEST0063: Test classes should have valid constructors"
description: "Learn about code analysis rule MSTEST0063: Test classes should have valid constructors"
ms.date: 02/04/2026
f1_keywords:
- MSTEST0063
- TestClassConstructorShouldBeValidAnalyzer
helpviewer_keywords:
- TestClassConstructorShouldBeValidAnalyzer
- MSTEST0063
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0063: Test classes should have valid constructors

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0063                                         |
| **Title**                           | Test classes should have valid constructors        |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.1.0                                              |
| **Is there a code fix**             | No                                                 |

## Cause

A test class doesn't have a valid constructor. Valid constructors are `public` and either parameterless or have a single parameter of type <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>.

## Rule description

Test classes must have a public constructor that is either parameterless or accepts a single <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> parameter. This allows the test framework to instantiate the test class properly.

Constructors that are non-public, have parameters of unsupported types, or have multiple parameters aren't valid and prevent the test framework from creating instances of the test class.

```csharp
[TestClass]
public class MyTestClass
{
    private MyTestClass() // Violation - constructor is not public
    {
    }
}
```

```csharp
[TestClass]
public class MyTestClass
{
    public MyTestClass(string value) // Violation - parameter type is not supported
    {
    }
}
```

```csharp
[TestClass]
public class MyTestClass
{
    public MyTestClass(TestContext testContext, int value) // Violation - multiple parameters
    {
    }
}
```

## How to fix violations

Ensure your test class has a valid constructor. A valid constructor must be:

1. Declared as `public`.
1. Either parameterless or accepts a single <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> parameter

### Parameterless constructor

```csharp
[TestClass]
public class MyTestClass
{
    public MyTestClass()
    {
    }

    [TestMethod]
    public void TestMethod()
    {
    }
}
```

### Constructor with TestContext

```csharp
[TestClass]
public class MyTestClass
{
    private readonly TestContext _testContext;

    public MyTestClass(TestContext testContext)
    {
        _testContext = testContext;
    }

    [TestMethod]
    public void TestMethod()
    {
        _testContext.WriteLine("Test is running...");
    }
}
```

### Implicit parameterless constructor

If you don't define any constructor, the compiler generates a public parameterless constructor automatically:

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

### Valid and invalid constructors together

If your test class has multiple constructors, at least one must be valid:

```csharp
[TestClass]
public class MyTestClass
{
    public MyTestClass() // Valid - this makes the class valid
    {
    }

    private MyTestClass(int x) // Invalid, but ignored because a valid constructor exists
    {
    }

    [TestMethod]
    public void TestMethod()
    {
    }
}
```

## When to suppress warnings

Don't suppress warnings from this rule. Test classes without valid constructors can't be instantiated by the test framework, and the tests won't run.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0063
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0063
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0063.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
