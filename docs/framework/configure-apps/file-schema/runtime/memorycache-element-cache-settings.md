---
description: "Learn more about: <memoryCache> Element (Cache Settings)"
title: "<memoryCache> Element (Cache Settings)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "<memoryCache> element"
  - "caching [.NET Framework], configuration"
  - "memoryCache element"
ms.assetid: 182a622f-f7cf-472d-9d0b-451d2fd94525
---
# \<memoryCache> Element (Cache Settings)

Defines an element that is used to configure a cache that is based on the <xref:System.Runtime.Caching.MemoryCache> class. The <xref:System.Runtime.Caching.Configuration.MemoryCacheElement> class defines a [memoryCache](memorycache-element-cache-settings.md) element that you can use to configure the cache. Multiple instances of the <xref:System.Runtime.Caching.MemoryCache> class can be used in a single application. Each `memoryCache` element in the configuration file can contain settings for a named <xref:System.Runtime.Caching.MemoryCache> instance.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.runtime.caching>**](system-runtime-caching-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<memoryCache>**  
  
## Syntax  
  
```xml  
<memoryCache>
    <namedCaches>  
        <!-- child elements -->  
    </namedCaches>
</memoryCache>  
```  
  
## Type  

 <xref:System.Runtime.Caching.MemoryCache> class.  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`CacheMemoryLimitMegabytes`|The maximum memory size, in megabytes, that an instance of a <xref:System.Runtime.Caching.MemoryCache> object can grow to. The default value is 0, which means that the <xref:System.Runtime.Caching.MemoryCache> class's autosize heuristics are used by default.|  
|`Name`|The name of the cache configuration.|  
|`PhysicalMemoryLimitPercentage`|The percentage of physical memory that can be used by the cache. The default value is 0, which means that the <xref:System.Runtime.Caching.MemoryCache> class's autosize heuristics are used by default.|  
|`PollingInterval`|A value that indicates the time interval after which the cache implementation compares the current memory load against the absolute and percentage-based memory limits that are set for the cache instance. The value is entered in "HH:MM:SS" format.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<namedCaches>](namedcaches-element-cache-settings.md)|Contains a collection of configuration settings for the `namedCache` instance.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration>](../configuration-element.md)|Specifies the root element in every configuration file that is used by the common language runtime and .NET Framework applications.|  
|[\<system.runtime.caching>](system-runtime-caching-element-cache-settings.md)|Contains types that let you implement output caching in applications that are built into the .NET Framework.|  
  
## Remarks  

 The <xref:System.Runtime.Caching.MemoryCache> class is a concrete implementation of the abstract <xref:System.Runtime.Caching.ObjectCache> class. Instances of the <xref:System.Runtime.Caching.MemoryCache> class can be supplied with configuration information from application configuration files. The [memoryCache](memorycache-element-cache-settings.md) configuration section contains a `namedCaches` configuration collection.  
  
 When a memory-based cache object is initialized, it first tries to find a `namedCaches` entry that matches the name in the parameter that is passed to the memory cache constructor. If a `namedCaches` entry is found, the polling and memory-management information are retrieved from the configuration file.  
  
 The initialization process then determines whether any configuration entries were overridden, by using the optional collection of name/value pairs of configuration information in the constructor. If you pass any one of the following values in the name/value pair collection, these values override information obtained from the configuration file:  
  
- <xref:System.Runtime.Caching.Configuration.MemoryCacheElement.CacheMemoryLimitMegabytes%2A>  
  
- <xref:System.Runtime.Caching.Configuration.MemoryCacheElement.PhysicalMemoryLimitPercentage%2A>  
  
- <xref:System.Runtime.Caching.MemoryCache.PollingInterval%2A>  
  
## Example  

 The following example shows how to set the name of the <xref:System.Runtime.Caching.MemoryCache> object to the default cache object name by setting the `name` attribute to "Default".  
  
 The `cacheMemoryLimitMegabytes` attribute and the `physicalMemoryLimitPercentage` attribute are set to zero. Setting these attributes to zero means that the <xref:System.Runtime.Caching.MemoryCache> autosizing heuristics are used by default. The cache implementation should compare the current memory load against the absolute and percentage-based memory limits every two minutes.  
  
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

- <xref:System.Runtime.Caching.MemoryCache>
- [\<system.runtime.caching> Element (Cache Settings)](system-runtime-caching-element-cache-settings.md)
- [\<namedCaches> Element (Cache Settings)](namedcaches-element-cache-settings.md)
