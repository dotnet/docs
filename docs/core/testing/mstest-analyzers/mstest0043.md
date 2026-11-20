---
title: "MSTEST0043: Use retry attribute on test method"
description: "Learn about code analysis rule MSTEST0043: Use retry attribute on test method"
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0043
- UseRetryWithTestMethodAnalyzer
helpviewer_keywords:
- UseRetryWithTestMethodAnalyzer
- MSTEST0043
author: Youssef1313
ms.author: ygerges
---
# MSTEST0043: Use retry attribute on test method

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0043                                                                               |
| **Title**                           | Use retry attribute on test method                                                       |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning (escalated to Error when setting `MSTestAnalysisMode` to `Recommended` or `All`) |
| **Introduced in version**           | 3.9.0                                                                                    |
| **Is there a code fix**             | No                                                                                       |

## Cause

A method or class has an attribute that derives from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryBaseAttribute> but isn't a test method or test class.

## Rule description

<xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryBaseAttribute> supplies retry policy for test execution. It doesn't declare a test or turn a helper or lifecycle method into a test. MSTest applies the policy when it invokes a test method, not when it calls an arbitrary method.

Starting with MSTest 4.3, retry attributes can also apply to a class marked with `[TestClass]` or a derived attribute. A class-level retry policy applies to the class's tests; it doesn't retry a lifecycle callback as an independent test. Earlier versions support retry attributes only on test methods.

## How to fix violations

Add `[TestMethod]` to an intended test method or, in MSTest 4.3 and later, `[TestClass]` to an intended test class. If the target isn't intended to declare tests, remove the retry attribute instead.

## When to suppress warnings

Do not suppress a warning from this rule.
