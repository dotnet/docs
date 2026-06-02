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

### Example: TestContext property

The following code triggers MSTEST0049 because `Task.Delay` and `HttpClient.GetAsync` accept a <xref:System.Threading.CancellationToken> but none is passed:

```csharp
[TestClass]
public class MyTestClass
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    public async Task TestMethod()
    {
        using var client = new HttpClient();
        // MSTEST0049: these calls accept a CancellationToken but none is passed
        await Task.Delay(1000);
        var response = await client.GetAsync("https://example.com");
    }
}
```

The fix is to pass `TestContext.CancellationToken` to each call:

:::code language="csharp" source="../snippets/testcontext/csharp-cancellation/CancellationToken.cs":::

### Example: constructor injection (MSTest 3.6+)

With constructor injection, use the `_testContext` field to access the cancellation token:

:::code language="csharp" source="../snippets/testcontext/csharp-cancellation/CancellationTokenCtor.cs":::

## When to suppress warnings

Suppress this warning if you intentionally don't want to support cancellation for specific operations, or if the operation should continue even when the test is cancelled.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0049
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0049
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0049.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
