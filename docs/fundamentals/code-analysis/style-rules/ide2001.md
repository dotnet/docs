---
title: "IDE2001: Embedded statements must be on their own line"
description: "Learn about code analysis rule IDE2001: Embedded statements must be on their own line"
ms.date: 08/19/2025
f1_keywords:
- IDE2001
helpviewer_keywords:
- IDE2001
dev_langs:
- CSharp
- VB
ai-usage: ai-assisted
---
# Embedded statements must be on their own line (IDE2001)

| Property                 | Value                                                              |
|--------------------------|--------------------------------------------------------------------|
| **Rule ID**              | IDE2001                                                            |
| **Title**                | Embedded statements must be on their own line                      |
| **Category**             | Style                                                              |
| **Subcategory**          | Language rules (new-line preferences)                              |
| **Applicable languages** | C#                                                                 |
| **Options**              | `csharp_style_allow_embedded_statements_on_same_line_experimental` |

> [!NOTE]
> This rule is experimental and subject to change or removal.

## Overview

This style rule enforces that embedded statements (statements that are part of control flow constructs like `if`, `while`, and `for`) must be placed on their own line rather than on the same line as the control keyword.

## Options

Options specify the behavior that you want the rule to enforce. For information about configuring options, see [Option format](language-rules.md#option-format).

### csharp_style_allow_embedded_statements_on_same_line_experimental

| Property                 | Value                                        | Description |
|--------------------------|----------------------------------------------|-------------|
| **Option name**          | `csharp_style_allow_embedded_statements_on_same_line_experimental` | |
| **Option values**        | `true`                                       | Allow embedded statements on same line as control keyword |
|                          | `false`                                      | Require embedded statements to be on their own line |
| **Default option value** | `true`                                       |             |

## Example

```csharp
// csharp_style_allow_embedded_statements_on_same_line_experimental = true
for (int i = 0; i < 10; i++) Console.WriteLine(i);
```

```csharp
// csharp_style_allow_embedded_statements_on_same_line_experimental = false
for (int i = 0; i < 10; i++)
    Console.WriteLine(i);
```

## Suppress a warning

If you want to suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable IDE2001
// The code that's violating the rule is on this line.
#pragma warning restore IDE2001
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.IDE2001.severity = none
```

To disable all of the code-style rules, set the severity for the category `Style` to `none` in the [configuration file](../configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_analyzer_diagnostic.category-style.severity = none
```

For more information, see [How to suppress code analysis warnings](../suppress-warnings.md).

## See also

- [New-line preferences](language-rules.md#new-line-preferences)
- [Code style language rules](language-rules.md)
- [Code style rules reference](index.md)
