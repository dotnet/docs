---
title: "MSTEST0047: Unused TestContext parameter suppressor."
description: "Learn about code suppressor MSTEST0047: Unused TestContext parameter suppressor."
ms.date: 06/16/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0047
- UnusedParameterSuppressor
helpviewer_keywords:
- UnusedParameterSuppressor
- MSTEST0047
author: Evangelink
ms.author: amauryleve
---
# MSTEST0047: Unused TestContext parameter suppressor

| Property                            | Value                                                     |
|-------------------------------------|-----------------------------------------------------------|
| **Rule ID**                         | MSTEST0047                                                |
| **Title**                           | Suppress IDE0060 for the TestContext parameter            |
| **Category**                        | Suppressor                                                |
| **Introduced in version**           | 3.10.0                                                    |

## Suppressor description

Suppress the [IDE0060: Remove unused parameter](../../../fundamentals/code-analysis/style-rules/ide0060.md) diagnostic for the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> parameter of fixture methods.

MSTest lets you receive the `TestContext` as a parameter of fixture methods that are marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.GlobalTestInitializeAttribute>, or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.GlobalTestCleanupAttribute>. Because the parameter is required by MSTest even when your method body doesn't use it, IDE0060 would otherwise incorrectly flag it as unused.

## When to disable suppressor

.NET suppressors cannot be disabled.
