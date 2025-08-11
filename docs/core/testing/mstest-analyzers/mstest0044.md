---
title: "MSTEST0044: Prefer TestMethod over DataTestMethod"
description: "Learn about code analysis rule MSTEST0044: Prefer TestMethod over DataTestMethod"
ms.date: 07/24/2025
f1_keywords:
- MSTEST0044
- PreferTestMethodOverDataTestMethodAnalyzer
helpviewer_keywords:
- PreferTestMethodOverDataTestMethodAnalyzer
- MSTEST0044
author: Evangelink
ms.author: amauryleve
---
# MSTEST0044: Prefer TestMethod over DataTestMethod

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0044                                                                               |
| **Title**                           | Prefer TestMethod over DataTestMethod                                                    |
| **Category**                        | Design                                                                                   |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning                                                                                  |
| **Introduced in version**           | 3.10.0                                                                                    |
| **Is there a code fix**             | Yes                                                                                       |

## Cause

A method or type uses <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataTestMethodAttribute> or inherits from it.

## Rule description

<xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataTestMethodAttribute> provides no additional value over <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> and will be removed in a future version. Use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> instead for all test methods, including those that use data source attributes like <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute>.

## How to fix violations

Use the provided code fixer to automatically replace <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataTestMethodAttribute> with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute>. You can also manually replace the attribute if needed. If you have a custom attribute that inherits from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataTestMethodAttribute>, change it to inherit from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> instead.

## When to suppress warnings

Don't suppress warnings from this rule. <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataTestMethodAttribute> will be removed in a future version, so you should migrate to <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute>.
