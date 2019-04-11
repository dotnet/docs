---
title: "<serviceAuthenticationManager>"
ms.date: "03/30/2017"
ms.assetid: 5d69e64f-f325-4d55-8e2d-0fb30f222dda
---
# \<serviceAuthenticationManager>
Provides a workflow configuration element that establishes at the service level the validity of a transmission, message, or originator.  
  
\<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceAuthenticationManager>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <serviceAuthenticationManager serviceAuthenticationManagerType="String" />
    </behavior>
  </serviceBehaviors>
</behaviors>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|serviceAuthenticationManagerType|A string that specifies the type of the authentication policy for the current behavior.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## See also

- <xref:System.ServiceModel.Configuration.ServiceAuthenticationElement>
