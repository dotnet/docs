---
title: "MSTEST0016: Test class should have test method"
description: "Learn about code analysis rule MSTEST0016: Test class should have test method"
ms.date: 03/12/2024
f1_keywords:
- MSTEST0016
- TestClassShouldHaveTestMethod
helpviewer_keywords:
- TestClassShouldHaveTestMethod
- MSTEST0016
author: engyebrahim
ms.author: enjieid
---
# MSTEST0016: Test class should have test method

| Property                            | Value                                        |
|-------------------------------------|----------------------------------------------|
| **Rule ID**                         | MSTEST0016                                   |
| **Title**                           | Test class should have test method           |
| **Category**                        | Design                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                 |
| **Enabled by default**              | Yes                                          |
| **Default severity**                | Info                                         |
| **Introduced in version**           | 3.3.0                                        |

## Cause

A Test class should have test method.

## Rule description

Test class should have at least one test method or be `static` with method(s) marked by `[AssemblyInitialization]` and/or `[AssemblyCleanup]`.

## How to fix violations

Ensure that the test class has test method or be `static` with method(s) marked by `[AssemblyInitialization]` and/or `[AssemblyCleanup].

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, test class will be ignored.
