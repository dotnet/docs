---
title: "MSTEST0055: String method return value should not be ignored"
description: "Learn about code analysis rule MSTEST0055: String method return value should not be ignored"
ms.date: 01/29/2025
f1_keywords:
- MSTEST0055
- IgnoreStringMethodReturnValueAnalyzer
helpviewer_keywords:
- IgnoreStringMethodReturnValueAnalyzer
- MSTEST0055
author: Evangelink
ms.author: amauryleve
ai-usage: ai-generated
---
# MSTEST0055: String method return value should not be ignored

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0055                                                                               |
| **Title**                           | String method return value should not be ignored                                         |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning                                                                                  |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | No                                                                                       |

## Cause

A test method calls a string manipulation method (such as `ToUpper`, `ToLower`, `Trim`, `Replace`, `Substring`) but doesn't use the return value.

## Rule description

Strings in .NET are immutable. Methods like `ToUpper()`, `ToLower()`, `Trim()`, `Replace()`, and `Substring()` don't modify the original string; instead, they return a new string with the modifications applied. Calling these methods without using the return value has no effect and is likely a programming error.

This issue is particularly common in tests where developers might mistakenly believe they're modifying a string in place, leading to incorrect test expectations.

## How to fix violations

Capture and use the return value from string methods.

For example, change this:

```csharp
[TestMethod]
public void TestMethod()
{
    string value = "  hello world  ";
    value.Trim(); // Return value is ignored
    Assert.AreEqual("hello world", value); // This will fail
}
```

To this:

```csharp
[TestMethod]
public void TestMethod()
{
    string value = "  hello world  ";
    value = value.Trim(); // Use the return value
    Assert.AreEqual("hello world", value);
}
```

Or use the return value directly:

```csharp
[TestMethod]
public void TestMethod()
{
    string value = "  hello world  ";
    Assert.AreEqual("hello world", value.Trim());
}
```

## When to suppress warnings

Don't suppress warnings from this rule. Calling string methods without using their return value is always a bug because strings are immutable in .NET.
