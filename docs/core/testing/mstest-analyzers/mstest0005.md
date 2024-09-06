---
title: "MSTEST0005: Test context property should have valid layout"
description: "Learn about code analysis rule MSTEST0005: Test context property should have valid layout"
ms.date: 01/03/2024
f1_keywords:
- MSTEST0005
- TestContextShouldBeValidAnalyzer
helpviewer_keywords:
- TestContextShouldBeValidAnalyzer
- MSTEST0005
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0005: Test context property should have valid layout

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0005                                         |
| **Title**                           | Test context property should have valid layout     |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 3.2.0                                              |
| **There is a code fix**             | Yes                                                |

## Cause

A test context property is not following single or multiple points of the required test context layout.

## Rule description

`TestContext` properties should follow the given layout to be considered valid by MSTest:

- they should be properties and not fields
- they should be named `TestContext` (case insensitive)
- they should be `public` (or `internal` if the `[assembly: DiscoverInternals]` assembly attribute is set)
- they should not be `static`
- they should not be readonly

## How to fix violations

Ensure that the `TestContext` property matches the required layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. Ignoring this rule will result in the `TestContext` not being injected by MSTest, thus resulting in `NullReferenceException` or inconsistent state when using the property.
