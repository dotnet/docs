---
title: "MSTEST0027: Use Async suffix for async methods suppressor"
description: "Learn about code suppressor MSTEST0027: Use Async suffix for async methods suppressor."
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0027
- UseAsyncSuffixTestMethodSuppressor
helpviewer_keywords:
- VSTHRD200
- UseAsyncSuffixTestMethodSuppressor
author: Evangelink
ms.author: amauryleve
---
# MSTEST0027: Use Async suffix for async methods suppressor

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0027                               |
| **Title**                           | Suppress VSTHRD200 for test methods      |
| **Category**                        | Suppressor                               |
| **Introduced in version**           | 3.5.0                                    |

## Suppressor description

Suppress the [VSTHRD200: Use Async suffix for async methods](https://github.com/microsoft/vs-threading/blob/main/doc/analyzers/VSTHRD200.md) diagnostic for test methods.

The `Async` suffix helps callers recognize APIs that they need to await. MSTest invokes test methods through the test runner, which recognizes their return types and awaits them without relying on their names. Test names can therefore describe the behavior under test without adding an `Async` suffix solely to satisfy a call-site naming convention.

## When to disable suppressor

.NET suppressors cannot be disabled.
