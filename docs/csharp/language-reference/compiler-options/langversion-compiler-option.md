---
description: "-langversion (C# Compiler Options)"
title: "-langversion (C# Compiler Options)"
ms.date: 05/20/2020
f1_keywords:
  - "/langversion"
helpviewer_keywords:
  - "/langversion compiler option [C#]"
  - "-langversion compiler option [C#]"
  - "langversion compiler option [C#]"
ms.custom: "updateeachrelease"
ms.assetid: 3fb00b05-a0ff-4782-b313-13a4c0f62d94
---
# -langversion (C# Compiler Options)

Causes the compiler to accept only syntax that is included in the chosen C# language specification.

## Syntax

```console
-langversion:option
```

## Arguments

`option`

The following values are valid:

[!INCLUDE [lang-versions-table](../includes/langversion-table.md)]

The default language version depends on the target framework for your application and the version of the SDK or Visual Studio installed. Those rules are defined in the [configuring the language version](../configure-language-version.md#defaults) article.

## Remarks

Metadata referenced by your C# application is not subject to **-langversion** compiler option.

Because each version of the C# compiler contains extensions to the language specification, **-langversion** does not give you the equivalent functionality of an earlier version of the compiler.

Additionally, while C# version updates generally coincide with major .NET Framework releases, the new syntax and features are not necessarily tied to that specific framework version. While the new features definitely require a new compiler update that is also released alongside the C# revision, each specific feature has its own minimum .NET API or common language runtime requirements that may allow it to run on downlevel frameworks by including NuGet packages or other libraries.

Regardless of which **-langversion** setting you use, use the current version of the common language runtime to create your .exe or .dll. One exception is friend assemblies and [-moduleassemblyname (C# Compiler Option)](./moduleassemblyname-compiler-option.md), which work under **-langversion:ISO-1**.

For other ways to specify the C# language version, see the [Select the C# language version](../configure-language-version.md) article.

For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.LanguageVersion%2A>.

## C# language specification

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

## Minimum SDK version needed to support all language features

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

## See also

- [C# Compiler Options](index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
