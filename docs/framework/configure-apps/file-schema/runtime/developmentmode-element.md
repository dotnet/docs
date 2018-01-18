---
title: "&lt;developmentMode&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/developmentMode"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#developmentMode"
helpviewer_keywords: 
  - "developmentMode element"
  - "container tags, <developmentMode> element"
  - "<developmentMode> element"
ms.assetid: 60e79a8c-415a-497d-be29-b9d0fd9bdee3
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;developmentMode&gt; Element
Specifies whether the runtime searches for assemblies in directories specified by the DEVPATH environment variable.  
  
 \<configuration>  
\<runtime>  
\<developmentMode>  
  
## Syntax  
  
```xml  
<developmentMode developerInstallation="true | false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**developerInstallation**|Specifies whether the runtime searches for assemblies in directories specified by the DEVPATH environment variable.|  
  
## developerInstallation Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|**true**|Searches for assemblies in directories specified by the DEVPATH environment variable.|  
|**false**|Does not search for assemblies in directories specified by the DEVPATH environment variable. This is the default|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 Use this setting only at development time. The runtime does not check the versions on strong-named assemblies found in the DEVPATH. It simply uses the first assembly it finds.  
  
## Example  
 The following example shows how to cause the runtime to search for assemblies in directories specified by the DEVPATH environment variable.  
  
```xml  
<configuration>  
   <runtime>  
      <developmentMode developerInstallation="true"/>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [How to: Locate Assemblies by Using DEVPATH](../../../../../docs/framework/configure-apps/how-to-locate-assemblies-by-using-devpath.md)
