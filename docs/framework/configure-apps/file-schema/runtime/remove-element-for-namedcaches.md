---
title: "&lt;remove&gt; Element for &lt;namedCaches&gt;"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "remove element for namedCaches"
  - "<remove> element for namedCaches"
ms.assetid: 24211ea5-163e-4fe5-aed8-004d8499760c
author: "mcleblanc"
ms.author: "markl"
---
# &lt;remove&gt; Element for &lt;namedCaches&gt;
Removes a named cache entry from the `namedCaches` collection for a memory cache.  
  
 \<system.runtime.caching>  
\<memoryCache>  
\<namedCaches>  
\<remove>  
  
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
|[\<namedCaches>](../../../../../docs/framework/configure-apps/file-schema/runtime/namedcaches-element-cache-settings.md)|Contains a collection of configuration settings for the named <xref:System.Runtime.Caching.MemoryCache> instances.|  
  
## Remarks  
 The `remove` element removes a `namedCache` entry from the named cache collection for a memory cache.  
  
## See Also  
 [\<namedCaches> Element (Cache Settings)](../../../../../docs/framework/configure-apps/file-schema/runtime/namedcaches-element-cache-settings.md)
