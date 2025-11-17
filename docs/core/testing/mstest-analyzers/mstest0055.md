---
title: "MSTEST0055: Do not ignore the return value of string methods"
description: "Learn about code analysis rule MSTEST0055: Do not ignore the return value of string methods"
ms.date: 10/01/2025
f1_keywords:
- MSTEST0055
- IgnoreStringMethodReturnValueAnalyzer
helpviewer_keywords:
- IgnoreStringMethodReturnValueAnalyzer
- MSTEST0055
author: Youssef1313
ms.author: ygerges
ai-usage: ai-generated
---
# MSTEST0055: Do not ignore the return value of string methods

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0055                                                                               |
| **Title**                           | Do not ignore the return value of string methods                                         |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning                                                                                  |
| **Introduced in version**           | 3.11.0                                                                                   |
| **Is there a code fix**             | No                                                                                       |

## Cause

A call to `string.Contains`, `string.StartsWith`, or `string.EndsWith` is made and its return value is ignored.

## Rule description

Those methods don't have any side effects and ignoring the return result is always wrong. It's more likely that the original intent of those calls are to assert that they are true.

## How to fix violations

Capture and use the return value from string methods, or use a proper assertion method.

For example, change this:

```csharp
[TestMethod]
public void TestMethod()
{
    string value = "Hello world";
    value.StartsWith("Hello");
}
```

To this:

```csharp
[TestMethod]
public void TestMethod()
{
    string value = "Hello world";
    Assert.IsTrue(value.StartsWith("Hello")); // or, Assert.StartsWith("Hello", value);
}
```

## When to suppress warnings

Don't suppress warnings from this rule. Calling string methods without using their return value is always a bug or a dead code.
