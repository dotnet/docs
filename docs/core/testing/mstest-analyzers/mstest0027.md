---
title: "MSTEST0027: Use Async suffix for async methods suppressor."
description: "Learn about code suppressor MSTEST0027: Use Async suffix for async methods suppressor."
ms.date: 08/09/2024
f1_keywords:
- MSTEST0027
- UseAsyncSuffixTestMethodSuppressor
helpviewer_keywords:
- VSTHRD200
- UseAsyncSuffixTestMethodSuppressor
author: Evangelink
ms.author: amauryleve
---
# MSTEST0027: Non-nullable reference not initialized suppressor

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0027                               |
| **Title**                           | Suppress VSTHRD200 for test methods      |
| **Category**                        | Suppressor                               |
| **Introduced in version**           | 3.5.0                                    |

## Suppressor description

Suppress the [VSTHRD200: Use Async suffix for async methods](https://github.com/microsoft/vs-threading/blob/main/doc/analyzers/VSTHRD200.md) diagnostic for all test methods as they are not required to follow the naming convention.

## When to disable suppressor

.NET suppressors cannot be disabled.
