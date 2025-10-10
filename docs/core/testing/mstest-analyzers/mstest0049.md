---
title: "MSTEST0049: Flow TestContext cancellation token"
description: "Learn about code analysis rule MSTEST0049: Flow TestContext cancellation token"
ms.date: 07/24/2025
f1_keywords:
- MSTEST0049
- FlowTestContextCancellationTokenAnalyzer
helpviewer_keywords:
- FlowTestContextCancellationTokenAnalyzer
- MSTEST0049
author: Evangelink
ms.author: amauryleve
---
# MSTEST0049: Flow TestContext cancellation token

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0049                                                                               |
| **Title**                           | Flow TestContext cancellation token                                                     |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Info                                                                                     |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | Yes                                                                                      |

## Cause

A method call within a test context doesn't use the <xref:System.Threading.CancellationToken> available from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> when the called method has a parameter or overload that accepts a <xref:System.Threading.CancellationToken>.

## Rule description

When <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> is available in your test methods, you should flow its <xref:System.Threading.CancellationToken> to async operations. This enables cooperative cancellation when timeouts occur and ensures proper resource cleanup. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> cancellation token is especially important when using cooperative cancellation with timeout attributes.

This rule triggers when:

- A method call has an optional <xref:System.Threading.CancellationToken> parameter that isn't explicitly provided.
- A method call has an overload that accepts a <xref:System.Threading.CancellationToken> but the non-cancellable overload is used instead.

## How to fix violations

Use the provided code fixer to automatically pass the <xref:System.Threading.CancellationToken> from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> to method calls that support cancellation. You can also manually update method calls to include `TestContext.CancellationToken` as a parameter.

## When to suppress warnings

Suppress this warning if you intentionally don't want to support cancellation for specific operations, or if the operation should continue even when the test is cancelled.
