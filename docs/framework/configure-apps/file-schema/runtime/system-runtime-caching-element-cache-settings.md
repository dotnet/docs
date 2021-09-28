---
description: "Learn more about: <system.runtime.caching> Element (Cache Settings)"
title: "<system.runtime.caching> Element (Cache Settings)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "<system.runtime.caching> element"
  - "caching [.NET Framework], configuration"
  - "system.runtime.caching element"
ms.assetid: 9b44daee-874a-4bd1-954e-83bf53565590
---
# \<system.runtime.caching> Element (Cache Settings)

Provides configuration for the default in-memory <xref:System.Runtime.Caching.ObjectCache> implementation through the `memoryCache` entry in the configuration file.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;**\<system.runtime.caching>**  
  
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
|[\<memoryCache>](memorycache-element-cache-settings.md)|Defines an element that is used to configure a cache that is based on the <xref:System.Runtime.Caching.MemoryCache> class.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration>](../configuration-element.md)|Specifies the root element in every configuration file that is used by the common language runtime and .NET Framework applications.|  
  
## Remarks

The classes in this namespace provide a way to use caching facilities like those in ASP.NET, but without a dependency on the `System.Web` assembly. For more information, see [Caching in .NET Framework Applications](../../../performance/caching-in-net-framework-applications.md).  
  
> [!NOTE]
> The output caching functionality and types in the <xref:System.Runtime.Caching> namespace are new in .NET Framework 4.  
  
## Example

The following example shows how to configure a cache that is based on the <xref:System.Runtime.Caching.MemoryCache> class. The example shows how to configure an instance of the `namedCaches` entry for memory cache. The name of the cache is set to the default cache entry name by setting the `name` attribute to "Default".  
  
The `cacheMemoryLimitMegabytes` attribute and the `physicalMemoryPercentage` attribute are set to zero. Setting these attributes to zero means that the <xref:System.Runtime.Caching.MemoryCache> autosizing heuristics are used by default. The cache implementation should compare the current memory load against the absolute and percentage-based memory limits every two minutes.  
  
```xml  
<configuration>  
  <system.runtime.caching>  
    <memoryCache>  
      <namedCaches>  
          <add name="Default"
               cacheMemoryLimitMegabytes="0"
               physicalMemoryLimitPercentage="0"  
               pollingInterval="00:02:00" />  
      </namedCaches>  
    </memoryCache>  
  </system.runtime.caching>  
</configuration>  
```  
  
## See also

- [\<memoryCache> Element (Cache Settings)](memorycache-element-cache-settings.md)
