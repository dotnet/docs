---
title: "MSTEST0058: Avoid assertions in catch blocks"
description: "Learn about code analysis rule MSTEST0058: Avoid assertions in catch blocks"
ms.date: 12/29/2024
f1_keywords:
- MSTEST0058
- AvoidAssertsInCatchBlocksAnalyzer
helpviewer_keywords:
- AvoidAssertsInCatchBlocksAnalyzer
- MSTEST0058
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
- VB
---
# MSTEST0058: Avoid assertions in `catch` blocks

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0058                                         |
| **Title**                           | Avoid assertions in catch blocks                  |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.1.0                                              |
| **Is there a code fix**             | No                                                 |

## Cause

A test method contains assertion statements within a `catch` block.

## Rule description

Placing assertions in `catch` blocks is an anti-pattern that can lead to confusing test results and makes tests harder to understand. When an exception is thrown, the `catch` block executes, and the assertion runs. However, if no exception is thrown, the `catch` block never executes, potentially giving false confidence that the test passed.

Instead, use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Throws*?displayProperty=nameWithType> or similar methods to verify that expected exceptions are thrown. This makes the test intent clearer and ensures proper test behavior.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public void TestMethod()
    {
        try
        {
            // Code that might throw.
            DoSomethingThatMightThrow();
        }
        catch
        {
            Assert.Fail("Exception was thrown"); // Violation
        }
    }
}
```

## How to fix violations

Use `Assert.ThrowsException` or related assertion methods to test for exceptions.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public void TestMethod_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => DoSomethingThatMightThrow());
    }

    [TestMethod]
    public void TestMethod_DoesNotThrow()
    {
        // If no exception is expected, just call the method directly
        DoSomethingThatMightNotThrow();
        // Add positive assertions here
    }
}
```

## When to suppress warnings

You might suppress this warning if you have a legitimate need to catch an exception and perform complex validation that cannot be easily expressed using standard assertion methods. However, consider refactoring your test to use more explicit exception assertions first.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0058
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0058
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0058.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
