---
title: "MSTEST0029: Public method should be test method"
description: "Learn about code analysis rule MSTEST0029: Public method should be test method"
ms.date: 04/06/2024
f1_keywords:
- MSTEST0029
- PublicMethodShouldBeTestMethod
helpviewer_keywords:
- PublicMethodShouldBeTestMethod
- MSTEST0029
author: engyebrahim
ms.author: enjieid
---
# MSTEST0029: Public method should be test method

| Property                            | Value                                        |
|-------------------------------------|----------------------------------------------|
| **Rule ID**                         | MSTEST0029                                   |
| **Title**                           | Public method should be test method          |
| **Category**                        | Design                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                 |
| **Enabled by default**              | No                                           |
| **Default severity**                | Info                                         |
| **Introduced in version**           | 3.5.0                                        |
| **Is there a code fix**             | Yes                                          |

## Cause

A `public` method should be a test method.

## Rule description

A `public` method of a class marked with `[TestClass]` should be a test method (marked with `[TestMethod]`). The rule ignores methods that are marked with `[TestInitialize]`, or `[TestCleanup]` attributes.

## How to fix violations

Ensure that the public method is a test method (marked with `[TestMethod]`).

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, the public method won't be considered as a test method.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0029
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0029
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0029.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
