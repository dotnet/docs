---
title: "MSTEST0041: Use 'ConditionBaseAttribute' on test classes"
description: "Learn about code analysis rule MSTEST0041: Use 'ConditionBaseAttribute' on test classes"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0041
- UseConditionBaseWithTestClassAnalyzer
helpviewer_keywords:
- UseConditionBaseWithTestClassAnalyzer
- MSTEST0041
author: Youssef1313
ms.author: ygerges
ai-usage: ai-assisted
---
# MSTEST0041: Use 'ConditionBaseAttribute' on test classes

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0041                                                             |
| **Title**                           | Use 'ConditionBaseAttribute' on test classes                           |
| **Category**                        | Usage                                                                  |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Warning                                                                |
| **Introduced in version**           | 3.8.0                                                                  |
| **Is there a code fix**             | Yes, starting with MSTest 4.4                                          |

## Cause

The use of an attribute that inherits from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute> on a class that is not marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute>.

## Rule description

An attribute that derives from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute> only has an effect when applied to a class that's marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute>.

## How to fix violations

Depending on the intent, either add the missing <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> or remove the attribute that derives from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute>.

Starting with MSTest 4.4, the code fix adds `[TestClass]` to the affected type.

## When to suppress warnings

Do not suppress a warning from this rule.
