---
description: "Learn more about: <system.codedom> Element"
title: "<system.codedom> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.codedom"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#system.codedom"
helpviewer_keywords: 
  - "compiler configuration elements, <system.codedom> element"
  - "system.codedom element"
  - "<system.codedom> element"
ms.assetid: 672a68f7-e69f-4479-ac30-e980085ec4fe
---
# \<system.codedom> Element

Specifies compiler configuration settings for available language providers.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;**\<system.codedom>**  
  
## Syntax  
  
```xml  
<system.codedom>  
  <compilers> ... </compilers>  
</system.codedom>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<compilers>](compilers-element.md)|Container for compiler configuration elements; contains zero or more [\<compiler>](compiler-element.md) elements.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration>](../configuration-element.md)|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
  
## Remarks  
  
## .NET Framework Version 2.0  

 The [\<system.codedom>](system-codedom-element.md) element contains compiler configuration settings for language providers installed on a computer in addition to the default providers that are installed with the .NET Framework, such as the <xref:Microsoft.CSharp.CSharpCodeProvider> and the <xref:Microsoft.VisualBasic.VBCodeProvider>. The [\<compilers>](compilers-element.md) element contains zero or more [\<compiler>](compiler-element.md) elements. Each [\<compiler>](compiler-element.md) element specifies the compiler configuration attributes for a specific language provider.  
  
 Developers and compiler vendors can add configuration settings to the machine configuration file (Machine.config) for a new <xref:System.CodeDom.Compiler.CodeDomProvider> implementation. Use the <xref:System.CodeDom.Compiler.CodeDomProvider.GetAllCompilerInfo%2A?displayProperty=nameWithType> method to programmatically enumerate both the default language providers and language providers identified by the compiler configuration settings on a computer.  
  
> [!NOTE]
> In the .NET Framework versions 1.0 and 1.1, the default language providers supplied by the .NET Framework are identified in the [\<compilers>](compilers-element.md) element. In the .NET Framework version 2.0, the default language providers are not identified in the [\<compilers>](compilers-element.md) element, but can be enumerated using the <xref:System.CodeDom.Compiler.CodeDomProvider.GetAllCompilerInfo%2A> method.  
  
## .NET Framework Versions 1.0 and 1.1  

 The [\<system.codedom>](system-codedom-element.md) element contains the compiler configuration settings for language providers on a computer. The [\<compilers>](compilers-element.md) element contains zero or more [\<compiler>](compiler-element.md) elements. Each [\<compiler>](compiler-element.md) element specifies the compiler configuration attributes for a specific language provider.  
  
 The .NET Framework defines the initial compiler settings in the machine configuration file (Machine.config). Developers and compiler vendors can add configuration settings for a new <xref:System.CodeDom.Compiler.CodeDomProvider> implementation. Use the <xref:System.CodeDom.Compiler.CodeDomProvider.GetAllCompilerInfo%2A?displayProperty=nameWithType> method to programmatically enumerate language provider and compiler configuration settings on a computer.  
  
## Configuration File  

 This element can be used in the machine configuration file and the application configuration file.  
  
## Example  

 The following example illustrates a typical compiler configuration.  
  
```xml  
<configuration>  
  <system.codedom>  
    <compilers>  
      <!-- zero or more compiler elements -->  
      <compiler
        language="c#;cs;csharp"  
        extension=".cs"  
        type="Microsoft.CSharp.CSharpCodeProvider, System,
          Version=1.0.5000.0, Culture=neutral,
          PublicKeyToken=b77a5c561934e089"  
        compilerOptions=""  
        warningLevel="1" />  
    </compilers>  
  </system.codedom>  
</configuration>  
```  
  
## See also

- <xref:System.CodeDom.Compiler.CompilerInfo>
- <xref:System.CodeDom.Compiler.CodeDomProvider>
- [Configuration File Schema](../index.md)
- [Compiler and Language Provider Settings Schema](index.md)
- [\<compiler> Element](compiler-element.md)
