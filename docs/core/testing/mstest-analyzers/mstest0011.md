---
title: "MSTEST0011: `ClassCleanup` should be valid"
description: "Learn about code analysis rule MSTEST0011: Ensure `ClassCleanup` has a valid layout"
ms.date: 02/19/2024
f1_keywords:
- MSTEST0011
- ClassCleanupShouldBeValidAnalyzer
helpviewer_keywords:
- ClassCleanupShouldBeValidAnalyzer
- MSTEST0011
author: engyebrahim
ms.author: enjieid
---
# MSTEST0011: `ClassCleanup` should be valid

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0011                               |
| **Title**                           | `ClassCleanup` should be valid         |
| **Category**                        | Usage                                    |
| **Fix is breaking or non-breaking** | Non-breaking                             |
| **Enabled by default**              | Yes                                      |
| **Default severity**                | Warning                                  |
| **Introduced in version**           | 3.3.0                                    |

## Cause

A method marked with `ClassCleanup` should have valid layout.

## Rule description

Methods marked with `[ClassCleanup]` should follow the following layout to be valid:

- it should be `public`
- it should be `static`
- it should not be `async void`
- it should not be a special method (finalizer, operator...).
- it should not be generic
- it should not take any parameter
- return type should be `void`, `Task` or `ValueTask`

## How to fix violations

To fix a violation of this rule, you should fix the layout.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, your tests woun't run.
