---
title: "MSTEST0024: Do not store TestContext in a static member"
description: "Learn about code analysis rule MSTEST0024: Do not store TestContext in a static member"
ms.date: 03/19/2024
f1_keywords:
- MSTEST0024
- DoNotStoreStaticTestContextAnalyzer
helpviewer_keywords:
- DoNotStoreStaticTestContextAnalyzer
- MSTEST0024
author: Evangelink
ms.author: amauryleve
---
# MSTEST0024: Do not store TestContext in a static member

| Property                            | Value                                       |
|-------------------------------------|---------------------------------------------|
| **Rule ID**                         | MSTEST0024                                  |
| **Title**                           | Do not store TestContext in a static member |
| **Category**                        | Usage                                       |
| **Fix is breaking or non-breaking** | Non-breaking                                |
| **Enabled by default**              | Yes                                         |
| **Default severity**                | Info                                        |
| **Introduced in version**           | 3.4.0                                       |
| **Is there a code fix**             | No                                          |

## Cause

This rule raises a diagnostic when an assignment to a `static` member of a `TestContext` parameter is done.

## Rule description

The `TestContext` parameter passed to each initialize method (`[AssemblyInitialize]` or `[ClassInitialize]`) is specific to the current context and is not updated on each test execution. Storing, for reuse, this `TextContext` object will most of the time lead to issues.

## How to fix violations

Do not store the `[AssemblyInitialize]` or `[ClassInitialize]` `TestContext` parameter.

## When to suppress warnings

You can suppress warnings from this rule if you are sure of the behavior does match what you want to do.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0024
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0024
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0024.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
