---
description: "Learn more about: <defaultFtpCachePolicy> Element (Network Settings)"
title: "<defaultFtpCachePolicy> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#defaultFtpCachePolicy"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/requestCaching/defaultFtpCachePolicy"
helpviewer_keywords: 
  - "<defaultFtpCachePolicy> element"
  - "defaultFtpCachePolicy element"
ms.assetid: 0eb0c5cb-dd97-484d-8614-785e88877abb
---
# \<defaultFtpCachePolicy> Element (Network Settings)

Describes whether FTP caching is active and describes the default caching policy.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<requestCaching>**](requestcaching-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<defaultFtpCachePolicy>**

## Syntax  
  
```xml  
<defaultFtpCachePolicy  
  policyLevel="BypassCache|Default|CacheOnly|CacheIfAvailable|Revalidate|Reload|NoCacheNoStore|Revalidate"  
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`policyLevel`|Specifies the FTP caching policy. The default value is `Default`.|  
  
## policyLevel Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`Default`|Returns the cached resource if the resource is fresh, the content length is accurate, and the expiration, modification, and content length attributes are present.|  
|`BypassCache`|Returns the resource from the server.|  
|`CacheOnly`|Returns the cached resource if the content length is present and matches the entry size.|  
|`CacheIfAvailable`|Returns the cached resource if the content length is provided and matches the entry size; otherwise, the resource is downloaded from the server and is returned to the caller.|  
|`Revalidate`|Returns the cached resource if the timestamp of the cached resource is the same as the timestamp of the resource on the server; otherwise, the resource is downloaded from the server, stored in the cache, and returned to the caller.|  
|`Reload`|Downloads the resource from the server, stores it in the cache, and returns the resource to the caller.|  
|`NoCacheNoStore`|If a cached resource exists, it is deleted. The resource is downloaded from the server and is returned to the caller.|  
|`Revalidate`|Satisfies a request by using the cached copy of the resource if the timestamp is the same as the timestamp of the resource on the server; otherwise, the resource is downloaded from the server, presented to the caller, and stored in the cache.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[requestCaching](requestcaching-element-network-settings.md)|Controls the caching mechanism for network requests.|  
  
## Remarks  
  
## Example  

 The following example shows how to specify an FTP caching policy of `NoCacheNoStore`.  
  
```xml  
<configuration>  
  <system.net>  
    <requestCaching>  
      <defaultFtpCachePolicy  
        policyLevel="NoCacheNoStore">  
      </defaultFtpCachePolicy>  
    </requestCaching>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.Cache>
- <xref:System.Net.WebRequest>
- <xref:System.Net.Cache.RequestCacheLevel>
- [Network Settings Schema](index.md)
