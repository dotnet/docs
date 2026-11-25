---
title: "MSTEST0028: Use Async suffix for async methods suppressor"
description: "Learn about code suppressor MSTEST0028: Use Async suffix for async methods suppressor."
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0028
- UseAsyncSuffixTestFixtureMethodSuppressor
helpviewer_keywords:
- VSTHRD200
- UseAsyncSuffixTestFixtureMethodSuppressor
author: Evangelink
ms.author: amauryleve
---
# MSTEST0028: Use Async suffix for async methods suppressor

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0028                               |
| **Title**                           | Suppress VSTHRD200 for test fixture methods |
| **Category**                        | Suppressor                               |
| **Introduced in version**           | 3.5.0                                    |

## Suppressor description

Suppress the [VSTHRD200: Use Async suffix for async methods](https://github.com/microsoft/vs-threading/blob/main/doc/analyzers/VSTHRD200.md) diagnostic for test fixture methods.

Fixture attributes identify the lifecycle phase, and the method's return type tells MSTest whether to await the callback. Ordinary callers don't select these callbacks by name. An `Async` suffix doesn't help the runner decide when or how to invoke them, so the suppressor lets fixture names follow your project's lifecycle naming convention.

## When to disable suppressor

.NET suppressors cannot be disabled.
