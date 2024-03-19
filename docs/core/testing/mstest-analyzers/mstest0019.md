---
title: "MSTEST0019: Prefer TestInitialize methods over constructors"
description: "Learn about code analysis rule MSTEST0019: Prefer TestInitialize methods over constructors"
ms.date: 03/19/2024
f1_keywords:
- MSTEST0019
- PreferTestInitializeOverConstructorAnalyzer
helpviewer_keywords:
- PreferTestInitializeOverConstructorAnalyzer
- MSTEST0019
author: Evangelink
ms.author: amauryleve
---
# MSTEST0019: Prefer TestInitialize methods over constructors

| Property                            | Value                                           |
|-------------------------------------|-------------------------------------------------|
| **Rule ID**                         | MSTEST0019                                      |
| **Title**                           | Prefer TestInitialize methods over constructors |
| **Category**                        | Design                                          |
| **Fix is breaking or non-breaking** | Non-breaking                                    |
| **Enabled by default**              | No                                              |
| **Default severity**                | Info                                            |
| **Introduced in version**           | 3.4.0                                           |

## Cause

This rule raises a diagnostic when there is a parameterless explicit constructor declared on a test class (class marked with `[TestClass]`).

## Rule description

Some developers prefer to always use `[TestInitialize]` method instead of constructors for their test setup as it provides a symmetrical initialization to doing async/await initialization where you do require `[TestInitialize]` methods.

## How to fix violations

Replace the constructor call with a `[TestInitialize]` method.

## When to suppress warnings

You usually don't want to suppress warnings from this rule if you decided to opt-in for it.
