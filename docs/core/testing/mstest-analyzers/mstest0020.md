---
title: "MSTEST0020: Prefer constructors over TestInitialize methods"
description: "Learn about code analysis rule MSTEST0020: Prefer constructors over TestInitialize methods"
ms.date: 03/19/2024
f1_keywords:
- MSTEST0020
- PreferConstructorOverTestInitializeAnalyzer
helpviewer_keywords:
- PreferConstructorOverTestInitializeAnalyzer
- MSTEST0020
author: Evangelink
ms.author: amauryleve
---
# MSTEST0020: Prefer constructors over TestInitialize methods

| Property                            | Value                                           |
|-------------------------------------|-------------------------------------------------|
| **Rule ID**                         | MSTEST0020                                      |
| **Title**                           | Prefer constructors over TestInitialize methods |
| **Category**                        | Design                                          |
| **Fix is breaking or non-breaking** | Non-breaking                                    |
| **Enabled by default**              | No                                              |
| **Default severity**                | Info                                            |
| **Introduced in version**           | 3.4.0                                           |
| **Is there a code fix**             | Yes                                             |

## Cause

This rule raises a diagnostic when there is a void `[TestInitialize]` method.

## Rule description

It is usually better to rely on constructors for non-async initialization as you can then rely on `readonly` and get better compiler feedback when developing your tests. This is especially true when dealing with nullable enabled contexts.

## How to fix violations

Replace `[TestInitialize]` returning `void` by constructors.

## When to suppress warnings

You usually don't want to suppress warnings from this rule if you decided to opt-in for it.

[!INCLUDE [disabled-in-all](includes/disabled-in-all.md)]

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0020
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0020
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0020.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
