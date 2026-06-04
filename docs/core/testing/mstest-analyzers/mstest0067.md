---
title: "MSTEST0067: Avoid synchronously blocking calls in test code"
description: "Learn about code analysis rule MSTEST0067: Avoid synchronously blocking calls in test code"
ms.date: 06/04/2026
f1_keywords:
- MSTEST0067
- AvoidThreadSleepAndTaskWaitInTestsAnalyzer
helpviewer_keywords:
- AvoidThreadSleepAndTaskWaitInTestsAnalyzer
- MSTEST0067
author: Evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0067: Avoid synchronously blocking calls in test code

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0067                                                                               |
| **Title**                           | Avoid synchronously blocking calls in test code                                          |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | No                                                                                       |
| **Default severity**                | Info                                                                                     |
| **Introduced in version**           | 4.3.0                                                                                    |
| **Is there a code fix**             | No                                                                                       |

> [!NOTE]
> This rule is available starting with MSTest 4.3. It's disabled by default. It's enabled as a warning when `<MSTestAnalysisMode>All</MSTestAnalysisMode>` is set.

## Cause

Test code uses a synchronously blocking call such as <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Task.WaitAll%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Task.WaitAny%2A?displayProperty=nameWithType>, or <xref:System.Threading.Tasks.Task%601.Result?displayProperty=nameWithType>.

The rule fires on methods marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> (including custom attributes that inherit from it) and on fixture methods marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyCleanupAttribute>, `GlobalTestInitializeAttribute`, and `GlobalTestCleanupAttribute`.

## Rule description

Synchronously blocking the current thread inside test methods or test fixtures is a common source of flakiness and can also deadlock when the test framework runs tests on a synchronization context that requires cooperative scheduling. Prefer `await Task.Delay` for time-based waits and `await` the task to observe its result.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public async Task Test()
    {
        Thread.Sleep(1000); // Violation
        var result = ComputeAsync().Result; // Violation
        ComputeAsync().Wait(); // Violation
    }

    private static Task<int> ComputeAsync() => Task.FromResult(42);
}
```

## How to fix violations

Use the asynchronous equivalent:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public async Task Test()
    {
        await Task.Delay(1000);
        var result = await ComputeAsync();
    }

    private static Task<int> ComputeAsync() => Task.FromResult(42);
}
```

## When to suppress warnings

This rule is disabled by default. When opted-in, suppress individual occurrences when the synchronous wait is intentional and not avoidable — for example, when interacting with a synchronous API that cannot be made asynchronous.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0067
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0067
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0067.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
