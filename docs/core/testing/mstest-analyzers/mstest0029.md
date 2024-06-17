---
title: "MSTEST0029: Public method should be test method"
description: "Learn about code analysis rule MSTEST0029: Public method should be test method"
ms.date: 04/06/2024
f1_keywords:
- MSTEST0029
- PublicMethodShouldBeTestMethod
helpviewer_keywords:
- PublicMethodShouldBeTestMethod
- MSTEST0029
author: engyebrahim
ms.author: enjieid
---
# MSTEST0029: Public method should be test method

| Property                            | Value                                        |
|-------------------------------------|----------------------------------------------|
| **Rule ID**                         | MSTEST0029                                   |
| **Title**                           | Public method should be test method          |
| **Category**                        | Design                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                 |
| **Enabled by default**              | No                                           |
| **Default severity**                | Info                                         |
| **Introduced in version**           | 3.5.0                                        |

## Cause

A Public method should be a test method.

## Rule description

A Public method should be a test method (marked with `[TestMethod]`).

## How to fix violations

Ensure that the public method is a test method (marked with `[TestMethod]`).

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, the public method won't be considered as a test method.
