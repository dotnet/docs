---
title: "MSTEST0003: Test methods should have valid layout"
description: "Learn about code analysis rule MSTEST0003: Test methods should have valid layout"
ms.date: 01/03/2024
f1_keywords:
- MSTEST0003
- TestMethodShouldBeValidAnalyzer
helpviewer_keywords:
- TestMethodShouldBeValidAnalyzer
- MSTEST0003
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0003: Test methods should have valid layout

| Property                            | Value                                                                                     |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0003                                                                               |
| **Title**                           | Test methods should have valid layout                                                    |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Breaking                                                                                 |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning (escalated to Error when setting `MSTestAnalysisMode` to `Recommended` or `All`) |
| **Introduced in version**           | 3.2.0                                                                                    |
| **Is there a code fix**             | Yes                                                                                      |

## Cause

A test method is not following single or multiple points of the required test method layout.

## Rule description

Test methods (methods marked with the `[TestMethod]` attribute) should follow the given layout to be considered valid by MSTest:

- they should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)
- they should not be `static`
- they should not be generic if using MSTest 3.7 or earlier
- they should not be `abstract`
- they should return `void` or `Task`
- they should not be `async void`
- they should not be a special method (constructor, finalizer, operator...)
- the type declaring this method should be public

## How to fix violations

Ensure that the test method matches the required layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. Ignoring this rule will result in tests being ignored, because MSTest will not consider this method to be a test method.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0003
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0003
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0003.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
