---
title: "`[DeploymentItem]` can be specified only on test class or test method."
description: "Learn about code analysis rule MSTEST0035: `[DeploymentItem]` can be specified only on test class or test method."
ms.date: 08/02/2024
f1_keywords:
- MSTEST0035
- UseDeploymentItemWithTestMethodOrTestClassTitle
helpviewer_keywords:
- UseDeploymentItemWithTestMethodOrTestClassTitle
- MSTEST0035
author: engyebrahim
ms.author: enjieid
---
# MSTEST0035: `[DeploymentItem]` can be specified only on test class or test method.

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0035                                                             |
| **Title**                           | `[DeploymentItem]` can be specified only on test class or test method. |
| **Category**                        | Usage                                                                  |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Info                                                                   |
| **Introduced in version**           | 3.6.0                                                                  |

## Cause

This rule raises a diagnostic when `[DeploymentItem]` isn't set on test class or test method.

## Rule description

With using  `[DeploymentItem]`, without putting it on test class or test method itwill be ignored.

## How to fix violations

Ensure the attribute `[DeploymentItem]` is specified on a test class or a test method, otherwise remove the attribute.

## When to suppress warnings

It's _not_ recommended to suppress warnings from this rule as the `[DeploymentItem]` will be ignored.
