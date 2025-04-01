---
title: "MSTEST0036: Do not use shadowing inside test class."
description: "Learn about code analysis rule MSTEST0036: Do not use shadowing inside test class."
ms.date: 08/19/2024
f1_keywords:
- MSTEST0036
- DoNotUseShadowingAnalyzer
helpviewer_keywords:
- DoNotUseShadowingAnalyzer
- MSTEST0036
author: engyebrahim
ms.author: enjieid
---
# MSTEST0036: Do not use shadowing inside test class

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0036                                                             |
| **Title**                           | Do not use shadowing inside test class.                                |
| **Category**                        | Design                                                                 |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Warning                                                                |
| **Introduced in version**           | 3.6.0                                                                  |
| **Is there a code fix**             | No                                                                     |

## Cause

Shadowing test members could cause testing issues (such as NRE).

## Rule description

Shadowing test members could cause testing issues (such as NRE).

## How to fix violations

Delete the shadowing member.

## When to suppress warnings

Don't suppress warnings from this rule as it could cause testing issues (such as NRE).

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0036
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0036
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0036.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
