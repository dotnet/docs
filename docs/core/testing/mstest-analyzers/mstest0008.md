---
title: "MSTEST0008: TestInitialize method should have valid layout"
description: "Learn about code analysis rule MSTEST0008: TestInitialize method should have valid layout"
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0008
- TestInitializeShouldBeValidAnalyzer
helpviewer_keywords:
- TestInitializeShouldBeValidAnalyzer
- MSTEST0008
author: engyebrahim
ms.author: enjieid
---
# MSTEST0008: TestInitialize method should have valid layout

| Property                            | Value                                          |
|-------------------------------------|------------------------------------------------|
| **Rule ID**                         | MSTEST0008                                     |
| **Title**                           | TestInitialize method should have valid layout |
| **Category**                        | Usage                                          |
| **Fix is breaking or non-breaking** | Non-breaking                                   |
| **Enabled by default**              | Yes                                            |
| **Default severity**                | Warning                                        |
| **Introduced in version**           | 3.3.0                                          |
| **Is there a code fix**             | Yes                                            |

## Cause

A method marked with `[TestInitialize]` should have valid layout.

## Rule description

MSTest calls `[TestInitialize]` on the test-class instance before it invokes the test method. The callback prepares that test's state:

| Requirement | Reason |
|-------------|--------|
| The method is `public`. | Public methods form MSTest's lifecycle discovery contract. `[DiscoverInternals]` permits an internal declaring class, not an internal lifecycle method. |
| The method isn't `static`. | Initialization needs access to the same instance fields and `TestContext` as the test method. |
| The method is ordinary and isn't `abstract`. | MSTest needs a callable method body, not a special member with language-defined invocation rules. |
| The method isn't generic. | Lifecycle callbacks don't receive test-data arguments from which MSTest could infer method type arguments. |
| The method has no parameters. | MSTest invokes this callback without arguments. Use the instance's `TestContext` for per-test information. |
| The return type is `void`, `Task`, or `ValueTask`. | An awaitable return value lets MSTest complete asynchronous setup before the test starts. |
| The method isn't `async void`. | Without an awaitable result, setup could continue after the test starts, and later exceptions couldn't be reliably recorded as initialization failures. |

[!INCLUDE [test-class-rules](includes/test-class-rules.md)]

## How to fix violations

Ensure that the method matches the layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0008
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0008
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0008.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
