---
title: "&lt;tokenReplayCache&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1572ab23-6933-41b5-bfb4-0c4548145500
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;tokenReplayCache&gt;
Registers a token replay cache with a service or a security token handler collection.  
  
 \<system.identityModel>  
\<identityConfiguration>  
\<caches>  
\<tokenReplayCache>  
  
## Syntax  
  
```xml  
<system.identityModel>  
  <identityConfiguration>  
    <caches>  
      <tokenReplayCache type=xs:string>  
      </tokenReplayCache>  
    </caches>  
  </identityConfiguration>  
</system.identityModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|type|A type that derives from the <xref:System.IdentityModel.Tokens.TokenReplayCache> class. For more information about how to specify a custom `type`, see [Custom Type References].
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<caches>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/caches.md)|Registers the caches used by a service or a security token handler collection.|  
  
## Remarks  
 The token replay cache is used to detect replayed tokens. Token replay detection is enabled by the [\<tokenReplayDetection>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/tokenreplaydetection.md) element, which also specifies the maximum expiration time for tokens.  
  
## Example  
 The following XML shows the configuration of a custom cache for detecting replayed tokens.  
  
```xml  
<caches>  
  <tokenReplayCache type="MyCacheLibrary.MyTokenReplayCache, MyCacheLibrary">  
  </tokenReplayCache>  
</caches>  
```  
  
## See Also  
 <xref:System.IdentityModel.Tokens.TokenReplayCache>  
 [\<tokenReplayDetection>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/tokenreplaydetection.md)
