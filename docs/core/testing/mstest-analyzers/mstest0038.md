---
title: "Don't use 'Assert.AreSame' with value types"
description: "Learn about code analysis rule MSTEST0038: Don't use 'Assert.AreSame' with value types"
ms.date: 01/06/2025
f1_keywords:
- MSTEST0038
- AvoidAssertAreSameWithValueTypesAnalyzer
helpviewer_keywords:
- AvoidAssertAreSameWithValueTypesAnalyzer
- MSTEST0038
author: Youssef1313
ms.author: ygerges
---
# MSTEST0038: Don't use 'Assert.AreSame' with value types

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0038                                                             |
| **Title**                           | Don't use 'Assert.AreSame' with value types                            |
| **Category**                        | Usage                                                                  |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Warning                                                                |
| **Introduced in version**           | 3.8.0                                                                  |
| **Is there a code fix**             | Yes                                                                    |

## Cause

The use of <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame%2A?displayProperty=nameWithType> with one or both arguments being a value type.

## Rule description

The way <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame%2A?displayProperty=nameWithType> works is by comparing the *reference* of the given expected and actual arguments via `ReferenceEquals`. Hence, when you pass a value type, it will be [boxed](../../../csharp/programming-guide/types/boxing-and-unboxing.md#boxing). So, the assert will always fail.

## How to fix violations

Use `Assert.AreEqual` instead of `Assert.AreSame`.

## When to suppress warnings

Do not suppress a warning from this rule. Ignoring this rule will result in an assertion that will fail.