---
title: "MSTEST0003: Test methods should have valid layout"
description: "Learn about code analysis rule MSTEST0003: Test methods should have valid layout"
ms.date: 01/03/2024
f1_keywords:
- MSTEST0003
- TestMethodShouldBeValidAnalyzer
helpviewer_keywords:
- TestMethodShouldBeValidAnalyzer
- MSTEST0003
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0003: Test methods should have valid layout

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0003                                         |
| **Title**                           | Test methods should have valid layout              |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Breaking                                           |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |

## Cause

A test method is not following single or multiple points of the required test method layout.

## Rule description

Test methods (methods marked with the `[TestMethod]` attribute) should follow the given layout to be considered valid by MSTest:

- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)
- it should not be `static`
- it should not be generic
- it should not be `abstract`
- it should return `void` or `Task`
- it should not be `async void`
- it should not be a special method (constructor, finalizer, operator...)

## How to fix violations

Ensure that the test method matches the required layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. Ignoring this rule will result in tests being ignored, because MSTest will not consider this method to be a test method.
