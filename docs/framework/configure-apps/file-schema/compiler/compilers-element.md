---
title: "<compilers> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#compilers"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.codedom/compilers"
helpviewer_keywords: 
  - "compiler configuration elements, <compilers> element"
  - "<compilers> element"
  - "compilers element"
ms.assetid: d40fba59-98f9-4783-ae0c-2ebea27ce77b
---
# \<compilers> Element
Container for compiler configuration elements; contains zero or more [\<compiler>](compiler-element.md) elements.  
  
 \<configuration>  
\<system.codedom>  
\<compilers> Element  
  
## Syntax  
  
```xml  
<compilers>  
  <compiler ... />  
</compilers>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<compiler> Element](compiler-element.md)|Specifies the compiler configuration attributes for a language provider.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration> Element](../configuration-element.md)|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|[\<system.codedom> Element](system-codedom-element.md)|Specifies compiler configuration settings for available language providers.|  
  
## Remarks  
 The [\<compilers>](compilers-element.md) element contains the compiler configuration settings for language providers on a computer. Each [\<compiler>](compiler-element.md) element specifies the compiler configuration attributes for a specific language provider.  
  
 The .NET Framework defines the initial compiler and language provider settings in the machine configuration file (Machine.config). Developers and compiler vendors can add configuration settings for a new <xref:System.CodeDom.Compiler.CodeDomProvider?displayProperty=nameWithType> implementation. Use the <xref:System.CodeDom.Compiler.CodeDomProvider.GetAllCompilerInfo%2A?displayProperty=nameWithType> method to programmatically enumerate language provider and compiler configuration settings on a computer.  
  
## Configuration File  
 This element can be used in the machine configuration file and the application configuration file.  
  
## Example  
 The following example illustrates a typical compiler configuration element.  
  
```xml  
<configuration>  
   <system.codedom>  
     <compilers>  
       <!-- zero or more compiler elements -->  
       <compiler   
          language="c#;cs;csharp"   
          extension=".cs"  
          type="Microsoft.CSharp.CSharpCodeProvider, System, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  
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
