---
title: "<add> Element for <namedCaches>"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "add element for <namedCaches>"
  - "<add> element for <namedCaches>"
ms.assetid: ce2a63a8-c829-4742-a6ea-72ee5d89f169
---
# \<add> Element for \<namedCaches>
Adds a `namedCache` entry to the `namedCaches` collection for a memory cache.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.runtime.caching>**](system-runtime-caching-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<memoryCache>**](memorycache-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<namedCaches>**](namedcaches-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**  
  
## Syntax  
  
```xml  
<namedCaches>  
    <add name="Default" />  
      <!-- child elements -->  
 </namedCaches>  
```  
  
## Type  
 `None`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|-|-|  
|`CacheMemoryLimitMegabytes`|An integer value that specifies the maximum allowed size (in megabytes) that an instance of a <xref:System.Runtime.Caching.MemoryCache> can grow to. The default value is 0, which means that the <xref:System.Runtime.Caching.MemoryCache> class's autosizing heuristics are used by default.|  
|`Name`|The name of the cache.|  
|`PhysicalMemoryLimitPercentage`|An integer value between 0 and 100 that specifies the maximum percentage of physically installed computer memory that can be consumed by the cache. The default value is 0, which means that the <xref:System.Runtime.Caching.MemoryCache> class's autosizing heuristics are used by default.|  
|`PollingInterval`|A value that indicates the time interval after which the cache implementation compares the current memory load against the absolute and percentage-based memory limits that are set for the cache instance. This value is entered in "HH:MM:SS" format.|  
  
### Child Elements  
 `None`  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<namedCaches>](namedcaches-element-cache-settings.md)|Contains a collection of configuration settings for the named <xref:System.Runtime.Caching.MemoryCache> instances.|  
  
## Remarks  
 The `add` element adds an entry to the `namedCaches` collection for a memory cache. You can use the [clear](clear-element-for-namedcaches.md) element before you use the `add` element to be certain that there are no other named caches in the collection. This element can be used in the machine.config file and in the Web.config file.  
  
## Example  
 The following example shows how to define settings for the default `namedCache` entry to the `namedCaches` collection for a memory cache.  
  
```xml  
<configuration>  
  
  <system.runtime.caching>  
    <memoryCache>  
      <namedCaches>  
          <add name="Default"   
               cacheMemoryLimitMegabytes="0"   
               physicalMemoryPercentage="0"  
               pollingInterval="00:02:00" />  
      </namedCaches>  
    </memoryCache>  
  </system.runtime.caching>  
  
</configuration>  
```  
  
## See also

- [\<namedCaches> Element (Cache Settings)](namedcaches-element-cache-settings.md)
