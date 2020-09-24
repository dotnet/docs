---
title: Configure .NET code quality rules using editorconfig
ms.date: 09/24/2020
ms.topic: conceptual
helpviewer_keywords:
- .NET analyzers
- code quality rules, configuring
- configure code quality rules
author: mikadumont
ms.author: midumont
---
# Configure .NET code quality rules

Starting in .NET 5.0, code quality analyzers ([`CAxxxx` rules](rules/quality-rules-reference.md)) are included with the .NET SDK. Each code quality analyzer can be refined to apply to parts of your codebase through configurable options. You specify an option by adding a key-value pair to an [EditorConfig](https://editorconfig.org) file that's specific to a file, project, solution, or an entire repo.

> [!TIP]
> Visual Studio provides an *.editorconfig* item template. For more information, see [Add an EditorConfig file to a project](/visualstudio/ide/create-portable-custom-editor-options#add-an-editorconfig-file-to-a-project).

For information about configuring a rule's severity (for example, whether it's an error or a warning), see [Configure code analysis rules](configure-rules.md). Or, you can choose one of the [predefined EditorConfig files or rule sets](#enable-a-category-of-rules) to quickly enable or disable a category of rules. The remainder of this article concerns the options that refine *where* .NET code-quality analyzers are applied.

## Option scopes

Each refining option can be configured for all rules, for a category of rules (for example, Security or Design), or for a specific rule.

### All rules

The syntax for configuring an option for *all* rules is as follows:

|Syntax|Example|
|-|-|
| dotnet_code_quality.OptionName = OptionValue | `dotnet_code_quality.api_surface = public` |

### Category of rules

The syntax for configuring an option for a *category* of rules (such as Naming, Design, or Performance) is as follows:

|Syntax|Example|
|-|-|
| dotnet_code_quality.RuleCategory.OptionName = OptionValue | `dotnet_code_quality.Naming.api_surface = public` |

### Specific rule

The syntax for configuring an option for a *specific* rule is as follows:

|Syntax|Example|
|-|-|
| dotnet_code_quality.RuleId.OptionName = OptionValue | `dotnet_code_quality.CA1040.api_surface = public` |

## Options for .NET code-quality analyzers

You specify options in an *.editorconfig* file. This section lists some of the available options.

> [!TIP]
> To see the full list of available options, see this [Analyzer Configuration.md file](https://github.com/dotnet/roslyn-analyzers/blob/master/docs/Analyzer%20Configuration.md). Here's an example of how an option is documented in the *Analyzer Configuration.md* file:
>
> Option Name: `sufficient_IterationCount_for_weak_KDF_algorithm`\
> Option Values: integral values\
> Default Value: Specific to each configurable rule (`100000` by default for most rules)\
> Example: `dotnet_code_quality.CA5387.sufficient_IterationCount_for_weak_KDF_algorithm = 100000`

### api_surface

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Which part of the API surface to analyze | `public`<br/>`internal` or `friend`<br/>`private`<br/>`all`<br/><br/>Separate multiple values with a comma (,) | `public` | [CA1000](rules/ca1000.md) [CA1003](rules/ca1003.md) [CA1008](rules/ca1008.md) [CA1010](rules/ca1010.md)<br/>[CA1012](rules/ca1012.md) [CA1024](rules/ca1024.md) [CA1027](rules/ca1027.md) [CA1028](rules/ca1028.md)<br/>[CA1030](rules/ca1030.md) [CA1036](rules/ca1036.md) [CA1040](rules/ca1040.md) [CA1041](rules/ca1041.md)<br/>[CA1043](rules/ca1043.md) [CA1044](rules/ca1044.md) [CA1051](rules/ca1051.md) [CA1052](rules/ca1052.md)<br/>[CA1054](rules/ca1054.md) [CA1055](rules/ca1055.md) [CA1056](rules/ca1056.md) [CA1058](rules/ca1058.md)<br/>[CA1063](rules/ca1063.md) [CA1708](rules/ca1708.md) [CA1710](rules/ca1710.md) [CA1711](rules/ca1711.md)<br/>[CA1714](rules/ca1714.md) [CA1715](rules/ca1715.md) [CA1716](rules/ca1716.md) [CA1717](rules/ca1717.md)<br/>[CA1720](rules/ca1720.md) [CA1721](rules/ca1721.md) [CA1725](rules/ca1725.md) [CA1801](rules/ca1801.md)<br/>[CA1802](rules/ca1802.md) [CA1815](rules/ca1815.md) [CA1819](rules/ca1819.md) [CA2217](rules/ca2217.md)<br/>[CA2225](rules/ca2225.md) [CA2226](rules/ca2226.md) [CA2231](rules/ca2231.md) [CA2234](rules/ca2234.md)<br/>|

### exclude_async_void_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Whether to ignore asynchronous methods that don't return a value | `true`<br/>`false` | `false` | [CA2007](rules/ca2007.md) |

> [!NOTE]
> This option was named `skip_async_void_methods` in an earlier version.

### exclude_single_letter_type_parameters

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Whether to exclude single-character [type parameters](../../csharp/programming-guide/generics/generic-type-parameters.md) from the rule, for example, `S` in `Collection<S>` | `true`<br/>`false` | `false` | [CA1715](rules/ca1715.md) |

> [!NOTE]
> This option was named `allow_single_letter_type_parameters` in an earlier version.

### output_kind

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Specifies that code in a project that generates this type of assembly should be analyzed | One or more fields of the <xref:Microsoft.CodeAnalysis.OutputKind> enumeration<br/><br/>Separate multiple values with a comma (,) | All output kinds | [CA2007](rules/ca2007.md) |

### required_modifiers

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Specifies the required modifiers for APIs that should be analyzed | One or more values from the below allowed modifiers table<br/><br/>Separate multiple values with a comma (,) | Depends on each rule | [CA1802](rules/ca1802.md) |

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
| Whether to skip analysis for the `this` parameter of extension methods | `true`<br/>`false` | `false` | [CA1062](rules/ca1062.md) |

### null_check_validation_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of null-check validation methods that validate that arguments passed to the method are non-null | Allowed method name formats (separated by `|`):<br/> - Method name only (includes all methods with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](https://github.com/dotnet/csharplang/blob/master/spec/documentation-comments.md#id-string-format), with an optional `M:` prefix | None | [CA1062](rules/ca1062.md) |

### additional_string_formatting_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of additional string formatting methods | Allowed method name formats (separated by `|`):<br/> - Method name only (includes all methods with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format), with an optional `M:` prefix | None | [CA2241](rules/ca2241.md) |

### excluded_type_names_with_derived_types

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of types, such that the type and all its derived types are excluded for analysis | Allowed symbol name formats (separated by `|`):<br/> - Type name only (includes all types with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format), with an optional `T:` prefix | None | [CA1303](rules/ca1303.md) |

### excluded_symbol_names

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of symbols that are excluded for analysis | Allowed symbol name formats (separated by `|`):<br/> - Symbol name only (includes all symbols with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format). Each symbol name requires a symbol kind prefix, such as `M:` prefix for methods, `T:` prefix for types, and `N:` prefix for namespaces.<br/> - `.ctor` for constructors and `.cctor` for static constructors | None | [CA1062](rules/ca1062.md) [CA1303](rules/ca1303.md) [CA2000](rules/ca2000.md) [CA2100](rules/ca2100.md) [CA2301](rules/ca2301.md) [CA2302](rules/ca2302.md)<br/>[CA2311](rules/ca2311.md) [CA2312](rules/ca2312.md) [CA2321](rules/ca2321.md) [CA2322](rules/ca2322.md) [CA2327](rules/ca2327.md) [CA2328](rules/ca2328.md)<br/>[CA2329](rules/ca2329.md) [CA2330](rules/ca2330.md) [CA3001](rules/ca3001.md) [CA3002](rules/ca3002.md) [CA3003](rules/ca3003.md) [CA3004](rules/ca3004.md)<br/>[CA3005](rules/ca3005.md) [CA3006](rules/ca3006.md) [CA3007](rules/ca3007.md) [CA3008](rules/ca3008.md) [CA3009](rules/ca3009.md) [CA3010](rules/ca3010.md)<br/>[CA3011](rules/ca3011.md) [CA3012](rules/ca3012.md) [CA5361](rules/ca5361.md) CA5376 CA5377 [CA5378](rules/ca5378.md)<br/>[CA5380](rules/ca5380.md) [CA5381](rules/ca5381.md) CA5382 CA5383 CA5384 CA5387<br/>CA5388 [CA5389](rules/ca5389.md) CA5390 |

### disallowed_symbol_names

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of symbols that are disallowed in the context of the analysis | Allowed symbol name formats (separated by `|`):<br/> - Symbol name only (includes all symbols with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format). Each symbol name requires a symbol kind prefix, such as `M:` prefix for methods, `T:` prefix for types, and `N:` prefix for namespaces.<br/> - `.ctor` for constructors and `.cctor` for static constructors | None | [CA1031](rules/ca1031.md) |

## Enable a category of rules

Analyzer packages may include predefined EditorConfig and [rule set](/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules) files that make it quick and easy to enable a category of rules, such as security or design rules. The [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers#microsoftcodeanalysisnetanalyzers) NuGet analyzer package includes both EditorConfig files and rule sets. By enabling a specific category of rules, you can identify targeted issues and specific conditions.

The NetAnalyzers NuGet package includes predefined EditorConfig files and rule sets for the following rule categories:

- All rules
- Dataflow
- Design
- Documentation
- Globalization
- Interoperability
- Maintainability
- Naming
- Performance
- Ported from FxCop
- Reliability
- Security
- Usage

Each of those categories of rules has an EditorConfig or rule set file to:

- Enable all the rules in the category (and disable all other rules)
- Use each rule's default severity and enabled by default setting (and disable all other rules)

> [!TIP]
> The "all rules" category has an additional EditorConfig or rule set file to disable all rules. Use this file to quickly get rid of any analyzer warnings or errors in a project.

> [!TIP]
> If you're migrating from legacy "FxCop" analysis to .NET Compiler Platform-based code analysis, the EditorConfig and rule set files enable you to continue using similar rule configurations to [those you used previously](/visualstudio/code-quality/rule-set-reference).

### Predefined EditorConfig files

The predefined EditorConfig files for the Microsoft.CodeAnalysis.NetAnalyzers analyzer package are located in the *editorconfig* subdirectory of where the NuGet package was installed. For example, the EditorConfig file to enable all security rules is located at *editorconfig/SecurityRulesEnabled/.editorconfig*.

Copy the chosen *.editorconfig* file to your project's root directory.

### Predefined rule sets

The predefined rule set files for the Microsoft.CodeAnalysis.NetAnalyzers analyzer package are located in the *rulesets* subdirectory of where the NuGet package was installed. For example, the rule set file to enable all security rules is located at *rulesets/SecurityRulesEnabled.ruleset*. Copy one or more of the rule sets and paste them in the directory that contains your project.

## See also

- [Analyzer configuration](https://github.com/dotnet/roslyn-analyzers/blob/master/docs/Analyzer%20Configuration.md)
- [.NET coding conventions for EditorConfig](/visualstudio/ide/editorconfig-code-style-settings-reference.md)
