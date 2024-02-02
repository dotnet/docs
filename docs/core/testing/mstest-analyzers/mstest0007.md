---
title: "MSTEST0007: [<TestAttribute>] can only be set on methods marked with [TestMethod]"
description: "Learn about code analysis rule MSTEST0007: Ensure test attributes can only be set on methods marked with TestMethod attribute"
ms.date: 02/01/2024
f1_keywords:
- MSTEST0007
- UseAttributeOnTestMethodAnalyzer
helpviewer_keywords:
- UseAttributeOnTestMethodAnalyzer
- MSTEST0007
author: cvpoienaru
ms.author: codrinpoienaru
dev_langs:
- CSharp
- VB
---
# MSTEST0007: Ensure test attributes can only be set on methods marked with TestMethod attribute

| Property                            | Value                                                                              |
|-------------------------------------|------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0007                                                                         |
| **Title**                           | Ensure test attributes can only be set on methods marked with TestMethod attribute |
| **Category**                        | Usage                                                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                                                       |
| **Enabled by default**              | Yes                                                                                |
| **Default severity**                | Info                                                                               |
| **Introduced in version**           | 3.3.0                                                                              |

## Cause

A method not marked with `[TestMethod]` attribute has one or more test attributes applied to it.

## Rule description

Test attributes:
- `[CssIteration]`
- `[CssProjectStructure]` 
- `[Description]`
- `[ExpectedException]`
- `[Owner]`
- `[Priority]`
- `[TestProperty]`
- `[WorkItem]`

should only be applied on methods marked with `[TestMethod]` attribute.

## How to fix violations

To fix a violation of this rule, either convert the method on which you applied one or more test attributes to a test method by setting the `[TestMethod]` attribute, or remove the test attribute(s) altogether.

## When to suppress warnings

Do not suppress a warning from this rule. Ignoring this rule will result in your attributes being ignored since they were designed only for use in a test context.
