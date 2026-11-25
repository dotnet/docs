---
title: "MSTEST0013: AssemblyCleanup method should have valid layout"
description: "Learn about code analysis rule MSTEST0013: AssemblyCleanup method should have valid layout"
ms.date: 11/05/2026
ai-usage: ai-assisted
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

MSTest calls `[AssemblyCleanup]` to release assembly-wide resources after the assembly's tests finish:

| Requirement | Reason |
|-------------|--------|
| The method is `public static`. | MSTest discovers a public lifecycle entry point and invokes it without a test-class instance. Assembly cleanup must not depend on the state of one test instance. |
| The method is ordinary and isn't `abstract` or generic. | MSTest needs a method body it can invoke without special invocation rules or method type arguments. |
| The method has no parameters, or one `TestContext` parameter in MSTest 3.8 and later. | MSTest can invoke cleanup without arguments or supply the assembly-cleanup context. It doesn't supply an individual test's arguments. |
| The return type is `void`, `Task`, or `ValueTask`, and the method isn't `async void`. | MSTest must wait for asynchronous resource release and observe cleanup failures before it completes the assembly lifecycle. |
| The declaring type is a non-generic class marked with `[TestClass]` or a derived attribute. | MSTest locates assembly callbacks through test-class containers. A non-generic container identifies the callback without requiring class type arguments. The container can be static. |
| The declaring class is `public`, or `internal` with `[assembly: DiscoverInternals]`. | The container must be accessible under MSTest's discovery contract. Internal discovery doesn't change the requirement that the callback itself is public. |

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
