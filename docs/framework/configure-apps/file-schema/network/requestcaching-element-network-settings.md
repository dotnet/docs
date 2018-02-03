---
title: "&lt;requestCaching&gt; Element (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#requestCaching"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/requestCaching"
helpviewer_keywords: 
  - "requestCaching element"
  - "<requestCaching> element"
ms.assetid: 9962a2fe-cbda-41a6-9377-571811eaea84
caps.latest.revision: 20
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;requestCaching&gt; Element (Network Settings)
Controls the caching mechanism for network requests.  
  
 \<configuration>  
\<system.net>  
\<requestCaching>  
  
## Syntax  
  
```xml  
      <requestCaching>  
        isPrivateCache ="true|false"  
        disableAllCaching="true|false"  
        defaultPolicyLevel="BypassCache|Default|CacheOnly|CacheIfAvailable|Revalidate|Reload|NoCacheNoStore|Revalidate"  
        unspecifiedMaximumAge= "d.hh.mm.ss">  
          <defaultHttpCachePolicy> … </defaultHttpCachePolicy>  
          <defaultFtpCachePolicy> … </defaultFtpCachePolicy>  
      </requestCaching>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`isPrivateCache`|Specifies whether the cache provides isolation between the information of different users. The default value is `true`. This value should be `false` for middle tier applications.|  
|`disableAllCaching`|Specifies that caching is disabled for all Web responses, and cannot be overridden programmatically.|  
|`defaultPolicyLevel`|One of the values in the <xref:System.Net.Cache.RequestCacheLevel> enumeration. The default value is `BypassCache`.|  
|`unspecifiedMaximumAge`|Specifies the default time after which content is marked as expired.|  
  
## policyLevel Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`Default`|Returns the cached resource if the resource is fresh, the content length is accurate, and the expiration, modification, and content length attributes are present.|  
|`BypassCache`|Returns the resource from the server.|  
|`CacheOnly`|Returns the cached resource if the content length is present and matches the entry size.|  
|`CacheIfAvailable`|Returns the cached resource if the content length is provided and matches the entry size; otherwise, the resource is downloaded from the server and is returned to the caller.|  
|`Revalidate`|Returns the cached resource if the timestamp of the cached resource is the same as the timestamp of the resource on the server; otherwise, the resource is downloaded from the server, stored in the cache, and is returned to the caller.|  
|`Reload`|Downloads the resource from the server, stores it in the cache, and returns the resource to the caller.|  
|`NoCacheNoStore`|If a cached resource exists, it is deleted. The resource is downloaded from the server and is returned to the caller.|  
|`Revalidate`|Satisfies a request by using the cached copy of the resource if the timestamp is the same as the timestamp of the resource on the server; otherwise, the resource is downloaded from the server, presented to the caller, and is stored in the cache,|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[defaultHttpCachePolicy](../../../../../docs/framework/configure-apps/file-schema/network/defaulthttpcachepolicy-element-network-settings.md)|Optional element.<br /><br /> Describes whether HTTP caching is active and describes the default caching policy.|  
|[\<defaultFtpCachePolicy> Element (Network Settings)](../../../../../docs/framework/configure-apps/file-schema/network/defaultftpcachepolicy-element-network-settings.md)|Optional element.<br /><br /> Describes whether FTP caching is active and describes the default caching policy.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[system.net](../../../../../docs/framework/configure-apps/file-schema/network/system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Example  
 The following example shows how to disable all caching.  
  
```xml  
<configuration>  
  <system.net>  
    <requestCaching  
      disableAllCaching="true"  
    />  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net.Cache?displayProperty=nameWithType>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
