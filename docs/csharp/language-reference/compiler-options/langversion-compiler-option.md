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
|default|The compiler accepts all valid language syntax that it can support.|  
|ISO-1|The compiler accepts only syntax that is included in the ISO/IEC 23270:2003 C# language specification. (net 2.x or newer)|  
|ISO-2|The compiler accepts only syntax that is included in the ISO/IEC 23270:2006 C# language specification. This specification is available on the [ISO](http://go.microsoft.com/fwlink/? LinkId=144406) Web site. (net 3.x or newer)|
|3|The compiler accepts only syntax that is included in the version 3.0 [C# Language Specification](../../../csharp/language-reference/language-specification.md). (net 4.x or newer)|
|4|The compiler accepts only syntax that is included in the version 4.0 (net 4.x or newer)|
|5|The compiler accepts only syntax that is included in the version 5.0 (net 4.x or newer)|
  
## Remarks  
 Metadata referenced by your C# application is not subject to **/langversion** compiler option.  
  
 Because each version of the C# compiler contains extensions to the language specification, **/langversion** does not give you the equivalent functionality of an earlier version of the compiler.  
 
 While newer versions of the C# syntax do not explicitly depend on a specific version of the net framework runtime, compilers on older versions of the framework are not updated to support newer langauge syntax without additional configuration (which is beyond the scope of this article.) The above table lists the minimum net framework compiler version needed to compile for a given language version without any additional configuration needed.
 
 Additionally, C# 6 and newer are not supported at all with this compiler, they require migrating to the newer .NET Compiler Platform ("Roslyn")
  
 Regardless of which **/langversion** setting you use, you will use the current version of the common language runtime to create your .exe or .dll. One exception is friend assemblies and [/moduleassemblyname (C# Compiler Option)](../../../csharp/language-reference/compiler-options/moduleassemblyname-compiler-option.md), which work under **/langversion:ISO-1**.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Build** property page.  
  
3.  Click the **Advanced** button.  
  
4.  Modify the **Language Version** property.  
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.LanguageVersion%2A>.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)   
 [C# Language Specification](../../../csharp/language-reference/language-specification.md)   
 [.NET Compiler Platform ("Roslyn")](https://github.com/dotnet/roslyn)    
