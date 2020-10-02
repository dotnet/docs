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

The following table list all the code style rules by ID and options, if any.

> [!div class="mx-tdCol4BreakAll"]
> | Rule ID | Title | Option |
> | - | - | - | - |
> | [IDE0003](ide0003-ide0009.md) | Remove 'this' or 'Me' qualification | [dotnet_style_qualification_for_field](ide0003-ide0009.md#dotnet\_style\_qualification\_for_field)<br/> [dotnet_style_qualification_for_property](ide0003-ide0009.md#dotnet\_style\_qualification\_for_property)<br/> [dotnet_style_qualification_for_method](ide0003-ide0009.md#dotnet\_style\_qualification\_for_method)<br/> [dotnet_style_qualification_for_event](ide0003-ide0009.md#dotnet\_style\_qualification\_for_event) |
> | [IDE0009](ide0003-ide0009.md) | Add 'this' or 'Me' qualification | [dotnet_style_qualification_for_field](ide0003-ide0009.md#dotnet\_style\_qualification\_for_field)<br/> [dotnet_style_qualification_for_property](ide0003-ide0009.md#dotnet\_style\_qualification\_for_property)<br/> [dotnet_style_qualification_for_method](ide0003-ide0009.md#dotnet\_style\_qualification\_for_method)<br/> [dotnet_style_qualification_for_event](ide0003-ide0009.md#dotnet\_style\_qualification\_for_event) |
> | [IDE0017](ide0017.md) | Use object initializers | [dotnet_style_object_initializer](ide0017.md#dotnet\_style\_object_initializer) |
> | [IDE0028](ide0028.md) | Use collection initializers | [dotnet_style_collection_initializer](ide0028.md#dotnet\_style\_collection_initializer) |
> | [IDE0029](ide0029.md) | Use coalesce expression | [dotnet_style_coalesce_expression](ide0029.md#dotnet\_style\_coalesce\_expression) |
> | [IDE0031](ide0031.md) | Use null propagation | [dotnet_style_null_propagation](ide0031.md#dotnet\_style\_null\_propagation) |
> | [IDE0032](ide0032.md) | Use auto property | [dotnet_style_prefer_auto_properties](ide0032.md#dotnet\_style\_prefer\_auto\_properties) |
> | [IDE0033](ide0033.md) | Use explicitly provided tuple name | [dotnet_style_explicit_tuple_names](ide0033.md#dotnet\_style\_explicit\_tuple_names) |
> | [IDE0036](ide0036.md) | Order modifiers | [csharp_preferred_modifier_order](ide0036.md#csharp\_preferred\_modifier\_order)<br/> [visual_basic_preferred_modifier_order](ide0036.md#visual\_basic\_preferred\_modifier\_order)<br/> |
> | [IDE0037](ide0037.md) | Use inferred member name | [dotnet_style_prefer_inferred_tuple_names](ide0037.md#dotnet\_style\_prefer\_inferred\_tuple_names)<br/> [dotnet_style_prefer_inferred_anonymous_type_member_names](ide0037.md#dotnet\_style\_prefer\_inferred\_anonymous\_type\_member_names) |
> | [IDE0040](ide0040.md) | Add accessibility modifiers | [dotnet_style_require_accessibility_modifiers](ide0040.md#dotnet\_style\_require\_accessibility_modifiers) |
> | [IDE0041](ide0041.md) | Use is null check | [dotnet_style_prefer_is_null_check_over_reference_equality_method](ide0041.md#dotnet\_style\_prefer\_is\_null\_check\_over\_reference\_equality\_method) |
> | [IDE0044](ide0044.md) | Add readonly modifier | [dotnet_style_readonly_field](ide0044.md#dotnet\_style\_readonly\_field) |
> | [IDE0045](ide0045.md) | Use conditional expression for assignment | [dotnet_style_prefer_conditional_expression_over_assignment](ide0045.md#dotnet\_style\_prefer\_conditional\_expression\_over\_assignment) |
> | [IDE0046](ide0046.md) | Use conditional expression for return | [dotnet_style_prefer_conditional_expression_over_return](ide0046.md#dotnet\_style\_prefer\_conditional\_expression\_over\_return) |
> | [IDE0047](ide0047-ide0048.md) | Remove unnecessary parentheses | [dotnet_style_parentheses_in_arithmetic_binary_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_arithmetic\_binary_operators)<br/> [dotnet_style_parentheses_in_relational_binary_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_relational\_binary_operators)<br/> [dotnet_style_parentheses_in_other_binary_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_other\_binary_operators)<br/> [dotnet_style_parentheses_in_other_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_other_operators) |
> | [IDE0048](ide0047-ide0048.md) | Add parentheses for clarity | [dotnet_style_parentheses_in_arithmetic_binary_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_arithmetic\_binary_operators)<br/> [dotnet_style_parentheses_in_relational_binary_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_relational\_binary_operators)<br/> [dotnet_style_parentheses_in_other_binary_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_other\_binary_operators)<br/> [dotnet_style_parentheses_in_other_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_other_operators) |
> | [IDE0049](ide0049.md) | Use language keywords instead of framework type names for type references | [dotnet_style_predefined_type_for_locals_parameters_members](ide0049.md#dotnet\_style\_predefined\_type\_for\_locals\_parameters_members)<br/> [dotnet_style_predefined_type_for_member_access](ide0049.md#dotnet\_style\_predefined\_type\_for\_member_access)<br/> | Use language keywords instead of framework type names for type references |
> | [IDE0054](ide0054.md) | Use compound assignment | [dotnet_style_prefer_compound_assignment](ide0054.md#dotnet\_style\_prefer\_compound\_assignment) |
> | [IDE0058](ide0058.md) | Unused expression value | [csharp_style_unused_value_expression_statement_preference](ide0058.md#csharp\_style\_unused\_value\_expression\_statement_preference)<br/> [visual_basic_style_unused_value_expression_statement_preference](ide0058.md#visual\_basic\_style\_unused\_value\_expression\_statement_preference) |
> | [IDE0059](ide0059.md) | Unnecessary value assignment | [csharp_style_unused_value_assignment_preference](ide0059.md#csharp\_style\_unused\_value\_assignment\_preference)<br/> [visual_basic_style_unused_value_assignment_preference](ide0059.md#visual\_basic\_style\_unused\_value\_assignment\_preference) |
> | [IDE0060](ide0060.md) | Remove unused parameter | [dotnet_code_quality_unused_parameters](ide0060.md#dotnet\_code\_quality\_unused\_parameters) |

## Legend

The following table shows the type of information that is provided for each rule in the reference documentation.

|Item|Description|
|----------|-----------------|
| **Rule ID** |The unique identifier for the rule. The rule ID is used for configuring rule severity and suppressing warnings in the code file.|
| **Title** |The title for the rule.|
| **Category** | The category for the rule. |
| **Subcategory** | The sub-category for the rule, such as Language rules, Formatting rules or Naming rules. |
| **Applicable languages** |Applicable .NET languages (C# or Visual Basic), along with the minimum language version, if applicable.|
| **Introduced version** |Version of the .NET SDK or Visual Studio when the rule was first introduced.|

For each option for the rule, following information is provided.

|Item|Description|
|----------|-----------------|
| **Option name** |The code style option name for the rule, if any. Options for customizing style are specified in an EditorConfig file.|
| **Option values** |The code style option values for the rule option, if any.|
| **Default option value** |Default code style option value for the rule option, if any.
| **Examples** |Examples for the code style corresponding to the option.|

## See also

- [Enforce code style on build](../overview.md#code-style-analysis)
- [Quick Actions in Visual Studio](/visualstudio/ide/quick-actions)
- [Create portable custom editor options in Visual Studio](/visualstudio/ide/create-portable-custom-editor-options)
