---
title: "MSTEST0054: Use TestContext.CancellationToken instead of TestContext.CancellationTokenSource.Token"
description: "Learn about code analysis rule MSTEST0054: Use TestContext.CancellationToken instead of TestContext.CancellationTokenSource.Token"
ms.date: 10/01/2025
f1_keywords:
- MSTEST0054
- UseCancellationTokenPropertyAnalyzer
helpviewer_keywords:
- UseCancellationTokenPropertyAnalyzer
- MSTEST0054
author: Youssef1313
ms.author: ygerges
ai-usage: ai-generated
---
# MSTEST0054: Use cancellation token from TestContext.CancellationToken

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0054                                                                               |
| **Title**                           | Use TestContext.CancellationToken instead of TestContext.CancellationTokenSource.Token   |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Info                                                                                     |
| **Introduced in version**           | 3.11.0                                                                                   |
| **Is there a code fix**             | Yes                                                                                      |

## Cause

Accessing `CancellationToken` via `TestContext.CancellationTokenSource.Token` instead of using the `TestContext.CancellationToken` property.

## Rule description

MSTest provides a cancellation token through the `TestContext.CancellationToken` property. Accessing `TestContext.CancellationTokenSource` is not recommended, and it might be removed in a future release. It's also simpler to use `TestContext.CancellationToken` compared to `TestContext.CancellationTokenSource.Token`.

## How to fix violations

Use the `TestContext.CancellationToken` property instead of `TestContext.CancellationTokenSource.Token`.

For example, change this:

```csharp
public TestContext TestContext { get; set; }

[TestMethod]
public async Task TestMethod()
{
    await Task.Delay(1000, TestContext.CancellationTokenSource.Token);
}
```

To this:

```csharp
public TestContext TestContext { get; set; }

[TestMethod]
public async Task TestMethod()
{
    await Task.Delay(1000, TestContext.CancellationToken);
}
```

## When to suppress warnings

Don't suppress warnings from this rule. The use of `CancellationTokenSource` property is not recommended and might be removed in a future release.
