---
title: "MSTEST0004: Public types should be test classes"
description: "Learn about code analysis rule MSTEST0004: Public types should be test classes"
ms.date: 01/03/2024
f1_keywords:
- MSTEST0004
- TestClassShouldBeValidAnalyzer
helpviewer_keywords:
- TestClassShouldBeValidAnalyzer
- MSTEST0004
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0004: Public types should be test classes

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0004                                         |
| **Title**                           | Public types should be test classes                |
| **Category**                        | Design                                             |
| **Fix is breaking or non-breaking** | Breaking                                           |
| **Enabled by default**              | No                                                 |
| **Default severity**                | Disabled                                           |

## Cause

A public type is not a test class (class marked with the `[TestClass]` attribute).

## Rule description

It's considered a good practice to keep all helper and base classes `internal` and have only test classes marked `public` in a test project.

## How to fix violations

Change the accessibility of the type to not be `public`.

## When to suppress warnings

You can suppress instances of this diagnostic if the type should remain `public` for compatibility reason.
