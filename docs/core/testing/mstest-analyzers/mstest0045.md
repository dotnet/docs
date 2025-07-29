---
title: "MSTEST0045: Use cooperative cancellation for timeout"
description: "Learn about code analysis rule MSTEST0045: Use cooperative cancellation for timeout"
ms.date: 07/24/2025
f1_keywords:
- MSTEST0045
- UseCooperativeCancellationForTimeoutAnalyzer
helpviewer_keywords:
- UseCooperativeCancellationForTimeoutAnalyzer
- MSTEST0045
author: Evangelink
ms.author: amauryleve
---
# MSTEST0045: Use cooperative cancellation for timeout

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0045                                                                               |
| **Title**                           | Use cooperative cancellation for timeout                                                 |
| **Category**                        | Design                                                                                   |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Info                                                                                     |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | Yes                                                                                       |

## Cause

A test method uses <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute> without setting the `CooperativeCancellation` property to `true`.

## Rule description

There is no way to gracefully abort a running thread. So, for a timeout to work, there are two ways:

1. Stop observing the thread running the test. But this can be problematic in many cases and might make the remaining tests unstable due to potential race conditions. This is non-cooperative cancellation.
2. A cancellation is requested once the timeout is reached, and it's the test responsibility to terminate on request. This is cooperative cancellation.

When using <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute>, you should set `CooperativeCancellation` to `true` to enable cooperative cancellation. Without cooperative cancellation, the test framework stops observing the test execution when the timeout is reached, but the test continues running in the background. This can lead to problems for other tests or cleanup steps, as the original test is still executing and might interfere with subsequent operations.

When using cooperative cancellation mode, MSTest only triggers cancellation of the token and you're responsible for flowing and utilizing the test context token in your test code. This mode aligns with the default behavior of cancellation in .NET.

## How to fix violations

Use the provided code fixer to automatically set the `CooperativeCancellation` property to `true` on the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute>. You can also manually add the property if needed.

```csharp
[TestClass]
public class TestClass1
{
    public TestContext TestContext { get; set; }

    [Timeout(TimeoutValue, CooperativeCancellation = true)]
    [TestMethod]
    public void TestMethod1()
    {
        // Respect TestContext.CancellationTokenSource.Token
    }
}
```

Alternatively, you can configure cooperative cancellation globally in your [runsettings](/dotnet/core/testing/unit-testing-mstest-configure#mstest-element) or [testconfig.json](/dotnet/core/testing/unit-testing-mstest-configure#timeout-settings) file to apply this setting to all timeout attributes in your test project.

## When to suppress warnings

Suppress this warning if you specifically need the test to be terminated abruptly when the timeout is reached, rather than using cooperative cancellation.
