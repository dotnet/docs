---
title: "<probing> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding/probing"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#probing"
helpviewer_keywords: 
  - "<probing> element"
  - "container tags, <probing> element"
  - "probing element"
ms.assetid: 09c80fc9-1ba5-4192-89f7-3a79b2e4b024
author: "rpetrusha"
ms.author: "ronpet"
---
# \<probing> Element
Specifies application base subdirectories for the common language runtime to search when loading assemblies.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<assemblyBinding>**](assemblybinding-element-for-runtime.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<probing>**  
  
## Syntax  
  
```xml  
<probing privatePath="paths"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`privatePath`|Required attribute.<br /><br /> Specifies subdirectories of the application's base directory that might contain assemblies. Delimit each subdirectory with a semicolon.|  
  
### Child Elements  

None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`assemblyBinding`|Contains information about assembly version redirection and the locations of assemblies.|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Example  
 The following example shows how to specify application base subdirectories the runtime should search for assemblies.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <probing privatePath="bin;bin2\subbin;bin3"/>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [Specifying an Assembly's Location](../../specify-assembly-location.md)
- [How the Runtime Locates Assemblies](../../../deployment/how-the-runtime-locates-assemblies.md)
