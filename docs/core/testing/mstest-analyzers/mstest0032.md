---
title: "MSTEST0032: Review or remove the assertion as its condition is known to be always true."
description: "Learn about code analysis rule MSTEST0032: Review or remove the assertion as its condition is known to be always true."
ms.date: 07/11/2024
f1_keywords:
- MSTEST0032
- ReviewAlwaysTrueAssertConditionAnalyzer
helpviewer_keywords:
- ReviewAlwaysTrueAssertConditionAnalyzer
- MSTEST0032
author: engyebrahim
ms.author: enjieid
---
# MSTEST0032: Review or remove the assertion as its condition is known to be always true

| Property                            | Value                                                                       |
|-------------------------------------|-----------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0032                                                                  |
| **Title**                           | Review or remove the assertion as its condition is known to be always true. |
| **Category**                        | Usage                                                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                                                |
| **Enabled by default**              | Yes                                                                         |
| **Default severity**                | Info                                                                        |
| **Introduced in version**           | 3.5.0                                                                       |
| **Is there a code fix**             | No                                                                          |

## Cause

This rule raises a diagnostic when a call to an assertion produces an always-true condition.

## Rule description

When you encounter an assertion that always passes (for example, `Assert.IsTrue(true)`), it's not obvious to someone reading the code why the assertion is there or what condition it's trying to check. This can lead to confusion and wasted time for developers who come across the code later on.

## How to fix violations

Ensure that calls to `Assert.IsTrue`, `Assert.IsFalse`, `Assert.AreEqual`, `Assert.AreNotEqual`, `Assert.IsNull` or `Assert.IsNotNull` aren't producing always-true conditions.

## When to suppress warnings

It's _not_ recommended to suppress warnings from this rule.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0032
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0032
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0032.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
