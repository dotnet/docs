---
title: "IDE2004: Blank line not allowed after constructor initializer colon"
description: "Learn about code analysis rule IDE2004: Blank line not allowed after constructor initializer colon"
ms.date: 08/19/2025
f1_keywords:
- IDE2004
helpviewer_keywords:
- IDE2004
dev_langs:
- CSharp
ai-usage: ai-assisted
---
# Blank line not allowed after constructor initializer colon (IDE2004)

| Property                 | Value                                                      |
|--------------------------|------------------------------------------------------------|
| **Rule ID**              | IDE2004                                                    |
| **Title**                | Blank line not allowed after constructor initializer colon |
| **Category**             | Style                                                      |
| **Subcategory**          | Language rules (new-line preferences)                      |
| **Applicable languages** | C#                                                         |
| **Options**              | `csharp_style_allow_blank_line_after_colon_in_constructor_initializer_experimental` |

> [!NOTE]
> This rule is experimental and subject to change or removal.

## Overview

This style rule enforces that there should not be a blank line after the colon (`:`) in a constructor initializer. The `base()` or `this()` call should immediately follow the colon without any blank lines in between.

## Options

Options specify the behavior that you want the rule to enforce. For information about configuring options, see [Option format](language-rules.md#option-format).

### csharp_style_allow_blank_line_after_colon_in_constructor_initializer_experimental

| Property                 | Value                                        | Description |
|--------------------------|----------------------------------------------|-------------|
| **Option name**          | `csharp_style_allow_blank_line_after_colon_in_constructor_initializer_experimental` | |
| **Option values**        | `true`                                       | Allow a blank line after the colon in a constructor initializer |
|                          | `false`                                      | Don't allow blank line after colon in constructor initializer |
| **Default option value** | `true`                                       |             |

## Example

```csharp
// csharp_style_allow_blank_line_after_colon_in_constructor_initializer_experimental = true
public Class() :
    base()
{
}
```

```csharp
// csharp_style_allow_blank_line_after_colon_in_constructor_initializer_experimental = false
public Class()
    : base()
{
}
```

## Suppress a warning

If you want to suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable IDE2004
// The code that's violating the rule is on this line.
#pragma warning restore IDE2004
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.IDE2004.severity = none
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
