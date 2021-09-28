---
description: "Learn more about: <windowsAuthentication> of <serviceCredentials>"
title: "<windowsAuthentication> of <serviceCredentials>"
ms.date: "03/30/2017"
ms.assetid: e0709473-0997-4de3-8f49-783527309a48
---
# \<windowsAuthentication> of \<serviceCredentials>

Specifies the settings of a Windows service credential.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceCredentials>**](servicecredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<windowsAuthentication>**  
  
## Syntax  
  
```xml  
<windowsAuthentication allowAnonymousLogons="Boolean"
                       includeWindowsGroups="Boolean" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`includeWindowsGroups`|An optional Boolean attribute that specifies whether the system includes Windows groups in the security context. The default is `true`.<br /><br /> Setting this attribute to `true` has a performance impact as it results in a full-group expansion. Set this attribute to `false` if you do not need to establish the list of groups a user belongs to.|  
|`allowAnonymousLogons`|An optional Boolean attribute that specifies whether anonymous, unauthenticated callers are allowed. The default is `false`.<br /><br /> When the `clientCredentialType` attribute of a binding is set to `Windows`, the system does not allow anonymous callers. This means that only domain or workgroup authenticated callers are allowed to access the system. You can override this behavior by using this attribute.<br /><br /> Use this setting with extreme caution.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceCredentials>](servicecredentials.md)|Specifies the credential to be used in authenticating the service, and the client credential validation-related settings.|  
  
## Remarks  

 Use this element to specify whether to allow anonymous Windows users access by setting the `allowAnonymousLogons` attribute. You can also specify whether to include group information to which users belong in the AuthorizationContext by setting the `includeWindowsGroups` attribute. If it is set to `true` (the default setting), the service can determine the Windows groups to which the client belongs.  
  
## See also

- <xref:System.ServiceModel.Configuration.WindowsServiceElement>
- <xref:System.ServiceModel.Configuration.ServiceCredentialsElement.WindowsAuthentication%2A>
- <xref:System.ServiceModel.Description.ServiceCredentials.WindowsAuthentication%2A>
- <xref:System.ServiceModel.Security.WindowsServiceCredential>
