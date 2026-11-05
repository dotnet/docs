---
title: "MSTEST0003: Test methods should have valid layout"
description: "Learn about code analysis rule MSTEST0003: Test methods should have valid layout"
ms.date: 11/05/2026
ai-usage: ai-assisted
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

A test method doesn't follow the required test method layout.

## Rule description

MSTest discovers methods marked with `[TestMethod]`, creates a test-class instance, and invokes each method as a test. These requirements let the runner supply test data, observe failures, and complete the test lifecycle:

| Requirement | Reason |
|-------------|--------|
| The method is `public`, or `internal` with `[assembly: DiscoverInternals]`. | Public methods form MSTest's default test-entry-point contract. Internal discovery is an explicit alternative when you want tests to remain internal to the assembly. Private methods aren't test entry points. |
| The declaring type is accessible under the same discovery rules. | A public method inside an inaccessible type isn't publicly accessible. MSTest checks the containing types as well as the method so discovery uses a consistent visibility contract. |
| The method isn't `static`. | MSTest runs the method on the instance whose constructor, `TestContext`, `TestInitialize`, and `TestCleanup` belong to that test execution. Instance methods can use that per-test state instead of shared static state. |
| The method isn't `abstract`. | The runner needs a method body to invoke. To share test implementations, declare concrete test methods in a base class and run them through concrete test classes. |
| The method isn't generic in MSTest 3.7 or earlier. In MSTest 3.8 and later, every type parameter can be inferred from the supplied test data. | A generic method needs concrete type arguments before the runner can invoke it. Earlier versions don't infer those arguments. Later versions infer them from `DataRow` or `DynamicData` values, so a type parameter that doesn't occur in a method parameter can't be inferred. |
| The return type is `void`, `Task`, or `ValueTask` (`ValueTask` support starts with MSTest 3.3). | MSTest uses assertions and exceptions to determine the outcome, not a returned value. `Task` and `ValueTask` let the runner wait for asynchronous work before it starts cleanup and records the result. |
| The method isn't `async void`. | An `async void` method doesn't return an operation that MSTest can await. The runner can't reliably wait for its asynchronous work or associate later exceptions with the test result. |
| The method is an ordinary method, not a constructor, finalizer, accessor, or operator. | Those special members have language-defined roles and invocation rules. An ordinary method provides an independent test entry point that MSTest can call with the test's arguments. |

These requirements describe MSTest's discovery and invocation contract, not general C# or Visual Basic restrictions. For example, reflection can access non-public members, but MSTest deliberately uses the visibility rules above for test entry points.

## How to fix violations

Ensure that the test method matches the required layout described above.

The [MSTest analyzers](overview.md#editor-support) can report signature problems in your editor, including in code inserted by IntelliSense. In Visual Studio, use the light bulb menu to apply an available code fix. A code fix helps correct the method; it doesn't change the editor's code-generation templates.

## When to suppress warnings

Don't suppress a warning from this rule. An invalid signature can prevent test discovery or cause invocation to fail. Suppression hides the diagnostic but doesn't change how MSTest discovers or runs the method.

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
