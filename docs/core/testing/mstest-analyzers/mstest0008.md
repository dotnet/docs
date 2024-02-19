---
title: "MSTEST0008: `TestInitialize` should be valid"
description: "Learn about code analysis rule MSTEST0008: Ensure `TestInitialize` has a valid layout"
ms.date: 02/19/2024
f1_keywords:
- MSTEST0008
- TestInitializeShouldBeValidAnalyzer
helpviewer_keywords:
- TestInitializeShouldBeValidAnalyzer
- MSTEST0008
author: engyebrahim
ms.author: engyebrahim
---
# MSTEST0008: `TestInitialize` should be valid

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0008                               |
| **Title**                           | `TestInitialize` should be valid         |
| **Category**                        | Usage                                    |
| **Fix is breaking or non-breaking** | Non-breaking                             |
| **Enabled by default**              | Yes                                      |
| **Default severity**                | Warning                                  |
| **Introduced in version**           | 3.3.0                                    |

## Cause

A method marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestInitialize> should have valid layout.

## Rule description

Methods marked with `[TestInitialize]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should not be `static`<br/>- it should not be generic<br/>- it should not be `abstract`<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).

## How to fix violations

To fix a violation of this rule, you should fix the layout.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, your tests woun't run.
