---
title: "MSTEST0028: Use Async suffix for async methods suppressor."
description: "Learn about code suppressor MSTEST0028: Use Async suffix for async methods suppressor."
ms.date: 08/09/2024
f1_keywords:
- MSTEST0028
- UseAsyncSuffixTestFixtureMethodSuppressor
helpviewer_keywords:
- VSTHRD200
- UseAsyncSuffixTestFixtureMethodSuppressor
author: Evangelink
ms.author: amauryleve
---
# MSTEST0028: Non-nullable reference not initialized suppressor

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0028                               |
| **Title**                           | Suppress VSTHRD200 for test methods      |
| **Category**                        | Suppressor                               |
| **Introduced in version**           | 3.5.0                                    |

## Suppressor description

Suppress the [VSTHRD200: Use Async suffix for async methods](https://github.com/microsoft/vs-threading/blob/main/doc/analyzers/VSTHRD200.md) diagnostic for all test fixture methods as they are not required to follow the naming convention.

## When to disable suppressor

You can disable this suppressor if you want to follow the `Async` suffix pattern also for your test fixture methods.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0028
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0028
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0028.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
