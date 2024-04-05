---
title: "MSTEST0022: Prefer TestCleanup over Dispose methods"
description: "Learn about code analysis rule MSTEST0022: Prefer TestCleanup over Dispose methods"
ms.date: 03/19/2024
f1_keywords:
- MSTEST0022
- PreferTestCleanupOverDisposeAnalyzer
helpviewer_keywords:
- PreferTestCleanupOverDisposeAnalyzer
- MSTEST0022
author: Evangelink
ms.author: amauryleve
---
# MSTEST0022: Prefer TestCleanup over Dispose methods

| Property                            | Value                                   |
|-------------------------------------|-----------------------------------------|
| **Rule ID**                         | MSTEST0022                              |
| **Title**                           | Prefer TestCleanup over Dispose methods |
| **Category**                        | Design                                  |
| **Fix is breaking or non-breaking** | Non-breaking                            |
| **Enabled by default**              | No                                      |
| **Default severity**                | Info                                    |
| **Introduced in version**           | 3.4.0                                   |

## Cause

This rule raises a diagnostic when a `Dispose` or `DisposeAsync` method is detected.

## Rule description

Although `Dispose` or `DisposeAsync` is a more common pattern, some developers prefer to always use `[TestCleanup]` for their test cleanup phase as the method is allowing async pattern even in older version of .NET.

## How to fix violations

Replace `Dispose` or `DisposeAsync` methods with `[TestCleanup]`.

## When to suppress warnings

You usually don't want to suppress warnings from this rule if you decided to opt-in for it.
