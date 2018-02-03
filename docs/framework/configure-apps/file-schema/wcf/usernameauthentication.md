---
title: "&lt;userNameAuthentication&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 24d8b398-770f-418f-ba23-c4325419cfa6
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;userNameAuthentication&gt;
Specifies a service's credentials based on user name and password.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceCredentials>  
\<userNameAuthentication>  
  
## Syntax  
  
```xml  
<userNameAuthentication  
   cacheLogonTokenLifetime="TimeSpan"  
   cacheLogonTokens="Boolean"   
   customUserNamePasswordValidatorType="String"  
   includeWindowsGroups="Boolean"   
   maxCacheLogonTokens="Integer"  
   membershipProviderName="String"  
   userNamePasswordValidationMode="Windows/MembershipProvider/Custom" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`cacheLogonTokenLifetime`|A <xref:System.TimeSpan> that specifies the maximum length of time a token is cached. The default is 00:15:00.|  
|`cacheLogonTokens`|A Boolean value that specifies whether logon tokens are cached. The default is `false`.|  
|`customUserNamePasswordValidatorType`|A string that specifies the type of custom username password validator to be used. The default is an empty string.|  
|`includeWindowsGroups`|A Boolean value that specifies whether Windows groups are included in the security context. The default is `true`.<br /><br /> Setting this attribute to `true` has a performance impact as it results in a full-group expansion. Set this property to `false` if you do not need to establish the list of groups a user belongs to.|  
|`maxCacheLogonTokens`|An integer that specifies the maximum number of logon tokens to cache. This value should be larger than zero. The default is 128.|  
|`membershipProviderName`|When the `clientCredentialType` attribute of a binding is set to `username`, the username is mapped to Windows accounts. You can override this behavior using this attribute, which is a string that contains the name of the <xref:System.Web.Security.MembershipProvider> value that provides the relevant password validation mechanism.|  
|`userNamePasswordValidationMode`|Specifies the manner in which username password is validated. Valid values are:<br /><br /> -   Windows<br />-   MembershipProvider<br />-   Custom<br /><br /> The default is Windows. This attribute is of type <xref:System.ServiceModel.Security.UserNamePasswordValidationMode>.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicecredentials.md)|Specifies the credential to be used in authenticating the service, and the client credential validation related settings.|  
  
## Remarks  
 If none of the bindings used by a service is configured for user name/password-based authentication, the attributes for this element are ignored. These include `customUserNamePasswordValidatorType`, `includeWindowsGroups`, `membershipProviderName`, and `userNamePasswordValidationMode`.  
  
 If none of the bindings used by a service is configured to use Windows authentication for user name/password, the settings related to caching of logon tokens are ignored. These include the `cacheLogonTokenLifetime`, `cacheLogonTokens`, and `maxCacheLogonTokens`.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.UserNameServiceElement>  
 <xref:System.ServiceModel.Description.ServiceCredentials.UserNameAuthentication%2A>  
 <xref:System.ServiceModel.Security.UserNamePasswordServiceCredential>  
 <xref:System.ServiceModel.Configuration.ServiceCredentialsElement.UserNameAuthentication%2A>
