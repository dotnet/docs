---
title: "MSTEST0078: '[DependsOn]' arguments should be valid"
description: "Learn about code analysis rule MSTEST0078: '[DependsOn]' arguments should be valid"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0078
- DependsOnShouldBeValidAnalyzer
helpviewer_keywords:
- DependsOnShouldBeValidAnalyzer
- MSTEST0078
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0078: '\[DependsOn]' arguments should be valid

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0078                                          |
| **Title**                           | '\[DependsOn]' arguments should be valid            |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | No                                                 |

> [!IMPORTANT]
> Test dependencies are planned for MSTest 4.4 and are available only in preview builds until MSTest 4.4.0 is released.

## Cause

A `[DependsOn]` attribute references a test by name, and the reference has a problem that the test framework can decide only at run time, such as a target that doesn't exist.

## Rule description

The test framework deliberately treats a `[DependsOn]` target that matches no test as a non-fatal warning at run time, so that `--filter` and single-test runs keep working. That means a typo or a rename silently drops the declared ordering instead of failing the build. This analyzer reports the problems that can be decided at build time:

- The referenced method doesn't exist on the referenced type.
- The referenced member isn't a test method, so the dependency is ignored.
- The referenced type isn't a test class, so the dependency is ignored.
- The referenced type is declared in another assembly (dependencies are resolved within a single test source).
- The referenced type is abstract, so its tests run under each derived test class instead.
- The attribute makes a test depend on itself, which is a dependency cycle that fails at run time.
- The attribute participates in a dependency cycle that's visible in the compilation, which fails every test in the cycle at run time.
- The attribute is applied where it has no effect, because the attribute target isn't a test method or runs no test.

```csharp
[TestMethod]
public void CreateCart() { }

[TestMethod, DependsOn("CreatCart")] // Violation: typo, no such member
public void AddItem() { }
```

## How to fix violations

Fix the typo or rename, and use `nameof` so the compiler keeps the reference in sync when you rename the target.

```csharp
[TestMethod]
public void CreateCart() { }

[TestMethod, DependsOn(nameof(CreateCart))]
public void AddItem() { }
```

## When to suppress warnings

Don't suppress warnings from this rule. Each case reported by this analyzer either fails the dependent test at run time, such as a self-reference or a cycle, or silently drops the declared ordering, such as a typo or a reference to a non-test member.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0078
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0078
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0078.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Test dependencies](../unit-testing-mstest-writing-tests-controlling-execution.md#test-dependencies)
