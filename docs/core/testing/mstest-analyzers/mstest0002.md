---
title: "MSTEST0002: Test classes should have valid layout"
description: "Learn about code analysis rule MSTEST0002: Test classes should have valid layout"
ms.date: 01/03/2024
f1_keywords:
- MSTEST0002
- TestClassShouldBeValidAnalyzer
helpviewer_keywords:
- TestClassShouldBeValidAnalyzer
- MSTEST0002
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0002: Test classes should have valid layout

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0002                                         |
| **Title**                           | Test classes should have valid layout              |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Breaking                                           |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 3.2.0                                              |
| **Is there a code fix**             | Yes                                                |

## Cause

A test class is not following one or multiple points of the required test class layout.

## Rule description

Test classes (classes marked with the `[TestClass]` attribute) should follow the given layout to be considered valid by MSTest:

- they should be `public` (or `internal` if the `[assembly: DiscoverInternals]` assembly attribute is set)
- they should not be `static`
- they should not be generic

## How to fix violations

Ensure that the class matches the required layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. Ignoring this rule will result in tests being ignored, because MSTest will not consider this class to be a test class.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0002
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0002
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0002.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
