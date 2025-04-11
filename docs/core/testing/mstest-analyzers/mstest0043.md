---
title: "MSTEST0043: Use retry attribute on test method"
description: "Learn about code analysis rule MSTEST0043: Use retry attribute on test method"
ms.date: 04/11/2025
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

A method has an attribute that derives from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryBaseAttribute> and does not have an attribute that derives from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute>.

## Rule description

<xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryBaseAttribute> only applies to test methods.

## How to fix violations

Add <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> to the method, or remove the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryBaseAttribute>.

## When to suppress warnings

Do not suppress a warning from this rule.
