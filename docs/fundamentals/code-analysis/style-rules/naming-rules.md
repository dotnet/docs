---
title: Code-style naming rules
description: Learn about the .NET code-style rules for naming code elements.
ms.date: 09/25/2020
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

In your *.editorconfig* file, you can define naming conventions for your .NET programming language code elements&mdash;such as classes, properties, and methods&mdash;and how the compiler or IDE should enforce those conventions. For example, you could specify that a public member that isn't capitalized should be treated as a compiler error, or that if a private field doesn't begin with an `_`, a build warning should be issued.

Specifically, you can define a **naming rule**, which consists of three parts:

* The **symbol group** that the rule applies to, for example, public members or private fields.
* The **naming style** to associate with the rule, for example, that the name must be capitalized or start with an underscore.
* The severity level of the message when code elements included in the symbol group don't follow the naming style.

## General syntax

To define any of the above entities&mdash;a naming rule, symbol group, or naming style&mdash;set one or more properties using the following syntax:

```ini
<kind>.<entityName>.<propertyName> = <propertyValue>
```

All the property settings for a given `kind` and `entityName` make up that specific entity definition.

Each property should only be set once, but some settings allow multiple, comma-separated values.

The order of the properties is not important.

## \<kind> values

**\<kind>** specifies which kind of entity is being defined&mdash;naming rule, symbol group, or naming style&mdash;and must be one of the following:

| To set a property for | Use the \<kind> value | Example |
| --- | --- | -- |
| Naming rule | `dotnet_naming_rule` | `dotnet_naming_rule.types_should_be_pascal_case.severity = suggestion` |
| Symbol group | `dotnet_naming_symbols` | `dotnet_naming_symbols.interface.applicable_kinds = interface` |
| Naming style | `dotnet_naming_style` | `dotnet_naming_style.pascal_case.capitalization = pascal_case` |

## \<entityName>

**\<entityName>** is a descriptive name you choose that associates multiple property settings into a single definition. For example, the following properties produce two symbol group definitions, `interface` and `types`, each of which has two properties set on it.

```ini
dotnet_naming_symbols.interface.applicable_kinds = interface
dotnet_naming_symbols.interface.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected

dotnet_naming_symbols.types.applicable_kinds = class, struct, interface, enum, delegate
dotnet_naming_symbols.types.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
```

## \<propertyName> and \<propertyValue>

Each kind of entity&mdash;[naming rule](#naming-rule-properties), [symbol group](#symbol-group-properties), or [naming style](#naming-style-properties)&mdash;has its own supported properties, as described in the following sections.

### Symbol group properties

You can set the following properties for symbol groups, to limit which symbols are included in the group. To specify multiple values for a single property, separate the values with a comma.

| Property | Description | Allowed values | Required |
| -- | -- | -- | -- |
| `applicable_kinds` | Kinds of symbols in the group <sup>1</sup> | `*` (use this value to specify all symbols)<br/>`namespace`<br/>`class`<br/>`struct`<br/>`interface`<br/>`enum`<br/>`property`<br/>`method`<br/>`field`<br/>`event`<br/>`delegate`<br/>`parameter`<br/>`type_parameter`<br/>`local`<br/>`local_function` | Yes |
| `applicable_accessibilities` | Accessibility levels of the symbols in the group | `*` (use this value to specify all accessibility levels)<br/>`public`<br/>`internal` or `friend`<br/>`private`<br/>`protected`<br/>`protected_internal` or `protected_friend`<br/>`private_protected`<br/>`local` (for symbols defined within a method) | Yes |
| `required_modifiers` | Only match symbols with *all* the specified modifiers <sup>2</sup> | `abstract` or `must_inherit`<br/>`async`<br/>`const`<br/>`readonly`<br/>`static` or `shared` <sup>3</sup> | No |

**Notes:**

1. Tuple members aren't currently supported in `applicable_kinds`.
2. The symbol group matches *all* the modifiers in the `required_modifiers` property.  If you omit this property, no specific modifiers are required for a match. This means a symbol's modifiers have no effect on whether or not this rule is applied.
3. If your group has `static` or `shared` in the `required_modifiers` property, the group will also include `const` symbols because they are implicitly `static`/`Shared`. However, if you don't want the `static` naming rule to apply to `const` symbols, you can create a new naming rule with a symbol group of `const`. The new rule will take precedence according to the [rule order](#rule-order).
4. `class` includes [C# records](../../../csharp/language-reference/builtin-types/record.md).

### Naming style properties

A naming style defines the conventions you want to enforce with the rule. For example:

* Capitalize with `PascalCase`
* Starts with `m_`
* Ends with `_g`
* Separate words with `__`

You can set the following properties for a naming style:

| Property | Description | Allowed values | Required |
| -- | -- | -- | -- |
| `capitalization` | Capitalization style for words within the symbol | `pascal_case`<br/>`camel_case`<br/>`first_word_upper`<br/>`all_upper`<br/>`all_lower` | Yes<sup>1</sup> |
| `required_prefix` | Must begin with these characters | | No |
| `required_suffix` | Must end with these characters | | No |
| `word_separator` | Words within the symbol need to be separated with this character | | No |

**Notes:**

1. You must specify a capitalization style as part of your naming style, otherwise your naming style might be ignored.

### Naming rule properties

All naming rule properties are required for a rule to take effect.

| Property | Description |
| -- | -- |
| `symbols` | The name of a symbol group defined elsewhere; the naming rule will be applied to the symbols in this group |
| `style` | The name of the naming style which should be associated with this rule; the style is defined elsewhere |
| `severity` |  Sets the severity with which to enforce the naming rule. Set the associated value to one of the available [severity levels](../configuration-options.md#severity-level).<sup>1</sup> |

**Notes:**

1. Severity specification within a naming rule is only respected inside development IDEs, such as Visual Studio. This setting is not understood by the C# or VB compilers, hence not respected during build. To enforce naming style rules on build, you should instead set the severity by using [code rule severity configuration](#rule-id-ide1006-naming-rule-violation). For more information, see this [GitHub issue](https://github.com/dotnet/roslyn/issues/44201).

## Rule order

The order in which naming rules are defined in an EditorConfig file doesn't matter. The naming rules are automatically ordered according to the definitions of the rules themselves. More specific rules regarding accessibilities, modifiers, and symbols take precedence over less specific rules. If there's overlap between rules or if the rule ordering causes problems, you can break out the intersection of the two rules into a new rule that takes precedence over the broader rules from which it was derived. For examples, see [Example: Overlapping naming strategies](#example-overlapping-naming-strategies) and [Example: `const` modifier includes `static` and `readonly`](#example-const-modifier-includes-static-and-readonly).

> [!NOTE]
> If you're using a version of Visual Studio earlier than Visual Studio 2019, naming rules should be ordered from most-specific to least-specific in the EditorConfig file. The first rule encountered that can be applied is the only rule that is applied. However, if there are multiple rule *properties* with the same name, the most recently found property with that name takes precedence. For more information, see [File hierarchy and precedence](/visualstudio/ide/create-portable-custom-editor-options#file-hierarchy-and-precedence).

### Example: Overlapping naming strategies

Consider the following two naming rules:

1. Public methods are PascalCase.
2. Asynchronous methods end with `"Async"`.

For `public async` methods, it's not obvious which rule takes precedence. You can create a new rule for `public async` methods and specify the naming exactly.

### Example: `const` modifier includes `static` and `readonly`

Consider the following two naming rules:

1. Constant fields are PascalCase.
2. Non-public `static` fields are s_camelCase.

Rule 2 is more specific and takes precedence, so all non-public constant fields are s_camelCase. To resolve the issue, you can define an intersection rule: non-public constant fields are PascalCase.

## Default naming styles

If you don't specify any custom naming rules, the following default styles are used:

* For classes, structs, enumerations, properties, methods, and events with any accessibility, the default naming style is Pascal case.

* For interfaces with any accessibility, the default naming style is Pascal case with a required prefix of **I**.

## <a name="rule-id-ide1006-naming-rule-violation"></a>Code Rule ID: `IDE1006 (Naming rule violation)`

All naming options have rule ID `IDE1006` and title `Naming rule violation`. You can configure the severity of naming violations globally in an EditorConfig file with the following syntax:

```ini
dotnet_diagnostic.IDE1006.severity = <severity value>
```

The severity value must be `warning` or `error` to be [enforced on build](../overview.md#code-style-analysis). For all possible severity values, see [severity level](../configuration-options.md#severity-level).

## Example: Public member capitalization

The following *.editorconfig* file contains a naming convention that specifies that public properties, methods, fields, events, and delegates that are marked `readonly` must be capitalized. This naming convention specifies multiple kinds of symbol to apply the rule to, using a comma to separate the values.

```ini
[*.{cs,vb}]

# Defining the 'public_symbols' symbol group
dotnet_naming_symbols.public_symbols.applicable_kinds           = property,method,field,event,delegate
dotnet_naming_symbols.public_symbols.applicable_accessibilities = public
dotnet_naming_symbols.public_symbols.required_modifiers         = readonly

# Defining the 'first_word_upper_case_style' naming style
dotnet_naming_style.first_word_upper_case_style.capitalization = first_word_upper

# Defining the 'public_members_must_be_capitalized' naming rule, by setting the
# symbol group to the 'public symbols' symbol group,
dotnet_naming_rule.public_members_must_be_capitalized.symbols  = public_symbols
# setting the naming style to the 'first_word_upper_case_style' naming style,
dotnet_naming_rule.public_members_must_be_capitalized.style    = first_word_upper_case_style
# and setting the severity.
dotnet_naming_rule.public_members_must_be_capitalized.severity = suggestion
```

## Example: Private instance fields with underscore

This *.editorconfig* file snippet enforces that private instance fields should start with an `_`; if that convention is not followed, the IDE will treat it as a compiler error. Private static fields are ignored.

Because you can only define a symbol group based on the identifiers it has (for example, `static` or `readonly`), and not by the identifiers it doesn't have (for example, an instance field because it doesn't have `static`), you need to define two naming rules:

1. All private fields&mdash; `static` or not&mdash;should have the `underscored` naming style applied to them as a compiler `error`.
1. Private fields with `static` should have the `underscored` naming style applied to them with a severity level of `none`; in other words, ignore this case.

```ini
[*.{cs,vb}]

# Define the 'private_fields' symbol group:
dotnet_naming_symbols.private_fields.applicable_kinds = field
dotnet_naming_symbols.private_fields.applicable_accessibilities = private

# Define the 'private_static_fields' symbol group
dotnet_naming_symbols.private_static_fields.applicable_kinds = field
dotnet_naming_symbols.private_static_fields.applicable_accessibilities = private
dotnet_naming_symbols.private_static_fields.required_modifiers = static

# Define the 'underscored' naming style
dotnet_naming_style.underscored.capitalization = pascal_case
dotnet_naming_style.underscored.required_prefix = _

# Define the 'private_fields_underscored' naming rule
dotnet_naming_rule.private_fields_underscored.symbols = private_fields
dotnet_naming_rule.private_fields_underscored.style = underscored
dotnet_naming_rule.private_fields_underscored.severity = error

# Define the 'private_static_fields_none' naming rule
dotnet_naming_rule.private_static_fields_none.symbols = private_static_fields
dotnet_naming_rule.private_static_fields_none.style = underscored
dotnet_naming_rule.private_static_fields_none.severity = none
```

This example also demonstrates that entity definitions can be reused. The `underscored` naming style is used by both the `private_fields_underscored` and `private_static_fields_none` naming rules.

## See also

* [Language rules](language-rules.md)
* [Formatting rules](ide0055.md)
* [Roslyn naming rules](https://github.com/dotnet/roslyn/blob/main/.editorconfig#L63)
* [C# identifier naming rules and conventions](../../../csharp/fundamentals/coding-style/identifier-names.md)
