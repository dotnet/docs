---
title: Code-style naming rules
description: Learn about the .NET code-style rules for naming code elements.
ms.date: 09/12/2021
ms.topic: reference
author: gewarren
ms.author: gewarren
dev_langs:
- CSharp
- VB
f1_keywords:
- IDE1006
- naming rules
helpviewer_keywords:
- IDE1006
- naming code style rules [EditorConfig]
- naming rules
- EditorConfig naming conventions
---
# Code-style naming rules

In your `.editorconfig` file, you can define **naming rules** that specify and enforce how .NET programming language code elements &ndash;&nbsp;such as classes, properties, and methods&nbsp;&ndash; should be named. For example, you can specify that public members must be capitalized, or that private fields must begin with `_`.

A naming rule has three components:

1. The **symbol group** that the rule applies to; for example, public members or private fields.
1. The **naming style** to apply with the rule; for example, the name must be capitalized or start with an underscore.
1. The **naming rule**, linking
   - *symbol group*
   - *naming style*
   - *severity* (enforcing the convention)

   for enabling the rule.

## General syntax

To define a *symbol group*, *naming style*, or *naming rule* component, use the following general syntax:

```ini
<kind>.<title>.<propertyName> = <propertyValue>
```

Each property should only be set once, but some settings allow multiple, comma-separated values.

### \<kind>

**\<kind>** specifies which component is being defined &ndash;&nbsp;[symbol group](#symbol-group-properties), [naming style](#naming-style-properties), or [naming rule](#naming-rule-properties)&nbsp;&ndash; and must be one of the following:

| Component | \<kind> value | Example |
| --- | --- | -- |
| Symbol group | `dotnet_naming_symbols` | `dotnet_naming_symbols.interfaces.applicable_kinds = interface` |
| Naming style | `dotnet_naming_style` | `dotnet_naming_style.pascal_casing.capitalization = pascal_case` |
| Naming rule | `dotnet_naming_rule` | `dotnet_naming_rule.types_should_be_pascal_case.severity = suggestion` |

### \<title>

**\<title>** is an arbitrary descriptive name you choose for assigning multiple property settings to a single component definition.

For example, the following assignments produce three [symbol group](#symbol-group-properties) components, `interface`, `all_classes`, and `my_type_group`, each of which has two properties set on it:

```ini
dotnet_naming_symbols.interface.applicable_kinds = interface
dotnet_naming_symbols.interface.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected

dotnet_naming_symbols.all_classes.applicable_kinds = class
dotnet_naming_symbols.all_classes.applicable_accessibilities = *

dotnet_naming_symbols.my_type_group.applicable_kinds = class, struct, interface, enum, delegate
dotnet_naming_symbols.my_type_group.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
```

### \<propertyName>

Each of the three naming rule component definitions &ndash;&nbsp;[symbol group](#symbol-group-properties), [naming style](#naming-style-properties), or [naming rule](#naming-rule-properties)&nbsp;&ndash; has its own properties, as described in the following sections.

## Naming rule properties

All three naming rule components &ndash;&nbsp;[symbol group](#symbol-group-properties), [naming style](#naming-style-properties), or [naming rule](#naming-rule-properties)&nbsp;&ndash; are required for a rule to take effect.

### *Symbol group* properties

You can set the following properties for symbol groups, to define which symbols are affected by the group.

To specify multiple values for a single property, separate the values with a comma.

| Property | Description | Required | Allowed values |
| -- | -- | -- | -- |
| `applicable_kinds` | Kinds of symbols in the group&nbsp;<sup>1</sup> | Yes | `*` (use this value to specify all symbols)<br/>`namespace`<br/>`class`&nbsp;<sup>4</sup><br/>`struct`<br/>`interface`<br/>`enum`<br/>`property`<br/>`method`<br/>`field`<br/>`event`<br/>`delegate`<br/>`parameter`<br/>`type_parameter`<br/>`local`<br/>`local_function` |
| `applicable_accessibilities` | Accessibility levels of the symbols in the group | Yes | `*` (use this value to specify all accessibility levels)<br/>`public`<br/>`internal` or `friend`<br/>`private`<br/>`protected`<br/>`protected_internal` or `protected_friend`<br/>`private_protected`<br/>`local` (for symbols defined within a method) |
| `required_modifiers` | Only match symbols with _all_ the specified modifiers&nbsp;<sup>2</sup> | No | `abstract` or `must_inherit`<br/>`async`<br/>`const`<br/>`readonly`<br/>`static` or `shared`&nbsp;<sup>3</sup> |

**Notes:**

1. Tuple members aren't currently supported in `applicable_kinds`.
2. The symbol group matches _all_ the modifiers in the `required_modifiers` property.  If you omit this property, no specific modifiers are required for a match. This means a symbol's modifiers have no effect on whether or not this rule is applied.
3. If your group has `static` or `shared` in the `required_modifiers` property, the group will also include `const` symbols because they are implicitly `static`/`Shared`. However, if you don't want the `static` naming rule to apply to `const` symbols, you can create a new naming rule with a symbol group of `const`.
4. `class` includes [C# records](../../../csharp/language-reference/builtin-types/record.md).

### *Naming style* properties

You can set the following properties for *naming styles*, to define the conventions you want to enforce. For example:

* Capitalize with `PascalCase`
* Starts with `m_`
* Ends with `_g`
* Separate words with `__`

| Property | Description | Required | Allowed values |
| -- | -- | -- | -- |
| `capitalization` | Capitalization style for words within the symbol | Yes&nbsp;<sup>1</sup> | `pascal_case`<br/>`camel_case`<br/>`first_word_upper`<br/>`all_upper`<br/>`all_lower` |
| `required_prefix` | Must begin with these characters | No | Any valid token, without quotes |
| `required_suffix` | Must end with these characters | No | Any valid token, without quotes |
| `word_separator` | Words within the symbol need to be separated with this character | No | Any valid token, without quotes |

**Notes:**

1. You must specify a capitalization style as part of your naming style, otherwise your naming style will be ignored.

### *Naming rule* properties

The following properties for *naming rules* link a [symbol group](#symbol-group-properties) and a [naming style](#naming-style-properties) with a severity, thereby enabling the rule:

| Property | Description | Required | Allowed values |
| -- | -- | -- | -- |
| `symbols` | The title of a *symbol group* to which the naming rule will be applied | Yes |
| `style` | The title of the *naming style* to apply with this rule | Yes |
| `severity` |  Severity with which to enforce the naming rule.<br/>Set the associated value to one of the available [severity levels](../configuration-options.md#severity-level).<sup>1</sup> | Yes | `error`<br/>`warning`<br/>`suggestion`<br/>`silent`<br/>`none`<br/>`default` |

**Notes:**

1. Severity specification within a naming rule is only respected inside development IDEs, such as Visual Studio. This setting is not understood by the C# or VB compilers, hence not respected during build. To enforce naming style rules on build, you should set the severity by using [code rule severity configuration](#rule-id-ide1006-naming-rule-violation). For more information, see this [GitHub issue](https://github.com/dotnet/roslyn/issues/44201).

## Rule order

The order in which naming rules are defined in an EditorConfig file doesn't matter. The naming rules are automatically ordered according to the definition of the rules themselves. The [EditorConfig Language Service extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.EditorConfig) can analyze an EditorConfig file and report cases where the rule ordering in the file is different to what the compiler will use at run time.

> [!NOTE]
>
> If you're using a version of Visual Studio earlier than Visual Studio 2019 version 16.2, naming rules should be ordered from most-specific to least-specific in the EditorConfig file. The first rule encountered that can be applied is the only rule that is applied. However, if there are multiple rule *properties* with the same name, the most recently found property with that name takes precedence. For more information, see [File hierarchy and precedence](/visualstudio/ide/create-portable-custom-editor-options#file-hierarchy-and-precedence).

## Default naming styles

If you don't specify any custom naming rules, the following default styles are used:

- For classes, structs, enumerations, properties, methods, and events with any accessibility, the default naming style is Pascal case.

- For interfaces with any accessibility, the default naming style is Pascal case with a required prefix of **I**.

## <a name="rule-id-ide1006-naming-rule-violation"></a>Code Rule ID: `IDE1006 (Naming rule violation)`

All naming options have rule ID `IDE1006` and title `Naming rule violation`. You can configure the severity of naming violations globally in an EditorConfig file with the following syntax:

```ini
dotnet_diagnostic.IDE1006.severity = <severity value>
```

The severity value must be `warning` or `error` to be [enforced on build](../overview.md#code-style-analysis). For all possible severity values, see [severity level](../configuration-options.md#severity-level).

## Examples

The following *.editorconfig* file contains a naming convention that specifies that public properties, methods, fields, events, and delegates must be capitalized. Notice that this naming convention specifies multiple kinds of symbol to apply the rule to, using a comma to separate the values.

```ini
[*.{cs,vb}]

# Defining the 'public_symbols' symbol group
dotnet_naming_symbols.public_symbols.applicable_kinds = property,method,field,event,delegate
dotnet_naming_symbols.public_symbols.applicable_accessibilities = public
dotnet_naming_symbols.public_symbols.required_modifiers = readonly

# Defining the `first_word_upper_case_style` naming style
dotnet_naming_style.first_word_upper_case_style.capitalization = first_word_upper

# Defining the `public_members_must_be_capitalized` naming rule, by setting the symbol group to the 'public symbols' symbol group,
dotnet_naming_rule.public_members_must_be_capitalized.symbols = public_symbols
# setting the naming style to the `first_word_upper_case_style` naming style,
dotnet_naming_rule.public_members_must_be_capitalized.style = first_word_upper_case_style
# and setting the severity.
dotnet_naming_rule.public_members_must_be_capitalized.severity = suggestion
```

The next example enforces private fields to be prefixed by an underscore:

```ini
[*.{cs,vb}]

# Defining the 'private_field' symbol group
dotnet_naming_symbols.private_field.applicable_kinds = field
dotnet_naming_symbols.private_field.applicable_accessibilities = private

# Defining the `underscore_prefix_private_field` naming style
dotnet_naming_style.underscore_prefix_private_field.capitalization = camel_case ; required for rule to be enabled
dotnet_naming_style.underscore_prefix_private_field.required_prefix = _

# Defining the 'prefix_private_field_with_underscore' naming rule
dotnet_naming_rule.prefix_private_field_with_underscore.symbols = private_field
dotnet_naming_rule.prefix_private_field_with_underscore.style = underscore_prefix_private_field
dotnet_naming_rule.prefix_private_field_with_underscore.severity = warning
```

## See also

- [Language rules](language-rules.md)
- [Formatting rules](formatting-rules.md)
- [Roslyn naming rules](https://github.com/dotnet/roslyn/blob/main/.editorconfig#L63)
- [.NET code style rules reference](index.md)
