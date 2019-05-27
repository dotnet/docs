---
title: "<claimTypeRequired>"
ms.date: "03/30/2017"
ms.assetid: c469d71f-6c77-4a24-97aa-53efa126ceef
author: "BrucePerlerMS"
---
# \<claimTypeRequired>
Specifies the set of required claims for incoming security tokens.  
  
 \<system.identityModel>  
\<identityConfiguration>  
\<claimTypeRequired>  
  
## Syntax  
  
```xml  
<system.identityModel>  
  <identityConfiguration>  
    <claimTypeRequired>  
    </claimTypeRequired>  
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
|[\<claimType>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/claimtype.md)|Specifies a single optional or required claim for incoming security tokens.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<identityConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/identityconfiguration.md)|Specifies service-level identity settings.|
