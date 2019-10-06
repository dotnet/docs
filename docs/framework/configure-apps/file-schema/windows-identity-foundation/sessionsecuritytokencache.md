---
title: "<sessionSecurityTokenCache>"
ms.date: "03/30/2017"
ms.assetid: d43e676c-0153-485c-ab31-0257a2db7507
author: "BrucePerlerMS"
---
# \<sessionSecurityTokenCache>
Registers a cache for session tokens with a service or a security token handler collection.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.identityModel>**](system-identitymodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<identityConfiguration>**](identityconfiguration.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<caches>**](caches.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<sessionSecurityTokenCache>**  
  
## Syntax  
  
```xml  
<system.identityModel>  
  <identityConfiguration>  
    <caches>  
      <sessionSecurityTokenCache type=xs:string>  
      </sessionSecurityTokenCache>  
    </caches>  
  </identityConfiguration>  
</system.identityModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|type|A type that derives from the <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache> class.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<caches>](caches.md)|Registers the caches used by a service or a security token handler collection.|  
  
## Example  
 The following XML shows the configuration of a custom cache for holding session security tokens (<xref:System.IdentityModel.Tokens.SessionSecurityToken>). The configuration is taken from the `ClaimsAwareWebFarm` sample. For more information about this sample, see [WIF Code Sample Index](../../../security/wif-code-sample-index.md).  
  
```xml  
<caches>  
  <sessionSecurityTokenCache type="CacheLibrary.SharedSessionSecurityTokenCache, CacheLibrary">  
    <!--cacheServiceAddress points to the centralized session security token cache service running in the web farm.-->  
    <cacheServiceAddress url="http://localhost:4161/SessionSecurityTokenCacheService.svc" />  
  </sessionSecurityTokenCache>  
</caches>  
```  
  
## See also

- <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache>
