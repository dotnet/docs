---
title: "&lt;assemblyBinding&gt; Element for &lt;runtime&gt;"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding"
helpviewer_keywords: 
  - "<assemblyBinding> element"
  - "assemblyBinding element"
  - "container tags, <assemblyBinding> element"
ms.assetid: 964cbb35-ab49-4498-8471-209689e5dada
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;assemblyBinding&gt; Element for &lt;runtime&gt;
Contains information about assembly version redirection and the locations of assemblies.  
  
 \<configuration>  
\<runtime>  
\<assemblyBinding>  
  
## Syntax  
  
```xml  
      <assemblyBinding    
   xmlns="urn:schemas-microsoft-com:asm.v1" appliesTo="v1.0.3705">  
</assemblyBinding>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**xmlns**|Required attribute.<br /><br /> Specifies the XML namespace required for assembly binding. Use the string "urn:schemas-microsoft-com:asm.v1" as the value.|  
|**appliesTo**|Specifies the runtime version the .NET Framework assembly redirection applies to. This optional attribute uses a .NET Framework version number to indicate what version it applies to. If no **appliesTo** attribute is specified, the **\<assemblyBinding>** element applies to all versions of the .NET Framework. The **appliesTo** attribute was introduced in .NET Framework version 1.1; it is ignored by the .NET Framework version 1.0. This means that all **\<assemblyBinding>** elements are applied when using the .NET Framework version 1.0, even if an **appliesTo** attribute is specified.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<dependentAssembly>](../../../../../docs/framework/configure-apps/file-schema/runtime/dependentassembly-element.md)|Encapsulates binding policy and assembly location for an assembly. Use one **\<dependentAssembly>** tag for each assembly.|  
|[\<probing>](../../../../../docs/framework/configure-apps/file-schema/runtime/probing-element.md)|Specifies subdirectories the common language runtime searches when loading assemblies.|  
|[\<publisherPolicy>](../../../../../docs/framework/configure-apps/file-schema/runtime/publisherpolicy-element.md)|Specifies whether the runtime applies publisher policy.|  
|[\<qualifyAssembly>](../../../../../docs/framework/configure-apps/file-schema/runtime/qualifyassembly-element.md)|Specifies the full name of the assembly that should be dynamically loaded when a partial name is used.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Example  
 The following example shows how to redirect one assembly version to another and provide a codebase.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <dependentAssembly>  
            <assemblyIdentity name="myAssembly"  
                              publicKeyToken="32ab4ba45e0a69a1"  
                              culture="neutral" />  
            <bindingRedirect oldVersion="1.0.0.0"  
                             newVersion="2.0.0.0"/>  
            <codeBase version="2.0.0.0"  
                      href="http://www.litwareinc.com/myAssembly.dll"/>  
         </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
 The following example shows how to use the **appliesTo** attribute to redirect binding of a .NET Framework assembly.  
  
```xml  
<runtime>  
   <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1" appliesTo="v1.0.3705">  
      <dependentAssembly>   
         <assemblyIdentity name="mscorcfg" publicKeyToken="b03f5f7f11d50a3a" culture=""/>  
         <bindingRedirect oldVersion="0.0.0.0-65535.65535.65535.65535" newVersion="1.0.3300.0"/>  
      </dependentAssembly>  
   </assemblyBinding>  
</runtime>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Redirecting Assembly Versions](../../../../../docs/framework/configure-apps/redirect-assembly-versions.md)
