---
title: "&lt;system.runtime.caching&gt; Element (Cache Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "<system.runtime.caching> element"
  - "caching [.NET Framework], configuration"
  - "system.runtime.caching element"
ms.assetid: 9b44daee-874a-4bd1-954e-83bf53565590
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;system.runtime.caching&gt; Element (Cache Settings)
Provides configuration for the default in-memory <xref:System.Runtime.Caching.ObjectCache> implementation through the `memoryCache` entry in the configuration file.  
  
 \<configuration>  
\<system.runtime.caching>  
  
## Syntax  
  
```xml  
<system.runtime.caching >  
   <!-- child elements -->  
</system.runtime.caching >  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 `None`  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<memoryCache>](../../../../../docs/framework/configure-apps/file-schema/runtime/memorycache-element-cache-settings.md)|Defines an element that is used to configure a cache that is based on the <xref:System.Runtime.Caching.MemoryCache> class.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration>](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)|Specifies the root element in every configuration file that is used by the common language runtime and [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] applications.|  
  
## Remarks  
 The classes in this namespace provide a way to use caching facilities like those in ASP.NET, but without a dependency on the `System.Web` assembly. For more information, see [Caching in .NET Framework Applications](../../../../../docs/framework/performance/caching-in-net-framework-applications.md).  
  
> [!NOTE]
>  The output caching functionality and types in the <xref:System.Runtime.Caching> namespace are new in [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)].  
  
## Example  
 The following example shows how to configure a cache that is based on the <xref:System.Runtime.Caching.MemoryCache> class. The example shows how to configure an instance of the `namedCaches` entry for memory cache. The name of the cache is set to the default cache entry name by setting the `name` attribute to "default".  
  
 The `cacheMemoryLimitMegabytes` attribute and the `physicalMemoryPercentage` attribute are set to zero. Setting these attributes to zero means that the <xref:System.Runtime.Caching.MemoryCache> autosizing heuristics are used by default. The cache implementation should compare the current memory load against the absolute and percentage-based memory limits every two minutes.  
  
```xml  
<configuration>  
  <system.runtime.caching>  
    <memoryCache>  
      <namedCaches>  
          <add name="default"   
               cacheMemoryLimitMegabytes="0"   
               physicalMemoryPercentage="0"  
               pollingInterval="00:02:00" />  
      </namedCaches>  
    </memoryCache>  
  </system.runtime.caching>  
</configuration>  
```  
  
## See Also  
 [\<memoryCache> Element (Cache Settings)](../../../../../docs/framework/configure-apps/file-schema/runtime/memorycache-element-cache-settings.md)
