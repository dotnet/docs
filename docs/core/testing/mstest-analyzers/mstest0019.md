---
title: "MSTEST0019: Prefer TestInitialize methods over constructors"
description: "Learn about code analysis rule MSTEST0019: Prefer TestInitialize methods over constructors"
ms.date: 03/19/2024
f1_keywords:
- MSTEST0019
- PreferTestInitializeOverConstructorAnalyzer
helpviewer_keywords:
- PreferTestInitializeOverConstructorAnalyzer
- MSTEST0019
author: Evangelink
ms.author: amauryleve
---
# MSTEST0019: Prefer TestInitialize methods over constructors

| Property                            | Value                                           |
|-------------------------------------|-------------------------------------------------|
| **Rule ID**                         | MSTEST0019                                      |
| **Title**                           | Prefer TestInitialize methods over constructors |
| **Category**                        | Design                                          |
| **Fix is breaking or non-breaking** | Non-breaking                                    |
| **Enabled by default**              | No                                              |
| **Default severity**                | Info                                            |
| **Introduced in version**           | 3.4.0                                           |
| **Is there a code fix**             | Yes                                             |

## Cause

This rule raises a diagnostic when there is a parameterless explicit constructor declared on a test class (class marked with `[TestClass]`).

## Rule description

Use this rule to enforce using `[TestInitialize]` for both synchronous and asynchronous test initialization. Asynchronous (async/await) test initialization requires the use of `[TestInitialize]` methods, because the resulting `Task` needs to be awaited.

## How to fix violations

Replace the constructor call with a `[TestInitialize]` method.

## When to suppress warnings

You usually don't want to suppress warnings from this rule if you decided to opt-in for it.

[!INCLUDE [disabled-in-all](includes/disabled-in-all.md)]

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0019
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0019
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0019.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
