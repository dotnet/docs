---
title: "MSTEST0013: AssemblyCleanup method should have valid layout"
description: "Learn about code analysis rule MSTEST0013: AssemblyCleanup method should have valid layout"
ms.date: 02/19/2024
f1_keywords:
- MSTEST0013
- AssemblyCleanupShouldBeValidAnalyzer
helpviewer_keywords:
- AssemblyCleanupShouldBeValidAnalyzer
- MSTEST0013
author: engyebrahim
ms.author: enjieid
---
# MSTEST0013: AssemblyCleanup method should have valid layout

| Property                            | Value                                           |
|-------------------------------------|-------------------------------------------------|
| **Rule ID**                         | MSTEST0013                                      |
| **Title**                           | AssemblyCleanup method should have valid layout |
| **Category**                        | Usage                                           |
| **Fix is breaking or non-breaking** | Non-breaking                                    |
| **Enabled by default**              | Yes                                             |
| **Default severity**                | Warning                                         |
| **Introduced in version**           | 3.3.0                                           |
| **Is there a code fix**             | Yes                                             |

## Cause

A method marked with `[AssemblyCleanup]` should have valid layout.

## Rule description

Methods marked with `[AssemblyCleanup]` should follow the following layout to be valid:

- it should be `public`
- it should be `static`
- it should not be `async void`
- it should not be a special method (finalizer, operator...).
- it should not be generic
- it should not be abstract
- it should not take any parameter, or starting with MSTest 3.8, it can have a single `TestContext` parameter
- return type should be `void`, `Task` or `ValueTask`

The type declaring these methods should also respect the following rules:

- The type should be a class.
- The class should be public or internal (if the test project is using the [DiscoverInternals] attribute).
- The class should be marked with [TestClass] (or a derived attribute)
- the class should not be generic

## How to fix violations

Ensure that the method matches the layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0013
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0013
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0013.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
