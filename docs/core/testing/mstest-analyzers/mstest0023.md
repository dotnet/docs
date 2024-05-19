---
title: "MSTEST0023: Do not negate boolean assertions"
description: "Learn about code analysis rule MSTEST0023: Do not negate boolean assertions"
ms.date: 03/19/2024
f1_keywords:
- MSTEST0023
- DoNotNegateBooleanAssertionAnalyzer
helpviewer_keywords:
- DoNotNegateBooleanAssertionAnalyzer
- MSTEST0023
author: Evangelink
ms.author: amauryleve
---
# MSTEST0023: Do not negate boolean assertions

| Property                            | Value                            |
|-------------------------------------|----------------------------------|
| **Rule ID**                         | MSTEST0023                       |
| **Title**                           | Do not negate boolean assertions |
| **Category**                        | Usage                            |
| **Fix is breaking or non-breaking** | Non-breaking                     |
| **Enabled by default**              | Yes                              |
| **Default severity**                | Info                             |
| **Introduced in version**           | 3.4.0                            |

## Cause

This rule raises a diagnostic when a call to `Assert.IsTrue` or `Assert.IsFalse` contains a negated argument.

## Rule description

MSTest assertion library contains opposite APIs that makes it easier to test `true` and `false` cases. It is recommend to use the right API for the right case as it is improving readability and also provides better information in case of failure.

## How to fix violations

When negating argument in a `Assert.IsTrue` call, you should use `Assert.IsFalse`.
When negating argument in a `Assert.IsFalse` call, you should use `Assert.IsTrue`.

## When to suppress warnings

Do not suppress warnings from this rule.
