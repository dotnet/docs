---
title: "IDE0041: Use 'is null' check"
description: "Learn about code analysis rule IDE0041: Use is null check"
ms.date: 02/13/2023
f1_keywords:
- IDE0041
- dotnet_style_prefer_is_null_check_over_reference_equality_method
helpviewer_keywords:
- IDE0041
- dotnet_style_prefer_is_null_check_over_reference_equality_method
author: gewarren
ms.author: gewarren
dev_langs:
- CSharp
- VB
---
# Use 'is null' check (IDE0041)

| Property                 | Value                                                              |
|--------------------------|--------------------------------------------------------------------|
| **Rule ID**              | IDE0041                                                            |
| **Title**                | Use 'is null' check                                                |
| **Category**             | Style                                                              |
| **Subcategory**          | Language rules (expression-level preferences)                      |
| **Applicable languages** | C# and Visual Basic                                                |
| **Introduced version**   | Visual Studio 2017                                                 |
| **Options**              | `dotnet_style_prefer_is_null_check_over_reference_equality_method` |

## Overview

This style rule concerns the use of a null check with pattern matching versus the use of the equality operator (`==`) or calling <xref:System.Object.ReferenceEquals(System.Object,System.Object)?displayProperty=nameWithType>.

## Options

Options specify the behavior that you want the rule to enforce. For information about configuring options, see [Option format](language-rules.md#option-format).

### dotnet_style_prefer_is_null_check_over_reference_equality_method

| Property                 | Value                                                            | Description                      |
| ------------------------ | ---------------------------------------------------------------- | -------------------------------- |
| **Option name**          | dotnet_style_prefer_is_null_check_over_reference_equality_method |                                  |
| **Option values**        | `true`                                                           | Prefer `is null` check           |
|                          | `false`                                                          | Prefer reference equality method |
| **Default option value** | `true`                                                           |                                  |

```csharp
// dotnet_style_prefer_is_null_check_over_reference_equality_method = true
if (value is null)
    return;

// dotnet_style_prefer_is_null_check_over_reference_equality_method = false
if (object.ReferenceEquals(value, null))
    return;

// dotnet_style_prefer_is_null_check_over_reference_equality_method = false
if ((object)o == null)
    return;
```

```vb
' dotnet_style_prefer_is_null_check_over_reference_equality_method = true
If value Is Nothing
    Return
End If

' dotnet_style_prefer_is_null_check_over_reference_equality_method = false
If Object.ReferenceEquals(value, Nothing)
    Return
End If

' dotnet_style_prefer_is_null_check_over_reference_equality_method = false
If CType(value, Object) = Nothing
    Return
End If
```

## Suppress a warning

If you want to suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable IDE0041
// The code that's violating the rule is on this line.
#pragma warning restore IDE0041
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.IDE0041.severity = none
```

To disable all of the code-style rules, set the severity for the category `Style` to `none` in the [configuration file](../configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_analyzer_diagnostic.category-Style.severity = none
```

For more information, see [How to suppress code analysis warnings](../suppress-warnings.md).

## See also

- [Code style language rules](language-rules.md)
- [Code style rules reference](index.md)
