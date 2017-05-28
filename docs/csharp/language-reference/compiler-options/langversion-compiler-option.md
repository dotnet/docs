---
title: "-langversion (C# Compiler Options) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/langversion"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/langversion compiler option [C#]"
  - "-langversion compiler option [C#]"
  - "langversion compiler option [C#]"
ms.assetid: 3fb00b05-a0ff-4782-b313-13a4c0f62d94
caps.latest.revision: 33
author: "BillWagner"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# /langversion (C# Compiler Options)
Causes the compiler to accept only syntax that is included in the chosen C# language specification.  
  
## Syntax  
  
```  
/langversion:option  
```  
  
## Arguments  
 `option`  
 The following values are valid:  
  
|Option|Meaning|  
|------------|-------------|  
|default|The compiler accepts all valid language syntax that it can support. <sup id="TDefault">[Default](#FDefault)</sup>| 
|ISO-1|The compiler accepts only syntax that is included in the ISO/IEC 23270:2003 C# language specification. <sup id="TISO1">[ISO1](#FISO1)</sup>|  
|ISO-2|The compiler accepts only syntax that is included in the ISO/IEC 23270:2006 C# language specification. <sup id="TISO2">[ISO2](#FISO2)</sup>|
|3|The compiler accepts only syntax that is included in C# 3.0 or lower <sup id="TCS3">[CS3](#FCS3)</sup>|
|4|The compiler accepts only syntax that is included in C# 4.0 or lower <sup id="TCS4">[CS4](#FCS4)</sup>|
|5|The compiler accepts only syntax that is included in C# 5.0 or lower <sup id="TCS5">[CS5](#FCS5)</sup>|
|6|The compiler accepts only syntax that is included in C# 6.0 or lower <sup id="TCS6">[CS6](#FCS6)</sup>|
|7|The compiler accepts only syntax that is included in C# 7.0 or lower <sup id="TCS7">[CS7](#FCS7)</sup>|
|7.1|The compiler accepts only syntax that is included in C# 7.1 or lower <sup id="TCS71">[CS71](#FCS71)</sup>|
|latest|The compiler accepts all valid language syntax that it can support. <sup id="TLatest">[Latest](#FLatest)</sup>|  
  
## Remarks  
 Metadata referenced by your C# application is not subject to **/langversion** compiler option.  
  
 Because each version of the C# compiler contains extensions to the language specification, **/langversion** does not give you the equivalent functionality of an earlier version of the compiler.  
 
 Additionally, while newer C# versions and features do necessarily not explicitly depend on the .Net Framework version they were released with, individual features/packages may have varying minimum API requirements.
  
 Regardless of which **/langversion** setting you use, you will use the current version of the common language runtime to create your .exe or .dll. One exception is friend assemblies and [/moduleassemblyname (C# Compiler Option)](../../../csharp/language-reference/compiler-options/moduleassemblyname-compiler-option.md), which work under **/langversion:ISO-1**.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Build** property page.  
  
3.  Click the **Advanced** button.  
  
4.  Modify the **Language Version** property.  
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.LanguageVersion%2A>.  
  
### Minimum compiler version needed to support all language features   
[↩](#TDefault)<a name="FDefault">Default</a>, <a name="FISO1">ISO1</a>: Microsoft Visual Studio/Build Tools .Net 2002 or bundled .Net Framework 1.0 compiler     
[↩](#TISO2)<a name="FISO2">ISO2</a>: Microsoft Visual Studio/Build Tools 2005 or bundled .Net Framework 2.0 compiler    
[↩](#TCS3)<a name="FCS3">CS3</a>: Microsoft Visual Studio/Build Tools 2008 or bundled .Net Framework 3.5 compiler    
[↩](#TCS4)<a name="FCS4">CS4</a>: Microsoft Visual Studio/Build Tools 2010 or bundled .Net Framework 4.0 compiler    
[↩](#TCS5)<a name="FCS5">CS5</a>: Microsoft Visual Studio/Build Tools 2012 or bundled .Net Framework 4.5 compiler    
[↩](#TCS6)<a name="FCS6">CS6</a>: Microsoft Visual Studio/Build Tools 2015    
[↩](#TCS7)<a name="FCS7">CS7</a>,<a name="FCS71">CS71</a>, <a name="FLatest">Latest</a>: Microsoft Visual Studio/Build Tools 2017   
  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)   
 
### C# Language Specification
 [C# Language Specification](../../../csharp/language-reference/language-specification.md)   
 This specification is available on the [ISO](http://go.microsoft.com/fwlink/?LinkId=144406) Web site.  
 [C# Language Specification](../../../csharp/language-reference/language-specification.md).
