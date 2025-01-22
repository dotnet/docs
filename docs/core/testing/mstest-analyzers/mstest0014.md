---
title: "MSTEST0014: DataRow should be valid"
description: "Learn about code analysis rule MSTEST0014: DataRow should be valid"
ms.date: 03/11/2024
f1_keywords:
- MSTEST0014
- DataRowShouldBeValidAnalyzer
helpviewer_keywords:
- DataRowShouldBeValidAnalyzer
- MSTEST0014
author: evangelink
ms.author: amauryleve
---
# MSTEST0014: DataRow should be valid

| Property                            | Value                                           |
|-------------------------------------|-------------------------------------------------|
| **Rule ID**                         | MSTEST0014                                      |
| **Title**                           | DataRow should be valid                         |
| **Category**                        | Usage                                           |
| **Fix is breaking or non-breaking** | Non-breaking                                    |
| **Enabled by default**              | Yes                                             |
| **Default severity**                | Warning                                         |
| **Introduced in version**           | 3.3.0                                           |
| **Is there a code fix**             | No                                              |

## Cause

An instance of `[DataRow]` is not following one or multiple points of the required `DataRow` layout.

## Rule description

`[DataRow]` instances should have the following layout to be valid:

- they should only be set on a test method
- argument count should match method parameters count
- argument type should match method argument type

## How to fix violations

Ensure that the `DataRow` instance matches the required layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0014
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0014
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0014.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
