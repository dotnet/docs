---
description: "C# Compiler Options for language feature rules. These options control how the compiler interprets certain language constructs."
title: "C# Compiler Options - language feature rules"
ms.date: 07/06/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "CheckForOverflowUnderflow compiler option [C#]"
  - "AllowUnsafeBlocks compiler option [C#]"
  - "DefineConstants compiler option [C#]"
  - "LangVersion compiler option [C#]"
  - "Nullable compiler option [C#]"
---
# C# Compiler Options for language feature rules

The following options control how the compiler interprets language features. The new MSBuild syntax is shown in **Bold**. The older *csc.exe* syntax is shown in `code style`.

- **CheckForOverflowUnderflow** / `-checked`: Generate overflow checks.
- **AllowUnsafeBlocks** / `-unsafe`: Allow 'unsafe' code.
- **DefineConstants** / `-define`: Define conditional compilation symbol(s).
- **LangVersion** / `-langversion`: Specify language version such as `default` (latest major version), or `latest` (latest version, including minor versions).
- **Nullable** / `-nullable`: Enable nullable context, or nullable warnings.

## CheckForOverflowUnderflow

The **CheckForOverflowUnderflow** option specifies whether an integer arithmetic statement that results in a value that is outside the range of the data type causes a run-time exception.  

```xml
<CheckForOverflowUnderflow>true</CheckForOverflowUnderflow>
```

An integer arithmetic statement that is in the scope of a `checked` or `unchecked` keyword isn't subject to the effect of the **CheckForOverflowUnderflow** option. If an integer arithmetic statement that isn't in the scope of a `checked` or `unchecked` keyword results in a value outside the range of the data type, and **CheckForOverflowUnderflow** is `true`, that statement causes an exception at run time. If **CheckForOverflowUnderflow** is `false`, that statement doesn't cause an exception at run time. The default value for this option is `false`; overflow checking is disabled.

## AllowUnsafeBlocks

The **AllowUnsafeBlocks** compiler option allows code that uses the [unsafe](../keywords/unsafe.md) keyword to compile. The default value for this option is `false`, meaning unsafe code is not allowed.

```xml
<AllowUnsafeBlocks>true</AllowUnsafeBlocks>
```

For more information about unsafe code, see [Unsafe Code and Pointers](../unsafe-code.md).

## DefineConstants

The **DefineConstants** option defines symbols in all source code files of your program.

```xml
<DefineConstants>name;name2</DefineConstants>
```

This option specifies the names of one or more symbols that you want to define. The **DefineConstants** option has the same effect as the [#define](../preprocessor-directives.md#defining-symbols) preprocessor directive except that the compiler option is in effect for all files in the project. A symbol remains defined in a source file until an [#undef](../preprocessor-directives.md#defining-symbols) directive in the source file removes the definition. When you use the `-define` option, an `#undef` directive in one file has no effect on other source code files in the project. You can use symbols created by this option with [#if](../preprocessor-directives.md#conditional-compilation), [#else](../preprocessor-directives.md), [#elif](../preprocessor-directives.md#conditional-compilation), and [#endif](../preprocessor-directives.md#conditional-compilation) to compile source files conditionally. The C# compiler itself defines no symbols or macros that you can use in your source code; all symbol definitions must be user-defined.

> [!NOTE]
> The C# `#define` directive does not allow a symbol to be given a value, as in languages such as C++. For example, `#define` cannot be used to create a macro or to define a constant. If you need to define a constant, use an `enum` variable. If you want to create a C++ style macro, consider alternatives such as generics. Since macros are notoriously error-prone, C# disallows their use but provides safer alternatives.

## LangVersion

Causes the compiler to accept only syntax that is included in the chosen C# language specification.

```xml
<LangVersion>9.0</LangVersion>
```

The following values are valid:

[!INCLUDE [lang-versions-table](../includes/langversion-table.md)]

The default language version depends on the target framework for your application and the version of the SDK or Visual Studio installed. Those rules are defined in [C# language versioning](../configure-language-version.md#defaults).

Metadata referenced by your C# application isn't subject to the **LangVersion** compiler option.

Because each version of the C# compiler contains extensions to the language specification, **LangVersion** doesn't give you the equivalent functionality of an earlier version of the compiler.

Additionally, while C# version updates generally coincide with major .NET Framework releases, the new syntax and features aren't necessarily tied to that specific framework version. While the new features definitely require a new compiler update that is also released alongside the C# revision, each specific feature has its own minimum .NET API or common language runtime requirements that may allow it to run on downlevel frameworks by including NuGet packages or other libraries.

Regardless of which **LangVersion** setting you use, use the current version of the common language runtime to create your .exe or .dll. One exception is friend assemblies and [**ModuleAssemblyName**](advanced.md#moduleassemblyname), which work under **-langversion:ISO-1**.

For other ways to specify the C# language version, see [C# language versioning](../configure-language-version.md).

For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.LanguageVersion%2A>.

### C# language specification

| Version          | Link                       | Description                                                             |
|------------------|----------------------------|-------------------------------------------------------------------------|
| C# 7.0 and later |                            | Not currently available                                                 |
| C# 6.0           | [Link][csharp-6]           | C# Language Specification Version 6 - Unofficial Draft: .NET Foundation |
| C# 5.0           | [Download PDF][csharp-5]   | Standard ECMA-334 5th Edition                                           |
| C# 3.0           | [Download DOC][csharp-3]   | C# Language Specification Version 3.0: Microsoft Corporation            |
| C# 2.0           | [Download PDF][csharp-2]   | Standard ECMA-334 4th Edition                                           |
| C# 1.2           | [Download DOC][csharp-1.2] | C# Language Specification Version 1.2: Microsoft Corporation            |
| C# 1.0           | [Download DOC][csharp-1]   | C# Language Specification Version 1.0: Microsoft Corporation            |

[csharp-6]: /dotnet/csharp/language-reference/language-specification/introduction
[csharp-5]: https://www.ecma-international.org/publications/files/ECMA-ST/ECMA-334.pdf
[csharp-3]: https://download.microsoft.com/download/3/8/8/388e7205-bc10-4226-b2a8-75351c669b09/CSharp%20Language%20Specification.doc
[csharp-2]: https://www.ecma-international.org/publications/files/ECMA-ST-ARCH/ECMA-334%204th%20edition%20June%202006.pdf
[csharp-1.2]: https://www.ecma-international.org/publications/files/ECMA-ST-ARCH/ECMA-334%202nd%20edition%20December%202002.pdf
[csharp-1]: https://www.ecma-international.org/publications/files/ECMA-ST-ARCH/ECMA-334%201st%20edition%20December%202001.pdf

### Minimum SDK version needed to support all language features

The following table lists the minimum versions of the SDK with the C# compiler that supports the corresponding language version:

| C# version | Minimum SDK version                                                                  |
|------------|--------------------------------------------------------------------------------------|
| C# 10     | Microsoft Visual Studio/Build Tools 2022, or .NET 6 SDK                              |
| C# 9.0     | Microsoft Visual Studio/Build Tools 2019, version 16.8, or .NET 5 SDK              |
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

The **Nullable** option lets you specify the nullable context.  The default value for this option is `disable`.

```xml
<Nullable>enable</Nullable>
```

The argument must be one of `enable`, `disable`, `warnings`, or `annotations`. The `enable` argument enables the nullable context. Specifying `disable` will disable the nullable context. When providing the `warnings` argument the nullable warning context is enabled. When specifying the `annotations` argument, the nullable annotation context is enabled.

Flow analysis is used to infer the nullability of variables within executable code. The inferred nullability of a variable is independent of the variable's declared nullability. Method calls are analyzed even when they're conditionally omitted. For instance, <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType> in release mode.

Invocation of methods annotated with the following attributes will also affect flow analysis:

- Simple pre-conditions: <xref:System.Diagnostics.CodeAnalysis.AllowNullAttribute> and <xref:System.Diagnostics.CodeAnalysis.DisallowNullAttribute>
- Simple post-conditions: <xref:System.Diagnostics.CodeAnalysis.MaybeNullAttribute> and <xref:System.Diagnostics.CodeAnalysis.NotNullAttribute>
- Conditional post-conditions: <xref:System.Diagnostics.CodeAnalysis.MaybeNullWhenAttribute> and <xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute>
- <xref:System.Diagnostics.CodeAnalysis.DoesNotReturnIfAttribute> (for example, `DoesNotReturnIf(false)` for <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType>) and <xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute>
- <xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute>
- Member post-conditions: <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.%23ctor(System.String)> and <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.%23ctor(System.String[])>

> [!IMPORTANT]
> The global nullable context does not apply for generated code files. Regardless of this setting, the nullable context is *disabled* for any source file marked as generated. There are four ways a file is marked as generated:
>
> 1. In the .editorconfig, specify `generated_code = true` in a section that applies to that file.
> 1. Put `<auto-generated>` or `<auto-generated/>` in a comment at the top of the file. It can be on any line in that comment, but the comment block must be the first element in the file.
> 1. Start the file name with *TemporaryGeneratedFile_*
> 1. End the file name with *.designer.cs*, *.generated.cs*, *.g.cs*, or *.g.i.cs*.
>
> Generators can opt-in using the [`#nullable`](../preprocessor-directives.md#nullable-context) preprocessor directive.
