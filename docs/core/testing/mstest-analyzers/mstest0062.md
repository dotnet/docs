---
title: "MSTEST0062: Avoid out and ref parameters in test methods"
description: "Learn about code analysis rule MSTEST0062: Avoid out and ref parameters in test methods"
ms.date: 12/29/2025
f1_keywords:
- MSTEST0062
- AvoidOutRefTestMethodParametersAnalyzer
helpviewer_keywords:
- AvoidOutRefTestMethodParametersAnalyzer
- MSTEST0062
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0062: Avoid out and ref parameters in test methods

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0062                                         |
| **Title**                           | Avoid out and ref parameters in test methods      |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.1.0                                              |
| **Is there a code fix**             | Yes                                                |

## Cause

A test method has parameters marked with `out` or `ref` modifiers.

## Rule description

Test methods should not have `out` or `ref` parameters because these modifiers are incompatible with data-driven testing. Data sources provide values to test methods through standard parameter passing, and the `out` and `ref` modifiers create conflicts with this mechanism. Using regular parameters makes tests more maintainable and compatible with parameterized test features.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public void TestMethod(out string s, ref string s2) // Violation
    {
        s = "test";
    }
}
```

## How to fix violations

Remove the `out` and `ref` modifiers from test method parameters.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public void TestMethod(string s, string s2)
    {
        // Test code
    }
}
```

If you need to test methods with `out` or `ref` parameters, call them from within your test method:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public void TestMethodWithOutParameter()
    {
        // Arrange
        string result;
        var instance = new MyClass();
        
        // Act
        bool success = instance.TryGetValue(out result);
        
        // Assert
        Assert.IsTrue(success);
        Assert.AreEqual("expected", result);
    }
}
```

For data-driven tests:

```csharp
[TestClass]
public class TestClass
{
    [DataTestMethod]
    [DataRow("input1", "expected1")]
    [DataRow("input2", "expected2")]
    public void TestMethod(string input, string expected)
    {
        // Arrange
        string result;
        var instance = new MyClass();
        
        // Act
        bool success = instance.TryParse(input, out result);
        
        // Assert
        Assert.IsTrue(success);
        Assert.AreEqual(expected, result);
    }
}
```

## When to suppress warnings

You might suppress this warning if you have a specific advanced scenario that requires `out` or `ref` parameters. However, this is rare, and you should consider alternative test designs first.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0062
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0062
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0062.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
