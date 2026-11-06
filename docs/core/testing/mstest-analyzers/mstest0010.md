---
title: "MSTEST0010: ClassInitialize method should have valid layout"
description: "Learn about code analysis rule MSTEST0010: ClassInitialize method should have valid layout"
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0010
- ClassInitializeShouldBeValidAnalyzer
helpviewer_keywords:
- ClassInitializeShouldBeValidAnalyzer
- MSTEST0010
author: engyebrahim
ms.author: enjieid
---
# MSTEST0010: ClassInitialize method should have valid layout

| Property                            | Value                                            |
|-------------------------------------|--------------------------------------------------|
| **Rule ID**                         | MSTEST0010                                       |
| **Title**                           | ClassInitialize method should have valid layout  |
| **Category**                        | Usage                                            |
| **Fix is breaking or non-breaking** | Non-breaking                                     |
| **Enabled by default**              | Yes                                              |
| **Default severity**                | Warning                                          |
| **Introduced in version**           | 3.3.0                                            |
| **Is there a code fix**             | Yes                                              |

## Cause

A method marked with `[ClassInitialize]` should have valid layout.

## Rule description

MSTest calls `[ClassInitialize]` to prepare resources shared by a test class, rather than the state of one test-class instance:

| Requirement | Reason |
|-------------|--------|
| The method is `public`. | Public methods form MSTest's lifecycle discovery contract. `[DiscoverInternals]` permits an internal declaring class, not an internal lifecycle method. |
| The method is `static`. | Class initialization belongs to the class's shared lifecycle, not to any one of the instances created for its tests. |
| The method is ordinary and isn't `abstract` or generic. | MSTest needs a method body it can invoke without special invocation rules or method type arguments. |
| The method takes exactly one `TestContext` parameter. | MSTest passes the class-initialization context directly because no per-test instance supplies it to this static callback. |
| The return type is `void`, `Task`, or `ValueTask`, and the method isn't `async void`. | MSTest must wait for asynchronous initialization and observe its failures before it runs tests that depend on the shared resources. |
| An abstract or generic declaring class specifies `InheritanceBehavior.BeforeEachDerivedClass`. | Such a base class doesn't run as a concrete test class on its own. The inheritance setting associates its initialization with the concrete derived classes that run the tests. |
| A sealed declaring class doesn't specify `InheritanceBehavior.BeforeEachDerivedClass`. | A sealed class can't have derived classes, so that inheritance setting has no lifecycle to apply to. |

[!INCLUDE [test-class-rules](includes/test-class-rules.md)]

## How to fix violations

Ensure that the method matches the layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0010
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0010
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0010.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
