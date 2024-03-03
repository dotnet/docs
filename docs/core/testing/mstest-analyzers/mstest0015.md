---
title: "MSTEST0015: Test method should not be ignored"
description: "Learn about code analysis rule MSTEST0015: Test method should not be ignored"
ms.date: 03/01/2024
f1_keywords:
- MSTEST0015
- TestMethodShouldNotBeIgnored
helpviewer_keywords:
- TestMethodShouldNotBeIgnored
- MSTEST0015
author: engyebrahim
ms.author: enjieid
---
# MSTEST0015: Test method should not be ignored

| Property                            | Value                                        |
|-------------------------------------|----------------------------------------------|
| **Rule ID**                         | MSTEST0015                                   |
| **Title**                           | Test method should not be ignored            |
| **Category**                        | Design                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                 |
| **Enabled by default**              | Yes                                          |
| **Default severity**                | Info                                         |
| **Introduced in version**           | 3.3.0                                        |

## Cause

A Test method should not be ignored.

## Rule description

Test methods should not be ignored (marked with `[Ignore]`).

## How to fix violations

Ensure that the test method isn't ignored.

