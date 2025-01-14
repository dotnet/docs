---
title: "MSTEST0033: Non-nullable reference not initialized suppressor."
description: "Learn about code suppressor MSTEST0033: Non-nullable reference not initialized suppressor."
ms.date: 08/09/2024
f1_keywords:
- MSTEST0033
- NonNullableReferenceNotInitializedSuppressor
helpviewer_keywords:
- NonNullableReferenceNotInitializedSuppressor
- MSTEST0033
author: Evangelink
ms.author: amauryleve
---
# MSTEST0033: Non-nullable reference not initialized suppressor

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0033                               |
| **Title**                           | Suppress CS8618 for TestContext property |
| **Category**                        | Suppressor                               |
| **Introduced in version**           | 3.6.0                                    |

## Suppressor description

Suppress the [CS8618: Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.](../../../csharp/language-reference/compiler-messages/nullable-warnings.md#nonnullable-reference-not-initialized) diagnostic for the `TestContext` property as its value is always initialized by the MSTest framework.

## When to disable suppressor

It's _not_ recommended to disable this suppressor.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0033
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0033
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0033.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
