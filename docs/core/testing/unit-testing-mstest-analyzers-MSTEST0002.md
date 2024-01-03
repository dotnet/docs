---
title: "MSTEST0002: Test classes should have valid layout"
description: "Learn about code analysis rule MSTEST0002: Test classes should have valid layout"
ms.date: 01/03/2024
f1_keywords:
- MSTEST0002
- TestClassShouldBeValidAnalyzer
helpviewer_keywords:
- TestClassShouldBeValidAnalyzer
- MSTEST0002
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0002: Test classes should have valid layout

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0002                                         |
| **Title**                           | Test classes should have valid layout              |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Breaking                                           |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |

## Cause

A test class is not following one or multiple points of the required test class layout.

## Rule description

Test classes (classes marked with the `[TestClass]` attribute) should follow the given layout to be considered valid by MSTest:

- they should be `public` (or `internal` if the `[assembly: DiscoverInternals]` assembly attribute is set)
- they should not be `static`
- they should not be generic

## How to fix violations

Ensure that the class matches the required layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. Ignoring this rule will result in tests being ignored, because MSTest will not consider this class to be a test class.
