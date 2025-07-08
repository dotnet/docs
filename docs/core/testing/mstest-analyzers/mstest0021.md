---
title: "MSTEST0021: Prefer Dispose over TestCleanup methods"
description: "Learn about code analysis rule MSTEST0021: Prefer Dispose over TestCleanup methods"
ms.date: 03/19/2024
f1_keywords:
- MSTEST0021
- PreferDisposeOverTestCleanupAnalyzer
helpviewer_keywords:
- PreferDisposeOverTestCleanupAnalyzer
- MSTEST0021
author: Evangelink
ms.author: amauryleve
---
# MSTEST0021: Prefer Dispose over TestCleanup methods

| Property                            | Value                                   |
|-------------------------------------|-----------------------------------------|
| **Rule ID**                         | MSTEST0021                              |
| **Title**                           | Prefer Dispose over TestCleanup methods |
| **Category**                        | Design                                  |
| **Fix is breaking or non-breaking** | Non-breaking                            |
| **Enabled by default**              | No                                      |
| **Default severity**                | Info                                    |
| **Introduced in version**           | 3.4.0                                   |
| **Is there a code fix**             | Yes, starting with 3.7.0                |

## Cause

This rule raises a diagnostic when there is a void `[TestCleanup]` method or on any `[TestCleanup]` if the targeted framework supports `IAsyncDisposable` interface.

## Rule description

Using `Dispose` or `DisposeAsync` is a more common pattern and some developers prefer to always use this pattern even for tests.

## How to fix violations

Replace `[TestCleanup]` method by `Dispose` or `DisposeAsync` pattern.

## When to suppress warnings

You usually don't want to suppress warnings from this rule if you decided to opt-in for it.

[!INCLUDE [disabled-in-all](includes/disabled-in-all.md)]

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0021
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0021
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0021.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
