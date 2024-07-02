---
title: "MSTEST0030: Type containing `[TestMethod]` should be marked with `[TestClass]`"
description: "Learn about code analysis rule MSTEST0030: Type contaning `[TestMethod]` should be marked with `[TestClass]`, otherwise the test method will be silently ignored."
ms.date: 07/02/2024
f1_keywords:
- MSTEST0030
- TypeContainingTestMethodShouldBeATestClass
helpviewer_keywords:
- TypeContainingTestMethodShouldBeATestClass
- MSTEST0030
author: engyebrahim
ms.author: enjieid
---
# MSTEST0030: Type containing `[TestMethod]` should be marked with `[TestClass]`

| Property                            | Value                                                              |
|-------------------------------------|--------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0030                                                         |
| **Title**                           | Type containing `[TestMethod]` should be marked with `[TestClass]` |
| **Category**                        | Usage                                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                                       |
| **Enabled by default**              | Yes                                                                |
| **Default severity**                | Info                                                               |
| **Introduced in version**           | 3.5.0                                                              |

## Cause

Type contaning `[TestMethod]` should be marked with `[TestClass]`, otherwise the test method will be silently ignored.

## Rule description

Type contaning `[TestMethod]` which is not abstacted should be marked with `[TestClass]`, otherwise the test method will be silently ignored.

## How to fix violations

A non-abstract class contains test methods should be marked with '[TestClass]'.

## When to suppress warnings

We do not recommend suppressing warnings from this rule, otherwise the test method will be silently ignored.
