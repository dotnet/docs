---
title: "MSTEST0077: Avoid hardcoded or shared filesystem paths in a parallelized test"
description: "Learn about code analysis rule MSTEST0077: Avoid hardcoded or shared filesystem paths in a parallelized test"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0077
- SharedFileSystemPathInTestAnalyzer
helpviewer_keywords:
- SharedFileSystemPathInTestAnalyzer
- MSTEST0077
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0077: Avoid hardcoded or shared filesystem paths in a parallelized test

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0077                                          |
| **Title**                           | Avoid hardcoded or shared filesystem paths in a parallelized test |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | No                                                 |

> [!IMPORTANT]
> `TestContext.TestTempDirectory` is planned for MSTest 4.4 and is available only in preview builds until MSTest 4.4.0 is released.

> [!NOTE]
> This analyzer activates only when assembly parallelization is syntactically enabled, for example through `[assembly: Parallelize]` without a matching `[assembly: DoNotParallelize]`, or when a `.editorconfig` file sets `mstest_parallel_safety_mode = always`. The analyzer can't detect parallelization that's enabled only through `.runsettings` or MSBuild properties such as `MSTestParallelizeWorkers`. Set the `.editorconfig` option if you configure parallelization that way and still want this analyzer to run.

## Cause

A test passes a constant absolute path, or a relative path literal, directly to a filesystem-mutating `File.*`/`Directory.*` method, such as `File.WriteAllText` or `Directory.CreateDirectory`.

## Rule description

A hardcoded or relative constant path targets a location shared by every other test in the assembly. Under in-assembly parallelization, two tests can then write to the same location concurrently and collide.

```csharp
[TestMethod]
public void WritesReport()
{
    File.WriteAllText("report.txt", contents); // Violation
}
```

Only statically constant paths passed to a mutating API are flagged. Reads, path construction, and paths built from variables are left for you to review manually, because the analyzer can't tell whether two tests actually collide on a computed path.

## How to fix violations

Use a unique per-test location, such as `TestContext.TestTempDirectory`, instead of a fixed or relative path.

```csharp
[TestMethod]
public void WritesReport()
{
    string path = Path.Combine(TestContext.TestTempDirectory!, "report.txt");
    File.WriteAllText(path, contents);
}
```

## When to suppress warnings

It's safe to suppress this warning if the path intentionally targets a fixture that every test reads but no test writes concurrently, or if the tests that write to it are already coordinated, for example through `[DoNotParallelize]`.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0077
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0077
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0077.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Per-test temporary directory](../unit-testing-mstest-writing-tests-testcontext.md#per-test-temporary-directory)
- [DoNotParallelizeAttribute](../unit-testing-mstest-writing-tests-controlling-execution.md#donotparallelizeattribute)
