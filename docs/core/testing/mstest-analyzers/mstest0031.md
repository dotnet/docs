---
title: "MSTEST0031: `System.ComponentModel.DescriptionAttribute` has no effect on test methods."
description: "Learn about code analysis rule MSTEST0031: `System.ComponentModel.DescriptionAttribute` has no effect in the context of tests, so likely user wanted to use `Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute` instead."
ms.date: 07/03/2024
f1_keywords:
- MSTEST0031
- DoNotUseSystemDescriptionAttribute
helpviewer_keywords:
- DoNotUseSystemDescriptionAttribute
- MSTEST0031
author: engyebrahim
ms.author: enjieid
---
# MSTEST0031: `System.ComponentModel.DescriptionAttribute` has no effect on test methods.

| Property                            | Value                                                                       |
|-------------------------------------|-----------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0031                                                                  |
| **Title**                           | `System.ComponentModel.DescriptionAttribute` has no effect on test methods. |
| **Category**                        | Usage                                                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                                                |
| **Enabled by default**              | Yes                                                                         |
| **Default severity**                | Info                                                                        |
| **Introduced in version**           | 3.5.0                                                                       |

## Cause

'System.ComponentModel.DescriptionAttribute' has no effect in the context of tests.

## Rule description

'System.ComponentModel.DescriptionAttribute' has no effect in the context of tests, so likely user wanted to use 'Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute' instead.

## How to fix violations

Remove or replace `System.ComponentModel.DescriptionAttribute` by `Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute` instead.

## When to suppress warnings

We don't recommend to suppress the diagnostic as the `System.ComponentModel.DescriptionAttribute` has no effect in the context of tests.
