---
title: "&lt;providerOption&gt; Element"
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
  - "provideroption"
helpviewer_keywords: 
  - "<provideroption> element"
  - "providerOptions"
  - "provideroption element"
ms.assetid: 014f2e0b-c0b5-4fc4-92d3-73f02978b2a1
caps.latest.revision: 22
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;providerOption&gt; Element
Specifies the compiler version attributes for a language provider.  
  
 \<configuration Element>  
\<system.codedom Element>  
\<compilers Element>  
\<compiler> Element  
\<providerOption> Element  
  
## Syntax  
  
```xml  
<providerOption  
  name="option-name"  
  value="option-value"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`name`|Required attribute.<br /><br /> Specifies the name of the option; for example, "CompilerVersion".|  
|`value`|Required attribute.<br /><br /> Specifies the value for the option; for example, "v3.5".|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration> Element](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)|The root element in every configuration file that is used by the common language runtime and .NET Framework applications.|  
|[\<system.codedom> Element](../../../../../docs/framework/configure-apps/file-schema/compiler/system-codedom-element.md)|Specifies compiler configuration settings for available language providers.|  
|[\<compilers> Element](../../../../../docs/framework/configure-apps/file-schema/compiler/compilers-element.md)|Container for compiler configuration elements; contains zero or more `<compiler>` elements.|  
|[\<compiler> Element](../../../../../docs/framework/configure-apps/file-schema/compiler/compiler-element.md)|Specifies the compiler configuration attributes for a language provider.|  
  
## Remarks  
 In the .NET Framework version 3.5, Code Document Object Model (CodeDOM) code providers can support provider-specific options by using the `<providerOption>` element.  
  
 The .NET Framework 3.5 includes updated .NET Framework 2.0 assemblies and provides new version 3.5 assemblies that contain new types. The Microsoft C# and Visual Basic code providers are contained in .NET Framework 2.0 assemblies but have been updated to support version 3.5 compilers. By default, the updated code providers generate code for version 2.0 compilers. You can use the `<providerOption>` element to change the target compiler version to 3.5. To do this, specify "CompilerVersion" for the `name` attribute and "v3.5" for the `value` attribute. You must precede the version number with a lower-case "v".  
  
 You can make the version specification global by adding the `<providerOption>` element to the .NET Framework 2.0 Machine.config or root Web.config file. If you update the default compiler version to 3.5 in the Machine.config file, you can change it back to 2.0 on a per-application basis by using the `<providerOption>` element in the application configuration file.  
  
 CodeDOM code provider implementers can process custom options by providing a constructor that takes a `providerOptions` parameter of type <xref:System.Collections.Generic.IDictionary%602>.  
  
## Example  
 The following example demonstrates how to specify that version 3.5 of the C# code provider should be used.  
  
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
        warningLevel="1" >  
          <providerOption  
            name="CompilerVersion"  
            value="v3.5" />  
      </compiler>  
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
 [compiler Element for compilers for compilation (ASP.NET Settings Schema)](http://msdn.microsoft.com/library/f7d6b078-5d42-4134-b3f7-62e1aba1df1e)
