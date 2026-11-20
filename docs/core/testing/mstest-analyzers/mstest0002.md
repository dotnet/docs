---
title: "MSTEST0002: Test classes should have valid layout"
description: "Learn about code analysis rule MSTEST0002: Test classes should have valid layout"
ms.date: 11/05/2026
ai-usage: ai-assisted
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

A test class has invalid accessibility or is static while it declares test methods or class/per-test lifecycle methods.

## Rule description

MSTest uses a test class as the fixture that owns test methods, per-test state, and lifecycle callbacks. This rule checks visibility and the use of static classes to support that execution model:

| Requirement | Reason |
|-------------|--------|
| The class is `public`, or `internal` with `[assembly: DiscoverInternals]`. | MSTest uses publicly accessible types as its default discovery contract. The assembly attribute explicitly opts into internal test classes without exposing them outside the assembly. |
| A class that contains tests or class/per-test lifecycle methods isn't `static`. | MSTest creates a test-class instance for each test execution. That instance holds the test's fields and `TestContext`, rather than state shared by every test. A static class can't provide an instance. |

Generic base classes aren't inherently invalid. MSTest needs a concrete type to create a test instance, so runnable classes must have fully specified type arguments. A generic abstract base class can supply inherited tests to concrete derived classes that specify those arguments.

Static classes can contain assembly or global lifecycle methods, which don't require a test-class instance. For more information, see [MSTest lifecycle](../unit-testing-mstest-writing-tests-lifecycle.md).

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
