---
title: "MSTEST0017: Assertion arguments should be passed in the correct order"
description: "Learn about code analysis rule MSTEST0017: Assertion arguments should be passed in the correct order"
ms.date: 03/19/2024
f1_keywords:
- MSTEST0017
- AssertionArgsShouldBePassedInCorrectOrderAnalyzer
helpviewer_keywords:
- AssertionArgsShouldBePassedInCorrectOrderAnalyzer
- MSTEST0017
author: Evangelink
ms.author: amauryleve
---
# MSTEST0017: Assertion arguments should be passed in the correct order

| Property                            | Value                                                               |
|-------------------------------------|---------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0017                                                          |
| **Title**                           | Assertion arguments should be passed in the correct order           |
| **Category**                        | Usage                                                               |
| **Fix is breaking or non-breaking** | Non-breaking                                                        |
| **Enabled by default**              | Yes                                                                 |
| **Default severity**                | Info                                                                |
| **Introduced in version**           | 3.4.0                                                               |
| **Is there a code fix**             | Yes                                                                 |

## Cause

This rule raises an issue when calls to `Assert.AreEqual`, `Assert.AreNotEqual`, `Assert.AreSame` or `Assert.AreNotSame` are following one or multiple of the patterns below:

- `actual` argument is a constant or literal value
- `actual` argument variable starts with `expected`, `_expected` or `Expected`
- `expected` or `notExpected` argument variable starts with `actual`
- `actual` is not a local variable

## Rule description

MSTest `Assert.AreEqual`, `Assert.AreNotEqual`, `Assert.AreSame` and `Assert.AreNotSame` expect the first argument to be the expected/unexpected value and the second argument to be the actual value.

Having the expected value and the actual value in the wrong order will not alter the outcome of the test (succeeds/fails when it should), but the assertion failure will contain misleading information.

## How to fix violations

Ensure that that `actual` and `expected`/`notExpected` arguments are passed in the correct order.

## When to suppress warnings

Do not suppress a warning from this rule as it would result to misleading output.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0017
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0017
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0017.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
