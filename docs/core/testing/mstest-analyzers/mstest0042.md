---
title: "MSTEST0042: Avoid duplicated 'DataRow' entries"
description: "Learn about code analysis rule MSTEST0042: Avoid duplicated 'DataRow' entries"
ms.date: 04/11/2025
f1_keywords:
- MSTEST0042
- DuplicateDataRowAnalyzer
helpviewer_keywords:
- DuplicateDataRowAnalyzer
- MSTEST0042
author: Youssef1313
ms.author: ygerges
---
# MSTEST0042: Avoid duplicated 'DataRow' entries

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0042                                                             |
| **Title**                           | Avoid duplicated 'DataRow' entries                                     |
| **Category**                        | Usage                                                                  |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Warning                                                                |
| **Introduced in version**           | 3.9.0                                                                  |
| **Is there a code fix**             | No                                                                     |

## Cause

A test method has two or more [DataRow](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute) attributes that are equivalent.

## Rule description

<xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute> is used to denote inputs to test methods. It's not expected that a test will intentionally run twice with the exact same data. Duplicated `DataRow`s are often a copy/paste error.

## How to fix violations

Either remove the duplicate `DataRow` attribute, or fix it to make unique.

## When to suppress warnings

Do not suppress a warning from this rule, unless you intended to use the same input more than once.
