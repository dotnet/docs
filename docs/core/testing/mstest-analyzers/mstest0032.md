---
title: "MSTEST0032: Review or remove the assertion as its condition is known to be always true."
description: "Learn about code analysis rule MSTEST0032: Review or remove the assertion as its condition is known to be always true."
ms.date: 11/05/2026
ai-usage: ai-assisted
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
| **Default severity**                | Warning starting with 4.0.0, Info before                                    |
| **Introduced in version**           | 3.5.0                                                                       |
| **Is there a code fix**             | No                                                                          |

## Cause

This rule raises a diagnostic when a call to an assertion produces an always-true condition.

## Rule description

An assertion that always passes, such as `Assert.IsTrue(true)`, can't detect a regression in the code under test. It can make a test appear to verify behavior while checking only a constant or a value against itself.

Review the assertion for a copy-and-paste error, a missing comparison, or the wrong variable. Assert a condition based on the actual result, or remove an assertion that has no behavior to verify.

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
