---
title: "MSTEST0074: Test mutating process-global state should declare a resource lock"
description: "Learn about code analysis rule MSTEST0074: Test mutating process-global state should declare a resource lock"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0074
- UndeclaredProcessGlobalStateMutationAnalyzer
helpviewer_keywords:
- UndeclaredProcessGlobalStateMutationAnalyzer
- MSTEST0074
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0074: Test mutating process-global state should declare a resource lock

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0074                                          |
| **Title**                           | Test mutating process-global state should declare a resource lock |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | Yes, for C# only                                   |

> [!IMPORTANT]
> `ResourceLockAttribute` is planned for MSTest 4.4 and is available only in preview builds until MSTest 4.4.0 is released.

> [!NOTE]
> This analyzer activates only when assembly parallelization is syntactically enabled, for example through `[assembly: Parallelize]` without a matching `[assembly: DoNotParallelize]`, or when a `.editorconfig` file sets `mstest_parallel_safety_mode = always`. The analyzer can't detect parallelization that's enabled only through `.runsettings` or MSBuild properties such as `MSTestParallelizeWorkers`. Set the `.editorconfig` option if you configure parallelization that way and still want this analyzer to run.

## Cause

A test, or a class-scoped fixture method it runs under, calls `Environment.SetEnvironmentVariable` or `Console.SetOut`/`SetError`/`SetIn` without a matching `[ResourceLock]` or `[DoNotParallelize]`.

## Rule description

Mutating process-global state, such as environment variables or console redirection, from a test is unsafe once in-assembly parallelization is enabled, because a sibling test running concurrently observes the mutation. Unlike `[ResourceLock]`, which fails open when a key is forgotten, this rule flags the mutation at compile time.

```csharp
[TestMethod]
public void SetsVariable()
{
    Environment.SetEnvironmentVariable("MODE", "test"); // Violation
}
```

## How to fix violations

Declare `[ResourceLock]` with the matching `WellKnownResources` key to serialize contending tests, or add `[DoNotParallelize]` to opt the test out of parallelization.

```csharp
[ResourceLock(WellKnownResources.EnvironmentVariables)]
[TestMethod]
public void SetsVariable()
{
    Environment.SetEnvironmentVariable("MODE", "test");
}
```

A C# code fix adds the `[ResourceLock]` attribute for you, at the test method or, for a class-scoped fixture such as `[TestInitialize]`, at the test class. Visual Basic code has this diagnostic but doesn't have an automatic fix; add the attribute by hand.

## When to suppress warnings

Don't suppress warnings from this rule without declaring a lock or opting out of parallelization, because doing so leaves the mutation racing silently against concurrently running tests.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0074
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0074
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0074.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [ResourceLockAttribute](../unit-testing-mstest-writing-tests-controlling-execution.md#resourcelockattribute)
- [DoNotParallelizeAttribute](../unit-testing-mstest-writing-tests-controlling-execution.md#donotparallelizeattribute)
