---
title: "MSTEST0053: Avoid Assert method format parameters"
description: "Learn about code analysis rule MSTEST0053: Avoid Assert method format parameters"
ms.date: 01/29/2025
f1_keywords:
- MSTEST0053
- AvoidAssertFormatParametersAnalyzer
helpviewer_keywords:
- AvoidAssertFormatParametersAnalyzer
- MSTEST0053
author: Evangelink
ms.author: amauryleve
ai-usage: ai-generated
---
# MSTEST0053: Avoid Assert method format parameters

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0053                                                                               |
| **Title**                           | Avoid Assert method format parameters                                                    |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning                                                                                  |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | Yes                                                                                      |

## Cause

An assertion method call uses the `message` and `parameters` arguments for string formatting instead of using string interpolation.

## Rule description

Older versions of MSTest assertion methods accepted a `message` parameter and a `params object[]` array for formatting the message. Modern C# supports string interpolation, which provides better compile-time checking, readability, and performance. The newer assertion method overloads support interpolated strings directly, making the format parameters obsolete.

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

Don't suppress warnings from this rule. String interpolation provides better compile-time safety and readability compared to format parameters.
