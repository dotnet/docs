---
title: "&lt;caches&gt; | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4651091b-3a20-40d8-b293-4408c0710143
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
---
# &lt;caches&gt;
Registers the caches used for session tokens and token replay detection.  
  
 \<system.identityModel>  
\<identityConfiguration>  
\<caches>  
  
## Syntax  
  
```  
<system.identityModel>  
  <identityConfiguration>  
    <caches>  
    </caches>  
  </identityConfiguration>  
</system.identityModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<sessionSecurityTokenCache>](../../../../../docs/framework/configuring-apps/file-schema/wif/sessionsecuritytokencache.md)|Registers a cache for session tokens with a service or a security token handler collection.|  
|[\<tokenReplayCache>](../../../../../docs/framework/configuring-apps/file-schema/wif/tokenreplaycache.md)|Registers a token replay cache with a service or a security token handler collection.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<identityConfiguration>](../../../../../docs/framework/configuring-apps/file-schema/wif/identityconfiguration.md)|Specifies service-level identity settings.|  
|[\<securityTokenHandlerConfiguration>](../../../../../docs/framework/configuring-apps/file-schema/wif/securitytokenhandlerconfiguration.md)|Provides configuration for a collection of security token handlers.|  
  
## Remarks  
 A `<caches>` element can be specified at the service level under the `<identityConfiguration>` element or on the security token handler collection level under the `<securityTokenHandlerConfiguration>` element. Settings on a token handler collection override those specified on the service.  
  
 The `<caches>` element is represented by the <xref:System.IdentityModel.Configuration.IdentityModelCachesElement> class. The configured caches are represented by the <xref:System.IdentityModel.Configuration.IdentityModelCaches> class.  
  
## Example  
 The following XML shows the configuration of a custom cache for holding session security tokens (<xref:System.IdentityModel.Tokens.SessionSecurityToken>). The configuration is taken from the `ClaimsAwareWebFarm` sample.  
  
```  
<caches>  
  <sessionSecurityTokenCache type="CacheLibrary.SharedSessionSecurityTokenCache, CacheLibrary">  
    <!--cacheServiceAddress points to the centralized session security token cache service running in the web farm.-->  
    <cacheServiceAddress url="http://localhost:4161/SessionSecurityTokenCacheService.svc" />  
  </sessionSecurityTokenCache>  
</caches>  
```