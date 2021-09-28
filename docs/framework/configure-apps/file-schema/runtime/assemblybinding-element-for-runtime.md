---
description: "Learn more about: <assemblyBinding> Element for <runtime>"
title: "<assemblyBinding> Element for <runtime>"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding"
helpviewer_keywords: 
  - "<assemblyBinding> element"
  - "assemblyBinding element"
  - "container tags, <assemblyBinding> element"
ms.assetid: 964cbb35-ab49-4498-8471-209689e5dada
---
# \<assemblyBinding> Element for \<runtime>

Contains information about assembly version redirection and the locations of assemblies.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<assemblyBinding>**  
  
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
|[\<dependentAssembly>](dependentassembly-element.md)|Encapsulates binding policy and assembly location for an assembly. Use one **\<dependentAssembly>** tag for each assembly.|  
|[\<probing>](probing-element.md)|Specifies subdirectories the common language runtime searches when loading assemblies.|  
|[\<publisherPolicy>](publisherpolicy-element.md)|Specifies whether the runtime applies publisher policy.|  
|[\<qualifyAssembly>](qualifyassembly-element.md)|Specifies the full name of the assembly that should be dynamically loaded when a partial name is used.|  
  
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
  
## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [Redirecting Assembly Versions](../../redirect-assembly-versions.md)
