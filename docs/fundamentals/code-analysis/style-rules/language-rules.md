---
title: Code style language rules
description: Learn about the different code style rules for using C# and Visual Basic language constructs.
ms.date: 09/25/2020
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

Code style language rules affect how various constructs of .NET programming languages, for example, modifiers and parentheses, are used. The rules fall into the following categories:

- [.NET style rules](#net-style-rules): Rules that apply to both C# and Visual Basic. The EditorConfig option names for these rules start with `dotnet_style_` prefix.
- [C# style rules](#c-style-rules): Rules that are specific to C# language only. The EditorConfig option names for these rules start with `csharp_style_` prefix.
- [Visual Basic style rules](#visual-basic-style-rules): Rules that are specific to Visual Bsic language only. The EditorConfig option names for these rules start with `visual_basic_style_` prefix.

## Option format

Options for language rules can be specified in an EditorConfig file with the following format:

`option_name = value` (Visual Studio 2019 version 16.9 Preview 2 and later)

or

`option_name = value:severity`

- **Value**

  For each language rule, you specify a value that defines if or when to prefer the style. Many rules accept a value of `true` (prefer this style) or `false` (do not prefer this style). Other rules accept values such as `when_on_single_line` or `never`.

- **Severity** (optional in Visual Studio 2019 version 16.9 Preview 2 and later versions)

  The second part of the rule specifies the [severity level](../configuration-options.md#severity-level) for the rule. When specified in this way, the severity setting is only respected inside development IDEs, such as Visual Studio. It is *not* respected during build.

  To enforce code style rules at build time, set the severity by using the rule ID-based severity configuration syntax for analyzers instead. The syntax takes the form `dotnet_diagnostic.<rule ID>.severity = <severity>`, for example, `dotnet_diagnostic.IDE0040.severity = silent`. For more information, see [severity level](../configuration-options.md#severity-level).

> [!TIP]
>
> Starting in Visual Studio 2019 version 16.3, you can configure code style rules from the [Quick Actions](/visualstudio/ide/quick-actions) light bulb menu after a style violation occurs. For more information, see [Automatically configure code styles in Visual Studio](/visualstudio/ide/editorconfig-language-conventions#automatically-configure-code-styles-in-visual-studio).

## .NET style rules

The style rules in this section are applicable to both C# and Visual Basic.

- ['this.' and 'Me.' qualifiers](ide0003-ide0009.md)
  - [dotnet_style_qualification_for_field](ide0003-ide0009.md#dotnet_style_qualification_for_field)
  - [dotnet_style_qualification_for_property](ide0003-ide0009.md#dotnet_style_qualification_for_property)
  - [dotnet_style_qualification_for_method](ide0003-ide0009.md#dotnet_style_qualification_for_method)
  - [dotnet_style_qualification_for_event](ide0003-ide0009.md#dotnet_style_qualification_for_event)
- [Language keywords instead of framework type names for type references](ide0049.md)
  - [dotnet_style_predefined_type_for_locals_parameters_members](ide0049.md#dotnet_style_predefined_type_for_locals_parameters_members)
  - [dotnet_style_predefined_type_for_member_access](ide0049.md#dotnet_style_predefined_type_for_member_access)
- [Modifier preferences](modifier-preferences.md#net-modifier-preferences)
  - [csharp_preferred_modifier_order](ide0036.md#csharp_preferred_modifier_order)
  - [visual_basic_preferred_modifier_order](ide0036.md#visual_basic_preferred_modifier_order)
  - [dotnet_style_require_accessibility_modifiers](ide0040.md#dotnet_style_require_accessibility_modifiers)
  - [dotnet_style_readonly_field](ide0044.md#dotnet_style_readonly_field)
- [Parentheses preferences](ide0047-ide0048.md)
  - [dotnet_style_parentheses_in_arithmetic_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_arithmetic_binary_operators)
  - [dotnet_style_parentheses_in_relational_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_relational_binary_operators)
  - [dotnet_style_parentheses_in_other_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_other_binary_operators)
  - [dotnet_style_parentheses_in_other_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_other_operators)
- [Expression-level preferences](expression-level-preferences.md#net-expression-level-preferences)
  - [dotnet_style_object_initializer](ide0017.md#dotnet_style_object_initializer)
  - [dotnet_style_collection_initializer](ide0028.md#dotnet_style_collection_initializer)
  - [dotnet_style_prefer_auto_properties](ide0032.md#dotnet_style_prefer_auto_properties)
  - [dotnet_style_explicit_tuple_names](ide0033.md#dotnet_style_explicit_tuple_names)
  - [dotnet_style_prefer_inferred_tuple_names](ide0037.md#dotnet_style_prefer_inferred_tuple_names)
  - [dotnet_style_prefer_inferred_anonymous_type_member_names](ide0037.md#dotnet_style_prefer_inferred_anonymous_type_member_names)
  - [dotnet_style_prefer_conditional_expression_over_assignment](ide0045.md#dotnet_style_prefer_conditional_expression_over_assignment)
  - [dotnet_style_prefer_conditional_expression_over_return](ide0046.md#dotnet_style_prefer_conditional_expression_over_return)
  - [dotnet_style_prefer_compound_assignment](ide0054-ide0074.md#dotnet_style_prefer_compound_assignment)
  - [dotnet_style_prefer_simplified_interpolation](ide0071.md#dotnet_style_prefer_simplified_interpolation)
  - [dotnet_style_prefer_simplified_boolean_expressions](ide0075.md#dotnet_style_prefer_simplified_boolean_expressions)
  - [Add missing cases to switch statement](ide0010.md) - This rule has no code style option.
  - [Convert anonymous type to tuple](ide0050.md) - This rule has no code style option.
  - [Use 'System.HashCode.Combine'](ide0070.md) - This rule has no code style option.
  - [Convert 'typeof' to 'nameof'](ide0082.md) - This rule has no code style option.
- [Null-checking preferences](null-checking-preferences.md#net-null-checking-preferences)
  - [dotnet_style_coalesce_expression](ide0029-ide0030.md#dotnet_style_coalesce_expression)
  - [dotnet_style_null_propagation](ide0031.md#dotnet_style_null_propagation)
  - [dotnet_style_prefer_is_null_check_over_reference_equality_method](ide0041.md#dotnet_style_prefer_is_null_check_over_reference_equality_method)
- [File header preferences](ide0073.md)
  - [file_header_template](ide0073.md#file_header_template)

## C# style rules

The style rules in this section are applicable to C# language only.

- ['var' preferences](ide0007-ide0008.md)
  - [csharp_style_var_for_built_in_types](ide0007-ide0008.md#csharp_style_var_for_built_in_types)
  - [csharp_style_var_when_type_is_apparent](ide0007-ide0008.md#csharp_style_var_when_type_is_apparent)
  - [csharp_style_var_elsewhere](ide0007-ide0008.md#csharp_style_var_elsewhere)
- [Expression-bodied members](expression-bodied-members.md)
  - [csharp_style_expression_bodied_constructors](ide0021.md#csharp_style_expression_bodied_constructors)
  - [csharp_style_expression_bodied_methods](ide0022.md#csharp_style_expression_bodied_methods)
  - [csharp_style_expression_bodied_operators](ide0023-ide0024.md#csharp_style_expression_bodied_operators)
  - [csharp_style_expression_bodied_properties](ide0025.md#csharp_style_expression_bodied_properties)
  - [csharp_style_expression_bodied_indexers](ide0026.md#csharp_style_expression_bodied_indexers)
  - [csharp_style_expression_bodied_accessors](ide0027.md#csharp_style_expression_bodied_accessors)
  - [csharp_style_expression_bodied_lambdas](ide0053.md#csharp_style_expression_bodied_lambdas)
  - [csharp_style_expression_bodied_local_functions](ide0061.md#csharp_style_expression_bodied_local_functions)
- [Pattern matching preferences](pattern-matching-preferences.md)
  - [csharp_style_pattern_matching_over_as_with_null_check](ide0019.md#csharp_style_pattern_matching_over_as_with_null_check)
  - [csharp_style_pattern_matching_over_is_with_cast_check](ide0020-ide0038.md#csharp_style_pattern_matching_over_is_with_cast_check)
  - [csharp_style_prefer_switch_expression](ide0066.md#csharp_style_prefer_switch_expression)
  - [csharp_style_prefer_pattern_matching](ide0078.md#csharp_style_prefer_pattern_matching)
  - [csharp_style_prefer_not_pattern](ide0083.md#csharp_style_prefer_not_pattern)
- [Expression-level preferences](expression-level-preferences.md#c-expression-level-preferences)
  - [csharp_style_inlined_variable_declaration](ide0018.md#csharp_style_inlined_variable_declaration)
  - [csharp_prefer_simple_default_expression](ide0034.md#csharp_prefer_simple_default_expression)
  - [csharp_style_pattern_local_over_anonymous_function](ide0039.md#csharp_style_pattern_local_over_anonymous_function)
  - [csharp_style_deconstructed_variable_declaration](ide0042.md#csharp_style_deconstructed_variable_declaration)
  - [csharp_style_prefer_index_operator](ide0056.md#csharp_style_prefer_index_operator)
  - [csharp_style_prefer_range_operator](ide0057.md#csharp_style_prefer_range_operator)
  - [csharp_style_implicit_object_creation_when_type_is_apparent](ide0090.md#csharp_style_implicit_object_creation_when_type_is_apparent)
  - [Add missing cases to switch expression](ide0072.md) - This rule has no code style option.
- ["Null" checking preferences](null-checking-preferences.md#c-null-checking-preferences)
  - [csharp_style_throw_expression](ide0016.md#csharp_style_throw_expression)
  - [csharp_style_conditional_delegate_call](ide1005.md#csharp_style_conditional_delegate_call)
- [Code block preferences](code-block-preferences.md)
  - [csharp_prefer_braces](ide0011.md#csharp_prefer_braces)
  - [csharp_prefer_simple_using_statement](ide0063.md#csharp_prefer_simple_using_statement)
- ['using' directive preferences](ide0065.md)
  - [csharp_using_directive_placement](ide0065.md#csharp_using_directive_placement)
- [Modifier preferences](modifier-preferences.md#c-modifier-preferences)
  - [csharp_prefer_static_local_function](ide0062.md#csharp_prefer_static_local_function)
  - [Make struct fields writable](ide0064.md) - This rule has no code style option.

## Visual Basic style rules

The style rules in this section are applicable to Visual Basic language only.

- [Pattern matching preferences](pattern-matching-preferences.md)
  - [visual_basic_style_prefer_isnot_expression](ide0084.md#visual_basic_style_prefer_isnot_expression)

## See also

- [Unnecessary code rules](unnecessary-code-rules.md)
- [Formatting rules](formatting-rules.md)
- [Naming rules](naming-rules.md)
- [.NET code style rules reference](index.md)
