---
title: "MSTEST0009: TestCleanup method should have valid layout"
description: "Learn about code analysis rule MSTEST0009: TestCleanup method should have valid layout"
ms.date: 02/19/2024
f1_keywords:
- MSTEST0009
- TestCleanupShouldBeValidAnalyzer
helpviewer_keywords:
- TestCleanupShouldBeValidAnalyzer
- MSTEST0009
author: engyebrahim
ms.author: enjieid
---
# MSTEST0009: TestCleanup method should have valid layout

| Property                            | Value                                       |
|-------------------------------------|---------------------------------------------|
| **Rule ID**                         | MSTEST0009                                  |
| **Title**                           | TestCleanup method should have valid layout |
| **Category**                        | Usage                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                |
| **Enabled by default**              | Yes                                         |
| **Default severity**                | Warning                                     |
| **Introduced in version**           | 3.3.0                                       |

## Cause

A method marked with `[TestCleanup]` should have valid layout.

## Rule description

Methods marked with `[TestCleanup]` should follow the following layout to be valid:

- it should be `public`
- it should not be `abstract`
- it should not be `async void`
- it should not be `static`
- it should not be a special method (finalizer, operator...).
- it should not be generic
- it should not take any parameter
- return type should be `void`, `Task` or `ValueTask`

The type declaring these methods should also respect the following rules:

- the type should be a class
- the class should be `public` or `internal` (if the test project is using the `[DiscoverInternals]` attribute)
- the class should not be `static`
- if the class is sealed, it should be marked with `[TestClass]` (or a derived attribute)

## How to fix violations

Ensure that the method matches the layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.
