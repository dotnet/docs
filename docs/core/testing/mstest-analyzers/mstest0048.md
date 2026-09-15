---
title: "MSTEST0048: Avoid TestContext properties in fixture methods"
description: "Learn about code analysis rule MSTEST0048: Avoid TestContext properties in fixture methods"
ms.date: 09/02/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0048
- TestContextPropertyUsageAnalyzer
helpviewer_keywords:
- TestContextPropertyUsageAnalyzer
- MSTEST0048
author: Evangelink
ms.author: amauryleve
---
# MSTEST0048: Avoid TestContext properties in fixture methods

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0048                                                                               |
| **Title**                           | Avoid TestContext properties in fixture methods                                          |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning                                                                                  |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | No                                                                                       |

## Cause

A fixture method (methods with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyCleanupAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute>, or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute>) accesses restricted <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> properties.

Starting with MSTest.Analyzers 4.4 preview, the rule also reports constant indexer access to a restricted key, such as `testContext.Properties["TestName"]`. It doesn't report indexer access when the key isn't a constant string.

## Rule description

Certain <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> properties aren't available in fixture methods because they're specific to individual test execution:

Properties unavailable in class and assembly fixture methods:

- `TestData`
- `TestDisplayName`
- `DataRow`
- `DataConnection`
- `TestName`

Properties unavailable in assembly-level fixture methods:

- `FullyQualifiedTestClassName`

## How to fix violations

Remove the usage of restricted <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> properties from fixture methods. Consider using alternative approaches for class/assembly initialization and cleanup that don't rely on test-specific context information.

## When to suppress warnings

Don't suppress warnings from this rule. Accessing these properties in fixture methods can result in unexpected behavior or runtime errors.
