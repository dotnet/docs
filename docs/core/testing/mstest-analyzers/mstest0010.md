---
title: "MSTEST0009: `ClassInitialize` should be valid"
description: "Learn about code analysis rule MSTEST0009: Ensure `ClassInitialize` has a valid layout"
ms.date: 02/19/2024
f1_keywords:
- MSTEST0009
- ClassInitializeShouldBeValidAnalyzer
helpviewer_keywords:
- ClassInitializeShouldBeValidAnalyzer
- MSTEST0009
author: engyebrahim
ms.author: engyebrahim
---
# MSTEST0009: `ClassInitialize` should be valid

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0009                               |
| **Title**                           | `ClassInitialize` should be valid         |
| **Category**                        | Usage                                    |
| **Fix is breaking or non-breaking** | Non-breaking                             |
| **Enabled by default**              | Yes                                      |
| **Default severity**                | Warning                                  |
| **Introduced in version**           | 3.3.0                                    |

## Cause

A method marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitialize> should have valid layout.

## Rule description

Methods marked with `[ClassInitialize]` should follow the following layout to be valid:
  
- it should be `public`
- it should be `static`
- it should not be `async void`
- it should not be a special method (finalizer, operator...).
- it should not be generic
- it should take one parameter of type `TestContext`
- return type should be `void`, `Task` or `ValueTask`

## How to fix violations

To fix a violation of this rule, you should fix the layout.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, your tests woun't run.
