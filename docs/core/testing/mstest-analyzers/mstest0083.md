---
title: "MSTEST0083: Use '[ExecutableCondition]' instead of 'File.Exists' checks before 'Process.Start'"
description: "Learn about code analysis rule MSTEST0083: Use '[ExecutableCondition]' instead of 'File.Exists' checks before 'Process.Start'"
ms.date: 08/26/2026
f1_keywords:
- MSTEST0083
- UseExecutableConditionAttributeInsteadOfProcessCheckAnalyzer
helpviewer_keywords:
- UseExecutableConditionAttributeInsteadOfProcessCheckAnalyzer
- MSTEST0083
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0083: Use '\[ExecutableCondition]' instead of 'File.Exists' checks before 'Process.Start'

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0083                                         |
| **Title**                           | Use '\[ExecutableCondition]' instead of 'File.Exists' checks before 'Process.Start' |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | Yes, for C# only                                   |

> [!IMPORTANT]
> This analyzer is planned for MSTest 4.4 and is available only in preview builds until MSTest 4.4.0 is released.

## Cause

A test method first checks whether an executable exists and returns or calls `Assert.Inconclusive` when it doesn't, then calls `Process.Start` with the same executable path.

## Rule description

Use `[ExecutableCondition]` to declare that a test requires an executable. The attribute reports the test as skipped when MSTest can't resolve the executable. An early return incorrectly reports the test as passed, and an imperative check hides the requirement from discovery and reporting tools.

```csharp
[TestMethod]
public void RunsTool()
{
    if (!File.Exists("tool.exe")) return; // Violation
    Process.Start("tool.exe");
}
```

The analyzer recognizes a first-statement guard without a meaningful `else` branch when both `File.Exists` and the later `Process.Start` use the same constant executable path.

## How to fix violations

Replace the guard with `[ExecutableCondition]`.

```csharp
[TestMethod]
[ExecutableCondition("tool.exe")]
public void RunsTool() => Process.Start("tool.exe");
```

A C# code fix replaces the guard with the attribute. Visual Basic reports the diagnostic but doesn't provide an automatic fix.

## When to suppress warnings

Suppress the rule when the file check validates data rather than an executable prerequisite, or when the test needs behavior that `ExecutableConditionAttribute` can't express.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0083
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0083
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0083.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [ExecutableConditionAttribute](../unit-testing-mstest-writing-tests-controlling-execution.md#executableconditionattribute)
- [MSTEST0061: Use OSCondition attribute instead of runtime check](mstest0061.md)
- [MSTEST0079: Use ArchitectureCondition attribute instead of runtime checks](mstest0079.md)
