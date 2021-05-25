---
title: Code-style naming rules
description: Learn about the .NET code-style rules for naming code elements.
ms.date: 09/25/2020
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

In your `.editorconfig` file, you can define **naming rules** that specify and enforce how .NET programming language code elements&mdash;such as classes, properties, and methods&mdash;should be named. For example, you can specify that public members must be capitalized, or that private fields must begin with `_`.

A naming rule has three components:

* The **symbol group** that the rule applies to, for example, public members or private fields.
* The **naming style** to associate with the rule, for example, that the name must be capitalized or start with an underscore.
* The severity for enforcing the convention.

First, you must specify the symbol group and naming style and give each of them a title. Then you specify the naming rule, which links everything together.

## General syntax

To define a naming rule, symbol group, or naming style, set one or more properties using the following syntax:

```ini
<kind>.<title>.<propertyName> = <propertyValue>
```

Each property should only be set once, but some settings allow multiple, comma-separated values.

The order of the properties is not important.

### \<kind>

**\<kind>** specifies which kind of element is being defined&mdash;naming rule, symbol group, or naming style&mdash;and must be one of the following:

| To set a property for | Use the \<kind> value | Example |
| --- | --- | -- |
| Naming rule | `dotnet_naming_rule` | `dotnet_naming_rule.types_should_be_pascal_case.severity = suggestion` |
| Symbol group | `dotnet_naming_symbols` | `dotnet_naming_symbols.interface.applicable_kinds = interface` |
| Naming style | `dotnet_naming_style` | `dotnet_naming_style.pascal_case.capitalization = pascal_case` |

Each type of definition&mdash;[naming rule](#naming-rule-properties), [symbol group](#symbol-group-properties), or [naming style](#naming-style-properties)&mdash;has its own supported properties, as described in the following sections.

### \<title>

**\<title>** is a descriptive name you choose that associates multiple property settings into a single definition. For example, the following properties produce two symbol group definitions, `interface` and `types`, each of which has two properties set on it.

```ini
dotnet_naming_symbols.interface.applicable_kinds = interface
dotnet_naming_symbols.interface.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected

dotnet_naming_symbols.types.applicable_kinds = class, struct, interface, enum, delegate
dotnet_naming_symbols.types.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
```

## Naming rule properties

All naming rule properties are required for a rule to take effect.

| Property | Description |
| -- | -- |
| `symbols` | The title of a symbol group; the naming rule will be applied to the symbols in this group |
| `style` | The title of the naming style which should be associated with this rule |
| `severity` |  Sets the severity with which to enforce the naming rule. Set the associated value to one of the available [severity levels](../configuration-options.md#severity-level).<sup>1</sup> |

**Notes:**

1. Severity specification within a naming rule is only respected inside development IDEs, such as Visual Studio. This setting is not understood by the C# or VB compilers, hence not respected during build. To enforce naming style rules on build, you should instead set the severity by using [code rule severity configuration](#rule-id-ide1006-naming-rule-violation). For more information, see this [GitHub issue](https://github.com/dotnet/roslyn/issues/44201).

## Symbol group properties

You can set the following properties for symbol groups, to limit which symbols are included in the group. To specify multiple values for a single property, separate the values with a comma.

| Property | Description | Allowed values | Required |
| -- | -- | -- | -- |
| `applicable_kinds` | Kinds of symbols in the group <sup>1</sup> | `*` (use this value to specify all symbols)<br/>`namespace`<br/>`class`<br/>`struct`<br/>`interface`<br/>`enum`<br/>`property`<br/>`method`<br/>`field`<br/>`event`<br/>`delegate`<br/>`parameter`<br/>`type_parameter`<br/>`local`<br/>`local_function` | Yes |
| `applicable_accessibilities` | Accessibility levels of the symbols in the group | `*` (use this value to specify all accessibility levels)<br/>`public`<br/>`internal` or `friend`<br/>`private`<br/>`protected`<br/>`protected_internal` or `protected_friend`<br/>`private_protected`<br/>`local` (for symbols defined within a method) | Yes |
| `required_modifiers` | Only match symbols with _all_ the specified modifiers <sup>2</sup> | `abstract` or `must_inherit`<br/>`async`<br/>`const`<br/>`readonly`<br/>`static` or `shared` <sup>3</sup> | No |

**Notes:**

1. Tuple members aren't currently supported in `applicable_kinds`.
2. The symbol group matches _all_ the modifiers in the `required_modifiers` property.  If you omit this property, no specific modifiers are required for a match. This means a symbol's modifiers have no effect on whether or not this rule is applied.
3. If your group has `static` or `shared` in the `required_modifiers` property, the group will also include `const` symbols because they are implicitly `static`/`Shared`. However, if you don't want the `static` naming rule to apply to `const` symbols, you can create a new naming rule with a symbol group of `const`.
4. `class` includes [C# records](../../../csharp/language-reference/builtin-types/record.md).

## Naming style properties

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

## Example

The following *.editorconfig* file contains a naming convention that specifies that public properties, methods, fields, events, and delegates must be capitalized. Notice that this naming convention specifies multiple kinds of symbol to apply the rule to, using a comma to separate the values.

```ini
[*.{cs,vb}]

# Defining the 'public_symbols' symbol group
dotnet_naming_symbols.public_symbols.applicable_kinds           = property,method,field,event,delegate
dotnet_naming_symbols.public_symbols.applicable_accessibilities = public
dotnet_naming_symbols.public_symbols.required_modifiers         = readonly

# Defining the `first_word_upper_case_style` naming style
dotnet_naming_style.first_word_upper_case_style.capitalization = first_word_upper

# Defining the `public_members_must_be_capitalized` naming rule, by setting the symbol group to the 'public symbols' symbol group,
dotnet_naming_rule.public_members_must_be_capitalized.symbols   = public_symbols
# setting the naming style to the `first_word_upper_case_style` naming style,
dotnet_naming_rule.public_members_must_be_capitalized.style    = first_word_upper_case_style
# and setting the severity.
dotnet_naming_rule.public_members_must_be_capitalized.severity = suggestion
```

## See also

- [Language rules](language-rules.md)
- [Formatting rules](formatting-rules.md)
- [Roslyn naming rules](https://github.com/dotnet/roslyn/blob/main/.editorconfig#L63)
- [.NET code style rules reference](index.md)
