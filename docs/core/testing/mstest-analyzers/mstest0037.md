---
title: "Use proper 'Assert' methods"
description: "Learn about code analysis rule MSTEST0037: Use proper 'Assert' methods."
ms.date: 11/17/2024
f1_keywords:
- MSTEST0037
- UseProperAssertMethodsAnalyzer
helpviewer_keywords:
- UseProperAssertMethodsAnalyzer
- MSTEST0037
author: Youssef1313
ms.author: ygerges
---
# MSTEST0037: Use proper 'Assert' methods

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0037                                                             |
| **Title**                           | Use proper 'Assert' methods                                            |
| **Category**                        | Usage                                                                  |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Info                                                                   |
| **Introduced in version**           | 3.7.0                                                                  |
| **Is there a code fix**             | Yes                                                                    |

## Cause

The use of <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods in a specific way when there is a better alternative.

## Rule description

There are multiple cases where you get this warning:

- The use of `Assert.IsTrue(<expression> == null)` (with all combinations, like `IsFalse`, `!= null`, `is null`, or `is not null`).

    Using `Assert.IsNull(<expression>)` or `Assert.IsNotNull(<expression>)` is a better alternative.

- The use of `Assert.IsTrue(<expression1> == <expression2>)` (with all combinations, like `IsFalse` or `!=`).

    Using `Assert.AreEqual(<expression1>, <expression2>)` or `Assert.AreNotEqual(<expression1>, <expression2>)` is a better alternative.

- The use of `Assert.AreEqual(true, <expression>)` or `Assert.AreEqual(false, <expression>)`.

    Using `Assert.IsTrue(<expression>)` or `Assert.IsFalse(<expression>)` is a better alternative.

- The use of `Assert.AreEqual(null, <expression>)` or `Assert.AreNotEqual(null, <expression>)`.

    Using `Assert.IsNull(<expression>)` or `Assert.IsNotNull<expression>` is a better alternative.

In many cases, the better alternatives provide better messages when they fail and are also easier to read.

## How to fix violations

Use the better alternative method.

## When to suppress warnings

If the assert is intended to verify the behavior of a user-defined operator, you can and should suppress the warning.
