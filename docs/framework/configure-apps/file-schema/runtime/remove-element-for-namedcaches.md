---
title: "<remove> Element for <namedCaches>"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "remove element for namedCaches"
  - "<remove> element for namedCaches"
ms.assetid: 24211ea5-163e-4fe5-aed8-004d8499760c
---
# \<remove> Element for \<namedCaches>
Removes a named cache entry from the `namedCaches` collection for a memory cache.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.runtime.caching>**](system-runtime-caching-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<memoryCache>**](memorycache-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<namedCaches>**](namedcaches-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<remove>**  
  
## Syntax  
  
```xml  
<namedCaches>  
    <remove name="default" />  
    <!-- child elements -->  
 </namedCaches>  
```  
  
## Type  
 `None`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 `None`  
  
### Child Elements  
 `None`  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<namedCaches>](namedcaches-element-cache-settings.md)|Contains a collection of configuration settings for the named <xref:System.Runtime.Caching.MemoryCache> instances.|  
  
## Remarks  
 The `remove` element removes a `namedCache` entry from the named cache collection for a memory cache.  
  
## See also

- [\<namedCaches> Element (Cache Settings)](namedcaches-element-cache-settings.md)
