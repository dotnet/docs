---
title: "MSTEST0040: Do not assert inside 'async void' contexts"
description: "Learn about code analysis rule MSTEST0040: Do not assert inside 'async void' methods, local functions, or lambdas because they may not fail the test"
ms.date: 01/17/2025
f1_keywords:
- MSTEST0040
- AvoidUsingAssertsInAsyncVoidContextAnalyzer
helpviewer_keywords:
- AvoidUsingAssertsInAsyncVoidContextAnalyzer
- MSTEST0040
author: Youssef1313
ms.author: ygerges
---
# MSTEST0040: Do not assert inside 'async void' contexts

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0040                                                             |
| **Title**                           | Do not assert inside 'async void' contexts                             |
| **Category**                        | Usage                                                                  |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Warning                                                                |
| **Introduced in version**           | 3.8.0                                                                  |
| **Is there a code fix**             | No                                                                     |

## Cause

The use of any assertion method in an `async void` method, local function, or lambda.

## Rule description

Exceptions that are thrown in an `async void` context are unhandled. A failing assertion in an `async void` method will be swallowed and will not crash the process when using VSTest under .NET Framework. Under .NET, a failing assertion in an `async void` method might crash the process when using Microsoft.Testing.Platform or VSTest. In cases where a custom `SynchronizationContext` is present that catches the exception, the failing assertion might be silently swallowed.

## How to fix violations

Refactor the code to not use assertions in `async void`.

## When to suppress warnings

Do not suppress a warning from this rule.
