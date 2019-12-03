---
title: "<claimTypeRequired>"
ms.date: "03/30/2017"
ms.assetid: c469d71f-6c77-4a24-97aa-53efa126ceef
author: "BrucePerlerMS"
---
# \<claimTypeRequired>
Specifies the set of required claims for incoming security tokens.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.identityModel>**](system-identitymodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<identityConfiguration>**](identityconfiguration.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<claimTypeRequired>**  
  
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
|[\<claimType>](claimtype.md)|Specifies a single optional or required claim for incoming security tokens.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<identityConfiguration>](identityconfiguration.md)|Specifies service-level identity settings.|
