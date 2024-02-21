---
title: "MSTEST0012: AssemblyInitialize method should have valid layout"
description: "Learn about code analysis rule MSTEST0012: AssemblyInitialize method should have valid layout"
ms.date: 02/19/2024
f1_keywords:
- MSTEST0012
- AssemblyInitializeShouldBeValidAnalyzer
helpviewer_keywords:
- AssemblyInitializeShouldBeValidAnalyzer
- MSTEST0012
author: engyebrahim
ms.author: enjieid
---
# MSTEST0012: `AssemblyInitialize` should be valid

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0012                                         |
| **Title**                           | AssemblyInitialize method should have valid layout |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 3.3.0                                              |

## Cause

A method marked with `AssemblyInitialize` should have valid layout.

## Rule description

Methods marked with `[AssemblyInitialize]` should follow the following layout to be valid:

- it should be `public`
- it should be `static`
- it should not be `async void`
- it should not be a special method (finalizer, operator...).
- it should not be generic
- it should take one parameter of type `TestContext`
- return type should be `void`, `Task` or `ValueTask`

## How to fix violations

Ensure that the method matches the layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.
