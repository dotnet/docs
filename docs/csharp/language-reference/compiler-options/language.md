---
description: "C# Compiler Options for language feature rules. These options control how the compiler interprets certain language constructs."
title: "Compiler Options - language feature rules"
ms.date: 09/10/2026
ai-usage: ai-assisted
f1_keywords:
  - "cs.build.options"
helpviewer_keywords:
  - "CheckForOverflowUnderflow compiler option [C#]"
  - "AllowUnsafeBlocks compiler option [C#]"
  - "DefineConstants compiler option [C#]"
  - "LangVersion compiler option [C#]"
  - "Nullable compiler option [C#]"
---
# C# compiler options for language feature rules

The following options control how the compiler interprets language features. The new MSBuild syntax is shown in **Bold**. The older *csc.exe* syntax is shown in `code style`.

- **CheckForOverflowUnderflow** / `-checked`: Generate overflow checks.
- **AllowUnsafeBlocks** / `-unsafe`: Allow `unsafe` code.
- **DefineConstants** / `-define`: Define conditional compilation symbols.
- **LangVersion** / `-langversion`: Specify language version such as `default` (latest major version), or `latest` (latest version, including minor versions).
- **Nullable** / `-nullable`: Enable nullable context, or nullable warnings.

> [!NOTE]
> For more information about configuring these options for your project, see [Compiler options](index.md#how-to-set-options).

## CheckForOverflowUnderflow

The **CheckForOverflowUnderflow** option controls the default overflow-checking context that defines the program behavior if integer arithmetic overflows.

```xml
<CheckForOverflowUnderflow>true</CheckForOverflowUnderflow>
```

When **CheckForOverflowUnderflow** is `true`, the default context is a checked context and overflow checking is enabled. When **CheckForOverflowUnderflow** is `false`, the default context is an unchecked context. The default value for this option is `false`, which means overflow checking is disabled.

You can also explicitly control the overflow-checking context for parts of your code by using the `checked` and `unchecked` statements.

For information about how the overflow-checking context affects operations and what operations it affects, see the [article about `checked` and `unchecked` statements](../statements/checked-and-unchecked.md).

## AllowUnsafeBlocks

The **AllowUnsafeBlocks** compiler option allows code that uses the [unsafe](../keywords/unsafe.md) keyword to compile. The default value for this option is `false`, meaning unsafe code isn't allowed.

```xml
<AllowUnsafeBlocks>true</AllowUnsafeBlocks>
```

For more information about unsafe code, see [Unsafe Code and Pointers](../unsafe-code.md).

### Enable the updated memory safety rules

The updated memory safety rules are a preview feature in C# 15 and .NET 11. They use two independent compiler settings:

- The `preview` language version enables the new syntax and pointer relaxations.
- The `updated-memory-safety-rules` compiler feature enables the updated rules, including *requires-unsafe* caller obligations, and causes the compiler to record the choice in the assembly with the <xref:System.Runtime.CompilerServices.MemorySafetyRulesAttribute> attribute.

A future stable SDK property, `MemorySafetyRules`, is planned as a third activation tier for when the feature exits preview (for example, `<MemorySafetyRules>2</MemorySafetyRules>`), but that property isn't implemented yet.

For a project, use both settings:

```xml
<PropertyGroup>
  <LangVersion>preview</LangVersion>
  <Features>$(Features);updated-memory-safety-rules</Features>
</PropertyGroup>
```

For a file-based program, add the equivalent directives:

```csharp
#:property Features=$(Features);updated-memory-safety-rules
#:property LangVersion=preview
```

The **AllowUnsafeBlocks** property is independent. It controls whether the source can use the `unsafe` keyword. A project can enable the updated rules without allowing unsafe code, in which case it receives errors when it calls requires-unsafe APIs.

Whether one assembly enforces the updated rules against another depends on which side opts in:

- **Updated-model caller, updated-model callee**: The callee's `unsafe` markers travel through metadata. The caller wraps each call to a requires-unsafe member in an `unsafe` block.
- **Updated-model caller, original-model callee**: A compatibility mode treats any callee member with a pointer type in its signature as requires-unsafe, so the call site needs an enclosing `unsafe` block. This mode keeps a pointer-based API from silently losing its `unsafe` requirement.
- **Original-model caller, updated-model callee**: The original pointer rules still apply. A requires-unsafe member that has no pointer type in its signature becomes callable from safe code, because the original-model caller can't read the new markers.

## DefineConstants

The **DefineConstants** option defines symbols in all source code files of your program.

```xml
<DefineConstants>name;name2</DefineConstants>
```

This option specifies the names of one or more symbols that you want to define. The **DefineConstants** option has the same effect as the [#define](../preprocessor-directives.md#defining-symbols) preprocessor directive except that the compiler option is in effect for all files in the project. A symbol remains defined in a source file until an [#undef](../preprocessor-directives.md#defining-symbols) directive in the source file removes the definition. When you use the `-define` option, an `#undef` directive in one file has no effect on other source code files in the project. You can use symbols created by this option with [#if](../preprocessor-directives.md#conditional-compilation), [#else](../preprocessor-directives.md), [#elif](../preprocessor-directives.md#conditional-compilation), and [#endif](../preprocessor-directives.md#conditional-compilation) to compile source files conditionally. The C# compiler itself defines no symbols or macros that you can use in your source code; all symbol definitions must be user-defined.

> [!NOTE]
> The C# `#define` directive doesn't allow a symbol to have a value, as in languages such as C++. For example, `#define` can't create a macro or define a constant. If you need to define a constant, use an `enum` variable. If you want to create a C++-style macro, consider alternatives such as generics. Since macros are notoriously error-prone, C# disallows their use but provides safer alternatives.

## LangVersion

The default language version for the C# compiler depends on the target framework for your application and the version of the SDK or Visual Studio installed. Those rules are defined in [C# language versioning](../language-versioning.md#defaults).

> [!WARNING]
>
> Don't set the `LangVersion` element to `latest`. The `latest` setting means the installed compiler uses its latest version. That version can change from machine to machine, making builds unreliable. In addition, it enables language features that might require runtime or library features that aren't included in the current SDK.

The **LangVersion** option causes the compiler to accept only syntax that's included in the specified C# language specification, for example:

```xml
<LangVersion>9.0</LangVersion>
```

Some preview features require a separate opt-in in addition to `<LangVersion>preview</LangVersion>`. For example, the C# 15 updated memory safety rules use the `updated-memory-safety-rules` compiler feature. For more information, see [Enable the updated memory safety rules](#enable-the-updated-memory-safety-rules).

The following values are valid:

[!INCLUDE [lang-versions-table](../includes/langversion-table.md)]

### Considerations

- To ensure that your project uses the default compiler version recommended for your target framework, don't use the **LangVersion** option. Update the target framework to access newer language features.

- Specifying **LangVersion** with the `default` value is different from omitting the **LangVersion** option. Specifying `default` uses the latest version of the language that the compiler supports, without taking into account the target framework. For example, building a project that targets .NET 6 from Visual Studio version 17.6 uses C# 10 if **LangVersion** isn't specified, but uses C# 11 if **LangVersion** is set to `default`.

- The **LangVersion** compiler option doesn't affect metadata referenced by your C# application.

- Because each version of the C# compiler contains extensions to the language specification, **LangVersion** doesn't give you the equivalent functionality of an earlier version of the compiler.

- While C# version updates generally coincide with major .NET releases, the new syntax and features aren't necessarily tied to that specific framework version. Each specific feature has its own minimum .NET API or common language runtime requirements that might allow it to run on down-level frameworks by including NuGet packages or other libraries.

- Regardless of which **LangVersion** setting you use, use the current version of the common language runtime to create your *.exe* or *.dll*. One exception is friend assemblies and [ModuleAssemblyName](advanced.md#moduleassemblyname), which work under **-langversion:ISO-1**.

For other ways to specify the C# language version, see [C# language versioning](../configure-language-version.md).

For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.LanguageVersion*>.

### C# language specification

| Version          | Link                       | Description                                                  |
|------------------|----------------------------|--------------------------------------------------------------|
| C# 8.0 and later | [download PDF][csharp-8]   | C# Language Specification Version 7: .NET Foundation         |
| C# 7.3           | [download PDF][csharp-7]   | Standard ECMA-334 7th Edition                                |
| C# 6.0           | [download PDF][csharp-6]   | Standard ECMA-334 6th Edition                                |
| C# 5.0           | [Download PDF][csharp-5]   | Standard ECMA-334 5th Edition                                |
| C# 3.0           | [Download DOC][csharp-3]   | C# Language Specification Version 3.0: Microsoft Corporation |
| C# 2.0           | [Download PDF][csharp-2]   | Standard ECMA-334 4th Edition                                |
| C# 1.2           | [Download DOC][csharp-1.2] | Standard ECMA-334 2nd Edition                                |
| C# 1.0           | [Download DOC][csharp-1]   | Standard ECMA-334 1st Edition                                |

[csharp-8]: /dotnet/csharp/language-reference/language-specification/introduction
[csharp-7]: https://ecma-international.org/wp-content/uploads/ECMA-334_7th_edition_december_2023.pdf
[csharp-6]: https://www.ecma-international.org/wp-content/uploads/ECMA-334_6th_edition_june_2022.pdf
[csharp-5]: https://www.ecma-international.org/wp-content/uploads/ECMA-334_5th_edition_december_2017.pdf
[csharp-3]: https://download.microsoft.com/download/3/8/8/388e7205-bc10-4226-b2a8-75351c669b09/CSharp%20Language%20Specification.doc
[csharp-2]: https://www.ecma-international.org/wp-content/uploads/ECMA-334_4th_edition_june_2006.pdf
[csharp-1.2]: https://www.ecma-international.org/wp-content/uploads/ECMA-334_2nd_edition_december_2002.pdf
[csharp-1]: https://www.ecma-international.org/wp-content/uploads/ECMA-334_1st_edition_december_2001.pdf

### Minimum SDK version needed to support all language features

The following table lists the minimum versions of the SDK with the C# compiler that supports the corresponding language version:

| C# version | Minimum SDK version                                                                  |
|------------|--------------------------------------------------------------------------------------|
| C# 12      | Microsoft Visual Studio/Build Tools 2022 version 17.8, or .NET 8 SDK                 |
| C# 11      | Microsoft Visual Studio/Build Tools 2022 version 17.4, or .NET 7 SDK                 |
| C# 10      | Microsoft Visual Studio/Build Tools 2022, or .NET 6 SDK                              |
| C# 9.0     | Microsoft Visual Studio/Build Tools 2019 version 16.8, or .NET 5 SDK                 |
| C# 8.0     | Microsoft Visual Studio/Build Tools 2019, version 16.3, or .NET Core 3.0 SDK         |
| C# 7.3     | Microsoft Visual Studio/Build Tools 2017, version 15.7                               |
| C# 7.2     | Microsoft Visual Studio/Build Tools 2017, version 15.5                               |
| C# 7.1     | Microsoft Visual Studio/Build Tools 2017, version 15.3                               |
| C# 7.0     | Microsoft Visual Studio/Build Tools 2017                                             |
| C# 6       | Microsoft Visual Studio/Build Tools 2015                                             |
| C# 5       | Microsoft Visual Studio/Build Tools 2012 or bundled .NET Framework 4.5 compiler      |
| C# 4       | Microsoft Visual Studio/Build Tools 2010 or bundled .NET Framework 4.0 compiler      |
| C# 3       | Microsoft Visual Studio/Build Tools 2008 or bundled .NET Framework 3.5 compiler      |
| C# 2       | Microsoft Visual Studio/Build Tools 2005 or bundled .NET Framework 2.0 compiler      |
| C# 1.0/1.2 | Microsoft Visual Studio/Build Tools .NET 2002 or bundled .NET Framework 1.0 compiler |

## Nullable

Use the **Nullable** option to specify the nullable context. Set it in the project's configuration by using the `<Nullable>` tag:

```xml
<Nullable>enable</Nullable>
```

The argument must be one of `enable`, `disable`, `warnings`, or `annotations`. The `enable` argument turns on the nullable context. The `disable` argument turns off the nullable context. The `warnings` argument turns on the nullable warning context. The `annotations` argument turns on the nullable annotation context. For more information about these values, see [Nullable contexts](../builtin-types/nullable-reference-types.md#nullable-context). To learn more about enabling nullable reference types in an existing codebase, see [nullable migration strategies](../../advanced-topics/update-applications/nullable-migration-strategies.md).

> [!NOTE]
> If you don't set a value, the default value is `disable`. However, .NET 6 and newer templates set the **Nullable** value to `enable` by default.

Flow analysis infers the nullability of variables within executable code. The inferred nullability of a variable is independent of the variable's declared nullability. The compiler analyzes method calls even when the call is conditionally omitted from the compiled output. For example, the compiler still analyzes a call to <xref:System.Diagnostics.Debug.Assert*?displayProperty=nameWithType> for nullability even though the call is conditional and isn't compiled into release builds.

Invocation of methods annotated with the following attributes also affects flow analysis:

- Simple preconditions: <xref:System.Diagnostics.CodeAnalysis.AllowNullAttribute> and <xref:System.Diagnostics.CodeAnalysis.DisallowNullAttribute>
- Simple postconditions: <xref:System.Diagnostics.CodeAnalysis.MaybeNullAttribute> and <xref:System.Diagnostics.CodeAnalysis.NotNullAttribute>
- Conditional postconditions: <xref:System.Diagnostics.CodeAnalysis.MaybeNullWhenAttribute> and <xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute>
- <xref:System.Diagnostics.CodeAnalysis.DoesNotReturnIfAttribute> (for example, `DoesNotReturnIf(false)` for <xref:System.Diagnostics.Debug.Assert*?displayProperty=nameWithType>) and <xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute>
- <xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute>
- Member postconditions: <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.%23ctor(System.String)> and <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.%23ctor(System.String[])>

> [!IMPORTANT]
> The global nullable context doesn't apply to generated code files. Regardless of this setting, the nullable context is *disabled* for any source file marked as generated. A file is marked as generated in one of the following ways:
>
> 1. In the .editorconfig, specify `generated_code = true` in a section that applies to that file.
> 1. Include `<auto-generated>` or `<auto-generated/>` in a comment at the top of the file. You can place it on any line in the comment, but the comment block must be the first element in the file.
> 1. Start the file name with *TemporaryGeneratedFile_*
> 1. End the file name with *.designer.cs*, *.generated.cs*, *.g.cs*, or *.g.i.cs*.
>
> Generators can opt in by using the [`#nullable`](../preprocessor-directives.md#nullable-context) preprocessor directive.
