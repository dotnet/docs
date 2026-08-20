---
title: "MSTEST0080: Use CICondition attribute instead of environment checks"
description: "Learn about code analysis rule MSTEST0080: Use CICondition attribute instead of environment checks"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0080
- UseCIConditionAttributeInsteadOfEnvironmentCheckAnalyzer
helpviewer_keywords:
- UseCIConditionAttributeInsteadOfEnvironmentCheckAnalyzer
- MSTEST0080
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0080: Use CICondition attribute instead of environment checks

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0080                                          |
| **Title**                           | Use CICondition attribute instead of environment checks |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | Yes, for C# only                                   |

## Cause

A test method's first statement null-checks the result of `Environment.GetEnvironmentVariable("CI")` and then either returns early or calls `Assert.Inconclusive`, instead of using the `[CICondition]` attribute.

## Rule description

Test methods that null-check the `CI` environment variable and then early return or call `Assert.Inconclusive` should use the `[CICondition]` attribute instead. The attribute recognizes every continuous integration provider MSTest knows about, and it reports the test as skipped rather than passed, which an early return doesn't.

```csharp
[TestMethod]
public void TestMethod()
{
    if (Environment.GetEnvironmentVariable("CI") is null) return; // Violation
}
```

The analyzer is deliberately limited to the general-use `CI` variable that every major provider sets. A guard on a provider-specific variable, such as `TF_BUILD`, means "skip on Azure Pipelines", while `[CICondition]` means "skip on any CI", so the analyzer doesn't suggest replacing a provider-specific check.

## How to fix violations

Replace the environment-variable check with the `[CICondition]` attribute.

```csharp
[TestMethod]
[CICondition(ConditionMode.Include)]
public void TestMethod() { }
```

A C# code fix replaces the guard with the attribute for you. Visual Basic code has this diagnostic but doesn't have an automatic fix; apply the attribute by hand.

## When to suppress warnings

You might suppress this warning if your environment check is more complex than a simple first-statement null check, or if you need conditional logic that `[CICondition]` can't express.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0080
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0080
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0080.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [CIConditionAttribute](../unit-testing-mstest-writing-tests-controlling-execution.md#ciconditionattribute)
