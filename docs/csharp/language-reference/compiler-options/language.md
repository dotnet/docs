---
description: "C# Compiler Options for language feature rules"
title: "C# Compiler Options - language feature rules"
ms.date: 02/28/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "CheckForOverflowUnderflow compiler option [C#]"
  - "AllowUnsafeBlocks compiler option [C#]"
  - "DefineConstants compiler option [C#]"
  - "LangVersion compiler option [C#]"
---
# C# Compiler Options for language feature rules

The following options control compiler inputs. The new MSBuild syntax is shown in **Bold**. The older `csc.exe` syntax is shown in `code style`.

- **CheckForOverflowUnderflow** / `-checked`: Generate overflow checks.
- **AllowUnsafeBlocks** / `-unsafe` : Allow 'unsafe' code.
- **DefineConstants** / `-define`: Define conditional compilation symbol(s).
- **LangVersion** / `-langversion`: Specify language version such as `default` (latest major version), or latest (latest version, including minor versions)

## CheckForOverflowUnderflow

The **CheckForOverflowUnderflow** option specifies whether an integer arithmetic statement that results in a value that is outside the range of the data type, and that is not in the scope of a [checked](../keywords/checked.md) or [unchecked](../keywords/unchecked.md) keyword, causes a run-time exception.  

```xml
<CheckForOverflowUnderflow>true</CheckForOverflowUnderflow>
```

An integer arithmetic statement that is in the scope of a `checked` or `unchecked` keyword is not subject to the effect of the **CheckForOverflowUnderflow** option. If an integer arithmetic statement that is not in the scope of a `checked` or `unchecked` keyword results in a value outside the range of the data type, and **CheckForOverflowUnderflow+** (or **CheckForOverflowUnderflow**) is used in the compilation, that statement causes an exception at run time. If **CheckForOverflowUnderflow-** is used in the compilation, that statement does not cause an exception at run time. The default value for this option is **CheckForOverflowUnderflow-**; overflow checking is disabled.

## AllowUnsafeBlocks

The **AllowUnsafeBlocks** compiler option allows code that uses the [unsafe](../keywords/unsafe.md) keyword to compile.

```xml
<AllowUnsafeBlocks>true</AllowUnsafeBlocks>
```

For more information about unsafe code, see [Unsafe Code and Pointers](../../programming-guide/unsafe-code-pointers/index.md).

## DefineConstants

The **DefineConstants** option defines `name` as a symbol in all source code files your program.

```xml
<DefineConstants>name;name2</DefineConstants>
```

`name`, `name2` are the name of one or more symbols that you want to define. The **DefineConstants** option has the same effect as using a [#define](../preprocessor-directives/preprocessor-define.md) preprocessor directive except that the compiler option is in effect for all files in the project. A symbol remains defined in a source file until an [#undef](../preprocessor-directives/preprocessor-undef.md) directive in the source file removes the definition. When you use the -define option, an `#undef` directive in one file has no effect on other source code files in the project. You can use symbols created by this option with [#if](../preprocessor-directives/preprocessor-if.md), [#else](../preprocessor-directives/preprocessor-else.md), [#elif](../preprocessor-directives/preprocessor-elif.md), and [#endif](../preprocessor-directives/preprocessor-endif.md) to compile source files conditionally. The C# compiler itself defines no symbols or macros that you can use in your source code; all symbol definitions must be user-defined.

> [!NOTE]
> The C# `#define` does not allow a symbol to be given a value, as in languages such as C++. For example, `#define` cannot be used to create a macro or to define a constant. If you need to define a constant, use an `enum` variable. If you want to create a C++ style macro, consider alternatives such as generics. Since macros are notoriously error-prone, C# disallows their use but provides safer alternatives.

## LangVersion

Causes the compiler to accept only syntax that is included in the chosen C# language specification.

```xml
<LangVersion>9.0</LangVersion>
```

The following values are valid:

[!INCLUDE [lang-versions-table](../includes/langversion-table.md)]

The default language version depends on the target framework for your application and the version of the SDK or Visual Studio installed. Those rules are defined in the [configuring the language version](../configure-language-version.md#defaults) article.

Metadata referenced by your C# application is not subject to **LangVersion** compiler option. Because each version of the C# compiler contains extensions to the language specification, **LangVersion** does not give you the equivalent functionality of an earlier version of the compiler.

Additionally, while C# version updates generally coincide with major .NET Framework releases, the new syntax and features are not necessarily tied to that specific framework version. While the new features definitely require a new compiler update that is also released alongside the C# revision, each specific feature has its own minimum .NET API or common language runtime requirements that may allow it to run on downlevel frameworks by including NuGet packages or other libraries.

Regardless of which **LangVersion** setting you use, use the current version of the common language runtime to create your .exe or .dll. One exception is friend assemblies and [-moduleassemblyname (C# Compiler Option)](./moduleassemblyname-compiler-option.md), which work under **-langversion:ISO-1**.

For other ways to specify the C# language version, see the [Select the C# language version](../configure-language-version.md) article.

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
