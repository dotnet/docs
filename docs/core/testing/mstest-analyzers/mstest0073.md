---
title: "MSTEST0073: Prefer a constant for the '[ResourceLock]' resource key"
description: "Learn about code analysis rule MSTEST0073: Prefer a constant for the '[ResourceLock]' resource key"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0073
- PreferConstantForResourceLockAnalyzer
helpviewer_keywords:
- PreferConstantForResourceLockAnalyzer
- MSTEST0073
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0073: Prefer a constant for the '\[ResourceLock]' resource key

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0073                                          |
| **Title**                           | Prefer a constant for the '\[ResourceLock]' resource key |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | No                                                 |

> [!IMPORTANT]
> `ResourceLockAttribute` is planned for MSTest 4.4 and is available only in preview builds until MSTest 4.4.0 is released.

## Cause

A `[ResourceLock]` attribute passes its resource key as a bare string literal instead of referencing a shared constant.

## Rule description

`[ResourceLock]` matches tests by exact, case-sensitive string equality of the resource key. A bare string literal fails open: a typo produces a different key, so the conflicting tests are no longer serialized and race silently instead of failing with a build error. Referencing a shared constant, such as a `WellKnownResources` member or your own `const`, makes typos a compile error and lets the compiler enforce that every test contending on the same resource uses the same key.

```csharp
[ResourceLock("database")] // Violation: bare string literal.
[TestMethod]
public void ReadsSharedSchema() { }
```

## How to fix violations

Reference a `WellKnownResources` member for process-global state, or declare and reference your own `const string`.

```csharp
private const string Database = "database";

[ResourceLock(Database)]
[TestMethod]
public void ReadsSharedSchema() { }
```

## When to suppress warnings

It's safe to suppress this warning if you intentionally use a literal resource key and are confident no other test in the assembly needs to coordinate on the same resource.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0073
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0073
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0073.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [ResourceLockAttribute](../unit-testing-mstest-writing-tests-controlling-execution.md#resourcelockattribute)
