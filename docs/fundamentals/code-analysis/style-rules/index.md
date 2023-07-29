---
title: Code-style rules overview
description: Learn about the different .NET code-style rules and categories.
ms.date: 07/22/2023
ms.topic: reference
author: gewarren
ms.author: gewarren
---
# Code-style rules

.NET code-style analysis provides rules that aim to maintain consistent *style* in your codebase. These rules have an "IDE" prefix in the rule ID.

The code-style rules are organized into the following subcategories:

- [Language and unnecessary code rules](language-rules.md)

  Rules that pertain to the C# or Visual Basic language. For example, you can specify rules that regard the use of `var` when defining variables, or whether expression-bodied members are preferred. This category also includes rules that find unnecessary code, for example, unreachable code within methods or unused private fields, properties, or methods.

- [Formatting rules](ide0055.md)

  Rules that pertain to the layout and structure of your code in order to make it easier to read. For example, you can specify a formatting option that defines whether spaces in control blocks are preferred or not.

- [Naming rules](naming-rules.md)

  Rules that pertain to the naming of code elements. For example, you can specify that `async` method names must have an "Async" suffix.

- [Miscellaneous rules](miscellaneous-rules.md)

  Rules that do not belong in other categories.

## Index

The following table list all the code-style rules by ID and [options](../code-style-rule-options.md), if any.

> [!div class="mx-tdCol3BreakAll"]
> | Rule ID | Title | Option |
> | - | - | - |
> | [IDE0001](ide0001.md) | Simplify name | |
> | [IDE0002](ide0002.md) | Simplify member access | |
> | [IDE0003](ide0003-ide0009.md) | Remove `this` or `Me` qualification | [dotnet_style_qualification_for_field](ide0003-ide0009.md#dotnet_style_qualification_for_field)<br/> [dotnet_style_qualification_for_property](ide0003-ide0009.md#dotnet_style_qualification_for_property)<br/> [dotnet_style_qualification_for_method](ide0003-ide0009.md#dotnet_style_qualification_for_method)<br/> [dotnet_style_qualification_for_event](ide0003-ide0009.md#dotnet_style_qualification_for_event) |
> | [IDE0004](ide0004.md) | Remove unnecessary cast | |
> | [IDE0005](ide0005.md) | Remove unnecessary import | |
> | [IDE0007](ide0007-ide0008.md) | Use `var` instead of explicit type | [csharp_style_var_for_built_in_types](ide0007-ide0008.md#csharp_style_var_for_built_in_types)<br/> [csharp_style_var_when_type_is_apparent](ide0007-ide0008.md#csharp_style_var_when_type_is_apparent)<br/> [csharp_style_var_elsewhere](ide0007-ide0008.md#csharp_style_var_elsewhere)<br/> |
> | [IDE0008](ide0007-ide0008.md) | Use explicit type instead of `var` | [csharp_style_var_for_built_in_types](ide0007-ide0008.md#csharp_style_var_for_built_in_types)<br/> [csharp_style_var_when_type_is_apparent](ide0007-ide0008.md#csharp_style_var_when_type_is_apparent)<br/> [csharp_style_var_elsewhere](ide0007-ide0008.md#csharp_style_var_elsewhere)<br/> |
> | [IDE0009](ide0003-ide0009.md) | Add `this` or `Me` qualification | [dotnet_style_qualification_for_field](ide0003-ide0009.md#dotnet_style_qualification_for_field)<br/> [dotnet_style_qualification_for_property](ide0003-ide0009.md#dotnet_style_qualification_for_property)<br/> [dotnet_style_qualification_for_method](ide0003-ide0009.md#dotnet_style_qualification_for_method)<br/> [dotnet_style_qualification_for_event](ide0003-ide0009.md#dotnet_style_qualification_for_event) |
> | [IDE0010](ide0010.md) | Add missing cases to switch statement | |
> | [IDE0011](ide0011.md) | Add braces | [csharp_prefer_braces](ide0011.md#csharp_prefer_braces) |
> | [IDE0016](ide0016.md) | Use throw expression | [csharp_style_throw_expression](ide0016.md#csharp_style_throw_expression) |
> | [IDE0017](ide0017.md) | Use object initializers | [dotnet_style_object_initializer](ide0017.md#dotnet_style_object_initializer) |
> | [IDE0018](ide0018.md) | Inline variable declaration | [csharp_style_inlined_variable_declaration](ide0018.md#csharp_style_inlined_variable_declaration) |
> | [IDE0019](ide0019.md) | Use pattern matching to avoid `as` followed by a `null` check | [csharp_style_pattern_matching_over_as_with_null_check](ide0019.md#csharp_style_pattern_matching_over_as_with_null_check) |
> | [IDE0020](ide0020-ide0038.md) | Use pattern matching to avoid `is` check followed by a cast (with variable) | [csharp_style_pattern_matching_over_is_with_cast_check](ide0020-ide0038.md#csharp_style_pattern_matching_over_is_with_cast_check) |
> | [IDE0021](ide0021.md) | Use expression body for constructors | [csharp_style_expression_bodied_constructors](ide0021.md#csharp_style_expression_bodied_constructors) |
> | [IDE0022](ide0022.md) | Use expression body for methods | [csharp_style_expression_bodied_methods](ide0022.md#csharp_style_expression_bodied_methods) |
> | [IDE0023](ide0023-ide0024.md) | Use expression body for conversion operators | [csharp_style_expression_bodied_operators](ide0023-ide0024.md#csharp_style_expression_bodied_operators) |
> | [IDE0024](ide0023-ide0024.md) | Use expression body for operators | [csharp_style_expression_bodied_operators](ide0023-ide0024.md#csharp_style_expression_bodied_operators) |
> | [IDE0025](ide0025.md) | Use expression body for properties | [csharp_style_expression_bodied_properties](ide0025.md#csharp_style_expression_bodied_properties) |
> | [IDE0026](ide0026.md) | Use expression body for indexers | [csharp_style_expression_bodied_indexers](ide0026.md#csharp_style_expression_bodied_indexers) |
> | [IDE0027](ide0027.md) | Use expression body for accessors | [csharp_style_expression_bodied_accessors](ide0027.md#csharp_style_expression_bodied_accessors) |
> | [IDE0028](ide0028.md) | Use collection initializers | [dotnet_style_collection_initializer](ide0028.md#dotnet_style_collection_initializer) |
> | [IDE0029](ide0029-ide0030-ide0270.md) | Null check can be simplified | [dotnet_style_coalesce_expression](ide0029-ide0030-ide0270.md#dotnet_style_coalesce_expression) |
> | [IDE0030](ide0029-ide0030-ide0270.md) | Null check can be simplified | [dotnet_style_coalesce_expression](ide0029-ide0030-ide0270.md#dotnet_style_coalesce_expression) |
> | [IDE0031](ide0031.md) | Use null propagation | [dotnet_style_null_propagation](ide0031.md#dotnet_style_null_propagation) |
> | [IDE0032](ide0032.md) | Use auto property | [dotnet_style_prefer_auto_properties](ide0032.md#dotnet_style_prefer_auto_properties) |
> | [IDE0033](ide0033.md) | Use explicitly provided tuple name | [dotnet_style_explicit_tuple_names](ide0033.md#dotnet_style_explicit_tuple_names) |
> | [IDE0034](ide0034.md) | Simplify `default` expression | [csharp_prefer_simple_default_expression](ide0034.md#csharp_prefer_simple_default_expression) |
> | [IDE0035](ide0035.md) | Remove unreachable code | |
> | [IDE0036](ide0036.md) | Order modifiers | [csharp_preferred_modifier_order](ide0036.md#csharp_preferred_modifier_order)<br/> [visual_basic_preferred_modifier_order](ide0036.md#visual_basic_preferred_modifier_order)<br/> |
> | [IDE0037](ide0037.md) | Use inferred member name | [dotnet_style_prefer_inferred_tuple_names](ide0037.md#dotnet_style_prefer_inferred_tuple_names)<br/> [dotnet_style_prefer_inferred_anonymous_type_member_names](ide0037.md#dotnet_style_prefer_inferred_anonymous_type_member_names) |
> | [IDE0038](ide0020-ide0038.md) | Use pattern matching to avoid `is` check followed by a cast (without variable) | [csharp_style_pattern_matching_over_is_with_cast_check](ide0020-ide0038.md#csharp_style_pattern_matching_over_is_with_cast_check) |
> | [IDE0039](ide0039.md) | Use local function instead of lambda | [csharp_style_prefer_local_over_anonymous_function](ide0039.md#csharp_style_prefer_local_over_anonymous_function) |
> | [IDE0040](ide0040.md) | Add accessibility modifiers | [dotnet_style_require_accessibility_modifiers](ide0040.md#dotnet_style_require_accessibility_modifiers) |
> | [IDE0041](ide0041.md) | Use is null check | [dotnet_style_prefer_is_null_check_over_reference_equality_method](ide0041.md#dotnet_style_prefer_is_null_check_over_reference_equality_method) |
> | [IDE0042](ide0042.md) | Deconstruct variable declaration | [csharp_style_deconstructed_variable_declaration](ide0042.md#csharp_style_deconstructed_variable_declaration) |
> | [IDE0044](ide0044.md) | Add readonly modifier | [dotnet_style_readonly_field](ide0044.md#dotnet_style_readonly_field) |
> | [IDE0045](ide0045.md) | Use conditional expression for assignment | [dotnet_style_prefer_conditional_expression_over_assignment](ide0045.md#dotnet_style_prefer_conditional_expression_over_assignment) |
> | [IDE0046](ide0046.md) | Use conditional expression for return | [dotnet_style_prefer_conditional_expression_over_return](ide0046.md#dotnet_style_prefer_conditional_expression_over_return) |
> | [IDE0047](ide0047-ide0048.md) | Remove unnecessary parentheses | [dotnet_style_parentheses_in_arithmetic_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_arithmetic_binary_operators)<br/> [dotnet_style_parentheses_in_relational_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_relational_binary_operators)<br/> [dotnet_style_parentheses_in_other_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_other_binary_operators)<br/> [dotnet_style_parentheses_in_other_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_other_operators) |
> | [IDE0048](ide0047-ide0048.md) | Add parentheses for clarity | [dotnet_style_parentheses_in_arithmetic_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_arithmetic_binary_operators)<br/> [dotnet_style_parentheses_in_relational_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_relational_binary_operators)<br/> [dotnet_style_parentheses_in_other_binary_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_other_binary_operators)<br/> [dotnet_style_parentheses_in_other_operators](ide0047-ide0048.md#dotnet_style_parentheses_in_other_operators) |
> | [IDE0049](ide0049.md) | Use language keywords instead of framework type names for type references | [dotnet_style_predefined_type_for_locals_parameters_members](ide0049.md#dotnet_style_predefined_type_for_locals_parameters_members)<br/> [dotnet_style_predefined_type_for_member_access](ide0049.md#dotnet_style_predefined_type_for_member_access)<br/> |
> | [IDE0050](ide0050.md) | Convert anonymous type to tuple | |
> | [IDE0051](ide0051.md) | Remove unused private member | |
> | [IDE0052](ide0052.md) | Remove unread private member | |
> | [IDE0053](ide0053.md) | Use expression body for lambdas | [csharp_style_expression_bodied_lambdas](ide0053.md#csharp_style_expression_bodied_lambdas) |
> | [IDE0054](ide0054-ide0074.md) | Use compound assignment | [dotnet_style_prefer_compound_assignment](ide0054-ide0074.md#dotnet_style_prefer_compound_assignment) |
> | [IDE0055](ide0055.md) | Fix formatting | (Too many to list here. See [.NET formatting options](dotnet-formatting-options.md) and [C# formatting options](csharp-formatting-options.md).) |
> | [IDE0056](ide0056.md) | Use index operator | [csharp_style_prefer_index_operator](ide0056.md#csharp_style_prefer_index_operator) |
> | [IDE0057](ide0057.md) | Use range operator | [csharp_style_prefer_range_operator](ide0057.md#csharp_style_prefer_range_operator) |
> | [IDE0058](ide0058.md) | Remove unused expression value | [csharp_style_unused_value_expression_statement_preference](ide0058.md#csharp_style_unused_value_expression_statement_preference)<br/> [visual_basic_style_unused_value_expression_statement_preference](ide0058.md#visual_basic_style_unused_value_expression_statement_preference) |
> | [IDE0059](ide0059.md) | Remove unnecessary value assignment | [csharp_style_unused_value_assignment_preference](ide0059.md#csharp_style_unused_value_assignment_preference)<br/> [visual_basic_style_unused_value_assignment_preference](ide0059.md#visual_basic_style_unused_value_assignment_preference) |
> | [IDE0060](ide0060.md) | Remove unused parameter | [dotnet_code_quality_unused_parameters](ide0060.md#dotnet_code_quality_unused_parameters) |
> | [IDE0061](ide0061.md) | Use expression body for local functions | [csharp_style_expression_bodied_local_functions](ide0061.md#csharp_style_expression_bodied_local_functions) |
> | [IDE0062](ide0062.md) | Make local function static | [csharp_prefer_static_local_function](ide0062.md#csharp_prefer_static_local_function) |
> | [IDE0063](ide0063.md) | Use simple `using` statement | [csharp_prefer_simple_using_statement](ide0063.md#csharp_prefer_simple_using_statement) |
> | [IDE0064](ide0064.md) | Make struct fields writable | |
> | [IDE0065](ide0065.md) | `using` directive placement | [csharp_using_directive_placement](ide0065.md#csharp_using_directive_placement) |
> | [IDE0066](ide0066.md) | Use switch expression | [csharp_style_prefer_switch_expression](ide0066.md#csharp_style_prefer_switch_expression) |
> | [IDE0070](ide0070.md) | Use <xref:System.HashCode.Combine%2A?displayProperty=fullName> | |
> | [IDE0071](ide0071.md) | Simplify interpolation | [dotnet_style_prefer_simplified_interpolation](ide0071.md#dotnet_style_prefer_simplified_interpolation) |
> | [IDE0072](ide0072.md) | Add missing cases to switch expression | |
> | [IDE0073](ide0073.md) | Use file header | [file_header_template](ide0073.md#file_header_template) |
> | [IDE0074](ide0054-ide0074.md) | Use coalesce compound assignment | [dotnet_style_prefer_compound_assignment](ide0054-ide0074.md#dotnet_style_prefer_compound_assignment) |
> | [IDE0075](ide0075.md) | Simplify conditional expression | [dotnet_style_prefer_simplified_boolean_expressions](ide0075.md#dotnet_style_prefer_simplified_boolean_expressions) |
> | [IDE0076](ide0076.md) | Remove invalid global `SuppressMessageAttribute` | |
> | [IDE0077](ide0077.md) | Avoid legacy format target in global `SuppressMessageAttribute` | |
> | [IDE0078](ide0078-ide0260.md) | Use pattern matching | [csharp_style_prefer_pattern_matching](ide0078-ide0260.md#csharp_style_prefer_pattern_matching-ide0078) |
> | [IDE0079](ide0079.md) | Remove unnecessary suppression | [dotnet_remove_unnecessary_suppression_exclusions](ide0079.md#dotnet_remove_unnecessary_suppression_exclusions) |
> | [IDE0080](ide0080.md) | Remove unnecessary suppression operator | |
> | [IDE0081](ide0081.md) | Remove `ByVal` | |
> | [IDE0082](ide0082.md) | Convert `typeof` to `nameof` | |
> | [IDE0083](ide0083.md) | Use pattern matching (`not` operator) | [csharp_style_prefer_not_pattern](ide0083.md#csharp_style_prefer_not_pattern) |
> | [IDE0084](ide0084.md) | Use pattern matching (`IsNot` operator) | [visual_basic_style_prefer_isnot_expression](ide0084.md#visual_basic_style_prefer_isnot_expression) |
> | [IDE0090](ide0090.md) | Simplify `new` expression | [csharp_style_implicit_object_creation_when_type_is_apparent](ide0090.md#csharp_style_implicit_object_creation_when_type_is_apparent) |
> | [IDE0100](ide0100.md) | Remove unnecessary equality operator | |
> | [IDE0110](ide0110.md) | Remove unnecessary discard | |
> | [IDE0120](ide0120.md) | Simplify LINQ expression | |
> | [IDE0130](ide0130.md) | Namespace does not match folder structure | [dotnet_style_namespace_match_folder](ide0130.md#dotnet_style_namespace_match_folder) |
> | [IDE0140](ide0140.md) | Simplify object creation | [visual_basic_style_prefer_simplified_object_creation](ide0140.md#visual_basic_style_prefer_simplified_object_creation) |
> | [IDE0150](ide0150.md) | Prefer `null` check over type check | [csharp_style_prefer_null_check_over_type_check](ide0150.md#csharp_style_prefer_null_check_over_type_check) |
> | [IDE0160](ide0160-ide0161.md) | Use block-scoped namespace | [csharp_style_namespace_declarations](ide0160-ide0161.md#csharp_style_namespace_declarations) |
> | [IDE0161](ide0160-ide0161.md) | Use file-scoped namespace | [csharp_style_namespace_declarations](ide0160-ide0161.md#csharp_style_namespace_declarations) |
> | [IDE0170](ide0170.md) | Simplify property pattern | [csharp_style_prefer_extended_property_pattern](ide0170.md#csharp_style_prefer_extended_property_pattern) |
> | [IDE0180](ide0180.md) | Use tuple to swap values | [csharp_style_prefer_tuple_swap](ide0180.md#csharp_style_prefer_tuple_swap) |
> | [IDE0200](ide0200.md) | Remove unnecessary lambda expression | [csharp_style_prefer_method_group_conversion](ide0200.md#csharp_style_prefer_method_group_conversion) |
> | [IDE0210](ide0210.md) | Convert to top-level statements | [csharp_style_prefer_top_level_statements](ide0210.md#csharp_style_prefer_top_level_statements) |
> | [IDE0211](ide0211.md) | Convert to 'Program.Main' style program | [csharp_style_prefer_top_level_statements](ide0211.md#csharp_style_prefer_top_level_statements) |
> | [IDE0220](ide0220.md) | Add explicit cast in foreach loop | [dotnet_style_prefer_foreach_explicit_cast_in_source](ide0220.md#dotnet_style_prefer_foreach_explicit_cast_in_source) |
> | [IDE0230](ide0230.md) | Use UTF-8 string literal | [csharp_style_prefer_utf8_string_literals](ide0230.md#csharp_style_prefer_utf8_string_literals) |
> | [IDE0240](ide0240.md) | Nullable directive is redundant | |
> | [IDE0241](ide0241.md) | Nullable directive is unnecessary | |
> | [IDE0250](ide0250.md) | Struct can be made 'readonly' | [csharp_style_prefer_readonly_struct](ide0250.md#csharp_style_prefer_readonly_struct) |
> | [IDE0251](ide0251.md) | Member can be made 'readonly' | [csharp_style_prefer_readonly_struct_member](ide0251.md#csharp_style_prefer_readonly_struct_member) |
> | [IDE0260](ide0078-ide0260.md) | Use pattern matching | [csharp_style_pattern_matching_over_as_with_null_check](ide0078-ide0260.md#csharp_style_pattern_matching_over_as_with_null_check-ide0260) |
> | [IDE0270](ide0029-ide0030-ide0270.md) | Null check can be simplified | [dotnet_style_coalesce_expression](ide0029-ide0030-ide0270.md#dotnet_style_coalesce_expression) |
> | [IDE1005](ide1005.md) | Use conditional delegate call | [csharp_style_conditional_delegate_call](ide1005.md#csharp_style_conditional_delegate_call) |
> | [IDE1006](naming-rules.md) | Naming styles | |

## Legend

The following table shows the type of information that's provided for each rule in the reference documentation.

| Item                     | Description                                                                                                       |
|--------------------------|-------------------------------------------------------------------------------------------------------------------|
| **Rule ID**              | The unique identifier for the rule. Used for configuring rule severity and suppressing warnings in the code file. |
| **Title**                | The title for the rule.                                                                                           |
| **Category**             | The category for the rule.                                                                                        |
| **Subcategory**          | The subcategory for the rule, such as Language rules, Formatting rules, or Naming rules.                          |
| **Applicable languages** | Applicable .NET languages (C# or Visual Basic), along with the minimum language version, if applicable.           |
| **Introduced version**   | Version of the .NET SDK or Visual Studio when the rule was first introduced.                                      |
| **Options**              | Any available options for the rule.                                                                               |

## See also

- [Enforce code style on build](../overview.md#code-style-analysis)
- [Quick Actions in Visual Studio](/visualstudio/ide/quick-actions)
- [Create portable custom editor options in Visual Studio](/visualstudio/ide/create-portable-custom-editor-options)
