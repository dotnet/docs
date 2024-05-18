---
title: Code quality rule configuration options
description: Learn how to specify additional configuration options for code quality rules.
ms.date: 05/19/2023
no-loc: ["EditorConfig"]
---
# Code quality rule configuration options

The *code quality* rules have additional configuration options, besides just [configuring their severity](configuration-options.md#severity-level). For example, each code quality analyzer can be configured to only apply to specific parts of your codebase. You specify these options by adding key-value pairs to the same [EditorConfig](https://editorconfig.org) file where you specify rule severities and general editor preferences.

> [!NOTE]
> This article does not detail how to configure a rule's severity. The *.editorconfig* option to set a rule's severity has a different prefix (`dotnet_diagnostic`) to the options described here (`dotnet_code_quality`). In addition, the options described here pertain to code quality rules only, whereas the severity option applies to code style rules as well. As a quick reference, you can configure a rule's severity using the following option syntax:
>
> ```ini
> dotnet_diagnostic.<rule ID>.severity = <severity value>
> ```
>
> However, for detailed information about configuring rule severity, see [Severity level](configuration-options.md#severity-level).

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
        `Design`\
        `Documentation`\
        `Globalization`\
        `Interoperability`
    :::column-end:::
    :::column:::
        `Maintainability`\
        `Naming`\
        `Performance`\
        `SingleFile`
    :::column-end:::
    :::column:::
        `Reliability`\
        `Security`\
        `Usage`
    :::column-end:::
:::row-end:::

### Specific rule

The syntax for configuring an option for a *specific* rule is as follows:

|Syntax|Example|
|-|-|
| dotnet_code_quality.\<RuleId>.\<OptionName> = \<OptionValue> | `dotnet_code_quality.CA1040.api_surface = public` |

## Options

This section lists some of the available options. To see the full list of available options, see [Analyzer configuration](https://github.com/dotnet/roslyn-analyzers/blob/main/docs/Analyzer%20Configuration.md).

- [api\_surface](#api_surface)
- [exclude\_async\_void\_methods](#exclude_async_void_methods)
- [exclude\_single\_letter\_type\_parameters](#exclude_single_letter_type_parameters)
- [output\_kind](#output_kind)
- [required\_modifiers](#required_modifiers)
- [exclude\_extension\_method\_this\_parameter](#exclude_extension_method_this_parameter)
- [null\_check\_validation\_methods](#null_check_validation_methods)
- [additional\_string\_formatting\_methods](#additional_string_formatting_methods)
- [excluded\_type\_names\_with\_derived\_types](#excluded_type_names_with_derived_types)
- [excluded\_symbol\_names](#excluded_symbol_names)
- [disallowed\_symbol\_names](#disallowed_symbol_names)
- [exclude\_ordefault\_methods](#exclude_ordefault_methods)
- [ignore_internalsvisibleto](#ignore_internalsvisibleto)
- [try_determine_additional_string_formatting_methods_automatically](#try_determine_additional_string_formatting_methods_automatically)
- [unsafe_DllImportSearchPath_bits](#unsafe_DllImportSearchPath_bits)
- [exclude_aspnet_core_mvc_controllerbase](#exclude_aspnet_core_mvc_controllerbase)
- [interprocedural_analysis_kind](#interprocedural_analysis_kind)
- [max_interprocedural_method_call_chain](#max_interprocedural_method_call_chain)
- [max_interprocedural_lambda_or_local_function_call_chain](#max_interprocedural_lambda_or_local_function_call_chain)
- [dispose_analysis_kind](#dispose_analysis_kind)
- [dispose_ownership_transfer_at_constructor](#dispose_ownership_transfer_at_constructor)
- [dispose_ownership_transfer_at_method_call](#dispose_ownership_transfer_at_method_call)
- [points_to_analysis_kind](#points_to_analysis_kind)
- [copy_analysis](#copy_analysis)
- [sufficient_IterationCount_for_weak_KDF_algorithm](#sufficient_IterationCount_for_weak_KDF_algorithm)
- [enum_values_prefix_trigger](#enum_values_prefix_trigger)
- [exclude_indirect_base_types](#exclude_indirect_base_types)
- [additional_required_suffixes](#additional_required_suffixes)
- [additional_required_generic_interfaces](#additional_required_generic_interfaces)
- [additional_inheritance_excluded_symbol_names](#additional_inheritance_excluded_symbol_names)
- [analyzed_symbol_kinds](#analyzed_symbol_kinds)
- [use_naming_heuristic](#use_naming_heuristic)
- [additional_use_results_methods](#additional_use_results_methods)
- [allowed_suffixes](#allowed_suffixes)
- [enable_platform_analyzer_on_pre_net5_target](#additional_inheritance_excluded_symbol_names)
- [exclude_structs](#exclude_structs)
- [additional_enum_none_names](#additional_enum_none_names)
- [enumeration_methods](#enumeration_methods)
- [linq_chain_methods](#linq_chain_methods)
- [assume_method_enumerates_parameters](#assume_method_enumerates_parameters)

### api_surface

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Which part of the API surface to analyze | `public` (applies to `public` and `protected` APIs)<br/>`internal` or `friend` (applies to `internal` and `private protected` APIs)<br/>`private` (applies to `private` APIs)<br/>`all` (applies to all APIs)<br/><br/>Separate multiple values with a comma (,) | `public` | [CA1000](quality-rules/ca1000.md) [CA1002](quality-rules/ca1002.md) [CA1003](quality-rules/ca1003.md) [CA1005](quality-rules/ca1005.md) [CA1008](quality-rules/ca1008.md) [CA1010](quality-rules/ca1010.md) [CA1012](quality-rules/ca1012.md) [CA1021](quality-rules/ca1021.md) [CA1024](quality-rules/ca1024.md) [CA1027](quality-rules/ca1027.md) [CA1028](quality-rules/ca1028.md) [CA1030](quality-rules/ca1030.md) [CA1036](quality-rules/ca1036.md) [CA1040](quality-rules/ca1040.md) [CA1041](quality-rules/ca1041.md) [CA1043](quality-rules/ca1043.md) [CA1044](quality-rules/ca1044.md) [CA1045](quality-rules/ca1045.md) [CA1046](quality-rules/ca1046.md) [CA1047](quality-rules/ca1047.md) [CA1051](quality-rules/ca1051.md) [CA1052](quality-rules/ca1052.md) [CA1054](quality-rules/ca1054.md) [CA1055](quality-rules/ca1055.md) [CA1056](quality-rules/ca1056.md) [CA1058](quality-rules/ca1058.md) [CA1062](quality-rules/ca1062.md) [CA1063](quality-rules/ca1063.md) [CA1068](quality-rules/ca1068.md) [CA1070](quality-rules/ca1070.md) [CA1700](quality-rules/ca1700.md) [CA1707](quality-rules/ca1707.md) [CA1708](quality-rules/ca1708.md) [CA1710](quality-rules/ca1710.md) [CA1711](quality-rules/ca1711.md) [CA1714](quality-rules/ca1714.md) [CA1715](quality-rules/ca1715.md) [CA1716](quality-rules/ca1716.md) [CA1717](quality-rules/ca1717.md) [CA1720](quality-rules/ca1720.md) [CA1721](quality-rules/ca1721.md) [CA1725](quality-rules/ca1725.md) [CA1801](quality-rules/ca1801.md) [CA1802](quality-rules/ca1802.md) [CA1815](quality-rules/ca1815.md) [CA1819](quality-rules/ca1819.md) [CA1822](quality-rules/ca1822.md) [CA1859](quality-rules/ca1859.md) [CA2208](quality-rules/ca2208.md) [CA2217](quality-rules/ca2217.md) [CA2225](quality-rules/ca2225.md) [CA2226](quality-rules/ca2226.md) [CA2231](quality-rules/ca2231.md) [CA2234](quality-rules/ca2234.md) |

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
| Names of types, such that the type and all its derived types are excluded for analysis | Allowed symbol name formats (separated by \|):<br/> - Type name only (includes all types with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format), with an optional `T:` prefix | None | [CA1001](quality-rules/ca1001.md) [CA1054](quality-rules/ca1054.md) [CA1055](quality-rules/ca1055.md) [CA1056](quality-rules/ca1056.md) [CA1062](quality-rules/ca1062.md) [CA1068](quality-rules/ca1068.md) [CA1303](quality-rules/ca1303.md) [CA1304](quality-rules/ca1304.md) [CA1305](quality-rules/ca1305.md) [CA1508](quality-rules/ca1508.md) [CA2000](quality-rules/ca2000.md) [CA2100](quality-rules/ca2100.md) [CA2301](quality-rules/ca2301.md) [CA2302](quality-rules/ca2302.md) [CA2311](quality-rules/ca2311.md) [CA2312](quality-rules/ca2312.md) [CA2321](quality-rules/ca2321.md) [CA2322](quality-rules/ca2322.md) [CA2327](quality-rules/ca2327.md) [CA2328](quality-rules/ca2328.md) [CA2329](quality-rules/ca2329.md) [CA2330](quality-rules/ca2330.md) [CA3001](quality-rules/ca3001.md) [CA3002](quality-rules/ca3002.md) [CA3003](quality-rules/ca3003.md) [CA3004](quality-rules/ca3004.md) [CA3005](quality-rules/ca3005.md) [CA3006](quality-rules/ca3006.md) [CA3007](quality-rules/ca3007.md) [CA3008](quality-rules/ca3008.md) [CA3009](quality-rules/ca3009.md) [CA3010](quality-rules/ca3010.md) [CA3011](quality-rules/ca3011.md) [CA3012](quality-rules/ca3012.md) [CA5361](quality-rules/ca5361.md) [CA5376](quality-rules/ca5376.md) [CA5377](quality-rules/ca5377.md) [CA5378](quality-rules/ca5378.md) [CA5380](quality-rules/ca5380.md) [CA5381](quality-rules/ca5381.md) [CA5382](quality-rules/ca5382.md) [CA5383](quality-rules/ca5383.md) [CA5384](quality-rules/ca5384.md) [CA5387](quality-rules/ca5387.md) [CA5388](quality-rules/ca5388.md) [CA5389](quality-rules/ca5389.md) [CA5390](quality-rules/ca5390.md) [CA5399](quality-rules/ca5399.md) [CA5400](quality-rules/ca5400.md) |

### excluded_symbol_names

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of symbols that are excluded for analysis | Allowed symbol name formats (separated by \|):<br/> - Symbol name only (includes all symbols with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format). Each symbol name requires a symbol kind prefix, such as `M:` prefix for methods, `T:` prefix for types, and `N:` prefix for namespaces.<br/> - `.ctor` for constructors and `.cctor` for static constructors | None | [CA1001](quality-rules/ca1001.md) [CA1054](quality-rules/ca1054.md) [CA1055](quality-rules/ca1055.md) [CA1056](quality-rules/ca1056.md) [CA1062](quality-rules/ca1062.md) [CA1068](quality-rules/ca1068.md) [CA1303](quality-rules/ca1303.md) [CA1304](quality-rules/ca1304.md) [CA1305](quality-rules/ca1305.md) [CA1508](quality-rules/ca1508.md) [CA2000](quality-rules/ca2000.md) [CA2100](quality-rules/ca2100.md) [CA2301](quality-rules/ca2301.md) [CA2302](quality-rules/ca2302.md) [CA2311](quality-rules/ca2311.md) [CA2312](quality-rules/ca2312.md) [CA2321](quality-rules/ca2321.md) [CA2322](quality-rules/ca2322.md) [CA2327](quality-rules/ca2327.md) [CA2328](quality-rules/ca2328.md) [CA2329](quality-rules/ca2329.md) [CA2330](quality-rules/ca2330.md) [CA3001](quality-rules/ca3001.md) [CA3002](quality-rules/ca3002.md) [CA3003](quality-rules/ca3003.md) [CA3004](quality-rules/ca3004.md) [CA3005](quality-rules/ca3005.md) [CA3006](quality-rules/ca3006.md) [CA3007](quality-rules/ca3007.md) [CA3008](quality-rules/ca3008.md) [CA3009](quality-rules/ca3009.md) [CA3010](quality-rules/ca3010.md) [CA3011](quality-rules/ca3011.md) [CA3012](quality-rules/ca3012.md) [CA5361](quality-rules/ca5361.md) [CA5376](quality-rules/ca5376.md) [CA5377](quality-rules/ca5377.md) [CA5378](quality-rules/ca5378.md) [CA5380](quality-rules/ca5380.md) [CA5381](quality-rules/ca5381.md) [CA5382](quality-rules/ca5382.md) [CA5383](quality-rules/ca5383.md) [CA5384](quality-rules/ca5384.md) [CA5387](quality-rules/ca5387.md) [CA5388](quality-rules/ca5388.md) [CA5389](quality-rules/ca5389.md) [CA5390](quality-rules/ca5390.md) [CA5399](quality-rules/ca5399.md) [CA5400](quality-rules/ca5400.md) |

### disallowed_symbol_names

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Names of symbols that are disallowed in the context of the analysis | Allowed symbol name formats (separated by \|):<br/> - Symbol name only (includes all symbols with the name, regardless of the containing type or namespace)<br/> - Fully qualified names in the symbol's [documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format). Each symbol name requires a symbol kind prefix, such as `M:` prefix for methods, `T:` prefix for types, and `N:` prefix for namespaces.<br/> - `.ctor` for constructors and `.cctor` for static constructors | None | [CA1031](quality-rules/ca1031.md) |

### exclude_ordefault_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Excludes `FirstOrDefault` and `LastOrDefault` methods from analysis. | `true` or `false` | `false` | [CA1826](quality-rules/ca1826.md) |

### ignore_internalsvisibleto

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Includes assemblies marked with <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> in analysis. | `true` or `false` | `true` | [CA1812](quality-rules/ca1812.md) [CA1852](quality-rules/ca1852.md) |

### try_determine_additional_string_formatting_methods_automatically

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Boolean option to enable heuristically detecting of additional string formatting methods <br/>A method is considered a string formatting method if it has a `string format` parameter followed by a `params object[]` parameter. | `true` or `false` | `false` | [CA2241](quality-rules/ca2241.md) |

### unsafe_DllImportSearchPath_bits

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Unsafe DllImportSearchPath bits when using DefaultDllImportSearchPaths attribute | Integer values of `System.Runtime.InteropServices.DllImportSearchPath` | `770` (i.e. `AssemblyDirectory | UseDllDirectoryForDependencies | ApplicationDirectory`) | [CA5393](quality-rules/ca5393.md) |

### exclude_aspnet_core_mvc_controllerbase

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Exclude ASP.NET Core MVC ControllerBase when considering CSRF | `true` or `false` | `true` | [CA5391](quality-rules/ca5391.md) |

### interprocedural_analysis_kind

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Interprocedural analysis Kind | - `None` - Skip interprocedural analysis for source method invocations.</br> - `NonContextSensitive` - Performs non-context sensitive interprocedural analysis for all source method invocations.</br> - `ContextSensitive` - Performs context sensitive interprocedural analysis for all source method invocations. | _Specific to each configurable rule_ |  |


### max_interprocedural_method_call_chain

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Maximum method call chain length to analyze for interprocedural dataflow analysis | Unsigned integer | `3` |  |

### max_interprocedural_lambda_or_local_function_call_chain

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Maximum lambda or local function call chain length to analyze for interprocedural dataflow analysis | Unsigned integer | `3` |  |

### dispose_analysis_kind

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Dispose analysis kind for IDisposable rules | - `AllPaths` - Track and report missing dispose violations on all paths (non-exception and exception paths). Additionally, also flag use of non-recommended dispose patterns that may cause potential dispose leaks.</br> - `AllPathsOnlyNotDisposed` - Track and report missing dispose violations on all paths (non-exception and exception paths). Do not flag use of non-recommended dispose patterns that may cause potential dispose leaks.</br> - `NonExceptionPaths` - Track and report missing dispose violations only on non-exception program paths. Additionally, also flag use of non-recommended dispose patterns that may cause potential dispose leaks.</br> - `NonExceptionPathsOnlyNotDisposed` - Track and report missing dispose violations only on non-exception program paths. Do not flag use of non-recommended dispose patterns that may cause potential dispose leaks. | NonExceptionPaths | [CA2000](quality-rules/ca2000.md) |

### dispose_ownership_transfer_at_constructor

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Configure dispose ownership transfer for arguments passed to constructor invocation | `true` or `false` | `false` | [CA2000](quality-rules/ca2000.md) |

For example, consider the below code:

```csharp
using System;

class A : IDisposable
{
    public void Dispose()
    {
    }
}

class Test
{
    DisposableOwnerType M1()
    {
        // Dispose ownership for allocation 'new A()' is assumed to be transferred to the returned 'DisposableOwnerType' instance
        // only if 'dotnet_code_quality.dispose_ownership_transfer_at_constructor = true'.
        // Otherwise, current method 'M1' has the dispose ownership for 'new A()', and it fires a CA2000 as a dispose leak for the below code.
        return new DisposableOwnerType(new A());
    }
}
```

### dispose_ownership_transfer_at_method_call

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Configure dispose ownership transfer for disposable objects passed as arguments to method calls | `true` or `false` | `false` | [CA2000](quality-rules/ca2000.md) |

For example, consider the below code:

```csharp
using System;

class Test
{
    void M1()
    {
        // Dispose ownership for allocation 'new A()' is assumed to be transferred to 'TransferDisposeOwnership' method
        // if 'dotnet_code_quality.dispose_ownership_transfer_at_method_call = true'.
        // Otherwise, current method 'M1' has the dispose ownership for 'new A()', and it fires a CA2000 as a dispose leak for the below code.
        TransferDisposeOwnership(new A());
    }
}
```

### points_to_analysis_kind

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Points to analysis kind for DFA rules based on PointsToAnalysis | - `None` - PointsToAnalysis is disabled.</br> - `PartialWithoutTrackingFieldsAndProperties` - Partial analysis that does not track PointsToData for fields and properties for improved performance.</br> - `Complete` - Complete analysis that also tracks PointsToData for fields and properties. | _Specific to each configurable rule_ | All DFA rules |

### copy_analysis

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Configure execution of Copy analysis (tracks value and reference copies) | `true` or `false` | `false` | _Specific to each configurable rule_ (`true` for most rules) |  |

### sufficient_IterationCount_for_weak_KDF_algorithm

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Configure sufficient IterationCount when using weak KDF algorithm | integral values | _Specific to each configurable rule_ (`100000` for most rules) |  |

### enum_values_prefix_trigger

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Do not prefix enum values with type name | - `AnyEnumValue` - The rule will be triggered if _any_ of the enum values starts with the enum type name.</br> - `AllEnumValues` - The rule will be triggered if _all_ of the enum values start with the enum type name.</br> - `Heuristic` - The rule will be triggered using the default FxCop heuristic (i.e. when at least 75% of the enum values start with the enum type name).</br> | `Heuristic` | [CA1712](quality-rules/ca1712.md) |

### exclude_indirect_base_types

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Exclude indirect base types | `true` or `false` | `true` | [CA1710](quality-rules/ca1710.md) |

```csharp
// An issue is always raised on this type because the suffix should be 'Exception'.
public class MyBaseClass : Exception, IEnumerable
{
   // code omitted for simplicity
}

// If the option is enabled no issue is raised on 'MyClass'; otherwise an issue will
// suggest to add the 'Exception' suffix.
public class MyClass : MyBaseClass
{
   // code omitted for simplicity
}
```

### additional_required_suffixes

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Additional required suffixes | List (separated by `\|`) of type names with their required suffix (separated by `->`). Allowed type name formats:</br> - Type name only (includes all types with the name, regardless of the containing type or namespace).</br> - Fully qualified names in the symbol's documentation ID format with an optional `T:` prefix.| None | [CA1710](quality-rules/ca1710.md) |

Examples:

| Option Value | Summary |
| --- | --- |
| `dotnet_code_quality.CA1710.additional_required_suffixes = MyClass->Class` | All types inheriting from `MyClass` are expected to have the `Class` suffix. |
| `dotnet_code_quality.CA1710.additional_required_suffixes = MyClass->Class\|MyNamespace.IPath->Path` | All types inheriting from `MyClass` are expected to have the `Class` suffix AND all types implementing `MyNamespace.IPath` are expected to have the `Path` suffix. |
| `dotnet_code_quality.CA1710.additional_required_suffixes = T:System.Data.IDataReader->{}` | Allows to override built-in suffixes, in this case, all types implementing `IDataReader` are no longer expected to end in `Collection`. |

### additional_required_generic_interfaces

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Additional required generic interfaces | List (separated by `\|`) of interface names with their required generic fully qualified interface (separated by `->`). Allowed interface formats:</br> - Interface name only (includes all interfaces with the name, regardless of the containing type or namespace).</br> - Fully qualified names in the symbol's documentation ID format with an optional `T:` prefix. | [CA1010](quality-rules/ca1010.md) |

Examples:

| Option Value | Summary |
| --- | --- |
| ``dotnet_code_quality.CA1010.additional_required_generic_interfaces = ISomething->System.Collections.Generic.IEnumerable`1`` | All types implementing `ISomething` regardless of its namespace are expected to also implement ``System.Collections.Generic.IEnumerable\`1``. |
| ``dotnet_code_quality.CA1010.additional_required_generic_interfaces = T:System.Collections.IDictionary->T:System.Collections.Generic.IDictionary`2`` | All types implementing `System.Collections.IDictionary` are expected to also implement ``System.Collections.Generic.IDictionary`2``. |

### additional_inheritance_excluded_symbol_names

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Inheritance excluded type or namespace names | Names of types or namespaces (separated by `\|`), such that the type or type's namespace does not count in the inheritance hierarchy tree. Allowed type name formats:</br> - Type or namespace name (includes all types with the name, regardless of the containing type or namespace and all types whose namespace contains the name).</br> - Type or namespace name ending with a wildcard symbol (includes all types whose name starts with the given name, regardless of the containing type or namespace and all types whose namespace contains the name). </br> - | `N:System.*` (note that this value is always automatically added to the value provided)</br> - Fully qualified names in the symbol's documentation ID format with an optional `T:` prefix for types or `N:` prefix for namespaces.</br> - Fully qualified type or namespace name with an optional `T:` prefix for type or `N:` prefix for namespace and ending with the wildcard symbol (includes all types whose fully qualified name starts with the given suffix).| [CA1501](quality-rules/ca1501.md) |

Examples:

| Option Value | Summary |
| --- | --- |
| `dotnet_code_quality.CA1501.additional_inheritance_excluded_symbol_names = MyType` | Matches all types named `MyType` or whose containing namespace contains `MyType` and all types from the `System` namespace. |
| `dotnet_code_quality.CA1501.additional_inheritance_excluded_symbol_names = MyType1\|MyType2` | Matches all types named either `MyType1` or `MyType2` or whose containing namespace contains either `MyType1` or `MyType2` and all types from the `System` namespace. |
| `dotnet_code_quality.CA1501.additional_inheritance_excluded_symbol_names = T:NS.MyType` | Matches specific type `MyType` in the namespace `NS` and all types from the `System` namespace. |
| `dotnet_code_quality.CA1501.additional_inheritance_excluded_symbol_names = T:NS1.MyType1\|T:NS2.MyType2` | Matches specific types `MyType1` and `MyType2` with respective fully qualified names and all types from the `System` namespace. |
| `dotnet_code_quality.CA1501.additional_inheritance_excluded_symbol_names = N:NS` | Matches all types from the `NS` namespace and all types from the `System` namespace. |
| `dotnet_code_quality.CA1501.additional_inheritance_excluded_symbol_names = My*` | Matches all types whose name starts with `My` or whose containing namespace parts starts with `My` and all types from the `System` namespace. |
| `dotnet_code_quality.CA1501.additional_inheritance_excluded_symbol_names = T:NS.My*` | Matches all types whose name starts with `My` in the namespace `NS` and all types from the `System` namespace. |
| `dotnet_code_quality.CA1501.additional_inheritance_excluded_symbol_names = N:My*` | Matches all types whose containing namespace starts with `My` and all types from the `System` namespace. |

### analyzed_symbol_kinds

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Analyzed symbol kinds | One or more fields of enum Microsoft.CodeAnalysis.SymbolKind as a comma separated list. | `Namespace, NamedType, Method, Property, Event, Parameter` | [CA1716](quality-rules/ca1716.md) |

### use_naming_heuristic

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Use naming heuristic | `true` or `false` | `false` | [CA1303](quality-rules/ca1303.md) |

### additional_use_results_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Additional use results methods | Names of additional methods (separated by `\|`). Allowed method name formats:</br> - Method name only (includes all methods with the name, regardless of the containing type or namespace).</br> - Fully qualified names in the symbol's documentation ID format with an optional `M:` prefix. | None | [CA1806](quality-rules/ca1806.md) |


Examples:

| Option Value | Summary |
| --- | --- |
| `dotnet_code_quality.CA1806.additional_use_results_methods = MyMethod` | Matches all methods named `MyMethod` in the compilation. |
| `dotnet_code_quality.CA1806.additional_use_results_methods = MyMethod1\|MyMethod2` | Matches all methods named either `MyMethod1` or `MyMethod2` in the compilation. |
| `dotnet_code_quality.CA1806.additional_use_results_methods = M:NS.MyType.MyMethod(ParamType)` | Matches specific method `MyMethod` with given fully qualified signature. |
| `dotnet_code_quality.CA1806.additional_use_results_methods = M:NS1.MyType1.MyMethod1(ParamType)\|M:NS2.MyType2.MyMethod2(ParamType)` | Matches specific methods `MyMethod1` and `MyMethod2` with respective fully qualified signature. |


### allowed_suffixes

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Allowed suffixes | List (separated by `\|`) of allowed suffixes. |  | [CA1711](quality-rules/ca1711.md) |

### enable_platform_analyzer_on_pre_net5_target

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Enable platform compatibility analyzer for TFMs <= net5.0 | `true` or `false` | `false` | [CA1416](quality-rules/ca1416.md) |

### exclude_structs

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Exclude structs | `true` or `false` | `false` | [CA1051](quality-rules/ca1051.md) |

### additional_enum_none_names

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Additional enum `None` names | Names of additional enum None names (separated by `\|`). | empty | [CA1008](quality-rules/ca1008.md) |

Example:
```
dotnet_code_quality.CA1008.additional_enum_none_names = Never
dotnet_code_quality.CA1008.additional_enum_none_names = Never|Nothing
```

### enumeration_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Enumeration methods | Fully qualified names of additional methods enumerating all parameters with IEnumerable type (separated by `\|`). | empty | [CA1851](quality-rules/ca1851.md) |

Example:

```
dotnet_code_quality.CA1851.enumeration_methods = M:NS.Cls.SomeMethod(System.Collections.Generic.IEnumerable{System.Int32})
dotnet_code_quality.CA1851.enumeration_methods = M:NS.Cls.SomeMethod*
M:NS.Cls.SomeMethod``1(System.Collections.Generic.IEnumerable{System.Int32}) | M:NS.Cls.OtherMethod*
```

### linq_chain_methods

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| This option is used to include customized methods like `Select` into the analysis scope. | Fully qualified names of additional methods accepting IEnumerable parameters and return a new IEnumerable type instance(separated by `\|`). By default, the IEnumerable type parameters of the Linq Chain method are considered not enumerated. This behavior could be overridden by combining using the `enumeration_methods` option. | empty | [CA1851](quality-rules/ca1851.md) |

### assume_method_enumerates_parameters

| Description | Allowable values | Default value | Configurable rules |
| - | - | - | - |
| Assume method enumerates parameters | `true` or `false` | `false` | [CA1851](quality-rules/ca1851.md) |
