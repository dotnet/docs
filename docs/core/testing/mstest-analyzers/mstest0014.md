---
title: "MSTEST0014: DataRow should be valid"
description: "Learn about code analysis rule MSTEST0014: DataRow should be valid"
ms.date: 11/05/2026
ai-usage: ai-assisted
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

MSTest turns each `[DataRow]` into arguments for a test-method invocation. The attribute doesn't declare a test by itself:

| Requirement | Reason |
|-------------|--------|
| Apply `[DataRow]` to a method marked with `[TestMethod]` or a derived attribute. | `[TestMethod]` identifies the test entry point. Without it, MSTest doesn't invoke the method as a test, regardless of the supplied data. |
| Supply an argument count that matches the method's parameters, including any supported `params` handling. | MSTest binds the row's values to the parameter list. Missing or extra arguments can prevent the test method from being invoked. |
| Supply values compatible with the parameter types. | The runner must pass each value to its corresponding parameter. An incompatible value causes an argument-binding failure instead of exercising the behavior the test intends to check. |

For supported argument shapes and examples, see [Data-driven testing](../unit-testing-mstest-writing-tests-data-driven.md#datarowattribute).

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
