---
title: "MSTEST0025: Use 'Assert.Fail' instead of an always-failing assert"
description: "Learn about code analysis rule MSTEST0025: Use 'Assert.Fail' instead of an always-failing assert"
ms.date: 05/07/2024
f1_keywords:
- MSTEST0025
- PreferAssertFailOverAlwaysFalseConditionsAnalyzer
helpviewer_keywords:
- PreferAssertFailOverAlwaysFalseConditionsAnalyzer
- MSTEST0025
author: Evangelink
ms.author: amauryleve
---
# MSTEST0025: Use 'Assert.Fail' instead of an always-failing assert

| Property                            | Value                                                 |
|-------------------------------------|-------------------------------------------------------|
| **Rule ID**                         | MSTEST0025                                            |
| **Title**                           | Use 'Assert.Fail' instead of an always-failing assert |
| **Category**                        | Design                                                |
| **Fix is breaking or non-breaking** | Non-breaking                                          |
| **Enabled by default**              | Yes                                                   |
| **Default severity**                | Info                                                  |
| **Introduced in version**           | 3.4.0                                                 |
| **Is there a code fix**             | Yes                                                   |

## Cause

This rule raises a diagnostic when a call to an assertion produces an always-false condition.

## Rule description

Using `Assert.Fail` over an always-failing assertion call provides clearer intent and better documentation for the code.

When you encounter an assertion that always fails (for example, `Assert.IsTrue(false)`), it might not be immediately obvious to someone reading the code why the assertion is there or what condition it's trying to check. This can lead to confusion and wasted time for developers who come across the code later on.

In contrast, using `Assert.Fail` allows you to provide a custom failure message, making it clear why the assertion is failing and what specific condition or scenario it's addressing. This message serves as documentation for the intent behind the assertion, helping other developers understand the purpose of the assertion without needing to dive deep into the code.

Overall, using `Assert.Fail` promotes clarity, documentation, and maintainability in your codebase, making it a better choice over an always failing assertion call.

## How to fix violations

Ensure that calls to `Assert.IsTrue`, `Assert.IsFalse`, `Assert.AreEqual`, `Assert.AreNotEqual`, `Assert.IsNull` or `Assert.IsNotNull` are not producing always-failing conditions.

## When to suppress warnings

We do not recommend suppressing warnings from this rule.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0025
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0025
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0025.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
