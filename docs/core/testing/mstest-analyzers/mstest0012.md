---
title: "MSTEST0012: AssemblyInitialize method should have valid layout"
description: "Learn about code analysis rule MSTEST0012: AssemblyInitialize method should have valid layout"
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0012
- AssemblyInitializeShouldBeValidAnalyzer
helpviewer_keywords:
- AssemblyInitializeShouldBeValidAnalyzer
- MSTEST0012
author: engyebrahim
ms.author: enjieid
---
# MSTEST0012: AssemblyInitialize method should have valid layout

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0012                                         |
| **Title**                           | AssemblyInitialize method should have valid layout |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 3.3.0                                              |
| **Is there a code fix**             | Yes                                                |

## Cause

A method marked with `[AssemblyInitialize]` should have valid layout.

## Rule description

MSTest calls `[AssemblyInitialize]` to prepare resources for the test assembly before its tests run:

| Requirement | Reason |
|-------------|--------|
| The method is `public static`. | MSTest discovers a public lifecycle entry point and invokes it without a test-class instance. Assembly setup belongs to the whole assembly, not one test. |
| The method is ordinary and isn't `abstract` or generic. | MSTest needs a method body it can invoke without special invocation rules or method type arguments. |
| The method takes exactly one `TestContext` parameter. | MSTest passes the assembly-initialization context directly to the static callback. That context describes assembly setup, not an individual test execution. |
| The return type is `void`, `Task`, or `ValueTask`, and the method isn't `async void`. | MSTest must wait for setup and observe its failures before it runs tests that depend on the assembly's resources. |
| The declaring type is a non-generic class marked with `[TestClass]` or a derived attribute. | MSTest locates assembly callbacks through test-class containers. A non-generic container identifies the callback without requiring class type arguments. The container can be static. |
| The declaring class is `public`, or `internal` with `[assembly: DiscoverInternals]`. | The container must be accessible under MSTest's discovery contract. Internal discovery doesn't change the requirement that the callback itself is public. |

To access per-test information instead of assembly-initialization information, use the test instance's `TestContext`. See [MSTEST0024](mstest0024.md).

## How to fix violations

Ensure that the method matches the layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0012
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0012
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0012.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
