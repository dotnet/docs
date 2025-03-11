---
title: "MSTEST0016: Test class should have test method"
description: "Learn about code analysis rule MSTEST0016: Test class should have test method"
ms.date: 03/12/2024
f1_keywords:
- MSTEST0016
- TestClassShouldHaveTestMethod
helpviewer_keywords:
- TestClassShouldHaveTestMethod
- MSTEST0016
author: engyebrahim
ms.author: enjieid
---
# MSTEST0016: Test class should have test method

| Property                            | Value                                        |
|-------------------------------------|----------------------------------------------|
| **Rule ID**                         | MSTEST0016                                   |
| **Title**                           | Test class should have test method           |
| **Category**                        | Design                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                 |
| **Enabled by default**              | Yes                                          |
| **Default severity**                | Info                                         |
| **Introduced in version**           | 3.3.0                                        |
| **Is there a code fix**             | No                                           |

## Cause

A test class should have a test method.

## Rule description

A test class should have at least one test method or be `static` and have methods that are attributed with `[AssemblyInitialize]` or `[AssemblyCleanup]`.

## How to fix violations

Ensure that the test class has a test method or is `static` and has methods attributed with `[AssemblyInitialize]` or `[AssemblyCleanup]`.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, test class will be ignored.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0016
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0016
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0016.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
