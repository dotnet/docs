---
title: "MSTEST0036: Do not use shadowing inside test class."
description: "Learn about code analysis rule MSTEST0036: Do not use shadowing inside test class."
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0036
- DoNotUseShadowingAnalyzer
helpviewer_keywords:
- DoNotUseShadowingAnalyzer
- MSTEST0036
author: engyebrahim
ms.author: enjieid
---
# MSTEST0036: Do not use shadowing inside test class

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0036                                                             |
| **Title**                           | Do not use shadowing inside test class.                                |
| **Category**                        | Design                                                                 |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Warning                                                                |
| **Introduced in version**           | 3.6.0                                                                  |
| **Is there a code fix**             | No                                                                     |

## Cause

A method or property in a test class hides an inherited member instead of overriding it.

## Rule description

Member hiding creates separate members with the same name. Base-class code can use the base member while MSTest's member lookup finds the derived member, so the two parts of the fixture no longer share the same state or behavior.

For example, a hidden `TestContext` property can receive the injected context while base-class code still reads an uninitialized property, causing a `NullReferenceException`. Hidden lifecycle or test methods can also change which inherited implementation runs. Unique helper names or intentional virtual overrides keep that contract explicit.

## How to fix violations

Rename or remove an unintended hidden member. If you intend polymorphic behavior, override a virtual base member instead of hiding it.

## When to suppress warnings

Suppress the diagnostic only if member hiding is intentional and you've confirmed that test discovery, lifecycle callbacks, and `TestContext` assignment still use the intended members. The `new` keyword doesn't merge the two members or resolve their separate state.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0036
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0036
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0036.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
