---
title: "-langversion (C# Compiler Options)"
ms.date: 08/23/2019
f1_keywords: 
  - "/langversion"
helpviewer_keywords: 
  - "/langversion compiler option [C#]"
  - "-langversion compiler option [C#]"
  - "langversion compiler option [C#]"
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
  
|Option|Meaning|  
|------------|-------------|  
|preview|The compiler accepts all valid language syntax from the latest preview version that it can support.|
|latest|The compiler accepts all valid language syntax from the latest version (including minor releases) that it can support.|
|latestMajor|The compiler accepts all valid language syntax from the latest major version that it can support.|
|8.0|The compiler accepts only syntax that is included in C# 8.0 or lower 
|7.3|The compiler accepts only syntax that is included in C# 7.3 or lower
|7.2|The compiler accepts only syntax that is included in C# 7.2 or lower
|7.1|The compiler accepts only syntax that is included in C# 7.1 or lower
|7|The compiler accepts only syntax that is included in C# 7.0 or lower
|6|The compiler accepts only syntax that is included in C# 6.0 or lower
|5|The compiler accepts only syntax that is included in C# 5.0 or lower
|4|The compiler accepts only syntax that is included in C# 4.0 or lower
|3|The compiler accepts only syntax that is included in C# 3.0 or lower
|ISO-2|The compiler accepts only syntax that is included in ISO/IEC 23270:2006 C# (2.0)
|ISO-1|The compiler accepts only syntax that is included in ISO/IEC 23270:2003 C# (1.0/1.2)

The default language version depends on the target framework for your application and the version of the SDK or Visual Studio installed. Those rules are defined in the article on [configuring the language version](../configure-language-version.md#defaults)

## Remarks

 Metadata referenced by your C# application is not subject to **-langversion** compiler option.  
  
 Because each version of the C# compiler contains extensions to the language specification, **-langversion** does not give you the equivalent functionality of an earlier version of the compiler.  

 Additionally, while C# version updates generally coincide with major .NET Framework releases, the new syntax and features are not necessarily tied to that specific framework version. While the new features definitely require a new compiler update that is also released alongside the C# revision, each specific feature has its own minimum .NET API or common language runtime requirements that may allow it to run on downlevel frameworks by including NuGet packages or other libraries.
  
 Regardless of which **-langversion** setting you use, you will use the current version of the common language runtime to create your .exe or .dll. One exception is friend assemblies and [-moduleassemblyname (C# Compiler Option)](./moduleassemblyname-compiler-option.md), which work under **-langversion:ISO-1**.  

 For other ways to specify the C# language version, see the [Select the C# language version](../configure-language-version.md) topic.
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.LanguageVersion%2A>.  

## See also

- [C# Compiler Options](index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)

### C# Language Specification

|Version|Link|Description|
|-------|----|-----------|
|C# 7.0 and later||not currently available|
|C# 6.0|[Link](../language-specification/index.md)|C# Language Specification Version 6 - Unofficial Draft: .NET Foundation|
|C# 5.0|[Download PDF](https://www.ecma-international.org/publications/files/ECMA-ST/ECMA-334.pdf)|Standard ECMA-334 5th Edition|
|C# 3.0|[Download DOC](https://download.microsoft.com/download/3/8/8/388e7205-bc10-4226-b2a8-75351c669b09/CSharp%20Language%20Specification.doc)|C# Language Specification Version 3.0: Microsoft Corporation|
|C# 2.0|[Download PDF](https://www.ecma-international.org/publications/files/ECMA-ST-ARCH/ECMA-334%204th%20edition%20June%202006.pdf)|Standard ECMA-334 4th Edition|
|C# 1.2|[Download DOC](https://www.ecma-international.org/publications/files/ECMA-ST-ARCH/ECMA-334%202nd%20edition%20December%202002.pdf)|C# Language Specification Version 1.2: Microsoft Corporation|
|C# 1.0|[Download DOC](https://www.ecma-international.org/publications/files/ECMA-ST-ARCH/ECMA-334%201st%20edition%20December%202001.pdf)|C# Language Specification Version 1.0: Microsoft Corporation|

### Minimum compiler version needed to support all language features

[↩](#TCS80)<a name="FCS80">CS80</a>: Microsoft Visual Studio/Build Tools 2019, version 16, or .NET Core 3.0 SDK  
[↩](#TCS73)<a name="FCS73">CS73</a>: Microsoft Visual Studio/Build Tools 2017, version 15.7  
[↩](#TCS72)<a name="FCS72">CS72</a>: Microsoft Visual Studio/Build Tools 2017, version 15.5  
[↩](#TCS71)<a name="FCS71">CS71</a>: Microsoft Visual Studio/Build Tools 2017, version 15.3  
[↩](#TCS7)<a name="FCS7">CS7</a>: Microsoft Visual Studio/Build Tools 2017  
[↩](#TCS6)<a name="FCS6">CS6</a>: Microsoft Visual Studio/Build Tools 2015  
[↩](#TCS5)<a name="FCS5">CS5</a>: Microsoft Visual Studio/Build Tools 2012 or bundled .NET Framework 4.5 compiler  
[↩](#TCS4)<a name="FCS4">CS4</a>: Microsoft Visual Studio/Build Tools 2010 or bundled .NET Framework 4.0 compiler  
[↩](#TCS3)<a name="FCS3">CS3</a>: Microsoft Visual Studio/Build Tools 2008 or bundled .NET Framework 3.5 compiler  
[↩](#TISO2)<a name="FISO2">ISO2</a>: Microsoft Visual Studio/Build Tools 2005 or bundled .NET Framework 2.0 compiler  
[↩](#TISO1)<a name="FISO1">ISO1</a>: Microsoft Visual Studio/Build Tools .NET 2002 or bundled .N Framework 1.0 compiler  
