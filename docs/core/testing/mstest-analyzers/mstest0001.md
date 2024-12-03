---
title: "MSTEST0001: Explicitly enable or disable tests parallelization"
description: "Learn about code analysis rule MSTEST0001: Explicitly enable or disable tests parallelization"
ms.date: 12/20/2023
f1_keywords:
- MSTEST0001
- UseParallelizeAttributeAnalyzer
helpviewer_keywords:
- UseParallelizeAttributeAnalyzer
- MSTEST0001
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0001: Explicitly enable or disable tests parallelization

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0001                                         |
| **Title**                           | Explicitly enable or disable tests parallelization |
| **Category**                        | Performance                                        |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 3.2.0                                              |
| **Is there a code fix**             | No                                                 |

## Cause

The assembly is not marked with `[assembly: Parallelize]` or `[assembly: DoNotParallelize]` attribute.

## Rule description

By default, MSTest runs tests within the same assembly sequentially, which can lead to severe performance limitations. It is recommended to enable assembly attribute [`[assembly: Parallelize]`](/dotnet/api/microsoft.visualstudio.testtools.unittesting.parallelizeattribute) to run tests in parallel, or if the assembly is known to not be parallelizable, to use explicitly the assembly level attribute [`[assembly: DoNotParallelize]`](/dotnet/api/microsoft.visualstudio.testtools.unittesting.donotparallelizeattribute).

The default configuration of `[assembly: Parallelize]` is equivalent to `[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]`, meaning that the parallelization will be set at class level (not method level) and will use as many threads as possible (depending on internal implementation).

## How to fix violations

To fix a violation of this rule, add `[assembly: Parallelize]` or `[assembly: DoNotParallelize]` attribute. We recommend to use `[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]` to have best parallelization.

## When to suppress warnings

Do not suppress a warning from this rule. Many libraries can benefit from a massive performance boost when enabling parallelization. When the test application is designed in a way that prevents parallelization, having the attribute explicitly set helps new developers to understand the limitations of the library.
