---
title: "IDE0306: Use collection expression for new"
description: "Learn about code analysis rule IDE0306: Use collection expression for new"
ms.date: 03/25/2025
f1_keywords:
- IDE0306
helpviewer_keywords:
- IDE0306
dev_langs:
- CSharp
---
# Use collection expression for new (IDE0306)

| Property                 | Value                                         |
|--------------------------|-----------------------------------------------|
| **Rule ID**              | IDE0306                                       |
| **Title**                | Use collection expression for new             |
| **Category**             | Style                                         |
| **Subcategory**          | Language rules (expression-level preferences) |
| **Applicable languages** | C# 12+                                        |
| **Options**              | `dotnet_style_prefer_collection_expression`   |

## Overview

This rule flags places where a [collection expression](../../../csharp/language-reference/operators/collection-expressions.md) with a spread element (`..`) could be used to initialize a list instead of `new`. For example, this rule offers to simplify code like `new List<...>(x)` into the collection expression form (`[.. x]`).

## Options

Options specify the behavior that you want the rule to enforce. For information about configuring options, see [Option format](language-rules.md#option-format).

[!INCLUDE [dotnet-style-prefer-collection-expression](includes/dotnet-style-prefer-collection-expression.md)]

## Example

```csharp
// Code with violation.
List<int> l1 = new List<int>(Enumerable.Range(1, 10));
List<int> m1 = new List<int>(new[] { 1, 2, 3 });

// Fixed code.
List<int> l1 = [.. Enumerable.Range(1, 10)];
List<int> m1 = [.. new[] { 1, 2, 3 }];
```

## Suppress a warning

If you want to suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable IDE0306
// The code that's violating the rule is on this line.
#pragma warning restore IDE0306
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.IDE0306.severity = none
```

To disable all of the code-style rules, set the severity for the category `Style` to `none` in the [configuration file](../configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_analyzer_diagnostic.category-Style.severity = none
```

For more information, see [How to suppress code analysis warnings](../suppress-warnings.md).

## See also

- [Use collection expression for array (IDE0300)](ide0300.md)
- [Use collection expression for empty (IDE0301)](ide0301.md)
- [Use collection expression for stackalloc (IDE0302)](ide0302.md)
- [Use collection expression for `Create()` (IDE0303)](ide0303.md)
- [Use collection expression for builder (IDE0304)](ide0304.md)
- [Use collection expression for fluent (IDE0305)](ide0305.md)
