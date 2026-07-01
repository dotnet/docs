---
title: "MSTEST0047: Unused TestContext parameter suppressor"
description: "Learn about code suppressor MSTEST0047: Unused TestContext parameter suppressor."
ms.date: 06/04/2026
f1_keywords:
- MSTEST0047
- UnusedParameterSuppressor
helpviewer_keywords:
- IDE0060
- UnusedParameterSuppressor
- MSTEST0047
author: Evangelink
ms.author: amauryleve
ai-usage: ai-assisted
---
# MSTEST0047: Unused `TestContext` parameter suppressor

| Property                            | Value                                                                          |
|-------------------------------------|--------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0047                                                                     |
| **Title**                           | Suppress IDE0060 for `TestContext` parameter on initialize and cleanup methods |
| **Category**                        | Suppressor                                                                     |
| **Introduced in version**           | 4.2.0                                                                          |

## Suppressor description

Suppress the [IDE0060: Remove unused parameter](../../../fundamentals/code-analysis/style-rules/ide0060.md) diagnostic for the `TestContext` parameter on the following MSTest fixture methods:

- A method marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute>.
- A method marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute>.
- A method marked with `GlobalTestInitializeAttribute` (available starting with MSTest 4.3).
- A method marked with `GlobalTestCleanupAttribute` (available starting with MSTest 4.3).

These signatures are required by the test framework even when the `TestContext` parameter isn't used in the method body, so IDE0060 isn't actionable on them.

## When to disable suppressor

.NET suppressors cannot be disabled.
