---
title: "&lt;namedCaches&gt; Element (Cache Settings)"
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
  - "namedCaches element"
  - "caching [.NET Framework], configuration"
  - "<namedCaches> element"
ms.assetid: 6bd4fbc5-55a6-4dc4-998b-cdcc7e023330
caps.latest.revision: 14
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;namedCaches&gt; Element (Cache Settings)
Specifies a collection of configuration settings for the named <xref:System.Runtime.Caching.MemoryCache> instances. The <xref:System.Runtime.Caching.Configuration.MemoryCacheSection.NamedCaches%2A> property references the collection of configuration settings from one or more `namedCaches` elements of the configuration file.  
  
 \<configuration>  
\< system.runtime.caching>  
\<memoryCache>  
\<namedCaches>  
  
## Syntax  
  
```xml  
<namedCaches>  
  <add name="default"/>   
</namedCaches>  
```  
  
## Type  
 `None`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`cacheMemoryLimitMegabytes`|An integer value that specifies the maximum allowable size, in megabytes, that an instance of a <xref:System.Runtime.Caching.MemoryCache> can grow to. The default value is 0, which means that the autosizing heuristics of the <xref:System.Runtime.Caching.MemoryCache> class are used by default.|  
|`name`|The name of the cache.|  
|`physicalMemoryLimitPercentage`|An integer value between 0 and 100 that specifies the maximum percentage of physically installed computer memory that can be consumed by the cache. The default value is 0, which means that the autosizing heuristics of the <xref:System.Runtime.Caching.MemoryCache> class are used by default.|  
|`pollingInterval`|A value that indicates the time interval after which the cache implementation compares the current memory load against the absolute and percentage-based memory limits that are set for the cache instance. This value is entered in "HH:MM:SS" format.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/runtime/add-element-for-namedcaches.md)|Adds a named cache to the `namedCaches` collection for a memory cache.|  
|[\<clear>](../../../../../docs/framework/configure-apps/file-schema/runtime/clear-element-for-namedcaches.md)|Clears the `namedCaches` collection for a memory cache.|  
|[\<remove>](../../../../../docs/framework/configure-apps/file-schema/runtime/remove-element-for-namedcaches.md)|Removes a named cache entry from the `namedCaches` collection for a memory cache.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<memoryCache>](../../../../../docs/framework/configure-apps/file-schema/runtime/memorycache-element-cache-settings.md)|Defines an element that is used to configure a cache that is based on the <xref:System.Runtime.Caching.MemoryCache> class.|  
  
## Remarks  
 The memory cache configuration section of the Web.config file can contain `add`, `remove`, and `clear` attributes for the `namedCaches` collection. Each `namedCaches` entry is uniquely identified by the `name` attribute.  
  
 You can retrieve instances of memory cache entries by referencing the information in the application configuration files. By default, only the default cache instance has an entry in the configuration file. The default cache instance is the instance that is returned from the <xref:System.Runtime.Caching.MemoryCache.Default%2A> property.  
  
 If you set the name attribute to "default", the element uses the default memory cache instance.  
  
## Example  
 The following example shows how to set the name of the cache to the default cache entry name by setting the `name` attribute to "default".  
  
 The `cacheMemoryLimitMegabytes` attribute and the `physicalMemoryPercentage` attribute are set to zero. Setting these attributes to zero means that the autosizing heuristics of the <xref:System.Runtime.Caching.MemoryCache> class are used. The cache implementation compares the current memory load against the absolute and percentage-based memory limits every two minutes.  
  
```xml  
<configuration>  
  
  <system.runtime.caching>  
    <memoryCache>  
      <namedCaches>  
          <add name="default"   
               cacheMemoryLimitMegabytes="0"   
               physicalMemoryLimitPercentage="0"  
               pollingInterval="00:02:00" />  
      </namedCaches>  
    </memoryCache>  
  </system.runtime.caching>  
  
</configuration>  
```  
  
## See Also  
 [\<memoryCache> Element (Cache Settings)](../../../../../docs/framework/configure-apps/file-schema/runtime/memorycache-element-cache-settings.md)
