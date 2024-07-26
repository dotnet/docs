---
title: "MSTEST0034: Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`."
description: "Learn about code analysis rule MSTEST0034: Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`."
ms.date: 07/22/2024
f1_keywords:
- MSTEST0034
- UseClassCleanupBehaviorEndOfClass
helpviewer_keywords:
- UseClassCleanupBehaviorEndOfClass
- MSTEST0034
author: engyebrahim
ms.author: enjieid
---
# MSTEST0034: Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`.

| Property                            | Value                                                            |
|-------------------------------------|------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0034                                                       |
| **Title**                           | Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`. |
| **Category**                        | Usage                                                            |
| **Fix is breaking or non-breaking** | Non-breaking                                                     |
| **Enabled by default**              | Yes                                                              |
| **Default severity**                | Info                                                             |
| **Introduced in version**           | 3.6.0                                                            |

## Cause

This rule raises a diagnostic when `ClassCleanupBehavior.EndOfClass` isn't seted with the `[ClassCleanup]`.

## Rule description

Without using  `ClassCleanupBehavior.EndOfClass`, the `[ClassCleanup]` will by default be run at the end of the assembly and not at the end of the class.

## How to fix violations

Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`.

## When to suppress warnings

It's _not_ recommended to suppress warnings from this rule as you can use instead `[AssemblyCleanup]`.
