---
title: "Do not use shadowing inside test class."
description: "Learn about code analysis rule MSTEST0036: Do not use shadowing inside test class."
ms.date: 08/19/2024
f1_keywords:
- MSTEST0036
- DoNotUseShadowingAnalyzer
helpviewer_keywords:
- DoNotUseShadowingAnalyzer
- MSTEST0036
author: engyebrahim
ms.author: enjieid
---
# MSTEST0036: Do not use shadowing inside test class.

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0036                                                             |
| **Title**                           | Do not use shadowing inside test class.                                |
| **Category**                        | Design                                                                 |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Warning                                                                |
| **Introduced in version**           | 3.6.0                                                                  |
| **There is a code fix**             | No                                                                     |

## Cause

Shadowing test members could cause testing issues (such as NRE).

## Rule description

Shadowing test members could cause testing issues (such as NRE).

## How to fix violations

Delete the shadowing member.

## When to suppress warnings

Don't suppress warnings from this rule as it could cause testing issues (such as NRE).
