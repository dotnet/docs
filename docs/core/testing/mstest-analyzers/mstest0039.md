---
title: "MSTEST0039: Use newer 'Assert.Throws' methods"
description: "Learn about code analysis rule MSTEST0039: Use 'Assert.ThrowsExactly' instead of 'Assert.ThrowsException'"
ms.date: 01/17/2025
f1_keywords:
- MSTEST0039
- UseNewerAssertThrowsAnalyzer
helpviewer_keywords:
- UseNewerAssertThrowsAnalyzer
- MSTEST0039
author: Youssef1313
ms.author: ygerges
---
# MSTEST0039: Use newer 'Assert.Throws' methods

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0039                                                             |
| **Title**                           | Use newer 'Assert.Throws' methods                                      |
| **Category**                        | Usage                                                                  |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Info                                                                   |
| **Introduced in version**           | 3.8.0                                                                  |
| **Is there a code fix**             | Yes                                                                    |

## Cause

The use of `Assert.ThrowsException` or `Assert.ThrowsExceptionAsync`, which are no longer recommended.

## Rule description

The `Assert.ThrowsException` and `Assert.ThrowsExceptionAsync` methods aren't recommended and might be deprecated in the future.

## How to fix violations

Use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExactly*?displayProperty=nameWithType> or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExactlyAsync*?displayProperty=nameWithType> instead of `Assert.ThrowsException` or `Assert.ThrowsExceptionAsync`.

## When to suppress warnings

Do not suppress a warning from this rule. It's strongly recommended to move from the old APIs to the new ones.
