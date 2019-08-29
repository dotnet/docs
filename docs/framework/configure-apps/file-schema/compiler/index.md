---
title: "Compiler and Language Provider Settings Schema"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "configuration settings [.NET Framework], compilers"
  - "compiler configuration elements, schema"
  - "compiler configuration elements"
  - "language providers"
  - "compiler configuration settings, schema"
  - "configuration schema [.NET Framework], compiler settings"
  - "language providers, settings schema"
  - "compiler configuration settings"
ms.assetid: c020b139-8699-4f0d-9ac9-70d0c5b2a8c8
---
# Compiler and Language Provider Settings Schema
Compiler and language provider settings specify compiler configuration elements for available language providers. Each compiler configuration element specifies the code provider type name, compiler parameters, supported language names, and supported file extensions.  
  
The .NET Framework defines the initial compiler settings in the machine configuration file (Machine.config). Developers and compiler vendors can add configuration settings for a new <xref:System.CodeDom.Compiler.CodeDomProvider> implementation. Use the <xref:System.CodeDom.Compiler.CodeDomProvider.GetAllCompilerInfo%2A?displayProperty=nameWithType> method to programmatically enumerate language provider and compiler configuration settings on a computer.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<system.codedom>**](system-codedom-element.md)  
&nbsp;&nbsp;&nbsp;&nbsp;[**\<compilers>**](compilers-element.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<compiler>**](compiler-element.md)  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.codedom>](system-codedom-element.md)|Specifies compiler configuration settings for available language providers.|  
|[\<compilers>](compilers-element.md)|Container for compiler configuration elements; contains zero or more [\<compiler>](compiler-element.md) elements.|  
|[\<compiler>](compiler-element.md)|Specifies the compiler configuration attributes for a language provider.|  
  
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
- [\<compiler> Element](compiler-element.md)
