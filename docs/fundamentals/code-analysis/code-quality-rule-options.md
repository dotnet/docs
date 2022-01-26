---
title: Code quality rule configuration options
description: Learn how to specify additional configuration options for code quality rules.
ms.date: 09/24/2020
no-loc: ["EditorConfig"]
---
# Code quality rule configuration options

The *code quality* rules have additional configuration options, besides just [configuring their severity](configuration-options.md#severity-level). For example, each code quality analyzer can be configured to only apply to specific parts of your codebase. You specify these options by adding key-value pairs to the same [EditorConfig](https://editorconfig.org) file where you specify rule severities and general editor preferences.

## Option scopes

Each refining option can be configured for all rules, for a category of rules (for example, Security or Design), or for a specific rule.

### All rules

The syntax for configuring an option for *all* rules is as follows:

|Syntax|Example|
|-|-|
| dotnet_code_quality.\<OptionName> = \<OptionValue> | `dotnet_code_quality.api_surface = public` |

The values for `<OptionName>` are listed under [Options](#options).

### Category of rules

The syntax for configuring an option for a [*category* of rules](categories.md) is as follows:

|Syntax|Example|
|-|-|
| dotnet_code_quality.\<RuleCategory>.\<OptionName> = OptionValue | `dotnet_code_quality.Naming.api_surface = public` |

The following table lists the available values for `<RuleCategory>`.

:::row:::
    :::column:::
        Design
        Documentation
        Globalization
        Interoperability
    :::column-end:::
    :::column:::
        Maintainability
        Naming
        Performance
        SingleFile
    :::column-end:::
    :::column:::
        Reliability
        Security
        Usage
    :::column-end:::
:::row-end:::

### Specific rule

The syntax for configuring an option for a *specific* rule is as follows:

|Syntax|Example|
|-|-|
| dotnet_code_quality.\<RuleId>.\<OptionName> = \<OptionValue> | `dotnet_code_quality.CA1040.api_surface = public` |

## Options

This section lists some of the available options. To see the full list of available options, see [Analyzer configuration](https://github.com/dotnet/roslyn-analyzers/blob/main/docs/Analyzer%20Configuration.md).

- [api_surface](#api_surface)
- [exclude_async_void_methods](#exclude_async_void_methods)
- [exclude_single_letter_type_parameters](#exclude_single_letter_type_parameters)
- [output_kind](#output_kind)
- [required_modifiers](#required_modifiers)
- [exclude_extension_method_this_parameter](#exclude_extension_method_this_parameter)
- [null_check_validation_methods](#null_check_validation_methods)
- [additional_string_formatting_methods](#additional_string_formatting_methods)
- [excluded_type_names_with_derived_types](#excluded_type_names_with_derived_types)
- [excluded_symbol_names](#excluded_symbol_names)
- [disallowed_symbol_names](#disallowed_symbol_names)

### api_surface

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Which part of the API surface to analyze | `public`<br/>`internal` or `friend`<br/>`private`<br/>`all`<br/><br/>Separate multiple values with a comma (,) | `public` | [CA1000](quality-rules/ca1000.md) [CA1003](quality-rules/ca1003.md) [CA1008](quality-rules/ca1008.md) [CA1010](quality-rules/ca1010.md)<br/>[CA1012](quality-rules/ca1012.md) [CA1024](quality-rules/ca1024.md) [CA1027](quality-rules/ca1027.md) [CA1028](quality-rules/ca1028.md)<br/>[CA1030](quality-rules/ca1030.md) [CA1036](quality-rules/ca1036.md) [CA1040](quality-rules/ca1040.md) [CA1041](quality-rules/ca1041.md)<br/>[CA1043](quality-rules/ca1043.md) [CA1044](quality-rules/ca1044.md) [CA1051](quality-rules/ca1051.md) [CA1052](quality-rules/ca1052.md)<br/>[CA1054](quality-rules/ca1054.md) [CA1055](quality-rules/ca1055.md) [CA1056](quality-rules/ca1056.md) [CA1058](quality-rules/ca1058.md)<br/>[CA1063](quality-rules/ca1063.md) [CA1708](quality-rules/ca1708.md) [CA1710](quality-rules/ca1710.md) [CA1711](quality-rules/ca1711.md)<br/>[CA1714](quality-rules/ca1714.md) [CA1715](quality-rules/ca1715.md) [CA1716](quality-rules/ca1716.md) [CA1717](quality-rules/ca1717.md)<br/>[CA1720](quality-rules/ca1720.md) [CA1721](quality-rules/ca1721.md) [CA1725](quality-rules/ca1725.md) [CA1801](quality-rules/ca1801.md)<br/>[CA1802](quality-rules/ca1802.md) [CA1815](quality-rules/ca1815.md) [CA1819](quality-rules/ca1819.md) [CA2217](quality-rules/ca2217.md)<br/>[CA2225](quality-rules/ca2225.md) [CA2226](quality-rules/ca2226.md) [CA2231](quality-rules/ca2231.md) [CA2234](quality-rules/ca2234.md)<br/>|

### exclude_async_void_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Whether to ignore asynchronous methods that don't return a value | `true`<br/>`false` | `false` | [CA2007](quality-rules/ca2007.md) |

> [!NOTE]
> This option was named `skip_async_void_methods` in an earlier version.

### exclude_single_letter_type_parameters

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Whether to exclude single-character [type parameters](../../csharp/programming-guide/generics/generic-type-parameters.md) from the rule, for example, `S` in `Collection<S>` | `true`<br/>`false` | `false` | [CA1715](quality-rules/ca1715.md) |

> [!NOTE]
> This option was named `allow_single_letter_type_parameters` in an earlier version.

### output_kind

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Specifies that code in a project that generates this type of assembly should be analyzed | One or more fields of the <xref:Microsoft.CodeAnalysis.OutputKind> enumeration<br/><br/>Separate multiple values with a comma (,) | All output kinds | [CA2007](quality-rules/ca2007.md) |

### required_modifiers

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Specifies the required modifiers for APIs that should be analyzed | One or more values from the below allowed modifiers table<br/><br/>Separate multiple values with a comma (,) | Depends on each rule | [CA1802](quality-rules/ca1802.md) |

| Allowed Modifier | Summary |
| --- | --- |
| `none` | No modifier requirement |
| `static` or `Shared` | Must be declared as `static` (`Shared` in Visual Basic) |
| `const` | Must be declared as `const` |
| `readonly` | Must be declared as `readonly` |
| `abstract` | Must be declared as `abstract` |
| `virtual` | Must be declared as `virtual` |
| `override` | Must be declared as `override` |
| `sealed` | Must be declared as `sealed` |
| `extern` | Must be declared as `extern` |
| `async` | Must be declared as `async` |

### exclude_extension_method_this_parameter

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Whether to skip analysis for the `this` parameter of extension methods | `true`<br/>`false` | `false` | [CA1062](quality-rules/ca1062.md) |

### null_check_validation_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of null-check validation methods that validate that arguments passed to the method are non-null | Allowed method name formats (separated by \|):<br/> - Method name only (includes all methods with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format), with an optional `M:` prefix | None | [CA1062](quality-rules/ca1062.md) |

### additional_string_formatting_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of additional string formatting methods | Allowed method name formats (separated by \|):<br/> - Method name only (includes all methods with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format), with an optional `M:` prefix | None | [CA2241](quality-rules/ca2241.md) |

### excluded_type_names_with_derived_types

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of types, such that the type and all its derived types are excluded for analysis | Allowed symbol name formats (separated by \|):<br/> - Type name only (includes all types with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format), with an optional `T:` prefix | None | [CA1303](quality-rules/ca1303.md) |

### excluded_symbol_names

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of symbols that are excluded for analysis | Allowed symbol name formats (separated by \|):<br/> - Symbol name only (includes all symbols with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format). Each symbol name requires a symbol kind prefix, such as `M:` prefix for methods, `T:` prefix for types, and `N:` prefix for namespaces.<br/> - `.ctor` for constructors and `.cctor` for static constructors | None | [CA1062](quality-rules/ca1062.md) [CA1303](quality-rules/ca1303.md) [CA2000](quality-rules/ca2000.md) [CA2100](quality-rules/ca2100.md) [CA2301](quality-rules/ca2301.md) [CA2302](quality-rules/ca2302.md)<br/>[CA2311](quality-rules/ca2311.md) [CA2312](quality-rules/ca2312.md) [CA2321](quality-rules/ca2321.md) [CA2322](quality-rules/ca2322.md) [CA2327](quality-rules/ca2327.md) [CA2328](quality-rules/ca2328.md)<br/>[CA2329](quality-rules/ca2329.md) [CA2330](quality-rules/ca2330.md) [CA3001](quality-rules/ca3001.md) [CA3002](quality-rules/ca3002.md) [CA3003](quality-rules/ca3003.md) [CA3004](quality-rules/ca3004.md)<br/>[CA3005](quality-rules/ca3005.md) [CA3006](quality-rules/ca3006.md) [CA3007](quality-rules/ca3007.md) [CA3008](quality-rules/ca3008.md) [CA3009](quality-rules/ca3009.md) [CA3010](quality-rules/ca3010.md)<br/>[CA3011](quality-rules/ca3011.md) [CA3012](quality-rules/ca3012.md) [CA5361](quality-rules/ca5361.md) CA5376 CA5377 [CA5378](quality-rules/ca5378.md)<br/>[CA5380](quality-rules/ca5380.md) [CA5381](quality-rules/ca5381.md) CA5382 CA5383 CA5384 CA5387<br/>CA5388 [CA5389](quality-rules/ca5389.md) CA5390 |

### disallowed_symbol_names

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of symbols that are disallowed in the context of the analysis | Allowed symbol name formats (separated by \|):<br/> - Symbol name only (includes all symbols with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format). Each symbol name requires a symbol kind prefix, such as `M:` prefix for methods, `T:` prefix for types, and `N:` prefix for namespaces.<br/> - `.ctor` for constructors and `.cctor` for static constructors | None | [CA1031](quality-rules/ca1031.md) |
