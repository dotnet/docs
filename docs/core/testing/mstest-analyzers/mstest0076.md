---
title: "MSTEST0076: Avoid mutating process-wide culture in a parallelized test"
description: "Learn about code analysis rule MSTEST0076: Avoid mutating process-wide culture in a parallelized test"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0076
- CultureMutationUnderParallelizationAnalyzer
helpviewer_keywords:
- CultureMutationUnderParallelizationAnalyzer
- MSTEST0076
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0076: Avoid mutating process-wide culture in a parallelized test

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0076                                          |
| **Title**                           | Avoid mutating process-wide culture in a parallelized test |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | No                                                 |

> [!NOTE]
> This analyzer activates only when assembly parallelization is syntactically enabled, for example through `[assembly: Parallelize]` without a matching `[assembly: DoNotParallelize]`, or when a `.editorconfig` file sets `mstest_parallel_safety_mode = always`. The analyzer can't detect parallelization that's enabled only through `.runsettings` or MSBuild properties such as `MSTestParallelizeWorkers`. Set the `.editorconfig` option if you configure parallelization that way and still want this analyzer to run.

## Cause

A test, or a class-scoped fixture method it runs under, assigns <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> or `DefaultThreadCurrentUICulture` without a matching `[ResourceLock]` or `[DoNotParallelize]`.

## Rule description

`CultureInfo.DefaultThreadCurrentCulture` and `DefaultThreadCurrentUICulture` set the default culture for the whole process, so every concurrently running test observes the change, and formatting or parsing can be corrupted. The per-thread and ambient forms, `Thread.CurrentThread.CurrentCulture`/`CurrentUICulture` and `CultureInfo.CurrentCulture`/`CurrentUICulture`, aren't flagged: on modern .NET they assign an `AsyncLocal`-backed value that flows with the execution context, so they don't corrupt sibling tests.

```csharp
[TestMethod]
public void SetsCulture()
{
    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture; // Violation
}
```

Because the flagged setters are process-wide, restoring the previous value in a `finally` block doesn't help: concurrently running tests still observe the changed culture for the duration of the mutation.

## How to fix violations

Add `[DoNotParallelize]` on the test, or avoid mutating process-wide culture and use the per-thread or ambient culture properties instead.

```csharp
[DoNotParallelize]
[TestMethod]
public void SetsCulture()
{
    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
}
```

No well-known `[ResourceLock]` key exists for culture, so a declared `[ResourceLock]` of any kind is treated as an acknowledgment that you've coordinated culture access, and this rule stays silent.

## When to suppress warnings

Don't suppress warnings from this rule without opting out of parallelization or switching to the per-thread culture properties, because doing so leaves the mutation racing silently against concurrently running tests.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0076
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0076
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0076.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [DoNotParallelizeAttribute](../unit-testing-mstest-writing-tests-controlling-execution.md#donotparallelizeattribute)
