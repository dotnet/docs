---
title: "-langversion (C# Compiler Options)"
ms.date: 05/14/2018
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
|default|The compiler accepts all valid language syntax from the latest major version that it can support.|
|ISO-1|The compiler accepts only syntax that is included in ISO/IEC 23270:2003 C# (1.0/1.2) <sup id="TISO1">[ISO1](#FISO1)</sup>|  
|ISO-2|The compiler accepts only syntax that is included in ISO/IEC 23270:2006 C# (2.0) <sup id="TISO2">[ISO2](#FISO2)</sup>|
|3|The compiler accepts only syntax that is included in C# 3.0 or lower <sup id="TCS3">[CS3](#FCS3)</sup>|
|4|The compiler accepts only syntax that is included in C# 4.0 or lower <sup id="TCS4">[CS4](#FCS4)</sup>|
|5|The compiler accepts only syntax that is included in C# 5.0 or lower <sup id="TCS5">[CS5](#FCS5)</sup>|
|6|The compiler accepts only syntax that is included in C# 6.0 or lower <sup id="TCS6">[CS6](#FCS6)</sup>|
|7|The compiler accepts only syntax that is included in C# 7.0 or lower <sup id="TCS7">[CS7](#FCS7)</sup>|
|7.1|The compiler accepts only syntax that is included in C# 7.1 or lower <sup id="TCS71">[CS71](#FCS71)</sup>|
|7.2|The compiler accepts only syntax that is included in C# 7.2 or lower <sup id="TCS72">[CS72](#FCS72)</sup>|
|7.3|The compiler accepts only syntax that is included in C# 7.3 or lower <sup id="TCS73">[CS73](#FCS73)</sup>|
|latest|The compiler accepts all valid language syntax that it can support.|

<!--- Uncomment and move these above
|8|The compiler accepts only syntax that is included in C# 8 or lower <sup id="TCS8">[CS8](#FCS8)</sup>|
-->

## Remarks

 Metadata referenced by your C# application is not subject to **-langversion** compiler option.  
  
 Because each version of the C# compiler contains extensions to the language specification, **-langversion** does not give you the equivalent functionality of an earlier version of the compiler.  

 Additionally, while C# version updates generally coincide with major .NET Framework releases, the new syntax and features are not necessarily tied to that specific framework version. While the new features definitely require a new compiler update that is also released alongside the C# revision, each specific feature has its own minimum .NET API or common language runtime requirements that may allow it to run on downlevel frameworks by including NuGet packages or other libraries.
  
 Regardless of which **-langversion** setting you use, you will use the current version of the common language runtime to create your .exe or .dll. One exception is friend assemblies and [-moduleassemblyname (C# Compiler Option)](../../../csharp/language-reference/compiler-options/moduleassemblyname-compiler-option.md), which work under **-langversion:ISO-1**.  

 For other ways to specify the C# language version, see the [Select the C# language version](../configure-language-version.md) topic.
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.LanguageVersion%2A>.  

## See Also

- [C# Compiler Options](index.md)  
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)  

### C# Language Specification

|Version|Link|Description|
|-------|----|-----------|
|C# 1.0|[Download DOC](https://download.microsoft.com/download/a/9/e/a9e229b9-fee5-4c3e-8476-917dee385062/csharp%20language%20specification%20v1.0.doc)|C# Language Specification Version 1.0: Microsoft Corporation|
|C# 1.2|[Download DOC](https://download.microsoft.com/download/5/e/5/5e58be0a-b02b-41ac-a4a3-7a22286214ff/csharp%20language%20specification%20v1.2.doc)|C# Language Specification Version 1.2: Microsoft Corporation|
|C# 2.0|[Download PDF](https://www.ecma-international.org/publications/files/ECMA-ST-ARCH/Ecma-334%204th%20edition%20June%202006.pdf)|Standard ECMA-334 4th Edition|
|C# 3.0|[Download DOC](https://download.microsoft.com/download/3/8/8/388e7205-bc10-4226-b2a8-75351c669b09/CSharp%20Language%20Specification.doc)|C# Language Specification Version 3.0: Microsoft Corporation|
|C# 5.0|[Download PDF](https://www.ecma-international.org/publications/files/ECMA-ST/Ecma-334.pdf)|Standard ECMA-334 5th Edition|
|C# 6.0|[Link](../language-specification/index.md)|C# Language Specification Version 6 - Unofficial Draft: .NET Foundation|
|C# 7.0 and later||not currently available|

### Minimum compiler version needed to support all language features

[↩](#TISO1)<a name="FISO1">ISO1</a>: Microsoft Visual Studio/Build Tools .Net 2002 or bundled .Net Framework 1.0 compiler
[↩](#TISO2)<a name="FISO2">ISO2</a>: Microsoft Visual Studio/Build Tools 2005 or bundled .Net Framework 2.0 compiler
[↩](#TCS3)<a name="FCS3">CS3</a>: Microsoft Visual Studio/Build Tools 2008 or bundled .Net Framework 3.5 compiler
[↩](#TCS4)<a name="FCS4">CS4</a>: Microsoft Visual Studio/Build Tools 2010 or bundled .Net Framework 4.0 compiler
[↩](#TCS5)<a name="FCS5">CS5</a>: Microsoft Visual Studio/Build Tools 2012 or bundled .Net Framework 4.5 compiler
[↩](#TCS6)<a name="FCS6">CS6</a>: Microsoft Visual Studio/Build Tools 2015
[↩](#TCS7)<a name="FCS7">CS7</a>: Microsoft Visual Studio/Build Tools 2017
[↩](#TCS71)<a name="FCS71">CS71</a>: Microsoft Visual Studio/Build Tools 2017, version 15.3
[↩](#TCS72)<a name="FCS72">CS72</a>: Microsoft Visual Studio/Build Tools 2017, version 15.5
[↩](#TCS73)<a name="FCS73">CS73</a>: Microsoft Visual Studio/Build Tools 2017, version 15.7

<!--- Uncomment and add to the above when they become officially released
[↩](#TCS8)<a name="FCS8">CS8</a>: Microsoft Visual Studio/Build Tools 20??    
-->
