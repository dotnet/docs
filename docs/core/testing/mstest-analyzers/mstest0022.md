---
title: "MSTEST0022: Prefer TestCleanup over Dispose methods"
description: "Learn about code analysis rule MSTEST0022: Prefer TestCleanup over Dispose methods"
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0022
- PreferTestCleanupOverDisposeAnalyzer
helpviewer_keywords:
- PreferTestCleanupOverDisposeAnalyzer
- MSTEST0022
author: Evangelink
ms.author: amauryleve
---
# MSTEST0022: Prefer TestCleanup over Dispose methods

| Property                            | Value                                   |
|-------------------------------------|-----------------------------------------|
| **Rule ID**                         | MSTEST0022                              |
| **Title**                           | Prefer TestCleanup over Dispose methods |
| **Category**                        | Design                                  |
| **Fix is breaking or non-breaking** | Non-breaking                            |
| **Enabled by default**              | No                                      |
| **Default severity**                | Info                                    |
| **Introduced in version**           | 3.4.0                                   |
| **Is there a code fix**             | Yes                                     |

## Cause

This rule raises a diagnostic when a `Dispose` or `DisposeAsync` method is detected.

## Rule description

To identify cleanup explicitly as an MSTest lifecycle callback, use `[TestCleanup]`. A `Task`-returning callback also supports asynchronous cleanup on target frameworks that don't provide `IAsyncDisposable`.

`Dispose` and `DisposeAsync` are also supported. This rule expresses an opt-in convention, not a requirement for correct test execution. [MSTEST0021](mstest0021.md) offers the opposite convention; choose the cleanup policy that fits your project rather than enabling both.

## How to fix violations

Replace `Dispose` or `DisposeAsync` methods with `[TestCleanup]`.

## When to suppress warnings

You usually don't want to suppress warnings from this rule if you decided to opt-in for it.

[!INCLUDE [disabled-in-all](includes/disabled-in-all.md)]

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0022
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0022
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0022.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
