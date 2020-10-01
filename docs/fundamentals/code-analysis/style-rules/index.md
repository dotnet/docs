---
title: Code style rules overview
description: Learn about the different .NET code style rules and categories.
ms.date: 09/25/2020
ms.topic: reference
author: gewarren
ms.author: gewarren
---
# Code style rules

.NET code style analysis provides rules that aim to maintain consistent *code style* in your codebase. These rules have an "IDE" prefix in the rule ID. Most of the rules have associated options to customize the preferred style. The rules are organized into the following subcategories:

- [Language rules](language-rules.md)

   Rules that pertain to the C# or Visual Basic language. For example, you can specify rules that regard the use of `var` when defining variables, or whether expression-bodied members are preferred.

- [Formatting rules](formatting-rules.md)

   Rules that pertain to the layout and structure of your code in order to make it easier to read. For example, you can specify rules that regard Allman braces, or whether spaces in control blocks are preferred.

- [Naming rules](naming-rules.md)

   Rules that pertain to the naming of code elements. For example, you can specify that `async` method names must have an "Async" suffix.

## Index

The following table list all the code style rules by ID and option(s), if any.

> [!div class="mx-tdCol4BreakAll"]
> | Rule ID | Title | Option | Option Group |
> | - | - | - | - |
> | [IDE0003](ide0003-ide0009.md) | Remove 'this' or 'Me' qualification | [dotnet_style_qualification_for_field](ide0003-ide0009.md#dotnet\_style\_qualification\_for_field)<br/> [dotnet_style_qualification_for_property](ide0003-ide0009.md#dotnet\_style\_qualification\_for_property)<br/> [dotnet_style_qualification_for_method](ide0003-ide0009.md#dotnet\_style\_qualification\_for_method)<br/> [dotnet_style_qualification_for_event](ide0003-ide0009.md#dotnet\_style\_qualification\_for_event) | 'this.' and 'Me.' qualifiers
> | [IDE0009](ide0003-ide0009.md) | Add 'this' or 'Me' qualification | [dotnet_style_qualification_for_field](ide0003-ide0009.md#dotnet\_style\_qualification\_for_field)<br/> [dotnet_style_qualification_for_property](ide0003-ide0009.md#dotnet\_style\_qualification\_for_property)<br/> [dotnet_style_qualification_for_method](ide0003-ide0009.md#dotnet\_style\_qualification\_for_method)<br/> [dotnet_style_qualification_for_event](ide0003-ide0009.md#dotnet\_style\_qualification\_for_event) | 'this.' and 'Me.' qualifiers
> | [IDE0049](ide0049.md) | Use language keywords instead of framework type names for type references | [dotnet_style_predefined_type_for_locals_parameters_members](ide0049.md#dotnet\_style\_predefined\_type\_for\_locals\_parameters_members)<br/> [dotnet_style_predefined_type_for_member_access](ide0049.md#dotnet\_style\_predefined\_type\_for\_member_access)<br/> | Use language keywords instead of framework type names for type references

## Legend

The following table shows the type of information that is provided for each rule in the reference documentation.

|Item|Description|
|----------|-----------------|
| **Rule ID** |The unique identifier for the rule. The rule ID is used for configuring rule severity and suppressing warnings in the code file.|
| **Option name** |The code style option name for the rule, if any. Options for customizing style are specified in an EditorConfig file.|
| **Option values** |The code style option values for the rule option, if any.|
| **Default option value** |Default code style option value for the rule option, if any.
| **Category** | The category for the rule. |
| **Subcategory** | The sub-category for the rule, such as Language rules, Formatting rules or Naming rules. |
| **Applicable languages** |Applicable .NET languages (C# or Visual Basic), along with the minimum language version, if applicable.|
| **Introduced version** |Version of the .NET SDK or Visual Studio when the rule was first introduced.|
| **Examples** |Examples for different code styles corresponding to the rule.|

## See also

- [Enforce code style on build](../overview.md#code-style-analysis)
- [Quick Actions in Visual Studio](/visualstudio/ide/quick-actions)
- [Create portable custom editor options in Visual Studio](/visualstudio/ide/create-portable-custom-editor-options)
