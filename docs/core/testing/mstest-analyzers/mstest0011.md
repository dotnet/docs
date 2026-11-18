---
title: "MSTEST0011: ClassCleanup method should have valid layout"
description: "Learn about code analysis rule MSTEST0011: ClassCleanup method should have valid layout"
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0011
- ClassCleanupShouldBeValidAnalyzer
helpviewer_keywords:
- ClassCleanupShouldBeValidAnalyzer
- MSTEST0011
author: engyebrahim
ms.author: enjieid
---
# MSTEST0011: ClassCleanup method should have valid layout

| Property                            | Value                                        |
|-------------------------------------|----------------------------------------------|
| **Rule ID**                         | MSTEST0011                                   |
| **Title**                           | ClassCleanup method should have valid layout |
| **Category**                        | Usage                                        |
| **Fix is breaking or non-breaking** | Non-breaking                                 |
| **Enabled by default**              | Yes                                          |
| **Default severity**                | Warning                                      |
| **Introduced in version**           | 3.3.0                                        |
| **Is there a code fix**             | Yes                                          |

## Cause

A method marked with `[ClassCleanup]` should have valid layout.

## Rule description

MSTest calls `[ClassCleanup]` to release resources shared by a test class, rather than resources owned by one test-class instance:

| Requirement | Reason |
|-------------|--------|
| The method is `public`. | Public methods form MSTest's lifecycle discovery contract. `[DiscoverInternals]` permits an internal declaring class, not an internal lifecycle method. |
| The method is `static`. | Class cleanup belongs to the class's shared lifecycle and must not depend on a particular test instance. |
| The method is ordinary and isn't `abstract` or generic. | MSTest needs a method body it can invoke without special invocation rules or method type arguments. |
| The method has no parameters, or one `TestContext` parameter in MSTest 3.8 and later. | MSTest can invoke cleanup without arguments or supply the class-cleanup context. It doesn't supply arbitrary arguments or a test's data row. |
| The return type is `void`, `Task`, or `ValueTask`, and the method isn't `async void`. | MSTest must wait for asynchronous cleanup and observe its failures instead of leaving resource release to an unobserved operation. |
| An abstract or generic declaring class specifies `InheritanceBehavior.BeforeEachDerivedClass`. | The inheritance setting associates a base class's cleanup with the concrete derived classes that use its resources. |
| A sealed declaring class doesn't specify `InheritanceBehavior.BeforeEachDerivedClass`. | A sealed class can't have derived classes, so that inheritance setting has no lifecycle to apply to. |

[!INCLUDE [test-class-rules](includes/test-class-rules.md)]

## How to fix violations

Ensure that the method matches the layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0011
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0011
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0011.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
