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

Test methods should not have `out` or `ref` parameters. MSTest is responsible for calling test methods, and it never reads the values that are passed by reference after the test method finishes. These modifiers are misleading because they suggest the test method returns values that will be used, but MSTest never uses them after the test completes.

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
    public void TestMethod()
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
        string passedByRef = "some value";
        var instance = new MyClass();
        
        // Act
        bool success = instance.TryGetValue(out result, ref passedByRef);
        
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
    [TestMethod]
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

Do not suppress warnings from this rule. There is no valid scenario where test methods should use `out` or `ref` parameters.

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
