---
title: "MSTEST0053: Avoid using Assert methods with format parameters"
description: "Learn about code analysis rule MSTEST0053: Avoid using Assert methods with format parameters"
ms.date: 11/05/2026
f1_keywords:
- MSTEST0053
- AvoidAssertFormatParametersAnalyzer
helpviewer_keywords:
- AvoidAssertFormatParametersAnalyzer
- MSTEST0053
author: Youssef1313
ms.author: ygerges
ai-usage: ai-generated
---
# MSTEST0053: Avoid using Assert methods with format parameters

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0053                                                                               |
| **Title**                           | Avoid using Assert methods with format parameters                                        |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning                                                                                  |
| **Introduced in version**           | 3.11.0                                                                                   |
| **Is there a code fix**             | Yes                                                                                      |

> [!NOTE]
> This analyzer is no longer relevant for MSTest 4 as the assertion APIs with format parameters were removed.

## Cause

An assertion method call uses the `message` and `parameters` arguments for string formatting instead of using string interpolation.

## Rule description

Format-parameter overloads refer to message values by numeric position, so a change to the argument list can leave a placeholder associated with the wrong value. The compiler doesn't check that each numeric placeholder refers to the value you intended.

String interpolation places each expression next to the message text that describes it and lets the compiler check the referenced variables. That makes failure messages easier to read and refactor. The format-parameter overloads are also removed in MSTest 4, so interpolation avoids a dependency on those older APIs.

## How to fix violations

Replace calls that use message format parameters with string interpolation.

For example, change this:

```csharp
[TestMethod]
public void TestMethod()
{
    int expected = 5;
    int actual = GetValue();
    Assert.AreEqual(expected, actual, "Expected {0} but got {1}", expected, actual);
}
```

To this:

```csharp
[TestMethod]
public void TestMethod()
{
    int expected = 5;
    int actual = GetValue();
    Assert.AreEqual(expected, actual, $"Expected {expected} but got {actual}");
}
```

## When to suppress warnings

Don't suppress warnings from this rule. These overloads are removed in MSTest v4 and are not recommended.
