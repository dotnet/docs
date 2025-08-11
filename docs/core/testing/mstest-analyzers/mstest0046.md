---
title: "MSTEST0046: Use Assert instead of StringAssert"
description: "Learn about code analysis rule MSTEST0046: Use Assert instead of StringAssert"
ms.date: 07/24/2025
f1_keywords:
- MSTEST0046
- StringAssertToAssertAnalyzer
helpviewer_keywords:
- StringAssertToAssertAnalyzer
- MSTEST0046
author: Evangelink
ms.author: amauryleve
---
# MSTEST0046: Use Assert instead of StringAssert

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0046                                                                               |
| **Title**                           | Use Assert instead of StringAssert                                                       |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Info                                                                                     |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | Yes                                                                                      |

## Cause

A test method uses <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> methods instead of equivalent <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods.

## Rule description

<xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> methods have equivalent counterparts in <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> that provide the same functionality. Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods for consistency, better readability, improved discoverability, and alignment with behavior across all test frameworks.

The following <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> methods have equivalent <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods:

- `StringAssert.Contains(value, substring)` → `Assert.Contains(substring, value)`
- `StringAssert.StartsWith(value, substring)` → `Assert.StartsWith(substring, value)`
- `StringAssert.EndsWith(value, substring)` → `Assert.EndsWith(substring, value)`
- `StringAssert.Matches(value, pattern)` → `Assert.MatchesRegex(pattern, value)`
- `StringAssert.DoesNotMatch(value, pattern)` → `Assert.DoesNotMatchRegex(pattern, value)`

> [!WARNING]
> When migrating from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> to <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods, be careful about the change in parameter order. In <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods, the expected value is always the first parameter.

## How to fix violations

Use the provided code fixer to automatically replace <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> method calls with their equivalent <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods. You can also manually replace the method calls if needed.

## When to suppress warnings

Don't suppress warnings from this rule. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods provide the same functionality with better consistency.
