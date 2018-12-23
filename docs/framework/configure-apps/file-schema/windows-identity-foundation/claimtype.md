---
title: "&lt;claimType&gt;"
ms.date: "03/30/2017"
ms.assetid: d17b5831-9a2c-45c4-b0d1-68f48e72e861
author: "BrucePerlerMS"
---
# &lt;claimType&gt;
Specifies a single optional or required claim for incoming security tokens.  
  
 \<system.identityModel>  
\<identityConfiguration>  
\<claimTypeRequired>  
\<claimType>  
  
## Syntax  
  
```xml  
<system.identityModel>  
  <identityConfiguration>  
    <claimTypeRequired>  
      <claimType type=URI optional=xs:boolean >  
      </claimType>  
    </claimTypeRequired>  
  </identityConfiguration>  
</system.identityModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|type|The claim type. Typically a URI. Required.|  
|optional|A boolean value that specifies whether the claim type is optional. Optional.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<claimTypeRequired>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/claimtyperequired.md)|Specifies the set of required claims for incoming security tokens.|
