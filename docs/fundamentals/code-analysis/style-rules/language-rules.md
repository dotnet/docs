---
title: Code style language rules
description: Learn about the different code style rules for using C# and Visual Basic language constructs.
ms.date: 06/22/2022
ms.topic: reference
author: gewarren
ms.author: gewarren
dev_langs:
- CSharp
- VB
helpviewer_keywords:
- language code style rules [EditorConfig]
- language rules
- EditorConfig language conventions
---
# Language rules

Code-style language rules affect how various constructs of .NET programming languages, for example, modifiers, and parentheses, are used. The rules fall into the following categories:

- [.NET style rules](#net-style-rules): Rules that apply to both C# and Visual Basic. The option names for these rules start with the prefix `dotnet_style_`.
- [C# style rules](#c-style-rules): Rules that are specific to C# code. The option names for these rules start with the prefix `csharp_style_`.
- [Visual Basic style rules](#visual-basic-style-rules): Rules that are specific to Visual Basic code. The option names for these rules start with the prefix `visual_basic_style_`.

## Option format

Options for language rules can be specified in a [configuration file](../configuration-files.md) with the following format:

`option_name = value` (Visual Studio 2019 version 16.9 and later)

or

`option_name = value:severity`

- **Value**

  For each language rule, you specify a value that defines if or when to prefer the style. Many rules accept a value of `true` (prefer this style) or `false` (do not prefer this style). Other rules accept values such as `when_on_single_line` or `never`.

- **Severity** (optional in Visual Studio 2019 version 16.9 and later versions)

  The second part of the rule specifies the [severity level](../configuration-options.md#severity-level) for the rule. When specified in this way, *the severity setting is only respected inside development IDEs, such as Visual Studio*. It is *not* respected during build.

  To enforce code style rules at build time, set the severity by using the rule ID-based severity configuration syntax for analyzers instead. The syntax takes the form `dotnet_diagnostic.<rule ID>.severity = <severity>`, for example, `dotnet_diagnostic.IDE0040.severity = none`. For more information, see [severity level](../configuration-options.md#severity-level).

> [!TIP]
>
> Starting in Visual Studio 2019 version 16.3, you can configure code style rules from the [Quick Actions](/visualstudio/ide/quick-actions) light bulb menu after a style violation occurs. For more information, see [Automatically configure code styles in Visual Studio](/visualstudio/ide/editorconfig-language-conventions#automatically-configure-code-styles-in-visual-studio).

## .NET style rules

The style rules in this section are applicable to both C# and Visual Basic.

- ['this.' and 'Me.' qualifiers](ide0003-ide0009.md)
- [Language keywords instead of framework type names for type references](ide0049.md)
- [Modifier preferences](modifier-preferences.md#net-modifier-preferences)
  - [Order modifiers (IDE0036)](ide0036.md)
  - [Add accessibility modifiers (IDE0040)](ide0040.md)
  - [Add readonly modifier (IDE0044)](ide0044.md)
- [Parentheses preferences](ide0047-ide0048.md)
- [Expression-level preferences](expression-level-preferences.md#net-expression-level-preferences)
  - [Use object initializers (IDE0017)](ide0017.md)
  - [Use collection initializers (IDE0028)](ide0028.md)
  - [Use auto-implemented property (IDE0032)](ide0032.md)
  - [Use explicitly provided tuple name (IDE0033)](ide0033.md)
  - [Use inferred member names (IDE0037)](ide0037.md)
  - [Use conditional expression for assignment (IDE0045)](ide0045.md)
  - [Use conditional expression for return (IDE0046)](ide0046.md)
  - [Use compound assignment (IDE0054 and IDE0074)](ide0054-ide0074.md)
  - [Simplify interpolation (IDE0071)](ide0071.md)
  - [Simplify conditional expression (IDE0075)](ide0075.md)
  - [Add missing cases to switch statement (IDE0010)](ide0010.md)
  - [Convert anonymous type to tuple (IDE0050)](ide0050.md)
  - [Use 'System.HashCode.Combine' (IDE0070)](ide0070.md)
  - [Convert `typeof` to `nameof` (IDE0082)](ide0082.md)
- [Null-checking preferences](null-checking-preferences.md#net-null-checking-preferences)
  - [Use coalesce expression (IDE0029 and IDE0030)](ide0029-ide0030.md)
  - [Use null propagation (IDE0031)](ide0031.md)
  - [Use 'is null' check (IDE0041)](ide0041.md)
- [File header preferences](ide0073.md)
- [Namespace naming preferences](ide0130.md)

## C# style rules

The style rules in this section are applicable to C# language only.

- ['var' preferences (IDE0007 and IDE0008)](ide0007-ide0008.md)
- [Expression-bodied members](expression-bodied-members.md)
  - [Use expression body for constructors (IDE0021)](ide0021.md)
  - [Use expression body for methods (IDE0022)](ide0022.md)
  - [Use expression body for operators (IDE0023 and IDE0024)](ide0023-ide0024.md)
  - [Use expression body for properties (IDE0025)](ide0025.md)
  - [Use expression body for indexers (IDE0026)](ide0026.md)
  - [Use expression body for accessors (IDE0027)](ide0027.md)
  - [Use expression body for lambdas (IDE0053)](ide0053.md)
  - [Use expression body for local functions (IDE0061)](ide0061.md)
- [Pattern matching preferences](pattern-matching-preferences.md)
  - [Use pattern matching to avoid 'as' followed by a 'null' check (IDE0019)](ide0019.md)
  - [Use pattern matching to avoid 'is' check followed by a cast (IDE0020 and IDE0038)](ide0020-ide0038.md)
  - [Use switch expression (IDE0066)](ide0066.md)
  - [Use pattern matching (IDE0078)](ide0078.md)
  - [Use pattern matching (`not` operator) (IDE0083)](ide0083.md)
  - [Simplify property pattern (IDE0170)](ide0170.md)
- [Expression-level preferences](expression-level-preferences.md#c-expression-level-preferences)
  - [Inline variable declaration (IDE0018)](ide0018.md)
  - [Simplify 'default' expression (IDE0034)](ide0034.md)
  - [Use local function instead of lambda (IDE0039)](ide0039.md)
  - [Deconstruct variable declaration (IDE0042)](ide0042.md)
  - [Use index operator (IDE0056)](ide0056.md)
  - [Use range operator (IDE0057)](ide0057.md)
  - [Simplify `new` expression (IDE0090)](ide0090.md)
  - [Add missing cases to switch expression (IDE0072)](ide0072.md)
  - [Use tuple to swap values (IDE0180)](ide0180.md)
- ["Null" checking preferences](null-checking-preferences.md#c-null-checking-preferences)
  - [Use throw expression (IDE0016)](ide0016.md)
  - [Use conditional delegate call (IDE1005)](ide1005.md)
  - [Prefer 'null' check over type check (IDE0150)](ide0150.md)
- [Code block preferences](code-block-preferences.md)
  - [Add braces (IDE0011)](ide0011.md)
  - [Use simple 'using' statement (IDE0063)](ide0063.md)
- ['using' directive preferences (IDE0065)](ide0065.md)
- [Modifier preferences](modifier-preferences.md#c-modifier-preferences)
  - [Make local function static (IDE0062)](ide0062.md)
  - [Make struct fields writable (IDE0064)](ide0064.md)
- [Namespace declaration preferences (IDE0160 and IDE0161)](ide0160-ide0161.md)

## Visual Basic style rules

The style rules in this section are applicable to Visual Basic language only.

- [Pattern matching preferences](pattern-matching-preferences.md)
  - [Use pattern matching (`IsNot` operator) (IDE0084)](ide0084.md)

## See also

- [Unnecessary code rules](unnecessary-code-rules.md)
- [Formatting rules](ide0055.md)
- [Naming rules](naming-rules.md)
- [.NET code style rules reference](index.md)
