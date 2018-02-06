---
title: "&lt;dependentAssembly&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding/dependentAssembly"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#dependentAssembly"
helpviewer_keywords: 
  - "container tags, <dependentAssembly> element"
  - "dependentAssembly element"
  - "<dependentAssembly> element"
ms.assetid: 14e95627-dd79-4b82-ac85-e682aa3a31d8
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;dependentAssembly&gt; Element
Encapsulates binding policy and assembly location for each assembly. Use one `dependentAssembly` element for each assembly.  
  
 \<configuration>  
\<runtime>  
\<assemblyBinding>  
\<dependentAssembly>  
  
## Syntax  
  
```xml  
<dependentAssembly>   
</dependentAssembly>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`assemblyIdentity`|Contains identifying information about the assembly. This element must be included in each `dependentAssembly` element.|  
|`codeBase`|Specifies where the runtime can find a shared assembly if it is not installed on the computer.|  
|`bindingRedirect`|Redirects one assembly version to another.|  
|`publisherPolicy`|Specifies whether the runtime applies publisher policy for this assembly.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`assemblyBinding`|Contains information about assembly version redirection and the locations of assemblies.|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Example  
 The following example shows how to encapsulate assembly information for two assemblies.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <dependentAssembly>  
            <assemblyIdentity name="myAssembly"  
                              publicKeyToken="32ab4ba45e0a69a1"  
                              culture="neutral" />  
            <!--Redirection and codeBase policy for myAssembly.-->  
         </dependentAssembly>  
         <dependentAssembly>  
            <assemblyIdentity name="mySecondAssembly"  
                              publicKeyToken="32ab4ba45e0a69a1"  
                              culture="neutral" />  
            <!--Redirection and codeBase policy for mySecondAssembly.-->  
         </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Redirecting Assembly Versions](../../../../../docs/framework/configure-apps/redirect-assembly-versions.md)
