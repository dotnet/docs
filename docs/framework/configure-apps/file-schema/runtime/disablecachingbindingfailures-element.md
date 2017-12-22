---
title: "&lt;disableCachingBindingFailures&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#disableCachingBindingFailures"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/disableCachingBindingFailures"
helpviewer_keywords: 
  - "assemblies [.NET Framework],caching binding failures"
  - "caching assembly binding failures"
  - "<disableCachingBindingFailures> element"
  - "disableCachingBindingFailures element"
ms.assetid: bf598873-83b7-48de-8955-00b0504fbad0
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;disableCachingBindingFailures&gt; Element
Specifies whether to disable the caching of binding failures that occur because the assembly was not found by probing.  
  
 \<configuration> Element  
\<runtime> Element  
\<disableCachingBindingFailures>  
  
## Syntax  
  
```xml  
<disableCachingBindingFailures enabled="0|1"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|enabled|Required attribute.<br /><br /> Specifies whether to disable the caching of binding failures that occur because the assembly was not found by probing.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|0|Do not disable the caching of binding failures that occur because the assembly was not found by probing. This is the default binding behavior starting with the .NET Framework version 2.0.|  
|1|Disable the caching of binding failures that occur because the assembly was not found by probing. This setting reverts to the binding behavior of the .NET Framework version 1.1.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 Starting with the .NET Framework version 2.0, the default behavior for loading assemblies is to cache all binding and loading failures. That is, if an attempt to load an assembly fails, subsequent requests to load the same assembly fail immediately, without any attempt to locate the assembly. This element disables that default behavior for binding failures that occur because the assembly could not be found in the probing path. These failures throw <xref:System.IO.FileNotFoundException>.  
  
 Some binding and loading failures are not affected by this element, and are always cached. These failures occur because the assembly was found but could not be loaded. They throw <xref:System.BadImageFormatException> or <xref:System.IO.FileLoadException>. The following list includes some examples of such failures.  
  
-   If you attempt to load a file is not a valid assembly, subsequent attempts to load the assembly will fail even if the bad file is replaced with the correct assembly.  
  
-   If you attempt to load an assembly that is locked by the file system, subsequent attempts to load the assembly will fail even after the assembly is released by the file system.  
  
-   If one or more versions of the assembly that you are attempting to load is in the probing path, but the specific version you are requesting is not among them, subsequent attempts to load that version will fail even if the correct version is moved into the probing path.  
  
## Example  
 The following example shows how to disable the caching of assembly binding failures that occur because the assembly was not found by probing.  
  
```xml  
<configuration>  
   <runtime>  
      <disableCachingBindingFailures enabled="1" />  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [How the Runtime Locates Assemblies](../../../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)
