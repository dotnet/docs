---
title: "MSTEST0015: Test method should not be ignored"
description: "Learn about code analysis rule MSTEST0015: Test method should not be ignored"
ms.date: 03/01/2024
f1_keywords:
- MSTEST0015
- TestMethodShouldNotBeIgnored
helpviewer_keywords:
- TestMethodShouldNotBeIgnored
- MSTEST0015
author: engyebrahim
ms.author: enjieid
---
# MSTEST0015: Test method should not be ignored

| Property                            | Value                                        |
|-------------------------------------|----------------------------------------------|
| **Rule ID**                         | MSTEST0015                                   |
| **Title**                           | Test method should not be ignored            |
| **Category**                        | Design                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                 |
| **Enabled by default**              | Yes (from 3.3 to 3.7). No (starting with 3.8)|
| **Default severity**                | Info                                         |
| **Introduced in version**           | 3.3.0                                        |
| **Is there a code fix**             | No                                           |

## Cause

A Test method should not be ignored.

## Rule description

Test methods should not be ignored (marked with `[Ignore]`).

## How to fix violations

Ensure that the test method isn't ignored.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, test method will be ignored.

[!INCLUDE [disabled-in-all](includes/disabled-in-all.md)]

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0015
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0015
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0015.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
