---
title: "&lt;compiler&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#compiler"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.codedom/compilers/compiler"
helpviewer_keywords: 
  - "compiler configuration elements, <compiler> element"
  - "<compiler> element"
  - "compiler configuration attributes"
  - "compiler element"
ms.assetid: 7a151659-b803-4c27-b5ce-1c4aa0d5a823
caps.latest.revision: 20
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;compiler&gt; Element
Specifies the compiler configuration attributes for a language provider.  
  
 \<configuration Element>  
\<system.codedom Element>  
\<compilers Element>  
\<compiler> Element  
  
## Syntax  
  
```xml  
<compiler  
  language="languageName[;...;...]"  
  extension="fileExtension[;...;...]"  
  type="typeName, assemblyName"  
  warningLevel="number"  
  compilerOptions="option1 option2"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`compilerOptions`|Optional attribute.<br /><br /> Specifies additional compiler-specific arguments for compilation. The values for the `compilerOptions` attribute are typically listed in a compiler options topic for the compiler. In the Visual Studio 2005 documentation, you can locate the options for the compiler by looking for "compiler options" in the index.|  
|`extension`|Required attribute.<br /><br /> Provides a semicolon-separated list of file name extensions used by source files for the language provider. For example, ".cs".|  
|`language`|Required attribute.<br /><br /> Provides a semicolon-separated list of language names supported by the language provider. For example, "c#;cs;csharp".|  
|`type`|Required attribute.<br /><br /> Specifies the type name of the language provider, including the name of the assembly containing the provider implementation. The type name must meet the requirements defined in [Specifying Fully Qualified Type Names](../../../../../docs/framework/reflection-and-codedom/specifying-fully-qualified-type-names.md).|  
|`warningLevel`|Optional attribute.<br /><br /> Specifies the default compiler warning level; determines the level at which the language provider treats compilation warnings as errors.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<providerOption> Element](../../../../../docs/framework/configure-apps/file-schema/compiler/provideroption-element.md)|Specifies compiler version attributes for a language provider.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration> Element](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|[\<system.codedom> Element](../../../../../docs/framework/configure-apps/file-schema/compiler/system-codedom-element.md)|Specifies compiler configuration settings for available language providers.|  
|[\<compilers> Element](../../../../../docs/framework/configure-apps/file-schema/compiler/compilers-element.md)|Container for compiler configuration elements; contains zero or more `<compiler>` elements.|  
  
## Remarks  
 Each `<compiler>` element specifies the compiler configuration attributes for a specific language provider. The provider extends the <xref:System.CodeDom.Compiler.CodeDomProvider?displayProperty=nameWithType> class for a specific language; the `<compiler>` element defines the compiler and code generator settings for the language provider.  
  
 The .NET Framework defines the initial compiler settings in the machine configuration file (Machine.config). Developers and compiler vendors can add configuration settings for a new <xref:System.CodeDom.Compiler.CodeDomProvider> implementation. Use the <xref:System.CodeDom.Compiler.CodeDomProvider.GetAllCompilerInfo%2A?displayProperty=nameWithType> method to programmatically enumerate language provider and compiler configuration settings on a computer.  
  
 Compiler elements in the application or Web configuration file can supplement or override the settings in the machine configuration file. If more than one provider implementation is configured for the same language name or the same file extension, the last matching configuration overrides any previous configured providers for that language name or file extension.  
  
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
        type="Microsoft.CSharp.CSharpCodeProvider, System,   
          Version=2.0.3600.0, Culture=neutral,   
          PublicKeyToken=b77a5c561934e089"  
        compilerOptions="/optimize"  
        warningLevel="1" />  
    </compilers>  
  </system.codedom>  
</configuration>  
```  
  
## See Also  
 <xref:System.CodeDom.Compiler.CompilerInfo>  
 <xref:System.CodeDom.Compiler.CodeDomProvider>  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [\<compilers> Element](../../../../../docs/framework/configure-apps/file-schema/compiler/compilers-element.md)  
 [Specifying Fully Qualified Type Names](../../../../../docs/framework/reflection-and-codedom/specifying-fully-qualified-type-names.md)  
 [compiler Element for compilers for compilation (ASP.NET Settings Schema)](https://msdn.microsoft.com/library/f7d6b078-5d42-4134-b3f7-62e1aba1df1e(v=vs.100))
