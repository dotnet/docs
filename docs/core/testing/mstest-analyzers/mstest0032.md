---
title: "MSTEST0032: Review or remove the assertion as its condition is known to be always true."
description: "Learn about code analysis rule MSTEST0032: Review or remove the assertion as its condition is known to be always true."
ms.date: 07/11/2024
f1_keywords:
- MSTEST0032
- ReviewAlwaysTrueAssertConditionAnalyzer
helpviewer_keywords:
- ReviewAlwaysTrueAssertConditionAnalyzer
- MSTEST0032
author: engyebrahim
ms.author: enjieid
---
# MSTEST0032: Review or remove the assertion as its condition is known to be always true.

| Property                            | Value                                                                       |
|-------------------------------------|-----------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0032                                                                  |
| **Title**                           | Review or remove the assertion as its condition is known to be always true. |
| **Category**                        | Usage                                                                      |
| **Fix is breaking or non-breaking** | Non-breaking                                                                |
| **Enabled by default**              | Yes                                                                         |
| **Default severity**                | Info                                                                        |
| **Introduced in version**           | 3.5.0                                                                       |

## Cause

This rule raises a diagnostic when a call to an assertion produces an always-true condition.

## Rule description

When you encounter an assertion that always passes (for example, `Assert.IsTrue(true)`), it is not obvious to someone reading the code why the assertion is there or what condition it's trying to check. This can lead to confusion and wasted time for developers who come across the code later on.

## How to fix violations

Ensure that calls to `Assert.IsTrue`, `Assert.IsFalse`, `Assert.AreEqual`, `Assert.AreNotEqual`, `Assert.IsNull` or `Assert.IsNotNull` aren't producing always-true conditions.

## When to suppress warnings

It's _not_ recommended to suppress warnings from this rule.
