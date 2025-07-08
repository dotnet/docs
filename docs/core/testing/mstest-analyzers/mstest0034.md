---
title: "MSTEST0034: Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`."
description: "Learn about code analysis rule MSTEST0034: Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`."
ms.date: 07/22/2024
f1_keywords:
- MSTEST0034
- UseClassCleanupBehaviorEndOfClass
helpviewer_keywords:
- UseClassCleanupBehaviorEndOfClass
- MSTEST0034
author: engyebrahim
ms.author: enjieid
---
# MSTEST0034: Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`

| Property                            | Value                                                            |
|-------------------------------------|------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0034                                                       |
| **Title**                           | Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`. |
| **Category**                        | Usage                                                            |
| **Fix is breaking or non-breaking** | Non-breaking                                                     |
| **Enabled by default**              | Yes                                                              |
| **Default severity**                | Info                                                             |
| **Introduced in version**           | 3.6.0                                                            |
| **Is there a code fix**             | No                                                               |

## Cause

This rule raises a diagnostic when `ClassCleanupBehavior.EndOfClass` isn't set with the `[ClassCleanup]`.

## Rule description

Without using  `ClassCleanupBehavior.EndOfClass`, the `[ClassCleanup]` will by default be run at the end of the assembly and not at the end of the class.

## How to fix violations

Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`.

## When to suppress warnings

It's _not_ recommended to suppress warnings from this rule as you can use instead `[AssemblyCleanup]`.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0034
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0034
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0034.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
