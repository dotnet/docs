---
title: "MSTEST0054: Use cancellation token from TestContext.CancellationToken"
description: "Learn about code analysis rule MSTEST0054: Use cancellation token from TestContext.CancellationToken"
ms.date: 01/29/2025
f1_keywords:
- MSTEST0054
- UseCancellationTokenPropertyAnalyzer
helpviewer_keywords:
- UseCancellationTokenPropertyAnalyzer
- MSTEST0054
author: Evangelink
ms.author: amauryleve
ai-usage: ai-generated
---
# MSTEST0054: Use cancellation token from TestContext.CancellationToken

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0054                                                                               |
| **Title**                           | Use cancellation token from TestContext.CancellationToken                                |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Info                                                                                     |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | No                                                                                       |

## Cause

A test method creates a new <xref:System.Threading.CancellationToken> or <xref:System.Threading.CancellationTokenSource> instead of using the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.CancellationToken?displayProperty=nameWithType> property.

## Rule description

MSTest provides a cancellation token through the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.CancellationToken?displayProperty=nameWithType> property that is tied to the test execution lifetime and respects timeouts. Creating a separate cancellation token in the test defeats this integration and can lead to tests that don't respect configured timeouts or cancellation requests.

Starting with MSTest 3.4, when a test timeout expires and `TimeoutAttribute.CooperativeCancellation` is `true`, the framework signals cancellation through `TestContext.CancellationToken`. Using this property ensures your async tests can be cancelled cooperatively.

## How to fix violations

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.CancellationToken?displayProperty=nameWithType> property instead of creating a new cancellation token or source.

For example, change this:

```csharp
public TestContext TestContext { get; set; }

[TestMethod]
[Timeout(5000, CooperativeCancellation = true)]
public async Task TestMethod()
{
    var cts = new CancellationTokenSource();
    await SomeAsyncOperation(cts.Token);
}
```

To this:

```csharp
public TestContext TestContext { get; set; }

[TestMethod]
[Timeout(5000, CooperativeCancellation = true)]
public async Task TestMethod()
{
    await SomeAsyncOperation(TestContext.CancellationToken);
}
```

## When to suppress warnings

You might suppress warnings from this rule if you have a specific need for a separate cancellation token that is independent of the test execution lifetime. However, in most cases, using the provided `TestContext.CancellationToken` is the better approach.
